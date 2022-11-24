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
    /// Interaction logic for AddUserStory.xaml
    /// </summary>
    public partial class AddUserStory : Window
    {
        public AddUserStory()
        {
            InitializeComponent();
        }
        private void CancelUserStoryButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddUserStoryButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;

                cmd.Connection = con;
                try
                {
                    if (UserStoryNameInput.Text != test)
                    {
                        cmd.CommandText = "INSERT INTO user_stories (user_story_nimi, user_story_info, user_story_prioriteetti)values(@ktnimi, @ktinfo, @ktprio)";
                        cmd.Parameters.AddWithValue("@ktimi", UserStoryNameInput.Text);
                        cmd.Parameters.AddWithValue("@ktinfo", UserStoryDescriptionInput.Text);
                        cmd.Parameters.AddWithValue("@ktprio", PrioritySelector.Text);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                    }
                    if (UserStoryNameInput.Text == test || UserStoryDescriptionInput.Text == test)    //Helppo testi NameBoxin sisällölle
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
