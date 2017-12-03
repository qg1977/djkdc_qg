using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace djkdc_qg.a_qg_trol
{
    //提示用的文本框，可用于初始使用程序时的提示，用数据库一个值来控制是否全部显示或不显示(控制代码在qg_form中)
    public partial class qg_tip_visible : UserControl
    {
        public string LabelText
        {
            get
            {
                //TODO
                return label1.Text;
            }
            set
            {
                //TODO
                label1.Text = value;
            }
        }

        public qg_tip_visible()
        {
            InitializeComponent();
        }

        public void set_text(string text)
        {
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen1 = new Pen(Color.Red, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }
    }
}
