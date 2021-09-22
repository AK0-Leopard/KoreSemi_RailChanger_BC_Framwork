using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDIEQAVAo : BaseTX
    {
        public String trx_id = "DDIEQAVA";                                       //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                                  //       input / output
        public String rtn_code;	                                                 //       Return Code
        public String eqpt_count;	                                             //       Equipment Count
        public EQPT[] eqpt_list = new EQPT[1];                                   //       Equipment Count
    }

    public class EQPT : BaseTX
    {
        //Transaction Variables
        private static readonly int DDIEQAVA_OARY = 50;

        //Sub Array References
        public DDIEQAVAo_a1[] eqpt_info = new DDIEQAVAo_a1[DDIEQAVA_OARY];
    }
}
