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
            Acc_Dtl = new Account(),
            Ch_Dtl = ch,
            Mns_Dtl = new List<Monster>(),
            message = new List<string>(),
            room = new Room()
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
            // Monster mns = test.Mns_testValue();
            // List<Monster> MnsList = new List<Monster>();
            // MnsList.Add(mns);
            // btrpt.Mns_Dtl = MnsList;
            btrpt = Mns_Sts.get(btrpt);
            string result = Battle.StartFight(ref btrpt);
            foreach(string meg in btrpt.message){
                output.AppendText(meg);
                Thread.Sleep(400);
                output.AppendText(Environment.NewLine);
            }
            output.AppendText(result);
            output.AppendText(Environment.NewLine);
            UIDisplay(btrpt);
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
            UIDisplay(btrpt);
        }

        //
        // Heal
        //
        private void button5_Click(object sender, System.EventArgs e)
        {
            Random rnd = new Random();
            int healHp = 0;
            for(int time = 2; time <= 10; time+=2){
                healHp += rnd.Next(30)+10;
                Thread.Sleep(1000);
                output.AppendText(String.Format("Healing...{0}%",time*10));
                output.AppendText(Environment.NewLine);
            }
            btrpt.Ch_Dtl.HP = (Convert.ToInt32(btrpt.Ch_Dtl.HP)+healHp) > 100 ? "100" : (Convert.ToInt32(btrpt.Ch_Dtl.HP)+healHp).ToString();
            output.AppendText("Successed Heal");
            output.AppendText(Environment.NewLine);
            UIDisplay(btrpt);
        }

        //
        // Create Character
        //
        private void button10_Click(object sender, System.EventArgs e)
        {
            // Create Character option
            if(String.IsNullOrEmpty(act.Act_Ch_No))
            {
                Ch_Sts.create(ch, ref act);
                #region textbox/button enable
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
                UIDisplay(btrpt);
                button10.Text = "Logout";
                // Initial Room set
                Ro_Rou.post(btrpt);
                btrpt.room = Ro_Sts.get(btrpt);
                output.AppendText("You are in " + btrpt.room.Ro_Nm);
                output.AppendText(Environment.NewLine);
            }else{// Logout option
                btrpt.Ch_Dtl.Ch_Nm = "";
                Login_Form login = new Login_Form(this);
                login.Owner = this;
                login.Show();
            }
        }
        public void reload(){
            if(String.IsNullOrEmpty(act.Act_Ch_No)){
                button10.Text = "Create";
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
                button10.Text = "Logout";
                ch = Ch_Sts.get(act.Act_Ch_No);
                btrpt.Ch_Dtl = ch;
                btrpt.Acc_Dtl = act;
                
                btrpt.room = Ro_Sts.get(btrpt);
                output.AppendText("You are in " + btrpt.room.Ro_Nm);
                output.AppendText(Environment.NewLine);
            }
            UIDisplay(btrpt);
        }

        private void UIDisplay(BattleReport btrptDis)
        {
            #region Character Detail
            textBox1.Text = btrptDis.Ch_Dtl.Ch_Nm;
            textBox2.Text = btrptDis.Ch_Dtl.Lv;
            textBox3.Text = btrptDis.Ch_Dtl.EXP;
            textBox4.Text = btrptDis.Ch_Dtl.HP;
            textBox5.Text = btrptDis.Ch_Dtl.MP;
            textBox6.Text = btrptDis.Ch_Dtl.ATK.ToString();
            textBox7.Text = btrptDis.Ch_Dtl.MATK.ToString();
            textBox8.Text = btrptDis.Ch_Dtl.Critical.ToString();
            textBox9.Text = btrptDis.Ch_Dtl.DEF.ToString();
            textBox10.Text = btrptDis.Ch_Dtl.MDEF.ToString();
            textBox11.Text = btrptDis.Ch_Dtl.STR.ToString();
            textBox12.Text = btrptDis.Ch_Dtl.INT.ToString();
            textBox13.Text = btrptDis.Ch_Dtl.VIT.ToString();
            textBox14.Text = btrptDis.Ch_Dtl.AGI.ToString();
            textBox15.Text = btrptDis.Ch_Dtl.DEX.ToString();
            textBox16.Text = btrptDis.Ch_Dtl.LUK.ToString();
            textBox17.Text = btrptDis.Ch_Dtl.ASPD.ToString();
            #endregion
            textBox18.Text = btrptDis.Acc_Dtl.Act_Mon;
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
