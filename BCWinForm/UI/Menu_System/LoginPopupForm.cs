//*********************************************************************************
//      LoginPopupForm.cs
//*********************************************************************************
// File Name: UserDao.cs
// Description: User DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date                      Author                  Request No.        Tag                        Description
// ---------------     ---------------     ---------------     ---------------     ------------------------------
// 2018/10/11         Boan Chen           N/A                       N/A                       Initial。
// 2018/12/13         Boan Chen           N/A                       A0.01                    新增介面外框(黑色)。
//**********************************************************************************

using com.mirle.ibg3k0.bc.winform.App;
using com.mirle.ibg3k0.bcf.Common;
using MirleGO_UIFrameWork.UI.uc_Button;
using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace com.mirle.ibg3k0.bc.winform.UI.UAS
{
    public interface ILoginInfo
    {
        string getLoginUserID();
        string getLoginPassword();
    }
    public partial class LoginPopupForm : Form, ILoginInfo
    {
        //*******************公用參數設定*******************
        private BCApplication bcApp = null;
        private string function_code = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        //*******************公用參數設定*******************

        //建構子
        public LoginPopupForm(string function_code) : this(function_code, false)
        {

        }

        //建構子
        public LoginPopupForm(string function_code, Boolean withDifferentAccount)
        {
            InitializeComponent();
            this.function_code = function_code;
            bcApp = BCApplication.getInstance();

            if (withDifferentAccount)
            {
                lbl_FormTitle.Text =
                    BCApplication.getMessageString("Login_With_Other_Account");
                this.Text = BCApplication.getMessageString("Login_With_Other_Account");
            }
            else
            {
                lbl_FormTitle.Text =
                    BCApplication.getMessageString("User_Login");
                this.Text = BCApplication.getMessageString("User_Login");
            }

            UserIDTBx.Text = BCAppConstants.LOGIN_USER_DEFAULT;

            loginButton_UserControl1.LoginButton_Click += btnLogin_Click;
            btn_Close.CloseButton_Click += CloseBtn_Click;
        }

        //介面載入
        private void LoginPopupForm_Load(object sender, EventArgs e)
        {
            try
            {
                PwdTBx.Select();        //將游標指定在密碼位置

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        public string getLoginUserID()
        {
            return UserIDTBx.Text;
        }

        public string getLoginPassword()
        {
            if (BCFUtility.isMatche(PwdTBx.Text, ""))
            {
                //TipMessage.Show("Please input password.");
                TipMessage_Type.Show("Please input password.", BCAppConstants.WARN_MSG);
            }

            return PwdTBx.Text;
        }

        private void UserIDTBx_Click(object sender, EventArgs e)
        {
            try
            {
                UserIDTBx.Text = string.Empty;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void UserIDTBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.UserIDTBx.Text = this.UserIDTBx.Text.ToUpper();
                this.UserIDTBx.SelectionStart = this.UserIDTBx.Text.Length;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.No;
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void PwdTBx_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)//如果输入的是回车键
                {
                    btnLogin_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //加速介面開啟速度
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        //滑鼠移動介面
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PwdTBx_TextChanged(object sender, EventArgs e)
        {
            if (PwdTBx.Text != "")
            {
                loginButton_UserControl1.FocusButton();
            }
            else
            {
                loginButton_UserControl1.Un_FocusButton();
            }
        }

        private void LoginPopupForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Control c = this.GetContainerControl().ActiveControl;

                    if (c.Name == loginButton_UserControl1.Name)
                    {
                        btnLogin_Click(sender, e);
                    }
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
