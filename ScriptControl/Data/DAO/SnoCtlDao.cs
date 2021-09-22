//*********************************************************************************
//      SnoCtlDao.cs
//*********************************************************************************
// File Name: SnoCtlDao.cs
// Description: SnoCtlDao
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
    public class SnoCtlDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 新增Sno Ctl
        /// </summary>
        /// <param name="sno">Sno Ctl</param>
        /// <returns></returns>
        public void insertSnoCtl(DBConnection conn, Sno_Ctl sno)
        {
            try
            {
                conn.SaveOrUpdate(sno);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 更新Sno Ctl
        /// </summary>
        /// <param name="sno">Sno Ctl</param>
        /// <returns></returns>
        public void updateSnoCtl(DBConnection conn, Sno_Ctl sno)
        {
            try
            {
                conn.Update(sno);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 根據Sno Type取得Sno Ctl
        /// </summary>
        /// <param name="sno_type">Sno Ctl</param>
        /// <returns>回覆取得的Sno_Ctl</returns>
        public Sno_Ctl getSnoCtl(DBConnection conn, string sno_type)
        {
            Sno_Ctl rtnSNo = null;

            try
            {
                rtnSNo = conn.Query<Sno_Ctl>().Where(c => c.Sno_Type.Trim() == sno_type.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnSNo;
        }

        /// <summary>
        /// 刪除Sno Ctl
        /// </summary>
        /// <param name="sno_type">Sno Ctl</param>
        /// <returns></returns>
        public void deleteSnoCtl(DBConnection conn, string sno_type)
        {
            try
            {
                Sno_Ctl delSno = conn.Query<Sno_Ctl>().Where(c => c.Sno_Type.Trim() == sno_type.Trim()).SingleOrDefault();
                if (delSno != null)  //A0.01
                {                    //A0.01
                    conn.Delete(delSno);
                }                    //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }

}
