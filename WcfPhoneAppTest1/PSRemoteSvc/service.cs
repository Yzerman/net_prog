using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Runtime.Serialization;

namespace Service
{

    // service contract.
    [ServiceContract(Namespace = "Service")]
    public interface IPSRemoting
    {

        [OperationContract]
        PSResponse invokeCommand(PSRequest datainput);

    }
    [DataContract]
    public class PSRequest
    {
        
        [DataMember]
        public string remotePath { get; set; }

        [DataMember]
        public string command { get; set; }

        [DataMember]
        public int pinCode { get; set; }

    }

    [DataContract]
    public class PSResponse
    {

        [DataMember]
        public string psResult { get; set; }

        [DataMember]
        public int statusCode { get; set; }

    }
   

    public class IPSRemotingService : IPSRemoting
    {

        public PSResponse invokeCommand(PSRequest datainput)
        {
            PSResponse dataoutput = new PSResponse();

            if (datainput.pinCode == 1234)
            {
                
                PowerShell ps = PowerShell.Create();
                // change directory if set
                if (!(datainput.remotePath == ""))
                {
                    ps.AddScript(datainput.remotePath);
                    ps.Invoke();
                }
         
                // invoke command
                ps.AddScript(datainput.command + "| out-string");
                Collection<PSObject> results = ps.Invoke();

                StringBuilder sb = new StringBuilder();

                foreach (var s in results)
                {
                    sb.Append(s);
                }

                dataoutput.psResult=sb.ToString();
                dataoutput.statusCode = 0;
                return dataoutput;
            }
            else
            {
                dataoutput.statusCode = 101; // wrong pincode
                return dataoutput;
            }
                      
        }
         

    }

    public class WCFIPSRemotingSvc : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public WCFIPSRemotingSvc()
        {
            // Name the Windows Service
            ServiceName = "WCFPSRemotingSvc";
        }

        public static void Main()
        {
            ServiceBase.Run(new WCFIPSRemotingSvc());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(IPSRemotingService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }

    // Provide the ProjectInstaller class which allows 
    // the service to be installed by the Installutil.exe tool
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "WCFPSRemotingSvc";
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}


