#include <stdio.h>
#include <stdlib.h>
#include <getopt.h>


#define TRUE 1
#define FALSE 0

/* Declare the linked list structures */

// Definition of each node
struct node {
   int data;
   struct node *next;
};

// The head node (start of list)
struct node *head = NULL;

// Variable to represent the current node
struct node *current = NULL;


void addtofront( int data){  

    struct node *newNode = (struct node*) malloc(sizeof(struct node)); 

    newNode->data = data;

    newNode->next = head; //points to original first node

    head = newNode; //points to new head
}


void addatend(int data){

    struct node* newNode = (struct node*) malloc(sizeof(struct node)); //function to add new node list

    newNode->data = data;

    newNode->next = NULL;

    if (head == NULL) { //check if list is empty
        
        head = newNode;
    
    } else {
                
        current = head; //find last node in the list

        while (current->next != NULL) {

            current = current->next;
        }
        
        current->next = newNode; //add new node to the end of the list
    }
}


void deletenode(int data) {


    if (head == NULL) { //check if list is empty

        printf("List is empty\n"); 
        
        return;
    }

    if (head->data == data) { //check if the first node would be deleted
        
        struct node* temp = head;
        
        head = head->next;
        
        free(temp); //release memory to prevent memory leak

        return;
    }

    
    current = head;

    
    while (current->next != NULL) {
    
        if (current->next->data == data) {
    
            struct node* temp = current->next;
    
            current->next = current->next->next;
    
            free(temp);
    
            return;
        }
    
        current = current->next;
    }

    printf("Node not found in list\n");

}

void printlist() { //prints the entire list
    
    current = head; 
    
    while (current != NULL) {
    
        printf("%d ", current->data);
    
        current = current->next;
    }
    
    printf("\n");
}


/* Main ========================================================= */
int main() {

    printf("Linked List Program!!!\n");

    addtofront(23);
    addtofront(99);
    addatend(77);
    addatend(123);
    addtofront(5);
    printlist("Linked List: ");
    
    deletenode(99);
    printlist("");

    return 0;

}




/**
 * Project References - this is where you list any and all resources you used to 
 *  compelete the project
 * 
 * https://www.geeksforgeeks.org/singly-linked-list-tutorial/
 * https://www.tutorialspoint.com/data_structures_algorithms/linked_list_algorithms.htm
 * 
 * l
*/ 
