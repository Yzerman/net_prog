using System;
using System.Collections.Generic;
using System.IO;
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

namespace L13HA_Patrice_Keusch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file = @"./text.txt";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(file, text.Text);
        }

        private void Button_Click_Load(object sender, RoutedEventArgs e)
        {
            if (File.Exists(file))
            {
                text.Text = File.ReadAllText(file);
            }
        }
    }
}
