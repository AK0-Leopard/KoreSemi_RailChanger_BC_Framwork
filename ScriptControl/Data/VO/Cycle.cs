//*********************************************************************************
//      Cycle.cs
//*********************************************************************************
// File Name: Cycle.cs
// Description: Cycle Object
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
    public class Cycle
    {
        public Cycle()
        {
            CyclePK = new CyclePKInfo();
        }

        public virtual CyclePKInfo CyclePK { get; set; }

        public virtual string Cyc_No { get { return CyclePK.Cyc_No; } set { CyclePK.Cyc_No = value; } }
        public virtual string Wh_ID { get { return CyclePK.Wh_ID; } set { CyclePK.Wh_ID = value; } }
        public virtual string Loc { get { return CyclePK.Loc; } set { CyclePK.Loc = value; } }
        public virtual string Loc_TxNo { get { return CyclePK.Loc_TxNo; } set { CyclePK.Loc_TxNo = value; } }
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
        public virtual int Cyc_Qty { get; set; }
        public virtual string Status { get; set; }
        public virtual string LocDtl01 { get; set; }
        public virtual string LocDtl02 { get; set; }
        public virtual string LocDtl03 { get; set; }
        public virtual string LocDtl04 { get; set; }
        public virtual string LocDtl05 { get; set; }
        public virtual string LocDtl06 { get; set; }
        public virtual string LocDtl07 { get; set; }
        public virtual string LocDtl08 { get; set; }
        public virtual string LocDtl09 { get; set; }
        public virtual string LocDtl10 { get; set; }
        public virtual string Crr_ID { get; set; }
    }

    public class CyclePKInfo
    {
        public virtual string Cyc_No { get; set; }

        public virtual string Wh_ID { get; set; }

        public virtual string Loc { get; set; }

        public virtual string Loc_TxNo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CyclePKInfo)
            {
                CyclePKInfo pk = obj as CyclePKInfo;
                if (BCFUtility.isMatche(this.Cyc_No, pk.Cyc_No)
                    && BCFUtility.isMatche(this.Wh_ID, pk.Wh_ID)
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