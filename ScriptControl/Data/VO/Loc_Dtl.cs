//*********************************************************************************
//      Loc_Dtl.cs
//*********************************************************************************
// File Name: Loc_Dtl.cs
// Description: Loc_Dtl Object
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
    public class Loc_Dtl
    {
        public Loc_Dtl()
        {
            LocDtlPK = new LocDtlPKInfo();
        }

        public virtual LocDtlPKInfo LocDtlPK { get; set; }

        public virtual string Wh_ID { get { return LocDtlPK.Wh_ID; } set { LocDtlPK.Wh_ID = value; } }
        public virtual string Loc { get { return LocDtlPK.Loc; } set { LocDtlPK.Loc = value; } }
        public virtual string Loc_TxNo { get { return LocDtlPK.Loc_TxNo; } set { LocDtlPK.Loc_TxNo = value; } }
        public virtual string Store_Code { get; set; }
        public virtual string Bank_Code { get; set; }
        public virtual string Item_No { get; set; }
        public virtual string Lot_No { get; set; }
        public virtual int Plt_Qty { get; set; }
        public virtual int Alo_Qty { get; set; }
        public virtual string Expire_Date { get; set; }
        public virtual string Qc_Code { get; set; }
        public virtual string Item_Type { get; set; }
        public virtual string In_Date { get; set; }
        public virtual string In_Tkt_No { get; set; }
        public virtual string LocDtl01 { get; set; }
        public virtual string LocDtl02 { get; set; }
        public virtual string LocDtl03 { get; set; }
        public virtual string LocDtl04 { get; set; }
        public virtual string LocDtl05 { get; set; }
        public virtual string LocDtl06 { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Created_by { get; set; }
        public virtual string Created_Date { get; set; }
        public virtual string Trn_User { get; set; }
        //新欄位
        public virtual string Crr_ID { get; set; }
    }

    public class LocDtlPKInfo
    {
        public virtual string Wh_ID { get; set; }

        public virtual string Loc { get; set; }

        public virtual string Loc_TxNo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is LocDtlPKInfo)
            {
                LocDtlPKInfo pk = obj as LocDtlPKInfo;
                if (BCFUtility.isMatche(this.Wh_ID, pk.Wh_ID)
                    && BCFUtility.isMatche(this.Loc, pk.Loc)
                    && BCFUtility.isMatche(this.Loc_TxNo, pk.Loc_TxNo))
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