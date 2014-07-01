using Microsoft.Phone.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PivotApp1.ServiceReference1;
using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Windows;


namespace PhoneAppUnitTests.UnitTests
{
    [TestClass]
    public class UnitTests : WorkItemTest
    {
        [TestMethod]
        [Description("Check to see if MainPage.xaml get instantiated")]
        public void MainPageTest()
        {
            //Should return true
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            Assert.IsNotNull(MPage);
        }


        // Button Tests
        [TestMethod]
        [Description("Check to see if btnAddFilterGo works as desired")]
        public void checkBtnAddFilterGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnAddFtilerGo();
            Assert.IsTrue(MPage.txtCommand.Text == " | where <column> -eq 'value' | select <column>");

        }

        [TestMethod]
        [Description("Check to see if BtnGetAliasGo works as desired")]
        public void checkBtnGetAliasGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnGetAliasGo();
            Assert.IsTrue(MPage.txtCommand.Text == "Get-Alias | select Name");
            Assert.IsTrue(MPage.txtRemotePath.Text == "C:\\");

        }

        [TestMethod]
        [Description("Check to see if btnSetCommandsGo works as desired")]
        public void checkbtnSetCommandsGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnSetCommandsGo();
            Assert.IsTrue(MPage.txtCommand.Text == "Get-Command Set-* | select Name,Module");
            Assert.IsTrue(MPage.txtRemotePath.Text == "C:\\");

        }

        [TestMethod]
        [Description("Check to see if ClearCommandGo works as desired")]
        public void checkbtnClearCommandGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnClearCommandGo();
            Assert.IsTrue(MPage.txtCommand.Text == "");
          
        }

        [TestMethod]
        [Description("Check to see if btnClearPathGo works as desired")]
        public void checkbtnClearPathGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnClearPathGo();
            Assert.IsTrue(MPage.txtRemotePath.Text == "");

        }
        
        [TestMethod]
        [Description("Check to see if btnGetCommandsGo works as desired")]
        public void checkbtnGetCommandsGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnGetCommandsGo();
            Assert.IsTrue(MPage.txtCommand.Text == "Get-Command Get-* | select Name,Module");
            Assert.IsTrue(MPage.txtRemotePath.Text == "C:\\");

        }

        [TestMethod]
        [Description("Check to see if btnClearGo works as desired")]
        public void checkbtnClearGo()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            MPage.btnClearGo();
            Assert.IsTrue(MPage.txtPort.Text == "");
            Assert.IsTrue(MPage.txtRemotePath.Text == "");
            Assert.IsTrue(MPage.txtServer.Text == "");
            
        }
       
        [TestMethod]
        [Asynchronous]
        public async void checkWCFStatus()
        {
            //testdata
            string server = "192.168.1.249";
            string port = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            string remotePath = "C:\\";
            string command = "hostname";
            int pinCode = 1234;

            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);

         
            newEndpointAddress.Uri = new Uri(svcUri);

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = remotePath;
            dataoutput.command = command;
            dataoutput.pinCode = pinCode;

            proxy.invokeCommandCompleted+= (obj, args) =>
                                            {
                                                Assert.IsTrue(args.Result.statusCode == 0);
                                                EnqueueTestComplete();
                                            };
            proxy.invokeCommandAsync(dataoutput);

          }

        [TestMethod]
        [Asynchronous]
        public async void checkWCFWrongPinCode()
        {
            //testdata
            string server = "192.168.1.249";
            string port = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            string remotePath = "C:\\";
            string command = "hostname";
            int pinCode = 124;

            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);


            newEndpointAddress.Uri = new Uri(svcUri);

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = remotePath;
            dataoutput.command = command;
            dataoutput.pinCode = pinCode;

            proxy.invokeCommandCompleted += (obj, args) =>
            {
                Assert.IsTrue(args.Result.statusCode == 101);
                Assert.IsTrue(args.Result.psResult == null);
                EnqueueTestComplete();
            };
            proxy.invokeCommandAsync(dataoutput);

        }

        [TestMethod]
        [Asynchronous]
        public async void checkCommandExecution()
        {
            //testdata
            string server = "192.168.1.249";
            string port = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            string remotePath = "C:\\";
            string command = "Get-Command Get-*";
            int pinCode = 1234;

            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);
            
            newEndpointAddress.Uri = new Uri(svcUri);

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = remotePath;
            dataoutput.command = command;
            dataoutput.pinCode = pinCode;

            proxy.invokeCommandCompleted += (obj, args) =>
            {
                PSResponse datainput = new PSResponse();
                datainput.statusCode = args.Result.statusCode;

                var data = Convert.FromBase64String(args.Result.psResult);
                datainput.psResult = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);

                Assert.IsTrue(datainput.statusCode == 0);
                Assert.IsTrue(datainput.psResult != "");
                EnqueueTestComplete();
            };
            proxy.invokeCommandAsync(dataoutput);
            

        }

        [TestMethod]
        [Asynchronous]
        public async void checkWrongWCFPath()
        {
            //testdata
            string server = "192.168.1.24";
            string port = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            string remotePath = "C:\\";
            string command = "Get-Command Get-*";
            int pinCode = 1234;

            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);

            newEndpointAddress.Uri = new Uri(svcUri);

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = remotePath;
            dataoutput.command = command;
            dataoutput.pinCode = pinCode;

            proxy.invokeCommandCompleted += (obj, args) =>
            {
                Assert.IsTrue(args.Error != null);
                
                EnqueueTestComplete();
            };
            proxy.invokeCommandAsync(dataoutput);


        }

        [TestMethod]
        public void checkemptyPinCode()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            //testdata

            string server = MPage.txtServer.Text = "192.168.1.24";
            string port = MPage.txtPort.Text = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            //int pinCode = 1234;

            Assert.IsFalse(MPage.inputValidationBeforeConnection());
            Assert.IsTrue(MPage.lblStatus.Text == "no pincode set");

        }


        [TestMethod]
        public void checkemptyServer()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            //testdata
            string server = MPage.txtServer.Text = "";
            string port = MPage.txtPort.Text = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";

            MPage.inputValidationBeforeConnection();

            Assert.IsFalse(MPage.inputValidationBeforeConnection());
            Assert.IsTrue(MPage.lblStatus.Text == "empty port or server");

        }

        [TestMethod]
        public void checkemptyPort()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            //testdata
            string server = MPage.txtServer.Text = "192.168.1.249";
            string port = MPage.txtPort.Text = "";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";

            MPage.inputValidationBeforeConnection();
          
            Assert.IsFalse(MPage.inputValidationBeforeConnection());
            Assert.IsTrue(MPage.lblStatus.Text == "empty port or server");
        }

        [TestMethod]
        public void checkisSetServerPortPincode()
        {
            PivotApp1.MainPage MPage = new PivotApp1.MainPage();
            //testdata
            string server = MPage.txtServer.Text = "192.168.1.249";
            string port = MPage.txtPort.Text = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            MPage.pboxPassword.Password = "1234";

            MPage.inputValidationBeforeConnection();

            Assert.IsTrue(MPage.inputValidationBeforeConnection());
 
        }

        [TestMethod]
        [Asynchronous]
        public async void checkwrongPSCommandWCF()
        {
            //testdata
            string server = "192.168.1.249"; 
            string port = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            string remotePath = "C:\\";
            string command = "afasda"; //wrong input
            int pinCode = 1234;

            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);

            newEndpointAddress.Uri = new Uri(svcUri);

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = remotePath;
            dataoutput.command = command;
            dataoutput.pinCode = pinCode;

            proxy.invokeCommandCompleted += (obj, args) =>
            {
            
                Assert.IsTrue(args.Result.statusCode == 102);
               
                EnqueueTestComplete();
            };
            proxy.invokeCommandAsync(dataoutput);


        }

        [TestMethod]
        [Asynchronous]
        public async void checkwrongRemotePathWCF()
        {
            //testdata
            string server = "192.168.1.249";
            string port = "8000";
            string svcUri = "http://" + server + ":" + port + "/IPSRemotingService";
            string remotePath = "T:\\"; //wrong input
            string command = "afasda";
            int pinCode = 1234;

            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);

            newEndpointAddress.Uri = new Uri(svcUri);

            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = remotePath;
            dataoutput.command = command;
            dataoutput.pinCode = pinCode;

            proxy.invokeCommandCompleted += (obj, args) =>
            {

                PSResponse datainput = new PSResponse();
                datainput.statusCode = args.Result.statusCode;

                Assert.IsTrue(datainput.statusCode == 103);

                EnqueueTestComplete();
            };
            proxy.invokeCommandAsync(dataoutput);


        }

    }
}

