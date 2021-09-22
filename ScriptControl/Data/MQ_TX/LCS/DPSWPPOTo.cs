﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DPSWPPOTo:BaseTX
    {
        //Transaction Output Variables

        public String trx_id = "";			    	//       Transaction ID
        public String type_id = "";			    	//       input / output
        public String rtn_code = "";				//       return code
        public String rtn_mesg = "";				//       return message
        public String to_eqpt_id = "";				//       To Equipment ID
        public String to_port_id = "";				//       To Port ID
        public String to_pati_id = "";				//       To Partition ID
        public String to_zone_id = "";				//       To Zone ID

    }
}
