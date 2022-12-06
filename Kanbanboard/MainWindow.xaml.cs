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
using System.Xml.Linq;

namespace Kanbanboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += UpdateProjectListButton_Click;
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddProject addProject = new AddProject();
            addProject.AddProjectButton.Click += new RoutedEventHandler(AddProject);
            addProject.Title = "Lisää projekti";
            addProject.ShowDialog();
        }

        private void AddUserStoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserStory addUserStory = new AddUserStory();
            addUserStory.AddUserStoryButton.Click += new RoutedEventHandler(AddUserStory);
            addUserStory.ShowDialog();
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

        private void UpdateProjectListButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectListing.Items.Clear();
            Reader reader= new Reader();
            string[] projects = reader.DBEveryProjectNameReader().Split('\n');
            foreach (string s in projects)
                ProjectListing.Items.Add(s);
        }
        private void TaskLists_populate()
        {
            string name = SprintListing.SelectedItem.ToString();
            Reader reader = new Reader(name);
            ToDoListBox.Items.Clear();
            string[] taskList = reader.DBBackLogReader().Split('\n');
            foreach (string s in taskList)
                ToDoListBox.Items.Add(s);

            TaskInProgressListBox.Items.Clear();
            string[] progressList = reader.DBTaskInProgressReader().Split('\n');
            foreach (string s in progressList)
                TaskInProgressListBox.Items.Add(s);

            TaskDoneListBox.Items.Clear();
            string[] completeList = reader.DBCompleteTaskReader().Split('\n');
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

            string name = ProjectListing.SelectedItem.ToString();
            Reader reader = new Reader(name);
            TitleBox.Text = reader.DBProjectNameReader();
            InfoBox.Text = reader.DBProjectInfoReader();
            StartDateBox.Text = reader.DBProjectStartDate().ToString("dd-MM-yyyy");
            EndDateBox.Text = reader.DBProjectEndDate().ToString("dd-MM-yyyy");

            SprintListing.Items.Clear();
            string[] sprints = reader.DBSprintNameReader().Split('\n');
            foreach (string s in sprints)
                SprintListing.Items.Add(s);

            UserStoryGridList.Items.Clear();
            string[] userstoryList = reader.DBUserStoryReader().Split('\n');
            foreach (string s in userstoryList)
                UserStoryGridList.Items.Add(s);

            TeamBox.Items.Clear();
            string[] teamList = reader.DBTeamNameReader().Split('\n');
            foreach (string s in teamList)
                TeamBox.Items.Add(s);

            UsersBox.Items.Clear();
            string[] userList = reader.DBUserNameReader().Split('\n');
            foreach (string s in userList)
                UsersBox.Items.Add(s);
        }

        private void SprintListing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string name = SprintListing.SelectedItem.ToString();
            Reader reader = new Reader(name);
            //SprintTitleBox.Text = DBSprintNameReader();
            SeeSprintInfo.Text = reader.DBSprintInfoReader();
            SeeSprintStartDate.Text = reader.DBSprintStartDate().ToString("dd-MM-yyyy");
            SeeSprintEndDate.Text = reader.DBSprintEndDate().ToString("dd-MM-yyyy");

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
        private void RightClickUserEdit_Click(object sender, RoutedEventArgs e)
        {
            string name = UsersBox.SelectedItem.ToString();
            EditUserWindow euw = new EditUserWindow(name);
            euw.Title = "Muokkaa käyttäjää " + name;
            euw.ShowDialog();
        }
        private void RightClickUserReport_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RightClickUserDelete_Click(object sender, RoutedEventArgs e)
        {

        }





        private void AddUserStory(object sender, RoutedEventArgs e)
        {

        }
        private void AddTask(object sender, RoutedEventArgs e)
        {

        }
        private void AddProject(object sender, RoutedEventArgs e)
        {

        }
        private void AddUser(object sender, RoutedEventArgs e)
        {

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
