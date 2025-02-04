using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powersinterface
{
    internal class Program
    {

        static void Main(string[] args)
        {

            FancyMath fancyMath = new FancyMath();
            int intValue = 5;
            Console.WriteLine($"Int Value: {intValue}, Square: {fancyMath.square(intValue)}, Cube: {fancyMath.cube(intValue)}" );

            fancyMath = new FancyMath();
            double dV = 4.5;
            Console.WriteLine($"Double Value: {dV}, Square: {fancyMath.square(dV)}, Cube: {fancyMath.cube(dV)}");

            fancyMath = new FancyMath();
            double sqrtV = 16.0;
            Console.WriteLine($"Int Value: {sqrtV}, Sqrt Value: {fancyMath.sqrt(sqrtV)}");

            Console.ReadKey();
        }

        public interface IPowers
        {
            int square(int x);
            double square(double x);

            int cube(int x);
            double cube(double x);

            double sqrt(double x);

        } 

        public class FancyMath : IPowers
        {
            public int square(int x)
            {
                return x*x ;

            }

            public double square(double x)
            {
                return x*x ;
            }

            public int cube(int x)
            {
                return x*x ;
            }

            public double cube(double x)
            {
                return x*x ;
            }
            public double sqrt(double x)
            {
                return Math.Sqrt(x) ;
            }

            

        }
        

        
    }
}
