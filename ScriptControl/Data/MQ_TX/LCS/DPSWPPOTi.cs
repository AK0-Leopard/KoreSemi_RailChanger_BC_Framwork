using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace com.mirle.ibg3k0.mqc.tx
{
    public class DPSWPPOTi : BaseTX
    {
        //Transaction Input Variables

        public String trx_id = "DPSWPPOT";				//       Transaction ID
        public String type_id = TX_TYPE_INPUT;			//       input / output
        public String eqpt_id = "";		         		//       Equipment ID
        public String port_id = "";			        	//       Port ID
        public String crr_id = "";			         	//       Carrier ID
        public String req_type = "";			    	//       request type A:Auto only

    }
}
