using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDIEQPSTo_a1 : BaseTX
    {
        public String eqpt_id;                                   //       Equipment ID
        public String carrier_id;                                //       Carrier ID
        public String eqpt_status;                            //       Equipment Status
        public String eqpt_service;                          //       Equipment Service
        public String operation_status;                  //       Operation Status
        public String alarm_count;                          //       Alarm Count
        public ALARM alarm_list;                             //       Alarm List
    }

    public class ALARM
    {
        //Transaction Variables
        private static readonly int DDIEQPST_OARY2 = 20;

        //Sub Array References
        public DDIEQPSTo_a2[] eqpt_info = new DDIEQPSTo_a2[DDIEQPST_OARY2];
    }

}
