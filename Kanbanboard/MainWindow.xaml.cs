using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
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

namespace Kanbanboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Projekti> ProjectList = new ObservableCollection<Projekti>();
        

        public MainWindow()
        {
            InitializeComponent();
            Loaded += UpdateProjectListButton_Click;
        }

        public String DBProjectNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_nimi, project_id FROM projects WHERE project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string projectname = String.Empty;    //Kerätään info tähän tyhjään stringiin.
               

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    projectname = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return projectname;
            }
        }
        public String DBProjectInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_info FROM projects WHERE project_nimi='" + ProjectListing.SelectedItem + "';");
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
        public DateTime DBStartDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT project_aloitus_pvm FROM projects WHERE project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime startdate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    startdate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return startdate;
            }
        }
        public DateTime DBEndDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT project_lopetus_pvm FROM projects WHERE project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime enddate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    enddate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return enddate;
            }
        }
        public String DBSprintNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                
                cmd = new OleDbCommand("SELECT sprints.sprint_nimi FROM projects INNER JOIN sprints ON projects.project_id = sprints.project_id WHERE projects.project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string sprintname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sprintname = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return sprintname;
            }
        }
        public String DBSprintInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT sprint_info FROM sprints WHERE sprint_nimi='" + SprintListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string sprintinfo = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sprintinfo = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return sprintinfo;
            }
        }
        public DateTime DBSprintStartDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT sprint_aloitus_pvm FROM sprints WHERE sprint_nimi='" + SprintListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                DateTime startdate = DateTime.Now;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    startdate = reader.GetDateTime(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return startdate;
            }
        }
        public String DBUserStoryReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT user_stories.user_story_nimi FROM projects INNER JOIN user_stories ON projects.project_id = user_stories.project_id WHERE projects.project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string userstories = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userstories = reader.GetString(0);
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return userstories;
            }
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddProject addProject = new AddProject();
            addProject.AddProjectButton.Click += new RoutedEventHandler(AddProject);
            addProject.Title = "Lisää projekti";
            addProject.ShowDialog();
        }

        private void AddProject(object sender, RoutedEventArgs e)
        {

        }

        private void AddUserStoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserStory addUserStory = new AddUserStory();
            addUserStory.AddUserStoryButton.Click += new RoutedEventHandler(AddUserStory);
            addUserStory.ShowDialog();
        }
        private void AddUserStory(object sender, RoutedEventArgs e)
        {

        }

       
        private void AddSprintButton_Click(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Sprintti";
            tabItem.Content = new TabitemMalli();
            SprinttiLaatikko.Items.Insert(SprinttiLaatikko.Items.Count, tabItem);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUser newUser = new AddUser();
            newUser.AddNewUserButton.Click += new RoutedEventHandler(AddUser);
            newUser.Title = "Lisää käyttäjä";
            newUser.ShowDialog();
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateProjectListButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectListing.Items.Clear();
            Reader reader= new Reader();
            string[] projects = reader.DBProjectNameReader().Split();
            foreach (string s in projects)
                ProjectListing.Items.Add(s);
        }

        private void ProjectListing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /**
                string name = DBProjectNameReader();
                string info = DBProjectInfoReader();
                DateTime date1 = DBStartDate();
                DateTime date2 = DBEndDate();
                //string outputString;
                InfoWindow infowindow = new InfoWindow(name, info, date1, date2);
                infowindow.Title = "Tietoa projektista";
                infowindow.ShowDialog();
            **/

            TitleBox.Text = DBProjectNameReader();
            InfoBox.Text = DBProjectInfoReader();
            StartDateBox.Text = DBStartDate().ToString("dd-MM-yyyy");
            EndDateBox.Text = DBEndDate().ToString("dd-MM-yyyy");

            SprintListing.Items.Clear();
            string[] sprints = DBSprintNameReader().Split();
            foreach (string s in sprints)
            SprintListing.Items.Add(s);



        }

        private void SprintListing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserStoryGridList.Items.Clear();
            string[] userstoryList = DBUserStoryReader().Split();
            foreach (string s in userstoryList)
                UserStoryGridList.Items.Add(s);
        }

        private void EditInfoWindowButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void AddTask(object sender, RoutedEventArgs e)
        {

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.AddTaskButton.Click += new RoutedEventHandler(AddTask);
            addTask.ShowDialog();
        }
    }
    public class Projekti
    {
        private string nimi;
        public string Nimi
        {
            get;
            set;
        }
        private string tiimi;
        public string Tiimi
        {
            get;
            set;
        }

    }
}
