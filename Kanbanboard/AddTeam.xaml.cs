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
    /// Interaction logic for AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Window
    {
        public AddTeam()
        {
            InitializeComponent();
            Loaded += ProjectBox_populate;
            Loaded += AllUsersListBox_populate;
        }

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string selectedProject = TeamProjectSelect.SelectedItem.ToString();
                Reader reader = new Reader(selectedProject);
                int i = reader.ProjectIdReader();
                string test = string.Empty;

                cmd.Connection = con;
                //try
                //{
                    if (TeamNameInput.Text != test && TeamDescriptionInput.Text != test)
                    {
                        cmd.CommandText = "INSERT INTO teams (team_nimi, team_info, project_id)values(@tnimi, @tinfo, @pjid)";
                        cmd.Parameters.AddWithValue("@tnimi", TeamNameInput.Text);
                        cmd.Parameters.AddWithValue("@tinfo", TeamDescriptionInput.Text);
                        cmd.Parameters.AddWithValue("@pjid", i);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                    }
                    if (TeamNameInput.Text == test)    //testi NimiBoxin sisällölle
                    {
                        MessageBox.Show("Anna tiimille nimi, info ja projekti.");
                    }
                //}
                //catch
                //{
                   // MessageBox.Show("Lisää arvo jokaiseen tietueeseen tai paina Cancel poistuaksesi ikkunasta");
                //}
            }
        }

        private void CancelAddTeamButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ProjectBox_populate(object sender, RoutedEventArgs e)
        {
            TeamProjectSelect.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryProjectNameReader().Split('\n');
            projects = projects.SkipLast(1).ToArray();
            foreach (string s in projects)
                TeamProjectSelect.Items.Add(s);
        }
        private void AllUsersListBox_populate(object sender, RoutedEventArgs e)
        {
            AllUsersListBox.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryUserNameReader().Split('\n');
            projects = projects.SkipLast(1).ToArray();
            foreach (string s in projects)
                AllUsersListBox.Items.Add(s);
        }
    }
}
