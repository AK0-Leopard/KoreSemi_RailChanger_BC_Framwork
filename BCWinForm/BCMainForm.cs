//*********************************************************************************
//      BCMainForm.cs
//*********************************************************************************
// File Name: BCMainForm.cs
// Description: BC Main Form
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bc.winform.App;
using com.mirle.ibg3k0.bc.winform.Common;
using com.mirle.ibg3k0.bc.winform.UI;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.VO;
using Microsoft.Win32;
using MirleGO_UIFrameWork.UI.uc_Button;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RailChanger_Viewer;

namespace com.mirle.ibg3k0.bc.winform
{
    public partial class BCMainForm : Form
    {
        //*******************公用參數設定*******************
        private static Logger mpcTipMsgLog = LogManager.GetLogger("MPCTipMessageLog");
        private static Logger masterPCMemoryLog = LogManager.GetLogger("MasterPCMemory");
        private static Logger logger = LogManager.GetCurrentClassLogger();

        string BC_ID = "";

        private BCApplication bcApp = null;
        private About bcAbout = null;

        Dictionary<String, Form> openForms = new Dictionary<string, Form>();  //A0.01
        CommonInfo ci;
        Line line;
        SerialPort SerialPort_BadgeCode = null;
        //*******************公用參數設定*******************

        public BCApplication BCApp
        {
            get { return bcApp; }
        }

        private void setInfo(Label setLable, Color setColor, Color setForeColor)
        {
            try
            {
                setLable.BackColor = setColor;
                setLable.ForeColor = setForeColor;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void setInfo(Label setLable, string setText, Color setColor, Color setForeColor)
        {
            try
            {
                setLable.Text = setText;
                setLable.BackColor = setColor;
                setLable.ForeColor = setForeColor;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //建構子
        public BCMainForm(string bcid)
        {
            try
            {
                InitializeComponent();

                Adapter.Initialize();

                BC_ID = bcid;

                Application.AddMessageFilter(new GlobalMouseHandler());

                notifyIcon1.Text = ConfigurationManager.AppSettings.Get("BC_ID");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //去除子畫面白框的問題
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                var mdiclient = this.Controls.OfType<MdiClient>().Single();
                this.SuspendLayout();
                mdiclient.SuspendLayout();
                var hdiff = mdiclient.Size.Width - mdiclient.ClientSize.Width;
                var vdiff = mdiclient.Size.Height - mdiclient.ClientSize.Height;
                var size = new Size(mdiclient.Width + hdiff, mdiclient.Height + vdiff);
                var location = new Point(mdiclient.Left - (hdiff / 2), mdiclient.Top - (vdiff / 2));
                mdiclient.Dock = DockStyle.None;
                mdiclient.Size = size;
                mdiclient.Location = location;
                mdiclient.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                mdiclient.ResumeLayout(true);
                this.ResumeLayout(true);
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //介面載入
        private void BCMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(cpuMemoryMonitor), null);

                ProgressBarDialog progress = new ProgressBarDialog(bcApp);
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(callBackDoInitialize), progress);
                if (progress != null && !progress.IsDisposed)
                {
                    progress.ShowDialog();
                }

                //openForm("AGC_Mainform");  //A0.01

                BCUtility.doLogout(bcApp);

                Refresh();

                //跳出使用者登入畫面
                //BCUtility.doLogin(this, bcApp);

                //Task.Run(() => { SCApplication.getInstance().updateTraceCountToExcel(true); });

                bcApp.addRefreshUIDisplayFun(this.Name, delegate (object o) { BCUtility.UpdateUIDisplayByAuthority(bcApp, this); });
                BCUtility.UpdateUIDisplayByAuthority(bcApp, this);

                RailChanger_Viewer.App wpfwindow = new RailChanger_Viewer.App();
            }
            catch (Exception ex)
            {
                TipMessage_Type.Show(String.Format("Exception: {0}", ex), BCAppConstants.ERROR_MSG);
            }
        }

        //初始化UI
        private void initUI()
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private class comboData
        {
            public string Name { get; set; }
            public string RptValue { get; set; }
        }

        private void callBackDoInitialize(Object status)
        {
            #region 系統載入等待介面
            ProgressBarDialog progress = status as ProgressBarDialog;
            Adapter.Invoke(new SendOrPostCallback((o1) =>
            {
                progress.Begin();
                progress.SetText("Loading...");
            }), null);
            #endregion 系統載入等待介面

            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    this.notifyIcon1.Visible = true;
                    //this.Hide();
                }), null);

                bcApp = BCApplication.getInstance();

                bcApp.SCApplication.enableAllevent();

                line = bcApp.SCApplication.getEQObjCacheManager().getLine();

                ci = bcApp.SCApplication.getEQObjCacheManager().CommonInfo;

                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    registerEvent();
                    initUI();
                }), null);
                //必須等到UI Event註冊完成後，才可以開啟通訊界面
                Thread.Sleep(2000);
                bcApp.startProcess();
            }
            catch (Exception ex)
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    TipMessage_Type.Show(ex.ToString(), BCAppConstants.ERROR_MSG);
                }), null);
            }
            finally
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    if (progress != null) { progress.End(); }
                }), null);
            }
        }

        private void cpuMemoryMonitor(object obj)
        {
            while (true)
            {
                System.Diagnostics.Process ps = System.Diagnostics.Process.GetCurrentProcess();
                try
                {
                    PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", ps.ProcessName);
                    PerformanceCounter pf2 = new PerformanceCounter("Process", "Working Set", ps.ProcessName);

                    masterPCMemoryLog.Debug("{0}:{1}  {2:N}KB", ps.ProcessName, "工作集(Process)", ps.WorkingSet64 / 1024);
                    masterPCMemoryLog.Debug("{0}:{1}  {2:N}KB", ps.ProcessName, "工作集        ", pf2.NextValue() / 1024);
                    masterPCMemoryLog.Debug("{0}:{1}  {2:N}KB", ps.ProcessName, "私有工作集    ", pf1.NextValue() / 1024);
                }
                catch (Exception) { }

                Thread.Sleep(10000);
            }
        }

        private void registerEvent()
        {
            try
            {
                string Handler = this.Name;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        public class TypeSwitch
        {
            Dictionary<Type, Action<object, bool>> matches = new Dictionary<Type, Action<object, bool>>();
            public TypeSwitch Case<T>(Action<T, bool> action) { matches.Add(typeof(T), (x, enabled) => action((T)x, enabled)); return this; }
            public void Switch(object x, bool enabled)
            {
                if (x == null)
                {
                }
                if (matches.ContainsKey(x.GetType()))
                    matches[x.GetType()](x, enabled);
                else
                    logger.Warn("Switch Type:[{0}], Not exist!!!", x.GetType().Name);
            }
        }

        private void confirmOPCall(Object obj)
        {
            string OPCallID = obj as string;
        }

        private void popupOperatorCallDialog(string OPCallID)
        {
            Adapter.BeginInvoke(new SendOrPostCallback((o1) =>
            {
                DialogResult result = MessageBox.Show(this, line.OperatorCall, "Operator Call");

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(
                    new System.Threading.WaitCallback(confirmOPCall), OPCallID);
                }

            }), null);
        }

        private void PLCDataErrorCall(string message)
        {
            BCFApplication.onErrorMsg("PLC Data Have Error", message);
        }

        private void doStartConnection(object status)
        {
            ProgressBarDialog progress = status as ProgressBarDialog;
            progress.Begin();
            progress.SetText(BCApplication.getMessageString("START_CONNECTING"));
            bcApp.startProcess();

            //Do something...

            progress.End();
        }

        private void doStopConnection(object status)
        {
            ProgressBarDialog progress = status as ProgressBarDialog;
            progress.Begin();
            progress.SetText(BCApplication.getMessageString("STOP_CONNECTING"));

            bcApp.stopProcess();

            //Do something...

            progress.End();
        }

        public string getMessageString(string key, params object[] args)
        {
            return SCApplication.getMessageString(key, args);
        }

        private void BCMainForm_FormClosing_New(object sender, FormClosingEventArgs e)
        {
            bool hasProcessCmd = false;
            string eqid = string.Empty;
            string portid = string.Empty;
            string glass_count = string.Empty;
            string tipMessage = string.Empty;
            DialogResult confirmResult;


            #region 1.初步詢問是否要關閉MPC
            tipMessage = BCApplication.getMessageString("Confirm_Close_BC");
            confirmResult = TipMessage_Request.Show(tipMessage);
            recordAction(tipMessage, confirmResult.ToString());
            if (confirmResult != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region 2.檢查是否有執行中命令
            
            #endregion

            if (!BCUtility.doLogin(this, bcApp, BCAppConstants.FUNC_CLOSE_BC, true, BCUtility.LoginType.ExitCheck))
            {
                e.Cancel = true;
                recordAction("Close BC, Authority Check...", "Failed !!");
                return;
            }
            recordAction("Close BC, Authority Check...", "Success !!");

            if (e.Cancel == false)
            {

                try
                {
                    ProgressBarDialog progress = new ProgressBarDialog(bcApp);
                    System.Threading.ThreadPool.QueueUserWorkItem(
                        new System.Threading.WaitCallback(doStopConnection), progress);
                    this.notifyIcon1.Visible = false;
                    if (progress != null && !progress.IsDisposed)
                    {
                        progress.ShowDialog();
                    }
                }
                catch (Exception ex) { }
            }
            SCApplication.getInstance().updateTraceCountToExcel(false);
        }

        private void recordAction(string tipMessage, string confirmResult)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(tipMessage);
                sb.AppendLine(string.Format("{0}         ConfirmResult:{1}", new string(' ', 5), confirmResult));
                bcApp.SCApplication.BCSystemBLL.addOperationHis(bcApp.LoginUserID, this.Name, sb.ToString());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void recordAction(string message)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(message);

                bcApp.SCApplication.BCSystemBLL.addOperationHis(bcApp.LoginUserID, this.Name, sb.ToString());
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //變更系統菜單介面風格
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                try
                {

                    //宣告1個矩形物件，並定義起始位置與大小
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    //Color c = e.Item.Selected ? Color.FromArgb(103, 173, 249) : Color.FromArgb(28, 132, 247);

                    ToolStripItem item = e.Item;
                    ToolStrip toolstrip = e.ToolStrip;

                    if (toolstrip is MenuStrip)
                    {
                        Color c = e.Item.Selected ? BCAppConstants.RGBColor.Menu_SelectedColor : BCAppConstants.RGBColor.Menu_BackColor;
                        //使用筆刷來填滿矩形
                        using (SolidBrush brush = new SolidBrush(c))
                            e.Graphics.FillRectangle(brush, rc);
                    }
                    else if (toolstrip is ToolStripDropDown)
                    {
                        Color c;
                        //Color c = e.Item.Selected ? BCAppConstants.RGBColor.SubMenu_SelectedColor : BCAppConstants.RGBColor.SubMenu_BackColor;

                        if (e.Item.Enabled)
                        {
                            if (e.Item.Selected)
                            {
                                c = BCAppConstants.RGBColor.SubMenu_SelectedColor;
                            }
                            else
                            {
                                c = BCAppConstants.RGBColor.SubMenu_BackColor;
                            }
                        }
                        else
                        {
                            c = Color.White;
                        }


                        using (SolidBrush brush = new SolidBrush(c))
                            e.Graphics.FillRectangle(brush, rc);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception");
                }
            }

            //變更Menu子項目文字顏色 (不變更Menu父項目文字顏色)
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                try
                {
                    var toolstrip = e.Item;
                    if (toolstrip is ToolStripMenuItem)
                    {
                        if ((toolstrip as ToolStripMenuItem).Owner is MenuStrip)
                        {
                        }
                        else
                        {
                            if (toolstrip.Selected)
                            {
                                toolstrip.ForeColor = Color.White;
                            }
                            else
                            {
                                toolstrip.ForeColor = Color.FromArgb(9, 0, 45);
                            }
                        }
                    }
                    base.OnRenderItemText(e);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception");
                }
            }

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void BCMainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.notifyIcon1.Visible = true;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }

        public void openForm(String formID)
        {
            openForm(formID, false, false);
        }

        /// <summary>
        /// 開啟一般視窗 所使用
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="isPopUp"></param>     //ispopup using new form, others using MDIfrom. 
        /// <param name="forceConfirm"></param>   //?? Require user react the form at first.
        public void openForm(String formID, Boolean isPopUp, Boolean forceConfirm)
        {
            Form form;

            if (openForms.ContainsKey(formID))  //Form is Opened.
            {

                form = (Form)openForms[formID];
                if (isPopUp)
                {
                    form.Activate();
                    if (forceConfirm)
                    {
                        form.Close();
                        if (form != null && !form.IsDisposed) { form.Dispose(); }   //Disposed form
                        removeForm(formID);
                        openForm(formID, isPopUp, forceConfirm);   // reopen the form
                        return;
                    }
                    else
                    {
                        form.Show();
                    }
                    form.Focus();
                }
                else  //not popup form
                {
                    form.Activate();
                    form.Show();
                    form.Focus();
                    form.AutoScroll = true;
                    form.WindowState = FormWindowState.Maximized;
                }

                if (form.MdiParent != null)
                {
                    form.MdiParent.Refresh();
                }
            }
            else   //Form not Opened.
            {
                try
                {
                    Type t = Type.GetType(String.Format("com.mirle.ibg3k0.bc.winform.UI.{0}", formID));
                    Object[] args = { this };
                    form = (Form)Activator.CreateInstance(t, args);
                    openForms.Add(formID, form);
                    if (isPopUp)
                    {
                        if (forceConfirm)
                        {
                            form.ShowDialog();
                        }
                        else
                        {
                            form.Show();
                        }
                        form.Focus();
                    }
                    else
                    {
                        if (!form.IsMdiContainer)
                        {
                            form.MdiParent = this;
                        }

                        form.Visible = false;
                        form.Show();
                        form.Focus();
                        form.AutoScroll = true;
                        form.WindowState = FormWindowState.Normal;
                        form.WindowState = FormWindowState.Maximized;
                        form.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("BCMainForm.cs.cs has Error[Error method:{0}],[Error Message:{1}",
                    "openForm", ex.ToString());
                    TipMessage_Type.Show("This fuction is not enable", BCAppConstants.WARN_MSG);

                }
            }
        }

        public void removeForm(String formID)
        {
            if (openForms.ContainsKey(formID))
            {
                openForms[formID].Dispose();
                openForms.Remove(formID);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openForm(typeof(MQTestPanel).Name, true, false);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

    }

    public delegate void MouseMovedEvent();

    public class GlobalMouseHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;
        private System.Drawing.Point previousMousePosition = new System.Drawing.Point();
        public static event EventHandler<MouseEventArgs> MouseMovedEvent = delegate { };

        #region IMessageFilter Members

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                System.Drawing.Point currentMousePoint = Control.MousePosition;
                if (previousMousePosition != currentMousePoint)
                {
                    previousMousePosition = currentMousePoint;
                    MouseMovedEvent(this, new MouseEventArgs(MouseButtons.None, 0, currentMousePoint.X, currentMousePoint.Y, 0));
                }
            }
            // Always allow message to continue to the next filter control
            return false;
        }

        #endregion
    }

}