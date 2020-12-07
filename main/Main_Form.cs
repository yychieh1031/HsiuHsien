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
        public Account act = new Account();
        public static Character ch = new Character();
        BattleReport btrpt = new BattleReport(){
            Ch_Dtl = ch,
            Mns_Dtl = new List<Monster>(),
            message = new List<string>()
        };

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, System.EventArgs e)
        {
            Login_Form login = new Login_Form(this);
            login.Owner = this;
            login.Show();
        }
        
        //
        // Attack
        //
        private void button1_Click(object sender, System.EventArgs e)
        {
            Monster mns = test.Mns_testValue();
            List<Monster> MnsList = new List<Monster>();
            MnsList.Add(mns);
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

        //
        // Training
        //
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
            act.Act_Mon = (Convert.ToInt32(act.Act_Mon)+1).ToString();
        }

        //
        // Create
        //
        private void button10_Click(object sender, System.EventArgs e)
        {
            Ch_Sts.create(ch, ref act);
            #region textbox/button disable
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            #endregion
            ch = Ch_Sts.get(act.Act_Ch_No);
            btrpt.Ch_Dtl = ch;
            UIDisplay(ch);
            button10.Enabled = false;
        }
        public void reload(){
            if(!String.IsNullOrEmpty(act.Act_Ch_No)){
                button10.Enabled = false;
            }
            if(String.IsNullOrEmpty(act.Act_Ch_No)){
                #region textbox/button disable
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox13.Enabled = false;
                textBox14.Enabled = false;
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                textBox17.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                #endregion
                output.AppendText("Please Insert Character Name..");
                output.AppendText(Environment.NewLine);
            }else{
                ch = Ch_Sts.get(act.Act_Ch_No);
                btrpt.Ch_Dtl = ch;
            }
            UIDisplay(ch);
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
