using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZUPLPTNi_a2 : BaseTX
    {
        //Transaction Input Variables
        public String zone_id = "";                               //       Zone ID
        public String zone_type = "";                             //       Zone Type
        public String zone_max_cnt = "";                          //       Zone Max Count
        public String zone_used_cnt = "";                         //       Zone Used Count
        public String zone_free_cnt = "";                         //       Zone Free Count
        public BZUPLPTNi_a3[] locations = new BZUPLPTNi_a3[1];    //       Location Information
    }
}
