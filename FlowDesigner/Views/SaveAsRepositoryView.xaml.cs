using Data;
using Data.Controllers;
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

namespace FlowDesigner
{
    /// <summary>
    /// Interaction logic for SaveAsRepositoryView.xaml
    /// </summary>
    public partial class SaveAsRepositoryView : Window
    {
        private WorkflowRepositoryController WFRepoController = new WorkflowRepositoryController();

        public String WorkflowName { get { return this.WFNameTextBox.Text; } }

        public SaveAsRepositoryView()
        {
            InitializeComponent();
        }

        private void SaveWFRepolButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WFNameTextBox.Text != String.Empty) this.DialogResult = true;
            else this.DialogResult = false;
        }
    }
}
