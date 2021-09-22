using System;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.JSON;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibgAK0.EAP.HostMessage.H2E;
using Grpc.Core;
using Newtonsoft.Json;
using NLog;

namespace ConsoleAppServer
{
    public class ReceiveHostCommad : EAP_K11_H2E.EAP_K11_H2EBase
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected Line line = EQObjCacheManager.getInstance().getLine();
        protected SCApplication scApp = null;

        public ReceiveHostCommad(SCApplication scApp)
        {
            this.scApp = scApp;
        }

    }
}
