using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5U1
{
    class Student
    {

        public String Name { get; set; }
        public String Vorname { get; set; }


        public Student()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);

            foreach (var item in stack1)
            {
                Console.WriteLine(item);
            }

           
            List<Student> liste1 = new List<Student>(){
                new Student{ Name = "Peter", Vorname = "Hans"},
                new Student{ Name = "Pete2r", Vorname = "Han1s"}

            };

            foreach (var item in liste1)
            {
                Console.WriteLine(item.Name + " " + item.Vorname);
            }

            Console.ReadLine();

        }
    }
 
}
