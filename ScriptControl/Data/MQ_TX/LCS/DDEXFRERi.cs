using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEXFRERi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEXFRER";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String ticket_no;			                         //       Ticket No.
        public String rtn_code;			                             //       Return Code
        public String shelf_loc;			                         //       Shelf Location
        public DDEXFRERi_a[] report_list = new DDEXFRERi_a[1];       //       Report List
    }
}
