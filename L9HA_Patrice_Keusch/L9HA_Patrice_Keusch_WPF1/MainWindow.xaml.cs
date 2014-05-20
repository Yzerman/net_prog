using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L9HA_Patrice_Keusch_WPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void ButtonCreatePerson_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new School())
            {
                var person = new Person { LastName = txtBoxLastNameCreate.Text, FirstName = txtBoxFirstNameCreate.Text };
                db.Person.Add(person);
                db.SaveChanges();
                
            }
        }

        private void ButtonSearchPerson_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new School())
            {
                var query = from b in db.Person where b.LastName == txtBoxLastNameSearch.Text && b.FirstName == txtBoxFirstNameSearch.Text orderby b.LastName select b;

                foreach (var item in query)
                {
                    txtBoxResult.AppendText("Lastname: " + item.LastName + "Firstname: " + item.FirstName + Environment.NewLine);
                }
            }

        }
    }
}
