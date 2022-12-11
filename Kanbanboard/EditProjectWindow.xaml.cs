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
    /// Interaction logic for EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
        string projectName;
        public EditProjectWindow(string pjName)
        {
            InitializeComponent();
            projectName= pjName;
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;
                cmd.Connection = con;
                try
                {
                    if (ProjectNameInput.Text != test)
                    {
                        cmd.CommandText = "UPDATE projects SET project_nimi = @pnimi, project_info = @pinfo, project_aloitus_pvm = @papvm, project_lopetus_pvm = @plpvm WHERE project_nimi='" + projectName + "';";
                        cmd.Parameters.AddWithValue("@nimi", ProjectNameInput.Text);
                        cmd.Parameters.AddWithValue("@pinfo", ProjectDescriptionInput.Text);
                        cmd.Parameters.Add("@papvm", OleDbType.Date).Value = ProjectStartDate.SelectedDate;
                        cmd.Parameters.Add("@plpvm", OleDbType.Date).Value = ProjectEndDate.SelectedDate;


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue muokattu!");
                    }
                    if (ProjectNameInput.Text == test)    //testi NimiBoxin sisällölle
                    {
                        MessageBox.Show("Nimilaatikko on tyhjä!");
                    }
                }
                catch
                {
                    MessageBox.Show("Lisää arvo jokaiseen tietueeseen tai paina Cancel poistuaksesi ikkunasta");
                }
            }
        }

        private void CancelAddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
