using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDESTOREi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDESTORE";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;		    	         //       input / output
        public String eqpt_id;				                         //       Equipment ID
        public String carrier_id;                                    //       Carrier ID
        public String store_type;                                    //       Store Type
        public String alternate_carrier;				             //       Alternate Carrier
        public DDESTOREi_a[] report_list = new DDESTOREi_a[1];       //       Report List
    }
}
