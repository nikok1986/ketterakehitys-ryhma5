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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kanbanboard
{
    /// <summary>
    /// Interaction logic for TabitemMalli.xaml
    /// </summary>
    public partial class TabitemMalli : UserControl
    {
        

        public TabitemMalli()
        {
            InitializeComponent();
        }

        
        private void AddTask(object sender, RoutedEventArgs e)
        {

        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.AddTaskButton.Click += new RoutedEventHandler(AddTask);
            addTask.ShowDialog();
        }
    }
}
