using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBalanced_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input1 = IsBalanced("[]()"); //true
            Console.WriteLine(input1);

            var input2 = IsBalanced("{(})"); //false
            Console.WriteLine(input2);

            var input3 = IsBalanced("({[{}]}){ (())}");  //true
            Console.WriteLine(input3);

            var input4 = IsBalanced("]["); //false
            Console.WriteLine(input4);
        }

        public static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            Dictionary<char, char> parBrack = new Dictionary<char, char> //for parenth and brackets
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

            
            foreach (char ch in input) 
            {
                
                if (parBrack.ContainsKey(ch)) //closed bracket 
                {
                    
                    if (stack.Count > 0 && stack.Peek() == parBrack[ch]) //checks if top of stack matches opening and if empty 
                    {
                        stack.Pop(); 
                    }

                    else
                    {
                        return false; 
                    }
                }
                
                else if (parBrack.ContainsValue(ch))
                {
                    stack.Push(ch); 
                }
            }
                        
            return stack.Count == 0;
        }
    }

}
