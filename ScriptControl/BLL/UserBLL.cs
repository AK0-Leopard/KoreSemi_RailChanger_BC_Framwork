//*********************************************************************************
//      UserBLL.cs
//*********************************************************************************
// File Name: UserBLL.cs
// Description: 業務邏輯：User、Group、Function Code
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class UserBLL
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private UserDao userDao = null;
        private FunctionCodeDao functionCodeDao = null;
        private UserFuncDao userFuncDao = null;
        private UserGroupDao userGroupDao = null;

        public UserBLL()
        {

        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            userDao = scApp.UserDao;
            functionCodeDao = scApp.FunctionCodeDao;
            userFuncDao = scApp.UserFuncDao;
            userGroupDao = scApp.UserGroupDao;
        }

        public Boolean createUser(User user)
        {
            DBConnection conn = null;
            try
            {
                if (user == null)
                {
                    return false;
                }
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userDao.insertUser(conn, user);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to UASUSR [user_id:{0}]", user.User_ID, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean createUser(string user_id, string user_name, string passwd, string badge_no, string group, Boolean isDisable, 
            Boolean isPowerUser, Boolean isAdmin, string department)  //A0.01  //A0.03
        {
            DBConnection conn = null;
            try
            {
                User newUser = new User
                {
                    User_ID = user_id.ToUpper(),
                    User_Name = user_name,
                    Passwd = passwd,
                    Badge_Number = badge_no,
                    User_Grp = group,
                    Disable_Flg = (isDisable ? SCAppConstants.YES_FLAG : SCAppConstants.NO_FLAG),
                    Power_User_Flg = (isPowerUser ? SCAppConstants.YES_FLAG : SCAppConstants.NO_FLAG),
                    Admin_Flg = (isAdmin ? SCAppConstants.YES_FLAG : SCAppConstants.NO_FLAG),
                    Department = department
                };

                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userDao.insertUser(conn, newUser);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to UASUSR [user_id:{0}]", user_id, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updatePassword(string user_id, string passwd)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                User updUser = userDao.getUser(conn, true, user_id);
                if (passwd != null && passwd.Trim().Length > 0)
                {
                    updUser.Passwd = passwd;
                }
                userDao.updateUser(conn, updUser);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to UASUSR [user_id:{0}]", user_id, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateUser(string user_id, string user_name, string passwd, string badge_no, string group, Boolean isDisable, Boolean isPowerUser, string department) 
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                User updUser = userDao.getUser(conn, true, user_id);
                updUser.User_Name = user_name;
                updUser.Badge_Number = badge_no;
                updUser.User_Grp = group;
                updUser.Department = department;
                if (passwd != null && passwd.Trim().Length > 0)
                {
                    updUser.Passwd = passwd;
                }
                updUser.Disable_Flg = (isDisable ? SCAppConstants.YES_FLAG : SCAppConstants.NO_FLAG);
                updUser.Power_User_Flg = (isPowerUser ? SCAppConstants.YES_FLAG : SCAppConstants.NO_FLAG);
                userDao.updateUser(conn, updUser);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to UASUSR [user_id:{0}]", user_id, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public User getUserByBadge(string badge_no)
        {
            User rtnUser = new User();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnUser = userDao.getUserByBadge(conn, badge_no);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Failed from UASUSR", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnUser;
        }

        public User getUserByID(string user_id)
        {
            User userTemp = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userTemp = userDao.getUser(conn, true, user_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Failed from UASUSR", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return userTemp;
        }

        public List<User> loadAllUser()
        {
            List<User> userList = new List<User>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userList = userDao.loadAllUser(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Failed from UASUSR", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return userList;
        }

        public User getAdminUser()
        {
            User admin = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                admin = userDao.getAdminUser(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Get Admin User Failed from UASUSR", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return admin;
        }

        public Boolean deleteUser(string user_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                User delUser = userDao.getUser(conn, true, user_id);
                if (!delUser.isAdmin())
                {
                    userDao.deleteUserByID(conn, user_id);
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete Failed From UASUSR [user_id:{0}]", user_id, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean createFunctionCode(FunctionCode functionCode)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                functionCodeDao.createFunctionCode(conn, functionCode);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to UASFNC [Func_Code:{0}]", functionCode.Func_Code, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean createFunctionCode(string func_code, string func_name)
        {
            FunctionCode funcCode = new FunctionCode();
            funcCode.Func_Code = func_code;
            funcCode.Func_Name = func_name;
            return createFunctionCode(funcCode);
        }

        public Boolean updateFunctionCodeByCode(string func_code, string func_name)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                FunctionCode funcCode = functionCodeDao.getFunctionCode(conn, true, func_code);
                funcCode.Func_Name = func_name;
                functionCodeDao.updateUser(conn, funcCode);

                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed From UASFNC [func_code:{0}]", func_code, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean deleteFunctionCodeByCode(string func_code)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                functionCodeDao.deleteFunctionCodeByCode(conn, func_code);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete Failed from UASFNC [func_code:{0}]", func_code, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public List<FunctionCode> loadAllFunctionCode()
        {
            DBConnection conn = null;
            List<FunctionCode> rtnCodeList = new List<FunctionCode>();
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnCodeList = functionCodeDao.loadAllFunctionCode(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load Function Code Failed from UASFNC", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnCodeList;
        }

        public Boolean createUserFunc(string user_id, string func_code)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                UserFunc userFunc = new UserFunc();
                userFunc.UserFuncPK.User_GRP = user_id.Trim();
                userFunc.UserFuncPK.Func_Code = func_code.Trim();

                userFuncDao.createUserFunc(conn, userFunc);

                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert User Function Failed to UASUFNC [user_id:{0}][func_code:{1}]",
                    user_id, func_code, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean deleteUserFunc(string user_id, string func_code)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                UserFunc userFunc = new UserFunc();
                userFunc.UserFuncPK.User_GRP = user_id.Trim();
                userFunc.UserFuncPK.Func_Code = func_code.Trim();
                userFuncDao.deleteUserFunc(conn, userFunc);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete User Function Failed from UASUFNC [user_id:{0}][func_code:{1}]",
                    user_id, func_code, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean registerUserFunc(string user_id, List<string> funcCodeList)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userFuncDao.deleteUserFuncByUserID(conn, user_id);
                foreach (string funcCode in funcCodeList)
                {
                    userFuncDao.createUserFunc(conn,
                        new UserFunc
                        {
                            UserFuncPK = new UserFuncPKInfo { User_GRP = user_id, Func_Code = funcCode }
                        });
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Register User Function Failed to UASUFNC [user_id:{0}]",
                    user_id, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public List<UserFunc> loadUserFuncByUser(string user_id)
        {
            List<UserFunc> rtnList = new List<UserFunc>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnList = userFuncDao.loadUserFuncByUserID(conn, user_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Function Failed from UASUFNC [user_id:{0}]",
                    user_id, ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnList;
        }

        public Boolean checkUserPassword(string user_id, string password)
        {
            DBConnection conn = null;
            Boolean result = false;
            try
            {
                //conn = scApp.getDBConnection();
                //conn.BeginTransaction();
                //User loginUser = userDao.getUser(conn, false, user_id);
                //if (loginUser == null)
                //{
                //    result = false;
                //}
                //else if (SCUtility.isMatche(loginUser.Passwd, password))
                //{
                //    result = true;
                //}
                //conn.Commit();
                if (SCUtility.isMatche(user_id, ConfigurationManager.AppSettings["EAP_UserID"]) && SCUtility.isMatche(password, ConfigurationManager.AppSettings["EAP_Password"]))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Function Failed from UASUFNC [user_id:{0}]",
                    user_id, ex);
                result = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return result;
        }

        public Boolean checkUserAuthority(string user_id, string function_code)
        {
            //DBConnection conn = null;
            Boolean result = true;
            try
            {
                //conn = scApp.getDBConnection();
                //conn.BeginTransaction();
                //User loginUser = userDao.getUser(conn, false, user_id);
                //if (loginUser == null)
                //{
                //    result = false;
                //}
                //else if (loginUser.isDisable())
                //{
                //    result = false;
                //}
                //else if (loginUser.isPowerUser())
                //{
                //    result = true;
                //}
                //else
                //{
                //    UserFunc userFunc = userFuncDao.getUserFunc(conn, loginUser.User_Grp, function_code);
                //    if (userFunc == null)
                //    {
                //        result = false;
                //    }
                //}
                //conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Function Failed from UASUFNC [user_id:{0}]",
                    user_id, ex);
                result = false;
            }
            finally
            {
                //if (conn != null) { try { conn.Close(); } catch { } }
            }
            return result;
        }

        public List<UserFunc> getUserFuncs(string user_id)
        {
            DBConnection conn = null;
            List<UserFunc> rtnUserFuncLst = null;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                User loginUser = userDao.getUser(conn, false, user_id);

                if (loginUser == null)
                {
                    rtnUserFuncLst = null;
                }
                else if (loginUser.isDisable())
                {
                    rtnUserFuncLst = null;
                }
                else if (loginUser.isPowerUser())
                {
                    List<FunctionCode> funcCodeLst = functionCodeDao.loadAllFunctionCode(conn);

                    foreach(FunctionCode funCode in funcCodeLst)
                    {
                        UserFunc userFunc = new UserFunc();
                        userFunc.UserFuncPK.User_GRP = loginUser.User_Grp;
                        userFunc.UserFuncPK.Func_Code = funCode.Func_Code;

                        rtnUserFuncLst.Add(userFunc);
                    }
                }
                else
                {
                    rtnUserFuncLst = userFuncDao.loadUserFuncByUserID(conn, loginUser.User_Grp);
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Function Failed from UASUFNC [user_id:{0}]", user_id, ex);

                rtnUserFuncLst = null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnUserFuncLst;
        }

        public UserFunc getUserFUNC(string user_id, string function_code)
        {
            DBConnection conn = null;
            UserFunc userFunc = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userFunc = userFuncDao.getUserFunc(conn, user_id, function_code);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load User Function Failed from UASUFNC [user_id:{0}]",
                    user_id, ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return userFunc;
        }

        public List<UserGroup> loadAllUserGroup()
        {
            DBConnection conn = null;
            List<UserGroup> userGrp = new List<UserGroup>();
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userGrp = userGroupDao.loadAllUserGroup(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Load All User Group Function Failed from UASUFNC ", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return userGrp;
        }

        public Boolean addUserGroup(string user_grp)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                UserGroup userGrp = new UserGroup();
                userGrp.User_Grp = user_grp.Trim();
                userGroupDao.insertUserGroup(conn, userGrp);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Add User Group Failed from UASUFNC [user_grp:{0}]",
                    user_grp, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean deleteUserGroup(string user_grp)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                userGroupDao.deleteUserGroupByID(conn, user_grp);
                userGroupDao.updateUser_ClearGroupByGroupName(conn, user_grp);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete User Group Failed from UASUFNC [user_grp:{0}]",
                    user_grp, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

    }
}
