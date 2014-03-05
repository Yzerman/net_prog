using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
{
    public interface IEmployee
    {
        int Age
        {
            get;
            set;
        }

        double benefit
        {
            get;
            set;
        }

        string Company
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        string Name
        {
            get;
            set;
        }

        int Pay
        {
            get;
            set;
        }

        int SocialSecurityNumber
        {
            get;
            set;
        }

        void DisplayStats();

        double GetBenefitCost();

        void GiveBonus();
    }
}
