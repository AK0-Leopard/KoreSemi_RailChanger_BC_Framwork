//*********************************************************************************
//      About.cs
//*********************************************************************************
// File Name: About.cs
// Description: 顯示關於BC系統製作團隊的資訊
//
//(c) Copyright 2018, MIRLE Automation Corporation
//
// Date               Author             Request No.        Tag                Description
// ------------------ ------------------ ------------------ ------------------ ------------------
// 2018/10/04         Boan               N/A                N/A                Initialize.
// 2019/05/06         Boan               N/A                A0.01              變更"3AB Development_Intelligence System Division"為
//                                                                             "3K0 Automation & Intelligence System Business."
// 2019/05/09         Boan               N/A                A0.02              調整部門描述文字如下：
//                                                                             Intelligent Manufacturing Software System Div.
//                                                                             Automation &  Intelligence Business Group    
//                                                                             MIRLE Automation Corporation. All rights reserved
//**********************************************************************************

using com.mirle.ibg3k0.bc.winform.App;
using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace com.mirle.ibg3k0.bc.winform.UI
{
    public partial class About : Form
    {
        //*******************公用參數設定*******************
        private BCApplication bcApp = null;
        //*******************公用參數設定*******************

        //建構子
        public About(BCApplication bcApp)
        {
            this.bcApp = bcApp;

            InitializeComponent();

            uc_btn_CloseButton_X1.CloseButton_Click += btnClose_Click;
        }

        //介面載入
        private void About_Load(object sender, EventArgs e)
        {
            //System Version
            lbl_SofwVsion_Val.Text = "Version " + SCAppConstants.getMainFormVersion("");

            //System Build Date
            IFormatProvider culture = new CultureInfo("en-US", true);
            string dtBuildDate = SCAppConstants.GetBuildDateTime().ToString("yyyy.MM.dd hh:mm tt", culture);
            lbl_SofwBuildDate_Val.Text = bcApp.SCApplication.getBCFApplication().BC_ID + " Build " + dtBuildDate;

            //System Copyright
            lbl_copyright_Val1.Text = SCApplication.getMessageString("CopyrightsIllustration1");
            lbl_copyright_Val2.Text = SCApplication.getMessageString("CopyrightsIllustration2");
            lbl_copyright_Val3.Text = SCApplication.getMessageString("CopyrightsIllustration3");
        }

        //關閉按紐事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //滑鼠移動介面事件1
        Point lastPoint;
        private void About_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //滑鼠移動介面事件2
        private void About_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
