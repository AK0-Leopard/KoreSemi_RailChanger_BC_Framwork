//*********************************************************************************
//      ECDataMapDao.cs
//*********************************************************************************
// File Name: ECDataMapDao.cs
// Description: ECDataMapDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   Delete動作增加檢查
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class ECDataMapDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<ECDataMap> loadDefaultECDataMapsByEQRealID(string eqpt_real_id)
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["ECDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("EQPT_REAL_ID").Trim() == eqpt_real_id.Trim()
                            select new ECDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                ECID = c.Field<string>("ECID"),
                                ECNAME = c.Field<string>("ECNAME"),
                                ECMIN = c.Field<string>("ECMIN"),
                                ECMAX = c.Field<string>("ECMAX"),
                                ECV = c.Field<string>("ECV")
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public List<ECDataMap> loadDefaultByECID(List<string> ecidList)
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["ECDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            where ecidList.Contains(c.Field<string>("ECID").Trim())
                            select new ECDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                ECID = c.Field<string>("ECID"),
                                ECNAME = c.Field<string>("ECNAME"),
                                ECMIN = c.Field<string>("ECMIN"),
                                ECMAX = c.Field<string>("ECMAX"),
                                ECV = c.Field<string>("ECV")
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public List<ECDataMap> loadAllDefaultECData()
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["ECDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            select new ECDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                ECID = c.Field<string>("ECID"),
                                ECNAME = c.Field<string>("ECNAME"),
                                ECMIN = c.Field<string>("ECMIN"),
                                ECMAX = c.Field<string>("ECMAX"),
                                ECV = c.Field<string>("ECV")
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public ECDataMap getDefaultByECID(string ecid) 
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["SVDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("ECID").Trim() == ecid.Trim().Trim()
                            select new ECDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                ECID = c.Field<string>("ECID"),
                                ECNAME = c.Field<string>("ECNAME"),
                                ECMIN = c.Field<string>("ECMIN"),
                                ECMAX = c.Field<string>("ECMAX"),
                                ECV = c.Field<string>("ECV")
                            };
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateECData(DBConnection conn, ECDataMap ecData) 
        {
            try
            {
                conn.SaveOrUpdate(ecData);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void insertECData(DBConnection conn, ECDataMap ecData)
        {
            try
            {
                conn.Save(ecData);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void deleteECData(DBConnection conn, List<string> ecidList) 
        {
            try
            {
                if (ecidList != null)  //A0.01
                {                      //A0.01
                    foreach (string ecid in ecidList)
                    {
                        conn.Delete<ECDataMap>(ecid);
                    }
                }                      //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public List<ECDataMap> loadECDataMapsByEQRealID(DBConnection conn, string eqpt_real_id) 
        {
            List<ECDataMap> rtnList = new List<ECDataMap>();
            try
            {
                rtnList = conn.Query<ECDataMap>().Where(o => o.EQPT_REAL_ID.Trim() == eqpt_real_id.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

        public List<ECDataMap> loadByECID(DBConnection conn, List<string> ecidList) 
        {
            List<ECDataMap> rtnList = new List<ECDataMap>();
            try
            {
                rtnList = conn.Query<ECDataMap>().Where(o => ecidList.Contains(o.ECID.Trim())).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

        public List<ECDataMap> loadAllECData(DBConnection conn) 
        {
            List<ECDataMap> rtnList = new List<ECDataMap>();
            try
            {
                rtnList = conn.Query<ECDataMap>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

        public ECDataMap getByECID(DBConnection conn, bool readLock, string ecid) 
        {
            ECDataMap rtnItem = null;
            try
            {
                rtnItem = conn.Query<ECDataMap>().Where(o => o.ECID.Trim() == ecid.Trim()).SingleOrDefault();
                if (readLock) 
                {
                    conn.Lock(rtnItem, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnItem;
        }
    }
}
