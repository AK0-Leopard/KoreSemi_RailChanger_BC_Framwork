//*********************************************************************************
//      UnitDao.cs
//*********************************************************************************
// File Name: UnitDao.cs
// Description: Unit DAO
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
    public class UnitDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertUnit(DBConnection conn, Unit unit)
        {
            try
            {
                conn.Save(unit);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public void updateUnit(DBConnection conn, Unit unit)
        {
            try
            {
                conn.Update(unit);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public Unit getUnitByUnitID(DBConnection conn, Boolean readLock, string unit_id)
        {
            Unit rtnUnit = null;
            try
            {
                rtnUnit = conn.Query<Unit>().Where(o => o.Unit_ID == unit_id).FirstOrDefault();
                if (rtnUnit != null && readLock)
                {
                    conn.Lock(rtnUnit, LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
            return rtnUnit;
        }

        public List<Unit> loadAllUnit(DBConnection conn)
        {
            List<Unit> rtnList = new List<Unit>();
            try
            {
                rtnList = conn.Query<Unit>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

        public List<Unit> loadUnitListByEqpt(DBConnection conn, string eqpt_id)
        {
            List<Unit> rtnList = new List<Unit>();
            try
            {
                rtnList = conn.Query<Unit>().Where(o => o.Eqpt_ID == eqpt_id).ToList();
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
