using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMSTAi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCLMSTA";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public String ticket_no = "";                             //       Ticket No.
        public BZCLMSTAi_a1[] carrier = new BZCLMSTAi_a1[1];      //       Carrier Information
        public BZCLMSTAi_a2[] fromeqp = new BZCLMSTAi_a2[1];      //       From Equipment
        public BZCLMSTAi_a2[] toeqp = new BZCLMSTAi_a2[1];        //       To Equipment
    }
}
