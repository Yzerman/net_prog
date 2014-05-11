using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WcfPhoneAppTest1.Resources;

namespace WcfPhoneAppTest1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnSendData_Click(object sender, RoutedEventArgs e)
        {
            var proxy = new ServiceReference1.Service1Client();
            int inputparam = Convert.ToInt32(input.Text);
            proxy.malZweiAsync(inputparam);
            proxy.malZweiCompleted += new EventHandler<ServiceReference1.malZweiCompletedEventArgs>(proxy_malZweiCompleted);
        }

        void proxy_malZweiCompleted(object sender, ServiceReference1.malZweiCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            output.Text = result;
        }

        private void btnInvokeCommand_Click(object sender, RoutedEventArgs e)
        {
            var proxy = new ServiceReference1.Service1Client();
            string ps_input = powershell_input.Text;
            proxy.invokeCommandAsync(ps_input);
            proxy.invokeCommandCompleted += new EventHandler<ServiceReference1.invokeCommandCompletedEventArgs>(proxy_InvokeCommandCompleted);
          
        }

        void proxy_InvokeCommandCompleted(object sender, ServiceReference1.invokeCommandCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            MessageBox.Show(result);
            powershell_output.Text = result;
        }

    }
}