namespace djkdc_qg.booksql
{
    partial class booksall_x_all
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
            this.qg_button1 = new djkdc_qg.a_qg_trol.qg_button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.qg_button2 = new djkdc_qg.a_qg_trol.qg_button();
            this.qg_bt_label1 = new djkdc_qg.a_qg_trol.qg_bt_label();
            this.qg_button3 = new djkdc_qg.a_qg_trol.qg_button();
            this.qg_button4 = new djkdc_qg.a_qg_trol.qg_button();
            this.SuspendLayout();
            // 
            // qg_button1
            // 
            this.qg_button1.Location = new System.Drawing.Point(48, 35);
            this.qg_button1.Name = "qg_button1";
            this.qg_button1.Size = new System.Drawing.Size(75, 23);
            this.qg_button1.TabIndex = 0;
            this.qg_button1.Text = "数据表";
            this.qg_button1.UseVisualStyleBackColor = false;
            this.qg_button1.Click += new System.EventHandler(this.qg_button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 569);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // qg_button2
            // 
            this.qg_button2.Location = new System.Drawing.Point(148, 35);
            this.qg_button2.Name = "qg_button2";
            this.qg_button2.Size = new System.Drawing.Size(75, 23);
            this.qg_button2.TabIndex = 2;
            this.qg_button2.Text = "柱状图表";
            this.qg_button2.UseVisualStyleBackColor = false;
            this.qg_button2.Click += new System.EventHandler(this.qg_button2_Click);
            // 
            // qg_bt_label1
            // 
            this.qg_bt_label1.AutoSize = true;
            this.qg_bt_label1.BackColor = System.Drawing.Color.Transparent;
            this.qg_bt_label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_bt_label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.qg_bt_label1.Location = new System.Drawing.Point(422, 5);
            this.qg_bt_label1.Name = "qg_bt_label1";
            this.qg_bt_label1.Size = new System.Drawing.Size(236, 27);
            this.qg_bt_label1.TabIndex = 4;
            this.qg_bt_label1.Text = "按出版社统计信息";
            // 
            // qg_button3
            // 
            this.qg_button3.Location = new System.Drawing.Point(247, 35);
            this.qg_button3.Name = "qg_button3";
            this.qg_button3.Size = new System.Drawing.Size(75, 23);
            this.qg_button3.TabIndex = 5;
            this.qg_button3.Text = "百分比柱图";
            this.qg_button3.UseVisualStyleBackColor = false;
            this.qg_button3.Click += new System.EventHandler(this.qg_button3_Click);
            // 
            // qg_button4
            // 
            this.qg_button4.Location = new System.Drawing.Point(352, 35);
            this.qg_button4.Name = "qg_button4";
            this.qg_button4.Size = new System.Drawing.Size(75, 23);
            this.qg_button4.TabIndex = 6;
            this.qg_button4.Text = "退  出";
            this.qg_button4.UseVisualStyleBackColor = false;
            this.qg_button4.Click += new System.EventHandler(this.qg_button4_Click);
            // 
            // booksall_x_all
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 677);
            this.Controls.Add(this.qg_button4);
            this.Controls.Add(this.qg_button3);
            this.Controls.Add(this.qg_bt_label1);
            this.Controls.Add(this.qg_button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.qg_button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "booksall_x_all";
            this.Text = "booksall_x_all";
            this.Resize += new System.EventHandler(this.booksall_x_all_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private a_qg_trol.qg_button qg_button1;
        private System.Windows.Forms.Panel panel1;
        private a_qg_trol.qg_button qg_button2;
        private a_qg_trol.qg_bt_label qg_bt_label1;
        private a_qg_trol.qg_button qg_button3;
        private a_qg_trol.qg_button qg_button4;
    }
}