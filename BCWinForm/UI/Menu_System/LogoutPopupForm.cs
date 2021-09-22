//*********************************************************************************
//      LogoutPopupForm.cs
//*********************************************************************************
// File Name: UserDao.cs
// Description: User DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date               Author           Request No.    Tag               Description
// ----------------   ----------------   ----------------   ----------------   ----------------
// 2017/05/09    Boan Chen     N/A               Initial              新增Logout畫面。
// 2017/06/13    Boan Chen     N/A               A0.01             變更預設按鈕為Logout。
// 2018/03/21    Boan Chen     N/A               A0.02             套用新UI設計。
// 2018/04/09    Boan Chen    N/A                 A0.03             移除套用CSKIN的按鈕，改採自行繪製的按鈕。
// 2018/12/13    Boan Chen    N/A                 A0.01           新增介面外框(黑色)。
//**********************************************************************************

using com.mirle.ibg3k0.bc.winform.App;
using com.mirle.ibg3k0.bc.winform.Common;
using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace com.mirle.ibg3k0.bc.winform.UI
{
    public partial class LogoutPopupForm : Form
    {
        private BCApplication bcApp = null;
        private string function_code = null;
        BCMainForm mainForm = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LogoutPopupForm(string function_code)
            : this(function_code, false)
        {
            
        }

        public LogoutPopupForm(string function_code, Boolean withDifferentAccount)
        {
            InitializeComponent();
            this.function_code = function_code;
            bcApp = BCApplication.getInstance();
            lbl_FormTitle.Text = BCApplication.getMessageString("User_Logout");

            //uc_btn_Yes.FocusButton();
            uc_btn_Yes.YesButton_Click += LogoutBtn_Click;

            uc_btn_No.NoButton_Click += CloseBtn_Click;
            btn_Close_X.CloseButton_Click += CloseBtn_Click;

        }

        private void LogoutPopupForm_Load(object sender, EventArgs e)
        {
            uc_btn_Yes.Select();
        }


        public string getLoginUserID()
        {
            return bcApp.LoginUserID;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
      
            DialogResult = DialogResult.OK;
            BCUtility.doLogout(bcApp);
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        Point lastPoint;
        private void UIForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void UIForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        public void btnClose(object sender, EventArgs e)
        {
            try
            {
                CloseBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void LogoutPopupForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Control c = this.GetContainerControl().ActiveControl;
                    
                    if (c.Name == uc_btn_Yes.Name)
                    {
                        LogoutBtn_Click(sender, e);
                    }
                    //else if (c.Name == closeButton_UserControl1.Name)
                    //{
                    //    CloseBtn_Click(sender, e);
                    //}
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }
        

    }
}
