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
        string name;
        public EditUserStoryWindow(string nimi)
        {
            InitializeComponent();
            name = nimi;
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
                    if (UserStoryNameInput.Text != test && UserStoryDescriptionInput.Text != test)
                    {
                        cmd.CommandText = "UPDATE user_stories SET user_story_nimi = @ktnimi, user_story_info = @ktinfo WHERE user_story_nimi='" + name +"';";
                        cmd.Parameters.AddWithValue("@ktimi", UserStoryNameInput.Text);
                        cmd.Parameters.AddWithValue("@ktinfo", UserStoryDescriptionInput.Text);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                        DialogResult = false;
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
