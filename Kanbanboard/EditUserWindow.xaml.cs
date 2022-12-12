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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        string name;
        public EditUserWindow(string nimi)
        {
            InitializeComponent();
            name = nimi;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;

                cmd.Connection = con;
                if (UserNameInput.Text != test) //tyhjä textbox on string.Empty, ei null
                {
                    cmd.CommandText = "UPDATE users SET user_nimi = @knimi, user_rooli = @krole WHERE user_nimi ='" + name + "';";
                    cmd.Parameters.AddWithValue("@knimi", UserNameInput.Text);
                    cmd.Parameters.AddWithValue("@krole", UserRoleComboBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tietue tallennettu!");
                }
                if (UserNameInput.Text == test) 
                {
                    MessageBox.Show("Nimilaatikko on tyhjä!");
                }
            }
        }

        private void CancelAddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
