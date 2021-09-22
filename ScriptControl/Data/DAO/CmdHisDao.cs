//*********************************************************************************
//      CmdHisDao.cs
//*********************************************************************************
// File Name: CmdHisDao.cs
// Description: CmdHisDao
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
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class CmdHisDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertCmdMstHis(DBConnection conn, Cmd_Mst_His cmd)
        {
            try
            {
                conn.SaveOrUpdate(cmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void insertCmdDtlHis(DBConnection conn, Cmd_Dtl_His cmd)
        {
            try
            {
                conn.SaveOrUpdate(cmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }

}
