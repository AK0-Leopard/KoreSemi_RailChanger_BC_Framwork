//*********************************************************************************
//      CmdDtlDao.cs
//*********************************************************************************
// File Name: CmdDtlDao.cs
// Description: CmdDtlDao
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   Delete動作增加檢查
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
    public class CmdDtlDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 新增Cmd Dtl
        /// </summary>
        /// <param name="cmd">Cmd Dtl</param>
        /// <returns></returns>
        public void insertCmdDtl(DBConnection conn, Cmd_Dtl cmd)
        {
            try
            {
                conn.SaveOrUpdate(cmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 更新Cmd Dtl
        /// </summary>
        /// <param name="cmd">Cmd Dtl</param>
        /// <returns></returns>
        public void updateCmdDtl(DBConnection conn, Cmd_Dtl cmd)
        {
            try
            {
                conn.Update(cmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 根據Cmd No取得Cmd Dtl
        /// </summary>
        /// <param name="cmd_sno">Cmd No</param>
        /// <returns>回覆取得的Cmd_Dtl</returns>
        public List<Cmd_Dtl> loadCmdDtlByNo(DBConnection conn, Boolean readLock, string cmd_sno)
        {
            List<Cmd_Dtl> rtnCmdLst = null;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Dtl>().Where(c => c.CmdDtlPK.Cmd_Sno.Trim() == cmd_sno.Trim()).ToList();
                if (rtnCmdLst != null && readLock)
                {
                    conn.Lock(rtnCmdLst, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 根據Carrier ID取得搬送命令明細
        /// </summary>
        /// <param name="crr_id">Carrier ID</param>
        /// <returns>回覆查到的搬送命令</returns>
        public List<Cmd_Dtl> loadCmdDtlByCarrierID(DBConnection conn, string crr_id)
        {
            List<Cmd_Dtl> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Dtl>().Where(c => c.Crr_ID.Trim() == crr_id.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 刪除搬送命令
        /// </summary>
        /// <param name="cmd_sno">Cmd No</param>
        /// <returns></returns>
        public void deleteCmdDtl(DBConnection conn, string cmd_sno)
        {
            try
            {
                List<Cmd_Dtl> delCmdLst = conn.Query<Cmd_Dtl>().Where(c => c.CmdDtlPK.Cmd_Sno.Trim() == cmd_sno.Trim()).ToList();
                if (delCmdLst != null)  //A0.01
                {                       //A0.01
                    foreach (Cmd_Dtl delCmd in delCmdLst)
                    {
                        conn.Delete(delCmd);
                    }
                }                       //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }

}
