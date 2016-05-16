namespace HostApplication.Forms
{
    partial class AgendaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CancelWFRepolButton = new System.Windows.Forms.Button();
            this.OpenWFRepolButton = new System.Windows.Forms.Button();
            this.WFNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dA_AgendaDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dA_AgendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HandlingUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DossierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DossierStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dA_AgendaDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dA_AgendaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelWFRepolButton
            // 
            this.CancelWFRepolButton.Location = new System.Drawing.Point(712, 395);
            this.CancelWFRepolButton.Name = "CancelWFRepolButton";
            this.CancelWFRepolButton.Size = new System.Drawing.Size(75, 23);
            this.CancelWFRepolButton.TabIndex = 9;
            this.CancelWFRepolButton.Text = "Cancel";
            this.CancelWFRepolButton.UseVisualStyleBackColor = true;
            this.CancelWFRepolButton.Click += new System.EventHandler(this.CancelWFRepolButton_Click);
            // 
            // OpenWFRepolButton
            // 
            this.OpenWFRepolButton.Location = new System.Drawing.Point(625, 395);
            this.OpenWFRepolButton.Name = "OpenWFRepolButton";
            this.OpenWFRepolButton.Size = new System.Drawing.Size(75, 23);
            this.OpenWFRepolButton.TabIndex = 6;
            this.OpenWFRepolButton.Text = "Open";
            this.OpenWFRepolButton.UseVisualStyleBackColor = true;
            this.OpenWFRepolButton.Click += new System.EventHandler(this.OpenWFRepolButton_Click);
            // 
            // WFNameTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.WFNameTextBox, 3);
            this.WFNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WFNameTextBox.Location = new System.Drawing.Point(114, 366);
            this.WFNameTextBox.Name = "WFNameTextBox";
            this.WFNameTextBox.Size = new System.Drawing.Size(680, 20);
            this.WFNameTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 369);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Workflow Name:";
            // 
            // dA_AgendaDataGridView
            // 
            this.dA_AgendaDataGridView.AllowUserToAddRows = false;
            this.dA_AgendaDataGridView.AllowUserToDeleteRows = false;
            this.dA_AgendaDataGridView.AllowUserToOrderColumns = true;
            this.dA_AgendaDataGridView.AutoGenerateColumns = false;
            this.dA_AgendaDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dA_AgendaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dA_AgendaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.HandlingUserName,
            this.DossierName,
            this.DossierStatus,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn1});
            this.tableLayoutPanel1.SetColumnSpan(this.dA_AgendaDataGridView, 4);
            this.dA_AgendaDataGridView.DataSource = this.dA_AgendaBindingSource;
            this.dA_AgendaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dA_AgendaDataGridView.Location = new System.Drawing.Point(3, 32);
            this.dA_AgendaDataGridView.Name = "dA_AgendaDataGridView";
            this.dA_AgendaDataGridView.ReadOnly = true;
            this.dA_AgendaDataGridView.RowHeadersWidth = 21;
            this.dA_AgendaDataGridView.Size = new System.Drawing.Size(791, 328);
            this.dA_AgendaDataGridView.TabIndex = 10;
            this.dA_AgendaDataGridView.SelectionChanged += new System.EventHandler(this.dA_AgendaDataGridView_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select pending task.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Controls.Add(this.CancelWFRepolButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OpenWFRepolButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.WFNameTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dA_AgendaDataGridView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(797, 421);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // dA_AgendaBindingSource
            // 
            this.dA_AgendaBindingSource.DataSource = typeof(Data.DA_Agenda);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DatePause";
            this.dataGridViewTextBoxColumn4.HeaderText = "Pause Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Process Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // HandlingUserName
            // 
            this.HandlingUserName.DataPropertyName = "HandlingUserName";
            this.HandlingUserName.HeaderText = "Handled By";
            this.HandlingUserName.Name = "HandlingUserName";
            this.HandlingUserName.ReadOnly = true;
            this.HandlingUserName.Width = 80;
            // 
            // DossierName
            // 
            this.DossierName.DataPropertyName = "DossierName";
            this.DossierName.HeaderText = "Dossier";
            this.DossierName.Name = "DossierName";
            this.DossierName.ReadOnly = true;
            this.DossierName.Width = 120;
            // 
            // DossierStatus
            // 
            this.DossierStatus.DataPropertyName = "DossierStatus";
            this.DossierStatus.HeaderText = "Dossier Status";
            this.DossierStatus.Name = "DossierStatus";
            this.DossierStatus.ReadOnly = true;
            this.DossierStatus.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PendingActivityName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Pending Activity";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DateStart";
            this.dataGridViewTextBoxColumn3.HeaderText = "Start Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ControlUserName";
            this.dataGridViewTextBoxColumn10.HeaderText = "Controled By";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WFInstanceId";
            this.dataGridViewTextBoxColumn1.HeaderText = "WFInstanceId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // AgendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AgendaForm";
            this.Text = "Agenda of pending tasks";
            this.Load += new System.EventHandler(this.AgendaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dA_AgendaDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dA_AgendaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelWFRepolButton;
        private System.Windows.Forms.Button OpenWFRepolButton;
        private System.Windows.Forms.TextBox WFNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource dA_AgendaBindingSource;
        private System.Windows.Forms.DataGridView dA_AgendaDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HandlingUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DossierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DossierStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}