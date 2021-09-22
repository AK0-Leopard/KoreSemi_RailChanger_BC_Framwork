using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMCANi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCLMCAN";                         //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                     //       input / output
        public String ticket_no = "";                              //       Ticket No.
        public BZCLMCANi_a[] carrier = new BZCLMCANi_a[1];         //       Carrier
        public String user_id = "";                                //       User ID
    }
}
