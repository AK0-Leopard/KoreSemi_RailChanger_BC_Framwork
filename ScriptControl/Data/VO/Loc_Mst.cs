//*********************************************************************************
//      Loc_Mst.cs
//*********************************************************************************
// File Name: Loc_Mst.cs
// Description: Loc_Mst Object
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
    public class Loc_Mst
    {
        public Loc_Mst()
        {
            LocMstPK = new LocMstPKInfo();
        }

        public virtual LocMstPKInfo LocMstPK { get; set; }

        public virtual string Wh_ID { get { return LocMstPK.Wh_ID; } set { LocMstPK.Wh_ID = value; } }
        public virtual string Loc { get { return LocMstPK.Loc; } set { LocMstPK.Loc = value; } }
        public virtual string Loc_Sts { get; set; }
        public virtual string Old_Sts { get; set; }
        public virtual int Mix_Qty { get; set; }
        public virtual int Avail { get; set; }
        public virtual int Row_X { get; set; }
        public virtual int Bay_Y { get; set; }
        public virtual int Lvl_Z { get; set; }
        public virtual string Loc_ID { get; set; }
        public virtual string Loc_Size { get; set; }
        public virtual string Zone_ID { get; set; }
        public virtual string Cycle_Date { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Loc_DD { get; set; }
        public virtual string Storage_Type { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Creater_By { get; set; }
        public virtual string Inhibit_By { get; set; }
        public virtual string Trn_User { get; set; }
        public virtual string Equ_No { get; set; }
        public virtual string Equ_RowNo { get; set; }
        public virtual string Plt_Count { get; set; }
        
        //新欄位
        public virtual int Enable_Flag { get; set; }

        //不儲存在Table中
        public virtual string UnloadTime { get; set; }
    }

    public class LocMstPKInfo
    {
        public virtual string Wh_ID { get; set; }

        public virtual string Loc { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is LocMstPKInfo)
            {
                LocMstPKInfo pk = obj as LocMstPKInfo;
                if (BCFUtility.isMatche(this.Wh_ID, pk.Wh_ID)
                    && BCFUtility.isMatche(this.Loc, pk.Loc))
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