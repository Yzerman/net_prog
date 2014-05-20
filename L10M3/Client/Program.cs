using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var proxy = new ServiceReference1.Service1Client())
            {
                try
                {
                    Console.WriteLine(proxy.calcTwoInt(1, 2));

                }
                catch (TimeoutException timeout)
                {
                    proxy.Abort();
                }
                catch (CommunicationException comException)
                {
                    proxy.Abort();
                }
               
            }
            Console.ReadLine();
        }
    }
}
