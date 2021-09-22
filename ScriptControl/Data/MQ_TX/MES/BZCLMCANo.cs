using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMCANo : BaseTX
    {
        public String trx_id;                                      //       Transaction ID
        public String type_id;                                     //       input / output
        public String rtn_code;                                    //       Return code
        public String ticket_no;                                   //       Ticket No.
        public BZCLMCANo_a[] carrier = new BZCLMCANo_a[1];       //       Carrier
    }
}
