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
using Data;
using System.Activities;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Metadata;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.ComponentModel;
using System.Reflection;
using Data.Controllers;


namespace FlowDesigner
{
    /// <summary>
    /// Interaction logic for DesignerView.xaml
    /// </summary>
    public partial class DesignerView : Window
    {
        private WorkflowDesigner wd;
        private ToolboxControl tc = new ToolboxControl();
        private WorkflowRepositoryController WFRepositoryController = new WorkflowRepositoryController();
        private WorkflowRepository WFRepositoryCurrentItem;

        public DesignerView()
        {
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized;

            // Register the metadata
            RegisterMetadata();

            // Add the WFF Designer
            AddDesigner();

            // Add the WFF ToolBox
            GetToolboxControl();
            AddToolBox();

            // Add the WFF Properties
            AddPropertyInspector();
        }

        #region Designer Mgt
        
        private void AddDesigner(String filename = "", String xaml = "")
        {
            //Create an instance of WorkflowDesigner class.
            wd = GetDesignerControl(filename, xaml);
            WfDesignerBorder.Child = wd.View;
            if (WFRepositoryCurrentItem != null) this.Title = "Flow Designer : " + WFRepositoryCurrentItem.Name;
            else this.Title = "Business Flow Designer";
        }

        private WorkflowDesigner GetDesignerControl(String filename = "", String xaml = "")
        {
            WorkflowDesigner designer = new WorkflowDesigner();
            designer.Context.Services.GetService<DesignerConfigurationService>().AnnotationEnabled = true;
            designer.Context.Services.GetService<DesignerConfigurationService>().AutoConnectEnabled = true;
            designer.Context.Services.GetService<DesignerConfigurationService>().NamespaceConversionEnabled = false;
            designer.Context.Services.GetService<DesignerConfigurationService>().TargetFrameworkName = new System.Runtime.Versioning.FrameworkName(".NETFramework", new Version(4, 6));
            designer.Context.Services.GetService<DesignerConfigurationService>().LoadingFromUntrustedSourceEnabled = true;

            //Load a new Sequence as default.
            //this.wd.Load(new Flowchart());
            if (filename != string.Empty)
            {
                designer.Load(filename);
            }
            else if (xaml != string.Empty)
            {
                designer.Text = xaml;
                designer.Load();
            }
            return designer;
        }

        private void ClearDesigner()
        {
            WfDesignerBorder.Child = null;
            WfPropertyBorder.Child = null;

            WFRepositoryCurrentItem = null;
            wd = null;
            AddToolBox();
        }

        private void RegisterMetadata()
        {
            DesignerMetadata dm = new DesignerMetadata();
            dm.Register();
        }

        private void GetToolboxControl()
        {
            ////////////Business Activities///////////////////////////////////////////////////////////////////////////////////////////////
            // Create a category
            ToolboxCategory categoryBusinessActivities = new ToolboxCategory("Business Activities");

            ToolboxItemWrapper tool3 = new ToolboxItemWrapper("HostApplication.Activities.ActivityShow_UC_MessageWith2Buttons",
                typeof(HostApplication.Activities.ActivityShow_UC_MessageWith2Buttons).Assembly.FullName, null, "Message Next");

            ToolboxItemWrapper tool31 = new ToolboxItemWrapper("HostApplication.Activities.ActivityMessageYesNo",
                typeof(HostApplication.Activities.ActivityMessageYesNo).Assembly.FullName, null, "Message Yes/No");

            ToolboxItemWrapper tool4 = new ToolboxItemWrapper("HostApplication.Activities.ActivityShow_UC_MessageWithDelays",
                typeof(HostApplication.Activities.ActivityShow_UC_MessageWithDelays).Assembly.FullName, null, "Delayed Message");

            // Add the Toolbox items to the categoryStatements.
            categoryBusinessActivities.Add(tool3);
            categoryBusinessActivities.Add(tool31);
            categoryBusinessActivities.Add(tool4);



            ////////////Statements///////////////////////////////////////////////////////////////////////////////////////////////
            // Create a categoryStatements.
            ToolboxCategory categoryStatements = new ToolboxCategory("Statements");

            ToolboxItemWrapper tool2 = new ToolboxItemWrapper("System.Activities.Statements.Sequence",
                typeof(Sequence).Assembly.FullName, null, "Sequence");

            ToolboxItemWrapper tool21 = new ToolboxItemWrapper("System.Activities.Statements.If",
                typeof(If).Assembly.FullName, null, "If");

            ToolboxItemWrapper tool22 = new ToolboxItemWrapper("System.Activities.Statements.DoWhile",
                typeof(DoWhile).Assembly.FullName, null, "DoWhile");

            ToolboxItemWrapper tool23 = new ToolboxItemWrapper("System.Activities.Statements.Parallel",
                typeof(System.Activities.Statements.Parallel).Assembly.FullName, null, "Parallel");

            ToolboxItemWrapper tool24 = new ToolboxItemWrapper("System.Activities.Statements.Pick",
                typeof(System.Activities.Statements.Pick).Assembly.FullName, null, "Pick");

            ToolboxItemWrapper tool25 = new ToolboxItemWrapper("System.Activities.Statements.PickBranch",
                typeof(System.Activities.Statements.PickBranch).Assembly.FullName, null, "Pick Branch");

            ToolboxItemWrapper tool26 = new ToolboxItemWrapper("System.Activities.Statements.Persist",
                typeof(System.Activities.Statements.Persist).Assembly.FullName, null, "Persist");

            // Add the Toolbox items to the categoryStatements.
            categoryStatements.Add(tool2);
            categoryStatements.Add(tool21);
            categoryStatements.Add(tool22);
            categoryStatements.Add(tool23);
            categoryStatements.Add(tool24);
            categoryStatements.Add(tool25);
            categoryStatements.Add(tool26);



            ////////////Flow Chart///////////////////////////////////////////////////////////////////////////////////////////////
            ToolboxCategory categoryFlowchart = new ToolboxCategory("Flow Chart");

            int activitiesCount = 0;
            // get all loaded assemblies
            IEnumerable<Assembly> appAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.GetName().Name.Contains("EntityFramework")
                    && !a.GetName().Name.Contains("Anonym"))
                .OrderBy(a => a.GetName().Name);

            foreach (Assembly activityLibrary in appAssemblies)
            {
                var actvities = from
                                    activityType in activityLibrary.GetExportedTypes()
                                where (activityType == typeof(System.Activities.Statements.Flowchart)
                                    || activityType == typeof(System.Activities.Statements.FlowDecision)
                                    || activityType == typeof(System.Activities.Statements.FlowSwitch<>)
                                    || activityType == typeof(System.Activities.Statements.FlowNode))
                                    && activityType.IsVisible
                                    && activityType.IsPublic
                                    && !activityType.IsNested
                                    && !activityType.IsAbstract
                                    && (activityType.GetConstructor(Type.EmptyTypes) != null)
                                orderby
                                    activityType.Name
                                select
                                    new ToolboxItemWrapper(activityType);

                actvities.ToList().ForEach(categoryFlowchart.Add);

                if (categoryFlowchart.Tools.Count > 0)
                {

                    activitiesCount += categoryFlowchart.Tools.Count;
                }
            }



            ////////////Specials///////////////////////////////////////////////////////////////////////////////////////////////
            // Create a categoryStatements.
            ToolboxCategory categorySpecial = new ToolboxCategory("Specials");

            // Create Toolbox items.
            ToolboxItemWrapper tool1 = new ToolboxItemWrapper("System.Activities.Statements.Assign",
                typeof(Assign).Assembly.FullName, null, "Assign");

            ToolboxItemWrapper tool11 = new ToolboxItemWrapper("System.Activities.Statements.InvokeMethod",
                typeof(InvokeMethod).Assembly.FullName, null, "Invoke Method");

            categorySpecial.Add(tool1);
            categorySpecial.Add(tool11);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////





            // Add the categoryStatements to the ToolBox control.
            tc.Categories.Add(categoryStatements);
            tc.Categories.Add(categoryFlowchart);
            tc.Categories.Add(categoryBusinessActivities);
            tc.Categories.Add(categorySpecial);
        }

        private void AddToolBox()
        {
            WfToolboxBorder.Child = tc;
            this.ToolBoxMnu.IsChecked = true;
            this.DocOutLineMnu.IsChecked = false;
        }

        private void AddPropertyInspector()
        {
            WfPropertyBorder.Child = wd.PropertyInspectorView;
        }

        #endregion

        #region Menu Actions

        private void NewMnu_Click(object sender, RoutedEventArgs e)
        {
            ClearDesigner();

            AddDesigner("defaultFlow.xaml");
            AddPropertyInspector();

            WFRepositoryCurrentItem = new WorkflowRepository();
            WFRepositoryCurrentItem.ValidityStartDate = DateTime.Now;
            WFRepositoryCurrentItem.ValidityEndDate = DateTime.MaxValue;
        }

        private void OpenMnu_Click(object sender, RoutedEventArgs e)
        {
            var repoDialogOpen = new OpenRepositoryView();
            bool result = repoDialogOpen.ShowDialog().Value;
            if (result)
            {
                String name = repoDialogOpen.WorkflowName;
                if (name != String.Empty)
                {
                    ClearDesigner();
                    WFRepositoryCurrentItem = WFRepositoryController.GetItem(name);
                    if (WFRepositoryCurrentItem != null)
                    {
                        AddDesigner("", WFRepositoryCurrentItem.WorkFlow);
                        AddPropertyInspector();
                    }
                    else MessageBox.Show("Workflow " + name + " does not exist!", "Flow Designer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CloseMnu_Click(object sender, RoutedEventArgs e)
        {
            ClearDesigner();
            if (WFRepositoryCurrentItem != null) this.Title = "Flow Designer : " + WFRepositoryCurrentItem.Name;
            else this.Title = "Business Flow Designer";
        }

        private void SaveMnu_Click(object sender, RoutedEventArgs e)
        {
            if (WFRepositoryCurrentItem != null
                && WFRepositoryCurrentItem.Name != String.Empty
                && !String.IsNullOrEmpty(wd.Text))
            {
                wd.Flush();
                if (WFRepositoryController.Exist(WFRepositoryCurrentItem.Name))
                {
                    WFRepositoryCurrentItem.WorkFlow = wd.Text;
                    WFRepositoryController.Save();// (WFRepositoryCurrentItem);
                    this.Title = "Flow Designer : " + WFRepositoryCurrentItem.Name;
                }
                else MessageBox.Show("Workflow " + WFRepositoryCurrentItem.Name + " aleary exist!", "Flow Designer", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SaveAsMnu_Click(object sender, RoutedEventArgs e)
        {
            var repoDialogOpen = new SaveAsRepositoryView();
            string name;
            bool result = repoDialogOpen.ShowDialog().Value;
            if (result)
            {
                name = repoDialogOpen.WorkflowName;
                if (name != String.Empty
                    && !String.IsNullOrEmpty(wd.Text))
                {
                    wd.Flush();
                    if (!WFRepositoryController.Exist(name)
                        && WFRepositoryCurrentItem != null)
                    {
                        WFRepositoryCurrentItem.Name = name;
                        WFRepositoryCurrentItem.ValidityStartDate = DateTime.Now;
                        WFRepositoryCurrentItem.ValidityEndDate = DateTime.MaxValue;
                        WFRepositoryCurrentItem.WorkFlow = wd.Text;
                        WFRepositoryController.AddNewItem(WFRepositoryCurrentItem);
                        this.Title = "Flow Designer : " + name;
                    }
                    else MessageBox.Show("Workflow " + name + " aleary exist!", "Flow Designer", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ImportMnu_Click(object sender, RoutedEventArgs e)
        {
            var dialogOpen = new Microsoft.Win32.OpenFileDialog();
            dialogOpen.Title = "Open Workflow";
            dialogOpen.Filter = "Workflows (.xaml)|*.xaml";

            if (dialogOpen.ShowDialog() == true)
            {
                ClearDesigner();
                AddDesigner(dialogOpen.FileName);
                AddPropertyInspector();

                WFRepositoryCurrentItem = new WorkflowRepository();
                WFRepositoryCurrentItem.ValidityStartDate = DateTime.Now;
                WFRepositoryCurrentItem.ValidityEndDate = DateTime.MaxValue;
            }
        }

        private void ExportMnu_Click(object sender, RoutedEventArgs e)
        {
            var dialogSave = new Microsoft.Win32.SaveFileDialog();
            dialogSave.Title = "Save Workflow";
            dialogSave.Filter = "Workflows (.xaml)|*.xaml";

            if (dialogSave.ShowDialog() == true)
            {
                wd.Save(dialogSave.FileName);
            }
        }

        private void ExitMnu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WFPropMnu_Click(object sender, RoutedEventArgs e)
        {
            if (WFRepositoryCurrentItem != null)
            {
                var repositoryPropertiesDialog = new Views.RepositoryView(
                    WFRepositoryCurrentItem.Name,
                    WFRepositoryCurrentItem.Description,
                    WFRepositoryCurrentItem.Area,
                    WFRepositoryCurrentItem.Function);

                bool result = repositoryPropertiesDialog.ShowDialog().Value;
                if (result)
                {
                    WFRepositoryCurrentItem.Description = repositoryPropertiesDialog.wfR.Description;
                    WFRepositoryCurrentItem.Area = repositoryPropertiesDialog.wfR.Area;
                    WFRepositoryCurrentItem.Function = repositoryPropertiesDialog.wfR.Function;
                }
            }
        }

        private void ToolBoxMnu_Click(object sender, RoutedEventArgs e)
        {
            if (!this.ToolBoxMnu.IsChecked)
            {
                AddToolBox();
            }
        }

        private void DocOutLineMnu_Click(object sender, RoutedEventArgs e)
        {
            if (!this.DocOutLineMnu.IsChecked && wd != null)
            {
                this.ToolBoxMnu.IsChecked = false;
                this.DocOutLineMnu.IsChecked = true;
                WfToolboxBorder.Child = wd.OutlineView;
            }
        }
    
        #endregion
    }
}
