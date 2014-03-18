using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2HA2_Keusch_Patrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double test = 1;

            Console.WriteLine(Converter.inchTocm(test));
            Console.ReadLine();
            double test1 = 2.54;
            Console.WriteLine(Converter.cmToinch(test1));
            Console.ReadLine();
        }
    }

    class  Converter
    {

        public static double inchTocm(double inch)
        {
            return inch * 2.54;
        }

        public static double cmToinch(double cm)
        {
            return cm / 2.54;
        }
        
    }
}
