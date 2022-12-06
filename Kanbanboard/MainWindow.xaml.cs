﻿using System;
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
                    projectname += reader.GetString(0) + "\n";
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
                    sprintname += reader.GetString(0) + "\n";
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
        public DateTime DBSprintEndDate()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand("SELECT sprint_lopetus_pvm FROM sprints WHERE sprint_nimi='" + SprintListing.SelectedItem + "';");
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
        public String DBTeamNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT team_nimi FROM projects INNER JOIN teams ON projects.project_id = teams.project_id WHERE projects.project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string teams = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teams += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return teams;
            }
        }
        public String DBUserNameReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT users.user_nimi FROM projects INNER JOIN (users INNER JOIN (teams INNER JOIN users_teams_link ON teams.team_id = users_teams_link.team_id) ON users.user_id = users_teams_link.user_id) ON projects.project_id = teams.project_id WHERE projects.project_nimi='" + ProjectListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string users = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return users;
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
                    userstories += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return userstories;
            }
        }
        public String DBBackLogReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                // SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id;
                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id WHERE tasks.task_tila=0 AND sprints.sprint_nimi='" + SprintListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskname;
            }
        }
        public String DBTaskInProgressReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id WHERE tasks.task_tila=1 AND sprints.sprint_nimi='" + SprintListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskname;
            }
        }
        public String DBCompleteTaskReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT tasks.task_nimi FROM sprints INNER JOIN tasks ON sprints.sprint_id = tasks.sprint_id WHERE tasks.task_tila=2 AND sprints.sprint_nimi='" + SprintListing.SelectedItem + "';");
                cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                string taskname = String.Empty;    //Kerätään info tähän tyhjään stringiin.

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    taskname += reader.GetString(0) + "\n";
                }
                reader.Close();
                cmd.ExecuteNonQuery();

                return taskname;
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
            //TabItem tabItem = new TabItem();
            //tabItem.Header = "Sprintti";
            //tabItem.Content = new TabitemMalli();
            //SprinttiLaatikko.Items.Insert(SprinttiLaatikko.Items.Count, tabItem);
            AddSprintWindow sprintWindow = new AddSprintWindow();
            sprintWindow.Title = "Lisää sprintti";
            sprintWindow.ShowDialog();
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
            string[] projects = reader.DBProjectNameReader().Split('\n');
            foreach (string s in projects)
                ProjectListing.Items.Add(s);
        }
        private void TaskLists_populate()
        {
            ToDoListBox.Items.Clear();
            string[] taskList = DBBackLogReader().Split('\n');
            foreach (string s in taskList)
                ToDoListBox.Items.Add(s);

            TaskInProgressListBox.Items.Clear();
            string[] progressList = DBTaskInProgressReader().Split('\n');
            foreach (string s in progressList)
                TaskInProgressListBox.Items.Add(s);

            TaskDoneListBox.Items.Clear();
            string[] completeList = DBCompleteTaskReader().Split('\n');
            foreach (string s in completeList)
                TaskDoneListBox.Items.Add(s);
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
            string[] sprints = DBSprintNameReader().Split('\n');
            foreach (string s in sprints)
                SprintListing.Items.Add(s);

            UserStoryGridList.Items.Clear();
            string[] userstoryList = DBUserStoryReader().Split('\n');
            foreach (string s in userstoryList)
                UserStoryGridList.Items.Add(s);

            TeamBox.Items.Clear();
            string[] teamList = DBTeamNameReader().Split('\n');
            foreach (string s in teamList)
                TeamBox.Items.Add(s);

            UsersBox.Items.Clear();
            string[] userList = DBUserNameReader().Split('\n');
            foreach (string s in userList)
                UsersBox.Items.Add(s);
        }

        private void SprintListing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //SprintTitleBox.Text = DBSprintNameReader();
            SeeSprintInfo.Text = DBSprintInfoReader();
            SeeSprintStartDate.Text = DBSprintStartDate().ToString("dd-MM-yyyy");
            SeeSprintEndDate.Text = DBSprintEndDate().ToString("dd-MM-yyyy");

            TaskLists_populate();
        }

        /*private void EditInfoWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListing.SelectedItem != null)
            {
                string pjName = ProjectListing.SelectedItem.ToString();
                EditProjectWindow epw = new EditProjectWindow(pjName);
                epw.Title = "Muokkaa projektia " + pjName;
                epw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Valitse tietue muokattavaksi.");
            }
        }*/


        private void AddTask(object sender, RoutedEventArgs e)
        {

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.AddTaskButton.Click += new RoutedEventHandler(AddTask);
            addTask.ShowDialog();
        }
        private void RightClickEdit_Click(object sender, RoutedEventArgs e) 
        {
            if (ProjectListing.SelectedItem != null)
            {
                string pjName = ProjectListing.SelectedItem.ToString();
                EditProjectWindow epw = new EditProjectWindow(pjName);
                epw.Title = "Muokkaa projektia " + pjName;
                epw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Valitse tietue muokattavaksi.");
            }
        }
        private void RightClickDelete_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                MessageBoxResult result = MessageBox.Show("Haluatko varmasti poistaa projektin " + ProjectListing.SelectedItem + "?", "Vahvistus", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (ProjectListing.SelectedItem != null)
                    {
                        cmd = new OleDbCommand("DELETE FROM projects WHERE project_nimi='" + ProjectListing.SelectedItem + "';");
                        cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Projekti " + ProjectListing.SelectedItem + " poistettu.");
                    }
                    else
                    {
                        MessageBox.Show("Valitse poistettava projekti");
                    }
                }
                if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Toiminto peruutettu.");
                }
            }
        }
        private void RightClickReport_Click(object sender, RoutedEventArgs e)
        {
            ProjectReport pr = new ProjectReport(ProjectListing.SelectedItem.ToString());
            pr.ShowDialog();
        }

        private void BacklogMoveTaskRightButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                if (ToDoListBox.SelectedItem != null)
                {
                    cmd = new OleDbCommand("UPDATE tasks SET task_tila = '1' WHERE task_nimi='" + ToDoListBox.SelectedItem + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Valitse tehtävä backlogissa olevien tehtävien listalta");
                }
            }
            TaskLists_populate();
        }

        private void TaskInProgressMoveTaskLeftButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                if (TaskInProgressListBox.SelectedItem != null)
                {
                    cmd = new OleDbCommand("UPDATE tasks SET task_tila = '0' WHERE task_nimi='" + TaskInProgressListBox.SelectedItem + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Valitse tehtävä keskeneräisten tehtävien listalta");
                }
            }
            TaskLists_populate();
        }

        private void TaskInProgressMoveTaskRightButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                if (TaskInProgressListBox.SelectedItem != null)
                {
                    cmd = new OleDbCommand("UPDATE tasks SET task_tila = '2' WHERE task_nimi='" + TaskInProgressListBox.SelectedItem + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Valitse tehtävä keskeneräisten tehtävien listalta");
                }
            }
            TaskLists_populate();
        }

        private void TaskDoneMoveTaskLeftButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                if (TaskDoneListBox.SelectedItem != null)
                {
                    cmd = new OleDbCommand("UPDATE tasks SET task_tila = '1' WHERE task_nimi='" + TaskDoneListBox.SelectedItem + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    cmd.ExecuteNonQuery();

                    TaskLists_populate();
                }
                else
                {
                    MessageBox.Show("Valitse tehtävä valmiiden tehtävien listalta");
                }
            }
            TaskLists_populate();
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
