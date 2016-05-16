using Data.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApplication.Forms
{
    public partial class AgendaForm : Form
    {
        private AgendaController agendaCtrl = new AgendaController();
        public String WorkflowName { get { return this.WFNameTextBox.Text; } }
        public Data.DA_Agenda PendingWorkflow { get { return (Data.DA_Agenda)this.dA_AgendaBindingSource.Current; } }

        public AgendaForm()
        {
            InitializeComponent();
        }

        private void OpenWFRepolButton_Click(object sender, EventArgs e)
        {
            if (this.WFNameTextBox.Text != String.Empty) this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CancelWFRepolButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dA_AgendaDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            Data.DA_Agenda ag = (Data.DA_Agenda)this.dA_AgendaBindingSource.Current;
            this.WFNameTextBox.Text = ag.Name + " - " + ag.PendingActivityName;
        }

        private void AgendaForm_Load(object sender, EventArgs e)
        {
            this.dA_AgendaBindingSource.DataSource = agendaCtrl.GetAllPending().OrderByDescending(x => x.DatePause);
        }
    }
}

