using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHIRERo : BaseTX
    {
        //Transaction Variables
        public String trx_id = "BZCHIRER";                        //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                   //       input / output
        public BZCHIRERo_a1[] carriers = new BZCHIRERo_a1[1];      //       Carrier Information
    }
}
