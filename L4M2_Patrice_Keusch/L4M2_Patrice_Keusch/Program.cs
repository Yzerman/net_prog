using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4M2_Patrice_Keusch
{
    class Program
    {
        static void Main(string[] args)
        {

            // Idee von http://stackoverflow.com/questions/2782328/how-to-simulate-outofmemory-exception

            List<object> Liste = new List<object>();

            try{
                while (true)
                        {
                            object o = new object();
                            Liste.Add(o);
                
                        }
            }
            catch (System.OutOfMemoryException e)
            {
 
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Data);
                Console.WriteLine(GC.GetTotalMemory(true));
                int gcmax = GC.MaxGeneration;
                Console.WriteLine(gcmax);
                Console.WriteLine(GC.GetGeneration(Liste));

                Console.ReadLine();
            }

           
        }
    }
}
