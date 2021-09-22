//*********************************************************************************
//      BCDefaultValueDefMapAction.cs
//*********************************************************************************
// File Name: BCDefaultValueDefMapAction.cs
// Description: BC PC Map Action
//
//(c) Copyright 2013, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.bcf.Common.MPLC;
using System.Collections;
using com.mirle.ibg3k0.sc.ValueHandler;
using System.Threading;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.ValueDefMapAction
{
    public class BCDefaultValueDefMapAction : IValueDefMapAction
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        protected SCApplication scApp = null;
        protected BCFApplication bcfApp = null;
        protected Node node = null;
        protected Port port = null;
        protected Equipment eqpt = null;

        public BCDefaultValueDefMapAction()
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
            this.eqpt = baseEQ as Equipment;
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
                logger.Error("BCDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
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
                logger.Warn("BCDefaultValueDefMapAction Initial ValueRead Fail");
            }

        }
    }
}
