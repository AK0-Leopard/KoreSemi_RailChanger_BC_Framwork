//*********************************************************************************
//      Unit.cs
//*********************************************************************************
// File Name: Unit.cs
// Description: Unit類別
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
    public class Unit : BaseUnitObject
    {
        //In DB
        public virtual string Unit_ID { get; set; }

        public virtual int Unit_Num { get; set; }

        public virtual string Eqpt_ID { get; set; }

        public virtual string Unit_Cate { get; set; }

        public virtual string Eqpt_Type { get; set; }

        public virtual int Capacity { get; set; }

        private string unit_stat = "I";
        public virtual string Unit_Stat
        {
            get { return unit_stat; }
            set
            {
                if (unit_stat != value)
                {
                    unit_stat = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Unit_Stat));
                }
            }
        }

        private string carrier_id;
        public virtual string Carrier_ID
        {
            get { return carrier_id; }
            set
            {
                if (carrier_id != value)
                {
                    carrier_id = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Carrier_ID));
                }
            }
        }

        private string unit_Service = "O";
        public virtual string Unit_Service
        {
            get { return unit_Service; }
            set
            {
                if (unit_Service != value)
                {
                    unit_Service = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Unit_Service));
                }
            }
        }

        private string operation_status = "INIT";
        public virtual string Operation_Status
        {
            get { return operation_status; }
            set
            {
                if (operation_status != value)
                {
                    operation_status = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Operation_Status));
                }
            }
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
        }

    }
}
