//*********************************************************************************
//      Tkt_Mst.cs
//*********************************************************************************
// File Name: Tkt_Mst.cs
// Description: Tkt_Mst Object
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
    public class Tkt_Mst
    {
        public Tkt_Mst()
        {
            TktMstPK = new TktMstPKInfo();
        }

        public virtual TktMstPKInfo TktMstPK { get; set; }

        public virtual string Tkt_Type { get { return TktMstPK.Tkt_Type; } set { TktMstPK.Tkt_Type = value; } }
        public virtual string Tkt_No { get { return TktMstPK.Tkt_No; } set { TktMstPK.Tkt_No = value; } }
        public virtual string Tkt_Seq { get { return TktMstPK.Tkt_Seq; } set { TktMstPK.Tkt_Seq = value; } }
        public virtual string Down_Date { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Trn_User { get; set; }
        public virtual string Tkt_Io { get; set; }
        public virtual string Tkt_Sts { get; set; }
        public virtual int Proc_Qty { get; set; }
        public virtual int Act_Qty { get; set; }
        public virtual int Plan_Qty { get; set; }
        public virtual string Expire_Date { get; set; }
        public virtual string Item_No { get; set; }
        public virtual string Lot_No { get; set; }
        public virtual string Store_Code { get; set; }
        public virtual string Bank_Code { get; set; }
        public virtual string Qc_Code { get; set; }
        public virtual string Item_Type { get; set; }
        public virtual string TktMst01 { get; set; }
        public virtual string TktMst02 { get; set; }
        public virtual string TktMst03 { get; set; }
        public virtual string TktMst04 { get; set; }
        public virtual string TktMst05 { get; set; }
        public virtual string Created_by { get; set; }
        public virtual string Created_Date { get; set; }
        public virtual string Updated_Date { get; set; }
        public virtual string Updated_by { get; set; }
    }

    public class TktMstPKInfo
    {
        public virtual string Tkt_Type { get; set; }

        public virtual string Tkt_No { get; set; }

        public virtual string Tkt_Seq { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TktMstPKInfo)
            {
                TktMstPKInfo pk = obj as TktMstPKInfo;
                if (BCFUtility.isMatche(this.Tkt_Type, pk.Tkt_Type)
                    && BCFUtility.isMatche(this.Tkt_No, pk.Tkt_No)
                    && BCFUtility.isMatche(this.Tkt_Seq, pk.Tkt_Seq))
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