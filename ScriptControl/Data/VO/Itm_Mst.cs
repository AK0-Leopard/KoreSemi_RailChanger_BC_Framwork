//*********************************************************************************
//      Itm_Mst.cs
//*********************************************************************************
// File Name: Itm_Mst.cs
// Description: Itm_Mst Object
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
    public class Itm_Mst
    {
        public virtual string Item_No { get; set; }
        public virtual string Item_Name { get; set; }
        public virtual string Item_Spec { get; set; }
        public virtual string Item_Unit { get; set; }
        public virtual string Item_Unite { get; set; }
        public virtual string Item_Type { get; set; }
        public virtual string Item_Grp { get; set; }
        public virtual int Qty_Box { get; set; }
        public virtual int Box_Plt { get; set; }
        public virtual int Qty_Plt { get; set; }
        public virtual int Safe_Height { get; set; }
        public virtual int Safe_low { get; set; }
        public virtual int Unit_Wg { get; set; }
        public virtual int Valid_Days { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Create_User { get; set; }
        public virtual string Create_Date { get; set; }
        public virtual string Trn_Date { get; set; }
        public virtual string Trn_User { get; set; }
        public virtual string Note1 { get; set; }
    }

}