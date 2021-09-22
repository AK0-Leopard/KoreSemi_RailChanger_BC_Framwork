using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHLRERi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCHLRER";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZCHLRERi_a1[] carriers = new BZCHLRERi_a1[1];     //       Carrier Information
        public String user_id;                                    //       User ID
    }
}
