using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
{
    class Secretary : Employee
    {
        public bool speaksEnglish { get; set; }
 

        public bool speaksGerman {get;set;}

    
        public void GetNotes()
        {
            throw new System.NotImplementedException();
        }

        public void WriteMail()
        {
            throw new System.NotImplementedException();
        }

        public override void DisplayStats()
        {
            Console.WriteLine("Spricht Englisch: " + speaksEnglish);
            Console.WriteLine("Spricht Deutsch: " + speaksGerman);
        }
       
    }
}
