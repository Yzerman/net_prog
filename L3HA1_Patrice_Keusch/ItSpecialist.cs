using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
{
    class ItSpecialist : Employee
    {
        public bool MicrosoftSpezi {get;set;}
   
        public bool LinuxSpezi {get;set;}
     
        public void InstallServer()
        {
            throw new System.NotImplementedException();
        }

        public void ConfigureApp()
        {
            throw new System.NotImplementedException();
        }

        public override void DisplayStats()
        {
            Console.WriteLine("Ist Microsoft Spezi: " + MicrosoftSpezi);
            Console.WriteLine("Ist Linux Spezi: " + LinuxSpezi);
        }
    }
}
