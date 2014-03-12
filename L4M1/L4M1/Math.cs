using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4M1
{
    public class Math : IZhawCal
    {
        public double Add(double e1, double e2){
            return e1 + e2;
        }
        public double Sub(double e1, double e2){
            return e1-e2;
        }
        public double Multi(double e1, double e2){
            return e1 * e2;
        }
        public double Div(double e1, double e2)
        {
            try
            {
                if (e2 == 0)
                {
                    DateTime saveNow = DateTime.Now;
                    throw new CalcException("e2 ist null", saveNow);
                }
                return e1 / e2;
            }
            catch (CalcException e)
            {
                Console.WriteLine(e.ExceptionTime);
                Console.ReadLine();
                return 0;
            }
            
        }

    }
}
