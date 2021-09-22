//*********************************************************************************
//      Node.cs
//*********************************************************************************
// File Name: Node.cs
// Description: Node類別
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
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Node : BaseEQObject
    {
        //DB
        public virtual string Node_ID { get; set; }

        public virtual string Zone_ID { get; set; }

        //Not in DB
        [BaseElement(NonChangeFromOtherVO = true)]
        public virtual int Recipe_Index { get; set; }

        [BaseElement(NonChangeFromOtherVO=true)]
        public virtual int Node_Num { get; set; } 

        public Node() 
        {
            eqptObjectCate = SCAppConstants.EQPT_OBJECT_CATE_NODE;
            Recipe_Index = -1; 
        }

        public virtual string getEqptObjectKey()
        {
            return BCFUtility.generateEQObjectKey(eqptObjectCate, Node_ID);
        }

        /// <summary>
        /// 開始執行初始化動作
        /// </summary>
        public override void doShareMemoryInit(BCFAppConstants.RUN_LEVEL runLevel)
        {
            foreach (IValueDefMapAction action in valueDefMapActionDic.Values)
            {
                action.doShareMemoryInit(runLevel);
            }
            //對sub eqpt進行初始化
            List<Equipment> subEqptList = SCApplication.getInstance().getEQObjCacheManager().getEuipmentListByNode(Node_ID);
            if (subEqptList != null)
            {
                foreach (Equipment eqpt in subEqptList)
                {
                    eqpt.doShareMemoryInit(runLevel);
                }
            }
        }

    }
}
