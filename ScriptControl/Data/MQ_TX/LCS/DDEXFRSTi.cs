using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEXFRSTi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEXFRST";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String ticket_no;				                     //       Ticket No.
        public String transfer_type;				                 //       Transfer Type                   
        public DDEXFRSTi_a[] report_list = new DDEXFRSTi_a[1];       //       Report List
    }
}
