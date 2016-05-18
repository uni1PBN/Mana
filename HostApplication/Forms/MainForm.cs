using Data;
using Data.Controllers;
using HostApplication.Forms;
using HostApplication.Helpers;
using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Activities.Hosting;
using System.Activities.XamlIntegration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApplication
{
    public partial class MainForm : Form, IInjectedForm
    {
        #region Fields & Properties

        private System.Threading.AutoResetEvent instanceUnloaded = new System.Threading.AutoResetEvent(false);
        private BookmarkInfo bookmarkInfo;
        private WorkflowApplication wfapp;
        private CustomTrackingParticipant executionLog;
        private enum ExcutionMode { RunNewInstance, ResumePendingInstance, RunPendingInstance };
        private ExcutionMode executionMode;
        private enum WFStatus { Created, Started, Aborded, Completed, None };
        private WFStatus wfStatus;
        public Dossier dossier { get; set; }

        #endregion

        #region cTor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Menu BUSINESS PROCESS

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Statuslabel.Text = "-------------------";
            this.executionMode = ExcutionMode.RunNewInstance;
            WorkflowRepository wfRepoItem = GetWorkflowRepository();
            Activity mywf = GetActivityFromWorkflowRepository(wfRepoItem);
            if (mywf != null)
            {
                wfStatus = WFStatus.Created;
                this.DossierTextBox.Text = wfRepoItem.Name;
                CREATE_dossier();
                RUN(wfRepoItem, mywf, Guid.Parse("00000000-0000-0000-0000-000000000000"), dossier);
                this.Text = "Business Process : " + " (" + wfapp.Id.ToString() + ")";
                timer1.Start();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.executionMode = ExcutionMode.ResumePendingInstance;
            Data.DA_Agenda ag = GetPendingWorkflow();
            if (ag != null)
            {
                Activity mywf = GetActivityFromWorkflowRepository(ag.Workflow);
                if (mywf != null)
                {
                    wfStatus = WFStatus.Created;
                    dossier = ag.Dossier;
                    READ_dossier();
                    RUN(ag.Workflow, mywf, ag.WFInstanceId, dossier);
                    this.Text = "Business Process : " + " (" + wfapp.Id.ToString() + ")";
                    timer1.Start();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wfStatus == WFStatus.Started && wfapp != null) wfapp.Unload();
        }

        #endregion

        #region WF Methods

        private Activity GetActivityFromWorkflowFile()
        {
            Activity mywf = null;
            var dialogOpen = new OpenFileDialog();
            dialogOpen.Title = "Open Workflow";
            dialogOpen.Filter = "Workflows (.xaml)|*.xaml";

            if (dialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Stream myXaml = File.OpenRead(dialogOpen.FileName);
                    mywf = ActivityXamlServices.Load(myXaml, new ActivityXamlServicesSettings());// { CompileExpressions = true });
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error during loading workflow instance", ex);
                }
            }
            return mywf;
        }

        private WorkflowRepository GetWorkflowRepository()
        {
            WorkflowRepositoryController WFRepositoryController = new WorkflowRepositoryController();
            WorkflowRepository wf = null;
            var dialogOpen = new OpenRepositoryForm();
            if (dialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    String name = dialogOpen.WorkflowName;
                    if (name != String.Empty)
                    {
                        wf = WFRepositoryController.GetItem(name);
                    }
                    else MessageBox.Show("Workflow " + name + " does not exist!", "Workflow Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error during loading workflow instance", ex);
                }
            }
            return wf;
        }

        private Activity GetActivityFromWorkflowRepository(WorkflowRepository wf)
        {
            Activity mywf = null;
            try
            {
                MemoryStream myXaml;


                if (wf != null)
                {
                    myXaml = new MemoryStream(Encoding.UTF8.GetBytes(wf.WorkFlow));
                    mywf = ActivityXamlServices.Load(myXaml, new ActivityXamlServicesSettings());
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error during loading workflow instance", ex);
            }

            return mywf;
        }

        private DA_Agenda GetPendingWorkflow()
        {
            DA_Agenda ag = null;
            var dialogOpen = new AgendaForm();
            if (dialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    ag = dialogOpen.PendingWorkflow;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error during loading workflow instance", ex);
                }
            }
            return ag;
        }

        private void RUN(WorkflowRepository wfRepositoryItem, Activity mywf, Guid wfInstanceID, Dossier _dossier)
        {
            // Create a WorflowApplication
            wfapp = new WorkflowApplication(mywf);
            injector = new InjectionController(this.panel1, wfapp);//, _dossier);

            //setup persistence
            SqlWorkflowInstanceStore store = new SqlWorkflowInstanceStore(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename='C:\Users\uni1lab\OneDrive\Projects\Visual Studio 2013\UNI1 Mana\DBMana.mdf';integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework");
            //System.Runtime.DurableInstancing.InstanceStore store = new SqlWorkflowInstanceStore(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename='C:\Users\uni1lab\OneDrive\Projects\Visual Studio 2013\UNI1 Mana\DBMana.mdf';integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework");
            System.Runtime.DurableInstancing.InstanceHandle handle = store.CreateInstanceHandle();
            System.Runtime.DurableInstancing.InstanceView view = store.Execute(handle, new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));
            handle.Free();
            store.DefaultInstanceOwner = view.InstanceOwner;
            wfapp.InstanceStore = store;

            //Add Tracking Extension to WF. 
            executionLog = new CustomTrackingParticipant(wfRepositoryItem, wfInstanceID, Environment.UserName, _dossier);
            wfapp.Extensions.Add(executionLog);

            //Add ReferenceService Extension to WF to pass arguments to WF without using InArgument.
            //   Reason : Reference to MainForm must be passed to WF instance in order to inject 
            //UserControl encapsuled in Activity into MainForm. Normally, MainForm should be passed
            //trought InArgument. Problem is that during WF persitence, InArguments are serialized, 
            //but a form is not serializable.
            ReferenceService refService = new ReferenceService();
            refService.SetMainFormReference(this);
            wfapp.Extensions.Add(refService);

            //Set WF lifecycle events
            wfapp.Completed = WfExecutionCompleted;
            wfapp.Idle = WfExecutionIdled;
            wfapp.Aborted = WfExecutionAborted;
            wfapp.Unloaded = WfExecutionUnloaded;
            wfapp.OnUnhandledException = WFOnUnhandledException;
            wfapp.PersistableIdle = WFPersistableIdle;

            //Run The WF
            try
            {
                if (executionMode == ExcutionMode.ResumePendingInstance && wfInstanceID != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    wfapp.Load(wfInstanceID);
                    Console.WriteLine("HostApplication (LOAD) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() + wfInstanceID.ToString());
                }
                wfapp.Run();
                wfStatus = WFStatus.Started;
            }
            catch (WorkflowApplicationException ex)// Exception)
            {
                throw new WorkflowApplicationException("Error on Workflow " + ex.InstanceId, ex);
            }
            Console.WriteLine("HostApplication (RUN) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

        }

        #endregion

        #region WF Lifecycle Events

        private void WfExecutionCompleted(WorkflowApplicationCompletedEventArgs e)
        {
            wfStatus = WFStatus.Completed;
            timer1.Stop();
            Console.WriteLine("HostApplication (WfExecutionCompleted) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void WfExecutionAborted(WorkflowApplicationAbortedEventArgs e)
        {
            wfStatus = WFStatus.Aborded;
            UPDATE_dossier();
            timer1.Stop();
            Console.WriteLine("HostApplication (WfExecutionAborted) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }
        private void WfExecutionIdled(WorkflowApplicationIdleEventArgs e)
        {
            Console.WriteLine("HostApplication (WfExecutionIdled) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            if (e.Bookmarks != null && e.Bookmarks.Count > 0)
            {
                bookmarkInfo = e.Bookmarks[0];
            }
        }
        private void WfExecutionUnloaded(WorkflowApplicationEventArgs e) { }
        private UnhandledExceptionAction WFOnUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine("HostApplication (OnUnhandledException) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            return UnhandledExceptionAction.Abort;
        }
        private PersistableIdleAction WFPersistableIdle(WorkflowApplicationIdleEventArgs e)
        {
            Console.WriteLine("HostApplication (PersistableIdle) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            //if (dossier != null)
            //{
            //    dossier.Name = this.DossierTextBox.Text;
            //    //dossier.Status = this.Statuslabel.Text;
            //}
            UPDATE_dossier();
            return PersistableIdleAction.Persist;
        }

        private void ResumePendingInstance()
        {
            executionMode = ExcutionMode.RunPendingInstance;
            Console.WriteLine("HostApplication (ResumePendingInstance ) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            if (bookmarkInfo != null) wfapp.ResumeBookmark(bookmarkInfo.BookmarkName, "RESUMED");

        }

        #endregion

        #region WF Tracking Timer

        private void TimerUpdatingTracking(object sender, EventArgs e)
        {
            if (executionMode == ExcutionMode.ResumePendingInstance)
            {
                ResumePendingInstance();
            }
            executionLog.dossier = dossier;
            this.LogtextBox.Text = executionLog.Console;
        }

        #endregion

        #region Menu TOOLS

        private async void purgeLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete all pending tasks", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == System.Windows.Forms.DialogResult.Yes)
            {
                //var Activityctrl = new Data.Controllers.ActivityLogController();
                //var WFctrl = new Data.Controllers.WorkflowInstanceLogController();
                //var InstTblctrl = new Data.Controllers.InstancesTableController();
                //Activityctrl.RemoveAll();
                //WFctrl.RemoveAll();
                //InstTblctrl.RemoveAll();
                DBManaEntities context = DBManaEntitiesSingleton.Instance;
                context.MANA_ActivityLog.Clear();
                context.MANA_WFInstancesLog.Clear();
                await context.SaveChangesAsync();
                context.InstancesTable.Clear();
                await context.SaveChangesAsync();
            }
        }

        #endregion

        #region CRUD Dossier

        private void CREATE_dossier()
        {
            dossier = new Dossier { OpenDate = DateTime.Now, Name = this.DossierTextBox.Text, Status = this.Statuslabel.Text };
        }

        private void READ_dossier()
        {
            if (dossier != null)
            {
                this.DossierTextBox.Text = dossier.Name;
                this.Statuslabel.Text = dossier.Status;
            }
        }

        private void UPDATE_dossier()
        {
            if (dossier != null)
            {
                dossier.Name = this.DossierTextBox.Text;
                //dossier.Status = this.Statuslabel.Text; =====> BECAUSE IT IS READ ONLY
                (new DossierController()).UpdateItem(dossier);
            }
        }

        private void IMPORT_dossier(string statut)
        {
            if (dossier != null)
            {
                dossier.Status = statut;
                this.Statuslabel.Text = statut;
            }
        }
        #endregion

        #region Injection UserControls

        private InjectionController injector;

        void IInjectedForm.Inject(Type controlType, object[] activityParams)
        {
            if (dossier != null) dossier.Status = (String)activityParams[1];
            injector.InjectControl(controlType, activityParams);
        }

        void IInjectedForm.Remove(object controlReturnedValue)
        {
            this.Statuslabel.Text = dossier.Status;
            if ((String)controlReturnedValue == "ABORT")
            {
                if (MessageBox.Show("Are you sure to abort this process ?", "Abort Business Process", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    wfapp.Abort("Aborted by user");
                }
            }
            injector.RemoveControl(this.bookmarkInfo, (string)controlReturnedValue);
        }

        #endregion
    }
}




//#region UserControled Activities

//#region MessageWithDelays

//HostApplication.UserControls.UC_MessageWithDelays _uc_MessageWithDelays;
//public void InjectUC_MessageWithDelays(string message, Int32 delay, string statut)
//{
//    if (dossier != null) dossier.Status = statut;
//    _uc_MessageWithDelays = new HostApplication.UserControls.UC_MessageWithDelays(message, delay);
//    _uc_MessageWithDelays.TimeOut += new System.EventHandler(this.RemoveUC_MessageWithDelays);
//    this.panel1.Controls.Add(_uc_MessageWithDelays);
//}

//public void RemoveUC_MessageWithDelays(object sender, EventArgs e)
//{
//    if (bookmarkInfo != null) wfapp.ResumeBookmark(bookmarkInfo.BookmarkName, "0");
//    this.Statuslabel.Text = dossier.Status;
//    panel1.Controls.Remove(_uc_MessageWithDelays);
//}

//#endregion

//#region MessageWith2Button

//HostApplication.UserControls.UC_MessageWith2Button _uc_MessageWith2Button;
//public void InjectUC_MessageWith2Button(string message, string statut)
//{
//    IMPORT_dossier(statut);
//    _uc_MessageWith2Button = new HostApplication.UserControls.UC_MessageWith2Button(message);
//    _uc_MessageWith2Button.Dock = System.Windows.Forms.DockStyle.Fill;
//    _uc_MessageWith2Button.Location = new System.Drawing.Point(0, 0);
//    _uc_MessageWith2Button.Name = "activity1";
//    _uc_MessageWith2Button.TabIndex = 0;
//    _uc_MessageWith2Button.Button1Click += new System.EventHandler(this.OnButton1);
//    _uc_MessageWith2Button.Button2Click += new System.EventHandler(this.OnButton2);

//    this.panel1.Controls.Add(_uc_MessageWith2Button);
//    Console.WriteLine("HostApplication (InjectUC_MessageWith2Button) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
//}

//public void OnButton1(object sender, EventArgs e)
//{
//    if (MessageBox.Show("Are you sure to abort this process ?", "Abort Business Process", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
//    {
//        wfapp.Abort("Aborted by user");
//        panel1.Controls.Remove(_uc_MessageWith2Button);
//    }
//    Console.WriteLine("HostApplication (OnButton1 - UC_MessageWith2Button) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
//}
//public void OnButton2(object sender, EventArgs e) { RemoveUC_MessageWith2Button("2"); }
//public void RemoveUC_MessageWith2Button(string val)
//{
//    if (bookmarkInfo != null) wfapp.ResumeBookmark(bookmarkInfo.BookmarkName, val);
//    this.Statuslabel.Text = dossier.Status;
//    panel1.Controls.Remove(_uc_MessageWith2Button);
//    Console.WriteLine("HostApplication (RemoveUC_MessageWith2Button) thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
//}

//#endregion

//#region MessageYesNo

//HostApplication.UserControls.UC_MessageYesNoButton _uc_MessageYesNoButton;
//public void InjectUC_MessageYesNoButton(string message, string statut)
//{
//    if (dossier != null) dossier.Status = statut;
//    _uc_MessageYesNoButton = new HostApplication.UserControls.UC_MessageYesNoButton(message);
//    _uc_MessageYesNoButton.Button1Click += new System.EventHandler(this.OnButtonYES);
//    _uc_MessageYesNoButton.Button2Click += new System.EventHandler(this.OnButtonNO);

//    this.panel1.Controls.Add(_uc_MessageYesNoButton);
//}

//public void OnButtonYES(object sender, EventArgs e) { RemoveUC_MessageYesNoButton("YES"); }
//public void OnButtonNO(object sender, EventArgs e) { RemoveUC_MessageYesNoButton("NO"); }
//public void RemoveUC_MessageYesNoButton(string val)
//{
//    if (bookmarkInfo != null) wfapp.ResumeBookmark(bookmarkInfo.BookmarkName, val);
//    this.Statuslabel.Text = dossier.Status;
//    panel1.Controls.Remove(_uc_MessageYesNoButton);
//}
//#endregion

//#endregion