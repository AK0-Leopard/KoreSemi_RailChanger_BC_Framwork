using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHIRERi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCHIRER";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZCHIRERi_a1[] carriers = new BZCHIRERi_a1[1];     //       Carrier Information
        public String user_id;                                    //       User ID
    }
}
