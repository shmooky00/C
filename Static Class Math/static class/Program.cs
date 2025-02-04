using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace static_class
{

    public static class Math
    {
        // sum of int array
        public static int Sum(int[] array)
        {
            int sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }
            
            return sum;
        }

        // product of int array
        public static int Product(int[] array)
        {
            int product = 1;

            foreach (var item in array)
            {
                product *= item;
            }
            
            return product;
        }

        // avg of int array
        public static double Average(int[] array)
        {
            if (array.Length == 0) 
                
                return 0;
            
            return (double)Sum(array) / array.Length;
        }

        // max value of int array
        public static int Max(int[] array)
        {
            
            int max = array[0];
            
            foreach (var item in array)
            {
                if (item > max) max = item;
            }
            
            return max;
        }

        // min value of int array
        public static int Min(int[] array)
        {
            
            int min = array[0];
            
            foreach (var item in array)
            {
                if (item < min) min = item;
            }
            
            return min;
        }

        // sum of a double array
        public static double Sum(double[] array)
        {
            double sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }
            
            return sum;
        }

        // avg of a double array
        public static double Average(double[] array)
        {
            if (array.Length == 0) 
                
                return 0;

            return Sum(array) / array.Length;
        }

        // max of double array
        public static double Max(double[] array)
        {
            
            double max = array[0];
            
            foreach (var item in array)
            {
                if (item > max) max = item;
            }
            
            return max;
        }

        // min of double array
        public static double Min(double[] array)
        {
            
            double min = array[0];

            foreach (var item in array)
            {
                if (item < min) min = item;
            }
            
            return min;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            int[] intArray = { 1, 2, 3, 4, 5, 6 };

            double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
            
            string[] stringArray = { "11", "22", "4.6", "5", "6", "9" };

            Console.WriteLine($"Int Sum: {Math.Sum(intArray)}");

            Console.WriteLine($"Int Product: {Math.Product(intArray)}");
            
            Console.WriteLine($"Int Average: {Math.Average(intArray)}");
            
            Console.WriteLine($"Int Max: {Math.Max(intArray)}");
            
            Console.WriteLine($"Int Min: {Math.Min(intArray)}");

            Console.WriteLine($"Double Sum: {Math.Sum(doubleArray)}");
            
            Console.WriteLine($"Double Average: {Math.Average(doubleArray)}");
            
            Console.WriteLine($"Double Max: {Math.Max(doubleArray)}");

            Console.WriteLine($"Double Min: {Math.Min(doubleArray)}");

            Console.WriteLine();

            Console.ReadLine();

        }
    }
}
