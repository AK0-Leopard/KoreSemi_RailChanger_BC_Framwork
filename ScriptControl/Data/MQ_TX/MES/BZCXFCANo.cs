using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCXFCANo : BaseTX
    {
        public String trx_id = "BZCXFCAN";                        //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                   //       input / output
        public String rtn_code = "";                              //       Return code
        public String ticket_no = "";                             //       Ticket No.
        public BZCLMXFRo_a[] carrier = new BZCLMXFRo_a[1];        //       Carrier
    }
}
