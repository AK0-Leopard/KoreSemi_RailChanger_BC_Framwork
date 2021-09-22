//*********************************************************************************
//      UserFuncDao.cs
//*********************************************************************************
// File Name: UserFuncDao.cs
// Description: UserFuncDao類別
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
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class UserFuncDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void createUserFunc(DBConnection conn, UserFunc userFunc) 
        {
            try
            {
                conn.Save(userFunc);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public List<UserFunc> loadUserFuncByUserID(DBConnection conn, string user_grp) 
        {
            List<UserFunc> rtnList = new List<UserFunc>();
            try
            {
                rtnList =
                    conn.Query<UserFunc>().Where(f => f.UserFuncPK.User_GRP.Trim() == user_grp.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
            return rtnList;
        }

        public UserFunc getUserFunc(DBConnection conn, string user_grp, string function_code) 
        {
            UserFunc rtnObj = null;
            try
            {
                rtnObj = conn.Query<UserFunc>().
                    Where(u => u.UserFuncPK.User_GRP.Trim() == user_grp.Trim() &&
                        u.UserFuncPK.Func_Code.Trim() == function_code.Trim()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
            return rtnObj;
        }

        public void deleteUserFunc(DBConnection conn, UserFunc userFunc) 
        {
            try
            {
                if (userFunc != null)  //A0.01
                {                      //A0.01
                    conn.Delete<UserFunc>(userFunc.UserFuncPK);
                }                      //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public void deleteUserFuncByUserID(DBConnection conn, string user_id) 
        {
            try
            {
                List<UserFunc> userFuncList = loadUserFuncByUserID(conn, user_id);

                if (userFuncList != null)  //A0.01
                {                          //A0.01
                    foreach (UserFunc userFunc in userFuncList)
                    {
                        conn.Delete<UserFunc>(userFunc.UserFuncPK);
                    }
                }                          //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

    }
}
