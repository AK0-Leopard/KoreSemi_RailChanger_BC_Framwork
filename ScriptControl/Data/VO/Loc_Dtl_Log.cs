//*********************************************************************************
//      Loc_Dtl_Log.cs
//*********************************************************************************
// File Name: Loc_Dtl_Log.cs
// Description: Loc_Dtl_Log Object
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
    public class Loc_Dtl_Log
    {
        public Loc_Dtl_Log()
        {
            LocDtlLogPK = new LocDtlLogPKInfo();
        }

        public virtual LocDtlLogPKInfo LocDtlLogPK { get; set; }

        public virtual string Wh_ID { get { return LocDtlLogPK.Wh_ID; } set { LocDtlLogPK.Wh_ID = value; } }
        public virtual string Loc { get { return LocDtlLogPK.Loc; } set { LocDtlLogPK.Loc = value; } }
        public virtual string Loc_TxNo { get { return LocDtlLogPK.Loc_TxNo; } set { LocDtlLogPK.Loc_TxNo = value; } }
        public virtual string Created_Date { get { return LocDtlLogPK.Created_Date; } set { LocDtlLogPK.Created_Date = value; } }
        public virtual string In_Date { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Cycle_Date { get; set; }
        public virtual string Expire_Date { get; set; }
        public virtual string Item_No { get; set; }
        public virtual string In_Tkt_No { get; set; }
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
        public virtual string LocDtl06 { get; set; }
        public virtual string Created_by { get; set; }
        public virtual string Updated_Date { get; set; }
        public virtual string Updated_by { get; set; }
        public virtual string Flag { get; set; }
        public virtual string Cmd_Sno { get; set; }
    }

    public class LocDtlLogPKInfo
    {
        public virtual string Wh_ID { get; set; }

        public virtual string Loc { get; set; }

        public virtual string Loc_TxNo { get; set; }

        public virtual string Created_Date { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is LocDtlLogPKInfo)
            {
                LocDtlLogPKInfo pk = obj as LocDtlLogPKInfo;
                if (BCFUtility.isMatche(this.Wh_ID, pk.Wh_ID)
                    && BCFUtility.isMatche(this.Loc, pk.Loc)
                    && BCFUtility.isMatche(this.Loc_TxNo, pk.Loc_TxNo)
                    && BCFUtility.isMatche(this.Created_Date, pk.Created_Date))
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

}