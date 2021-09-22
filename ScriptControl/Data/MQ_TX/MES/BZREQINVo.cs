using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZREQINVo : BaseTX
    {
        //Transaction Variables
        private static readonly int BZREQINV_OARY2 = 2000;

        public String trx_id = "BZREQINV";                        //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                   //       input / output
        public String rtn_code = "";                              //       Return code
        public BZREQINVo_a1[] equipment = new BZREQINVo_a1[1];    //       Equipment Information
        public BZREQINVo_a2[] locations = new BZREQINVo_a2[BZREQINV_OARY2];    //       Location Information
    }
}
