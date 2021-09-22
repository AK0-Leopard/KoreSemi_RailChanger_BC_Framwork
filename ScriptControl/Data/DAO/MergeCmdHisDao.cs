//*********************************************************************************
//      MergeCmdHisDao.cs
//*********************************************************************************
// File Name: MergeCmdHisDao.cs
// Description: MergeCmdHisDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
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
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class MergeCmdHisDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertMergeCmdHis(DBConnection conn, MergeCmdHis mergeCmdHis)
        {
            try
            {
                conn.SaveOrUpdate(mergeCmdHis);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public MergeCmdHis getMergeCmdHisByCrr(DBConnection conn, string crr_id)
        {
            MergeCmdHis rtnCmd = null;

            try
            {
                rtnCmd = conn.Query<MergeCmdHis>().Where(c => c.Crr_ID1.Trim() == crr_id.Trim() || c.Crr_ID2.Trim() == crr_id.Trim()).
                    OrderByDescending(c => c.Log_Sno).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmd;
        }

        public void deleteMergeCmdHis(DBConnection conn, MergeCmdHis mergeCmdHis)
        {
            try
            {
                if (mergeCmdHis != null) 
                {
                    conn.Delete(mergeCmdHis);
                } 
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }


    }
}
