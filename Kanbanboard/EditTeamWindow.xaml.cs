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
    /// Interaction logic for EditTeamWindow.xaml
    /// </summary>
    public partial class EditTeamWindow : Window
    {
        public EditTeamWindow()
        {
            InitializeComponent();
        }
        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAddTeamButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ProjectBox_populate(object sender, RoutedEventArgs e)
        {
            AddTeamProjectSelect.Items.Clear();
            Reader reader = new Reader();
            string[] projects = reader.DBEveryProjectNameReader().Split('\n');
            projects = projects.SkipLast(1).ToArray();
            foreach (string s in projects)
                AddTeamProjectSelect.Items.Add(s);
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
    }
}
