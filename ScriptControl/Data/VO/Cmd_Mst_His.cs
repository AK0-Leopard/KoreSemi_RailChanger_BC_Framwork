//*********************************************************************************
//      Cmd_Mst_His.cs
//*********************************************************************************
// File Name: Cmd_Mst_His.cs
// Description: Cmd_Mst_His Object
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
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Cmd_Mst_His
    {
        public virtual string Log_Sno { get; set; }
        public virtual string Cmd_Sno { get; set; }
        public virtual string Cmd_Sts { get; set; }
        public virtual string Cmd_Abnormal { get; set; }
        public virtual int Prty { get; set; }
        public virtual string Stn_No { get; set; }
        public virtual string Cmd_Mode { get; set; }
        public virtual string IO_Type { get; set; }
        public virtual string Wh_ID { get; set; }
        public virtual string Loc { get; set; }
        public virtual string New_Loc { get; set; }
        public virtual int Mix_Qty { get; set; }
        public virtual int Avail { get; set; }
        public virtual string Zone_ID { get; set; }
        public virtual string Crt_Date { get; set; }
        public virtual string Exp_Date { get; set; }
        public virtual string End_Date { get; set; }
        public virtual string Trn_User { get; set; }
        public virtual string Host_Name { get; set; }
        public virtual string Trace { get; set; }
        public virtual string Plt_Count { get; set; }
        public virtual string Equ_No { get; set; }
        public virtual string Xfr_Speed { get; set; }
        public virtual string Cmd_Stat { get; set; }
        public virtual string Ticket_No { get; set; }
        public virtual string OutPort_Flg { get; set; }
        public virtual string Cmd_No { get; set; }
        public virtual string Cmd_Name { get; set; }
    }

}