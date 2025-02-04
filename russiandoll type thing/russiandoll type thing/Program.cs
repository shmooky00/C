using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace russiandoll_type_thing
{

    //need doll (class)
    //need to be able to do verbs 

    
    class Program
    {
        static void Main(string[] args)
        {
            var smallest = new Doll("smallest", null); //choose smallest doll first

            var medium = new Doll("medium", smallest); //fit the small into medium

            var largest = new Doll("largest", medium); //fit all inside of the largest

            //now make program stop after opening all of them

            OpenAllDolls(largest);

        }


        //time complexity: O(N)
        static void OpenAllDolls(Doll doll)
        {
            //base case 
            if (doll.child == null)
            {
                //done
                doll.Open(); //since wouldnt open smallest orignally.
                             //now will display that smallest cannot be opened

            }
            else
            {
                //recursive case. also returns a value
                var dollThatCameOutOfOpenedDoll = doll.Open(); //teach doll how to open 
                                                               //smallest doll that comes out
                OpenAllDolls(dollThatCameOutOfOpenedDoll);

            }
                                               
        }
    }

   
    
}


