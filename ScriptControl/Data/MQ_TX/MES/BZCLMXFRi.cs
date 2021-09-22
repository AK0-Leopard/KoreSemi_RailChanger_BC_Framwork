using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMXFRi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCLMXFR";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public String ticket_no;                                  //       Ticket No.
        public BZCLMXFRi_a1[] carrier = new BZCLMXFRi_a1[1];      //       Carrier Information
        public BZCLMXFRi_a4[] xferinfo = new BZCLMXFRi_a4[1];     //       Transfer Info
    }
}
