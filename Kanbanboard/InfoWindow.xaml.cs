using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Windows.Shapes;

namespace Kanbanboard
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(string input, string input2, DateTime input3, DateTime input4)
        {
            InitializeComponent();
            string nimi = input;
            string info = input2;
            DateTime startDate = input3;
            DateTime endDate = input4;
            TitleBox.Text = nimi;
            InfoBox.Text = info;
            StartDateBox.Text = startDate.ToString("dd-MM-yyyy");
            EndDateBox.Text = endDate.ToString("dd-MM-yyyy");
        }

        private void ExitInfoWindowButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EditInfoWindowButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
