using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZMNCREQi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZMNCREQ";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZMNCREQi_a1[] carriers = new BZMNCREQi_a1[1];     //       Carrier Information
        public String user_id;                                    //       User ID
    }
}
