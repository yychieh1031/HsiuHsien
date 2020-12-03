﻿using System;
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
        
        public static Character ch = Ch_Sts.get();
        BattleReport btrpt = new BattleReport(){
            Ch_Dtl = ch,
            Mns_Dtl = new List<Monster>(),
            message = new List<string>()
        };
        public Main_Form()
        {
            InitializeComponent();
            UIDisplay(ch);
        }
        public void refresh(){
            UIDisplay(ch);
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            //Character ch = Ch_Sts.get();
            Monster mns = test.Mns_testValue();
            List<Monster> MnsList = new List<Monster>();
            MnsList.Add(mns);
            // BattleReport btrpt = new BattleReport(){
            //     Ch_Dtl = ch,
            //     Mns_Dtl = MnsList,
            //     message = new List<string>()
            // };
            //string result = Battle.StartFight(ch, mns);
            btrpt.Mns_Dtl = MnsList; // 12.02
            string result = Battle.StartFight(ref btrpt);
            foreach(string meg in btrpt.message){
                output.AppendText(meg);
                Thread.Sleep(400);
                output.AppendText(Environment.NewLine);
            }
            output.AppendText(result);
            output.AppendText(Environment.NewLine);
            UIDisplay(btrpt.Ch_Dtl);
        }
        private void button4_Click(object sender, System.EventArgs e)
        {
            Random rnd = new Random();
            int trainingExp = 0;
            for(int time = 1; time <= 10; time++){
                trainingExp += rnd.Next(Convert.ToInt32(ch.Lv)*10);
                Thread.Sleep(1000);
                output.AppendText(String.Format("Training...{0}%",time*10));
                output.AppendText(Environment.NewLine);
            }
            output.AppendText("Training Done");
            output.AppendText(Environment.NewLine);
            output.AppendText(String.Format("You get {0} EXP", trainingExp));
            output.AppendText(Environment.NewLine);
            btrpt.Ch_Dtl.EXP = (Convert.ToInt32(btrpt.Ch_Dtl.EXP) + trainingExp).ToString();
            Ch_Sts.update(btrpt.Ch_Dtl);
            UIDisplay(btrpt.Ch_Dtl);
        }
        private void button5_Click(object sender, System.EventArgs e)
        {
            Login_Form Login = new Login_Form();
            Login.Show();
        }

        private void UIDisplay(Character chDis)
        {
            textBox1.Text = chDis.Ch_Nm;
            textBox2.Text = chDis.Lv;
            textBox3.Text = chDis.EXP;
            textBox4.Text = chDis.HP;
            textBox5.Text = chDis.MP;
            textBox6.Text = chDis.ATK.ToString();
            textBox7.Text = chDis.MATK.ToString();
            textBox8.Text = chDis.Critical.ToString();
            textBox9.Text = chDis.DEF.ToString();
            textBox10.Text = chDis.MDEF.ToString();
            textBox11.Text = chDis.STR.ToString();
            textBox12.Text = chDis.INT.ToString();
            textBox13.Text = chDis.VIT.ToString();
            textBox14.Text = chDis.AGI.ToString();
            textBox15.Text = chDis.DEX.ToString();
            textBox16.Text = chDis.LUK.ToString();
            textBox17.Text = chDis.ASPD.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.Ch_Nm = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.Lv = textBox2.Text;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.EXP = textBox3.Text;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.HP = textBox4.Text;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.MP = textBox5.Text;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.ATK = Convert.ToInt32(textBox6.Text);
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.MATK = Convert.ToInt32(textBox7.Text);
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.Critical = Convert.ToInt32(textBox8.Text);
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.DEF = Convert.ToInt32(textBox9.Text);
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.MDEF = Convert.ToInt32(textBox10.Text);
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.STR = Convert.ToInt32(textBox11.Text);
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.INT = Convert.ToInt32(textBox12.Text);
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.VIT = Convert.ToInt32(textBox13.Text);
        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.AGI = Convert.ToInt32(textBox14.Text);
        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.DEX = Convert.ToInt32(textBox15.Text);
        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.LUK = Convert.ToInt32(textBox16.Text);
        }
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            btrpt.Ch_Dtl.ASPD = Convert.ToInt32(textBox17.Text);
        }
    }
}
