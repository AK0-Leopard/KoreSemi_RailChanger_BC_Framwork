//*********************************************************************************
//      AlarmHisList.cs
//*********************************************************************************
// File Name: AlarmHisList.cs
// Description: Alarm History List類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/04/01    Hayes Chen     N/A            N/A     Initial Release
//
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class AlarmHisList : PropertyChangedVO
    {
        private List<Alarm> alarmList = new List<Alarm>();
        public virtual List<Alarm> AlarmList { get { return alarmList; } }

        private Object alarmLock = new Object();
        public virtual void resetAlarmHis(List<Alarm> dbAlarmList)
        {
            lock (alarmLock)
            {
                alarmList.Clear();
                alarmList.AddRange(dbAlarmList);
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.AlarmList));
            }
        }

        public virtual void addAlarmHis(Alarm alarm) 
        {
            lock (alarmLock)
            {
                alarmList.Add(alarm);
                OnPropertyChanged(BCFUtility.getPropertyName(() => this.AlarmList));
            }
        }

    }

    public interface IAlarmHisList
    {
        void resetAlarmHis(List<Alarm> dbAlarmList);
    }
}
