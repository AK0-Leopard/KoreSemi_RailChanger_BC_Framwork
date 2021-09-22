﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZREPINVi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZREPINV";                        //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                    //       input / output
        public BZREPINVi_a[] carrier = new BZREPINVi_a[1];        //       Carrier Information
    }
}
