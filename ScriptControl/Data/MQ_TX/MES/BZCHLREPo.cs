using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHLREPo : BaseTX
    {
        //Transaction Variables
        public String trx_id = "BZCHLDRR";                        //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                   //       input / output
        public BZCHLREPo_a1[] carriers = new BZCHLREPo_a1[1];     //       Carrier Information
    }
}
