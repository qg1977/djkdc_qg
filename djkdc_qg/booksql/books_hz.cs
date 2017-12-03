using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using static djkdc_qg.a_GlobalClass.con_sql;
using djkdc_qg.a_sqlconn;

namespace djkdc_qg.booksql
{
    class books_hz
    {
        public DataTable bookshz_all(string cbsid,string typeid)
        {
            DataTable dt_permoney = new DataTable();
             try 
            {
                string sqlstring = "";

                sqlstring = "select ID,ISBN号,书名,拼音,单价,convert(char(10),出版日期,120) 出版日期,册数"
                    + ",出版社ID,出版社=isnull((select 出版社 from press where ID=b.出版社ID),'')"
                     + ",类别ID,图书类别=isnull((select 图书类别 from types where ID=b.类别ID),'')"
                     +",convert(decimal(12,2),单价*册数) 金额"
                     + " from booksall b where ID is not null";
                if (cbsid.Trim()!="")
                { sqlstring = sqlstring + " and 出版社ID in ("+cbsid+")"; }
                if (typeid.Trim()!="")
                { sqlstring = sqlstring + " and 类别ID in (" + typeid + ")"; }
                dt_permoney = return_select(sqlstring);

                if (dt_permoney.Rows.Count <= 0) { return null; }

                return dt_permoney;              
            }
            catch (Exception ex)
            {
                ex.errormess();
            }

            return dt_permoney;
        }


        public DataTable bookshz_all_cbs(string cbsid)
        {
            DataTable dt_permoney_bm = null;
            try
            {
                DataTable dt_permoney = bookshz_all(cbsid, "");

                DataColumn dc1 = new DataColumn("排序", Type.GetType("System.Int32"));
                dc1.DefaultValue = 2;
                dt_permoney.Columns.Add(dc1);

                //dc1 = new DataColumn("ID", Type.GetType("System.Int64"));
                //dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("上级ID", Type.GetType("System.Int64"));
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("编码", Type.GetType("System.String"));
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("展开", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("显示", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("金额排序", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_permoney.Columns.Add(dc1);

                //相当于select 员工ID,月份,sum(工种) 工种,sum(基本工资) group by 员工ID,月份
                #region

                var query = from t in dt_permoney.AsEnumerable()
                            group t by new { t1 = t.Field<Int64>("出版社ID"), t2 = t.Field<string>("出版社") } into m
                            select new
                            {
                                出版社ID = m.Key.t1,
                                出版社 = m.Key.t2,
                               金额 = m.Sum(n => n.Field<decimal>("金额")),
                                册数 = m.Sum(n => n.Field<decimal>("册数")),
                            };
                DataTable dtNamex1 = Cs_Datatable.ToDataTable(query.ToList());

                DataView dtName_dv = dtNamex1.DefaultView;
                dtName_dv.Sort = "金额 desc";
                DataTable  dtName = dtName_dv.ToTable();

                dc1 = new DataColumn("金额排序", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dtName.Columns.Add(dc1);

                for (int i=0;i<dtName.Rows.Count;i++)
                {
                    dtName.Rows[i]["金额排序"] = i+1;
                }
                //将出版社的金额进行合计，最后放到总表的第一行，后面要用
                decimal moneyallall = dtName.Compute("sum(金额)", "").ToString().ToDecimal();
                int csallall = dtName.Compute("sum(册数)", "").ToString().ToInt();

                DataTable dtResult = dt_permoney.Clone();//用来将所有汇总后的数据表
                //DataTable dtName = dt_permoney.DefaultView.ToTable(true, "出版社ID", "出版社");

                for (int i = 0; i < dtName.Rows.Count; i++)
                {
                    int px_money= dtName.Rows[i]["金额排序"].ToString().ToInt();
                    string bmidtempid = dtName.Rows[i][0].ToString().Trim();

                    DataRow drtemp1 = dt_permoney.NewRow();
                    drtemp1["出版社ID"] = bmidtempid;
                    drtemp1["排序"] = 3;
                    drtemp1["ID"] = 0;
                    drtemp1["金额排序"] = px_money;
                    dt_permoney.Rows.Add(drtemp1);

                    DataRow[] rows = dt_permoney.Select("出版社ID='" + bmidtempid + "'","金额 desc");

                    

                    //temp用来存储筛选出来的数据
                    DataTable temp = dtResult.Clone();
                    foreach (DataRow row in rows)
                    {
                        //LogTextHelper.Info("\r\n书名：" + row["书名"].ToString()+"   金额："+row["金额"].ToString());

                        temp.Rows.Add(row.ItemArray);

                        //顺便将员工列的“上级ID”和“编码”定下来
                        row["上级ID"] = bmidtempid;
                        row["编码"] = bmidtempid.Trim() + "-" + row["ID"].ToString().Trim();
                        row["金额排序"] = px_money;
                        //顺便将员工列的“上级ID”和“编码”定下来
                    }


                    DataRow dr = dtResult.NewRow();
                    dr["ID"] = dtName.Rows[i][0].ToString();
                    dr["编码"] = dtName.Rows[i][0].ToString();
                    dr["出版社ID"] = dtName.Rows[i][0].ToString();
                    dr["出版社"] = "● " + dtName.Rows[i][1].ToString();
                    dr["排序"] = 1;
                    dr["展开"] = 0;
                    dr["显示"] = 1;
                    dr["金额排序"] = px_money;

                    for (int j = 0; j < temp.Columns.Count; j++)
                    {
                        string columnnametemp1 = temp.Columns[j].ColumnName.ToString().Trim();



                        //if (columnnametemp1 != "出版社ID"
                        //    && columnnametemp1 != "出版社"
                        //    && columnnametemp1 != "员工ID"
                        //    && columnnametemp1 != "姓名"
                        //    && columnnametemp1 != "月份"
                        //    && columnnametemp1 != "上级ID"
                        //    && columnnametemp1 != "编码"
                        //    && (temp.Columns[j].DataType.FullName == "System.Decimal")
                        //    )
                        if (columnnametemp1=="册数" || columnnametemp1.Trim()=="金额")
                        {

                            dr[columnnametemp1] = temp.Compute("sum(" + columnnametemp1.Trim() + ")", "");
                        }
                    }
                    //dr["工种"] = temp.Compute("max(工种)", "");
                    dtResult.Rows.Add(dr);


                }
                #endregion
                //相当于select 员工ID,月份,sum(工种) 工种,sum(基本工资) group by 员工ID,月份

                //员工工资列的“部门名称”设为“”
                for (int i = 0; i < dt_permoney.Rows.Count; i++)
                {
                    dt_permoney.Rows[i]["出版社"] = "";  //添加数据行
                }
                //员工工资列的“部门名称”设为“”

                //将部门合计的金额列加入到总表中
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    dt_permoney.Rows.Add(dtResult.Rows[i].ItemArray);  //添加数据行
                }
                //将部门合计的金额列加入到总表中

                //LogTextHelper.Info("\r\n执行前列数：" +dt_permoney.Rows.Count.ToString());
                //将总合计金额放到表头
                DataRow dr_all = dt_permoney.NewRow();
                dr_all["出版社"] = "合计";
                dr_all["金额"] = moneyallall;
                dr_all["册数"] = csallall;
                dr_all["金额排序"] = 0;
                dr_all["显示"] = 1;
                dr_all["排序"] = 1;
                dr_all["编码"] = "-1";
                dr_all["ID"] = "0";
                dt_permoney.Rows.Add(dr_all);

                dr_all = dt_permoney.NewRow();
                dr_all["金额排序"] = 0;
                dr_all["显示"] = 1;
                dr_all["排序"] = 3;
                dr_all["编码"] = "-1";
                dr_all["ID"] = "0";
                dt_permoney.Rows.Add(dr_all);
                //将总合计金额放到表头
                //LogTextHelper.Info("\r\n执行后：" + dt_permoney.Rows.Count.ToString());

                //排序
                DataView dv = dt_permoney.DefaultView;
                dv.Sort = "金额排序,出版社ID,排序,金额 desc";
                //dt_permoney_bm = dv.ToTable().DefaultView.ToTable(true, "ID", "出版社", "册数", "金额", "ISBN号", "书名","上级ID","编码","展开","显示","排序");
                dt_permoney_bm = dv.ToTable();
                //LogTextHelper.Info("\r\n排序后：" + dt_permoney_bm.Rows.Count.ToString());

                DataRow[] rows1 = dt_permoney_bm.Select("排序=2");
                for(int i=0;i< rows1.Count();i++)
                {
                    rows1[i]["出版社"] = "      " + rows1[i]["书名"].ToString() + "(ISBN号：" + rows1[i]["ISBN号"].ToString() + ")";
                }

                dt_permoney_bm.Columns["出版社"].SetOrdinal(1);
                dt_permoney_bm.Columns["册数"].SetOrdinal(2);
                dt_permoney_bm.Columns["金额"].SetOrdinal(3);
                dt_permoney_bm.Columns["ISBN号"].SetOrdinal(4);
                dt_permoney_bm.Columns["书名"].SetOrdinal(5);
                //排序
            }
            catch (Exception ex)
            {
                ex.errormess();
            }


            return dt_permoney_bm;
        }



        public DataTable bookshz_all_type(string typeid)
        {
            DataTable dt_permoney_bm = null;
            try
            {
                DataTable dt_permoney = bookshz_all("",typeid);

                DataColumn dc1 = new DataColumn("排序", Type.GetType("System.Int32"));
                dc1.DefaultValue = 2;
                dt_permoney.Columns.Add(dc1);

                //dc1 = new DataColumn("ID", Type.GetType("System.Int64"));
                //dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("上级ID", Type.GetType("System.Int64"));
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("编码", Type.GetType("System.String"));
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("展开", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_permoney.Columns.Add(dc1);

                dc1 = new DataColumn("显示", Type.GetType("System.Int32"));
                dc1.DefaultValue = 0;
                dt_permoney.Columns.Add(dc1);

                //相当于select 员工ID,月份,sum(工种) 工种,sum(基本工资) group by 员工ID,月份
                #region
                DataTable dtResult = dt_permoney.Clone();
                DataTable dtName = dt_permoney.DefaultView.ToTable(true, "类别ID", "图书类别");
                for (int i = 0; i < dtName.Rows.Count; i++)
                {
                    string bmidtempid = dtName.Rows[i][0].ToString().Trim();

                    DataRow drtemp1 = dt_permoney.NewRow();
                    drtemp1["类别ID"] = bmidtempid;
                    drtemp1["排序"] = 3;
                    drtemp1["ID"] = 0;
                    dt_permoney.Rows.Add(drtemp1);

                    DataRow[] rows = dt_permoney.Select("类别ID='" + bmidtempid + "'");

                    //temp用来存储筛选出来的数据
                    DataTable temp = dtResult.Clone();
                    foreach (DataRow row in rows)
                    {
                        temp.Rows.Add(row.ItemArray);

                        //顺便将员工列的“上级ID”和“编码”定下来
                        row["上级ID"] = bmidtempid;
                        row["编码"] = bmidtempid.Trim() + "-" + row["ID"].ToString().Trim();
                        //顺便将员工列的“上级ID”和“编码”定下来
                    }


                    DataRow dr = dtResult.NewRow();
                    dr["ID"] = dtName.Rows[i][0].ToString();
                    dr["编码"] = dtName.Rows[i][0].ToString();
                    dr["类别ID"] = dtName.Rows[i][0].ToString();
                    dr["图书类别"] = "● " + dtName.Rows[i][1].ToString();
                    dr["排序"] = 1;
                    dr["展开"] = 0;
                    dr["显示"] = 1;

                    for (int j = 0; j < temp.Columns.Count; j++)
                    {
                        string columnnametemp1 = temp.Columns[j].ColumnName.ToString().Trim();


                        if (columnnametemp1 == "册数" || columnnametemp1.Trim() == "金额")
                        {

                            dr[columnnametemp1] = temp.Compute("sum(" + columnnametemp1.Trim() + ")", "");
                        }
                    }
                    //dr["工种"] = temp.Compute("max(工种)", "");
                    dtResult.Rows.Add(dr);


                }
                #endregion
                //相当于select 员工ID,月份,sum(工种) 工种,sum(基本工资) group by 员工ID,月份

                //员工工资列的“部门名称”设为“”
                for (int i = 0; i < dt_permoney.Rows.Count; i++)
                {
                    dt_permoney.Rows[i]["图书类别"] = "";  //添加数据行
                }
                //员工工资列的“部门名称”设为“”

                //将部门合计的金额列加入到总表中
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    dt_permoney.Rows.Add(dtResult.Rows[i].ItemArray);  //添加数据行
                }
                //将部门合计的金额列加入到总表中

                //排序
                DataView dv = dt_permoney.DefaultView;
                dv.Sort = "类别ID,排序";
                //dt_permoney_bm = dv.ToTable().DefaultView.ToTable(true, "ID", "出版社", "册数", "金额", "ISBN号", "书名","上级ID","编码","展开","显示","排序");
                dt_permoney_bm = dv.ToTable();
                dt_permoney_bm.Columns["图书类别"].SetOrdinal(1);
                dt_permoney_bm.Columns["册数"].SetOrdinal(2);
                dt_permoney_bm.Columns["金额"].SetOrdinal(3);
                dt_permoney_bm.Columns["ISBN号"].SetOrdinal(4);
                dt_permoney_bm.Columns["书名"].SetOrdinal(5);
                //排序
            }
            catch (Exception ex)
            {
                ex.errormess();
            }


            return dt_permoney_bm;
        }


    }
}
