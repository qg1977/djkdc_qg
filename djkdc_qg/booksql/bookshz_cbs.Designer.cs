namespace djkdc_qg.booksql
{
    partial class bookshz_cbs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.qg_button_quit1 = new djkdc_qg.a_qg_trol.qg_button_quit();
            this.qg_dy1 = new djkdc_qg.a_qg_trol.qg_dy();
            this.qg_grid_tree1 = new djkdc_qg.a_qg_trol.qg_grid_tree();
            this.qg_label_visible1 = new djkdc_qg.a_qg_trol.qg_label_visible();
            this.qg_label_visible2 = new djkdc_qg.a_qg_trol.qg_label_visible();
            ((System.ComponentModel.ISupportInitialize)(this.qg_grid_tree1)).BeginInit();
            this.SuspendLayout();
            // 
            // qg_button_quit1
            // 
            this.qg_button_quit1.Location = new System.Drawing.Point(680, 379);
            this.qg_button_quit1.Name = "qg_button_quit1";
            this.qg_button_quit1.Size = new System.Drawing.Size(75, 23);
            this.qg_button_quit1.TabIndex = 5;
            this.qg_button_quit1.Text = "qg_button_quit1";
            this.qg_button_quit1.UseVisualStyleBackColor = true;
            this.qg_button_quit1.Visible = false;
            // 
            // qg_dy1
            // 
            this.qg_dy1.dy_month = null;
            this.qg_dy1.dy_title = null;
            this.qg_dy1.Location = new System.Drawing.Point(281, 379);
            this.qg_dy1.Name = "qg_dy1";
            this.qg_dy1.Size = new System.Drawing.Size(75, 23);
            this.qg_dy1.TabIndex = 2;
            this.qg_dy1.Text = "打印预览";
            this.qg_dy1.UseVisualStyleBackColor = true;
            // 
            // qg_grid_tree1
            // 
            this.qg_grid_tree1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.qg_grid_tree1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.qg_grid_tree1.auto_jytt = true;
            this.qg_grid_tree1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.qg_grid_tree1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.qg_grid_tree1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.qg_grid_tree1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qg_grid_tree1.Location = new System.Drawing.Point(9, 27);
            this.qg_grid_tree1.Name = "qg_grid_tree1";
            this.qg_grid_tree1.RowHeadersVisible = false;
            this.qg_grid_tree1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.qg_grid_tree1.RowTemplate.Height = 30;
            this.qg_grid_tree1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qg_grid_tree1.Size = new System.Drawing.Size(969, 279);
            this.qg_grid_tree1.TabIndex = 1;
            this.qg_grid_tree1.xz_jytt = false;
            // 
            // qg_label_visible1
            // 
            this.qg_label_visible1.AutoSize = true;
            this.qg_label_visible1.BackColor = System.Drawing.Color.Transparent;
            this.qg_label_visible1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_label_visible1.ForeColor = System.Drawing.Color.Red;
            this.qg_label_visible1.Location = new System.Drawing.Point(12, 9);
            this.qg_label_visible1.Name = "qg_label_visible1";
            this.qg_label_visible1.Size = new System.Drawing.Size(331, 12);
            this.qg_label_visible1.TabIndex = 6;
            this.qg_label_visible1.Text = "双击出版社名称(比如“北京工业大学”)可显示详细记录";
            // 
            // qg_label_visible2
            // 
            this.qg_label_visible2.AutoSize = true;
            this.qg_label_visible2.BackColor = System.Drawing.Color.Transparent;
            this.qg_label_visible2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qg_label_visible2.Location = new System.Drawing.Point(24, 364);
            this.qg_label_visible2.Name = "qg_label_visible2";
            this.qg_label_visible2.Size = new System.Drawing.Size(642, 12);
            this.qg_label_visible2.TabIndex = 7;
            this.qg_label_visible2.Text = "如果需要导出或打印表格中的数据，就点“打印预览”，然后选择是“横排“还是”竖排“，导出时会自动排版";
            // 
            // bookshz_cbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 421);
            this.Controls.Add(this.qg_label_visible2);
            this.Controls.Add(this.qg_label_visible1);
            this.Controls.Add(this.qg_button_quit1);
            this.Controls.Add(this.qg_dy1);
            this.Controls.Add(this.qg_grid_tree1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "bookshz_cbs";
            this.Text = "按出版社统计信息";
            this.Load += new System.EventHandler(this.bookshz_cbs_Load);
            this.Shown += new System.EventHandler(this.bookshz_cbs_Shown);
            this.Resize += new System.EventHandler(this.bookshz_cbs_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.qg_grid_tree1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private a_qg_trol.qg_grid_tree qg_grid_tree1;
        private a_qg_trol.qg_dy qg_dy1;
        private a_qg_trol.qg_button_quit qg_button_quit1;
        private a_qg_trol.qg_label_visible qg_label_visible1;
        private a_qg_trol.qg_label_visible qg_label_visible2;
    }
}