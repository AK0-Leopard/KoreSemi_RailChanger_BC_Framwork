//*********************************************************************************
//      CarrierDetailInformation.cs
//*********************************************************************************
// File Name: CarrierDetailInformation.cs
// Description: Carrier Detail Information for AGC
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
    public partial class CarrierDetailInformation : UserControl
    {
        Port voPort = null;
        SCApplication scApp = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        string sPORTID = string.Empty;
        Dictionary<String, String> port_cmd = new Dictionary<string, string>();
        Carrier carrier = null;

        public CarrierDetailInformation()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        public void updateCarrierDetail(string _carrierID)
        {
            scApp = SCApplication.getInstance();
            carrier = scApp.CarrierBLL.getCarrier(_carrierID);
            if (carrier != null)
            {
                setCarrierDetailInformation(carrier);
            }
            else
            {
                setCarrierDetailInformation(carrier);
                return;
            }
        }







        public void Start(string _portid)
        {
            try
            {
                scApp = SCApplication.getInstance();
                voPort = scApp.getEQObjCacheManager().getPortByPortID(_portid);
                setCarrierID(voPort.Port_ID);
                //initialUI();
                addEventHandle();
                sPORTID = _portid;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }


        private void initialUI()
        {
            try
            {
                Adapter.Invoke(new SendOrPostCallback((o1) =>
                {
                    //setPortStatus_AGC();
                }), null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }


        string sHandlerID = string.Empty;
        private void addEventHandle()
        {
            try
            {
                //voPort.addEventHandler(sHandlerID, BCFUtility.getPropertyName(() => voPort.Port_Cmd), (s1, e1) =>
                //Adapter.Invoke(new SendOrPostCallback((o1) =>
                //{
                //    setPortStatus_AGC();
                //}), null));

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        public void refreshPortStatus(string _portid)
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //更新Port狀態
        public void setCarrierDetailInformation(Carrier voCarrier)
        {
            try
            {
                if (voCarrier != null)
                {
                    lbl_CarrierID_Title.Text = "Carrier ID : " + voCarrier.Crr_ID.Trim();
                    lab_crr_stat.Text = voCarrier.Crr_Stat.ToString();
                    lab_trx_stat.Text = voCarrier.Crr_TrxStat.ToString();
                    lab_location.Text = voCarrier.Loc;
                    lab_toPortNo.Text = voCarrier.To_PortNo;
                    lab_priority.Text = voCarrier.Priority.ToString();
                    lb_cstType.Text = voCarrier.Cst_Type.ToString();
                    lab_stockInTime.Text = voCarrier.CrrStockIn_Time.ToString();
                    lab_logonTime.Text = voCarrier.CrrLogOn_Time.ToString();
                    lab_logoffTime.Text = voCarrier.CrrLogOff_Time.ToString();
                    lab_logoffPort.Text = voCarrier.CrrLogOff_Port;
                    lab_holdflag.Text = voCarrier.HoldFlag;
                    lab_ticketNo.Text = voCarrier.Ticket_No;
                    lab_Alternate.Text = voCarrier.Alternate;
                    lab_reserveFlag.Text = voCarrier.Reserve_Flag;


                }
                else
                {
                    lbl_CarrierID_Title.Text = "Carrier ID : --";
                    lab_crr_stat.Text = "";
                    lab_trx_stat.Text = "";
                    lab_location.Text = "";
                    lab_toPortNo.Text = "";
                    lab_priority.Text = "";
                    lb_cstType.Text = "";
                    lab_cst1ID.Text = "";
                    lab_cst2ID.Text = "";
                    lab_cst3ID.Text = "";
                    lab_stockInTime.Text = "";
                    lab_logonTime.Text = "";
                    lab_logoffTime.Text = "";
                    lab_logoffPort.Text = "";
                    lab_holdflag.Text = "";
                    lab_ticketNo.Text = "";
                    lab_modelName.Text = "";
                    lab_nexProcNo.Text = "";
                    lab_Alternate.Text = "";
                    lab_reserveFlag.Text = "";
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception");
            }
        }

        //Port ID設定
        public void setCarrierID(string PORTID)
        {
            setInfo(lbl_CarrierID_Title, PORTID);
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
