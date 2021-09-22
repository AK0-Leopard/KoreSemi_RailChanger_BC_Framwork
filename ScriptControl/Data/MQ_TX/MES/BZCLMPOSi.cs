using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMPOSi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCLMPOS";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public String ticket_no = "";                             //       Ticket No.
        public String cur_location_no = "";                       //       Current Location
        public BZCLMPOSi_a1[] carrier = new BZCLMPOSi_a1[1];      //       Carrier Information
        public BZCLMPOSi_a2[] xferinfo = new BZCLMPOSi_a2[1];     //       Transfer Info
    }
}
