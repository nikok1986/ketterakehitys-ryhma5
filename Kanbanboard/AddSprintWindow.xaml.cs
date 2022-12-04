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
    /// Interaction logic for AddSprintWindow.xaml
    /// </summary>
    public partial class AddSprintWindow : Window
    {
        public AddSprintWindow()
        {
            InitializeComponent();
            Loaded += ProjectList_populate;
        }
        public String DBProjectInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_info FROM projects WHERE project_nimi='" + ProjectList.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string projectinfo = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectinfo = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return projectinfo;
            }
        }
        private void ProjectList_populate(object sender, EventArgs e)
        {
            ProjectList.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBProjectNameReader().Split('\n');
            foreach (string s in projects)
                ProjectList.Items.Add(s);
            if (ProjectList.Items.Count > 0)
            {
                ProjectList.SelectedIndex = 0;
            }
        }
        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
