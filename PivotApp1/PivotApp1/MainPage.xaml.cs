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



namespace PivotApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
     
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Pivot_Loaded(object sender, RoutedEventArgs e)
        {
            // txtDisplay is a TextBlock defined in XAML.
           
            if (IsolatedStorageSettings.ApplicationSettings.Contains("username"))
            {
                txtUsername.Text+=
                    IsolatedStorageSettings.ApplicationSettings["username"] as string;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
                      
        }

           private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            PSRequest dataoutput = new PSRequest();
            dataoutput.remotePath = txtRemotePath.Text;
            dataoutput.command = txtCommand.Text;
            dataoutput.pinCode = 12334;
            
            var proxy = new ServiceReference1.PSRemotingClient();

            proxy.invokeCommandAsync(dataoutput);
            proxy.invokeCommandCompleted += new EventHandler<ServiceReference1.invokeCommandCompletedEventArgs>(proxy_invokeCommandCompleded);
            
        }

        private void proxy_invokeCommandCompleded(object sender, ServiceReference1.invokeCommandCompletedEventArgs e)
        {
            PSResponse datainput = new PSResponse();
            datainput.statusCode = e.Result.statusCode;
            datainput.psResult = e.Result.psResult;
            if (datainput.statusCode != 0)
            {
                txtResult.Text = "ERROR";
            }
            else
            {
                txtResult.Text = datainput.psResult;
            }
            pivMain.SelectedItem = pivResult;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            
            if (!settings.Contains("username"))
            {
                settings.Add("username", txtUsername.Text);
            }
            else
            {
                settings["username"] = txtUsername.Text;
            }
            settings.Save();
        }


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}