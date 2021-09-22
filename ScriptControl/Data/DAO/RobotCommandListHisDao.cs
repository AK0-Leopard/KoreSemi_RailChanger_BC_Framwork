//*********************************************************************************
//      RobotCommandListHisDao.cs
//*********************************************************************************
// File Name: RobotCommandListHisDao.cs
// Description: Robot Command List History DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NHibernate.Criterion;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class RobotCommandListHisDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static public void insertRobotCMDListHis(DBConnection conn, RobotCommandListHis RobotCMDLstHis)
        {
            try
            {
                conn.SaveOrUpdate(RobotCMDLstHis);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw ;
            }
        }

        static public void deleteAllRobotCMDLst(DBConnection conn)
        {
            try
            {
                const string query = "DELETE FROM ROBOTCMD_LST_HIS";
                if (conn.UsingStateless)
                {
                    conn.StatelessSess
                            .CreateSQLQuery(query)
                            .ExecuteUpdate();
                }
                else
                {
                    conn.Session
                            .CreateSQLQuery(query)
                            .ExecuteUpdate();
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
