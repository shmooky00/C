// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong number;

            do
            {
                Console.WriteLine("Please Enter a Number");

                //read number from user    
                number = Convert.ToUInt64(Console.ReadLine());

                if (number < 0)
                    Console.WriteLine("\nPlease enter a positive number\n");

            } while (number < 0);

            Console.WriteLine("\n");

            // Get the nth fibonacci number
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //invoke the static method    
            ulong factorial = FactLoop(number);
            // ulong factorial = FactRecursion(number);
            Console.WriteLine("factorial of " + number + " = " + factorial.ToString());


            // Calculate Fibonacci number n using recursion
            // ulong fibonacci = Fib(number);

            // Calculate Fibonacci number n using dynamic programming
            // ulong fibonacci = Fibonacci(number, 0, 1);
            // Console.WriteLine("Fibonacci of " + number + " numbers = " + fibonacci.ToString());

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("\nRunTime " + elapsedTime);
            Console.ReadKey();



        }

        /**
         * Calculate factorial in a loop
         */
        public static ulong FactLoop(ulong number)
        {
            // Handle special case of 0
            if (number == 0)
                return 1;

            ulong factorial = 1;
            for (ulong i = number; i >= 1; i--)
            {
                factorial = factorial * i;
            }
            return factorial;
        }

        /**
         * Calculate factorial using recursion
         */
        public static ulong FactRecursion(ulong number)
        {
            ulong x;
            if (number == 0)
                return 1;

            // Console.WriteLine(number.ToString());
            x = number * FactRecursion(number - 1); //Recursive call    
            Console.WriteLine(number.ToString());

            return x;
        }

        /**
         * Print Fibonacci series using recursion
         */
        public static ulong Fibonacci(ulong limit, ulong firstnum, ulong secondnum)
        {
            ulong x;

            // Decrement the limit
            limit--;

            ulong total = firstnum + secondnum;

            // When we hit zero, we are done
            if (limit == 0)
                return total;

            
            x = Fibonacci(limit, secondnum, total); //Recursive call                
            Console.WriteLine(total.ToString());
            return x;
        }

        /**
         * Print the nth Fibonacci number
         */
        public static ulong Fib(ulong n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
    }
}
