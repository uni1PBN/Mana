namespace HostApplication
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Statuslabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LogtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.businessProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workflowLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activitiesLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsNanigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purgeLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.DossierTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(16, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 191);
            this.panel1.TabIndex = 5;
            // 
            // Statuslabel
            // 
            this.Statuslabel.AutoSize = true;
            this.Statuslabel.Location = new System.Drawing.Point(61, 86);
            this.Statuslabel.Name = "Statuslabel";
            this.Statuslabel.Size = new System.Drawing.Size(64, 13);
            this.Statuslabel.TabIndex = 6;
            this.Statuslabel.Text = "-------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Status: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(16, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current Activity";
            // 
            // LogtextBox
            // 
            this.LogtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogtextBox.Location = new System.Drawing.Point(279, 135);
            this.LogtextBox.Multiline = true;
            this.LogtextBox.Name = "LogtextBox";
            this.LogtextBox.ReadOnly = true;
            this.LogtextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogtextBox.Size = new System.Drawing.Size(420, 191);
            this.LogtextBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Todo List ( list of steps already performed in this process )";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.TimerUpdatingTracking);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.businessProcessesToolStripMenuItem,
            this.tOOLSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // businessProcessesToolStripMenuItem
            // 
            this.businessProcessesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.businessProcessesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.businessProcessesToolStripMenuItem.Name = "businessProcessesToolStripMenuItem";
            this.businessProcessesToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.businessProcessesToolStripMenuItem.Text = "BUSINESS PROCESSES";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workflowLogToolStripMenuItem,
            this.activitiesLogToolStripMenuItem,
            this.instanceTableToolStripMenuItem,
            this.logsNanigationToolStripMenuItem,
            this.purgeLogsToolStripMenuItem});
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.tOOLSToolStripMenuItem.Text = "TOOLS";
            // 
            // workflowLogToolStripMenuItem
            // 
            this.workflowLogToolStripMenuItem.Name = "workflowLogToolStripMenuItem";
            this.workflowLogToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.workflowLogToolStripMenuItem.Text = "Workflow Log";
            // 
            // activitiesLogToolStripMenuItem
            // 
            this.activitiesLogToolStripMenuItem.Name = "activitiesLogToolStripMenuItem";
            this.activitiesLogToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.activitiesLogToolStripMenuItem.Text = "Activities Log";
            // 
            // instanceTableToolStripMenuItem
            // 
            this.instanceTableToolStripMenuItem.Name = "instanceTableToolStripMenuItem";
            this.instanceTableToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.instanceTableToolStripMenuItem.Text = "Instance Table";
            // 
            // logsNanigationToolStripMenuItem
            // 
            this.logsNanigationToolStripMenuItem.Name = "logsNanigationToolStripMenuItem";
            this.logsNanigationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.logsNanigationToolStripMenuItem.Text = "Logs Navigation";
            // 
            // purgeLogsToolStripMenuItem
            // 
            this.purgeLogsToolStripMenuItem.Name = "purgeLogsToolStripMenuItem";
            this.purgeLogsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.purgeLogsToolStripMenuItem.Text = "Purge Logs";
            this.purgeLogsToolStripMenuItem.Click += new System.EventHandler(this.purgeLogsToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Dossier";
            // 
            // DossierTextBox
            // 
            this.DossierTextBox.Location = new System.Drawing.Point(64, 45);
            this.DossierTextBox.Name = "DossierTextBox";
            this.DossierTextBox.Size = new System.Drawing.Size(635, 20);
            this.DossierTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(711, 358);
            this.Controls.Add(this.DossierTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LogtextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Statuslabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Todo\'s Managemement Tool.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label Statuslabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LogtextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem businessProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workflowLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activitiesLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instanceTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsNanigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purgeLogsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DossierTextBox;
    }
}