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
    /// Interaction logic for TaskInfo.xaml
    /// </summary>
    public partial class TaskInfo : Window
    {
        string name;
        public TaskInfo(string nimi)
        {
            InitializeComponent();
            name = nimi;
            Loaded += Window_populate;
        }
        public void Window_populate(object sender, EventArgs e)
        {
            Reader reader = new Reader(name);
            TaskNameBox.Text = name;
            TaskUserStoryBox.Text = reader.DBTaskUserStoryReader();
            TaskSprintBox.Text = reader.DBTaskSprintReader();
            TaskUserBox.Text = reader.DBTaskUserReader();
            TaskInfoBox.Text = reader.DBTaskInfoReader();
            TaskPrioBox.Text = reader.DBTaskPrioReader();
            TaskStateBox.Text = reader.DBTaskStateReader();
            TaskStartDateBox.Text = reader.DBTaskStartDateReader().ToString("dd-MM-yyyy");
            TaskDeadLineBox.Text = reader.DBTaskEndDateReader().ToString("dd-MM-yyyy");
            TaskDifficultyBox.Text = reader.DBTaskDifficultyReader();
            TaskDurationBox.Text = reader.DBTaskDurationReader();
        }
    }
}
