//*********************************************************************************
//      EqptDao.cs
//*********************************************************************************
// File Name: EqptDao.cs
// Description: Equipment DAO
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
    public class EqptDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertEqpt(DBConnection conn, Equipment eqpt)
        {
            try
            {
                conn.Save(eqpt);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateEqpt(DBConnection conn, Equipment eqpt)
        {
            try
            {
                conn.Update(eqpt);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public Equipment getEqptByEqptID(DBConnection conn, Boolean readLock, string eqpt_id)
        {
            Equipment rtnEqpt = null;
            try
            {
                rtnEqpt = conn.Query<Equipment>().Where(o => o.Eqpt_ID.Trim() == eqpt_id.Trim()).FirstOrDefault();
                if (rtnEqpt != null && readLock)
                {
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
            return rtnEqpt;
        }

        public List<Equipment> loadEqptListByNode(DBConnection conn, string node_id)
        {
            List<Equipment> rtnList = new List<Equipment>();
            try
            {
                rtnList = conn.Query<Equipment>().Where(o => o.Node_ID == node_id).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

        public List<string> loadEqptNameListByExistEq(DBConnection conn)
        {
            List<string> rtnstringList = new List<string>();
            try
            {
                rtnstringList = conn.Query<Equipment>().Where(o=>o.Eqpt_ID.StartsWith("N")).Select(o => o.Eqpt_ID).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnstringList;
        }



    }
}
