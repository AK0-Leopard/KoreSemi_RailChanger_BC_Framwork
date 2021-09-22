using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDIEPTSTo : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDIEPTST";				             //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;			             //       input / output
        public String rtn_code;	                                     //       Return Code
        public String port_count;                                    //       Port Count
        public Port_List[] port_list = new Port_List[1];             //       Port List
    }

    public class Port_List : BaseTX
    {
        //Transaction Variables
        private static readonly int DDIEPTST_OARY = 200;

        //Sub Array References
        public DDIEPTSTo_a[] port_info = new DDIEPTSTo_a[DDIEPTST_OARY];
    }
}
