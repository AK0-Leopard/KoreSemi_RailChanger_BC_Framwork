using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEXFRCMi_a2 : BaseTX
    {
        public String sequence;				                //       Sequence
        public String task_id;				                    //       Task ID
        public String source_loc;				            //       Source Location
        public String destination_loc;			        //       Destination Location
        public DDEXFRCMi_a1[] start_time = new DDEXFRCMi_a1[1];          //       Start Time
        public DDEXFRCMi_a1[] end_time = new DDEXFRCMi_a1[1];           //       End Time
    }
}
