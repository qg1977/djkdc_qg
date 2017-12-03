namespace djkdc_qg.systemall
{
    partial class pass_update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_old_pass_label = new djkdc_qg.a_qg_trol.qg_label();
            this.text_old_pass = new djkdc_qg.a_qg_trol.qg_text_pass();
            this.qg_label2 = new djkdc_qg.a_qg_trol.qg_label();
            this.text_old_name = new djkdc_qg.a_qg_trol.qg_read_text();
            this.qg_label1 = new djkdc_qg.a_qg_trol.qg_label();
            this.qg_bt_label1 = new djkdc_qg.a_qg_trol.qg_bt_label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.text_new_pass_2_label = new djkdc_qg.a_qg_trol.qg_label();
            this.text_new_pass_label = new djkdc_qg.a_qg_trol.qg_label();
            this.text_new_name_label = new djkdc_qg.a_qg_trol.qg_label();
            this.text_new_name = new djkdc_qg.a_qg_trol.qg_text();
            this.text_new_pass_2 = new djkdc_qg.a_qg_trol.qg_text_pass();
            this.qg_label5 = new djkdc_qg.a_qg_trol.qg_label();
            this.text_new_pass = new djkdc_qg.a_qg_trol.qg_text_pass();
            this.qg_label3 = new djkdc_qg.a_qg_trol.qg_label();
            this.qg_label4 = new djkdc_qg.a_qg_trol.qg_label();
            this.qg_button1 = new djkdc_qg.a_qg_trol.qg_button();
            this.qg_button_quit1 = new djkdc_qg.a_qg_trol.qg_button_quit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.text_old_pass_label);
            this.panel1.Controls.Add(this.text_old_pass);
            this.panel1.Controls.Add(this.qg_label2);
            this.panel1.Controls.Add(this.text_old_name);
            this.panel1.Controls.Add(this.qg_label1);
            this.panel1.Location = new System.Drawing.Point(22, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 63);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // text_old_pass_label
            // 
            this.text_old_pass_label.AutoSize = true;
            this.text_old_pass_label.BackColor = System.Drawing.Color.Transparent;
            this.text_old_pass_label.ForeColor = System.Drawing.Color.Red;
            this.text_old_pass_label.Location = new System.Drawing.Point(321, 8);
            this.text_old_pass_label.Name = "text_old_pass_label";
            this.text_old_pass_label.Size = new System.Drawing.Size(89, 12);
            this.text_old_pass_label.TabIndex = 90;
            this.text_old_pass_label.Text = "密码格式不正确";
            this.text_old_pass_label.Visible = false;
            // 
            // text_old_pass
            // 
            this.text_old_pass.Location = new System.Drawing.Point(323, 23);
            this.text_old_pass.Name = "text_old_pass";
            this.text_old_pass.PasswordChar = '*';
            this.text_old_pass.Size = new System.Drawing.Size(167, 21);
            this.text_old_pass.TabIndex = 1;
            this.text_old_pass.TextChanged += new System.EventHandler(this.text_old_pass_TextChanged);
            this.text_old_pass.Validating += new System.ComponentModel.CancelEventHandler(this.text_old_pass_Validating);
            // 
            // qg_label2
            // 
            this.qg_label2.AutoSize = true;
            this.qg_label2.BackColor = System.Drawing.Color.Transparent;
            this.qg_label2.Location = new System.Drawing.Point(228, 28);
            this.qg_label2.Name = "qg_label2";
            this.qg_label2.Size = new System.Drawing.Size(89, 12);
            this.qg_label2.TabIndex = 3;
            this.qg_label2.Text = "当前帐号密码：";
            // 
            // text_old_name
            // 
            this.text_old_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(170)))));
            this.text_old_name.DataDicEntry = null;
            this.text_old_name.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.text_old_name.Location = new System.Drawing.Point(73, 23);
            this.text_old_name.Name = "text_old_name";
            this.text_old_name.NeedChineseNumerals = false;
            this.text_old_name.Precision = 2;
            this.text_old_name.ReadOnly = true;
            this.text_old_name.Size = new System.Drawing.Size(137, 21);
            this.text_old_name.TabIndex = 999;
            this.text_old_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // qg_label1
            // 
            this.qg_label1.AutoSize = true;
            this.qg_label1.BackColor = System.Drawing.Color.Transparent;
            this.qg_label1.Location = new System.Drawing.Point(13, 28);
            this.qg_label1.Name = "qg_label1";
            this.qg_label1.Size = new System.Drawing.Size(65, 12);
            this.qg_label1.TabIndex = 1;
            this.qg_label1.Text = "当前帐号：";
            // 
            // qg_bt_label1
            // 
            this.qg_bt_label1.AutoSize = true;
            this.qg_bt_label1.BackColor = System.Drawing.Color.Transparent;
            this.qg_bt_label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_bt_label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.qg_bt_label1.Location = new System.Drawing.Point(168, 5);
            this.qg_bt_label1.Name = "qg_bt_label1";
            this.qg_bt_label1.Size = new System.Drawing.Size(264, 27);
            this.qg_bt_label1.TabIndex = 0;
            this.qg_bt_label1.Text = "修改登录帐号及密码";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.text_new_pass_2_label);
            this.panel2.Controls.Add(this.text_new_pass_label);
            this.panel2.Controls.Add(this.text_new_name_label);
            this.panel2.Controls.Add(this.text_new_name);
            this.panel2.Controls.Add(this.text_new_pass_2);
            this.panel2.Controls.Add(this.qg_label5);
            this.panel2.Controls.Add(this.text_new_pass);
            this.panel2.Controls.Add(this.qg_label3);
            this.panel2.Controls.Add(this.qg_label4);
            this.panel2.Location = new System.Drawing.Point(22, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 187);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // text_new_pass_2_label
            // 
            this.text_new_pass_2_label.AutoSize = true;
            this.text_new_pass_2_label.BackColor = System.Drawing.Color.Transparent;
            this.text_new_pass_2_label.ForeColor = System.Drawing.Color.Red;
            this.text_new_pass_2_label.Location = new System.Drawing.Point(168, 118);
            this.text_new_pass_2_label.Name = "text_new_pass_2_label";
            this.text_new_pass_2_label.Size = new System.Drawing.Size(113, 12);
            this.text_new_pass_2_label.TabIndex = 93;
            this.text_new_pass_2_label.Text = "两次输入密码不一致";
            this.text_new_pass_2_label.Visible = false;
            // 
            // text_new_pass_label
            // 
            this.text_new_pass_label.AutoSize = true;
            this.text_new_pass_label.BackColor = System.Drawing.Color.Transparent;
            this.text_new_pass_label.ForeColor = System.Drawing.Color.Red;
            this.text_new_pass_label.Location = new System.Drawing.Point(168, 70);
            this.text_new_pass_label.Name = "text_new_pass_label";
            this.text_new_pass_label.Size = new System.Drawing.Size(89, 12);
            this.text_new_pass_label.TabIndex = 92;
            this.text_new_pass_label.Text = "密码格式不正确";
            this.text_new_pass_label.Visible = false;
            // 
            // text_new_name_label
            // 
            this.text_new_name_label.AutoSize = true;
            this.text_new_name_label.BackColor = System.Drawing.Color.Transparent;
            this.text_new_name_label.ForeColor = System.Drawing.Color.Red;
            this.text_new_name_label.Location = new System.Drawing.Point(170, 13);
            this.text_new_name_label.Name = "text_new_name_label";
            this.text_new_name_label.Size = new System.Drawing.Size(89, 12);
            this.text_new_name_label.TabIndex = 91;
            this.text_new_name_label.Text = "帐号格式不正确";
            this.text_new_name_label.Visible = false;
            // 
            // text_new_name
            // 
            this.text_new_name.Location = new System.Drawing.Point(172, 28);
            this.text_new_name.Name = "text_new_name";
            this.text_new_name.Size = new System.Drawing.Size(192, 21);
            this.text_new_name.TabIndex = 888;
            this.text_new_name.TextChanged += new System.EventHandler(this.text_new_name_TextChanged);
            this.text_new_name.Validating += new System.ComponentModel.CancelEventHandler(this.text_new_name_Validating);
            // 
            // text_new_pass_2
            // 
            this.text_new_pass_2.Location = new System.Drawing.Point(170, 133);
            this.text_new_pass_2.Name = "text_new_pass_2";
            this.text_new_pass_2.PasswordChar = '*';
            this.text_new_pass_2.Size = new System.Drawing.Size(194, 21);
            this.text_new_pass_2.TabIndex = 4;
            this.text_new_pass_2.Validating += new System.ComponentModel.CancelEventHandler(this.text_new_pass_2_Validating);
            // 
            // qg_label5
            // 
            this.qg_label5.AutoSize = true;
            this.qg_label5.BackColor = System.Drawing.Color.Transparent;
            this.qg_label5.Location = new System.Drawing.Point(11, 137);
            this.qg_label5.Name = "qg_label5";
            this.qg_label5.Size = new System.Drawing.Size(161, 12);
            this.qg_label5.TabIndex = 5;
            this.qg_label5.Text = "再次输入您的新的帐号密码：";
            // 
            // text_new_pass
            // 
            this.text_new_pass.Location = new System.Drawing.Point(170, 85);
            this.text_new_pass.Name = "text_new_pass";
            this.text_new_pass.PasswordChar = '*';
            this.text_new_pass.Size = new System.Drawing.Size(194, 21);
            this.text_new_pass.TabIndex = 3;
            this.text_new_pass.TextChanged += new System.EventHandler(this.text_new_pass_TextChanged);
            this.text_new_pass.Validating += new System.ComponentModel.CancelEventHandler(this.text_new_pass_Validating);
            // 
            // qg_label3
            // 
            this.qg_label3.AutoSize = true;
            this.qg_label3.BackColor = System.Drawing.Color.Transparent;
            this.qg_label3.Location = new System.Drawing.Point(50, 88);
            this.qg_label3.Name = "qg_label3";
            this.qg_label3.Size = new System.Drawing.Size(89, 12);
            this.qg_label3.TabIndex = 3;
            this.qg_label3.Text = "新的帐号密码：";
            // 
            // qg_label4
            // 
            this.qg_label4.AutoSize = true;
            this.qg_label4.BackColor = System.Drawing.Color.Transparent;
            this.qg_label4.Location = new System.Drawing.Point(71, 31);
            this.qg_label4.Name = "qg_label4";
            this.qg_label4.Size = new System.Drawing.Size(77, 12);
            this.qg_label4.TabIndex = 1;
            this.qg_label4.Text = "新的帐号名：";
            // 
            // qg_button1
            // 
            this.qg_button1.Location = new System.Drawing.Point(150, 369);
            this.qg_button1.Name = "qg_button1";
            this.qg_button1.Size = new System.Drawing.Size(75, 23);
            this.qg_button1.TabIndex = 5;
            this.qg_button1.Text = "确  定";
            this.qg_button1.UseVisualStyleBackColor = false;
            this.qg_button1.Click += new System.EventHandler(this.qg_button1_Click);
            // 
            // qg_button_quit1
            // 
            this.qg_button_quit1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.qg_button_quit1.Location = new System.Drawing.Point(376, 369);
            this.qg_button_quit1.Name = "qg_button_quit1";
            this.qg_button_quit1.Size = new System.Drawing.Size(75, 23);
            this.qg_button_quit1.TabIndex = 6;
            this.qg_button_quit1.Text = "退  出";
            this.qg_button_quit1.UseVisualStyleBackColor = true;
            // 
            // pass_update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 420);
            this.Controls.Add(this.qg_button_quit1);
            this.Controls.Add(this.qg_button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.qg_bt_label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "pass_update";
            this.Text = "修改登录帐号及密码";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private a_qg_trol.qg_bt_label qg_bt_label1;
        private a_qg_trol.qg_label qg_label1;
        private System.Windows.Forms.Panel panel1;
        private a_qg_trol.qg_label qg_label2;
        private a_qg_trol.qg_read_text text_old_name;
        private a_qg_trol.qg_text_pass text_old_pass;
        private System.Windows.Forms.Panel panel2;
        private a_qg_trol.qg_text text_new_name;
        private a_qg_trol.qg_text_pass text_new_pass_2;
        private a_qg_trol.qg_label qg_label5;
        private a_qg_trol.qg_text_pass text_new_pass;
        private a_qg_trol.qg_label qg_label3;
        private a_qg_trol.qg_label qg_label4;
        private a_qg_trol.qg_button qg_button1;
        private a_qg_trol.qg_button_quit qg_button_quit1;
        private a_qg_trol.qg_label text_old_pass_label;
        private a_qg_trol.qg_label text_new_pass_2_label;
        private a_qg_trol.qg_label text_new_pass_label;
        private a_qg_trol.qg_label text_new_name_label;
    }
}