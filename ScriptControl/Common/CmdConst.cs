//*********************************************************************************
//      SECSConst.cs
//*********************************************************************************
// File Name: SECSConst.cs
// Description: SECSConst
//
//(c) Copyright 2017, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.stc.Common.SECS;

namespace com.mirle.ibg3k0.sc.Data.SECS
{
    public class CmdConst
    {

        #region CRST
        public static readonly string CRST_Off_Line = "O";
        public static readonly string CRST_On_Line_Remote = "R";
        public static readonly string CRST_On_Line_Local = "L";
        
        public static readonly string BOE_CRST_Off_Line = "0";
        public static readonly string BOE_CRST_On_Line_Remote = "1";
        public static readonly string BOE_CRST_On_Line_Local = "2";
        
        public static readonly string[] CRST = 
        {
            CRST_Off_Line,
            CRST_On_Line_Remote,
            CRST_On_Line_Local,
            BOE_CRST_Off_Line,
            BOE_CRST_On_Line_Remote,
            BOE_CRST_On_Line_Local
        };
        #endregion CRST

        #region EQST
        public static readonly string EQST_IDLE = "I";
        public static readonly string EQST_RUN = "R";
        public static readonly string EQST_DOWN = "D";
        public static readonly string EQST_MAINTENANCE = "M";
        public static readonly string EQST_OTHER = "O";
        #endregion EQST
        
        #region TRSMODE
        public static readonly string TRSMODE_AUTO = "1";
        public static readonly string TRSMODE_Manual = "2";
        #endregion TRSMODE

        #region HCACK
        public static readonly string HCACK_Confirm_Executed = "0";
        public static readonly string HCACK_Command_Not_Exist = "1";
        public static readonly string HCACK_Not_Able_Execute = "2";
        public static readonly string HCACK_Param_Invalid = "3";
        public static readonly string HCACK_Confirm = "4";
        public static readonly string HCACK_Rejected = "5";
        public static readonly string HCACK_Obj_Not_Exist = "6";
        #endregion HCACK

        #region CEID
        /// <summary>
        /// 用來代表所有的CEID（於Enable、Disable All CEID時會使用到）。
        /// </summary>
        public static readonly string CEID_ALL_CEID = "000";
        //CEID Remark Begin
        public static readonly string CEID_Oper_Mode_Status_Change = "103";
        public static readonly string CEID_Flow_Control_Mode_Change = "104";
        public static readonly string CEID_Unit_Status_Change = "105";
        public static readonly string CEID_Sub_Unit_Status_Change = "106";
        public static readonly string CEID_Reticle_Status_Change = "107";
        //Material State Change
        public static readonly string CEID_Material_State_Change = "108";
        //Equipment Constant Change
        public static readonly string CEID_Equipment_Constant_Change = "109";
        //Ready To Start
        public static readonly string CEID_Ready_To_Start = "110";
        //Control State Change & Equipment Status Change
        public static readonly string CEID_Control_State_Change_OFF_LINE = "111";
        public static readonly string CEID_Control_State_Change_ON_LINE_LOCAL = "112";
        public static readonly string CEID_Control_State_Change_ON_LINE_REMOTE = "113";
        public static readonly string CEID_Equipment_Status_Change = "114";
        //Current Flow Control Mode Change
        public static readonly string CEID_Current_Flow_Control_Mode_Change = "115";
        //Operator Confirm Event about Operator Call Command
        public static readonly string CEID_Operator_Confirm = "118";
        //Port Status & Transfer Mode Change (CEID 200 ~ 209)
        public static readonly string CEID_Load_Request = "200";
        public static readonly string CEID_Pre_Load_Complete = "201";
        public static readonly string CEID_Load_Complete = "202";
        public static readonly string CEID_Unload_Request = "203";
        public static readonly string CEID_Unload_Complete = "204";
        public static readonly string CEID_Port_Diable_Changed = "205";
        public static readonly string CEID_Port_Enable_Changed = "206";
        public static readonly string CEID_Transfer_Mode_Changed = "207";
        public static readonly string CEID_Port_Use_Type_Changed = "208";
        public static readonly string CEID_Port_Type_Changed = "209";
        //Crate Port Status & Transfer Mode Change (CEID 210 ~ 219)
        public static readonly string CEID_Crate_Port_Load_Request = "210";
        public static readonly string CEID_Crate_Port_Load_Complete = "211";
        public static readonly string CEID_Crate_Port_Unload_Request = "212";
        public static readonly string CEID_Crate_Port_Unload_Complete = "213";
        public static readonly string CEID_Crate_Port_Port_Disabled = "214";        //The Port must be empty before the event happens
        public static readonly string CEID_Crate_Port_Port_Enabled = "215";         //The port must be empty before the event happens
        public static readonly string CEID_Crate_Port_Transfer_Mode_Change = "216"; //AGV or MGV / Use of Port Type
        public static readonly string CEID_Remained_Glass_Count_Of_Crate_Report = "217";
        public static readonly string CEID_Crate_Port_Use_Type_Change = "218";
        //Mask Cassette Port Status & Transfer Mode Change (CEID 220 ~ 229)
        public static readonly string CEID_Mask_Cassette_Port_Load_Request = "220";
        public static readonly string CEID_Mask_Cassette_Port_Pre_Load_Complete = "221";
        public static readonly string CEID_Mask_Cassette_Port_Load_Complete = "222";
        public static readonly string CEID_Mask_Cassette_Port_Unload_Request = "223";
        public static readonly string CEID_Mask_Cassette_Port_Unload_Complete = "224";
        public static readonly string CEID_Mask_Cassette_Port_Disable_Changed = "225";
        public static readonly string CEID_Mask_Cassette_Port_Enable_Changed = "226";
        public static readonly string CEID_Mask_Cassette_Port_Type_Changed = "227";
        public static readonly string CEID_Mask_Cassette_Port_Use_Type_Changed = "228";
        public static readonly string CEID_Mask_Cassette_Port_Transfer_Mode_Changed = "229";
        //Process Status (CEID 301 ~ 305)
        public static readonly string CEID_Process_Start = "301";
        public static readonly string CEID_Process_Cancel = "302";
        public static readonly string CEID_Process_Abort = "303";
        public static readonly string CEID_Process_Pause = "304";
        public static readonly string CEID_Process_Resume = "305";
        //Unit Process Status
        public static readonly string CEID_Unit_Process_Start = "306";
        public static readonly string CEID_Unit_Process_End = "307";
        //Sub-Unit Process Status
        public static readonly string CEID_Sub_Unit_Process_Start = "308";
        public static readonly string CEID_Sub_Unit_Process_End = "309";
        //Last Glass Process Start
        public static readonly string CEID_Last_Glass_Process_Start = "311";
        //Glass Out/In
        public static readonly string CEID_Glass_Out_By_Indexer_Port = "321";
        public static readonly string CEID_Glass_In_By_Indexer_Port = "322";
        public static readonly string CEID_Glass_Out_By_Unit = "323";
        public static readonly string CEID_Glass_In_By_Unit = "324";
        public static readonly string CEID_Glass_Out_By_Sub_Unit = "325";
        public static readonly string CEID_Glass_In_By_Sub_Unit = "326";
        public static readonly string CEID_Glass_Out_By_Buffer = "327";
        public static readonly string CEID_Glass_In_By_Buffer = "328";
        //Glass Scrap / Unscrap
        public static readonly string CEID_Glass_Scrap = "331";
        //Glass Out/In EQP
        public static readonly string CEID_Glass_Out_By_EQP = "332";
        public static readonly string CEID_Glass_In_By_EQP = "333";
        //Glass Turn
        public static readonly string CEID_Glass_Turn = "334";
        //Panel Out/In
        public static readonly string CEID_Panel_Out_By_Indexer = "341";
        public static readonly string CEID_Panel_In_By_Indexer = "342";
        public static readonly string CEID_Panel_Out_By_Unit = "343";
        public static readonly string CEID_Panel_In_By_Unit = "344";
        public static readonly string CEID_Panel_Out_By_Sub_Unit = "345";
        public static readonly string CEID_Panel_In_By_Sub_Unit = "346";
        //Panel Scrap
        public static readonly string CEID_Panel_Scrap = "351";
        //Panel Out/In EQP
        public static readonly string CEID_Panel_Out_By_EQP = "352";
        public static readonly string CEID_Panel_In_By_EQP = "353";
        //Cassette Out/In Unit
        public static readonly string CEID_Cassette_Out_By_Unit = "363";
        public static readonly string CEID_Cassette_In_By_Unit = "364";
        //Cassette Out/In Sub-Unit
        public static readonly string CEID_Cassette_Out_By_Sub_Unit = "365";
        public static readonly string CEID_Cassette_In_By_Sub_Unit = "366";
        //Sub Cassette Out/In By Indexer
        public static readonly string CEID_Sub_Cassette_Out_By_Indexer = "371";
        public static readonly string CEID_Sub_Cassette_In_By_Indexer = "372";
        //Sub Cassette Out/In By Unit
        public static readonly string CEID_Sub_Cassette_Out_By_Unit = "373";
        public static readonly string CEID_Sub_Cassette_In_By_Unit = "374";
        //Panel Out/In By Sub Cassette
        public static readonly string CEID_Panel_Out_By_Sub_Cassette = "375";
        public static readonly string CEID_Panel_In_By_Sub_Cassette = "376";
        //Sub Cassette Empty
        public static readonly string CEID_Sub_Cassette_Empty = "377";
        //Process Program or Recipe Change
        public static readonly string CEID_Proc_Prog_or_Recipe_Change = "401";
        //Lamination Complete
        public static readonly string CEID_Lamination_Complete = "402";
        //Box Weighting Complete
        public static readonly string CEID_Box_Weighting_Complete = "403";
        //Assemble Complete Event
        public static readonly string CEID_Assemble_Complete_Event = "411";
        //Glass Cut Process
        public static readonly string CEID_Glass_Cut_Process = "412";
        //Cutting Complete Event
        public static readonly string CEID_2_Cutting_Complete = "413";
        public static readonly string CEID_1_Cutting_Complete = "414";
        //Sorting Job Event
        public static readonly string CEID_Sorting_Job_Process_Start = "431";
        public static readonly string CEID_Sorting_Job_Process_End = "432";
        public static readonly string CEID_Sorting_Job_Cancel_Begin = "433";
        public static readonly string CEID_Sorting_Job_Cancel_End = "434";
        public static readonly string CEID_Sorting_Job_Abort_Begin = "435";
        public static readonly string CEID_Sorting_Job_Abort_End = "436";
        //VCR Data Read
        public static readonly string CEID_VCR_Data_Read = "460"; //A0.01
        //Process Data
        public static readonly string CEID_Glass_Process_Data = "500";
        public static readonly string CEID_Lot_Process_Data = "501";
        public static readonly string CEID_Exposure_Feedback_Data = "502";
        //Panel Process State (Lamination Line)
        public static readonly string CEID_Panel_Process_Start_Lamination = "503";
        public static readonly string CEID_Panel_Process_End_Lamination = "504";
        //Panel Lamination Scrap (Lamination Line)
        public static readonly string CEID_Panel_Scrap_Lamination = "511";
        //Panel Out/In By EQP (Lamination Line)
        public static readonly string CEID_Panel_Out_By_EQP_Lamination = "512";
        public static readonly string CEID_Panel_In_By_EQP_Lamination = "513";
        //Pallet Load/Unload Complete, Boxing Complete
        public static readonly string CEID_Pallet_Load_Complete = "522";
        public static readonly string CEID_Pallet_Boxing_Complete = "523";
        public static readonly string CEID_Pallet_Unload_Complete = "524";
        //Lot Info
        public static readonly string CEID_LOT_Information_Upload = "601";  //M0.02
        //Mask Use Count
        public static readonly string CEID_Mask_Use_Count = "700"; //A0.02
        public static readonly string CEID_Recycle_Mode = "701"; //A0.02
        //CEID Remark End
        #region CEID Array
        public static readonly string[] CEID_ARRAY = 
        {
          CEID_Oper_Mode_Status_Change,
              //CEID_Oper_Mode_Status_Change,
          CEID_Flow_Control_Mode_Change,
          CEID_Unit_Status_Change,
          CEID_Sub_Unit_Status_Change,
          CEID_Reticle_Status_Change,
        //Material State Change
          CEID_Material_State_Change,
        //Equipment Constant Change
          CEID_Equipment_Constant_Change,
        //Ready To Start
          CEID_Ready_To_Start,
        //Control State Change & Equipment Status Change
          CEID_Control_State_Change_OFF_LINE,
          CEID_Control_State_Change_ON_LINE_LOCAL,
          CEID_Control_State_Change_ON_LINE_REMOTE,
          CEID_Equipment_Status_Change,
          CEID_Current_Flow_Control_Mode_Change,
        //Operator Confirm Event about Operator Call Command
          CEID_Operator_Confirm,
        //Port Status & Transfer Mode Change (CEID 200 ~ 209)
          CEID_Load_Request,
          CEID_Pre_Load_Complete,
          CEID_Load_Complete,
          CEID_Unload_Request,
          CEID_Unload_Complete,
          CEID_Port_Diable_Changed,
          CEID_Port_Enable_Changed,
          CEID_Port_Type_Changed,
          CEID_Port_Use_Type_Changed,
          CEID_Transfer_Mode_Changed ,
        //Crate Port Status & Transfer Mode Change (CEID 210 ~ 219)
          CEID_Crate_Port_Load_Request,
          CEID_Crate_Port_Load_Complete,
          CEID_Crate_Port_Unload_Request,
          CEID_Crate_Port_Unload_Complete,
          CEID_Crate_Port_Port_Disabled,        //The Port must be empty before the event happens
          CEID_Crate_Port_Port_Enabled,        //The port must be empty before the event happens
          CEID_Remained_Glass_Count_Of_Crate_Report,
          CEID_Crate_Port_Use_Type_Change ,
          CEID_Crate_Port_Transfer_Mode_Change,//AGV or MGV / Use of Port Type
        //Mask Cassette Port Status & Transfer Mode Change (CEID 220 ~ 229)
          CEID_Mask_Cassette_Port_Load_Request,
          CEID_Mask_Cassette_Port_Pre_Load_Complete,
          CEID_Mask_Cassette_Port_Load_Complete,
          CEID_Mask_Cassette_Port_Unload_Request,
          CEID_Mask_Cassette_Port_Unload_Complete,
          CEID_Mask_Cassette_Port_Disable_Changed,
          CEID_Mask_Cassette_Port_Enable_Changed ,
          CEID_Mask_Cassette_Port_Type_Changed ,
          CEID_Mask_Cassette_Port_Use_Type_Changed ,
          CEID_Mask_Cassette_Port_Transfer_Mode_Changed,
        //Process Status (CEID 301 ~ 305)
          CEID_Process_Start,
          CEID_Process_Cancel,
          CEID_Process_Abort,
          CEID_Process_Pause,
          CEID_Process_Resume ,
        //Last Glass Process Start
          CEID_Last_Glass_Process_Start,
        //Glass Out/In
          CEID_Glass_Out_By_Indexer_Port,
          CEID_Glass_In_By_Indexer_Port,
          CEID_Glass_Out_By_Unit,
          CEID_Glass_In_By_Unit ,
          CEID_Glass_Out_By_Sub_Unit ,
          CEID_Glass_In_By_Sub_Unit,
        //Cassette Out/In Unit
          CEID_Glass_Out_By_Buffer,
          CEID_Glass_In_By_Buffer,
        //Glass Scrap / Unscrap
          CEID_Glass_Scrap,
        //Glass Out/In EQP
          CEID_Glass_Out_By_EQP,
          CEID_Glass_In_By_EQP,
        //Glass Turn
          CEID_Glass_Turn,
        //Panel Out/In
          CEID_Panel_Out_By_Indexer,
          CEID_Panel_In_By_Indexer,
          CEID_Panel_Out_By_Unit,
          CEID_Panel_In_By_Unit,
          CEID_Panel_Out_By_Sub_Unit,
          CEID_Panel_In_By_Sub_Unit,
        //Panel Scrap
          CEID_Panel_Scrap,
        //Panel Out/In EQP
          CEID_Panel_Out_By_EQP,
          CEID_Panel_In_By_EQP,
        //Cassette Out/In Unit
          CEID_Cassette_Out_By_Unit,
          CEID_Cassette_In_By_Unit,
        //Cassette Out/In Sub-Unit
          CEID_Cassette_Out_By_Sub_Unit,
          CEID_Cassette_In_By_Sub_Unit,
        //Sub Cassette Out/In By Indexer
          CEID_Sub_Cassette_Out_By_Indexer,
          CEID_Sub_Cassette_In_By_Indexer,
        //Sub Cassette Out/In By Unit
          CEID_Sub_Cassette_Out_By_Unit,
          CEID_Sub_Cassette_In_By_Unit,
        //Panel Out/In By Sub Cassette
          CEID_Panel_Out_By_Sub_Cassette,
          CEID_Panel_In_By_Sub_Cassette,
        //Sub Cassette Empty
          CEID_Sub_Cassette_Empty,
        //Process Program or Recipe Change
          CEID_Proc_Prog_or_Recipe_Change,
        //Lamination Complete
          CEID_Lamination_Complete,
        //Box Weighting Complete
          CEID_Box_Weighting_Complete,
        //Assemble Complete Event
          CEID_Assemble_Complete_Event,
        //Glass Cut Process
          CEID_Glass_Cut_Process,
        //Cutting Complete Event
          CEID_2_Cutting_Complete,
          CEID_1_Cutting_Complete,
        //Sorting Job Event
          CEID_Sorting_Job_Process_Start,
          CEID_Sorting_Job_Process_End,
          CEID_Sorting_Job_Cancel_Begin,
          CEID_Sorting_Job_Cancel_End,
          CEID_Sorting_Job_Abort_Begin ,
          CEID_Sorting_Job_Abort_End,
        //VCR Data Read
          CEID_VCR_Data_Read, //A0.01
        //Process Data
          CEID_Glass_Process_Data,
          CEID_Lot_Process_Data,
          CEID_Mask_Use_Count,
          CEID_Recycle_Mode,
        //Panel Process State (Lamination Line)
          CEID_Panel_Process_Start_Lamination,
          CEID_Panel_Process_End_Lamination,
        //Panel Scrap (Lamination Line)
          CEID_Panel_Scrap_Lamination,
        //Panel Out/In By EQP (Lamination Line)
          CEID_Panel_Out_By_EQP_Lamination,
          CEID_Panel_In_By_EQP_Lamination,
        //Pallet Load/Unload Complete, Boxing Complete
          CEID_Pallet_Load_Complete,
          CEID_Pallet_Boxing_Complete,
          CEID_Pallet_Unload_Complete
        };
        #endregion CEID Array
        #endregion CEID

        #region EAC
        public static readonly string EAC_Accept = "0";
        public static readonly string EAC_Denied_At_Least_one_constant_does_not_exist = "1";
        public static readonly string EAC_Denied_Busy = "2";
        public static readonly string EAC_Denied_At_least_one_constant_out_of_range = "3";
        public static readonly string EAC_Other_equipment_specific_error = "4";
        #endregion EAC

        #region ACKC5
        public static readonly string ACKC5_Accepted = "0";
        public static readonly string ACKC5_Not_Accepted = "1";
        public static readonly string ACKC5_Not_Exist_ALID = "2";
        #endregion ACKC5

        #region ACKC7
        public static readonly string ACKC7_Accepted = "0";
        public static readonly string ACKC7_Not_Accepted = "1";
        public static readonly string ACKC7_Unit_ID_is_not_exist = "2";
        public static readonly string ACKC7_PPTYPE_is_not_match = "3";
        public static readonly string ACKC7_PPID_is_not_match = "4";
        #endregion ACKC7

        #region ACKC10
        public static readonly string ACKC10_Accepted = "0";
        public static readonly string ACKC10_Not_Accepted = "1";
        #endregion ACKC10
        
        #region CSTTYPE
        public static readonly string CSTTYPE_NormalCST = "N";
        public static readonly string CSTTYPE_WireCST = "W";
        #endregion CSTTYPE
        
        #region CEED
        public static readonly string CEED_Enable = "0";
        public static readonly string CEED_Disable = "1";
        #endregion CEED

        #region ALED
        public static readonly string ALED_Enable = "0";
        public static readonly string ALED_Disable = "1";
        #endregion ALED

        #region PPCINFO
        /// <summary>
        /// A new PPID is created and registered
        /// </summary>
        public static readonly string PPCINFO_Created = "1";
        /// <summary>
        /// Some parameters of a PPID are modified
        /// </summary>
        public static readonly string PPCINFO_Modified = "2";
        /// <summary>
        /// Any PPID is deleted
        /// </summary>
        public static readonly string PPCINFO_Deleted = "3";
        /// <summary>
        /// Equipment sets up any PPID which different from current PPID
        /// </summary>
        public static readonly string PPCINFO_Changed = "4";
        #endregion PPCINFO

        #region ALST
        public static readonly string ALST_SET = "1";
        public static readonly string ALST_CLEAR = "2";
        #endregion ALST

        #region ALCD
        public static readonly string ALCD_Light_Alarm = "1";
        public static readonly string ALCD_Serious_Alarm = "2";
        #endregion ALCD

        #region SORTERJOBST
        public static readonly string SORTERJOBST_Running = "R";
        public static readonly string SORTERJOBST_Waiting = "W";
        public static readonly string SORTERJOBST_Cancelling = "C";
        public static readonly string SORTERJOBST_Aborting = "A";
        #endregion

        #region SCACK
        public static readonly string SCACK_Accepted = "0";
        public static readonly string SCACK_Busy = "1";
        public static readonly string SCACK_CSTID_is_Invalid = "2";
        public static readonly string SCACK_Already_Received = "3";
        public static readonly string SCACK_SLOT_Information_Mismatch = "4";
        public static readonly string SCACK_NetYet_Prepared_For_This_Sorter_Job = "5";
        #endregion

        #region EMPTYCSTPMS
        public static readonly string EMPTYCSTPMS_G = "G";
        public static readonly string EMPTYCSTPMS_C = "C";
        #endregion

        public static com.mirle.ibg3k0.stc.Common.SECS.SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT checkDataValue(
            string name, string value)
        {
            com.mirle.ibg3k0.stc.Common.SECS.SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT result =
                SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT.Recognize;

            if (name.Trim().Equals("CRST"))
            {
                //SECSConst.CRST
                if (!CmdConst.CRST.Contains(value.Trim()))
                {
                    return SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT.Illegal_Data_Value_Format;
                }
            }

            return result;
        }

        public static readonly int[] StreamIDArray = { 1, 2, 5, 6, 7, 9, 10 };
        public static readonly int[] FunctionIDArray = 
        { 
            0, 1, 2, 3, 4, 5, 6, 7, 9,
            11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            23, 24, 25, 26, 29, 
            30, 31, 32, 37, 38, 
            41, 42, 
            53, 54 ,
            101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 110, 112, 117, 118,
            203, 204, 243, 244,248,249,250
        };

        public static com.mirle.ibg3k0.stc.Common.SECS.SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT checkSFType(int S, int F)
        {
            com.mirle.ibg3k0.stc.Common.SECS.SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT result =
                SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT.Recognize;
            string streamFunction = string.Format("S{0}F{1}", S, F);

            if (!StreamIDArray.Contains(S))
            {
                result = SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT.Unrecognized_Stream_Type;
            }
            else if (!FunctionIDArray.Contains(F))
            {
                result = SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT.Unrecognized_Function_Type;
            }
            else
            {
                Type type = Type.GetType("com.mirle.ibg3k0.sc.Data.SECS." + streamFunction);
                Type typeBase = Type.GetType("com.mirle.ibg3k0.stc.Data.SecsData." + streamFunction);
                if (type == null && typeBase == null && F != 0)
                {
                    result = SECSAgent.SECS_STREAM_FUNCTION_CHECK_RESULT.Unrecognized_Stream_Type;
                }
            }
            return result;
        }
    }
}
