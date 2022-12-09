using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kanbanboard
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
            Loaded += Lists_populate;
        }

        private void CancelAddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;
                Reader reader = new Reader(AddedSprintList.SelectedItem.ToString());
                int sprintId = reader.SprintIdReader();
                reader = new Reader(AddedUserStoryList.SelectedItem.ToString());
                int userStoryId = reader.UserStoryIdReader();
                reader = new Reader(AddedUserList.SelectedItem.ToString());
                int userId = reader.UserIdReader();
                int prio = TaskPrioritySelector.SelectedIndex;
                int diff = TaskDifficulty.SelectedIndex;

                cmd.Connection = con;
                try
                {
                    if (TaskNameInput.Text != test)
                    {
                        cmd.CommandText = "INSERT INTO tasks (task_nimi, task_info, task_tila, task_prioriteetti, task_kategoria, task_vaikeustaso, task_aloitus_pvm, task_lopetus_pvm, sprint_id, user_story_id, user_id)values(@tnimi, @tinfo, @ttila, @tprio, @tkat, @tvaik, @tapvm, @tlpvm, @tspri, @tust, @tuser)";
                        cmd.Parameters.AddWithValue("@tnimi", TaskNameInput.Text);  //(@tnimi, @tinfo, @ttila, @tprio, @tkat, @tvaik, @tapvm, @tlpvm, @tspri, @tust)"
                        cmd.Parameters.AddWithValue("@tinfo", TaskDescriptionInput.Text);
                        cmd.Parameters.AddWithValue("@ttila", 0);
                        cmd.Parameters.AddWithValue("@tprio", prio);
                        cmd.Parameters.AddWithValue("@tkat", TaskCategory.SelectedItem);
                        cmd.Parameters.AddWithValue("@tvaik", diff);
                        cmd.Parameters.Add("@tapvm", OleDbType.Date).Value = TaskStartDate.SelectedDate;
                        cmd.Parameters.Add("@tlpvm", OleDbType.Date).Value = TaskEndDate.SelectedDate;
                        cmd.Parameters.AddWithValue("@tspri", sprintId);
                        cmd.Parameters.AddWithValue("@tust", userStoryId);
                        cmd.Parameters.AddWithValue("@tuser", userId);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                    }
                    if (TaskNameInput.Text == test)    //testi NimiBoxin sisällölle
                    {
                        MessageBox.Show("Osa tiedoista puuttuu");
                    }
                }
                catch
                {
                    MessageBox.Show("Lisää arvo jokaiseen tietueeseen tai paina Cancel poistuaksesi ikkunasta");
                }
            }
        }
        public void Lists_populate(object sender, RoutedEventArgs e)
        {
            AddedSprintList.Items.Clear();
            Reader reader = new Reader();
            string[] sprints = reader.DBEverySprintNameReader().Split('\n');
            sprints = sprints.SkipLast(1).ToArray();
            foreach (string s in sprints)
            AddedSprintList.Items.Add(s);

            AddedUserStoryList.Items.Clear();
            reader = new Reader();
            string[] userstories = reader.DBEveryUserStoryNameReader().Split('\n');
            userstories = userstories.SkipLast(1).ToArray();
            foreach (string s in userstories)
            AddedUserStoryList.Items.Add(s);

            AddedUserList.Items.Clear();
            reader = new Reader();
            string[] users = reader.DBEveryUserNameReader().Split('\n');
            users = users.SkipLast(1).ToArray();
            foreach (string s in users)
            AddedUserList.Items.Add(s);
        }
    }
}
