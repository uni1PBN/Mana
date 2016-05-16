using Data;
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
    public partial class OpenRepositoryForm : Form
    {
        private WorkflowRepositoryController WFRepoController = new WorkflowRepositoryController();
        public String WorkflowName { get { return this.WFNameTextBox.Text; } }

        public OpenRepositoryForm()
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
            //this.Close();
        }

        private void OpenRepositoryForm_Load(object sender, EventArgs e)
        {
            WFRepoListBox.DataSource = WFRepoController.GetNameList(false);
        }


        private void WFRepoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.WFNameTextBox.Text = (String)WFRepoListBox.SelectedItem;
        }
    }
}
