using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddTeamMember.xaml
    /// </summary>
    public partial class AddTeamMember : Window
    {
        public AddTeamMember()
        {
            InitializeComponent();
            Loaded += ProjectBox_populate;
            Loaded += AllUsersListBox_populate;
        }
        private void AddTeamMeamberButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveTeamMemberButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompleteAddingTeamMembersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAddTeamMembersButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ProjectBox_populate(object sender, RoutedEventArgs e)
        {
            TeamProjectSelect.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryProjectNameReader().Split('\n');
            projects = projects.SkipLast(1).ToArray();
            foreach (string s in projects)
                TeamProjectSelect.Items.Add(s);
        }
        private void AllUsersListBox_populate(object sender, RoutedEventArgs e)
        {
            AllUsersListBox.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryUserNameReader().Split('\n');
            projects = projects.SkipLast(1).ToArray();
            foreach (string s in projects)
                AllUsersListBox.Items.Add(s);
        }

        private void RefreshProjectTeamsBoxButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedProjectTeamsBox.Items.Clear();
            string pjName = TeamProjectSelect.Text;
            Reader reader = new Reader(pjName);
            string[] projectTeams = reader.DBProjectTeamsReader().Split('\n');
            projectTeams = projectTeams.SkipLast(1).ToArray();
            foreach (string s in projectTeams)
                SelectedProjectTeamsBox.Items.Add(s);
        }


        private void RefreshTeamMembers_Click(object sender, RoutedEventArgs e)
        {
            TeamListBox.Items.Clear();
            string teamName = SelectedProjectTeamsBox.Text;
            Reader reader = new Reader(teamName);
            string[] teamMembers = reader.DBTeamUserReader().Split('\n');
            teamMembers = teamMembers.SkipLast(1).ToArray();
            foreach (string s in teamMembers) TeamListBox.Items.Add(s);
        }

        

    }
    
}
