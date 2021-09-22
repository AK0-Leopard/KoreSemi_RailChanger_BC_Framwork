//*********************************************************************************
//      BCApplication.cs
//*********************************************************************************
// File Name: BCApplication.cs
// Description: Type 1 Function
//
//(c) Copyright 2015, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2015/05/29    Kevin Wei      N/A            A0.01   加入當LogIn-User有改變時，會更新UI的顯示(決定按鈕要Enable/DisEnable)。
// 2015/08/10    Kevin Wei      N/A            A0.02   將會詢問是否要Recover DB中的資料回來拿掉。
// 2017/07/04    Steven Hong    N/A            A0.03   加入Line Status Map設定初始化。
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.mirle.ibg3k0.sc.App;
using NLog;
using com.mirle.ibg3k0.bcf.Common;
using System.Threading;
using com.mirle.ibg3k0.sc.Data.VO;

namespace com.mirle.ibg3k0.bc.winform.App
{
    public class BCApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private SCApplication scApp = null;
        public SCApplication SCApplication { get { return scApp; } }

        #region UAS
        private string loginUserID = null;
        public string LoginUserID { get { return loginUserID; } }
        private Dictionary<string, System.Windows.Forms.ToolStripStatusLabel> statusUserIDLabelDic =
            new Dictionary<string, System.Windows.Forms.ToolStripStatusLabel>();
        private Dictionary<string, Action<object>> refresh_UIDisplay_FunDic =
            new Dictionary<string, Action<object>>(); //A0.01
        #endregion UAS

        private static Form mainForm = null;

        private static BCApplication bcApp = null;
        private BCApplication()
        {
            try
            {
                init();
            }
            catch (Exception ex) 
            {
                logger.ErrorException("BCApplication Exception! ", ex);
                throw ;
            }
        }

        private static Object _lock = new Object();
        private static com.mirle.ibg3k0.bcf.App.BCFApplication.BuildValueEventDelegate buildValueFunc;
        public static BCApplication getInstance(Form _mainForm, 
            com.mirle.ibg3k0.bcf.App.BCFApplication.BuildValueEventDelegate _buildValueFunc)
        {
            mainForm = _mainForm;
            buildValueFunc = _buildValueFunc;
            return getInstance();
        }
        public static BCApplication getInstance()
        {
            lock (_lock)
            {
                if (bcApp == null)
                {
                    bcApp = new BCApplication();
                }
                return bcApp;
            }
        }

        private void init()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('=', 80));
            sb.AppendLine("Do BCApplication Initialize...");
            sb.AppendLine(new string('=', 80));
            logger.Info(sb.ToString());
            sb.Clear();
            sb = null;
            
            scApp = SCApplication.getInstance(buildValueFunc);
            Boolean recoverFromDB = false;
            //A0.02  if (scApp.canSelRevertSystem())
            //A0.02  {
            //A0.02      Adapter.Invoke(new SendOrPostCallback((o1) =>
            //A0.02      {
            //A0.02          DialogResult result = MessageBox.Show(mainForm,
            //A0.02          getMessageString("REVERTS_TO_PREVIOUS_STATUS"),
            //A0.02          getMessageString("CONFIRM"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //A0.02          if (result == DialogResult.Yes)
            //A0.02          {
            //A0.02              recoverFromDB = true;
            //A0.02          }
            //A0.02          else
            //A0.02          {
            //A0.02              recoverFromDB = false;
            //A0.02          }
            //A0.02      }), null);
            //A0.02  }
            try
            {
                scApp.startBuildEqpts(recoverFromDB);
            }
            catch (Exception ex) 
            {
                logger.ErrorException("startBuildEqpts Exception!", ex);
                throw ;
            }
        }

        public Boolean isStarted()
        {
            return scApp.Started;
        }

        public void startProcess()
        {
            scApp.start();
            scApp.startShareMemory();
            scApp.startSECSAgent();
        }

        public void startSECS() 
        {
            scApp.startSECSAgent();
        }

        public void stopProcess()
        {
            scApp.stop();
            scApp.stopShareMemory();
            scApp.stopSECSAgent();
        }

        public void stopSECS() 
        {
            scApp.stopSECSAgent();
        }

        public Form getMainForm()
        {
            return mainForm;
        }

        public static string getMessageString(string key, params object[] args)
        {
            return SCApplication.getMessageString(key, args);
        }

        #region UAS
        public void login(User user)
        {
            login(user.User_ID);
        }

        public void login(string user_id)
        {
            scApp.LoginUserID = user_id;
            loginUserID = user_id;
            refreshLoginUserInfo();
            refresh_UIDisplayFun();//A0.01
        }

        private void refreshLoginUserInfo() 
        {
            foreach (System.Windows.Forms.ToolStripStatusLabel label in statusUserIDLabelDic.Values)
            {
                try
                {
                    if (label == null || label.IsDisposed)
                    {
                        continue;
                    }
                    label.Text = loginUserID;
                }
                catch { }
            }
        }

        /// <summary>
        /// A0.01
        /// </summary>
        private void refresh_UIDisplayFun()
        {


            foreach (Action<object> action in refresh_UIDisplay_FunDic.Values)
            {
                try
                {
                    if (action == null)
                    {
                        continue;
                    }
                    action(new object());
                }
                catch { }
            }
        }
        public void logoff()
        {
            login("");
        }

        public void addUserToolStripStatusLabel(System.Windows.Forms.ToolStripStatusLabel label)
        {
            //statusUserIDLabelDic
            if (statusUserIDLabelDic.ContainsKey(label.Name))
            {
                statusUserIDLabelDic[label.Name] = label;
            }
            else
            {
                statusUserIDLabelDic.Add(label.Name, label);
            }
            refreshLoginUserInfo();
        }
        /// <summary>
        /// A0.01
        /// </summary>
        /// <param name="refreshFun"></param>
        public void addRefreshUIDisplayFun(Action<object> refreshFun)
        {
            //statusUserIDLabelDic
            if (refresh_UIDisplay_FunDic.ContainsKey(refreshFun.Method.Name))
            {
                refresh_UIDisplay_FunDic[refreshFun.Method.Name] = refreshFun;
            }
            else
            {
                refresh_UIDisplay_FunDic.Add(refreshFun.Method.Name, refreshFun);
            }
        }
        public void addRefreshUIDisplayFun(string formName, Action<object> refreshFun)
        {
            //statusUserIDLabelDic
            if (refresh_UIDisplay_FunDic.ContainsKey(formName))
            {
                refresh_UIDisplay_FunDic[formName] = refreshFun;
            }
            else
            {
                refresh_UIDisplay_FunDic.Add(formName, refreshFun);
            }
        }

        //public void addRe
        #endregion

    }
}
