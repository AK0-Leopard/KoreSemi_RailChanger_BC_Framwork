//*********************************************************************************
//      Trn_Log.cs
//*********************************************************************************
// File Name: Trn_Log.cs
// Description: Trn_Log Object
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
    public class Trn_Log
    {
        public virtual string Log_Date { get; set; }
        public virtual string Cmd_Sno { get; set; }
        public virtual string Cmd_TxNo { get; set; }
        public virtual string Cmd_Sts { get; set; }
        public virtual string Cmd_Abnormal { get; set; }
        public virtual int Prty { get; set; }
        public virtual string Stn_No { get; set; }
        public virtual string Cmd_Mode { get; set; }
        public virtual string Io_Type { get; set; }
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
        public virtual string Loc_TxNo { get; set; }
        public virtual string Item_No { get; set; }
        public virtual string Lot_No { get; set; }
        public virtual string Qc_Code { get; set; }
        public virtual string Item_Type { get; set; }
        public virtual int Plt_Qty { get; set; }
        public virtual int Trn_Qty { get; set; }
        public virtual string In_Date { get; set; }
        public virtual string Expire_Date { get; set; }
        public virtual string In_Tkt_No { get; set; }
        public virtual string In_Tkt_Seq { get; set; }
        public virtual string Store_Code { get; set; }
        public virtual string Bank_Code { get; set; }
        public virtual string Trn_Tkt_No { get; set; }
        public virtual string Trn_Tkt_Seq { get; set; }
        public virtual string Cyc_No { get; set; }
        public virtual string Cyc_Date { get; set; }
        public virtual string LocDtl01 { get; set; }
        public virtual string LocDtl02 { get; set; }
        public virtual string LocDtl03 { get; set; }
        public virtual string LocDtl04 { get; set; }
        public virtual string LocDtl05 { get; set; }
        public virtual string LocDtl06 { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Created_by { get; set; }
        public virtual string Created_Date { get; set; }
        public virtual string Updated_Date { get; set; }
        public virtual string Updated_by { get; set; }
        public virtual string Prog_ID { get; set; }
        public virtual int Xfr_Speed { get; set; }
        public virtual int Alo_Qty { get; set; }
        public virtual string OutPort_Flg { get; set; }
        public virtual string Cmd_No { get; set; }
        public virtual string Cmd_Name { get; set; }
    }

}