using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEBCRRFi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEBCRRF";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String ticket_no;			                         //       Ticket No
        public String bcr_loc;                                       //       BCR Location
        public String rtn_code;                                      //       Return Code
        public String carrier_id;                                    //       Carrier ID
        public Cassette_List[] cassette_list = new Cassette_List[1]; //       Cassette List
        public DDEBCRRFi_a2[] report_list = new DDEBCRRFi_a2[1];     //       Report List
    }

    public class Cassette_List : BaseTX
    {
        //Transaction Variables
        private static readonly int DDEBCRRF_IARY = 3;

        //Sub Array References
        public DDEBCRRFi_a1[] cassette_info = new DDEBCRRFi_a1[DDEBCRRF_IARY];
    }
}
