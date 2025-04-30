#include <sys/socket.h>
#include <sys/types.h>
#include <errno.h>
#include <getopt.h>
#include <netdb.h>
#include <netinet/in.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <mqueue.h>
#include <sys/mman.h>
#include <fcntl.h>
#include <semaphore.h>


#define MSG_QUEUE "/shm_server_queue"
#define SHM_NAME "/shm_file_transfer"
#define MAX_MSG 256
#define SHM_SIZE 4096
#define SEM_NAME "/shm_file_sem"

#define BUFSIZE 512

#define USAGE                                            \
  "usage:\n"                                             \
  "  shm_server [options]\n"                             \
  "options:\n"                                           \
  "  -h                  Show this help message\n"       \

/* OPTIONS DESCRIPTOR ====================================================== */
static struct option gLongOptions[] = {
    {"help", no_argument, NULL, 'h'},
    {NULL, 0, NULL, 0} };


// handle the datatransfer in shared mem
typedef struct 
{
    int total_size;
    int sent_size;
    char buffer[SHM_SIZE];
    
} shm_data_t;


int main(int argc, char** argv) 
{
    int option_char;

    setbuf(stdout, NULL);  // disable buffering

    // Parse and set command line arguments
    while ((option_char =
        getopt_long(argc, argv, "hx", gLongOptions, NULL)) != -1) 
    {
        switch (option_char) 
        {
            case 'h':  // help
                fprintf(stdout, "%s", USAGE);
                exit(0);
                break;
            default:
                fprintf(stderr, "%s", USAGE);
                exit(1);
        }
    }


    /* Server Code Here */
   // printf("You need to write the code to make this do something!\n");

// posix message que
  mqd_t msg_queue;

    struct mq_attr attr;

    attr.mq_flags = 0;
    attr.mq_maxmsg = 10; // max num of msg que
    attr.mq_msgsize = 256; // max msg size
    attr.mq_msgs = 0; // current num of msg

   if ((msg_queue = mq_open(MSG_QUEUE, O_CREAT | O_RDWR, 0644, &attr)) == -1) {
    perror("mq_open");
    exit(1);
}
printf("Message queue created\n");

// posix shared memory region
    int shm_fd = shm_open(SHM_NAME, O_CREAT | O_RDWR, 0644);
if (shm_fd == -1) { perror("shm_open"); exit(EXIT_FAILURE); }

if (ftruncate(shm_fd, sizeof(shm_data_t)) == -1) {
    perror("ftruncate");

    exit(EXIT_FAILURE);
}

shm_data_t* shm_ptr = mmap(NULL, sizeof(shm_data_t), PROT_READ | PROT_WRITE, MAP_SHARED, shm_fd, 0);
if (shm_ptr == MAP_FAILED) { perror("mmap"); 

    exit(EXIT_FAILURE); }

    printf("Shared memory created \n");


// semaphore
   sem_t* sem = sem_open(SEM_NAME, O_CREAT, 0644, 1);
if (sem == SEM_FAILED) { perror("sem_open"); 
    
    exit(EXIT_FAILURE); }

    printf("Semaphore created \n");


// handle file and connecting to message que
 char buffer[MAX_MSG];

    while (1) 
    {
        // get message from client
        ssize_t bytes_read = mq_receive(msg_queue, buffer, MAX_MSG, NULL);

        if (bytes_read == -1) 
        {
            perror("mq_receive");
            continue;

        }

        printf("Client message: %s\n", buffer);


// sem to protect mem
    sem_wait(sem);    


// open file
   FILE *file = fopen(buffer, "r"); 
   if (!file) {
        perror("fopen");
        sem_post(sem);
        
        continue;     
    }

        // get file size through pointer
        fseek(file, 0, SEEK_END);

        (*shm_ptr).total_size = ftell(file);

        rewind(file);

        // send file data w pointer
        (*shm_ptr).sent_size = 0;

        while ((bytes_read = fread((*shm_ptr).buffer, 1, SHM_SIZE, file)) > 0) 
        {
             (*shm_ptr).sent_size += bytes_read;
        }

        fclose(file);
        sem_post(sem);
    }

    return 0;
}



//references for posix 
//https://www.softprayog.in/programming/interprocess-communication-using-posix-shared-memory-in-linux
//https://www.geeksforgeeks.org/posix-shared-memory-api/
//https://gist.github.com/juniorprincewang/16cb7e8f9fd51dc5857b00580dab9b38
// https://pubs.opengroup.org/onlinepubs/9699919799/functions/shm_open.html
