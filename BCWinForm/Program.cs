//*********************************************************************************
//      Program.cs
//*********************************************************************************
// File Name: AlarmBLL.cs
// Description: 業務邏輯：Alarm
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2016/01/12    Kevin Wei      N/A            A0.01   加入"UnhandledException"的Log紀錄。
// 2016/09/29    Steven Hong    N/A            A0.02   將所有Message Box換為自製元件
//**********************************************************************************
// 2017/06/22    Kevin Wei      N/A            B0.01   加入"UnhandledException(從畫面上發生時)"的Log紀錄。
// 2017/08/24    Kevin Wei      N/A            B0.02   加入BC Name 是否為Null的判斷。
// 2018/04/25    Boan Chen    N/A            B0.03   Tip Message樣式變更。
// 2019/05/21    Boan Chen    N/A            B0.04   新增多語言功能。
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.mirle.ibg3k0.bc.winform.UI;  //A0.02
using MirleGO_UIFrameWork.UI.uc_Button;
using com.mirle.ibg3k0.bc.winform.App;

namespace com.mirle.ibg3k0.bc.winform
{
    static class Program
    {
        static string appGuid = "{fds49f49sd-cc5b-4b38-894e-20210909}";

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex m = new Mutex(false, "Global\\" + appGuid))
            {
                //MessageBox.Show("Test 1.0.0.2");
                SCUtility.SystemEventLog("Start BC System!!", EventLogEntryType.Information);
                //檢查是否同名Mutex已存在(表示另一份程式正在執行)
                if (!m.WaitOne(0, false))
                {
                    Console.WriteLine("Only one instance is allowed!");
                    SCUtility.SystemEventLog("Can Not Execute Multiple BC System!!", EventLogEntryType.Warning);

                    //A0.02 var confirmResult = MessageBox.Show("Can Not Execute Multiple BC System!!",
                    //A0.02         "Confirm Exit BC System!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //var confirmResult = CMsgBox.Show("Can Not Execute Multiple BC System!!");  //A0.02  //A0.03
                    //var confirmResult = TipMessage.Show("Can NOT execute multiple BC System!!");  //A0.02  //A0.03
                    var confirmResult = TipMessage_Type.Show("Can NOT execute multiple BC System!!", BCAppConstants.ERROR_MSG);

                    return;
                }
                ////檢查是否有重複開啟BC System
                System.Diagnostics.Process crProcess = System.Diagnostics.Process.GetCurrentProcess();
                System.Diagnostics.Process[] myProcess = System.Diagnostics.Process.GetProcessesByName(crProcess.ProcessName);
                if (myProcess.Length > 1)
                {
                    SCUtility.SystemEventLog("Can NOT execute multiple BC System!!", EventLogEntryType.Warning);

                    //A0.02 var confirmResult = MessageBox.Show("Can Not Execute Multiple BC System!",
                    //A0.02         "Confirm Exit BC System!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //var confirmResult = CMsgBox.Show("Can Not Execute Multiple BC System!");  //A0.02  //A0.03
                    //var confirmResult = TipMessage.Show("Can NOT execute multiple BC System!");  //A0.02  //A0.03
                    var confirmResult = TipMessage_Type.Show("Can NOT execute multiple BC System!", BCAppConstants.ERROR_MSG);

                    return;
                }

                string bcName = Environment.GetEnvironmentVariable("BCNAME");
                Console.WriteLine("BCNAME:{0}", bcName);

                string argStr = SCUtility.stringListToString(" ", args.ToList());
                if (BCFUtility.isEmpty(argStr))
                {
                    args = new string[] { bcName };
                    argStr = bcName;
                }
                else
                {
                    bcName = args[0];
                }
                //B0.02 Start
                if (string.IsNullOrWhiteSpace(bcName))
                {
                    SCUtility.SystemEventLog("BC Name is Null Can't Execute MPC System", EventLogEntryType.Warning);
                    NLog.LogManager.GetCurrentClassLogger().Warn("BC Name is Null Can't Execute MPC System");
                    return;
                }
                //B0.02 End
                copyConfig(bcName);
                ConfigSystem.Install();
                string bc_tst = ConfigurationManager.AppSettings.Get("BC_ID");

                var wi = WindowsIdentity.GetCurrent();
                var wp = new WindowsPrincipal(wi);
                bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);
                if (!runAsAdmin)
                {
                    Console.WriteLine("Try change run as Admin.");
                    //A0.02 MessageBox.Show("Try Change Run As Admin.");

                    //CMsgBox.Show("Try Change Run As Admin.");  //A0.02    //B0.03
                    //TipMessage.Show("Try change run as Admin.");  //A0.02   //B0.03
                    TipMessage_Type.Show("Try change run as Admin.", BCAppConstants.ERROR_MSG);

                    var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);
                    processInfo.UseShellExecute = true;
                    processInfo.Verb = "runas";


                    processInfo.Arguments = argStr;
                    // Start the new process
                    try
                    {
                        Process.Start(processInfo);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Sorry, can't to start " +
                           "this program with administrator rights!");
                        //A0.02 MessageBox.Show("Sorry, can't to start " +
                        //A0.02    "this application with administrator rights!");

                        //CMsgBox.Show("Sorry, can't to start this application with administrator rights!");  //A0.02     //A0.03
                        //TipMessage.Show("Sorry, can't to start this application with administrator rights!");  //A0.02      //A0.03
                        TipMessage_Type.Show("Sorry, can't to start this application with administrator rights!", BCAppConstants.ERROR_MSG);

                    }
                    return;
                }

                AppDomain currentDomain = AppDomain.CurrentDomain;                                  //A0.12
                currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);  //A0.12
                Application.ThreadException += Application_ThreadException;                         //B0.01

                Localization.BuildMultiLanguageResources(bc_tst);     //B0.04

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BCMainForm(args[0]));
                SCUtility.SystemEventLog("Close BC System!!", EventLogEntryType.Information);
                Application.ExitThread();
                crProcess.Kill();
            }
        }

        //B0.01
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs args)
        {
            Exception e = args.Exception;
            NLog.LogManager.GetCurrentClassLogger().Error(e, "UnhandException - Application.ThreadException:");
        }

        /// <summary>
        /// //A0.12
        /// </summary>
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            NLog.LogManager.GetCurrentClassLogger().Error(e, "UnhandledException:");
        }

        private static void copyConfig(string bcid)
        {
            #region Copy App.Config to Run Time Dir
            string curDir = Environment.CurrentDirectory;
            string sourceFile = System.IO.Path.Combine(curDir, "Config", bcid, "App.Config");
            string destFile = System.IO.Path.Combine(curDir, "App.Config");
            System.IO.File.Copy(sourceFile, destFile, true);
            string exeName = Assembly.GetExecutingAssembly().GetName().Name;
            destFile = System.IO.Path.Combine(curDir, exeName + ".exe.config");
            System.IO.File.Copy(sourceFile, destFile, true);
            destFile = System.IO.Path.Combine(curDir, exeName + ".vshost.exe.config");
            System.IO.File.Copy(sourceFile, destFile, true);
            #endregion
        }
    }
}
