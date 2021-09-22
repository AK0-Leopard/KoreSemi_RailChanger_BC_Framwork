//*********************************************************************************
//      RobotCommandTable.cs
//*********************************************************************************
// File Name: RobotCommandTable.cs
// Description: RobotCommandTable類別
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

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class RobotCommandTable
    {

        [RobotCMDTableOrder(OrderNo = 1)]
        public virtual int Seq_No { get; set; }
        public virtual string Stk_ID { get; set; }
        [RobotCMDTableOrder(OrderNo = 2)]
        public virtual string Crr_ID { get; set; }
        /// <summary>
        ///Status_Change = 1;
        ///Timer = 2;
        ///Semi_Mode = 3;
        ///Timeout = 4;
        ///PreGet = 5;
        ///NoNextStation = 6;
        ///ReciveReady = 7;
        ///SendReady = 8;
        /// </summary>
        [RobotCMDTableOrder(OrderNo = 3)]
        public virtual int Gen_Source { get; set; }
        public virtual int Seq_No_Year { get; set; }
        public virtual int Seq_No_Month { get; set; }
        public virtual int Seq_No_Day { get; set; }
        public virtual int Seq_No_Hour { get; set; }
        [RobotCMDTableOrder(OrderNo = 4)]
        public virtual string From_Loc { get; set; }
        [RobotCMDTableOrder(OrderNo = 5)]
        public virtual string To_Loc { get; set; }

        //將DateTime的型別更改為DateTimeOffset的型別，藉此來將時間記錄至毫秒等級
        [RobotCMDTableOrder(OrderNo = 6)]
        public virtual DateTimeOffset? Status_Time { get; set; }
        [RobotCMDTableOrder(OrderNo = 7)]
        public virtual DateTimeOffset? Command_Gen_Time { get; set; }
        [RobotCMDTableOrder(OrderNo = 8)]
        public virtual DateTimeOffset? Step_Gen_Time { get; set; }
        [RobotCMDTableOrder(OrderNo = 9)]
        public virtual DateTimeOffset? Command_Send_Time { get; set; }
        [RobotCMDTableOrder(OrderNo = 10)]
        public virtual DateTimeOffset? Command_Start_Time { get; set; }
        [RobotCMDTableOrder(OrderNo = 11)]
        public virtual DateTimeOffset? Command_End_Time { get; set; }
        /// <summary>
        ///Gen=1,
        ///Send=2,
        ///Process_Wait= 3,
        ///Processing=4,
        ///Process_End=5,
        ///Robot_Cancel=8,
        ///Manul_Cancel=9
        /// </summary>
        [RobotCMDTableOrder(OrderNo = 12)]
        public virtual int Command_Status { get; set; }
        /// <summary>
        ///Co的定義:
        ///0=ACK,
        ///1=Busy,
        ///2=CIM Mode is Offline,
        ///3=Invaild prrameter,
        ///99=No RobotCMD
        ///1000=Timeout,
        ///2000=SendDataFail
        /// </summary>
        public virtual int? Command_Excute_Retune_Code { get; set; }
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
        [RobotCMDTableOrder(OrderNo = 13)]
        public virtual int? Step_Return_Code { get; set; }
        public virtual int Command_Prioty { get; set; }
        /// <summary>
        /// 僅供在Semi Auto 時提供選擇上下臂使用,及用來判斷此筆命令是否需要做Exchange
        /// </summary>
        [RobotCMDTableOrder(OrderNo = 14)]
        public virtual string UsingArm { get; set; }
        public virtual string Cmd_Sno { get; set; }
        public virtual string User_ID { get; set; }

        //不須DB欄位
        public bool IsToShelf { get; set; }
    }

    /// <summary>
    /// 來用排序Alarm His 在Data Grid View 的順序
    /// </summary>
    public class RobotCMDTableOrder : Attribute
    {
        //public AlarmOrder();

        public int OrderNo { get; set; }

    }
}
