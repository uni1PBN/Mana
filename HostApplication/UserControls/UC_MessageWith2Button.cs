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
    public partial class UC_MessageWith2Button : UserControl
    {
        public event EventHandler Button1Click;
        public event EventHandler Button2Click;

        public String message { get; set; }
        public String Button1Text { get; set; }
        public String Button2Text { get; set; }

        public UC_MessageWith2Button() { }

        public UC_MessageWith2Button(String message)//, String button1Text, String button2Text)
        {
            InitializeComponent();
            this.label1.Text = message;
            //this.button1.Text = button1Text;
            //this.button2.Text = button2Text;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.Button1Click != null)
                this.Button1Click(this, e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.Button2Click != null)
                this.Button2Click(this, e);
        }
    }
}
