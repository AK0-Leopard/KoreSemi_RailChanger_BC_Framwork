//*********************************************************************************
//      RobotCommandList.cs
//*********************************************************************************
// File Name: RobotCommandList.cs
// Description: RobotCommandList類別
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
    public class RobotCommandList
    {
        public RobotCommandList()
        {
            SeqCMD = new SeqNoANDCMDStep();
        }

        public virtual SeqNoANDCMDStep SeqCMD { get; set; }
        [RobotCMDListOrder(OrderNo = 1)]
        public virtual int Seq_No { get { return SeqCMD.Seq_No; } set { SeqCMD.Seq_No = value; } }
        [RobotCMDListOrder(OrderNo = 2)]
        public virtual int CMD_Step { get{ return SeqCMD.CMD_Step; } set{ SeqCMD.CMD_Step = value; } }        
        public virtual int Seq_No_Year { get; set; }
        public virtual int Seq_No_Month { get; set; }
        public virtual int Seq_No_Day { get; set; }
        public virtual int Seq_No_Houre { get; set; }
        [RobotCMDListOrder(OrderNo = 3)]
        public virtual int CMD_Type { get; set; }
        [RobotCMDListOrder(OrderNo = 4)]
        public virtual string Arm { get; set; }
        [RobotCMDListOrder(OrderNo = 5)]
        public virtual string From_Loc { get; set; }
        [RobotCMDListOrder(OrderNo = 6)]
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
        [RobotCMDListOrder(OrderNo = 7)]
        public virtual int? Return_Code { get; set; }
        [RobotCMDListOrder(OrderNo = 8)]
        public virtual DateTime? Step_Start_Time { get; set; }
        [RobotCMDListOrder(OrderNo = 9)]
        public virtual DateTime? Step_End_Time { get; set; }
        public virtual string Crr_ID { get; set; }
        public virtual int Org_Seq_No { get; set; }  //A0.01

        public override bool Equals(object obj)
        {
            if (obj is RobotCommandList)
            {
                RobotCommandList second = obj as RobotCommandList;
                if (this.SeqCMD.Seq_No == second.SeqCMD.Seq_No
                    && this.SeqCMD.CMD_Step == second.SeqCMD.CMD_Step)
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

    public class SeqNoANDCMDStep
    {
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
    public class RobotCMDListOrder : Attribute
    {
        public int OrderNo { get; set; }

    }
}
