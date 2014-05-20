using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace L9HA_Patrice_Keusch_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolModel())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name : ");
                var name = Console.ReadLine();

                var query = from b in db.Person
                            orderby b.FirstName
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName);
                } 

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 

        }

     
    }

}
