using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace L6M1
{
    class Program
    {

        public delegate double DelegateCalculateSquareRoot(double x);
        public delegate double DelegateCalculateSin(double x);
        static void Main(string[] args)
        {

            DelegateCalculateSquareRoot DCalcRoot = new DelegateCalculateSquareRoot(CalculateSquareRoot);
            DelegateCalculateSin DCalcSin = new DelegateCalculateSin(CalculateSin);

            if (DCalcRoot != null)
            {
                //Console.WriteLine(DCalcRoot.Invoke(25));
                IAsyncResult asynchResuslt = DCalcSin.BeginInvoke(12, null, null);
                Console.WriteLine(DCalcSin.EndInvoke(asynchResuslt));
                
                Console.ReadLine();
            }

        }

        static public double CalculateSquareRoot(double x)
        {
            return Math.Sqrt(x);
        }

        static public double CalculateSin(double x)
        {
            return Math.Sin(x);
        }

    }
}
