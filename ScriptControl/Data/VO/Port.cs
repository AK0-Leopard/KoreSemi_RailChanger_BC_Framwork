//*********************************************************************************
//      Port.cs
//*********************************************************************************
// File Name: Port.cs
// Description: Port類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/23    Steven Hong    N/A            A0.01   移除Cassette，將Cassette資料儲存於Carrier中
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;
using NLog;
using com.mirle.ibg3k0.stc.Common;
using com.mirle.ibg3k0.sc.Common;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Port : BaseUnitObject, ICassetteLoader, IBreakConvWait
    {
        public virtual CSTDataInfo CstDataInfo { get; set; }

        public virtual bool IsFinish_abortSelect { get; set; }

        public virtual string Port_ID { get; set; }
        public virtual string Buffer_ID { get; set; }
        public virtual string Bundle_ID { get; set; }
        public virtual int Buffer_Status { get; set; }
        public virtual int Tray_Type { get; set; }

        public virtual int Unit_Num { get; set; }
        public virtual int Port_Num { get; set; }

        public virtual string Eqpt_ID { get; set; }
        public List<CassetteDispatchInfo> cassetteDispatchInfos = null;


        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual string sv_cst_id { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual string sv_lot_id { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual string sv_slot_map { get; set; }  
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual Boolean CancelProcessByHost { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual Boolean CancelProcessByOP { get; set; }

        public Boolean breakConvWait()
        {
            return (CancelProcessByHost || CancelProcessByOP || Port_Stat != SCAppConstants.PortStatus.LDCM);
        }

        [BaseElement(NonChangeFromOtherVO = true)]
        private int portCommandStatus;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int PortCommandStatus
        {
            get { return portCommandStatus; }
            set
            {
                if (portCommandStatus != value)
                {
                    portCommandStatus = value;
                    SCUtility.PrintPortCommandInfo(this);
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.PortCommandStatus));
                }
            }
        }

        private string port_type;
        public virtual string Port_Type
        {
            get { return port_type; }
            set
            {
                if (!BCFUtility.isMatche(port_type, value))
                {
                    port_type = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Port_Type));
                }
            }
        }

        public virtual string Port_Type_Alias { get; set; }

        private string port_use_typ;
        public virtual string Port_Use_Typ
        {
            get { return port_use_typ; }
            set
            {
                if (!BCFUtility.isMatche(port_use_typ, value))
                {
                    port_use_typ = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Port_Use_Typ));
                }
            }
        }

        private string port_real_typ;
        public virtual string Port_Real_Typ
        {
            get { return port_real_typ; }
            set
            {
                if (!BCFUtility.isMatche(port_real_typ, value))
                {
                    port_real_typ = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Port_Real_Typ));
                }
            }
        }

        public virtual int Capacity { get; set; }

        private int capacity_percentage;
        public virtual int Capacity_Percentage
        {
            get { return capacity_percentage; }
            set
            {
                if (!BCFUtility.isMatche(capacity_percentage, value))
                {
                    capacity_percentage = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Capacity_Percentage));
                }
            }
        }

        public DateTime Port_StatChangeTime; //formModify
        private int port_stat = SCAppConstants.PortStatus.No_Request;
        public virtual int Port_Stat
        {
            get { return port_stat; }
            set
            {
                if (port_stat != value)
                {
                    port_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Port_Stat));
                }
            }
        }

        private int port_enable;
        public virtual int Port_Enable
        {
            get { return port_enable; }
            set
            {
                if (!BCFUtility.isMatche(port_enable, value))
                {
                    port_enable = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Port_Enable));
                }
            }
        }


        /// <summary>
        /// Transfer Mode
        /// </summary>
        public virtual int trs_mode { get; set; }
        public virtual int Trs_Mode
        {
            get { return trs_mode; }
            set
            {
                if (!BCFUtility.isMatche(trs_mode, value))
                {
                    trs_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Trs_Mode));
                }
            }
        }

        public virtual string Lyt_Dir { get; set; }

        private DateTime cst_datadowmloadtime;//formModify
        public virtual DateTime CST_DataDowmLoadTime//formModify
        {
            get { return cst_datadowmloadtime; }
            set
            {
                if (cst_datadowmloadtime != value)
                {
                    cst_datadowmloadtime = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.CST_DataDowmLoadTime));
                }
            }
        }
        private DateTime cst_startcmdtime;//formModify
        public virtual DateTime CST_StartCMDTime//formModify
        {
            get { return cst_startcmdtime; }
            set
            {
                if (cst_startcmdtime != value)
                {
                    cst_startcmdtime = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.CST_StartCMDTime));
                }
            }
        }

        public DateTime[] Q_TimeStartWaitDisplay = new DateTime[20];

        //For MPLC
        private int mplc_PortStat;
        public virtual int MPLC_PortStat
        {
            get { return mplc_PortStat; }
            set
            {
                if (mplc_PortStat != value)
                {
                    mplc_PortStat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.MPLC_PortStat));
                }
            }
        }

        public virtual string Ticket_No { get; set; }

        public virtual string MPLC_Crr_ID { get; set; }

        public virtual string Model_Name { get; set; }

        public virtual int Cst_Type { get; set; }

        public virtual int Cst_Condition { get; set; }

        public virtual string To_PortNo { get; set; }

        public virtual int Priority { get; set; }

        public virtual int Zone_Code { get; set; }

        public virtual int Inventory_Crr { get; set; }

        public virtual int Speed { get; set; }

        public virtual int Nx_ProcNo { get; set; }

        public virtual int Curr_ProcNo { get; set; }

        public virtual string Cst1_ID { get; set; }

        public virtual int Cst1_Qty { get; set; }

        public virtual string Cst1_LotNo { get; set; }

        public virtual string Cst2_ID { get; set; }

        public virtual int Cst2_Qty { get; set; }

        public virtual string Cst2_LotNo { get; set; }

        public virtual string Cst3_ID { get; set; }

        public virtual int Cst3_Qty { get; set; }

        public virtual string Cst3_LotNo { get; set; }

        public virtual DateTime? Unload_Time { get; set; }

        public virtual string CheckResult { get; set; }

        //For IO Port
        private string crr_id;
        public virtual string Crr_ID
        {
            get { return crr_id; }
            set
            {
                if (crr_id != value)
                {
                    crr_id = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Crr_ID));
                }
            }
        }

        private CassetteLoader cassetteLoader = new CassetteLoader();  
        public virtual CassetteLoader CassetteLoader  
        {
            get { return cassetteLoader; }
        }

        public Port()
        {
            eqptObjectCate = SCAppConstants.EQPT_OBJECT_CATE_PORT;
            CancelProcessByHost = false;
            CancelProcessByOP = false;
        }

        public Boolean isLoadPort()
        {
            return (BCFUtility.isMatche(port_type, SCAppConstants.PORT_TYPE_LOAD));
        }

        public Boolean isUnloadPort()
        {
            return (BCFUtility.isMatche(port_type, SCAppConstants.PORT_TYPE_UNLOAD));
        }

        public Boolean isCommonPort()
        {
            return (BCFUtility.isMatche(port_type, SCAppConstants.PORT_TYPE_COMMON_LOAD_UNLOAD));
        }

        public virtual void unloadCassette()
        {
            cassetteLoader.unloadCassette();
        }

        //A0.01 Start
        //public virtual void loadCassette(Cassette cassette)
        //{
        //    cassetteLoader.loadCassette(cassette);
        //}
        //A0.01 End

        private void initCassetteDispatchInfoList()
        {
            cassetteDispatchInfos = new List<CassetteDispatchInfo>();
            CassetteDispatchInfo cst_data_download = new CassetteDispatchInfo(SCAppConstants.CassetteDispatchInfoItem.CST_Data_Download, string.Empty);
            CassetteDispatchInfo cst_start_command = new CassetteDispatchInfo(SCAppConstants.CassetteDispatchInfoItem.CST_Start_Command, string.Empty);
            CassetteDispatchInfo bc_request_job = new CassetteDispatchInfo(SCAppConstants.CassetteDispatchInfoItem.BC_Request_Job, string.Empty);

            cassetteDispatchInfos.Add(cst_data_download);
            cassetteDispatchInfos.Add(cst_start_command);
            cassetteDispatchInfos.Add(bc_request_job);
        }
        public CassetteDispatchInfo getCassetteDispatchInfo(string item)
        {
            if (cassetteDispatchInfos == null)
            {
                initCassetteDispatchInfoList();
            }

            CassetteDispatchInfo cassetteDispatchInfo = null;
            try
            {
                cassetteDispatchInfo = cassetteDispatchInfos.Where(i => i.Item.Trim() == item.Trim()).FirstOrDefault();
            }
            catch { };
            return cassetteDispatchInfo;
        }
        public void updateCassetteDispatchInfoNote(string item,string note)
        {
            try
            {
                CassetteDispatchInfo cassetteDispatchInfo = getCassetteDispatchInfo(item);
                cassetteDispatchInfo.Note_Message = note;
            }
            catch (Exception ex)
            {
            }
        }


        public List<CassetteDispatchInfo> loadCassetteDispatchInfoList()
        {
            if (cassetteDispatchInfos == null)
            {
                initCassetteDispatchInfoList();
            }
            return cassetteDispatchInfos;
        }

        public string NotifyLotHisCntChange = "NotifyLotHisCntChange";
        public void NotifyRefreshLotHisCntChange()
        {
            OnPropertyChanged(NotifyLotHisCntChange);
        }

        public virtual string getEqptObjectKey()
        {
            return BCFUtility.generateEQObjectKey(eqptObjectCate, Port_ID);
        }

        /// <summary>
        /// 開始執行初始化動作
        /// </summary>
        public override void doShareMemoryInit(BCFAppConstants.RUN_LEVEL runLevel)
        {
            foreach (IValueDefMapAction action in valueDefMapActionDic.Values)
            {
                action.doShareMemoryInit(runLevel);
            }
        }

    }
}
