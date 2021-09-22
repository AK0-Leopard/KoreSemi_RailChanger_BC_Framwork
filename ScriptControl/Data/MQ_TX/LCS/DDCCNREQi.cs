using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDCCNREQi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDCCNREQ";                    //       Transaction ID
        public String type_id = TX_TYPE_INPUT;             //       input / output
        public String control_status;				                   //       Control Status
    }
}
