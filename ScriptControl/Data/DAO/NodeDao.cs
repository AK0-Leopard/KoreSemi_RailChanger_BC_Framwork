//*********************************************************************************
//      NodeDao.cs
//*********************************************************************************
// File Name: NodeDao.cs
// Description: Node DAO
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
    public class NodeDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertNode(DBConnection conn, Node node)
        {
            try
            {
                conn.Save(node);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateNode(DBConnection conn, Node node)
        {
            try
            {
                conn.Update(node);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public Node getNodeByNodeID(DBConnection conn, Boolean readLock, string node_id)
        {
            Node rtnNode = null;
            try
            {
                rtnNode = conn.Query<Node>().Where(o => o.Node_ID == node_id).FirstOrDefault();
                if (rtnNode != null && readLock)
                {
                    conn.Lock(rtnNode, LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnNode;
        }

        public List<Node> loadNodeListByZone(DBConnection conn, string zone_id) 
        {
            List<Node> rtnList = new List<Node>();
            try 
            {
                rtnList = conn.Query<Node>().Where(o => o.Zone_ID == zone_id).ToList();
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
