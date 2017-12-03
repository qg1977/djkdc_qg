using djkdc_qg.a_sqlconn;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;


using djkdc_qg.a_sqlconn;
using static djkdc_qg.a_GlobalClass.con_sql;
using System.Runtime.InteropServices;

namespace djkdc_qg.a_qg_trol
{
    public partial class qg_form : Form
    {
        public bool button_px_jytt
        {
            get; set;
        }

        public qg_form()
        {
            //StartPosition = FormStartPosition.CenterScreen;//窗体居中
            
            InitializeComponent();
            this.BackgroundImage = a_qg_zy.tree;//指定背景图片v
            //skinEngine1.SkinFile = "skins/GlassOrange.ssk";
            button_px_jytt = true;

            OnActivated(null);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void auto_bj()
        {
            try
            {
                //表单中的一些提示文字是否还用显示
                string sqlstring = "select 值 from z_system where 属性=2";
                DataTable dt = return_select(sqlstring);
                int jytt_visible = 0;
                if (dt.Rows.Count > 0) { jytt_visible = dt.Rows[0]["值"].ToString().ToInt(); }
                //表单中的一些提示文字是否还用显示


                int button_sum = 0;
                int b_quit_z_width = 0;//窗体中是否有"退出"按钮,如果没有就不对按钮排列
                int b_quit_z_top = 0;
                List<string> button_name_all = new List<string>();

                foreach (Control control in this.Controls)
                {
                    #region 如果不需要一些简单提示语句，就隐藏
                    if (jytt_visible == 1)
                    {
                        if (control is qg_tip_visible)
                        {
                            control.Visible = false;
                        }

                        if (control is Panel)
                        {
                            foreach(Control trol in control.Controls)
                            {
                                if (trol is qg_tip_visible)
                                {
                                    trol.Visible = false;
                                }
                            }
                        }

                        if (control is MonthCalendar)
                        { control.Visible = false; }
                    }
                    #endregion


                    //标题
                    if (control is qg_bt_label)
                    {
                        if (((qg_bt_label)control).Name == "qg_bt_label1")
                        {
                            qg_bt_label qg_bt_label = (qg_bt_label)control;
                            Text = qg_bt_label.Text.ToString();

                            qg_bt_label.Top = 5;
                            qg_bt_label.Left = (qg_bt_label.Parent.Width - qg_bt_label.Width) / 2;
                        }
                    }

                    if (control is qg_label)
                    {
                        if (((qg_label)control).Text == "月份")
                        {
                            qg_label qg_label = (qg_label)control;
                            qg_label.Top = 35;
                            qg_label.Left = (qg_label.Parent.Width - qg_label.Width) / 2;
                        }
                    }
                    //数据表格
                    if (control is qg_grid)
                    {
                        if (((qg_grid)control).auto_jytt)
                        {
                            qg_grid qg_grid = (qg_grid)control;
                            qg_grid.Left = 10;
                            qg_grid.Width = (qg_grid.Parent).Width - 20;
                            qg_grid.Top = 55;
                            qg_grid.Height = (qg_grid.Parent).Height-qg_grid.Top - 180;
                        }
                    }
                    //也是一个数据表格，树状的
                    if (control is qg_grid_tree)
                    {
                        if (((qg_grid_tree)control).auto_jytt)
                        {
                            qg_grid_tree qg_grid = (qg_grid_tree)control;
                            qg_grid.Left = 10;
                            qg_grid.Width = (qg_grid.Parent).Width - 20;
                            qg_grid.Top = 55;
                            qg_grid.Height = (qg_grid.Parent).Height - 180;
                        }
                    }
                    //退出按钮
                    if (control is qg_button_quit)
                    {


                        qg_button_quit b_quit = (qg_button_quit)control;
                        b_quit.Text = "退  出";
                        CancelButton = b_quit;

                        b_quit.Top = (b_quit.Parent).Height - 90;

                        b_quit_z_width = b_quit.Width;//有"退出"按钮就对所有按钮排列
                        b_quit_z_top = b_quit.Top;
                    }
                    //打印预览
                    if (control is qg_dy)
                    {
                        qg_dy qg_dy = (qg_dy)control;
                        qg_dy.Text = "打印预览";
                    }

                    if ((control is qg_button && control.Name.ToString().Contains("qg_button"))
                         || control is qg_button_quit
                         || control is qg_dy)
                    {
                        button_sum = button_sum + 1;
                        button_name_all.Add(control.Name.ToString());
                    }
                }

                if (button_px_jytt && b_quit_z_width > 0)
                {
                    button_name_all.Sort();//对按钮的名称排序

                    int l_width_temp = (this.Width - b_quit_z_width * button_sum) / (button_sum + 1);
                    //MessageBox.Show("按钮数目:" + button_sum.ToString() + "\n" + "间距:" + l_width_temp.ToString());

                    //int button_i = 0;
                    foreach (Control control in this.Controls)
                    {
                        if (control is qg_button_quit)
                        {
                            control.Left = Width - l_width_temp - b_quit_z_width;
                        }

                        if (control is qg_dy)
                        {
                            control.Top = b_quit_z_top;
                            control.Left = Width - 2 * l_width_temp - 2 * b_quit_z_width;
                        }

                        if (control is qg_button)
                        {
                            //根据按钮的名称判断该按钮在“button_name_all”中的排序位置
                            string butt_name = control.Name.ToString();
                            int button_i = button_name_all.IndexOf(butt_name) - 1;

                            control.Top = b_quit_z_top;
                            control.Left = (button_i + 1) * l_width_temp + button_i * b_quit_z_width;
                            //MessageBox.Show("距离:"+l_width_temp.ToString()+"\n"+"按钮宽度:"+b_quit_z_width.ToString()+"\n"+"第几个:" + button_i.ToString() + "\n" + "左:" + control.Left.ToString());

                            //button_i = button_i + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }

        }

        private void sz_size()
        {
            //   MessageBox.Show("width:" + a_GlobalClass.other_static.mdi_max_width.ToString() + "  " + Width.ToString() + "\n"
            //+ "height:" + a_GlobalClass.other_static.mdi_max_height.ToString() + "  " + Height.ToString());
            //避免程序调试过程中，表单的大小也不正常
            if (a_GlobalClass.other_static.mdi_max_width > 0)
            {
                bool jytt_max = true;

                if (Width > a_GlobalClass.other_static.mdi_max_width)
                {
                    jytt_max = false;

                    Left = 1;
                    //WindowState = FormWindowState.Normal;
                    Width = a_GlobalClass.other_static.mdi_max_width;
                }

                if (Height > a_GlobalClass.other_static.mdi_max_height)
                {
                    jytt_max = false;

                    //WindowState = FormWindowState.Normal;
                    Left = 0;
                    Top = a_GlobalClass.other_static.mdi_top_zl - 15;
                    Height = a_GlobalClass.other_static.mdi_max_height;

                }
                if (jytt_max)
                {
                    Left = (a_GlobalClass.other_static.mdi_max_width - Width) / 2;
                    Top = (a_GlobalClass.other_static.mdi_max_height - Height) / 2;
                }
                else { WindowState = FormWindowState.Normal; }
            }
        }


        private void qg_form_Load(object sender, EventArgs e)
        {
            //sz_size();
            auto_bj();

        }

        private void qg_form_Resize(object sender, EventArgs e)
        {
            //sz_size();
            auto_bj();
        }

        //mdi窗体菜单打开新窗体时，会将mdi窗体菜单设为不可用
        //所以当关闭新窗体时，需要将mdi窗体的菜单设为可用
        private void qg_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Form mdi_Form = MdiParent;
                if (mdi_Form != null)
                {
                    foreach (System.Windows.Forms.Control control in mdi_Form.Controls)
                    {
                        if (control is MenuStrip)
                        {
                            MenuStrip mdi_menu = (MenuStrip)control;
                            if (mdi_menu.Name == "mdi_menu")
                            {
                                mdi_menu.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void qg_form_Activated(object sender, EventArgs e)
        {
            
        }

        private void qg_form_Shown(object sender, EventArgs e)
        {
            sz_size();
        }



        //声明一些API函数 
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            IntPtr HIme = ImmGetContext(this.Handle);
            if (ImmGetOpenStatus(HIme))    //如果输入法处于打开状态 
            {
                int iMode = 0;
                int iSentence = 0;
                bool bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);    //检索输入法信息 
                if (bSuccess)
                {
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)      //如果是全角 
                        ImmSimulateHotKey(this.Handle, IME_CHOTKEY_SHAPE_TOGGLE);    //转换成半角 
                }

            }
        }

        //结束
    }
}
