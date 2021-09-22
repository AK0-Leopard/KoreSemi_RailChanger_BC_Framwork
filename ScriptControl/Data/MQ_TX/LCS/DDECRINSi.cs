using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDECRINSi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDECRINS";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;		    	         //       input / output
        public String eqpt_id;				                         //       Eqpt ID
        public String carrier_id;				                     //       Carrier ID
        public String carrier_loc;				                     //       Carrier Location
        public String task_id;				                         //       Task ID
        public String source_loc;				                     //       Source Location
        public String destination_loc;				                 //       Destination Location
        public DDECRINSi_a[] report_list = new DDECRINSi_a[1];       //       Report List
    }
}
