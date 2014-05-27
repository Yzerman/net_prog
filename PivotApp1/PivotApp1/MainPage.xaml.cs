using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PivotApp1.Resources;
using PivotApp1.ServiceReference1;
using System.IO.IsolatedStorage;
using System.ServiceModel;




namespace PivotApp1
{
    public partial class MainPage : PhoneApplicationPage
    {

        bool debug;
        
        public MainPage()
        {
            InitializeComponent();
            
            //active/disable debugging
            debug = true;

        }

        // testdata
        private void loadTestData()
        {
            
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("pinCode"))
            {
                settings.Add("pinCode", "1234");
            }
            else
            {
                settings["pinCode"] = "1234";
            }

            if (!settings.Contains("server"))
            {
                settings.Add("server", "192.168.1.249");
            }
            else
            {
                settings["server"] = "192.168.1.249";
            }

            if (!settings.Contains("port"))
            {
                settings.Add("port", "8000");
            }
            else
            {
                settings["port"] = "8000";
            }

            settings.Save();
            txtRemotePath.Text = "c:\\";
            txtCommand.Text = "hostname";
           
        }
        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {

            if (debug)
            {
                loadTestData();
            }

            // load state
            if (IsolatedStorageSettings.ApplicationSettings.Contains("pinCode"))
            {
                pboxPassword.Password+=
                    IsolatedStorageSettings.ApplicationSettings["pinCode"] as string;
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("server"))
            {
                txtServer.Text +=
                    IsolatedStorageSettings.ApplicationSettings["server"] as string;
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("port"))
            {
                txtPort.Text +=
                    IsolatedStorageSettings.ApplicationSettings["port"] as string;
            }


            

        }


           private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            var proxy = new PSRemotingClient();
            var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

            EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);

            string svcUri = "http://" + txtServer.Text + ":" + txtPort.Text + "/IPSRemotingService";
            newEndpointAddress.Uri = new Uri(svcUri);
            
            proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());
            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = txtRemotePath.Text;
            dataoutput.command = txtCommand.Text;
            dataoutput.pinCode = Convert.ToInt32(pboxPassword.Password);

            proxy.invokeCommandAsync(dataoutput);
           
            proxy.invokeCommandCompleted += new EventHandler<ServiceReference1.invokeCommandCompletedEventArgs>(proxy_invokeCommandCompleted);
            btnExecute.Content = "executing ...";
            
        }

        private void proxy_invokeCommandCompleted(object sender, ServiceReference1.invokeCommandCompletedEventArgs e)
        {
            btnExecute.Content = "execute";
            if (e.Result == null)
            {
                wbrowserResult.NavigateToString("connection failed");
                pivMain.SelectedItem = pivResult;
            }
            else
            {
                PSResponse datainput = new PSResponse();
                datainput.statusCode = e.Result.statusCode;
                datainput.psResult = e.Result.psResult;
                if (datainput.statusCode == 0 || datainput.statusCode == 1)
                {
                    // txtResult.Text = "ERROR";
                    wbrowserResult.NavigateToString(datainput.psResult);

                }
                else
                {
                    //switch
                    wbrowserResult.NavigateToString("ERROR");
                }
                pivMain.SelectedItem = pivResult;
            }
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            
            if (!settings.Contains("pinCode"))
            {
                settings.Add("pinCode", pboxPassword.Password);
            }
            else
            {
                settings["pinCode"] = pboxPassword.Password;
            }

            if (!settings.Contains("server"))
            {
                settings.Add("server", txtServer.Text);
            }
            else
            {
                settings["server"] = txtServer.Text;
            }

            if (!settings.Contains("port"))
            {
                settings.Add("port", txtPort.Text);
            }
            else
            {
                settings["port"] = txtServer.Text;
            }

            settings.Save();
        }


        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            if (txtServer.Text != "" && txtPort.Text != "")
            {
                var proxy = new PSRemotingClient();
                var endpointAddress = proxy.Endpoint.Address; //gets the default endpoint address

                EndpointAddressBuilder newEndpointAddress = new EndpointAddressBuilder(endpointAddress);

                string svcUri = "http://" + txtServer.Text + ":" + txtPort.Text + "/IPSRemotingService";
                newEndpointAddress.Uri = new Uri(svcUri);
                
                proxy = new PSRemotingClient("BasicHttpBinding_IPSRemoting", newEndpointAddress.ToEndpointAddress());

                PSRequest dataoutput = new PSRequest();
                dataoutput.remotePath = txtRemotePath.Text;
                dataoutput.command = txtCommand.Text;
                dataoutput.pinCode = Convert.ToInt32(pboxPassword.Password);

                proxy.invokeCommandAsync(dataoutput);
                proxy.invokeCommandCompleted += new EventHandler<ServiceReference1.invokeCommandCompletedEventArgs>(proxy_invokeCommandStatusCompleted);
                btnStatus.Content = "checking status ...";
                
               
            }
            else
            {
                lblStatus.Text = "empty port or server";
            }
            

        }

        private void proxy_invokeCommandStatusCompleted(object sender, ServiceReference1.invokeCommandCompletedEventArgs e)
        {
            PSResponse datainput = new PSResponse();
            if (e.Result == null)
            {
                lblStatus.Text = "connection failed";
                btnStatus.Content = "check status";
            }
            else
            {
                datainput.statusCode = e.Result.statusCode;
                datainput.psResult = e.Result.psResult;
                if (datainput.statusCode != 0)
                {
                    switch (datainput.statusCode)
                    {
                        case 101:
                            lblStatus.Text = "Wrong PinCode";
                            break;
                        case 102:
                            lblStatus.Text = "something else";
                            break;
                        default:
                            lblStatus.Text = "Not Connected";
                            break;
                    }

                }
                else
                {
                    lblStatus.Text = "Connected";
                    btnStatus.Content = "check status";
                }
          
            }
          
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("pinCode"))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove("pinCode");
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("server"))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove("server");
            }
            if (IsolatedStorageSettings.ApplicationSettings.Contains("port"))
            {
                IsolatedStorageSettings.ApplicationSettings.Remove("port");
            }
            if (txtServer.Text != "")
            {
                txtServer.Text = "";
            }
            if (pboxPassword.Password != "")
            {
                pboxPassword.Password = "";
            }
            if (txtPort.Text != "")
            {
                txtPort.Text = "";
            }
        }

    }
}