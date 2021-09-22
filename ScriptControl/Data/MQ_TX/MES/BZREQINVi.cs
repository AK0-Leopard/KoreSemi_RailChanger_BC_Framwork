using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZREQINVi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZREQINV";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZREQINVi_a[] equipment = new BZREQINVi_a[1];      //       Equipment Information
    }
}
