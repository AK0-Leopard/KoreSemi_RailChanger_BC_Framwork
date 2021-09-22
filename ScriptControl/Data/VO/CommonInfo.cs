using com.mirle.ibg3k0.bcf.Common;
//*********************************************************************************
//      CommonInfo.cs
//*********************************************************************************
// File Name: CommonInfo.cs
// Description: CCommonInfo類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using System.Data;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CommonInfo : PropertyChangedVO, IAlarmHisList
    {
        #region MPC Tip Message
        private readonly static int MAX_MPC_TIP_MSG_COUNT = 50;
        private List<MPCTipMessage> mpcTipMsgList = new List<MPCTipMessage>();
        public List<MPCTipMessage> MPCTipMsgList
        {
            get
            {
                return mpcTipMsgList;
            }
        }
        private DataTable mpcTipMsgDataTable = null;
        private void initMPCTipMsgDataTable()
        {
            mpcTipMsgDataTable = new DataTable("MPCTipMSG");
            //mpcTipMsgDataTable.Columns.Add("Time", typeof(string));
            mpcTipMsgDataTable.Columns.Add("Time", typeof(string));
            mpcTipMsgDataTable.Columns.Add("MsgSource", typeof(string));
            mpcTipMsgDataTable.Columns.Add("MsgLevel", typeof(string));
            mpcTipMsgDataTable.Columns.Add("Msg", typeof(string));
        }

        public void addMPCTipMsg(MPCTipMessage mpcTipMsg)
        {
            lock (mpcTipMsgList)
            {
                if (mpcTipMsgList.Count > MAX_MPC_TIP_MSG_COUNT)
                {
                    mpcTipMsgList.RemoveAt(mpcTipMsgList.Count - 1);
                }
                mpcTipMsgList.Insert(0, mpcTipMsg);
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.MPCTipMsgList));
            }
        }
        #endregion

        private AlarmHisList alarmHisList = new AlarmHisList();
        public AlarmHisList AlarmHisList { get { return alarmHisList; } }

        private StringBuilder actionMsgBuffer = new StringBuilder();
        public StringBuilder ActionMsgBuffer { get { return actionMsgBuffer; } }
        private string action_msg = string.Empty;
        public virtual string Action_Msg
        {
            get { return action_msg; }
            set
            {
                lock (actionMsgBuffer)
                {
                    action_msg = value;
                    if (actionMsgBuffer.Length > 200)
                    {
                        actionMsgBuffer.Clear();
                    }
                    actionMsgBuffer.AppendLine(action_msg);
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Action_Msg));
                }
            }
        }

        /// <summary>
        /// A0.03
        /// </summary>
        /// <param name="alarmList"></param>
        public void resetAlarmHis(List<Alarm> alarmList)
        {
            alarmHisList.resetAlarmHis(alarmList);
        }

        private string secs_msg;
        public virtual string SECS_Msg
        {
            get { return secs_msg; }
            set
            {
                if (!BCFUtility.isMatche(secs_msg, value))
                {
                    secs_msg = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.SECS_Msg));
                }
            }
        }
        private string plc_msg;
        public virtual string PLC_Msg
        {
            get { return plc_msg; }
            set
            {
                if (!BCFUtility.isMatche(plc_msg, value))
                {
                    plc_msg = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.PLC_Msg));
                }
            }
        }

        private string tracerobotcmd;
        public virtual string TraceRobotCMD
        {
            get { return tracerobotcmd; }
            set
            {
                if (!BCFUtility.isMatche(tracerobotcmd, value))
                {
                    tracerobotcmd = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.TraceRobotCMD));
                }
            }
        }

        private bool isrecodetracerobotcmd = false;
        public virtual bool IsRecodeTraceRobotCMD
        {
            get { return isrecodetracerobotcmd; }
            set
            {
                isrecodetracerobotcmd = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.IsRecodeTraceRobotCMD));
            }
        }

        private bool dcs_execute = false;
        public virtual bool Dcs_Execute
        {
            get { return dcs_execute; }
            set
            {
                dcs_execute = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.Dcs_Execute));
            }
        }

        private bool rcs_execute;
        public virtual bool Rcs_Execute
        {
            get { return rcs_execute; }
            set
            {
                rcs_execute = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.Rcs_Execute));
            }
        }

        private string plcdataerror;
        public virtual string PLCDataErrorCall
        {
            get { return plcdataerror; }
            set
            {
                plcdataerror = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.PLCDataErrorCall));
            }
        }

        private bool openrobotsemiautofrom;
        public virtual bool OpenRobotSemiAutoFrom
        {
            get { return openrobotsemiautofrom; }
            set
            {
                openrobotsemiautofrom = value;
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.OpenRobotSemiAutoFrom));
            }
        }

        /// <summary>
        /// A0.01 傳入Eqpt ID 或 Eqpt Real ID，回傳該EQ 是否 CIM On 
        /// </summary>
        public bool isCIMOn(string eqptid)
        {
            Equipment eqpt;
            eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTID(eqptid);
            if (eqpt == null)
                eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTRealID(eqptid);
            if (eqpt == null)
                return false;

            return eqpt.isCIMOn();
        }
        /// <summary>
        /// A0.02 傳入Eqpt ID 或 Eqpt Real ID，回傳該EQ 是否為Down
        /// </summary>
        public bool isDown(string eqptid)
        {
            Equipment eqpt;
            eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTID(eqptid);
            if (eqpt == null)
                eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTRealID(eqptid);
            if (eqpt == null)
                return false;

            return eqpt.isDown();
        }

        /// <summary>
        /// A0.03 傳入Eqpt ID 或 Eqpt Real ID，回傳該EQ 是否 Mainte
        /// </summary>
        public bool isMainte(string eqptid)
        {
            Equipment eqpt;
            eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTID(eqptid);
            if (eqpt == null)
                eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTRealID(eqptid);
            if (eqpt == null)
                return false;

            return eqpt.isMainte();
        }

        /// <summary>
        /// A0.06
        /// </summary>
        /// <param name="eqptid"></param>
        /// <returns></returns>
        public bool isOther(string eqptid)
        {
            Equipment eqpt;
            eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTID(eqptid);
            if (eqpt == null)
                eqpt = SCApplication.getInstance().getEQObjCacheManager().getEquipmentByEQPTRealID(eqptid);
            if (eqpt == null)
                return false;

            return eqpt.isOther();
        }

    }

    public class MPCTipMessage
    {
        //訊息時間
        public String Time { set; get; }
        //訊息等級
        public String MsgLevel { get; set; }
        //訊息
        public String Msg { get; set; }

        public MPCTipMessage()
        {
            Time = BCFUtility.formatDateTime(DateTime.Now, SCAppConstants.DateTimeFormat_19); // 0621 modify
        }
    }

    public class PortTaskInfo
    {
        public string portNumber;
        public string reqUseType;

        public PortTaskInfo(string portNumber, string reqUseType)
        {
            this.portNumber = portNumber;
            this.reqUseType = reqUseType;

        }
    }

}
