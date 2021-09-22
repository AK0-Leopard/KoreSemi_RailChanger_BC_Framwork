using System;
using System.Collections.Generic;
using System.ComponentModel;
//*********************************************************************************
//      EQPort.cs
//*********************************************************************************
// File Name: EQPort.cs
// Description: EQPort
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   修正起始資料
//**********************************************************************************

using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using com.mirle.ibg3k0.bcf.Common;
using System.Threading;

namespace com.mirle.ibg3k0.bc.winform.UI.AGCComponent_DEMO
{
    public partial class EQPort : UserControl
    {
        Port port = null;
        SCApplication scApp = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        public event EventHandler CST_Click;

        public EQPort()
        {
            InitializeComponent();
        }

        public bool isExitCST
        {
            get
            {
                return ExitCST.Visible;
            }
            set
            {
                ExitCST.Visible = value;
            }
        }

        //控件啟動
        public void Start(string _portID)
        {
            try
            {
                //取得SCApplication實例
                scApp = SCApplication.getInstance();

                //取得UNIT物件
                port = scApp.getEQObjCacheManager().getPortByPortID(_portID);

                if (port != null)
                {
                    //初始畫面
                    initialUI(port);

                    //新增監聽事件
                    addEventHandle(port);
                }
                else
                {
                    ExitCST.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //初始畫面
        private void initialUI(Port _Port)
        {
            try
            {
                //A0.01 Start
                string crr_id = string.Empty;
                if (_Port.MPLC_Crr_ID != null)
                {
                    crr_id = _Port.MPLC_Crr_ID.Trim();
                }
                //A0.01 End

                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    //A0.01 setCarrierID(_Port.MPLC_Crr_ID.Trim());
                    setCarrierID(crr_id);  //A0.01
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //新增監聽事件
        string sHandlerID = string.Empty;
        private void addEventHandle(Port _port)
        {
            try
            {
                _port.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => _port.MPLC_PortStat), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setCarrierID(_port.MPLC_Crr_ID);
                }), null));
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //設定Carrier ID
        private void setCarrierID(string _carrierid)
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    if (_carrierid == null || _carrierid == "")
                    {
                        ExitCST.Visible = false;
                    }
                    else
                    {
                        ExitCST.Visible = true;
                    }
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        private void ExitCST_Click(object sender, EventArgs e)
        {
            if (CST_Click != null)
            {
                CST_Click(sender, e);
            }
        }
    }
}
