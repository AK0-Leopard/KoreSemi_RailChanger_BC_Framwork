//*********************************************************************************
//      LinkStatusCheck.cs
//*********************************************************************************
// File Name: LinkStatusCheck.cs
// Description: 
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.TimerAction;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.stc.Common.SECS;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.TimerAction
{
    public class LinkStatusCheck : ITimerAction
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected MPLCSMControl smControl;
        List<Equipment> AllEqLst = null;
        double eqAlive_Min_Change_Interval_sec = 10;

        public LinkStatusCheck(string name, long intervalMilliSec)
            : base(name, intervalMilliSec)
        {
        }

        public override void initStart()
        {
            scApp = SCApplication.getInstance();
            smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;
            AllEqLst = scApp.getEQObjCacheManager().getAllEquipment();
        }

        public override void doProcess(object obj)
        {
            try
            {
                foreach (Equipment eqpt in AllEqLst)
                {
                    if (SCUtility.isMatche(eqpt.Eqpt_ID, "EAP"))
                    {
                        continue;
                    }

                    if (eqpt.Eq_Alive_Last_Change_time.AddSeconds(eqAlive_Min_Change_Interval_sec) < DateTime.Now)
                    {
                        eqpt.Is_EqAlive = false;
                        //logger.Warn("EQ ID:{0}, Eq alive fail!!Last change time:{1},Last change index:{2}"
                        //            , eqpt.Eqpt_ID
                        //            , eqpt.Eq_Alive_Last_Change_time.ToString(SCAppConstants.DateTimeFormat_22)
                        //            , eqpt.Eq_Alive.ToString());
                    }
                    else
                    {
                        eqpt.Is_EqAlive = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

    }
}