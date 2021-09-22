using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDCALTZNi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDCALTZN";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String count;				                         //       Array Count
        public ALTERNATE_SHELF[] alternate_shelf_list = new ALTERNATE_SHELF[1];                 //       Alternate Shelf
    }

    public class ALTERNATE_SHELF : BaseTX
    {
        //Sub Array References
        public DDCALTZNi_a[] shelf_info = new DDCALTZNi_a[1];
    }
}
