//*********************************************************************************
//      PortDao.cs
//*********************************************************************************
// File Name: PortDao.cs
// Description: Port DAO
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
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class PortDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertPort(DBConnection conn, Port port)
        {
            try
            {
                conn.Save(port);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updatePort(DBConnection conn, Port port)
        {
            try
            {
                conn.Update(port);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public Port getPortByPortID(DBConnection conn, Boolean readLock, string port_id)
        {
            Port rtnPort = null;
            try
            {
                rtnPort = conn.Query<Port>().Where(o => o.Port_ID == port_id).FirstOrDefault();
                if (rtnPort != null && readLock)
                {
                    conn.Lock(rtnPort, LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnPort;
        }

        public List<Port> loadPortListByEqpt(DBConnection conn, string eqpt_id)
        {
            List<Port> rtnList = new List<Port>();
            try
            {
                rtnList = conn.Query<Port>().Where(o => o.Eqpt_ID == eqpt_id).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

        public List<Port> loadAllPort(DBConnection conn)
        {
            List<Port> rtnList = new List<Port>();
            try
            {
                rtnList = conn.Query<Port>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnList;
        }

    }
}
