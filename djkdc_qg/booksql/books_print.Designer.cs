namespace djkdc_qg.booksql
{
    partial class books_print
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
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.qg_button1 = new djkdc_qg.a_qg_trol.qg_button();
            this.FileMenuItem_Print = new djkdc_qg.a_qg_trol.qg_button();
            this.FileMenuItem_PrintView = new djkdc_qg.a_qg_trol.qg_button();
            this.FileMenuItem_PageSet = new djkdc_qg.a_qg_trol.qg_button();
            this.FileMenuItem_PrintSet = new djkdc_qg.a_qg_trol.qg_button();
            this.textBox = new djkdc_qg.a_qg_trol.qg_text();
            this.qg_button2 = new djkdc_qg.a_qg_trol.qg_button();
            this.SuspendLayout();
            // 
            // qg_button1
            // 
            this.qg_button1.Location = new System.Drawing.Point(614, 457);
            this.qg_button1.Name = "qg_button1";
            this.qg_button1.Size = new System.Drawing.Size(95, 23);
            this.qg_button1.TabIndex = 5;
            this.qg_button1.Text = "导入打印数据";
            this.qg_button1.UseVisualStyleBackColor = false;
            this.qg_button1.Click += new System.EventHandler(this.qg_button1_Click);
            // 
            // FileMenuItem_Print
            // 
            this.FileMenuItem_Print.Location = new System.Drawing.Point(477, 457);
            this.FileMenuItem_Print.Name = "FileMenuItem_Print";
            this.FileMenuItem_Print.Size = new System.Drawing.Size(75, 23);
            this.FileMenuItem_Print.TabIndex = 4;
            this.FileMenuItem_Print.Text = "打印";
            this.FileMenuItem_Print.UseVisualStyleBackColor = false;
            this.FileMenuItem_Print.Click += new System.EventHandler(this.FileMenuItem_Print_Click);
            // 
            // FileMenuItem_PrintView
            // 
            this.FileMenuItem_PrintView.Location = new System.Drawing.Point(320, 457);
            this.FileMenuItem_PrintView.Name = "FileMenuItem_PrintView";
            this.FileMenuItem_PrintView.Size = new System.Drawing.Size(75, 23);
            this.FileMenuItem_PrintView.TabIndex = 3;
            this.FileMenuItem_PrintView.Text = "打印预览";
            this.FileMenuItem_PrintView.UseVisualStyleBackColor = false;
            this.FileMenuItem_PrintView.Click += new System.EventHandler(this.FileMenuItem_PrintView_Click);
            // 
            // FileMenuItem_PageSet
            // 
            this.FileMenuItem_PageSet.Location = new System.Drawing.Point(193, 457);
            this.FileMenuItem_PageSet.Name = "FileMenuItem_PageSet";
            this.FileMenuItem_PageSet.Size = new System.Drawing.Size(75, 23);
            this.FileMenuItem_PageSet.TabIndex = 2;
            this.FileMenuItem_PageSet.Text = "页面设置";
            this.FileMenuItem_PageSet.UseVisualStyleBackColor = false;
            this.FileMenuItem_PageSet.Click += new System.EventHandler(this.FileMenuItem_PageSet_Click);
            // 
            // FileMenuItem_PrintSet
            // 
            this.FileMenuItem_PrintSet.Location = new System.Drawing.Point(61, 458);
            this.FileMenuItem_PrintSet.Name = "FileMenuItem_PrintSet";
            this.FileMenuItem_PrintSet.Size = new System.Drawing.Size(75, 23);
            this.FileMenuItem_PrintSet.TabIndex = 1;
            this.FileMenuItem_PrintSet.Text = "打印设置";
            this.FileMenuItem_PrintSet.UseVisualStyleBackColor = false;
            this.FileMenuItem_PrintSet.Click += new System.EventHandler(this.FileMenuItem_PrintSet_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(26, 36);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(986, 375);
            this.textBox.TabIndex = 0;
            // 
            // qg_button2
            // 
            this.qg_button2.Location = new System.Drawing.Point(762, 456);
            this.qg_button2.Name = "qg_button2";
            this.qg_button2.Size = new System.Drawing.Size(137, 23);
            this.qg_button2.TabIndex = 6;
            this.qg_button2.Text = "textbox分行读取";
            this.qg_button2.UseVisualStyleBackColor = false;
            this.qg_button2.Click += new System.EventHandler(this.qg_button2_Click);
            // 
            // books_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 602);
            this.Controls.Add(this.qg_button2);
            this.Controls.Add(this.qg_button1);
            this.Controls.Add(this.FileMenuItem_Print);
            this.Controls.Add(this.FileMenuItem_PrintView);
            this.Controls.Add(this.FileMenuItem_PageSet);
            this.Controls.Add(this.FileMenuItem_PrintSet);
            this.Controls.Add(this.textBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "books_print";
            this.Text = "books_print";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private a_qg_trol.qg_text textBox;
        private System.Drawing.Printing.PrintDocument printDocument;
        private a_qg_trol.qg_button FileMenuItem_PrintSet;
        private a_qg_trol.qg_button FileMenuItem_PageSet;
        private a_qg_trol.qg_button FileMenuItem_PrintView;
        private a_qg_trol.qg_button FileMenuItem_Print;
        private a_qg_trol.qg_button qg_button1;
        private a_qg_trol.qg_button qg_button2;
    }
}