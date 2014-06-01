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
using System.Windows.Media;
using System.Runtime.CompilerServices;

// allow PhoneAppUnitTests access to internal methods
[assembly: InternalsVisibleTo("PhoneAppUnitTests")]

namespace PivotApp1
{
    /// <summary>
    /// MainPage Class with pivot page and all methods
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// control debugging.
        /// </summary>
        bool debug;
        
        /// <summary>
        /// Mainpage constructer with pivot function
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            
            // active ordisable debugging
            debug = true;

        }

        /// <summary>
        /// if debugging is active, load these testdata
        /// </summary>
        private void loadTestData()
        {
            // local storage on windows phone
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

        /// <summary>
        /// if pivots gets loaded, load the saved pw/server/port to form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// opens a client connection to the WCF Service and execute asynchronous the set command.
        /// adds a handler to the proxy_invokeCommandCompleted method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (dataoutput.command == "")
            {
                dataoutput.command = "C:\\";
            }
            dataoutput.pinCode = Convert.ToInt32(pboxPassword.Password);

            proxy.invokeCommandAsync(dataoutput);
           
            proxy.invokeCommandCompleted += new EventHandler<ServiceReference1.invokeCommandCompletedEventArgs>(proxy_invokeCommandCompleted);
            btnExecute.Content = "executing ...";
            
        }

        /// <summary>
        /// waits for the response from WCF Service. handle response. check statuscode and generate output for the result page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void proxy_invokeCommandCompleted(object sender, ServiceReference1.invokeCommandCompletedEventArgs e)
        {
            btnExecute.Content = "execute";
            if (e.Result == null)
            {
                wbrowserResult.NavigateToString("connection failed, check connection page");
            }
            else
            {
                PSResponse datainput = new PSResponse();
                datainput.statusCode = e.Result.statusCode;

                switch (datainput.statusCode)
                {
                    case 0:
                        var data = Convert.FromBase64String(e.Result.psResult);
                        datainput.psResult = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                        wbrowserResult.NavigateToString(datainput.psResult);
                        break;
                    case 101:
                        wbrowserResult.NavigateToString("wrong pincode, check connection page");
                        break;
                    case 102:
                        var data1 = Convert.FromBase64String(e.Result.psResult);
                        datainput.psResult = System.Text.Encoding.UTF8.GetString(data1, 0, data1.Length);
                        wbrowserResult.NavigateToString(datainput.psResult);
                        break;

                    case 103:
                        wbrowserResult.NavigateToString("remote path does not exists, check execution page");
                        break;

                }

            }
            pivMain.SelectedItem = pivResult;
            
        }
        
        /// <summary>
        /// opens a client connection to the WCF Service and execute asynchronous a status command.
        /// adds a handler to the proxy_invokeCommandStatusCompleted method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                dataoutput.remotePath = "C:\\";
                dataoutput.command = "hostname";
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

        /// <summary>
        /// waits for the response from WCF Service. handle response. check statuscode and generate output for the connection page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                
                switch (datainput.statusCode)
                {
                    case 0:
                        lblStatus.Foreground = new SolidColorBrush(Colors.Green);
                        lblStatus.Text = "service available";
                        btnStatus.Content = "check status";
                        break;
                    case 101:
                        lblStatus.Foreground = new SolidColorBrush(Colors.Red);
                        lblStatus.Text = "Wrong PinCode";
                        btnStatus.Content = "check status again";
                        break;
                    case 102:
                        lblStatus.Foreground = new SolidColorBrush(Colors.Red);
                        lblStatus.Text = "something else";
                        btnStatus.Content = "check status agains";
                        break;
                    default:
                        lblStatus.Foreground = new SolidColorBrush(Colors.Red);
                        lblStatus.Text = "Not Connected";
                        btnStatus.Content = "check status again";
                        break;
                }
            
            }
          
        }


        // Button Actions 

        /// <summary>
        /// saves the values pincode, server, port from form input to isolatedstorage on the phone.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            btnClearGo();
        }

        internal void btnClearGo()
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
            
            txtServer.Text = "";
            pboxPassword.Password = "";
            txtPort.Text = "";
            
        }

        /// <summary>
        /// by click at the Get-Command button, these method will be executed.
        /// it starts the encapsulated btnGetCommandsGo() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetCommands_Click(object sender, RoutedEventArgs e)
        {
            btnGetCommandsGo();
        }

        /// <summary>
        /// sets the remote path and command text-field in the UI.
        /// remote path: C:\
        /// command: Get-Command Get-* | select Name,Module
        /// </summary>
        internal void btnGetCommandsGo()
        {
            txtRemotePath.Text = "C:\\";
            txtCommand.Text = "Get-Command Get-* | select Name,Module";
        }

        /// <summary>
        /// by click at the clear path button, these method will be executed.
        /// it starts the encapsulated btnClearPathGo() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearPath_Click(object sender, RoutedEventArgs e)
        {
            btnClearPathGo();
        }

        /// <summary>
        /// clears the remote path text-field in the UI.
        /// remote path: 
        /// </summary>
        internal void btnClearPathGo()
        {
            txtRemotePath.Text = "";
        }

        /// <summary>
        /// by click at the clear command button, these method will be executed.
        /// it starts the encapsulated btnClearCommandGo() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCommand_Click(object sender, RoutedEventArgs e)
        {
            btnClearCommandGo();
        }
        
        /// <summary>
        /// clears the command path text-field in the UI.
        /// command: 
        /// </summary>
        internal void btnClearCommandGo()
        {
            txtCommand.Text = "";
        }

        /// <summary>
        /// by click at the Set-Command button, these method will be executed.
        /// it starts the encapsulated btnSetCommandsGo() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetCommands_Click(object sender, RoutedEventArgs e)
        {
            btnSetCommandsGo();
        }

        /// <summary>
        /// sets the remote path and command text-field in the UI.
        /// remote path: C:\
        /// command: Get-Command Set-* | select Name,Module
        /// </summary>
        internal void btnSetCommandsGo()
        {
            txtRemotePath.Text = "C:\\";
            txtCommand.Text = "Get-Command Set-* | select Name,Module";
        }
        
        /// <summary>
        /// by click at the Get-Alias button, these method will be executed.
        /// it starts the encapsulated btnGetAliasGo() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAlias_Click(object sender, RoutedEventArgs e)
        {
            btnGetAliasGo();
        }

        /// <summary>
        /// sets the remote path and command text-field in the UI.
        /// remote path: C:\
        /// command: Get-Alias | select Name
        /// </summary>
        internal void btnGetAliasGo()
        {
            txtRemotePath.Text = "C:\\";
            txtCommand.Text = "Get-Alias | select Name";
        }

        /// <summary>
        /// by click at the add filter button, these method will be executed.
        /// it starts the encapsulated btnAddFtilerGo() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFilter_Click(object sender, RoutedEventArgs e)
        {
            btnAddFtilerGo();
        }

        /// <summary>
        /// appends a filter to the command text-field in the UI.
        /// command: set command +  | where 'column' -eq 'value' | select 'column'
        /// </summary>
        internal void btnAddFtilerGo()
        {
            string str = txtCommand.Text;
            txtCommand.Text = str + " | where <column> -eq 'value' | select <column>";
        }

    }
}