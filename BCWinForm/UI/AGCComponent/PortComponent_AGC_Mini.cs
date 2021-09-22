//*********************************************************************************
//      PortComponent_AGC_Mini.cs
//*********************************************************************************
// File Name: PortComponent_AGC_Mini.cs
// Description: Port Load 組件 for AGC
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date                      Author                  Request No.        Tag                        Description
// ---------------     ---------------     ---------------     ---------------     ------------------------------
// 2020/01/06         Boan Chen           N/A                       N/A                       Initial。
//**********************************************************************************

using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MirleGO_UIFrameWork.UI.Layout
{
    public partial class PortComponent_AGC_Mini : UserControl
    {
        #region 全域變數
        Port voPort = null;
        SCApplication scApp = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        string sPORTID = string.Empty;
        Dictionary<String, String> port_cmd = new Dictionary<string, string>();
        public event EventHandler CarrerID_Click;
        #endregion 全域變數

        //建構子
        public PortComponent_AGC_Mini()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        //控件啟動
        public void Start(string _portID, string _portRealID)
        {
            try
            {
                //取得SCApplication實例
                scApp = SCApplication.getInstance();

                //設定PORT ID
                setPortID(_portID);

                //取得PORT物件
                voPort = scApp.getEQObjCacheManager().getPortByPortID(_portRealID);

                if (voPort != null)
                {
                    //初始畫面
                    initialUI(voPort);

                    //新增監聽事件
                    addEventHandle(voPort);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //設定PORT ID
        public void setPortID(string PORTID)
        {
            try
            {
                setInfo(lbl_PortID_Title, PORTID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //初始畫面
        private void initialUI(Port _voPort)
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setCarrierID(_voPort.MPLC_Crr_ID);
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //新增監聽事件
        string sHandlerID = string.Empty;
        private void addEventHandle(Port _voPort)
        {
            try
            {
                _voPort.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => _voPort.MPLC_PortStat), (s1, e1) =>
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    setCarrierID(_voPort.MPLC_Crr_ID);
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
                        setInfo(lb_CarrierID_Value, "--");
                    }
                    else
                    {
                        setInfo(lb_CarrierID_Value, _carrierid);
                    }
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //資訊設定
        private void setInfo(Label setLable, string setData)
        {
            try
            {
                if (setData == null)
                {
                    return;
                }
                else
                {
                    setLable.Text = setData.Trim();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //點選Carrier ID，即更新Port Detail Information於畫面最右側
        private void lb_CarrierID_Value_Click(object sender, EventArgs e)
        {
            try
            {
                if (CarrerID_Click != null)
                {
                    CarrerID_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }






















        //public void refreshPortStatus(string _portid)
        //{
        //    try
        //    {
        //        setPortStatus_AGC();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception");
        //    }
        //}

        ////更新Port狀態
        //public void setPortStatus_AGC()
        //{
        //    try
        //    {
        //lb_TicketNo_Value.Text = voPort.Port_Cmd["Tick_NO"];
        //lb_CarrierID_Value.Text = voPort.Port_Cmd["CarrierID"];
        //lb_PortReqMode_Value.Text = voPort.Port_Cmd["Port_Request_Mode"];
        //lb_CstType_Value.Text = voPort.Port_Cmd["CST_Type"];
        //lb_CSTCondition_Value.Text = voPort.Port_Cmd["CST_Condition"];
        //lb_ModelName_Value.Text = voPort.Port_Cmd["Model_Name"];
        //lb_UnloadingProcessLotNo_Value.Text = voPort.Port_Cmd["CST1_LOT_NO"];
        //lb_UnloadingDate_Value.Text = voPort.Port_Cmd["DateTime"];
        //lb_PortNoTo_Value.Text = voPort.Port_Cmd["To_Port_NO"];
        //lb_TransferPriority_Value.Text = voPort.Port_Cmd["Priority"];
        //lb_ZoneCode_Value.Text = voPort.Port_Cmd["Zone_Code"];
        //lb_N1CSTID_Value.Text = voPort.Port_Cmd["CST1_ID"];
        //lb_N1GLSQty_Value.Text = voPort.Port_Cmd["CST1_QTY"];
        //lb_N2CSTID_Value.Text = voPort.Port_Cmd["CST2_ID"];
        //lb_N2GLSQty_Value.Text = voPort.Port_Cmd["CST2_QTY"];
        //lb_N3CSTID_Value.Text = voPort.Port_Cmd["CST3_ID"];
        //lb_N3GLSQty_Value.Text = voPort.Port_Cmd["CST3_QTY"];
        //lb_InventoryCarrier_Value.Text = voPort.Port_Cmd["Inventory_Carrier"];
        //lb_TransferSpeed_Value.Text = voPort.Port_Cmd["Transfer_Speed"];
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception");
        //    }
        //}

    }
}
