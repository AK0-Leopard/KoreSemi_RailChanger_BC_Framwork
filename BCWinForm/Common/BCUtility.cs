//*********************************************************************************
//      BCAppConstants.cs
//*********************************************************************************
// File Name: BCAppConstants.cs
// Description: Type 1 Function
//
//(c) Copyright 2015, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bc.winform.App;
using com.mirle.ibg3k0.bc.winform.UI.UAS;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.bc.winform.UI.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using com.mirle.ibg3k0.bc.winform.UI;
using MirleGO_UIFrameWork.UI.uc_Button;

namespace com.mirle.ibg3k0.bc.winform.Common
{
    public class BCUtility
    {
        public static Boolean doLogout(BCApplication bcApp)
        {
            bcApp.logoff();
            return true;
        }

        public static Boolean doLogout(System.Windows.Forms.IWin32Window window, BCApplication bcApp)
        {
            string loginUserID = bcApp.LoginUserID;
            Boolean hasLogout = false;
            LogoutPopupForm loginForm = new LogoutPopupForm(BCAppConstants.FUNC_LOGOUT);
            System.Windows.Forms.DialogResult result = loginForm.ShowDialog(window);
            loginUserID = loginForm.getLoginUserID();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                hasLogout = true;
                loginForm.Dispose();
            }
            else
            {
                hasLogout = false;
                loginForm.Dispose();
            }
            return hasLogout;
        }

        public static Boolean isLogin(BCApplication bcApp)
        {
            string loginUserID = bcApp.LoginUserID;
            if (SCUtility.isEmpty(loginUserID))
            {
                return false;
            }
            return true;
        }

        public static Boolean loginAsAdmin(BCApplication bcApp)
        {
            User admin = bcApp.SCApplication.UserBLL.getAdminUser();
            if (admin == null)
            {
                return false;
            }
            bcApp.login(admin);
            return true;
        }

        /// <summary>
        /// 單純進行Login動作
        /// </summary>
        /// <param name="window"></param>
        /// <param name="bcApp"></param>
        /// <returns></returns>
        public static Boolean doLogin(System.Windows.Forms.IWin32Window window, BCApplication bcApp)
        {
            string loginUserID = bcApp.LoginUserID;
            Boolean hasAuth = false;
            if (!SCUtility.isEmpty(loginUserID))
            {
                TipMessage_Type.Show(BCApplication.getMessageString("Already_Login"), BCAppConstants.WARN_MSG);

                return false;
            }
            LoginPopupForm loginForm = new LoginPopupForm(BCAppConstants.FUNC_LOGIN);
            System.Windows.Forms.DialogResult result = loginForm.ShowDialog(window);
            loginUserID = loginForm.getLoginUserID();
            
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                loginForm.Dispose();
            }
            else
            {
                loginForm.Dispose();
                return false;
            }

            string loginPassword = loginForm.getLoginPassword();
            Boolean loginSuccess = false;
            if (!SCUtility.isEmpty(loginUserID))
            {
                loginSuccess = bcApp.SCApplication.UserBLL.checkUserPassword(loginUserID, loginPassword);
            }
            if (loginSuccess)
            {
                hasAuth = bcApp.SCApplication.UserBLL.checkUserAuthority(loginUserID, BCAppConstants.FUNC_LOGIN);
                if (hasAuth)
                {
                    bcApp.login(loginUserID);
                }
            }

            if (!hasAuth)
            {
                TipMessage_Type.Show(BCApplication.getMessageString("NO_AUTHORITY"), BCAppConstants.ERROR_MSG);
            }

            return hasAuth;
        }

        public static Boolean doLogin(System.Windows.Forms.IWin32Window window, BCApplication bcApp, string function_code, LoginType loginType = LoginType.LogIn)
        {
            return doLogin(window, bcApp, function_code, false, loginType);
        }


        public enum LoginType
        {
            LogIn,
            ExitCheck
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        /// <param name="bcApp"></param>
        /// <param name="function_code"></param>
        /// <returns></returns>
        public static Boolean doLogin(System.Windows.Forms.IWin32Window window, BCApplication bcApp, string function_code, bool isForceChack, LoginType loginType)
        {
            //return true;
            string loginUserID = bcApp.LoginUserID;
            Boolean hasAuth = false;
            if (!isForceChack && !SCUtility.isEmpty(loginUserID))
            {
                hasAuth = bcApp.SCApplication.UserBLL.checkUserAuthority(loginUserID, function_code);
            }

            if (hasAuth)
            {
                return true;
            }

            //如果已經有人登入了，就必須已切換帳號的方式再次登入
            Form loginForm = null;
            switch (loginType)
            {
                case LoginType.LogIn:
                    loginForm = new LoginPopupForm(function_code, isForceChack ? false : BCUtility.isLogin(bcApp));
                    break;
                case LoginType.ExitCheck:
                    loginForm = new ExitSystemPopupForm(function_code, isForceChack ? false : BCUtility.isLogin(bcApp));
                    break;
                default:
                    //todo: Log
                    return false;
            }
            
            System.Windows.Forms.DialogResult result = loginForm.ShowDialog(window);
            loginUserID = (loginForm as ILoginInfo).getLoginUserID();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                loginForm.Dispose();
            }
            else
            {
                loginForm.Dispose();
                return false;
            }
            Boolean loginSuccess = false;
            string loginPassword = (loginForm as ILoginInfo).getLoginPassword();
            if (!SCUtility.isEmpty(loginUserID))
            {
                loginSuccess = bcApp.SCApplication.UserBLL.checkUserPassword(loginUserID, loginPassword);
            }
            if (loginSuccess)
            {
                hasAuth = bcApp.SCApplication.UserBLL.checkUserAuthority(loginUserID, function_code);
                if (hasAuth)
                {
                    bcApp.login(loginUserID);
                }
            }

            if (!hasAuth)
            {
                TipMessage_Type.Show(BCApplication.getMessageString("NO_AUTHORITY"), BCAppConstants.ERROR_MSG);
            }

            return hasAuth;
        }

        public static Boolean doLoginByBadge(System.Windows.Forms.IWin32Window window, BCApplication bcApp, string badgeNo)
        {
            string loginUserID = bcApp.LoginUserID;
            Boolean hasAuth = false;
            if (!SCUtility.isEmpty(loginUserID))
            {
                TipMessage_Type.Show(BCApplication.getMessageString("Already_Login"), BCAppConstants.WARN_MSG);

                return false;
            }
            Boolean loginSuccess = false;
            User tmpUser = bcApp.SCApplication.UserBLL.getUserByBadge(badgeNo);
            if (!SCUtility.isEmpty(tmpUser))
            {
                loginUserID = tmpUser.User_ID;
                loginSuccess = true;
            }
            if (loginSuccess)
            {
                hasAuth = bcApp.SCApplication.UserBLL.checkUserAuthority(loginUserID, BCAppConstants.FUNC_LOGIN);
            }
            if (!hasAuth)
            {
                TipMessage_Type.Show(BCApplication.getMessageString("NO_AUTHORITY"), BCAppConstants.ERROR_MSG);
            }
            else
            {
                bcApp.login(loginUserID);
            }
            return hasAuth;
        }

        /// <summary>
        /// </summary>
        /// <param name="bcApp"></param>
        /// <param name="targetFormType"></param>
        public static void UpdateUIDisplayByAuthority(BCApplication bcApp, object targetFormType)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            MemberInfo[] memberInfos = targetFormType.GetType().GetMembers(flag);

            var typeSwitch = new com.mirle.ibg3k0.bc.winform.BCMainForm.TypeSwitch()
                .Case((System.Windows.Forms.ToolStripMenuItem tsm, bool tf) => { tsm.Enabled = tf; })
                .Case((System.Windows.Forms.ComboBox cb, bool tf) => { cb.Enabled = tf; })
                //.Case((com.mirle.ibg3k0.bc.winform.UI.Components_New.UserControl_Button bt, bool tf) => { bt.Enabled = tf; })
                .Case((System.Windows.Forms.PictureBox px, bool tf) => { px.Enabled = tf; })
                //.Case((System.Windows.Forms.Button btn, bool tf) => { btn.Enabled = tf; })
                .Case((CCWin.SkinControl.SkinButton btn, bool tf) => { btn.Enabled = tf; }) 
                .Case((uc_btn_Custom btn, bool tf) => { btn.Visible = tf; });
           
            foreach (MemberInfo memberInfo in memberInfos)
            {
                Attribute AuthorityCheck = memberInfo.GetCustomAttribute(typeof(AuthorityCheck));
                if (AuthorityCheck != null)
                {
                    string attribute_FUNName = ((AuthorityCheck)AuthorityCheck).FUNCode;
                    FieldInfo info = (FieldInfo)memberInfo;
                    if (bcApp.SCApplication.UserBLL.checkUserAuthority(bcApp.LoginUserID, attribute_FUNName))
                    {
                        typeSwitch.Switch(info.GetValue(targetFormType), true);
                    }
                    else
                    {
                        typeSwitch.Switch(info.GetValue(targetFormType), false);
                    }
                }
            }


        }
    }
}
