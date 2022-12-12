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
    /// Interaction logic for TeamReport.xaml
    /// </summary>
    public partial class TeamReport : Window
    {
        string name;
        public TeamReport(string nimi)
        {
            InitializeComponent();
            name= nimi;
            Loaded += Window_populate;
        }
        public void Window_populate(object sender, EventArgs e) 
        {
            TeamHeaderBox.Text = name;
            Reader reader = new Reader(name);
            TeamProjectsBox.Text = reader.DBTeamProjectReader();
            TeamInfoBox.Text = reader.DBTeamInfoReader();

            TeamMembersListBox.Items.Clear();
            string[] completeList = reader.DBTeamUserReader().Split('\n');
            completeList = completeList.SkipLast(1).ToArray();
            foreach (string s in completeList)
                TeamMembersListBox.Items.Add(s);
        }
    }
}
