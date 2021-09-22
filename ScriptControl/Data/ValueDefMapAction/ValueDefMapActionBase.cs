//*********************************************************************************
//      ValueDefMapActionBase.cs
//*********************************************************************************
// File Name: ValueDefMapActionBase.cs
// Description: Type 1 Function
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date               Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//2021/09/01   克祥                                         A0.01  修正HandShake on住的問題
//2021/09/01   克祥                                         A0.02  新增邏輯-Buffer若已存在Tray則自動選其他Buffer
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;
using NLog;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.stc.Common;
using com.mirle.ibg3k0.sc.Data.SECS;
using System.Reflection;
using com.mirle.ibg3k0.sc.ValueHandler;
using System.Collections;
using System.Threading;
using com.mirle.ibg3k0.bcf.Common.MPLC;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.sc.Data.JSON;

namespace com.mirle.ibg3k0.sc.Data.ValueDefMapAction
{
    public class ValueDefMapActionBase : IValueDefMapAction
    {
        //提供紀錄Robot 下命令中的各段時間
        public DateTimeOffset? Start_WritePLC;

        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected BCFApplication bcfApp = null;
        Line line = null;
        protected Equipment eqpt = null;
        protected HostDefaultValueDefMapAction hostDefaultMapAction;

        protected int HandShake_TimeOut = 5000;//A0.01
        public ValueDefMapActionBase()
        {
            scApp = SCApplication.getInstance();
            bcfApp = scApp.getBCFApplication();
            line = scApp.getEQObjCacheManager().getLine();
        }

        public virtual void unRegisterEvent() { }
        public virtual void setContext(BaseEQObject baseEQ) { }
        public virtual string getIdentityKey() { return this.GetType().Name; }
        public virtual void doShareMemoryInit(com.mirle.ibg3k0.bcf.App.BCFAppConstants.RUN_LEVEL runLevel) { }
        public virtual void doInit()
        {
            try
            {

            }
            catch
            {
                scApp.getBCFApplication().onSMAppError(0, "11");
                logger.Warn("ValueDefMapActionBase Initial ValueRead Fail");
            }
        }
    }

}
