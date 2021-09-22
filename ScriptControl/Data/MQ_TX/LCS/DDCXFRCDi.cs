using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDCXFRCDi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDCXFRCD";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;		    	         //       input / output
        public String ticket_no;			                         //       Ticket No.
        public String priority;			                             //       Priority
        public String source_loc;			                         //       Source Location
        public String destination_loc;			                     //       Destination Location
        public String transfer_speed;                                //       Transfer Speed
        public String carrier_id;			                         //       Carrier ID
        public CASSETTE[] cassette_list = new CASSETTE[1];           //       Cassette List
    }

    public class CASSETTE : BaseTX
    {
        //Transaction Variables
        private static readonly int DDCXFRCD_IARY = 3;

        //Sub Array References
        public DDCXFRCDi_a[] cassette_info = new DDCXFRCDi_a[DDCXFRCD_IARY];
    }

}
