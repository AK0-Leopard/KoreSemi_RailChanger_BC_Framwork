//*********************************************************************************
//      UserGroupDao.cs
//*********************************************************************************
// File Name: UserGroupDao.cs
// Description: User Group DAO
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
    public class UserGroupDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertUserGroup(DBConnection conn, UserGroup userGrp)
        {
            try
            {
                conn.Save(userGrp);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateUserGroup(DBConnection conn, UserGroup userGrp)
        {
            try
            {
                conn.Update(userGrp);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public UserGroup getUser(DBConnection conn, string user_grp)
        {
            UserGroup rtnUser = null;
            try
            {
                rtnUser = conn.Query<UserGroup>().Where(u => u.User_Grp.Trim() == user_grp.Trim()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnUser;
        }

        public List<UserGroup> loadAllUserGroup(DBConnection conn)
        {
            List<UserGroup> userGrpList = new List<UserGroup>();
            try
            {
                userGrpList = conn.Query<UserGroup>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return userGrpList;
        }

        public void deleteUserGroupByID(DBConnection conn, string user_grp)
        {
            try
            {
                if (user_grp != null)  //A0.01
                {                      //A0.01
                    conn.Delete<UserGroup>(user_grp);
                }                      //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateUser_ClearGroupByGroupName(DBConnection conn, string user_grp)
        {
            try
            {
                const string query = "UPDATE UASUSR SET USER_GRP=:user_grp_empty WHERE USER_GRP = :user_grp";
                if (conn.UsingStateless)
                {
                    conn.StatelessSess
                            .CreateSQLQuery(query)
                            .SetParameter("user_grp_empty", string.Empty)
                            .SetParameter("user_grp", user_grp)
                            .ExecuteUpdate();
                }
                else
                {
                    conn.Session
                            .CreateSQLQuery(query)
                            .SetParameter("user_grp_empty", string.Empty)
                            .SetParameter("user_grp", user_grp)
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
