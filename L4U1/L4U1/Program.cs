using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("L4U1");
            
            try
            {
                Person pers1 = new Person() { Name = "hans", Vorname = "Peter" };

                pers1.Vorname = null;
                if (pers1.Vorname == null)
                {
                    throw new PersonException("Kein Vorname angegeben");
                }

                // testen der NullReferenceException
                //pers1 = null;

                //String test = pers1.Name;
            }

                // Eine Null Pointer Exception gemäss Aufgabenstellung konnte ich nicht erzeugen. Stattdessen habe ich die NullReferenceException abgefangen. 
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.HResult);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.TargetSite); 
                Console.WriteLine(e.InnerException);
                Console.ReadLine();
            }
            catch (PersonException e)
            {
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.HelpLink);
                Console.WriteLine(e.HResult);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.InnerException);
                Console.ReadLine();
            }
            
           
           
        }
    }
}
