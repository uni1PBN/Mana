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
    public partial class UC_MessageWith2Button : UserControl
    {

        //public String message { get; set; }
        //public String Button1Text { get; set; }
        //public String Button2Text { get; set; }

        private IInjectedForm _form;
        public UC_MessageWith2Button()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
        }
        public UC_MessageWith2Button(object[] cTorParams)
        {
            InitializeComponent();
            this._form = (IInjectedForm)cTorParams[0];
            this.label1.Text = (String) cTorParams[2];
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            _form.Remove("ABORT");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            _form.Remove("NEXT");
        }
    }
}
