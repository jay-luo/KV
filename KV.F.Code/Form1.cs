using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KV.F.Code
{
    public  partial  class Form1 : Form
    {
        public static Form1 f1;
        public  Form1()
        {
            f1 = this;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Test();
        }
        public   void Ch() {
            if (textBox1.InvokeRequired)
            {
                Action action = delegate ()
                {
                    textBox1.Text = "123";
                };
                textBox1.Invoke(action);
            }
            else
            {
                textBox1.Text = "456";
            }
        }
    }
}
