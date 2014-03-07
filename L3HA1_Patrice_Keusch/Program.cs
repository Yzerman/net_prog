using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine("***** hausaufgabe 3 *****\n");
            ItSpecialist linuxGuru = new ItSpecialist { LinuxSpezi = true, MicrosoftSpezi = false };
            linuxGuru.DisplayStats();

            Secretary germanSec = new Secretary { speaksEnglish = true, speaksGerman = false };
            germanSec.DisplayStats();
            Console.ReadLine();

            Console.ReadLine();


        }

        #region Helper methods
        static void CastingExamples()
        {
            // A Manager "is-a" System.Object, so we can 
            // store a Manager reference in an object variable just fine.
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            // OK!
            GivePromotion((Manager)frank);

            // A Manager "is-an" Employee too.
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);

            // A PTSalesPerson "is-a" SalesPerson.
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);

        }
        static void GivePromotion( Employee emp )
        {
            Console.WriteLine("{0} was promoted!", emp.Name);

            if (emp is SalesPerson)
            {
                Console.WriteLine("{0} made {1} sale(s)!", emp.Name,
                  ((SalesPerson)emp).SalesNumber);
                Console.WriteLine();
            }
            if (emp is Manager)
            {
                Console.WriteLine("{0} had {1} stock options...", emp.Name,
                  ((Manager)emp).StockOptions);
                Console.WriteLine();
            }
        }
        #endregion
    }
}
