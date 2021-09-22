//*********************************************************************************
//      Cmd_Dtl.cs
//*********************************************************************************
// File Name: Cmd_Dtl.cs
// Description: Cmd_Dtl Object
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
    public class Cmd_Dtl
    {
        public Cmd_Dtl()
        {
            CmdDtlPK = new CmdDtlPKInfo();
        }

        public virtual CmdDtlPKInfo CmdDtlPK { get; set; }

        public virtual string Cmd_Sno { get { return CmdDtlPK.Cmd_Sno; } set { CmdDtlPK.Cmd_Sno = value; } }
        public virtual string Loc_TxNo { get { return CmdDtlPK.Loc_TxNo; } set { CmdDtlPK.Loc_TxNo = value; } }
        public virtual string Cmd_TxNo { get { return CmdDtlPK.Cmd_TxNo; } set { CmdDtlPK.Cmd_TxNo = value; } }
        public virtual string In_Date { get; set; }
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
        public virtual string Cycle_Date { get; set; }
        public virtual string Cyc_No { get; set; }
        public virtual string LocDtl01 { get; set; }
        public virtual string LocDtl02 { get; set; }
        public virtual string LocDtl03 { get; set; }
        public virtual string LocDtl04 { get; set; }
        public virtual string LocDtl05 { get; set; }
        public virtual string Trn_Date { get; set; }
        //新欄位
        public virtual string Crr_ID { get; set; }
    }

    public class CmdDtlPKInfo
    {
        public virtual string Cmd_Sno { get; set; }

        public virtual string Loc_TxNo { get; set; }

        public virtual string Cmd_TxNo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CmdDtlPKInfo)
            {
                CmdDtlPKInfo pk = obj as CmdDtlPKInfo;
                if (BCFUtility.isMatche(this.Cmd_Sno, pk.Cmd_Sno)
                    && BCFUtility.isMatche(this.Loc_TxNo, pk.Loc_TxNo)
                    && BCFUtility.isMatche(this.Cmd_TxNo, pk.Cmd_TxNo))
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