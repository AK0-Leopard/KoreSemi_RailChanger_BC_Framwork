//*********************************************************************************
//      ZoneDao.cs
//*********************************************************************************
// File Name: ZoneDao.cs
// Description: Zone DAO
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
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NHibernate.Linq;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class ZoneDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertZone(DBConnection conn, Zone zone)
        {
            try
            {
                conn.Save(zone);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public void updateZone(DBConnection conn, Zone zone)
        {
            try
            {
                conn.Update(zone);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public Zone getZoneByZoneID(DBConnection conn, Boolean readLock, string zone_id)
        {
            Zone rtnZone = null;
            try
            {
                rtnZone = conn.Query<Zone>().Where(o => o.Zone_ID == zone_id).FirstOrDefault();
                if (rtnZone != null && readLock) 
                {
                    conn.Lock(rtnZone, LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
            return rtnZone;
        }

        public List<Zone> loadZoneListByLineID(DBConnection conn, string line_id) 
        {
            List<Zone> rtnList = null;
            try
            {
                rtnList = conn.Query<Zone>().Where(o => o.Line_ID == line_id).ToList();
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
                throw ;
            }
            return rtnList;
        }

    }
}
