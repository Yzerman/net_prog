using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5U2
{
 
    public class Person : IComparable<Person>
    {

        public String Name { get; set; }
        public int Age { get; set; }


        public Person() 
        {

        }
        
        // stellt die Methode .sort() auf einer Liste mit Personen zur Verfügung.
        int IComparable<Person>.CompareTo(Person obj)
        {
           /* if (this.Name == obj.Name && this.Age == obj.Age)
                return 1;
            else
                return -1;*/
            return this.Age.CompareTo(obj.Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Person> liste1 = new List<Person>(){
                new Person{ Name = "Peter", Age = 23},
                new Person{ Name = "Pete2r", Age = 44},
                new Person{ Name = "Sepp", Age = 11}

            };

            liste1.Sort();
            
            foreach (var item in liste1)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }

            Console.ReadLine();

        }
    }
}
