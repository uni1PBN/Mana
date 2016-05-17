using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApplication.UserControls
{
    public partial class UC_MessageWithDelays : UserControl
    {
        public event EventHandler TimeOut;

        public String message { get; set; }
        public Int32 delay { get; set; }

        public UC_MessageWithDelays() 
        {
        }

        public UC_MessageWithDelays(String message, Int32 delay)
        {
            InitializeComponent();
            this.label1.Text = message;
            this.delay = delay;
            this.digitalGauge2.Value = delay.ToString();
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            delay -= 1;
            this.digitalGauge2.Value = delay.ToString();
            if (delay < 0)
            {
                timer1.Stop();
                if (this.TimeOut != null)
                    this.TimeOut(this, e);
            }
        }
    }
}
