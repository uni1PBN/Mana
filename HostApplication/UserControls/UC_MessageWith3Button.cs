using System;
using System.Windows.Forms;
using HostApplication.Helpers;

namespace HostApplication.UserControls
{
    public partial class MessageWith3Button : UserControl
    {
        private IInjectedForm _form;
        public MessageWith3Button()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
        }

        public MessageWith3Button(object[] cTorParams)
        {
            InitializeComponent();
            this._form = (IInjectedForm)cTorParams[0];
            this.label1.Text = (String) cTorParams[2];
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            _form.Remove("BUTTON1");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            _form.Remove("BUTTON2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _form.Remove("BUTTON3");
        }
    }
}
