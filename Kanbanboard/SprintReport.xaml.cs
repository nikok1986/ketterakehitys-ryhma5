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
    /// Interaction logic for SprintReport.xaml
    /// </summary>
    public partial class SprintReport : Window
    {
        string name;
        public SprintReport(string nimi)
        {
            InitializeComponent();
            name = nimi;
            Loaded += Lists_populate;
        }
        private void Lists_populate(object sender, RoutedEventArgs e)
        {
            Reader reader = new Reader(name);
            SprintTitleBox.Text = name;
            SprintInfoBox.Text = reader.DBSprintInfoReader();
            SprintStartDateBox.Text = reader.DBSprintStartDate().ToString("dd-MM-yyyy");
            SprintEndDateBox.Text = reader.DBSprintEndDate().ToString("dd-MM-yyyy");

            BackLogTaskList.Items.Clear();
            string[] taskList = reader.DBBackLogReader().Split('\n');
            taskList = taskList.SkipLast(1).ToArray();
            foreach (string s in taskList)
                BackLogTaskList.Items.Add(s);

            InProgressTaskList.Items.Clear();
            string[] progressList = reader.DBTaskInProgressReader().Split('\n');
            progressList = progressList.SkipLast(1).ToArray();
            foreach (string s in progressList)
                InProgressTaskList.Items.Add(s);

            CompleteTaskList.Items.Clear();
            string[] completeList = reader.DBCompleteTaskReader().Split('\n');
            completeList = completeList.SkipLast(1).ToArray();
            foreach (string s in completeList)
                CompleteTaskList.Items.Add(s);
        }
    }
}
