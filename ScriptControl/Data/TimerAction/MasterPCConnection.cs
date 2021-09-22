//*********************************************************************************
//      MasterPCConnection.cs
//*********************************************************************************
// File Name: MasterPCConnection.cs
// Description: 
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.TimerAction;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace com.mirle.ibg3k0.sc.Data.TimerAction
{
    class MasterPCConnection : ITimerAction
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected MPLCSMControl smControl;
        private static DateTime syscDateTime;
        private Line line;

        private int RoutineInspectionInterval_Day = 1;

        public MasterPCConnection(string name, long intervalMilliSec)
            : base(name, intervalMilliSec)
        {
        }

        public override void initStart()
        {
            scApp = SCApplication.getInstance();
            smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;
            syscDateTime = DateTime.Now;
            line = scApp.getEQObjCacheManager().getLine();
        }
       
        private long syncCheck_Point = 0;
        public override void doProcess(object obj)
        {
            //ValueWrite isAliveIndexVW = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, "EAP", "HS41_INDEX");

            if (System.Threading.Interlocked.Exchange(ref syncCheck_Point, 1) == 0)
            {
                try
                {
                    //line.Plc_Link_Stat = updateAlive(isAliveIndexVW, scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl) ? SCAppConstants.LinkStatus.Link_OK : SCAppConstants.LinkStatus.Link_Fail;
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception");
                }
                finally
                {
                    System.Threading.Interlocked.Exchange(ref syncCheck_Point, 0);
                }
            }
        }

        private bool updateAlive(ValueWrite isAliveIndexVW, MPLCSMControl smControl)
        {

            /*int x = (UInt16)isAliveIndexVW.getText() + 1;
            if (x > 9999) { x = 1; }
            isAliveIndexVW.setWriteValue((UInt16)x);

            bool isWriteSucess = false;
            try
            {
                isWriteSucess = smControl.writeDeviceBlock(isAliveIndexVW);
                return isWriteSucess;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");

                return false;
            }*/
            return true;
        }



    }
}