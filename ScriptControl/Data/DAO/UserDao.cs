//*********************************************************************************
//      UserDao.cs
//*********************************************************************************
// File Name: UserDao.cs
// Description: User DAO
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
using com.mirle.ibg3k0.bcf.Data;
using NLog;
using NHibernate;
using NHibernate.Linq;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class UserDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertUser(DBConnection conn, User user) 
        {
            try
            {
                conn.Save(user);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public void updateUser(DBConnection conn, User user) 
        {
            try
            {
                conn.Update(user);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public User getUser(DBConnection conn, Boolean readLock, string user_id) 
        {
            User rtnUser = null;
            try
            {
                rtnUser = conn.Query<User>().Where(u => u.User_ID.Trim() == user_id.Trim()).FirstOrDefault();
                if (readLock) { conn.Lock(rtnUser, LockMode.Upgrade); }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
            return rtnUser;
        }

        public User getUserByBadge(DBConnection conn, string badge_no)
        {
            User rtnUser = null;
            try
            {
                rtnUser = conn.Query<User>().Where(u => u.Badge_Number.Trim() == badge_no.Trim()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnUser;
        }

        public User getAdminUser(DBConnection conn) 
        {
            User rtnUser = null;
            try
            {
                rtnUser = conn.Query<User>().Where(u => u.Admin_Flg.Trim() == SCAppConstants.YES_FLAG.Trim()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnUser;
        }

        public List<User> loadAllUser(DBConnection conn) 
        {
            List<User> userList = new List<User>();
            try
            {
                userList = conn.Query<User>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
            return userList;
        }

        public List<User> loadUserByIDList(DBConnection conn, List<string> userIDList) 
        {
            List<User> userList = new List<User>();
            try
            {
                userList = conn.Query<User>().Where(u => userIDList.Contains(u.User_ID.Trim())).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }

            return userList;
        }

        public void deleteUserByID(DBConnection conn, string user_id) 
        {
            try 
            {
                if (user_id != null)  //A0.01
                {                     //A0.01
                    conn.Delete<User>(user_id);
                }                     //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }
    }
}
