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
        Main_Form main = new Main_Form();
        public Login_Form(Main_Form mainform)
        {
            main = mainform;
            InitializeComponent();
        }
        private void Login_Form_Activated(object sender, System.EventArgs e)
        {
            main.Enabled = false;
        }
        private void Login_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            main = (Main_Form)this.Owner;
            main.reload();
            
            main.Enabled = true;
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Boolean temp = Act_Sts.create(ref act);
            if(temp){
                button2_Click(sender, e);
            }
            label3.Text = "UserName already existed";
            label3.Visible = true;
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            if(Act_Sts.validate(ref act)){
                main.act = act;
                this.Close();
            }
            label3.Text = "UserName or Password incorrect";
            label3.Visible = true;
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
