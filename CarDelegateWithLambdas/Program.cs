using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarEventsWithLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** More Fun with Lambdas *****\n");

            // Make a car as usual.
            Car c1 = new Car("SlugBug", 100, 30, 50);

            // Now with lambdas!
            //c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            //c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };
            //c1.SlowedDown += (sender, e) => { Console.WriteLine(e.msg); };

            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };
            c1.SlowedDown += (sender, e) => { Console.WriteLine(e.msg); };

            // Speed up bis 90 (this will generate the events).
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(10);
            // abbremsen
            for (int i = 0; i < 9; i++)
                c1.Accelerate(-10);

            Console.ReadLine();
        }
    }
}
