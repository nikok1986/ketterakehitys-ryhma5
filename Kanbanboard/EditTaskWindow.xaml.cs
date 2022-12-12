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
    /// Interaction logic for EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        string name;
        public EditTaskWindow(string nimi)
        {
            InitializeComponent();
            name= nimi;
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
                int dura = Convert.ToInt32(TaskDurationTextBox.Text);

                cmd.Connection = con;
                try
                {
                    if (TaskNameInput.Text != test || TaskDescriptionInput.Text != test || TaskStartDate.SelectedDate != null || TaskEndDate != null || AddedUserStoryList.Text != test || AddedUserList.Text != test || AddedSprintList.Text != test || TaskDifficulty.Text != test || TaskCategory.Text != test || TaskPrioritySelector.Text != test)
                    {
                        cmd.CommandText = "UPDATE tasks SET task_nimi = @tnimi, task_info = @tinfo, task_tila = @ttila, task_prioriteetti = @tprio, task_kategoria = @tkat, task_vaikeustaso = @tvaik, task_kesto = @tdura, task_aloitus_pvm = tapvm, task_lopetus_pvm = tlpvm, sprint_id = @tspri, user_story_id = @tust, user_id = @tuser WHERE task_nimi='" + name + "';";
                        cmd.Parameters.AddWithValue("@tnimi", TaskNameInput.Text);  //(@tnimi, @tinfo, @ttila, @tprio, @tkat, @tvaik, @tapvm, @tlpvm, @tspri, @tust)"
                        cmd.Parameters.AddWithValue("@tinfo", TaskDescriptionInput.Text);
                        cmd.Parameters.AddWithValue("@ttila", 0);
                        cmd.Parameters.AddWithValue("@tprio", prio);
                        cmd.Parameters.AddWithValue("@tkat", TaskCategory.SelectedItem);
                        cmd.Parameters.AddWithValue("@tvaik", diff);
                        cmd.Parameters.AddWithValue("@tdura", dura);
                        cmd.Parameters.Add("@tapvm", OleDbType.Date).Value = TaskStartDate.SelectedDate;
                        cmd.Parameters.Add("@tlpvm", OleDbType.Date).Value = TaskEndDate.SelectedDate;
                        cmd.Parameters.AddWithValue("@tspri", sprintId);
                        cmd.Parameters.AddWithValue("@tust", userStoryId);
                        cmd.Parameters.AddWithValue("@tuser", userId);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                        DialogResult = false;
                    }
                    if (TaskNameInput.Text == test)    //testi NimiBoxin sisällölle
                    {
                        MessageBox.Show("Osa tiedoista puuttuu");
                    }
                }
                catch
                {
                    //MessageBox.Show("Lisää arvo jokaiseen tietueeseen tai paina Cancel poistuaksesi ikkunasta");
                }
            }
        }
        public void Lists_populate(object sender, RoutedEventArgs e)
        {
            TaskNameBox.Text = name;

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

