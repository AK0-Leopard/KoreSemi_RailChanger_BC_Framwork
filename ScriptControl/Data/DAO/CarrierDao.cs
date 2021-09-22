//*********************************************************************************
//      CarrierDao.cs
//*********************************************************************************
// File Name: CarrierDao.cs
// Description: CarrierDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/03/15    Steven Hong    N/A            A0.01   新增Load Carrier By Bay
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
    public class CarrierDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertCarrier(DBConnection conn, Carrier crr)
        {
            try
            {
                conn.SaveOrUpdate(crr);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateCarrier(DBConnection conn, Carrier crr)
        {
            try
            {
                conn.Update(crr);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public Carrier getCarrier(DBConnection conn, Boolean readLock, string crr_id)
        {
            Carrier rtnCrr = null;
            try
            {
                rtnCrr = conn.Query<Carrier>().Where(c => c.Crr_ID.Trim() == crr_id.Trim()).SingleOrDefault();
                if (rtnCrr != null && readLock)
                {
                    conn.Lock(rtnCrr, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrr;
        }

        public Carrier getCarrierByLocation(DBConnection conn, string location)
        {
            Carrier rtnCrr = null;
            try
            {
                rtnCrr = conn.Query<Carrier>().Where(c => c.Loc.Trim() == location.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrr;
        }

        public List<Carrier> getCarrierAtMGV(DBConnection conn, string location)
        {
            List<Carrier> rtnCrrLst = null;
            try
            {
                rtnCrrLst = conn.Query<Carrier>().Where(c => c.Loc.Trim().StartsWith(location)).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrrLst;
        }

        /// <summary>
        /// 根據Carrier Type要求Carrier
        /// </summary>
        /// <param name="crr_type">Carrier Type</param>
        /// <returns>回覆Carrier</returns>
        public List<Carrier> loadCarrierByType(DBConnection conn, string crr_type)
        {
            List<Carrier> rtnCrrList = null;
            try
            {
                rtnCrrList = conn.Query<Carrier>().Where(c => c.Cst_Type.Trim() == crr_type.Trim()).OrderBy(c => c.CrrStockIn_Time).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrrList;
        }

        /// <summary>
        /// 根據Carrier Type要求空Carrier
        /// </summary>
        /// <param name="crr_type">Carrier Type</param>
        /// <returns>回覆空Carrier</returns>
        public List<Carrier> loadEmptyCarrierByType(DBConnection conn, string crr_type)
        {
            List<Carrier> rtnCrrList = null;
            try
            {
                rtnCrrList = conn.Query<Carrier>().Where(c => c.Crr_Stat == SCAppConstants.CrrStat.EMPTY && c.Cst_Type.Trim() == crr_type.Trim() &&
                   (c.Crr_TrxStat == SCAppConstants.CrrTrxStat.Nothing || c.Crr_TrxStat == SCAppConstants.CrrTrxStat.Complete)).
                   OrderBy(c => c.CrrStockIn_Time).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrrList;
        }

        /// <summary>
        /// 要求空Carrier
        /// </summary>
        /// <returns>回覆空Carrier</returns>
        public List<Carrier> loadEmptyCarrier(DBConnection conn)
        {
            List<Carrier> rtnCrrList = null;
            try
            {
                rtnCrrList = conn.Query<Carrier>().Where(c => c.Crr_Stat == SCAppConstants.CrrStat.EMPTY).OrderBy(c => c.CrrStockIn_Time).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrrList;
        }

        /// <summary>
        /// 要求不在Stocker、搬出口的Carrier
        /// </summary>
        /// <returns>回覆Carrier</returns>
        public List<Carrier> loadTransferCarrier(DBConnection conn)
        {
            List<Carrier> rtnCrrList = null;
            try
            {
                rtnCrrList = conn.Query<Carrier>().Where(c => c.Crr_TrxStat != SCAppConstants.CrrTrxStat.Complete && c.Crr_TrxStat != SCAppConstants.CrrTrxStat.WaitOut).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrrList;
        }

        //A0.01 Start
        /// <summary>
        /// 根據Bay ID要求Carrier
        /// </summary>
        /// <param name="bay_id">Bay ID</param>
        /// <returns>回覆Carrier</returns>
        public List<Carrier> loadCarrierByBay(DBConnection conn, string bay_id)
        {
            List<Carrier> rtnCrrList = null;
            try
            {
                rtnCrrList = conn.Query<Carrier>().Where(c => (c.Crr_TrxStat == SCAppConstants.CrrTrxStat.Nothing || c.Crr_TrxStat == SCAppConstants.CrrTrxStat.Complete) &&
                                                               c.Loc.StartsWith(bay_id)).OrderBy(c => c.CrrStockIn_Time).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnCrrList;
        }
        //A0.01 End

        public void deleteCarrier(DBConnection conn, string crr_id)
        {
            try
            {
                Carrier delCst = conn.Query<Carrier>().Where(c => c.Crr_ID.Trim() == crr_id.Trim()).SingleOrDefault();
                if (delCst != null) 
                {
                    conn.Delete(delCst);
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
