using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDIEQPSTo : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDIEQPST";                       //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                  //       input / output
        public String rtn_code;                                  //       Return Code
        public String eqpt_count;                                //       Eqpt Count
        public EQUIPMENT[] eqpt_list = new EQUIPMENT[1];         //       Report List
    }

    public class EQUIPMENT : BaseTX
    {
        //Transaction Variables
        private static readonly int DDIEQPST_OARY1 = 30;

        //Sub Array References
        public DDIEQPSTo_a1[] eqpt_info = new DDIEQPSTo_a1[DDIEQPST_OARY1];
    }

}
