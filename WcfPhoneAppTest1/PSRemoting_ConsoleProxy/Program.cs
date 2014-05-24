using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRemoting_ConsoleProxy
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var proxy = new ServiceReference1.Service1Client())
            {
                string ps_input = "hostname";

                var item = proxy.malZwei(2);
               // proxy.invokeCommandAsync(ps_input);
                //string asd = proxy.invokeCommandAsync(ps_input);

                Console.WriteLine(item);
                Console.ReadLine();

            }
            

        }
    }
}
