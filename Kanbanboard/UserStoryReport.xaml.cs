using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
    /// Interaction logic for UserStoryReport.xaml
    /// </summary>
    public partial class UserStoryReport : Window
    {
        string name;
        public UserStoryReport(string nimi)
        {
            name= nimi;
            InitializeComponent();
            Loaded += AllLists_populate;
        }
        public void AllLists_populate(object sender, RoutedEventArgs e)
        {
            UserStoryNameBox.Text= name;
            Reader reader = new Reader(name);
            ProjectNameTextBox.Text = reader.DBUserStoryProjectReader();
            UserStoryInfoBox.Text = reader.DBUserStoryInfoReader();

            string[] tasks = reader.DBUserStoryTaskReader().Split('\n');
            tasks = tasks.SkipLast(1).ToArray();
            foreach (string s in tasks)
                UserStoryTaskListBox.Items.Add(s);

            string[] taskStates = reader.DBUserStoryTaskStateReader().Split('\n');
            taskStates = taskStates.SkipLast(1).ToArray();
            string finalState = String.Empty;

            for (int i = 0; i < taskStates.Length; i++)
            {
                if (taskStates[i] == "0" || taskStates[i] == "1")
                {
                    finalState += "kesken" + "\n";
                }
                if (taskStates[i] == "2")
                {
                    finalState += "valmis" + "\n";
                }
            }
            string[] finalList = finalState.Split("\n");

            foreach (string s in finalList)
                UserStoryTaskStateListBox.Items.Add(s);
        }
    }
}
