using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEEQPALi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEEQPAL";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String ticket_no;				                     //       Ticket No.
        public String eqpt_id;				                         //       Eqpt ID
        public DDEEQPALi_a1[] report_list = new DDEEQPALi_a1[1];     //       Report List
        public DDEEQPALi_a2[] alarm_list = new DDEEQPALi_a2[1];      //       Alarm List
    }
}
