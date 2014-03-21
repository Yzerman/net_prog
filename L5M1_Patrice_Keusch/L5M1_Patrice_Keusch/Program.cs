using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace L5M1_Patrice_Keusch
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList liste1 = new ArrayList();
            Queue queue1 = new Queue();

            List<int> listeGen = new List<int>();
            Queue<string> queueGen = new Queue<string>();

            liste1.Add(1);
            liste1.Add(2);
            liste1.Add(3);

            queue1.Enqueue("First");
            queue1.Enqueue("Second");
            queue1.Enqueue("Third");

            listeGen.Add(1);
            listeGen.Add(2);
            listeGen.Add(3);

            queueGen.Enqueue("First");
            queueGen.Enqueue("Second");
            queueGen.Enqueue("Third");

            foreach(object i in liste1){
                Console.WriteLine(i);
            }
            foreach (object i in queue1)
            {
                Console.WriteLine(i);
            }
            foreach (int i in listeGen)
            {
                Console.WriteLine(i);
            } foreach (string i in queueGen)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            
        }
    }
}
