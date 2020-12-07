using lib;
namespace main
{
    partial class Login_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1_UserName
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
            // 
            // textBox1_UserName
            // 
            this.textBox1.Location = new System.Drawing.Point( 8, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 15);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2_Password
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 5, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 30, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // textBox2_Password
            // 
            this.textBox2.Location = new System.Drawing.Point( 8, 80);
            this.textBox2.Name = "textBox1";
            this.textBox2.Size = new System.Drawing.Size(180, 15);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3_Notification
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 5, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 30, 15);
            this.label3.TabIndex = 1;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Arial", 8F);
            this.label3.Text = "UserName or Password incorrect";
            this.label3.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 10, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button2.Location = new System.Drawing.Point( 110, 150);
            this.button2.Name = "button1";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Sign In";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            //
            // Login Form
            //
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Activated += new System.EventHandler(this.Login_Form_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_Form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_Form_FormClosed);
            this.TopMost = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Text = "Login_Form";
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}