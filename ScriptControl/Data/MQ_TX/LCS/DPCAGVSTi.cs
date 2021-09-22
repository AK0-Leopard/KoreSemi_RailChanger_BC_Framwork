using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DPCAGVSTi:BaseTX
    {
        //Transaction Input Variables

        public String trx_id = "DPCAGVST";				//       Transaction ID
        public String type_id = TX_TYPE_INPUT;	        //       input / output
        public String clm_date = "";		     		//       Claim Date
        public String clm_time = "";		     		//       Claim Time
        public String user_id = "";			        	//       User ID
        public String eqpt_id = "";			         	//       Equipment ID
        public String ld_agv_mode = "";		    		//       Loader AGV mode (M:MGV A:AGV)
        public String ul_agv_mode = "";		    		//       Unloader Carrier Transfer (M:MGV A:AGV)
    }
}
