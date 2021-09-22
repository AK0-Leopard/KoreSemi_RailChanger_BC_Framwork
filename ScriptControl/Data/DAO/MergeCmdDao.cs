//*********************************************************************************
//      MergeCmdDao.cs
//*********************************************************************************
// File Name: MergeCmdDao.cs
// Description: MergeCmdDao類別
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
    public class MergeCmdDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertMergeCmd(DBConnection conn, MergeCmd mergeCmd)
        {
            try
            {
                conn.SaveOrUpdate(mergeCmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateMergeCmd(DBConnection conn, MergeCmd mergeCmd)
        {
            try
            {
                conn.Update(mergeCmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public MergeCmd getMergeCmd(DBConnection conn, string cmd_sno)
        {
            MergeCmd rtnCmd = null;
            try
            {
                rtnCmd = conn.Query<MergeCmd>().Where(c => c.Cmd_Sno.Trim() == cmd_sno.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCmd;
        }

        public void deleteMergeCmd(DBConnection conn, string cmd_sno)
        {
            try
            {
                MergeCmd delCmd = conn.Query<MergeCmd>().Where(c => c.Cmd_Sno.Trim() == cmd_sno.Trim()).SingleOrDefault();
                if (delCmd != null) 
                {
                    conn.Delete(delCmd);
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
