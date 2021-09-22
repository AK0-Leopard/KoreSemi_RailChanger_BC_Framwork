using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.BLL;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.WIF
{
    public class BCSystemWIF
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private EQObjCacheManager eqObjCacheManager = null;
        private BCSystemBLL bcSystemBLL = null;

        public BCSystemWIF(SCApplication scApp) 
        {
            this.scApp = scApp;
            eqObjCacheManager = scApp.getEQObjCacheManager();
            bcSystemBLL = scApp.BCSystemBLL;
        }

        public Boolean canCloseBCSystem() 
        {
            if (eqObjCacheManager == null) { return true; }
            List<Equipment> eqptList = eqObjCacheManager.getAllEquipment();
            Boolean isAllCIMOFF = true;
            foreach (Equipment eqpt in eqptList) 
            {
                if (eqpt.CIM_Mode != Convert.ToInt32(SCAppConstants.EQPTCIMMode.CIM_OFF)) 
                {
                    isAllCIMOFF = false;
                    break;
                }
            }
            return isAllCIMOFF;
        }

        public Boolean closeBCSystem() 
        {
            if (!canCloseBCSystem()) 
            {
                return false;
            }
            return bcSystemBLL.closeBCSystem();
        }

        /// <summary>
        /// 更改系統時間
        /// </summary>
        /// <param name="hostTime"></param>
        public void updateSystemTime(DateTime hostTime) 
        {
            SystemTime st = new SystemTime();
            st.FromDateTime(hostTime);
            SystemTime.SetSystemTime(ref st);
            SystemTime.GetSystemTime(ref st);
            logger.Info("Set System Time:{0}", st.ToDateTime().ToString(SCAppConstants.TimestampFormat_16));
        }

    }
}
