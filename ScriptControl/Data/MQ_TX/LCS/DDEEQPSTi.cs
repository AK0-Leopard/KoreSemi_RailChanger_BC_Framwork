using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEEQPSTi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEEQPST";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String eqpt_id;			                             //       Equipment ID
        public String eqpt_status;			                         //       Equipment Status
        public String eqpt_service;			                         //       Equipment Service
        public String operation_status;			                     //       Equipment Operation Status
        public DDEEQPSTi_a[] report_list = new DDEEQPSTi_a[1];       //       Report List
    }
}
