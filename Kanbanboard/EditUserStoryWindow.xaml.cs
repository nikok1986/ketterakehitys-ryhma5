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
    /// Interaction logic for EditUserStoryWindow.xaml
    /// </summary>
    public partial class EditUserStoryWindow : Window
    {
        public EditUserStoryWindow()
        {
            InitializeComponent();
        }
        private void CancelUserStoryButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void AddUserStoryProjectSelect_populate(object sender, RoutedEventArgs e)
        {
            Reader reader = new Reader();
            string[] projectList = reader.DBEveryProjectNameReader().Split('\n');
            projectList = projectList.SkipLast(1).ToArray();
            foreach (string s in projectList)
                AddUserStoryProjectSelect.Items.Add(s);
        }

        private void AddUserStoryButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string pjName = AddUserStoryProjectSelect.Text.ToString();
                string test = string.Empty;
                Reader reader = new Reader(pjName);
                int i = reader.ProjectIdReader();

                cmd.Connection = con;
                try
                {
                    if (UserStoryNameInput.Text != test)
                    {
                        cmd.CommandText = "INSERT INTO user_stories (user_story_nimi, user_story_info, user_story_tila, project_id)values(@ktnimi, @ktinfo, 0, @pjid)";
                        cmd.Parameters.AddWithValue("@ktimi", UserStoryNameInput.Text);
                        cmd.Parameters.AddWithValue("@ktinfo", UserStoryDescriptionInput.Text);
                        cmd.Parameters.AddWithValue("@pjid", i);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                    }
                    if (UserStoryNameInput.Text == test || UserStoryDescriptionInput.Text == test)
                    {
                        MessageBox.Show("Tietoja puuttuu!");
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
