using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject : Window
    {
        public AddProject()
        {
            InitializeComponent();
        }
        private void CancelAddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
                    if (ProjectNameInput.Text != test || ProjectNameInput.Text != test || ProjectStartDate.SelectedDate != null || ProjectEndDate.SelectedDate != null)
                    {
                        cmd.CommandText = "INSERT INTO projects (project_nimi, project_info, project_aloitus_pvm, project_lopetus_pvm)values(@pnimi, @pinfo, @papvm, @plpvm)";
                        cmd.Parameters.AddWithValue("@nimi", ProjectNameInput.Text);
                        cmd.Parameters.AddWithValue("@pinfo", ProjectDescriptionInput.Text);
                        cmd.Parameters.Add("@papvm", OleDbType.Date).Value = ProjectStartDate.SelectedDate;
                        cmd.Parameters.Add("@plpvm", OleDbType.Date).Value = ProjectEndDate.SelectedDate;


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                        DialogResult = false;
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
    }
}
