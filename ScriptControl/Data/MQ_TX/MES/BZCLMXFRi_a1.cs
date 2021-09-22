using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCLMXFRi_a1 : BaseTX
    {
        //Transaction Input Variables
        public String crr_id;                                     //       Carrier ID
        public String model_name;                                 //       Model Name
        public String cst_type;                                   //       Cassette Type
        public String cst_condition;                              //       Cassette Condition
        public String cst1_lot_no;                                //       Cassette 1 Unloading Process Lot No
        public String cst2_lot_no;                                //       Cassette 1 Unloading Process Lot No
        public String cst3_lot_no;                                //       Cassette 1 Unloading Process Lot No
        public String unlord_date;                                //       Unloading Date
        public String unlord_time;                                //       Unloading Time
        public String cst1_id;                                    //       Cassette 1 ID
        public String cst2_id;                                    //       Cassette 2 ID
        public String cst3_id;                                    //       Cassette 3 ID
        public String cst1_qty;                                   //       Cassette 1 Qty
        public String cst2_qty;                                   //       Cassette 1 Qty
        public String cst3_qty;                                   //       Cassette 1 Qty
        public String next_process_no;                            //       Next Process No
        public BZCLMXFRi_a2[] fromeqp = new BZCLMXFRi_a2[1];      //       From Equipment
        public BZCLMXFRi_a3[] toeqp = new BZCLMXFRi_a3[1];        //       To Equipment
    }
}
