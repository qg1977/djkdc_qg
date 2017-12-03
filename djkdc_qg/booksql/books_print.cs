using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace djkdc_qg.booksql
{
    public partial class books_print : a_qg_trol.qg_form
    {
        StringReader lineReader = null;

        public books_print()
        {


            InitializeComponent();
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            // 这里的printDocument对象可以通过将PrintDocument控件拖放到窗体上来实现，注意要设置该控件的PrintPage事件。
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics; //获得绘图对象
            float linesPerPage = 0; //页面的行号
            float yPosition = 0;   //绘制字符串的纵向位置
            int count = 0; //行计数器
            float leftMargin = e.MarginBounds.Left; //左边距
            float topMargin = e.MarginBounds.Top; //上边距
            string line = null; //行字符串
            Font printFont = this.textBox.Font; //当前的打印字体
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(g);//每页可打印的行数
                                                                          //逐行的循环打印一页
            while (count < linesPerPage && ((line = lineReader.ReadLine()) != null))
            {
                yPosition = topMargin + (count * printFont.GetHeight(g));
                g.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
            // 注意：使用本段代码前，要在该窗体的类中定义lineReader对象：
            //       StringReader lineReader = null;
            //如果本页打印完成而line不为空,说明还有没完成的页面,这将触发下一次的打印事件。在下一次的打印中lineReader会
            //自动读取上次没有打印完的内容，因为lineReader是这个打印方法外的类的成员，它可以记录当前读取的位置
            if (line != null)
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                // 重新初始化lineReader对象，不然使用打印预览中的打印按钮打印出来是空白页
                lineReader = new StringReader(textBox.Text); // textBox是你要打印的文本框的内容
            }
        }

        private void FileMenuItem_PrintSet_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
                 printDialog.Document = printDocument;
                 printDialog.ShowDialog();
        }

        private void FileMenuItem_PageSet_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
                 pageSetupDialog.Document = printDocument;
                 pageSetupDialog.ShowDialog();
        }

        private void FileMenuItem_PrintView_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument;
                lineReader = new StringReader(textBox.Text);
                try
                 {
                         printPreviewDialog.ShowDialog();
                   }
                catch (Exception excep)
                   {
                         MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void FileMenuItem_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
               printDialog.Document = printDocument;
               lineReader = new StringReader(textBox.Text);
               if (printDialog.ShowDialog() == DialogResult.OK)
                  {
                      try
                     {
                             printDocument.Print();
                          }
                      catch (Exception excep)
                       {
                                 MessageBox.Show(excep.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                           }
                   }
            }

        private void qg_button2_Click(object sender, EventArgs e)
        {
            string strText = textBox.Text;
            char[] cSplit = new char[1];
            cSplit[0] = '\r';
            string[] strTextLine = strText.Split(cSplit);
            foreach(string str in strTextLine)
            {
                if (str.Trim().Length>50)
                {
                    MessageBox.Show(str);
                }
             }
        }
    }
}
