//*********************************************************************************
//      Equipment.cs
//*********************************************************************************
// File Name: Equipment.cs
// Description: Equipment類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/02/24    Steven Hong    N/A            A0.01   檢查特定Arm是否可用
//**********************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.ConfigHandler;
using com.mirle.ibg3k0.bcf.Data;
using NLog;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using Appccelerate.StateMachine;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.ConfigHandler;
using com.mirle.ibg3k0.sc.ValueHandler;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.SECS;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Equipment : BaseEQObject, IAlarmHisList
    {
        public DateTime secs_link_fail_time = DateTime.MinValue;
        private int secs_link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int Secs_Link_Stat
        {
            get { return secs_link_stat; }
            set
            {
                if (secs_link_stat != value)
                {
                    secs_link_stat = value;
                    if (secs_link_stat == SCAppConstants.LinkStatus.Link_Fail)
                    {
                        secs_link_fail_time = DateTime.Now;
                    }
                    else
                    {
                        secs_link_fail_time = DateTime.MinValue;
                    }
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Secs_Link_Stat));
                }
            }
        }

        public DateTime plc_link_fail_time = DateTime.MinValue;
        private int plc_link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int Plc_Link_Stat
        {
            get { return plc_link_stat; }
            set
            {
                if (plc_link_stat != value)
                {
                    plc_link_stat = value;
                    if (plc_link_stat == SCAppConstants.LinkStatus.Link_Fail)
                    {
                        plc_link_fail_time = DateTime.Now;
                    }
                    else
                    {
                        plc_link_fail_time = DateTime.MinValue;
                    }
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Plc_Link_Stat));
                }
            }
        }

        public DateTime secs_ip_link_fail_time = DateTime.MinValue;
        private int secs_ip_link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int Secs_ip_Link_Stat
        {
            get { return secs_ip_link_stat; }
            set
            {
                if (secs_ip_link_stat != value)
                {
                    secs_ip_link_stat = value;
                    if (secs_ip_link_stat == SCAppConstants.LinkStatus.Link_Fail)
                    {
                        secs_ip_link_fail_time = DateTime.Now;
                    }
                    else
                    {
                        secs_ip_link_fail_time = DateTime.MinValue;
                    }
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Secs_ip_Link_Stat));
                }
            }
        }
        public Item<Boolean> MSMQConnectionStatus = new Item<Boolean>();

        //DB
        public virtual string Eqpt_ID { get; set; }     //Key

        public virtual string Node_ID { get; set; }

        private string crr_id;
        public virtual string Crr_ID
        {
            get { return crr_id; }
            set
            {
                crr_id = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.Crr_ID));
            }
        }

        private int cim_mode;
        public virtual int CIM_Mode
        {
            get { return cim_mode; }
            set
            {
                if (cim_mode != value)
                {
                    cim_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.CIM_Mode));
                }
            }
        }

        private int run_mode;
        public virtual int Run_Mode
        {
            get { return run_mode; }
            set
            {
                if (run_mode != value)
                {
                    run_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Run_Mode));
                }
            }
        }

        private int alarm_happen;
        public virtual int Alarm_Happen_Code
        {
            get { return alarm_happen; }
            set
            {
                if (alarm_happen != value)
                {
                    alarm_happen = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.alarm_happen));
                }
            }
        }

        private int oper_mode;
        public virtual int Oper_Mode
        {
            get { return oper_mode; }
            set
            {
                if (oper_mode != value)
                {
                    oper_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Oper_Mode));
                }
            }
        }

        private bool inline_mode;
        public virtual bool Inline_Mode
        {
            get { return inline_mode; }
            set
            {
                if (inline_mode != value)
                {
                    inline_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Inline_Mode));
                }
            }
        }

        private bool alarm_stat;
        public virtual bool Alarm_Stat            // Y / N
        {
            get { return alarm_stat; }
            set
            {
                if (!BCFUtility.isMatche(alarm_stat, value))
                {
                    alarm_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Alarm_Stat));
                }
            }
        }

        private bool warn_stat;
        public virtual bool Warn_Stat
        {
            get { return warn_stat; }
            set
            {
                if (!BCFUtility.isMatche(warn_stat, value))
                {
                    warn_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Warn_Stat));
                }
            }
        }

        private string eqpt_stat = "D";
        public virtual string Eqpt_Stat
        {
            get { return eqpt_stat; }
            set
            {
                eqpt_stat = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.Eqpt_Stat));
            }
        }

        public virtual string Operation_status { get; set; }

        private int eqpt_proc_stat;
        public virtual int Eqpt_Proc_Stat
        {
            get { return eqpt_proc_stat; }
            set
            {
                if (eqpt_proc_stat != value)
                {
                    eqpt_proc_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Eqpt_Proc_Stat));
                }
            }
        }

        private int rc_side;
        public virtual int RC_Side
        {
            get { return rc_side; }
            set
            {
                if (rc_side != value)
                {
                    rc_side = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.RC_Side));
                }
            }
        }

        private int block_status;
        public virtual int Block_Status
        {
            get { return block_status; }
            set
            {
                if (block_status != value)
                {
                    block_status = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Block_Status));
                }
            }
        }

        private int mode_onoff;
        public virtual int Mode_Onoff
        {
            get { return mode_onoff; }
            set
            {
                if (mode_onoff != value)
                {
                    mode_onoff = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Mode_Onoff));
                }
            }
        }

        private int default_side;
        public virtual int Default_Side
        {
            get { return default_side; }
            set
            {
                if (default_side != value)
                {
                    default_side = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Default_Side));
                }
            }
        }

        private int change_count;
        public virtual int Change_Count
        {
            get { return change_count; }
            set
            {
                if (change_count != value)
                {
                    change_count = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Change_Count));
                }
            }
        }

        private int error_report;
        public virtual int Error_Report
        {
            get { return error_report; }
            set
            {
                if (error_report != value)
                {
                    error_report = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Error_Report));
                }
            }
        }

        private int vesrion;
        public virtual int RC_Version
        {
            get { return vesrion; }
            set
            {
                if (vesrion != value)
                {
                    vesrion = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.RC_Version));
                }
            }
        }
        

        private AlarmHisList alarmHisList = new AlarmHisList();
        public virtual AlarmHisList AlarmHisList { get { return alarmHisList; } }

        private int link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int Link_Stat
        {
            get { return link_stat; }
            set
            {
                if (link_stat != value)
                {
                    link_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Link_Stat));
                }
            }
        }

        [BaseElement(NonChangeFromOtherVO = true)]
        public string Alarm_List_File { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        private Properties alarmPrty;
        [BaseElement(NonChangeFromOtherVO = true)]
        public string Process_Data_Format { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        public string SV_Data_Format { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        public string Recipe_Parameter_Format { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        public string ECID_Format { get; set; }
        [BaseElement(NonChangeFromOtherVO = true)]
        private com.mirle.ibg3k0.sc.ConfigHandler.ProcessDataConfigHandler procDataConfigHandler;
        [BaseElement(NonChangeFromOtherVO = true)]
        private SVDataConfigHandler svDataConfigHandler;
        [BaseElement(NonChangeFromOtherVO = true)]
        private SVDataValueHandler svDataValueHandler;
        [BaseElement(NonChangeFromOtherVO = true)]
        private RecipeParameterConfigHandler recipeParameterConfigHandler;
        [BaseElement(NonChangeFromOtherVO = true)]
        private ECIDConfigHandler ECIDConfigHandler;
        [BaseElement(NonChangeFromOtherVO = true)]
        private ECIDValueHandler ECIDValueHandler;
        [BaseElement(NonChangeFromOtherVO = true)]
        public List<Unit> UnitList { get; set; }

        //ES52 CV Water Level
        //public Dictionary<int, ES52_WaterLevel> ES52_WaterLevelDic = new Dictionary<int, ES52_WaterLevel>();

        //EP11 Buffer Status List
        public List<BufferStatus> EP11_Buffer_Status_lst = new List<BufferStatus>();

        public Dictionary<string, WipRejectStat> ES53_WipRejectReserveDic = new Dictionary<string, WipRejectStat>();

        public int getWipRejectCnt()
        {
            int empty_cnt = 0;
            try
            {
                List<WipRejectStat> wipRejectLst = ES53_WipRejectReserveDic.Values.ToList();
                foreach (WipRejectStat wipReject in wipRejectLst)
                {
                    if (!wipReject.Crr_Exist && !wipReject.Reserve)
                    {
                        empty_cnt++;
                    }
                }
            }
            catch
            {

            }

            return empty_cnt;
        }

        //EP01 Port Stat
        public Dictionary<string, string> EP01_PortMGDic = new Dictionary<string, string>();

        //ES45 Eqipment Alive
        public DateTime Eq_Alive_Last_Change_time = DateTime.MinValue;

        //ES57 Flag
        public bool ES57_Flag = false;

        [BaseElement(NonChangeFromOtherVO = true)]
        public int Eq_Alive { get; set; }

        private bool iseq_alive;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual bool Is_EqAlive
        {
            get { return iseq_alive; }
            set
            {
                if (iseq_alive != value)
                {
                    iseq_alive = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Is_EqAlive));
                }
            }
        }

        //EQ MG Stat
        public Dictionary<string, MGStat> EQ_MGStatDic = new Dictionary<string, MGStat>();

        //Crane Status
        private bool robottablechange;
        public virtual bool RobotTableChange
        {
            get { return robottablechange; }
            set
            {
                robotlistchange = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.RobotTableChange));
            }
        }
        private bool robotlistchange;
        public virtual bool RobotListChange
        {
            get { return robotlistchange; }
            set
            {
                robotlistchange = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.RobotListChange));
            }
        }

        private int ec01_cranestat;
        public virtual int EC01_CraneStat
        {
            get { return ec01_cranestat; }
            set
            {
                if (ec01_cranestat != value)
                {
                    ec01_cranestat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_CraneStat));
                }
            }
        }

        private int ec01_automode;
        public virtual int EC01_AutoMode
        {
            get { return ec01_automode; }
            set
            {
                if (ec01_automode != value)
                {
                    ec01_automode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_AutoMode));
                }
            }
        }

        private bool ec01_arm1enable;
        public virtual bool EC01_Arm1Enable
        {
            get { return ec01_arm1enable; }
            set
            {
                if (ec01_arm1enable != value)
                {
                    ec01_arm1enable = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_Arm1Enable));
                }
            }
        }

        private bool ec01_arm1mgexist;
        public virtual bool EC01_Arm1MGExist
        {
            get { return ec01_arm1mgexist; }
            set
            {
                if (ec01_arm1mgexist != value)
                {
                    ec01_arm1mgexist = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_Arm1MGExist));
                }
            }
        }

        private string ec01_arm1mgid;
        public virtual string EC01_Arm1MGID
        {
            get { return ec01_arm1mgid; }
            set
            {
                if (ec01_arm1mgid != value)
                {
                    ec01_arm1mgid = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_Arm1MGID));
                }
            }
        }

        private bool ec01_arm2enable;
        public virtual bool EC01_Arm2Enable
        {
            get { return ec01_arm2enable; }
            set
            {
                if (ec01_arm2enable != value)
                {
                    ec01_arm2enable = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_Arm2Enable));
                }
            }
        }

        private bool ec01_arm2mgexist;
        public virtual bool EC01_Arm2MGExist
        {
            get { return ec01_arm2mgexist; }
            set
            {
                if (ec01_arm2mgexist != value)
                {
                    ec01_arm2mgexist = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_Arm2MGExist));
                }
            }
        }
        private string ec01_arm2mgid;
        public virtual string EC01_Arm2MGID
        {
            get { return ec01_arm2mgid; }
            set
            {
                if (ec01_arm2mgid != value)
                {
                    ec01_arm2mgid = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_Arm2MGID));
                }
            }
        }

        private int ec01_execucmdseq;
        public virtual int EC01_ExecuCMDSeq
        {
            get { return ec01_execucmdseq; }
            set
            {
                if (ec01_execucmdseq != value)
                {
                    ec01_execucmdseq = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_ExecuCMDSeq));
                }
            }
        }
        private int ec01_execucmdstep;
        public virtual int EC01_ExecuCMDStep
        {
            get { return ec01_execucmdstep; }
            set
            {
                if (ec01_execucmdstep != value)
                {
                    ec01_execucmdstep = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_ExecuCMDStep));
                }
            }
        }

        private bool ec01_craneready;
        public virtual bool EC01_CraneReady
        {
            get { return ec01_craneready; }
            set
            {
                if (ec01_craneready != value)
                {
                    ec01_craneready = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_CraneReady));
                }
            }
        }

        private int ec01_craneposition;
        public virtual int EC01_CranePosition
        {
            get { return ec01_craneposition; }
            set
            {
                if (ec01_craneposition != value)
                {
                    ec01_craneposition = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.EC01_CranePosition));
                }
            }
        }

        private bool hascmdexecute;
        public virtual bool HasCMDExecute
        {
            get { return hascmdexecute; }
            set
            {
                if (hascmdexecute != value)
                {
                    hascmdexecute = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.HasCMDExecute));
                }
            }
        }

        private bool havesendcmdexecute;
        public virtual bool HaveSendCMDExecute
        {
            get { return havesendcmdexecute; }
            set
            {
                if (havesendcmdexecute != value)
                {
                    havesendcmdexecute = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.HaveSendCMDExecute));
                }
            }
        }

        public int CurrentExcuSeq;

        //Equipment 狀態機
        public Equipment()
        {
            eqptObjectCate = SCAppConstants.EQPT_OBJECT_CATE_EQPT;
            lock_MES_Port_Status_Change = new Object();
            lock_MES_Proc_Status = new Object();
            lock_MES_Port_Move_In_Status = new Object();

            lock_MES_EQ_Status = new Object();
            lock_MES_Alarm = new Object();
            lock_MES_TerminalMsgChange_Reset = new Object();
            lock_MES_Terminal_Msg = new Object();
            lock_MES_terminalMsgChange_InitTimeout = new Object();

            init();
        }

        /// <summary>
        /// 取得Alarm Desc
        /// </summary>
        /// <param name="alarmCode"></param>
        /// <returns></returns>
        public string getAlarmDesc(string alarmCode)
        {
            if (alarmPrty == null)
            {
                alarmPrty = new Properties(Alarm_List_File);
            }
            return alarmPrty.get(alarmCode, alarmCode);
        }

        public Dictionary<string, string> getAlarmMapDic()
        {
            if (alarmPrty == null)
            {
                alarmPrty = new Properties(Alarm_List_File);
            }
            return alarmPrty.toDictionary();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public com.mirle.ibg3k0.sc.ConfigHandler.SVDataConfigHandler getSVDataConfigHandler()
        {
            if (BCFUtility.isEmpty(SV_Data_Format))
            {
                return null;
            }
            if (svDataConfigHandler == null)
            {
                svDataConfigHandler =
                    new com.mirle.ibg3k0.sc.ConfigHandler.SVDataConfigHandler(SV_Data_Format);
            }
            return svDataConfigHandler;
        }

        public void reloadSVDataFormatFile()
        {
            com.mirle.ibg3k0.sc.ConfigHandler.SVDataConfigHandler handler = getSVDataConfigHandler();
            if (handler != null)
            {
                handler.reload();
            }
        }

        public SVDataValueHandler getSVDataValueHandler()
        {
            if (svDataValueHandler == null)
            {
                svDataValueHandler = new SVDataValueHandler(null, this);
            }
            return svDataValueHandler;
        }

        /// <summary>
        /// 取得Process Data Format
        /// </summary>
        /// <returns></returns>
        public com.mirle.ibg3k0.sc.ConfigHandler.ProcessDataConfigHandler getProcessDataConfigHandler()
        {
            if (BCFUtility.isEmpty(Process_Data_Format))
            {
                return null;
            }
            if (procDataConfigHandler == null)
            {
                procDataConfigHandler =
                    new com.mirle.ibg3k0.sc.ConfigHandler.ProcessDataConfigHandler(Process_Data_Format);
            }
            return procDataConfigHandler;
        }

        public void reloadProcessDataFormatFile()
        {
            com.mirle.ibg3k0.sc.ConfigHandler.ProcessDataConfigHandler handler = getProcessDataConfigHandler();
            if (handler != null)
            {
                handler.reload();
            }
        }

        /// <summary>
        /// 取得Recipe Parameter Format
        /// </summary>
        /// <returns></returns>
        public com.mirle.ibg3k0.sc.ConfigHandler.RecipeParameterConfigHandler getRecipeParameterConfigHandler()
        {
            if (BCFUtility.isEmpty(Recipe_Parameter_Format))
            {
                return null;
            }
            if (recipeParameterConfigHandler == null)
            {
                recipeParameterConfigHandler =
                    new com.mirle.ibg3k0.sc.ConfigHandler.RecipeParameterConfigHandler(Recipe_Parameter_Format);
            }
            return recipeParameterConfigHandler;
        }

        public void reloadRecipeParameterFormatFile()
        {
            com.mirle.ibg3k0.sc.ConfigHandler.RecipeParameterConfigHandler handler = getRecipeParameterConfigHandler();
            if (handler != null)
            {
                handler.reload();
            }
        }

        /// <summary>
        /// 取得ECID Format
        /// </summary>
        /// <returns></returns>
        public com.mirle.ibg3k0.sc.ConfigHandler.ECIDConfigHandler getECIDConfigHandler()
        {
            if (BCFUtility.isEmpty(ECID_Format))
            {
                return null;
            }
            if (ECIDConfigHandler == null)
            {
                ECIDConfigHandler =
                    new com.mirle.ibg3k0.sc.ConfigHandler.ECIDConfigHandler(ECID_Format);
            }
            return ECIDConfigHandler;
        }

        public void reloadECIDFormatFile()
        {
            com.mirle.ibg3k0.sc.ConfigHandler.ECIDConfigHandler handler = getECIDConfigHandler();
            if (handler != null)
            {
                handler.reload();
            }
        }
        public ECIDValueHandler getECIDValueHandler()
        {
            if (ECIDValueHandler == null)
            {
                ECIDValueHandler = new ECIDValueHandler(null, this);
            }
            return ECIDValueHandler;
        }

        /// <summary>
        /// 重新取得Alarm Desc List
        /// </summary>
        /// <param name="alarm_list_file"></param>
        public void reloadAlarmDesc(string alarm_list_file)
        {
            this.Alarm_List_File = alarm_list_file;
            alarmPrty.reload(Alarm_List_File);
        }

        /// <summary>
        /// 重新取得Alarm Desc List
        /// </summary>
        public void reloadAlarmDesc()
        {
            alarmPrty.reload();
        }

        /// <summary>
        /// 放入Alarm至Queue中
        /// </summary>
        /// <param name="alarm"></param>
        public virtual void resetAlarmHis(List<Alarm> AlarmHisList)
        {
            alarmHisList.resetAlarmHis(AlarmHisList);
        }

        /// <summary>
        /// 取得Equipment的EqptObjectKey
        /// </summary>
        /// <returns></returns>
        public virtual string getEqptObjectKey()
        {
            return BCFUtility.generateEQObjectKey(eqptObjectCate, Eqpt_ID);
        }

        private void init()
        {
            eqpt_stat = CmdConst.EQST_DOWN;
        }

        public Boolean isCIMOn()
        {
            if (cim_mode == Convert.ToInt32(SCAppConstants.EQPTCIMMode.CIM_ON))
            {
                return true;
            }
            return false;
        }

        public Boolean isDown()
        {
            if (BCFUtility.isMatche(eqpt_stat, CmdConst.EQST_DOWN))
            {
                return true;
            }
            return false;
        }

        public Boolean isMainte()
        {
            if (BCFUtility.isMatche(eqpt_stat, CmdConst.EQST_MAINTENANCE))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public Boolean isOther()
        {
            if (BCFUtility.isMatche(eqpt_stat, CmdConst.EQST_OTHER))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 開始執行初始化動作
        /// </summary>
        public override void doShareMemoryInit(BCFAppConstants.RUN_LEVEL runLevel)
        {
            Eqpt_ID = Eqpt_ID;
            foreach (IValueDefMapAction action in valueDefMapActionDic.Values)
            {
                action.doShareMemoryInit(runLevel);
            }
            //對sub eqpt進行初始化
            List<Unit> subUnitList = SCApplication.getInstance().getEQObjCacheManager().getUnitListByEquipment(Eqpt_ID);
            if (subUnitList != null)
            {
                foreach (Unit unit in subUnitList)
                {
                    unit.doShareMemoryInit(runLevel);
                }
            }
            List<Port> subPortList = SCApplication.getInstance().getEQObjCacheManager().getPortListByEquipment(Eqpt_ID);
            if (subPortList != null)
            {
                foreach (Port port in subPortList)
                {
                    port.doShareMemoryInit(runLevel);
                }
            }
        }

        /**
         * Only LD(LDRQ、LDCM、UDRQ、UDCM) & ULD(LDRQ、LDCM、UDRQ、UDCM) 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_Port_Status_Change { get; set; }

        /**
         * Only LD & ULD 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_Port_Move_In_Status { get; set; }

        /**
         * Only LD(Process Start) & ULD(Process End) & EQ(Process Data) 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_Proc_Status { get; set; }

        /**
         * All EQ 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_EQ_Status { get; set; }

        /**
         * All EQ 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_Alarm { get; set; }

        /**
         * All EQ 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_TerminalMsgChange_Reset { get; set; }


        /**
         * All EQ 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_Terminal_Msg { get; set; }

        /**
         * All EQ 使用
         **/
        [BaseElement(NonChangeFromOtherVO = true)]
        public Object lock_MES_terminalMsgChange_InitTimeout { get; set; }

        [BaseElement(NonChangeFromOtherVO = true)]
        public int CommunicationType { get; set; }


        /// <summary>
        /// 刪除所有Alarm
        /// </summary>
        public void deleteAllAlarm()
        {
            //if (CommunicationType == BCFAppConstants.COMMUNICATION_TYPE_ONLY_PLC)
            //{
            //    SCApplication.getInstance().AlarmBLL.deleteAllAlarmByEQPT_ID(this.Eqpt_ID);
            //}
            //else if (CommunicationType == BCFAppConstants.COMMUNICATION_TYPE_MIX_PLC_SECS)
            //{
            //    SCApplication.getInstance().AlarmBLL.deleteAllAlarmByEQPT_ID(this.Eqpt_ID);
            //}
        }

    }
    public class GI_EQ_Ready
    {
        public Boolean isUse { get; set; }
        public Boolean EQReady { get; set; }
    }

    public class MGStat
    {
        public String Crr_Type { get; set; }
        public Boolean LDRQ { get; set; }
    }

    public class BufferStatus
    {
        public String Buffer_ID { get; set; }
        public String Bundle_ID { get; set; }
        public UInt16 Buffer_Status { get; set; }
        public UInt16 Tray_Type { get; set; }


    }
}
