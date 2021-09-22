using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDECRRRMi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDECRRRM";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String eqpt_id;				                         //       Eqpt ID
        public String carrier_id;				                     //       Carrier ID
        public String carrier_loc;				                     //       Carrier Location
        public String destination_loc;				                 //       Destination Location
        public DDECRRRMi_a[] report_list = new DDECRRRMi_a[1];       //       Report List
    }
}
