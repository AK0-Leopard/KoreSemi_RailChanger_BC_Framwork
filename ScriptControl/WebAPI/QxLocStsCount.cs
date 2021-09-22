using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.webAPI
{
    public class QxLocStsCounto
    {
        public string trx_name { get; set; }
        public string type_id { get; set; }
        public string rtn_code { get; set; }
        public string rtn_msg { get; set; }
        public QxLocStsCounto_a1 result { get; set; }
    }

    public class QxLocStsCounto_a1
    {
        public string WH_ID { get; set; }
        public string EQU_NO { get; set; }
        public string ROW_X { get; set; }
        public string Total_Qty { get; set; }
        public List<QxLocStsCounto_a2> LOC_STS { get; set; }
    }

    public class QxLocStsCounto_a2
    {
        public string type { get; set; }
        public string name { get; set; }
        public string Count { get; set; }
    }
}
