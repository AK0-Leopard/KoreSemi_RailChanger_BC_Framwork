//*********************************************************************************
//      uiPortCst.cs
//*********************************************************************************
// File Name: uiPortCst.cs
// Description: Port 與 Cst 的狀態顯示
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
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.BLL;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.SECS;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.WIF
{
    public class LineWIF
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private EQObjCacheManager eqObjCacheManager = null;
        private LineBLL lineBLL = null;
        private CarrierBLL cassetteBLL = null;
        private Line line = null;

        public LineWIF(SCApplication scApp)
        {
            this.scApp = scApp;
            eqObjCacheManager = scApp.getEQObjCacheManager();
            lineBLL = scApp.LineBLL;
            cassetteBLL = scApp.CarrierBLL;
            line = eqObjCacheManager.getLine();
        }

        public void updateLineStatus()
        {
            try
            {
                line = eqObjCacheManager.getLine();

                List<Equipment> eqptLst = scApp.getEQObjCacheManager().getAllEquipment();

                int lineStatus = SCAppConstants.LineStatus.IDLE;
                foreach (Equipment eqpt in eqptLst)
                {
                    if(SCUtility.isMatche(eqpt.Eqpt_ID, "BC"))
                    {
                        continue;
                    }

                    int eqptStat = SCAppConstants.EQPTStatus.convert2BC(eqpt.Eqpt_Stat);
                    if(eqptStat > lineStatus)
                    {
                        lineStatus = eqptStat;
                    }
                }

                line.Line_Stat = lineStatus;
                Boolean result = lineBLL.updateLineStatus(null, line.Line_ID, lineStatus);
                if (!result)
                {
                    logger.Warn("updateLineStatus fail.");
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("updateLineStatus Exception!", ex);
            }
        }



    }
}
