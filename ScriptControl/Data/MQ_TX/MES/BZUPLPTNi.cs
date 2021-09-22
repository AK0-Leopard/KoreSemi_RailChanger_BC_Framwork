using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZUPLPTNi : BaseTX
    {
        //Transaction Input Variables
        private static readonly int BZUPLPTNV_IARY2 = 50;

        public String trx_id = "BZUPLPTN";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZUPLPTNi_a1[] equipment = new BZUPLPTNi_a1[1];    //       Equipment Information
        public BZUPLPTNi_a2[] zone = new BZUPLPTNi_a2[BZUPLPTNV_IARY2];    //       Zone Information
    }
}
