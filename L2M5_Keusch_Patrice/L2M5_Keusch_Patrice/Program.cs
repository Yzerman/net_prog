using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2M5_Keusch_Patrice
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] intarray;
            int asd = 3;
            int asd = 3;

            Console.WriteLine("Wie gross soll dein Array sein?");
            string intgroesse = Console.ReadLine();
            int intgroesse2;
            checked
            {
                intgroesse2 = Convert.ToInt32(intgroesse);
            }
            intarray = new int[intgroesse2];

            for (int i = 0; i < intgroesse2; i++)
            {
                intarray[i] = i;
                Console.WriteLine("Array wird abgefüllt " + intarray[i]);

            }

            Console.WriteLine("Welches Element des Arrays willst du entfernen?");
            string element2 = Console.ReadLine();
            int elementToDel;
            checked
            {
                elementToDel = Convert.ToInt32(element2);
            }

            Console.WriteLine(elementToDel);
            //int[] intarray2 = new int[intarray.Length-1];
            var list = new List<int>(intarray);
            list.RemoveAt(elementToDel);
            int[] array2 = list.ToArray();

            for (int i = 0; i < array2.Length; i++)
            {

                Console.WriteLine("Array wird abgefüllt " + array2[i]);

            }

            Console.ReadLine();
        }
    }
}
