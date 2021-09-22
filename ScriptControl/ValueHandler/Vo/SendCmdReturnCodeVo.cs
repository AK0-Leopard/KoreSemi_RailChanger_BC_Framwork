using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.ValueHandler.Vo
{
    public class SendCmdReturnCodeVo
    {
        public int iSeqNo { get; set; }
        public int iCo { get; set; }

        //Co的定義:
        //0=ACK,
        //1=Busy,
        //2=CIM Mode is Offline,
        //3=Invaild prrameter,
        //99=No RobotCMD
        //1000=Timeout,
        //2000=SendDataFail,
        public string sCmdStr;
    }
}
