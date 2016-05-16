using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FlowDesigner.Views
{
    /// <summary>
    /// Interaction logic for RepositoryView.xaml
    /// </summary>
    public partial class RepositoryView : Window, INotifyPropertyChanged
    {
        private WorkflowRepository _wfR = new WorkflowRepository();
        public WorkflowRepository wfR
        {
            get { return _wfR; }
            set
            {
                _wfR = value;
                OnPropertyChanged("wfR");
            }
        }
      

        public RepositoryView()
        {
            InitializeComponent();
            this.RepoInfo.DataContext = wfR;
            //this.Loaded += new RoutedEventHandler(Window_Loaded);
        }
        public RepositoryView(String name, String desc, String area, String fonc)
        {
            InitializeComponent();
            this.RepoInfo.DataContext = wfR;
            //this.Loaded += new RoutedEventHandler(Window_Loaded);
            wfR.Name = name;
            wfR.Description = desc;
            wfR.Area = area;
            wfR.Function = fonc;
        }

        private void OKWFRepolButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    this.RepoInfo.DataContext = wfR;
        //    wfR = new WorkflowRepository();
        //    wfR = _wfR;
        //}


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) new PropertyChangedEventArgs(propertyName);
        }
        //event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        //{
        //    add { throw new NotImplementedException(); }
        //    remove { throw new NotImplementedException(); }
        //}
        #endregion



    }
}
