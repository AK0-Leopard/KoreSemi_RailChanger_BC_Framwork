using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHLREPi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCHLREP";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZCHLREPi_a1[] carriers = new BZCHLREPi_a1[1];     //       Carrier Information
        public String user_id = "";                               //       User ID
    }
}
