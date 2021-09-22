//*********************************************************************************
//      Zone.cs
//*********************************************************************************
// File Name: Zone.cs
// Description: Zone類別
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
    public class Zone : BaseEQObject
    {
        //In DB
        public virtual string Zone_ID { get; set; }

        public virtual string Line_ID { get; set; }

        public Zone() 
        {
            eqptObjectCate = SCAppConstants.EQPT_OBJECT_CATE_ZONE;
        }

        public virtual string getEqptObjectKey()
        {
            return BCFUtility.generateEQObjectKey(eqptObjectCate, Zone_ID);
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
            List<Node> subNodeList = SCApplication.getInstance().getEQObjCacheManager().getNodeListByZone(Zone_ID);
            if (subNodeList != null)
            {
                foreach (Node node in subNodeList)
                {
                    node.doShareMemoryInit(runLevel);
                }
            }
        }

    }
}
