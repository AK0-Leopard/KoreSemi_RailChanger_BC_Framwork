using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMSTAo : BaseTX
    {
        public String trx_id = "BZCLMSTA";                        //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                   //       input / output
        public String rtn_code;                                   //       Return code
        public String ticket_no;                                  //       Ticket No.
        public BZCLMSTAo_a[] carrier = new BZCLMSTAo_a[1];        //       Carrier Information
    }
}
