using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDECARWIi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDECARWI";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String eqpt_id;			                             //       Equipment ID
        public String port_id;			                             //       Port ID
        public String port_type;			                         //       Port Type
        public String carrier_id;			                         //       Carrier ID
        public String carrier_loc;			                         //       Carrier Location
        public String carrier_wait_status;			                 //       Carrier Wait Status
        public DDECARWIi_a[] report_list = new DDECARWIi_a[1];       //       Report List
    }
}
