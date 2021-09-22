using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCXFCANi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCXFCAN";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public String ticket_no;                                  //       Ticket No.
        public BZCLMXFRi_a[] carrier = new BZCLMXFRi_a[1];        //       Carrier
        public String user_id;                                    //       User ID
    }
}
