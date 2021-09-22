using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Data.TimerAction;
using com.mirle.ibg3k0.sc.App;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.TimerAction
{
    public class BCSystemStatusTimer : ITimerAction
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;

        public BCSystemStatusTimer(string name, long intervalMilliSec)
            : base(name, intervalMilliSec)
        {

        }
        public override void initStart()
        {
            scApp = SCApplication.getInstance();
        }
        public override void doProcess(object obj)
        {
            scApp.BCSystemBLL.reWriteBCSystemRunTime();
        }
    }
}
