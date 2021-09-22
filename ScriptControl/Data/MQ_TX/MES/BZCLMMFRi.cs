using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMMFRi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "BZCLMMFR";                          //       Transaction ID
        public String type_id = TX_TYPE_INPUT;                      //       input / output
        public String ticket_no = "";                               //       Ticket No.
        public BZCLMMFRi_a1[] carrier = new BZCLMMFRi_a1[1];        //       Carrier Information
        public BZCLMMFRi_a4[] xferinfo = new BZCLMMFRi_a4[1];       //       Transfer Info
    }
}
