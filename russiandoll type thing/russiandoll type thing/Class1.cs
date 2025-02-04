using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace russiandoll_type_thing
{
    public class Doll
    {
        public string size { get; set; }
        public Doll child { get; set; } //type prop, then tab

        public Doll(string size, Doll child) //properties are lowercase, can also use underscore
        {
            this.size = size;
            this.child = child;
        }

        //since this is an object, doll, make it able to do a verb
        //such as open

        public Doll Open() //verb on a noun, doesnt take an input 
        {
            if (this.child == null) //if at the smallest
            {
                Console.WriteLine($"Cannot open {this.size}");
                
                return null;
            }
            else
            {
                Console.WriteLine($"Opened {size}");

                return this.child;
            }

            
        }
    }
}
