using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HsiuHsien.Entity;
using lib;
namespace main
{
    public partial class Login_Form : Form
    {
        public static Account act = new Account();
        public Login_Form()
        {
            InitializeComponent();
            TableCreate.create();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Act_Sts.create(act);
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            if(Act_Sts.validate(act)){
                Main_Form.ch.Lv = "1";
                this.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            act.Act_Nm = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            act.Act_Pw = textBox2.Text;
        }
    }
}
