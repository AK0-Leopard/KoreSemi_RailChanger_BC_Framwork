//*********************************************************************************
//      LocMstDao.cs
//*********************************************************************************
// File Name: LocMstDao.cs
// Description: LocMstDao類別
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
    public class LocMstDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 更新Loc_Mst
        /// </summary>
        /// <param name="loc">LocMst</param>
        /// <returns></returns>
        public void updateLocMst(DBConnection conn, Loc_Mst loc)
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
        /// 根據Location ID取得Loc_Mst
        /// </summary>
        /// <param name="loc">Location ID</param>
        /// <returns>回覆取得的Loc_Mst</returns>
        public Loc_Mst getLocMst(DBConnection conn, string loc)
        {
            Loc_Mst rtnLoc = null;
            try
            {
                rtnLoc = conn.Query<Loc_Mst>().Where(l => l.LocMstPK.Loc.Trim() == loc.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLoc;
        }

        /// <summary>
        /// 取得所有Loc_Mst
        /// </summary>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadAllLocMst(DBConnection conn)
        {
            List<Loc_Mst> rtnLocLst = new List<Loc_Mst>();
            try
            {
                rtnLocLst = conn.Query<Loc_Mst>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據WH ID取得Loc_Mst
        /// </summary>
        /// <param name="wh_id">WH ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWhID(DBConnection conn, string wh_id)
        {
            List<Loc_Mst> rtnLocLst = new List<Loc_Mst>();
            try
            {
                rtnLocLst = conn.Query<Loc_Mst>().Where(l => l.LocMstPK.Wh_ID.Trim() == wh_id.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據WIP ID取得Loc_Mst
        /// </summary>
        /// <param name="wip_id">WIP ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWIPAll(DBConnection conn, string wip_id)
        {
            List<Loc_Mst> rtnLocLst = new List<Loc_Mst>();
            try
            {
                rtnLocLst = conn.Query<Loc_Mst>().Where(l => l.LocMstPK.Loc.StartsWith(wip_id)).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據WIP ID取得Loc_Mst
        /// </summary>
        /// <param name="wip_id">WIP ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWIP(DBConnection conn, string wip_id)
        {
            List<Loc_Mst> rtnLocLst = new List<Loc_Mst>();
            try
            {
                rtnLocLst = conn.Query<Loc_Mst>().Where(l => l.LocMstPK.Loc.StartsWith(wip_id) && l.Loc_Sts.Trim() != SCAppConstants.AsrsShelfStat.Disable).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據WIP ID取得空Loc_Mst
        /// </summary>
        /// <param name="wip_id">WIP ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadEmptyLocMstByWIP(DBConnection conn, string wip_id)
        {
            List<Loc_Mst> rtnLocLst = new List<Loc_Mst>();
            try
            {
                rtnLocLst = conn.Query<Loc_Mst>().Where(l => l.LocMstPK.Loc.StartsWith(wip_id) && l.Loc_Sts.Trim() == SCAppConstants.AsrsShelfStat.Empty.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLocLst;
        }

        /// <summary>
        /// 根據WH ID、Zone ID取得Loc_Mst
        /// </summary>
        /// <param name="wh_id">WH ID</param>
        /// <param name="zone_id">Zone ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWhIDAndZone(DBConnection conn, string wh_id, string zone_id)
        {
            List<Loc_Mst> rtnLocLst = new List<Loc_Mst>();
            try
            {
                rtnLocLst = conn.Query<Loc_Mst>().Where(l => l.LocMstPK.Wh_ID.Trim() == wh_id.Trim() && l.Zone_ID.Trim() == zone_id.Trim()).ToList();
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
