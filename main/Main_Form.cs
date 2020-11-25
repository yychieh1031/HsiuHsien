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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            Character ch = test.Ch_testValue();
            Monster mns = test.Mns_testValue();
            UIDisplay(ch);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Character ch = test.Ch_testValue();
            Monster mns = test.Mns_testValue();
            string result = Battle.StartFight(ch, mns);
            output.AppendText(result);
            output.AppendText(Environment.NewLine);
            
        }

        private void UIDisplay(Character ch)
        {
            textBox1.Text = ch.Ch_Nm;
            Lv.Text = ch.Lv;
            textBox3.Text = ch.EXP;
            textBox4.Text = ch.HP;
            textBox5.Text = ch.MP;
            textBox6.Text = ch.ATK.ToString();
            textBox7.Text = ch.MATK.ToString();
            textBox8.Text = ch.Critical.ToString();
            textBox9.Text = ch.DEF.ToString();
            textBox10.Text = ch.MDEF.ToString();
            textBox11.Text = ch.STR.ToString();
            textBox12.Text = ch.INT.ToString();
            textBox13.Text = ch.VIT.ToString();
            textBox14.Text = ch.AGI.ToString();
            textBox15.Text = ch.DEX.ToString();
            textBox16.Text = ch.LUK.ToString();
            textBox17.Text = ch.ASPD.ToString();
        }
    }
}
