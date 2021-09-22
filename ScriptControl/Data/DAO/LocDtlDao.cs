//*********************************************************************************
//      LocDtlDao.cs
//*********************************************************************************
// File Name: LocDtlDao.cs
// Description: LocDtlDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class LocDtlDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 更新Loc_Dtl
        /// </summary>
        /// <param name="loc">LocDtl</param>
        /// <returns></returns>
        public void updateLocDtl(DBConnection conn, Loc_Dtl loc)
        {
            try
            {
                conn.Update(loc);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 根據Location ID、Tx No取得Loc_Dtl
        /// </summary>
        /// <param name="loc">Location ID</param>
        /// <param name="tx_no">Tx No</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public Loc_Dtl getLocDtl(DBConnection conn, string loc, string tx_no)
        {
            Loc_Dtl rtnLoc = null;
            try
            {
                rtnLoc = conn.Query<Loc_Dtl>().Where(l => l.LocDtlPK.Loc.Trim() == loc.Trim() && l.LocDtlPK.Loc_TxNo.Trim() == tx_no.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLoc;
        }

        /// <summary>
        /// 取得所有Loc_Dtl
        /// </summary>
        /// <returns>回覆取得的Loc_Dtl List</returns>
        public List<Loc_Dtl> loadAllLocDtl(DBConnection conn)
        {
            List<Loc_Dtl> rtnLocLst = new List<Loc_Dtl>();
            try
            {
                rtnLocLst = conn.Query<Loc_Dtl>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據Location ID取得Loc_Dtl
        /// </summary>
        /// <param name="loc">Location ID</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public List<Loc_Dtl> loadLocDtlByLoc(DBConnection conn, string loc)
        {
            List<Loc_Dtl> rtnLocLst = new List<Loc_Dtl>();
            try
            {
                rtnLocLst = conn.Query<Loc_Dtl>().Where(l => l.LocDtlPK.Loc.Trim() == loc.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據Caassette ID取得Loc_Dtl
        /// </summary>
        /// <param name="cstID">Cassette ID</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public Loc_Dtl getLocDtlByCst(DBConnection conn, string cstID)
        {
            Loc_Dtl rtnLoc = new Loc_Dtl();
            try
            {
                rtnLoc = conn.Query<Loc_Dtl>().Where(l => l.Crr_ID.Trim() == cstID.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLoc;
        }

        /// <summary>
        /// Wh ID取得Loc_Dtl
        /// </summary>
        /// <param name="wh_id">Wh ID</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public List<Loc_Dtl> loadLocDtlByWhID(DBConnection conn, string wh_id)
        {
            List<Loc_Dtl> rtnLocDtlLst = new List<Loc_Dtl>();
            try
            {
                rtnLocDtlLst = conn.Query<Loc_Dtl>().Where(l => l.LocDtlPK.Wh_ID.Trim() == wh_id.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocDtlLst;
        }

        /// <summary>
        /// 取得實Loc_Dtl
        /// </summary>
        /// <returns>回覆取得的實Loc_Dtl</returns>
        public List<Loc_Dtl> loadFullLocDtl(DBConnection conn)
        {
            List<Loc_Dtl> rtnLocLst = new List<Loc_Dtl>();
            try
            {
                rtnLocLst = conn.Query<Loc_Dtl>().Where(l => l.Plt_Qty > 0).OrderBy(l => l.LocDtlPK.Wh_ID).OrderBy(l => l.LocDtlPK.Loc).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

    }
}
