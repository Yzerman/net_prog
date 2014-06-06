using System;
using System.Text;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Service
{
    /// <summary>
    /// service contract defines the method signature invokeCommand
    /// 
    /// </summary>
    [ServiceContract(Namespace = "Service")]
    public interface IPSRemoting
    {

        [OperationContract]
        PSResponse invokeCommand(PSRequest datainput);

    }

    /// <summary>
    /// the datacontract PSRequest can be used from WCF client and server.
    /// three properties: remotePath, command, pincode
    /// </summary>
    [DataContract]
    public class PSRequest
    {
        
        [DataMember]
        [Required]
        public string remotePath { get; set; }

        [DataMember]
        [Required]
        public string command { get; set; }

        [DataMember]
        [Required]
        public int pinCode { get; set; }

    }

    /// <summary>
    /// the datacontract PSResponse can be used from WCF client and server.
    /// three properties: remotePath, command, pincode
    /// </summary>
    [DataContract]
    public class PSResponse
    {

        [DataMember]
        [Required]
        public string psResult { get; set; }

        [DataMember]
        [Required]
        public int statusCode { get; set; }

    }
   
    /// <summary>
    /// the service class IPSRemotingService implements the method from the IPSRemotingInterface
    /// 
    /// invokeCommand:
    /// 1) input validation for the incoming PSRequest paket
    /// 2) opens a powershell session
    /// 3) change the dirctory withn powerhsell session
    /// 4) invoke the set command in the powershell session, convert output to HTML-String
    /// 5) checks for errors
    /// 6) convert HTML-String in base64
    /// 7) generate PSResponse paket and return it
    /// </summary>
    public class IPSRemotingService : IPSRemoting
    {
        // response object
        PSResponse dataoutput;

       /// <summary>
       /// input validation from PSRequest object.
       /// checks for valid pincode and remotepath
       /// </summary>
       /// <param name="datainput">PSRequest object</param>
       /// <returns>bool</returns>
        private bool inputValidation(PSRequest datainput)
        {
            if (datainput.pinCode != 1234)
            {
                dataoutput.statusCode = 101; // wrong pincode
                return false;
            }
            else if(!Directory.Exists(datainput.remotePath))
            {
                dataoutput.statusCode = 103; // Path does not exists
                return false;
            }
            else
            {
                dataoutput.statusCode = 0; // till here no errors
                return true;
            }
                    
        }

        /// <summary>
        /// 1) call inputValidation(datainput) for input validation.
        /// 2) opens a powershell session
        /// 3) change the dirctory withn powerhsell session
        /// 4) invoke the set command in the powershell session, convert output to HTML-String
        /// 5) checks for errors
        /// 6) convert HTML-String in base64
        /// 7) generate PSResponse paket and return it
        /// </summary>
        /// <param name="datainput"></param>
        /// <returns></returns>
        public PSResponse invokeCommand(PSRequest datainput)
        {
            dataoutput = new PSResponse();


            if (inputValidation(datainput))
            {
                // start powershell session
                PowerShell ps = PowerShell.Create();

                // change dirctory within powershell session
                ps.AddScript("cd " + datainput.remotePath);
                ps.Invoke();
                
                // invoke powershell command and convert to HTML string
                ps.AddScript(datainput.command + "| ConvertTo-Html");
                Collection<PSObject> results = ps.Invoke();

                // check for errors, if true, chance statuscode to 102 and return the error
                if (ps.HadErrors)
                {
                    Collection<System.Management.Automation.ErrorRecord> results2 = ps.Streams.Error.ReadAll();

                    StringBuilder sb = new StringBuilder();

                    foreach (var s in results2)
                    {
                        sb.Append(s);
                    }

                    var bytes = Encoding.UTF8.GetBytes(sb.ToString());
                    dataoutput.psResult = Convert.ToBase64String(bytes);
                   
                    dataoutput.statusCode = 102;
                    return dataoutput;
                }
                else
                {
                    // get the powershell output, convert to base64 and return it
                    StringBuilder sb = new StringBuilder();

                    foreach (var s in results)
                    {
                        sb.Append(s);
                    }

                    var bytes = Encoding.UTF8.GetBytes(sb.ToString());
                    dataoutput.psResult = Convert.ToBase64String(bytes);
            
                    dataoutput.statusCode = 0;
                    return dataoutput;

                }

            }
            else
            {
                
                return dataoutput;
            }
                      
        }
         

    }

    /// <summary>
    /// Class for Windows Service creation, starting, stopping, installing, etc.
    /// </summary>
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

            // Create a ServiceHost for the IPSRemotingService WCF-Server type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(IPSRemotingService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        /// <summary>
        /// stops the service host when you click on stop in the windows services
        /// </summary>
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }

    /// <summary>
    /// Provide the ProjectInstaller class which allows 
    /// the service to be installed by the Installutil.exe tool
    /// </summary>
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


