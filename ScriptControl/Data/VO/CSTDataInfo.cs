//*********************************************************************************
//      CSTInfo.cs
//*********************************************************************************
// File Name: CSTInfo.cs
// Description: CST Data修改畫面
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2017/10/11    Steven Hong    N/A            N/A     Initial Create
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Data.SECS;
using NLog;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.bcf.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CSTDataInfo
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        public Boolean hasEdited = false;

        public string Port_ID { get; set; }
        public string Port_Use_Type { get; set; }
        public string Port_Type { get; set; }
        public string CST_ID { get; set; }
        public string LOT_ID { get; set; }
        public string SPLIT_ID { get; set; }
        public string Product_ID { get; set; }
        public string EC_CODE { get; set; }
        public string Next_Route_ID { get; set; }
        public string Next_Route_Version { get; set; }
        public string Next_Process_ID { get; set; }
        public string Next_Oper_No { get; set; }
        public string Next_Oper_Version { get; set; }
        public string Next_Oper_desc { get; set; }
        public string Next_Oper_ID { get; set; }
        public string Priority { get; set; }
        public string Sheet_Cnt { get; set; }
        public string Panel_Cnt { get; set; }
        public string Recipe_ID { get; set; }
        public string Rework_Cnt { get; set; }
        public string Max_Rework_Cnt { get; set; }
        public string PPBody { get; set; }
        public string Logof_EQPT_ID { get; set; }
        public string Logof_PORT_ID { get; set; }
        public string Logof_Recipe_ID { get; set; }
        public string Sheet_Group_ID { get; set; }
        public string Use_Partial_Flag { get; set; }
        public string Layout_Size { get; set; }
        public string Thickness { get; set; }
        public string Array_SHT_Cnt { get; set; }
        public string Job_Sequence { get; set; }


        public List<GlassDataInfo> GlassDataList { get; set; }

        public class GlassDataInfo
        {
            public string Slot_NO { get; set; }
            public string Sheet_ID { get; set; }
            public string Product_ID { get; set; }
            public string Sheet_Group_ID { get; set; }
            public string Verify_Oper_Proc_Flag { get; set; }
            public string Rework_Cnt { get; set; }
            public string Sample_Flag { get; set; }


            //public string Lot_ID { get; set; }
            //public string Lot_Sort_Type { get; set; }
            //public string Oper_ID { get; set; }
            //public string Model_Type { get; set; }
            //public string Prod_Type { get; set; }
            //public string Work_Order { get; set; }
            //public string Glass_THK { get; set; }
            //public string PPID { get; set; }
            //public string Glass_Judge { get; set; }
            //public string Glass_Grade { get; set; }
            //public string Sample_Flag { get; set; }
            //public string Rework_Count { get; set; }
            //public string Panel_Judge { get; set; }
            //public string Panel_Grade { get; set; }
            //public string Dummy_Type { get; set; }
            //public string Dummy_Used_Count { get; set; }
            //public string PPID_Version { get; set; }
            //public string Batch_ID { get; set; }
            //public string Batch_Mix_Flag { get; set; }
            //public string Job_Type { get; set; }
            //public string COP_ID { get; set; }
            //public string Print_Flag { get; set; }

            //public List<string> UnitList { get; set; }
            //public List<ExpInfo> ExpList { get; set; }
            //public List<string> SmplList { get; set; }
            //public List<QPanelInfo> QPnlList { get; set; }

            #region No Use
            //public string Glass_Type { get; set; }
            //public string Glass_ID_Type { get; set; }
            //public string Maker { get; set; }
            //public string Glass_Size { get; set; }
            //public string Mask_ID { get; set; }
            //public string Prober_ID { get; set; }
            //public string Array_Repair_Type { get; set; }
            //public string LCVD_Repair_Type { get; set; }
            //public string Exp_Unit_ID { get; set; }
            //public string Exp_Recipe_ID { get; set; }
            //public string Lot_Judge { get; set; }
            #endregion

            //public class ExpInfo
            //{
            //    public string Exp_Unit_ID;
            //    public string Exp_Recipe_ID;
            //}

            //public class QPanelInfo
            //{
            //    public string QPnl_ID;
            //    public string QPnl_Type;
            //    public string QPnl_Judge;
            //    public string QPnl_Grade;
            //}
        }


    }
}
