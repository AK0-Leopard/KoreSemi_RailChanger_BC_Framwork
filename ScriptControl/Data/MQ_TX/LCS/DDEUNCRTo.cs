using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEUNCRTo : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEUNCRT";				             //       Transaction ID
        public String type_id = TX_TYPE_OUTPUT;			             //       input / output
        public String rtn_code;	                                     //       Return Code
        public String carrier_id;                                    //       Carrier ID
        public String carrier_loc;			                         //       Carrier Location
        public CassetteList[] cassette_list = new CassetteList[1];   //       Cassette List
    }

    public class CassetteList : BaseTX
    {
        //Transaction Variables
        private static readonly int DDEUNCRT_OARY = 3;

        //Sub Array References
        public DDEUNCRTo_a[] cassette_info = new DDEUNCRTo_a[DDEUNCRT_OARY];
    }
}
