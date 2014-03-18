using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2HA3_Keusch_Patrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rndGen = new Random();
            int[] array = new int[1000];
            int zufallszahl;

            for (int i = 0; i < array.Length; i++)
            {
                zufallszahl = rndGen.Next(1, 2000);
                if(Array.Exists(array, element => element == zufallszahl)){
                     i--;
                }
                   
                else
                {
                    array[i] = zufallszahl;
                }
                

            }
            /*

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Index: " + i + "Inhalt: " + array[i]);
                
            }
            Console.Read();
             * */

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {

                sb.Append(array[i].ToString());
                
            }
            Console.WriteLine(sb);
            Console.ReadLine();


        }
    }
}
