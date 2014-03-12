using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4M1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Excpetion Test");
            new Math().Div(1, 0);
        }
    }
}
