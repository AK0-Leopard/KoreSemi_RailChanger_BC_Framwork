using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEEPTSTi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEEPTST";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String port_loc;			                             //       Port Location
        public String port_status;                                   //       Port Status
        public String eqpt_service;                                  //       Equipment Service
        public DDEEPTSTi_a[] report_list = new DDEEPTSTi_a[1];       //       Report List
    }
}
