using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDCUACCHo : BaseTX
    {
        public String trx_id = "DDCUACCH";                      //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;           //       input / output
        public String rtn_code;                                               //       Return code
    }
}
