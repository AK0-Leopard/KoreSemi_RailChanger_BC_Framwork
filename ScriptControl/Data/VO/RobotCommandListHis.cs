//*********************************************************************************
//      RobotCommandListHis.cs
//*********************************************************************************
// File Name: RobotCommandListHis.cs
// Description: RobotCommandListHis類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/02/24    Steven Hong    N/A            A0.01   增加Org_Seq_No欄位
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class RobotCommandListHis
    {
        public RobotCommandListHis()
        {
            RobotCommandListHisPK = new RobotCommandListHisPKInfo();
        }

        public virtual RobotCommandListHisPKInfo RobotCommandListHisPK { get; set; }

        [RobotCMDListHisOrder(OrderNo = 1)]
        public virtual string Log_Sno { get { return RobotCommandListHisPK.Log_Sno; } set { RobotCommandListHisPK.Log_Sno = value; } }
        [RobotCMDListHisOrder(OrderNo = 2)]
        public virtual int Seq_No { get { return RobotCommandListHisPK.Seq_No; } set { RobotCommandListHisPK.Seq_No = value; } }
        [RobotCMDListHisOrder(OrderNo = 3)]
        public virtual int CMD_Step { get{ return RobotCommandListHisPK.CMD_Step; } set{ RobotCommandListHisPK.CMD_Step = value; } }        
        public virtual int Seq_No_Year { get; set; }
        public virtual int Seq_No_Month { get; set; }
        public virtual int Seq_No_Day { get; set; }
        public virtual int Seq_No_Houre { get; set; }
        [RobotCMDListHisOrder(OrderNo = 4)]
        public virtual int CMD_Type { get; set; }
        [RobotCMDListHisOrder(OrderNo = 5)]
        public virtual string Arm { get; set; }
        [RobotCMDListHisOrder(OrderNo = 6)]
        public virtual string From_Loc { get; set; }
        [RobotCMDListHisOrder(OrderNo = 7)]
        public virtual string To_Loc { get; set; }
        /// <summary>
        ///0. Complete.
        ///1. Status Error.
        ///2. Host cancel.
        ///3. Operator Cancel
        ///4. Glass Interface T1 time out
        ///5. Glass Interface T2 time out
        ///6. Glass Interface T3 time out
        ///7. Glass Interface T4 time out
        ///8. Glass Interface T5 time out
        ///9. Glass Interface T7 time out
        ///10.Error( 人為介入…等)
        /// </summary>
        [RobotCMDListHisOrder(OrderNo = 8)]
        public virtual int? Return_Code { get; set; }
        [RobotCMDListHisOrder(OrderNo = 9)]
        public virtual DateTime? Step_Start_Time { get; set; }
        [RobotCMDListHisOrder(OrderNo = 10)]
        public virtual DateTime? Step_End_Time { get; set; }
        public virtual string Crr_ID { get; set; }
        public virtual int Org_Seq_No { get; set; }  //A0.01

        public override bool Equals(object obj)
        {
            if (obj is RobotCommandListHis)
            {
                RobotCommandListHis second = obj as RobotCommandListHis;
                if (this.RobotCommandListHisPK.Seq_No == second.RobotCommandListHisPK.Seq_No
                    && this.RobotCommandListHisPK.CMD_Step == second.RobotCommandListHisPK.CMD_Step)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class RobotCommandListHisPKInfo
    {
        public virtual string Log_Sno { get; set; }
        public virtual int Seq_No { get; set; }
        public virtual int CMD_Step { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// 來用排序Alarm His 在Data Grid View 的順序
    /// </summary>
    public class RobotCMDListHisOrder : Attribute
    {
        public int OrderNo { get; set; }

    }
}
