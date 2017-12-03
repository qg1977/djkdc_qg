using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace djkdc_qg.booksql
{
    public partial class booksall_x_all : a_qg_trol.qg_form
    {
        private booksall_x1 frmEmbed = new booksall_x1(); // 全局变量

        private bookshz_cbs book_cbs = new bookshz_cbs(); // 全局变量

        private booksall_x2 book_x2 = new booksall_x2(); // 全局变量
        public booksall_x_all()
        {
            InitializeComponent();
            auto();
        }

        private void auto()
        {
            panel1.Top = qg_button1.Top + qg_button1.Height;
            panel1.Left = 0;
            panel1.Width = Width-10;
            panel1.Height = Height - panel1.Top - 30;
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            form_hide();

            if (book_cbs != null)
            {
                book_cbs.FormBorderStyle = FormBorderStyle.None; // 无边框
                book_cbs.TopLevel = false; // 不是最顶层窗体
                panel1.Controls.Add(book_cbs);  // 添加到 Panel中
                book_cbs.Show();     // 显示
                //book_cbs.Dock = DockStyle.Fill;
                book_cbs.Top =0;
                book_cbs.Left = 5;
                book_cbs.Height = panel1.Height - 10;
                book_cbs.Width = panel1.Width - 10;
            }
        }

        private void qg_button2_Click(object sender, EventArgs e)
        {
            form_hide();

            if (frmEmbed != null)
            {
                frmEmbed.FormBorderStyle = FormBorderStyle.None; // 无边框
                frmEmbed.TopLevel = false; // 不是最顶层窗体
                panel1.Controls.Add(frmEmbed);  // 添加到 Panel中
                frmEmbed.Show();     // 显示
                //frmEmbed.Dock = DockStyle.Fill;
                frmEmbed.Top = 5;
                frmEmbed.Left = 5;
                frmEmbed.Height = panel1.Height - 10;
                frmEmbed.Width = panel1.Width - 10;


            }
        }

        private void qg_button3_Click(object sender, EventArgs e)
        {
            form_hide();

            if (frmEmbed != null)
            {
                book_x2.FormBorderStyle = FormBorderStyle.None; // 无边框
                book_x2.TopLevel = false; // 不是最顶层窗体
                panel1.Controls.Add(book_x2);  // 添加到 Panel中
                book_x2.Show();     // 显示
                book_x2.Dock = DockStyle.Fill;
                //book_x2.Top = 5;
                //book_x2.Left = 5;
                //book_x2.Height = panel1.Height - 10;
                //book_x2.Width = panel1.Width - 10;


            }

        }

        private void form_hide()
        {
            foreach(Control trol in panel1.Controls)
            {
                if (trol is a_qg_trol.qg_form)
                {
                    trol.Hide();
                }
            }
        }

        private void booksall_x_all_Resize(object sender, EventArgs e)
        {
            auto();
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //使用红色虚线绘制边框  
            Pen pen1 = new Pen(Color.Black, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }

        private void qg_button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //
    }
}
