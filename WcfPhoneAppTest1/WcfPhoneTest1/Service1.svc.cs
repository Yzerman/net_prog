using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace WcfPhoneTest1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int malZwei(int value)
        {
            return 2 * value;
        }

        public string invokeCommand(string value)
        {

            PowerShell ps = PowerShell.Create();
            string rcommand = value;
            ps.AddScript(rcommand + "| out-string");
            Collection<PSObject> results = ps.Invoke();

            StringBuilder sb = new StringBuilder();

            foreach (var s in results)
            {
                sb.Append(s);
            }
            return sb.ToString();

        }

    }
}
