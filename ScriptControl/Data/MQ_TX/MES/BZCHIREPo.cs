using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHIREPo : BaseTX
    {
        //Transaction Variables
        public String trx_id = "BZCHIREP";                        //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                   //       input / output
        public BZCHIREPo_a1[] carriers = new BZCHIREPo_a1[1];     //       Carrier Information
    }
}
