using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    /// Interaction logic for AddUserToTask.xaml
    /// </summary>
    public partial class AddUserToTask : Window
    {
        string name;
        public AddUserToTask(string nimi)
        {
            InitializeComponent();
            name = nimi;
            Loaded += UserList_populate;
        }
        public void UserList_populate(object sender, EventArgs e)
        {
            Reader reader = new Reader();
            AddUserHeaderBox.Text = name;
            UsersListBox.Items.Clear();
            string[] progressList = reader.DBEveryUserNameReader().Split('\n');
            progressList = progressList.SkipLast(1).ToArray();
            foreach (string s in progressList)
                UsersListBox.Items.Add(s);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())
            {
                OleDbCommand cmd;

                if (UsersListBox.SelectedItem != null)
                {
                    string userName = UsersListBox.SelectedItem.ToString();
                    Reader reader = new Reader(userName);
                    int i = reader.UserIdReader();
                    cmd = new OleDbCommand("UPDATE tasks SET user_id = " + i + " WHERE task_nimi = '" + name + "';");
                    cmd.Connection = con;   //Yhteys avataan OleDb-komennolla.
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Käyttäjä lisätty.");
                    DialogResult = false;
                }
                else
                {
                    MessageBox.Show("Valitse lisättävä käyttäjä listalta");
                }
            }
        }
    }
}
