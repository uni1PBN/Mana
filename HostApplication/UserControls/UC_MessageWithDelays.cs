using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HostApplication.Helpers;

namespace HostApplication.UserControls
{
    public partial class UC_MessageWithDelays : UserControl
    {
        //public event EventHandler TimeOut;

        //public String message { get; set; }
        public Int32 delay { get; set; }

        private IInjectedForm _form;
        public UC_MessageWithDelays() 
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
        }

        public UC_MessageWithDelays(object[] cTorParams)
        {
            InitializeComponent();
            this._form = (IInjectedForm)cTorParams[0];
            this.delay = (Int32)cTorParams[1];
            this.label1.Text = (String)cTorParams[2];
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.digitalGauge2.Value = delay.ToString();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            delay -= 1;
            this.digitalGauge2.Value = delay.ToString();
            if (delay < 0)
            {
                timer1.Stop();
                _form.Remove("NEXT");
                //if (this.TimeOut != null)
                //    this.TimeOut(this, e);
            }
        }
    }
}
