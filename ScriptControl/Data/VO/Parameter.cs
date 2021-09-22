//*********************************************************************************
//      Parameter.cs
//*********************************************************************************
// File Name: Parameter.cs
// Description: Parameter Object
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
    public class Parameter
    {
        public Parameter()
        {
            ParaPK = new ParaPKInfo();
        }

        public virtual ParaPKInfo ParaPK { get; set; }

        [ParaOrder(OrderNo=1)]
        public virtual string Para_Cate { get { return ParaPK.Para_Cate; } set { ParaPK.Para_Cate = value; } }
        [ParaOrder(OrderNo = 2)]
        public virtual string Para_ID { get { return ParaPK.Para_ID; } set { ParaPK.Para_ID = value; } }
        [ParaOrder(OrderNo = 3)]
        public virtual string Val_1 { get; set; }
        [ParaOrder(OrderNo = 4)]
        public virtual string Val_2 { get; set; }
        [ParaOrder(OrderNo = 5)]
        public virtual string Val_3 { get; set; }
        [ParaOrder(OrderNo = 6)]
        public virtual string Val_4 { get; set; }
        [ParaOrder(OrderNo = 7)]
        public virtual string Val_5 { get; set; }
        [ParaOrder(OrderNo = 7)]
        public virtual string Para_Desc { get; set; }

    }

    public class ParaPKInfo
    {
        public virtual string Para_Cate { get; set; }

        public virtual string Para_ID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ParaPKInfo)
            {
                ParaPKInfo pk = obj as ParaPKInfo;
                if (BCFUtility.isMatche(this.Para_Cate, pk.Para_Cate)
                    && BCFUtility.isMatche(this.Para_ID, pk.Para_ID))
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

   /// <summary>
   /// 來用排序Parameter在Data Grid View 的順序
   /// </summary>
   public class ParaOrder : Attribute
    {
        public int OrderNo { get; set; }

    }

}