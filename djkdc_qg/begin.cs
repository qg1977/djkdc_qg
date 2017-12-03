using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using static djkdc_qg.a_GlobalClass.con_sql;
using djkdc_qg.a_sqlconn;

namespace djkdc_qg
{
    class begin
    {
        public static void auto()
        {
            try {

                //其它的一些全局变量
                a_GlobalClass.begin_public.begin_public_other();

 
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }
    }
}
