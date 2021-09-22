//*********************************************************************************
//      Alarm.cs
//*********************************************************************************
// File Name: Alarm.cs
// Description: Alarm Object
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/03/05    Hayes Chen     N/A            N/A     Initial Release
// 2014/05/07    Hayes Chen     N/A            A0.01   Add EQPT_ID
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Alarm
    {
        public Alarm()
        {
            AlarmPK = new AlarmPKInfo();
        }

        public virtual AlarmPKInfo AlarmPK { get; set; }

        [AlarmOrder(OrderNo=1)]
        public virtual string EQPT_ID { get { return AlarmPK.EQPT_ID; } set { AlarmPK.EQPT_ID = value; } }
        [AlarmOrder(OrderNo = 2)]
        public virtual int Unit_Num { get { return AlarmPK.Unit_Num; } set { AlarmPK.Unit_Num = value; } }
        [AlarmOrder(OrderNo = 3)]
        public virtual string Rpt_Date_Time { get { return AlarmPK.Rpt_Date_Time; } set { AlarmPK.Rpt_Date_Time = value; } }
        [AlarmOrder(OrderNo = 4)]
        public virtual string Alarm_Code { get; set; }
        [AlarmOrder(OrderNo = 5)]
        public virtual int Alarm_Lvl { get; set; }
        [AlarmOrder(OrderNo = 6)]
        public virtual int Alarm_Stat { get; set; }
        // 1 : Set
        // 1 : Clear
        [AlarmOrder(OrderNo = 7)]
        public virtual int Alarm_Affect_Count { get; set; }
        [AlarmOrder(OrderNo = 8)]
        public virtual string Alarm_Desc { get; set; }

        //List<string> lstAlarmAffectGlass

        public virtual Boolean isSet()
        {
            if (Alarm_Stat == Convert.ToInt32(SCAppConstants.AlarmStatus.Set))
            {
                return true;
            }
            return false;
        }

        public virtual Boolean isAlarm()
        {
            if (Alarm_Lvl == Convert.ToInt32(SCAppConstants.AlarmLevel.Alarm))
            {
                return true;
            }
            return false;
        }

        public virtual Boolean isWarning()
        {
            if (Alarm_Lvl == Convert.ToInt32(SCAppConstants.AlarmLevel.Warning))
            {
                return true;
            }
            return false;
        }

    }

    public class AlarmPKInfo
    {
        public virtual string EQPT_ID { get; set; }     //A0.01

        public virtual int Unit_Num { get; set; }

        //public virtual DateTime Rpt_Date_Time { get; set; }
        public virtual string Rpt_Date_Time { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AlarmPKInfo)
            {
                AlarmPKInfo pk = obj as AlarmPKInfo;
                if (BCFUtility.isMatche(this.EQPT_ID, pk.EQPT_ID)
                    && BCFUtility.isMatche(this.Unit_Num, pk.Unit_Num)
                    && this.Rpt_Date_Time.CompareTo(pk.Rpt_Date_Time) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

   /// <summary>
   /// 來用排序Alarm His 在Data Grid View 的順序
   /// </summary>
   public class AlarmOrder : Attribute
    {
        //public AlarmOrder();

        public int OrderNo { get; set; }

    }

}