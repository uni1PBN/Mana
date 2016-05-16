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
    /// Interaction logic for OpenRepositoryView.xaml
    /// </summary>
    public partial class OpenRepositoryView : Window
    {
        private WorkflowRepositoryController WFRepoController = new WorkflowRepositoryController();

        public String WorkflowName { get { return this.WFNameTextBox.Text; } }

        public OpenRepositoryView()
        {
            InitializeComponent();
        }

        private void OpenWFRepolButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WFNameTextBox.Text != String.Empty) this.DialogResult = true;
            else this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WFRepoListBox.ItemsSource = WFRepoController.GetNameList(false);
        }

        private void WFRepoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.WFNameTextBox.Text = (String)WFRepoListBox.SelectedItem;
        }
    }
}
