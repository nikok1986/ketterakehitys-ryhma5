using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserReport.xaml
    /// </summary>
    public partial class UserReport : Window
    {
        string name;
        public UserReport(string nimi)
        {
            InitializeComponent();
            name = nimi;
            Loaded += UserNameAndRoleBoxes_populate;
            Loaded += UserTeamsListBox_populate;
        }
        public void UserNameAndRoleBoxes_populate(object sender, EventArgs e)
        {
            Reader reader= new Reader(name);
            UserNimiBox.Text = name;
            UserRooliBox.Text = reader.DBUserRoleReader();
        }
        public void UserTeamsListBox_populate(object sender, EventArgs e)
        {
            UserTeamListBox.Items.Clear();
            Reader reader = new Reader(name);
            string[] teams = reader.DBUserTeamReader().Split('\n');
            teams = teams.SkipLast(1).ToArray();
            foreach (string s in teams)
                UserTeamListBox.Items.Add(s);

            UserTaskListBox.Items.Clear();
            string[] tasks = reader.DBUserTaskReader().Split('\n');
            teams = teams.SkipLast(1).ToArray();
            foreach (string s in tasks)
                UserTaskListBox.Items.Add(s);
        }
    }
}
