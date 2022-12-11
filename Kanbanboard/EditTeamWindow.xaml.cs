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
    /// Interaction logic for EditTeamWindow.xaml
    /// </summary>
    public partial class EditTeamWindow : Window
    {
        string name;
        public EditTeamWindow(string nimi)
        {
            InitializeComponent();
            Loaded += ProjectBox_populate;
            name = nimi;
        }
        private void EditTeamButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string selectedProject = EditTeamProjectSelect.SelectedItem.ToString();
                Reader reader = new Reader(selectedProject);
                int i = reader.ProjectIdReader();
                string test = string.Empty;
                cmd.Connection = con;
                try
                {
                    if (EditTeamNameInput.Text != test)
                    {
                        cmd.CommandText = "UPDATE teams SET team_nimi = @tnimi, team_info = @tinfo, project_id = @pjid WHERE team_nimi='" + name + "';";
                        cmd.Parameters.AddWithValue("@tnimi", EditTeamNameInput.Text);
                        cmd.Parameters.AddWithValue("@tinfo", EditTeamDescriptionInput.Text);
                        cmd.Parameters.AddWithValue("@pjid", i);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue muokattu!");
                    }
                    if (EditTeamNameInput.Text == test)    //testi NimiBoxin sisällölle
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

        private void CancelEditTeamButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void ProjectBox_populate(object sender, RoutedEventArgs e)
        {
            EditTeamProjectSelect.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryProjectNameReader().Split('\n');
            projects = projects.SkipLast(1).ToArray();
            foreach (string s in projects)
                EditTeamProjectSelect.Items.Add(s);
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
