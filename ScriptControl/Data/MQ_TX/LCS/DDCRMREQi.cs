using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDCRMREQi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDCRMREQ";                   //       Transaction ID
        public String type_id = TX_TYPE_INPUT;             //       input / output
        public String eqpt_id;                                               //       Equipment ID
        public String operation_status;				               //       Operation Status
    }
}
