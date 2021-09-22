//*********************************************************************************
//      RobotCommandTableHisDao.cs
//*********************************************************************************
// File Name: RobotCommandTableHisDao.cs
// Description: Robot Command Table History DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class RobotCommandTableHisDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static public void insertRobotCMDHis(DBConnection conn, RobotCommandTableHis RobotCMDHis)
        {
            try
            {
                conn.SaveOrUpdate(RobotCMDHis);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
            }
        }

        static public void deleteAllRobotCMD(DBConnection conn)
        {
            try
            {
                const string query = "DELETE FROM ROBOTCMD_TABLE_HIS";
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
