using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PSRemoting_ConsoleProxy.ServiceReference1;

namespace PSRemoting_ConsoleProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);
            newEndpointAddress.Uri = new Uri("http://192.168.1.249:8000/IPSRemotingService/");

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = "c:\\";
            dataoutput.command = "dir";
            dataoutput.pinCode = 1234;

            var result = proxy.invokeCommand(dataoutput);

            Console.WriteLine(result.statusCode);
            Console.WriteLine(result.psResult);
            Console.ReadLine();
            

        }
    }
}
