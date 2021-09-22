//*********************************************************************************
//      PortDetailInformation.cs
//*********************************************************************************
// File Name: PortDetailInformation.cs
// Description: Port Detail Information for AGC
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
    public partial class PortDetailInformation : UserControl
    {
        #region 全域變數
        Port voPort = null;
        SCApplication scApp = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        string sPORTID = string.Empty;
        Dictionary<String, String> port_cmd = new Dictionary<string, string>();
        #endregion 全域變數

        //建構子
        public PortDetailInformation()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }


        public void updatePortDetail(string _portid)
        {
            try
            {
                scApp = SCApplication.getInstance();
                voPort = scApp.getEQObjCacheManager().getPortByPortID(_portid);
                if (voPort != null)
                {
                    setPortDetailInformation_AGC(voPort);
                }
                else
                {
                    setPortDetailInformation_AGC(voPort);
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //更新Port狀態
        public void setPortDetailInformation_AGC(Port voPort)
        {
            try
            {
                if (voPort != null)
                {
                    lb_CarrierID_Value.Text = "Carrier ID : " + voPort.MPLC_Crr_ID.Trim();
                    lb_TicketNo_Value.Text = voPort.Ticket_No;
                    lb_CstType_Value.Text = voPort.Cst_Type.ToString();
                    lb_CSTCondition_Value.Text = voPort.Cst_Condition.ToString();
                    lb_ModelName_Value.Text = voPort.Model_Name;
                    lb_PortNoTo_Value.Text = voPort.To_PortNo;
                    lb_TransferPriority_Value.Text = voPort.Priority.ToString();
                    lb_ZoneCode_Value.Text = voPort.Zone_Code.ToString();
                    lb_N1CSTID_Value.Text = voPort.Cst1_ID;
                    lb_N1GLSQty_Value.Text = voPort.Cst1_Qty.ToString();
                    lb_N2CSTID_Value.Text = voPort.Cst2_ID;
                    lb_N2GLSQty_Value.Text = voPort.Cst2_Qty.ToString();
                    lb_N3CSTID_Value.Text = voPort.Cst3_ID;
                    lb_N3GLSQty_Value.Text = voPort.Cst3_Qty.ToString();
                    lb_InventoryCarrier_Value.Text = voPort.Inventory_Crr.ToString();
                    lb_TransferSpeed_Value.Text = voPort.Speed.ToString();
                }
                else
                {
                    lb_CarrierID_Value.Text = "Carrier ID : --";
                    lb_TicketNo_Value.Text = "";
                    lb_CstType_Value.Text = "";
                    lb_CSTCondition_Value.Text = "";
                    lb_ModelName_Value.Text = "";
                    lb_PortNoTo_Value.Text = "";
                    lb_TransferPriority_Value.Text = "";
                    lb_ZoneCode_Value.Text = "";
                    lb_N1CSTID_Value.Text = "";
                    lb_N1GLSQty_Value.Text = "";
                    lb_N2CSTID_Value.Text = "";
                    lb_N2GLSQty_Value.Text = "";
                    lb_N3CSTID_Value.Text = "";
                    lb_N3GLSQty_Value.Text = "";
                    lb_InventoryCarrier_Value.Text = "";
                    lb_TransferSpeed_Value.Text = "";
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //資訊設定
        private void setInfo(Label setLable, string setData)
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
    }
}
