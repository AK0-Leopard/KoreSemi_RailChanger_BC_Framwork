using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEXFRCMi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEXFRCM";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String ticket_no;				                     //       Ticket No.
        public String transfer_reason_code;				             //       Transfer Reason Code
        public String carrier_loc;				                     //       Carrier Location
        public DDEXFRCMi_a1[] report_list = new DDEXFRCMi_a1[1];     //       Report List
        public String task_count;                                    //       Task Count
        public TASK[] task_list = new TASK[1];                       //       Report List
    }

    public class TASK : BaseTX
    {
        //Transaction Variables
        private static readonly int DDEXFRCM_IARY = 20;

        //Sub Array References
        public DDEXFRCMi_a2[] task_info = new DDEXFRCMi_a2[DDEXFRCM_IARY];
    }
}
