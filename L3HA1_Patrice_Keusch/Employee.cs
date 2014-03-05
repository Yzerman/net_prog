using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    abstract partial class Employee : IEmployee
    {
        // Field data.
        private string empName;
        private int empID;
        private float currPay;
        private int empAge;
        private string empSSN;
        int IEmployee.Pay
        {
            get;
            set;
        }

        string IEmployee.Company
        {
            get;
            set;
        }
        double IEmployee.benefit
        {
            get;
            set;
        }
       

        // Contain a BenefitPackage object.
        protected BenefitPackage empBenefits = new BenefitPackage();

        // Expose certain benefit behaviors of object.
        public double GetBenefitCost()
        { return empBenefits.ComputePayDeduction(); }
        public void GiveBonus()
        {

        }
        int IEmployee.SocialSecurityNumber
        {
            get;
            set;
        }


        #region Nested type
        // BenefitPackage nests BenefitPackageLevel.
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }

            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }
        #endregion

        #region Constructors
        public Employee() { }
        public Employee(string name, int age, int id, float pay, string ssn)
        {
            // Better!  Use properties when setting class data.
            // This reduces the amount of duplicate error checks.
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
            SocialSecurityNumber = ssn;
        }

        public Employee( string name, int id, float pay )
            : this(name, 0, id, pay, "") { }

       
        #endregion
    }
}
