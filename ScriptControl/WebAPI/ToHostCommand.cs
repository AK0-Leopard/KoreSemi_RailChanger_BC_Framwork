using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using com.mirle.ibg3k0.sc.Data.JSON;
using com.mirle.ibgAK0.EAP.HostMessage.E2H;
using Grpc.Core;
using Newtonsoft.Json;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.WebAPI
{
    public class ToHostCommand
    {
        double TimeOut = double.Parse(ConfigurationManager.AppSettings["Host_Sever_Timeout"]);
        protected SCApplication scApp = null;

        public ToHostCommand(SCApplication scApp) {
            this.scApp = scApp;
        }

    }
}

