using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3M1_Patrice_Keusch
{
    class L3M1_Patrice_Keusch
    {
        static void Main(string[] args)
        {

        }
    }

    class Employee
    {

        
        static int retirementAge { get; set; }

        static Employee()
        {
            retirementAge = 65;
        }
        string FirstName {

            get{ return FirstName;}
            set{
                if (value == "")
                {
                    FirstName = "NotSet";
                }
                else
                {
                    FirstName = value;}
                }
                

        }

        string LastName;
        int Age { get; set; }
        int ID { get; set; }
        int Salary;

        public Employee(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;

        }

        public Employee(string FirstName, string LastName, int Age = 3, int ID = 123, int Salary = 23313)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ID = ID;
            this.Age = Age;
            this.Salary = Salary;

        }

        private void SetSalary(int Salary){

            this.Salary = Salary;
        }

         private int GetSalary(){

            return Salary;
        }
    }
}
