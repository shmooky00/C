using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            stack.Push(1); //sincce stack is made as an iint, can only push int 
            stack.Push(30); 

            var result = stack.Pop(); //returns the item that pops, last thing in the push

            Console.WriteLine(result);

            var myList = new List<int>();

            var queue = new Queue<int>();
        }
    }
}
