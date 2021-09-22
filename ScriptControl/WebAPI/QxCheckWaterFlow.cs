using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.webAPI
{
    public class QxCheckWaterFlow
    {
        public string trx_name { get; set; }
        public string type_id { get; set; }
        public string rtn_code { get; set; }
        public string rtn_msg { get; set; }
        public QxCheckWaterFlowo_a result { get; set; }
    }

    public class QxCheckWaterFlowo_a
    {
        public string PARA_CATE { get; set; }
        public string DEFINE_VALUE { get; set; }
        public string WH_ID { get; set; }
        public string CALCULATE { get; set; }
        public string HIGH_WATER_MARK { get; set; }
    }

}
