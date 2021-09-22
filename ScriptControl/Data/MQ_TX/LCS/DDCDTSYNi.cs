using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDCDTSYNi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDCDTSYN";                     //       Transaction ID
        public String type_id = TX_TYPE_INPUT;             //       input / output
        public String date;                                                     //       Date
        public String time;				                                       //       Time
    }
}
