using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject : Window
    {
        public AddProject()
        {
            InitializeComponent();
            Loaded += AddedProjectsList_populate;
        }
        public String DBProjectInfoReader()
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;

                cmd = new OleDbCommand("SELECT project_info FROM projects WHERE project_nimi='" + AddedProjectsList.SelectedItem + "';");
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

        private void CancelAddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;     

                cmd.Connection = con;
                try
                {
                    if (ProjectNameInput.Text != test)
                    {
                        cmd.CommandText = "INSERT INTO projects (project_nimi, project_info, project_aloitus_pvm, project_lopetus_pvm)values(@pnimi, @pinfo, @papvm, @plpvm)";
                        cmd.Parameters.AddWithValue("@nimi", ProjectNameInput.Text);
                        cmd.Parameters.AddWithValue("@pinfo", ProjectDescriptionInput.Text);
                        cmd.Parameters.Add("@papvm", OleDbType.Date).Value = ProjectStartDate.SelectedDate;
                        cmd.Parameters.Add("@plpvm", OleDbType.Date).Value = ProjectEndDate.SelectedDate;


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tietue tallennettu!");
                    }
                    if (ProjectNameInput.Text == test)    //Helppo testi NimiBoxin sisällölle
                    {
                        MessageBox.Show("Nimilaatikko on tyhjä!");
                    }
                }
                catch
                {
                    MessageBox.Show("Lisää arvo jokaiseen tietueeseen tai paina Cancel poistuaksesi ikkunasta");
                }
            }
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;

                cmd.Connection = con;
                if (ProjectNameInput.Text != test)
                {
                    cmd.CommandText = "UPDATE projects SET project_nimi= '" + ProjectNameInput.Text + "', project_info= '" + ProjectDescriptionInput.Text + "' WHERE project_nimi='" + AddedProjectsList.SelectedItem + "';";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tietue " + AddedProjectsList.Text + " muokattu!");
                }
                else
                {
                    MessageBox.Show("Valitse tietue muokattavaksi listalta ja aseta uusi nimi nimilaatikkoon!");  //Jos nimeä ei ole valittuna, tulee siitä ilmoitus.
                }
            }
        }
        private void AddedProjectsList_populate(object sender, EventArgs e) 
        {
            AddedProjectsList.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBProjectNameReader().Split();
            foreach (string s in projects)
                AddedProjectsList.Items.Add(s);
            if (AddedProjectsList.Items.Count > 0) 
            { 
                AddedProjectsList.SelectedIndex= 0;
            }
        }
        private void AddedProjectsList_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        { 

        }
        private void ShowProjectInfo_Click(object sender, RoutedEventArgs e)
        {
        //    string info = DBProjectInfoReader();
            //string outputString;
        //    InfoWindow infowindow = new InfoWindow(info);
        //    infowindow.Title = "Tietoa projektista";
        //    infowindow.ShowDialog();
        }
    }
}
