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
    /// Interaction logic for EditSprintWindow.xaml
    /// </summary>
    public partial class EditSprintWindow : Window
    {
        string name;
        public EditSprintWindow(string nimi)
        {
            InitializeComponent();
            name = nimi;
            Loaded += ProjectList_populate;
        }
        private void EditSprintButton_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection con = DataServices.DBConnection())   //Käytetään DataServices.cs tiedostoon luotua tietokantayhteyttä.
            {                                                           //Using-komennolla yhteys suljetaan automaattisesti suorituksen jälkeen.
                OleDbCommand cmd;
                cmd = new OleDbCommand();
                string test = string.Empty;
                string projectName = ProjectList.SelectedItem.ToString();
                Reader reader = new Reader(projectName);
                int i = reader.ProjectIdReader();

                cmd.Connection = con;
                if (SprintNameInput.Text != test || SprintDescriptionInput.Text != test || SprintStartDate.SelectedDate != null || SprintEndDate.SelectedDate != null)
                {
                    cmd.CommandText = "UPDATE sprints SET sprint_nimi = @snimi, sprint_info = @sinfo, sprint_aloitus_pvm = sapvm, sprint_lopetus_pvm = slpvp, project_id = @pjid WHERE sprint_nimi='" + name + "';";
                    cmd.Parameters.AddWithValue("@nimi", SprintNameInput.Text);
                    cmd.Parameters.AddWithValue("@pinfo", SprintDescriptionInput.Text);
                    cmd.Parameters.Add("@sapvm", OleDbType.Date).Value = SprintStartDate.SelectedDate;
                    cmd.Parameters.Add("@slpvm", OleDbType.Date).Value = SprintEndDate.SelectedDate;
                    cmd.Parameters.AddWithValue("@pjid", i);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sprintti " + name + " muokattu.");
                    DialogResult = false;
                }
                else
                {
                    MessageBox.Show("Anna kaikki sprintin tiedot.");
                }
        }
        }
        private void CancelEditSprintButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void ProjectList_populate(object sender, EventArgs e)
        {
            ProjectList.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryProjectNameReader().Split('\n');
            foreach (string s in projects)
                ProjectList.Items.Add(s);
            if (ProjectList.Items.Count > 0)
            {
                ProjectList.SelectedIndex = 0;
            }
        }
        private void ProjectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




    }
}
