namespace djkdc_qg.systemall
{
    partial class first_view
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
            this.qg_label1 = new djkdc_qg.a_qg_trol.qg_label();
            this.qg_label3 = new djkdc_qg.a_qg_trol.qg_label();
            this.qg_label2 = new djkdc_qg.a_qg_trol.qg_label();
            this.qg_check1 = new djkdc_qg.a_qg_trol.qg_check();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.qg_label1);
            this.panel1.Controls.Add(this.qg_label3);
            this.panel1.Controls.Add(this.qg_label2);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 367);
            this.panel1.TabIndex = 3;
            // 
            // qg_label1
            // 
            this.qg_label1.BackColor = System.Drawing.Color.Transparent;
            this.qg_label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_label1.Location = new System.Drawing.Point(3, 18);
            this.qg_label1.Name = "qg_label1";
            this.qg_label1.Size = new System.Drawing.Size(327, 57);
            this.qg_label1.TabIndex = 0;
            this.qg_label1.Text = "qg_label1";
            // 
            // qg_label3
            // 
            this.qg_label3.BackColor = System.Drawing.Color.Transparent;
            this.qg_label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_label3.Location = new System.Drawing.Point(3, 133);
            this.qg_label3.Name = "qg_label3";
            this.qg_label3.Size = new System.Drawing.Size(386, 213);
            this.qg_label3.TabIndex = 2;
            this.qg_label3.Text = "qg_label3";
            // 
            // qg_label2
            // 
            this.qg_label2.AutoSize = true;
            this.qg_label2.BackColor = System.Drawing.Color.Transparent;
            this.qg_label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.qg_label2.Location = new System.Drawing.Point(108, 86);
            this.qg_label2.Name = "qg_label2";
            this.qg_label2.Size = new System.Drawing.Size(147, 27);
            this.qg_label2.TabIndex = 1;
            this.qg_label2.Text = "qg_label2";
            // 
            // qg_check1
            // 
            this.qg_check1.AutoSize = true;
            this.qg_check1.BackColor = System.Drawing.Color.Transparent;
            this.qg_check1.Location = new System.Drawing.Point(18, 395);
            this.qg_check1.Name = "qg_check1";
            this.qg_check1.Size = new System.Drawing.Size(96, 16);
            this.qg_check1.TabIndex = 4;
            this.qg_check1.Text = "关闭提示文字";
            this.qg_check1.UseVisualStyleBackColor = false;
            this.qg_check1.CheckedChanged += new System.EventHandler(this.qg_check1_CheckedChanged);
            this.qg_check1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.qg_check1_MouseClick);
            // 
            // first_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 423);
            this.Controls.Add(this.qg_check1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "first_view";
            this.Text = "修改提示设置";
            this.Load += new System.EventHandler(this.first_view_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private a_qg_trol.qg_label qg_label1;
        private a_qg_trol.qg_label qg_label2;
        private a_qg_trol.qg_label qg_label3;
        private System.Windows.Forms.Panel panel1;
        private a_qg_trol.qg_check qg_check1;
    }
}