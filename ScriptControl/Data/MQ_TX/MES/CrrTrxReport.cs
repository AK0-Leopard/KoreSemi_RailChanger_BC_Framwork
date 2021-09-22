using com.mirle.ibg3k0.sc.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class CrrTrxReport
    { 
        public PortCmd cmd;                                       //       Command
        public String user;                                       //       User
        public String fromLoc;                                    //       From Location
        public String toLoc;                                      //       To Location
        public String toZone;                                     //       To Zone
        public String toEqpt;                                     //       To Equipment
    }
}
