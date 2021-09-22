//*********************************************************************************
//      FunctionCodeDao.cs
//*********************************************************************************
// File Name: FunctionCodeDao.cs
// Description: FunctionCodeDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   Delete動作增加檢查
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
    public class FunctionCodeDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void createFunctionCode(DBConnection conn, FunctionCode funcCode) 
        {
            try
            {
                conn.Save(funcCode);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateUser(DBConnection conn, FunctionCode funcCode)
        {
            try
            {
                conn.Update(funcCode);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public FunctionCode getFunctionCode(DBConnection conn, Boolean readLock, string func_code)
        {
            FunctionCode funcCode = null;
            try
            {
                funcCode = conn.Query<FunctionCode>().Where(u => u.Func_Code == func_code.Trim()).FirstOrDefault();
                if (readLock) { conn.Lock(funcCode, LockMode.Upgrade); }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return funcCode;
        }

        public List<FunctionCode> loadAllFunctionCode(DBConnection conn)
        {
            List<FunctionCode> funcList = new List<FunctionCode>();
            try
            {
                funcList = conn.Query<FunctionCode>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return funcList;
        }

        public void deleteFunctionCodeByCode(DBConnection conn, string func_code)
        {
            try
            {
                if (func_code != null)  //A0.01
                {                       //A0.01
                    conn.Delete<FunctionCode>(func_code);
                }                       //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }
}
