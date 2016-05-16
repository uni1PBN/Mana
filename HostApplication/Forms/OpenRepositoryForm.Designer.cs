namespace HostApplication.Forms
{
    partial class OpenRepositoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.WFRepoListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WFNameTextBox = new System.Windows.Forms.TextBox();
            this.OpenWFRepolButton = new System.Windows.Forms.Button();
            this.CancelWFRepolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a workflow:";
            // 
            // WFRepoListBox
            // 
            this.WFRepoListBox.FormattingEnabled = true;
            this.WFRepoListBox.Location = new System.Drawing.Point(16, 30);
            this.WFRepoListBox.Name = "WFRepoListBox";
            this.WFRepoListBox.Size = new System.Drawing.Size(376, 199);
            this.WFRepoListBox.TabIndex = 1;
            this.WFRepoListBox.SelectedIndexChanged += new System.EventHandler(this.WFRepoListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Workflow Name:";
            // 
            // WFNameTextBox
            // 
            this.WFNameTextBox.Location = new System.Drawing.Point(108, 235);
            this.WFNameTextBox.Name = "WFNameTextBox";
            this.WFNameTextBox.Size = new System.Drawing.Size(284, 20);
            this.WFNameTextBox.TabIndex = 3;
            // 
            // OpenWFRepolButton
            // 
            this.OpenWFRepolButton.Location = new System.Drawing.Point(236, 262);
            this.OpenWFRepolButton.Name = "OpenWFRepolButton";
            this.OpenWFRepolButton.Size = new System.Drawing.Size(75, 23);
            this.OpenWFRepolButton.TabIndex = 0;
            this.OpenWFRepolButton.Text = "Open";
            this.OpenWFRepolButton.UseVisualStyleBackColor = true;
            this.OpenWFRepolButton.Click += new System.EventHandler(this.OpenWFRepolButton_Click);
            // 
            // CancelWFRepolButton
            // 
            this.CancelWFRepolButton.Location = new System.Drawing.Point(317, 262);
            this.CancelWFRepolButton.Name = "CancelWFRepolButton";
            this.CancelWFRepolButton.Size = new System.Drawing.Size(75, 23);
            this.CancelWFRepolButton.TabIndex = 5;
            this.CancelWFRepolButton.Text = "Cancel";
            this.CancelWFRepolButton.UseVisualStyleBackColor = true;
            this.CancelWFRepolButton.Click += new System.EventHandler(this.CancelWFRepolButton_Click);
            // 
            // OpenRepositoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 295);
            this.Controls.Add(this.CancelWFRepolButton);
            this.Controls.Add(this.OpenWFRepolButton);
            this.Controls.Add(this.WFNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WFRepoListBox);
            this.Controls.Add(this.label1);
            this.Name = "OpenRepositoryForm";
            this.Text = "Workflows Repository";
            this.Load += new System.EventHandler(this.OpenRepositoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox WFRepoListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WFNameTextBox;
        private System.Windows.Forms.Button OpenWFRepolButton;
        private System.Windows.Forms.Button CancelWFRepolButton;
    }
}