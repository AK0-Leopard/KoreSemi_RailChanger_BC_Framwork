//*********************************************************************************
//      Cmd_Dtl_His.cs
//*********************************************************************************
// File Name: Cmd_Dtl_His.cs
// Description: Cmd_Dtl_His Object
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
    public class Cmd_Dtl_His
    {
        public virtual string Log_Sno { get; set; }
        public virtual string Cmd_Sno { get; set; }
        public virtual string Loc_TxNo { get; set; }
        public virtual string Cmd_TxNo { get; set; }
        public virtual string In_Date { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Cycle_Date { get; set; }
        public virtual string Cyc_No { get; set; }
        public virtual string Expire_Date { get; set; }
        public virtual string Item_No { get; set; }
        public virtual string Tkt_No { get; set; }
        public virtual string Tkt_Seq { get; set; }
        public virtual string Lot_No { get; set; }
        public virtual string Store_Code { get; set; }
        public virtual string Bank_Code { get; set; }
        public virtual string Qc_Code { get; set; }
        public virtual string Item_Type { get; set; }
        public virtual int Plt_Qty { get; set; }
        public virtual int Alo_Qty { get; set; }
        public virtual string LocDtl01 { get; set; }
        public virtual string LocDtl02 { get; set; }
        public virtual string LocDtl03 { get; set; }
        public virtual string LocDtl04 { get; set; }
        public virtual string LocDtl05 { get; set; }
        //新欄位
        public virtual string Crr_ID { get; set; }
    }

}