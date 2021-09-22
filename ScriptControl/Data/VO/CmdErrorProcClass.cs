using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CmdErrorProcClass
    {
        public string Crr_ID;
        public int Seq_No;
        public string Arm;
        public bool Finish;
        public bool Error;
        public bool Started;
        public List<RobotCommandList> RobotCMDListLst;
    }
}
