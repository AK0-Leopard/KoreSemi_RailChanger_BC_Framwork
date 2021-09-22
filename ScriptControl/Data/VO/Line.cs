//*********************************************************************************
//      Line.cs
//*********************************************************************************
// File Name: Line.cs
// Description: Line類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using System.Data;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Line : BaseEQObject, IAlarmHisList
    {
        // In DB
        public virtual string Line_ID { get; set; }

        private int host_mode;
        public virtual int Host_Mode           //On-Line / Off-Line
        {
            get { return host_mode; }
            set
            {
                if (host_mode != value)
                {
                    host_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Host_Mode));
                }
            }
        }

        private int mplc_host_mode;
        public virtual int MPLC_Host_Mode           //MPLC On-Line / Off-Line
        {
            get { return mplc_host_mode; }
            set
            {
                if (mplc_host_mode != value)
                {
                    mplc_host_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.MPLC_Host_Mode));
                }
            }
        }

        private int mq_host_mode;
        public virtual int MQ_host_mode           //CONT / MANU
        {
            get { return mq_host_mode; }
            set
            {
                if (mq_host_mode != value)
                {
                    mq_host_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.MQ_host_mode));
                }
            }
        }

        private string operation_mode;
        public virtual string Operation_Mode
        {
            get { return operation_mode; }
            set
            {
                if (!BCFUtility.isMatche(operation_mode, value))
                {
                    operation_mode = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Operation_Mode));
                }
            }
        }

        private Queue<ConsoleMsg> systemConsoleMsgQueue = new Queue<ConsoleMsg>(Convert.ToInt32(SCApplication.getMessageString("SYSTEM_CONSOLE_MSG_CAPACITY")));
        public virtual Queue<ConsoleMsg> SystemConsoleMsgQueue
        {
            get { return systemConsoleMsgQueue; }
            set
            {
                systemConsoleMsgQueue = value;
                onSystemConsoleMsgQueueChange();
            }
        }

        public virtual void onSystemConsoleMsgQueueChange()
        {
            OnPropertyChanged(BCFUtility.getPropertyName(() => this.SystemConsoleMsgQueue));
        }

        private int currentCstCount;
        public virtual int CurrentCstCount
        {
            get { return currentCstCount; }
            set
            {
                this.currentCstCount = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.CurrentCstCount));
            }
        }

        private int currentAlarmCount;
        public virtual int CurrentAlarmCount
        {
            get { return currentAlarmCount; }
            set
            {
                this.currentAlarmCount = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.CurrentAlarmCount));
            }
        }

        private Boolean canSyncStatusByOnline;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual Boolean CanSyncStatusByOnline
        {
            get { return canSyncStatusByOnline; }
            set { canSyncStatusByOnline = value; }
        }

        private bool cycleRun;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual bool CycleRun
        {
            get { return cycleRun; }
            set
            {
                cycleRun = value;
            }
        }
        private int cycleRunCount;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int CycleRunCount
        {
            get { return cycleRunCount; }
            set
            {
                cycleRunCount = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.cycleRunCount));
            }
        }

        public DateTime lcs_link_fail_time = DateTime.MinValue;
        private int lcs_link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int LCS_Link_Stat
        {
            get { return lcs_link_stat; }
            set
            {
                lcs_link_stat = value;
                if (lcs_link_stat == SCAppConstants.LinkStatus.Link_Fail)
                {
                    lcs_link_fail_time = DateTime.Now;
                }
                else
                {
                    lcs_link_fail_time = DateTime.MinValue;
                }
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.LCS_Link_Stat));
            }
        }

        //MES更新還未實作 TBD
        public DateTime mes_link_fail_time = DateTime.MinValue;
        private int mes_link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int MES_Link_Stat
        {
            get { return mes_link_stat; }
            set
            {
                mes_link_stat = value;
                if (mes_link_stat == SCAppConstants.LinkStatus.Link_Fail)
                {
                    mes_link_fail_time = DateTime.Now;
                }
                else
                {
                    mes_link_fail_time = DateTime.MinValue;
                }
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.MES_Link_Stat));
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

        public DateTime sv_link_fail_time = DateTime.MinValue;
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
                        sv_link_fail_time = DateTime.Now;
                    }
                    else
                    {
                        sv_link_fail_time = DateTime.MinValue;
                    }
                }
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.Secs_Link_Stat));
            }
        }

        private int cim_link_stat;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int CIM_Link_Stat
        {
            get { return cim_link_stat; }
            set
            {
                if (cim_link_stat != value)
                {
                    cim_link_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.CIM_Link_Stat));
                }
            }
        }

        private int line_stat;
        public virtual int Line_Stat                    //Run / Down / Idle
        {
            get { return line_stat; }
            set
            {
                if (line_stat != value)
                {
                    line_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Line_Stat));
                }
            }
        }

        private AlarmHisList alarmHisList = new AlarmHisList();
        public virtual AlarmHisList AlarmHisList { get { return alarmHisList; } }

        private string operatorCall;
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual string OperatorCall
        {
            get { return operatorCall; }
            set
            {
                operatorCall = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.OperatorCall));
            }
        }

        private int traceSystemRunShtCountToExcel = 0;
        public virtual int TraceSystemRunShtCountToExcel
        {
            get { return traceSystemRunShtCountToExcel; }
            set
            {
                if (!BCFUtility.isMatche(traceSystemRunShtCountToExcel, value))
                {
                    traceSystemRunShtCountToExcel = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.TraceSystemRunShtCountToExcel));
                }
            }
        }

        public Line()
        {
            eqptObjectCate = SCAppConstants.EQPT_OBJECT_CATE_LINE;
            Operation_Mode = SCAppConstants.LineNormalRunMode;
            Line_Stat = SCAppConstants.LineStatus.DOWN;
        }

        public virtual void resetAlarmHis(List<Alarm> AlarmHisList)
        {
            alarmHisList.resetAlarmHis(AlarmHisList);
        }

        public virtual string getEqptObjectKey()
        {
            return BCFUtility.generateEQObjectKey(eqptObjectCate, Line_ID);
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
            //對sub eqpt進行初始化
            List<Zone> subZoneList = SCApplication.getInstance().getEQObjCacheManager().getZoneListByLine();
            if (subZoneList != null)
            {
                foreach (Zone zone in subZoneList)
                {
                    zone.doShareMemoryInit(runLevel);
                }
            }
        }

    }
}
