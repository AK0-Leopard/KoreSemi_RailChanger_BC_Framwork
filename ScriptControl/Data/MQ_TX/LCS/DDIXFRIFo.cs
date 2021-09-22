using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDIXFRIFo : BaseTX
    {
        public String trx_id = "DDIXFRIF";                                  //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;                             //       input / output
        public String rtn_code;                                             //       Return Code
        public String transport_count;	                                    //       Transport Count
        public TRANSPORT[] transport_list = new TRANSPORT[1];               //       Report List
    }

    public class TRANSPORT : BaseTX
    {
        //Transaction Variables
        private static readonly int DDIXFRIF_OARY = 200;

        //Sub Array References
        public DDIXFRIFo_a[] transport = new DDIXFRIFo_a[DDIXFRIF_OARY];
    }

}
