using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.webAPI
{
    public class QxMGVPortCarrier
    {
        public string trx_name { get; set; }
        public string type_id { get; set; }
        public string rtn_code { get; set; }
        public string rtn_msg { get; set; }
        public List<QxMGVPortCarriero_a> result { get; set; }
    }

    public class QxMGVPortCarriero_a
    {
        public string location { get; set; }
        public string crr_id { get; set; }
        public string crr_size { get; set; }
        public string crr_stat { get; set; }
    }
}
