//*********************************************************************************
//      MESDefaultValueDefMapAction.cs
//*********************************************************************************
// File Name: MESDefaultValueDefMapAction.cs
// Description: LCS Map Action
//
//(c) Copyright 2013, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.mqc.tx;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.JSON;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.sc.Data.VO;
using Mirle.AK0.Hlt.Communications.Sockets.TCPClients;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.ValueDefMapAction
{
    public class HostDefaultValueDefMapAction : IValueDefMapAction
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected BCFApplication bcfApp = null;
        protected Line line = null;
        protected Equipment eqptCV = null;


        public HostDefaultValueDefMapAction()
            : base()
        {
            scApp = SCApplication.getInstance();
            bcfApp = scApp.getBCFApplication();
        }

        public virtual string getIdentityKey()
        {
            return this.GetType().Name;
        }

        public virtual void setContext(BaseEQObject baseEQ)
        {
            this.line = baseEQ as Line;
        }

        public virtual void unRegisterEvent()
        {

        }

        public virtual void doShareMemoryInit(BCFAppConstants.RUN_LEVEL runLevel)
        {
            try
            {
                switch (runLevel)
                {
                    case BCFAppConstants.RUN_LEVEL.ZERO:
                        initHandShake();
                        break;
                    case BCFAppConstants.RUN_LEVEL.ONE:
                        break;
                    case BCFAppConstants.RUN_LEVEL.TWO:
                        break;
                    case BCFAppConstants.RUN_LEVEL.NINE:
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error("HostDefaultValueDefMapAction has Error[Line Name:{0}],[Error method:{1}],[Error Message:{2}",
                    line.Line_ID, "doShareMemoryInit", ex.ToString());
            }
        }

        public virtual void doInit()
        {
            try
            {

            }
            catch
            {
                scApp.getBCFApplication().onSMAppError(0, "11");
                logger.Warn("HostDefaultValueDefMapAction Initial ValueRead Fail");
            }
        }

        protected virtual void initHandShake()
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.Error("Exception:", ex);
            }
        }
    }

}