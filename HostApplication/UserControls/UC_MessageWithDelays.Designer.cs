namespace HostApplication.UserControls
{
    partial class UC_MessageWithDelays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.digitalGauge2 = new Syncfusion.Windows.Forms.Gauge.DigitalGauge();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // digitalGauge2
            // 
            this.digitalGauge2.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.digitalGauge2.BackgroundGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.digitalGauge2.CharacterCount = 2;
            this.digitalGauge2.DisplayRecordIndex = 0;
            this.digitalGauge2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digitalGauge2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(111)))), ((int)(((byte)(119)))));
            this.digitalGauge2.FrameBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.digitalGauge2.Location = new System.Drawing.Point(3, 52);
            this.digitalGauge2.MaximumSize = new System.Drawing.Size(500, 180);
            this.digitalGauge2.MinimumSize = new System.Drawing.Size(90, 90);
            this.digitalGauge2.Name = "digitalGauge2";
            this.digitalGauge2.OuterFrameGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(202)))), ((int)(((byte)(217)))));
            this.digitalGauge2.OuterFrameGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.digitalGauge2.Size = new System.Drawing.Size(184, 102);
            this.digitalGauge2.TabIndex = 1;
            this.digitalGauge2.Value = "00";
            this.digitalGauge2.VisualStyle = Syncfusion.Windows.Forms.Gauge.ThemeStyle.Blue;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.digitalGauge2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.75676F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.24324F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 157);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // UC_MessageWithDelays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_MessageWithDelays";
            this.Size = new System.Drawing.Size(190, 157);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private Syncfusion.Windows.Forms.Gauge.DigitalGauge digitalGauge2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
