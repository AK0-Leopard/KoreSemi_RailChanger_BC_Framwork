//*********************************************************************************
//      SCAppConstants.cs
//*********************************************************************************
// File Name: SCAppConstants.cs
// Description: SCAppConstants
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
using com.mirle.ibg3k0.sc.Data.SECS;
using System.Diagnostics;
using System.Reflection;
using com.mirle.ibg3k0.sc.Common;

namespace com.mirle.ibg3k0.sc.App
{
    public class SCAppConstants
    {
        public static readonly string Normal_Mode = "1";
        public static readonly string Bypass_Mode = "2";
        public static readonly string[] RUN_MODE_OPTION = { Normal_Mode, Bypass_Mode };
        public static readonly string ECID_Format = "{0:0000}";
        public static readonly string ECID_AUTO_JOB_SWITCH = "0001";
        public static readonly string ECID_GEM_INITIAL_CONTROL_STATE = "0003";
        public static readonly string ECID_DEVICE_ID = "0004";
        public static readonly string ECID_HEARTBEAT = "0005";
        public static readonly string ECID_T3 = "0006";
        public static readonly string ECID_T5 = "0007";
        public static readonly string ECID_T6 = "0008";
        public static readonly string ECID_T7 = "0009";
        public static readonly string ECID_T8 = "0010";
        public static readonly string ECID_CONVERSATION_TIMEOUT = "0011";
        public static readonly string ECID_LOGOUT_TIME = "0012";
        public static readonly string ECID_TACK_TIME_OVER = "0013";

        public static readonly string ECID_DCS_SERIVE_ORDER = "0101";
        public static readonly string ECID_DCS_ADVANCE_MOVE = "0102";
        public static readonly string ECID_DCS_ADVANCE_GET = "0103";
        public static readonly string ECID_DCS_ARM_PRIORITY = "0104";
        public static readonly string ECID_DCS_MODE = "0105";
        public static readonly string ECID_DCS_SINGLEARM = "0106";
        public static readonly string ECID_N2_Pre_Move_Stage = "0107";
        public static readonly string ECID_N3_Pre_Move_Stage = "0108";
        public static readonly string[] SYSTEM_DEFAULT_ECID =
        {
            ECID_AUTO_JOB_SWITCH,
            ECID_GEM_INITIAL_CONTROL_STATE,
            ECID_DEVICE_ID,
            ECID_HEARTBEAT,
            ECID_T3,
            ECID_T5,
            ECID_T6,
            ECID_T7,
            ECID_T8,
            ECID_TACK_TIME_OVER,
            ECID_CONVERSATION_TIMEOUT,
            ECID_DCS_SERIVE_ORDER,
            ECID_DCS_ADVANCE_MOVE,
            ECID_DCS_ADVANCE_GET,
            ECID_DCS_ARM_PRIORITY,
            ECID_DCS_MODE,
            ECID_DCS_SINGLEARM,
            ECID_N2_Pre_Move_Stage,
            ECID_N3_Pre_Move_Stage
        };

        //System EqptParameters
        public const string EQPT_PARAMETERS_NEED_MOVETO = "NEED_MOVETO";
        public const string EQPT_PARAMETERS_ABORTED_FINISH_JOB = "ABORTED_FINISH_JOB";

        public static readonly int MAX_DATA_ID = 9999;
        public static readonly int DATA_ID_LENGTH = 4;

        public static readonly string CEID_ALL_CEID = CmdConst.CEID_ALL_CEID;
        public static readonly string ALARM_ALL_ALARMID = "0000000000";

        public static readonly string YES_FLAG = "Y";
        public static readonly string NO_FLAG = "N";

        public static readonly string O_FLAG = "O";
        public static readonly string X_FLAG = "X";

        public static readonly string TimestampFormat_19 = "yyyyMMddHHmmssfffff";
        public static readonly string TimestampFormat_17 = "yyyyMMddHHmmssfff";
        public static readonly string TimestampFormat_16 = "yyyyMMddHHmmssff";
        public static readonly string TimestampFormat_14 = "yyyyMMddHHmmss";
        public static readonly string DateTimeFormat_22 = "yyyy-MM-dd HH:mm:ss.ff";
        public static readonly string DateTimeFormat_23 = "yyyy-MM-dd HH:mm:ss.fff";
        public static readonly string DateTimeFormat_19 = "yyyy-MM-dd HH:mm:ss";
        public static readonly string DateTimeFormat_19_Slash = "yyyy//MM//dd HH:mm:ss";
        public static readonly string DateTimeFormat_Date = "yyyyMMdd";
        public static readonly string DateTimeFormat_Time = "HHmmss";

        //Sequence Name
        public static readonly string SEQUENCE_NAME_CST_SEQUENCE = "CST_SEQ";
        public static readonly string SEQUENCE_NAME_PNL_JOB_SEQUENCE = "PNL_JOB_SEQ";
        public static readonly string SEQUENCE_NAME_RobotCMD_SEQUENCE = "RobotCMD_SEQ";
        public static readonly string SEQUENCE_NAME_SHEET_SEQUENCE = "Sheet_SEQ";

        public static readonly int CST_SEQUENCE_NUMBER_BIT_LENGTH = 8;//00000000~11111111 (0 ~ 255)
        public static readonly int CST_SEQUENCE_NUMBER_MAX = 255;
        public static readonly int CST_SEQUENCE_NUMBER_MIN = 0;
        public static readonly int PNL_JOB_SEQUENCE_NUMBER_BIT_LENGTH = 15;//000000000000000~111111111111111 (0 ~ 32767)
        public static readonly int PNL_JOB_SEQUENCE_NUMBER_MAX = 32767;
        public static readonly int PNL_JOB_SEQUENCE_NUMBER_MIN = 0;

        public static readonly int ROBOTCMD_SEQUENCE_NUMBER_LENGTH = 5;     //00000 ~ 65535
        public static readonly int ROBOTCMD_SEQUENCE_NUMBER_MAX = 500;
        public static readonly int ROBOTCMD_SEQUENCE_NUMBER_MIN = 1;

        public static readonly int SHEET_SEQUENCE_NUMBER_BIT_LENGTH = 7;     //000 ~ 127
        public static readonly int SHEET_SEQUENCE_NUMBER_MAX = 127;
        public static readonly int SHEET_SEQUENCE_NUMBER_MIN = 0;

        public static readonly int BCR_READ_HISTORY_MAX_CNT = 500;
        public static readonly int BCR_READ_HISTORY_DEL_CNT = 20;

        //The SEQ sent to mcs
        public static readonly string SEQUENCE_NAME_HOST_SEQUENCE = "HOST_SEQ";
        public static readonly int JSON_HOST_SEQUENCE_NUMBER_MAX = 99999;
        public static readonly int JSON_HOST_SEQUENCE_NUMBER_MIN = 1;

        //Robot Command Retry Count
        public static readonly int ROBOTCMD_RETRY_COUNT = 5;

        //Slot Number
        public static readonly int SLOT_NO_LENGTH = 3;          //EX: 002、005、025...etc

        //EQ Symbol
        public static readonly string EQPT_SYMBOL_INDEXER = "IND";
        public static readonly string EQPT_SYMBOL_N2 = "N2";
        public static readonly string EQPT_SYMBOL_N3 = "N3";

        //EQ Station No
        public static readonly string EQPT_StationNo_ALL = "0";
        public static readonly string EQPT_StationNo_INDEXER = "2";
        public static readonly string EQPT_StationNo_N2 = "3";
        public static readonly string EQPT_StationNo_N3 = "4";

        public static readonly string DEFAULT_SITE_NAME = "G";


        /////////////////////////////////Config Use Begin////////////////////////////////////////
        /******************Return Code***********************/
        public class ReturnCode
        {
            public static readonly int OK = 1;
            public static readonly int NG = 2;
        }

        public class ReturnCodeStr
        {
            public static readonly string OK = "OK";
            public static readonly string NG = "NG";
        }

        public class ReturnCodeNum
        {
            public static readonly string OK = "00000";
            public static readonly string NG = "00001";
        }
        /****************************************************/
        /******************* Unit Cate *********************/
        public static readonly string UNIT_CATE_VCR = "V";
        public static readonly string UNIT_CATE_PORT = "O";
        public static readonly string UNIT_CATE_STAGE = "S";
        public static readonly string UNIT_CATE_BUFFER = "B";
        public static readonly string UNIT_CATE_ROBOT = "R";
        public static readonly string UNIT_CATE_CONVEYER = "C";
        public static readonly string UNIT_CATE_LIFT = "L";
        public static readonly string UNIT_CATE_PROCESS = "P";
        public static readonly List<string> UNIT_CATE_LIST = new List<string>
        {
            UNIT_CATE_VCR,
            UNIT_CATE_PORT,
            UNIT_CATE_STAGE,
            UNIT_CATE_BUFFER,
            UNIT_CATE_ROBOT,
            UNIT_CATE_CONVEYER,
            UNIT_CATE_LIFT,
            UNIT_CATE_PROCESS
        };
        /***************************************************/

        /******************* EQPT Type *********************/
        public static readonly string EQPT_TYPE_TRANSFER = "T";
        public static readonly string EQPT_TYPE_PROCESS = "P";
        public static readonly string EQPT_TYPE_MEASUREMENT = "M";
        public static readonly List<string> EQPT_TYPE_LIST = new List<string>
        {
            EQPT_TYPE_TRANSFER,
            EQPT_TYPE_PROCESS,
            EQPT_TYPE_MEASUREMENT
        };
        /***************************************************/

        /******************* Port Type *********************/
        public static readonly string PORT_TYPE_LOAD = "L";
        public static readonly string PORT_TYPE_LOAD_REWORK = "LRE";
        public static readonly string PORT_TYPE_UNLOAD = "U";
        public static readonly string PORT_TYPE_UNLOAD_REWORK = "URE";
        public static readonly string PORT_TYPE_COMMON_LOAD_UNLOAD = "C";
        public static readonly string PORT_TYPE_MGV = "M";
        public static readonly string PORT_TYPE_IO = "T";

        public static readonly List<string> PORT_TYPE_LIST = new List<string>
        {
            PORT_TYPE_LOAD,
            PORT_TYPE_LOAD_REWORK,
            PORT_TYPE_UNLOAD,
            PORT_TYPE_UNLOAD_REWORK,
            PORT_TYPE_COMMON_LOAD_UNLOAD,
            PORT_TYPE_MGV,
            PORT_TYPE_IO
        };
        /***************************************************/

        /******************* Port Command *********************/
        public static readonly string PORT_CMD_START = "1";
        public static readonly string PORT_CMD_CANCEL = "2";
        public static readonly string PORT_CMD_ABORT = "3";
        public static readonly string PORT_CMD_PROC_END = "4";
        public static readonly string PORT_CMD_PAUSE_PREABORT = "5";
        public static readonly string PORT_CMD_PAUSE = "6";
        public static readonly string PORT_CMD_RESUME = "7";
        public static readonly string PORT_CMD_OPERATOR_CALL = "8";
        public static readonly string PORT_CMD_RELOAD = "9";
        /***************************************************/

        /***************** Relation Type *******************/
        public static readonly string REL_TYPE_NODE = "N";
        /***************************************************/

        /**************** EQPT Object Cate *****************/
        public static readonly string EQPT_OBJECT_CATE_LINE = "Line";
        public static readonly string EQPT_OBJECT_CATE_ZONE = "Zone";
        public static readonly string EQPT_OBJECT_CATE_NODE = "Node";
        public static readonly string EQPT_OBJECT_CATE_EQPT = "Equipment";
        public static readonly string EQPT_OBJECT_CATE_UNIT = "Unit";
        public static readonly string EQPT_OBJECT_CATE_PORT = "Port";
        public static readonly string EQPT_OBJECT_CATE_BUFFER = "BufferPort";
        /***************************************************/
        /////////////////////////////////Config Use End//////////////////////////////////////////

        /******************* BC Status *********************/
        public class BCSystemStatus
        {
            public static readonly string Default = "0";
            public static readonly string NormalClosed = "1";
        }

        public enum BCSystemInitialRtnCode
        {
            Normal = 0,
            Error = 1,
            NonNormalShutdown = 2
        }
        /***************************************************/
        public class CapacityPercentage
        {
            public static readonly int None = 0;
            public static readonly int Quarter = 1;
            public static readonly int Half = 2;
            public static readonly int ThreeQuarter = 3;
            public static readonly int Whole = 4;
        }
        /*****************Alarm Source Type*****************/
        public class AlarmSourceType
        {
            public static readonly string Line = "1";
            public static readonly string Zone = "2";
            public static readonly string Node = "3";
            public static readonly string EQPT = "4";
            public static readonly string Unit = "5";
            public static readonly string Port = "6";
            public static readonly string Buffer = "7";
        }
        /***************************************************/

        /********************Alarm State********************/
        public class EQAlarmStatus
        {
            public static readonly string On = "1";
            public static readonly string Off = "2";
        }
        /********************Alarm State********************/
        public class AlarmStatus
        {
            public static readonly int Set = 1;
            public static readonly int Clear = 2;
        }
        /***************************************************/

        /********************Alarm State********************/
        public class sAlarmStatus
        {
            public static readonly string Set = "S";
            public static readonly string Clear = "C";
        }
        /***************************************************/

        /********************Alarm Level********************/
        public class AlarmLevel
        {
            public static readonly int Warning = 1;
            public static readonly int Alarm = 2;
        }

        public class sAlarmLevel
        {
            /// <summary>
            /// The warning
            /// </summary>
            public static readonly string sWarning = "Warning";
            /// <summary>
            /// The alarm
            /// </summary>
            public static readonly string sAlarm = "Alarm";
        }

        /***************************************************/

        /********************Alarm Warning Status***********/
        public class AlarmWarningStat
        {
            public static readonly int No = 0;
            public static readonly int OnlyAlarm = 1;
            public static readonly int OnlyWarn = 2;
            public static readonly int Both = 3;
        }
        /***************************************************/

        /********************Link Status********************/
        public class LinkStatus
        {
            public static readonly int Link_Fail = 0;
            public static readonly int Link_OK = 1;
        }
        public class ConsoleMsgLvl
        {
            public static readonly string Info = "0";
            public static readonly string Warning = "1";
            public static readonly string Error = "1";
        }
        /***************************************************/
        /*************************Line**********************/
        public static readonly string LineNormalRunMode = "1";
        public static readonly string LineSemiAutoMode = "2";

        public class RoutingMode
        {
            public static readonly string NoneMode = "0";
            public static readonly string MixMode = "5";  //不管目前線內跑的Glass為何種Mode，只要有Glass符合機台的就會抽出去給該機台
            public static readonly string SingleMode_N2 = "1";//只跑N2
            public static readonly string SingleMode_N3 = "2";//只跑N3
            public static readonly string NormalMode_N2toN3 = "3";   //跑N2+N3
            public static readonly string NormalMode_N3toN2 = "4";   //跑N3+N2
            public static string convert2EQID_RoutingMode(string eq_no)
            {
                if (BCFUtility.isMatche(eq_no, "1"))
                {
                    return "N2";
                }
                else if (BCFUtility.isMatche(eq_no, "2"))
                {
                    return "N3";
                }
                return "None";
            }
            public static readonly string[] Set = { MixMode, SingleMode_N2, SingleMode_N3, NormalMode_N2toN3, NormalMode_N3toN2 };

        }

        //BC定義的Status 1:Idle      2:Run      3:Down      4:Maintenance      5:Other
        public class LineStatus
        {
            public static readonly int IDLE = 1;
            public static readonly int RUN = 2;
            public static readonly int DOWN = 3;
            public static readonly int MAINTENANCE = 4;
            public static readonly int OTHER = 5;

            public static string convert2MES(int lineStatus)
            {
                string rtnCode = string.Empty;
                if (lineStatus == IDLE)
                {
                    rtnCode = CmdConst.EQST_IDLE;
                }
                else if (lineStatus == RUN)
                {
                    rtnCode = CmdConst.EQST_RUN;
                }
                else if (lineStatus == DOWN)
                {
                    rtnCode = CmdConst.EQST_DOWN;
                }
                else if (lineStatus == MAINTENANCE)
                {
                    rtnCode = CmdConst.EQST_MAINTENANCE;
                }
                else if (lineStatus == OTHER)
                {
                    rtnCode = CmdConst.EQST_OTHER;
                }
                else
                {
                    rtnCode = "0";
                }
                return rtnCode;
            }

            public static string convert2DisPlay(int lineStatus)
            {
                string rtnCode = string.Empty;
                if (lineStatus == IDLE)
                {
                    rtnCode = CmdConst.EQST_IDLE;
                }
                else if (lineStatus == RUN)
                {
                    rtnCode = CmdConst.EQST_RUN;
                }
                else if (lineStatus == DOWN)
                {
                    rtnCode = CmdConst.EQST_DOWN;
                }
                else if (lineStatus == MAINTENANCE)
                {
                    rtnCode = CmdConst.EQST_MAINTENANCE;
                }
                else if (lineStatus == OTHER)
                {
                    rtnCode = CmdConst.EQST_OTHER;
                }
                else
                {
                    rtnCode = "0";
                }
                return rtnCode;
            }


            public static string convert2MQ(int lineStatus)
            {
                string rtnCode = string.Empty;
                if (lineStatus == IDLE)
                {
                    rtnCode = MQLineStatus.IDLE;
                }
                else if (lineStatus == RUN)
                {
                    rtnCode = MQLineStatus.RUN;
                }
                else if (lineStatus == DOWN)
                {
                    rtnCode = MQLineStatus.DOWN;
                }
                else if (lineStatus == MAINTENANCE)
                {
                    rtnCode = MQLineStatus.MAINTENANCE;
                }
                else if (lineStatus == OTHER)
                {
                    rtnCode = MQLineStatus.OTHER;
                }
                else
                {
                    rtnCode = "0";
                }
                return rtnCode;
            }
            public class MQLineStatus
            {
                public static readonly string IDLE = "IDLE";
                public static readonly string RUN = "RUN";
                public static readonly string DOWN = "DOWN";
                public static readonly string MAINTENANCE = "MAINTENANCE";
                public static readonly string OTHER = "OTHER";
            }
            public static int convert2BC(string lineStatus)
            {
                int rtnCode = 0;
                if (lineStatus == CmdConst.EQST_IDLE)
                {
                    rtnCode = IDLE;
                }
                else if (lineStatus == CmdConst.EQST_RUN)
                {
                    rtnCode = RUN;
                }
                else if (lineStatus == CmdConst.EQST_DOWN)
                {
                    rtnCode = DOWN;
                }
                else if (lineStatus == CmdConst.EQST_MAINTENANCE)
                {
                    rtnCode = MAINTENANCE;
                }
                else if (lineStatus == CmdConst.EQST_OTHER)
                {
                    rtnCode = OTHER;
                }
                else
                {
                    rtnCode = 0;
                }
                return rtnCode;
            }

        }

        public class LineOperationMode
        {
            public static readonly int Normal = 0;
            public static readonly int NG = 1;
            public static readonly int[] set = { Normal, NG };

        }

        public class LineRunMode
        {
            public static readonly string Normal_Mode = "1";
            public static readonly string Bypass_Mode = "2";
            public static readonly string Normal_Mode_Desc = "Normal Mode";
            public static readonly string Bypass_Mode_Desc = "Bypass Mode";

            public static string convert2Desc(string mode)
            {
                if (BCFUtility.isMatche(mode, Normal_Mode))
                {
                    return Normal_Mode_Desc;
                }
                else if (BCFUtility.isMatche(mode, Bypass_Mode))
                {
                    return Bypass_Mode_Desc;
                }
                return "Not Defined";
            }

        }

        public class LineHostMode
        {
            public static readonly int OffLine = 0;
            public static readonly int OnLineRemote = 1;
            public static readonly int OnLineLocal = 2;



            public static string convert2MES(int hostMode)
            {
                if (hostMode == OffLine)
                {
                    return CmdConst.BOE_CRST_Off_Line;
                }
                else if (hostMode == OnLineRemote)
                {
                    return CmdConst.BOE_CRST_On_Line_Remote;
                }
                else if (hostMode == OnLineLocal)
                {
                    return CmdConst.BOE_CRST_On_Line_Local;
                }
                return string.Empty;
            }

            public static int convert2BC(string hostMode)
            {
                if (BCFUtility.isMatche(hostMode, CmdConst.CRST_Off_Line))
                {
                    return OffLine;
                }
                else if (BCFUtility.isMatche(hostMode, CmdConst.CRST_On_Line_Remote))
                {
                    return OnLineRemote;
                }
                else if (BCFUtility.isMatche(hostMode, CmdConst.CRST_On_Line_Local))
                {
                    return OnLineLocal;
                }
                return OffLine;
            }
            public static readonly int[] Set = { OffLine, OnLineRemote, OnLineLocal };

        }

        public class LineHostMode_MQ
        {
            public static readonly int CONT = 0;
            public static readonly int MANU = 1;
            public static string convert2MES(int eqptMode)
            {
                if (eqptMode == CONT)
                {
                    return "CONT";
                }
                else if (eqptMode == MANU)
                {
                    return "MANU";
                }
                return string.Empty;
            }
            public static readonly int[] Set = { CONT, MANU };
        }

        public class CommandMaster_MCS
        {
            public static readonly int MPLC = 1;
            public static readonly int MES = 2;
        }

        public class MQServer
        {
            public static readonly string LCS = "LCS";
            public static readonly string MES = "MES";
        }

        public class LineInLineMode
        {
            public static readonly int OffLine = 0;
            public static readonly int InLine = 1;
        }
        /****************************************************/
        /*************************Zone***********************/
        public class ZoneStatus
        {
            public static readonly int IDLE = 1;
            public static readonly int RUN = 2;
            public static readonly int DOWN = 3;
        }
        /****************************************************/
        /*************************Node***********************/
        public class NodeStatus
        {
            public static readonly int IDLE = 1;
            public static readonly int RUN = 2;
            public static readonly int DOWN = 3;
        }
        /****************************************************/
        /*************************EQPT***********************/
        public class EQPTRunMode
        {
            public static readonly int NORMAL = 1;         //一搬運行狀態
            public static readonly int SCAN = 2;           //對帳狀態
            public static readonly int CLEANLINE = 3;      //清線狀態
            public static readonly int FINAL_TRAY = 4;     //尾盤模式
        }

        public class EQPTPassMode
        {
            public static readonly int Normal = 0;
            public static readonly int Pass = 1;
        }

        public class EQPTInLineMode
        {
            public static readonly int OffLine = 0;
            public static readonly int InLine = 1;
        }

        public class sEQPTInLineMode
        {
            public static readonly string OffLine = "Offline";
            public static readonly string InLine = "Inline";
        }

        //EQPT Status Change
        public class EQPTStatus
        {
            public static readonly int NONE = 0;
            public static readonly int IDLE = 1;
            public static readonly int RUN = 2;
            public static readonly int DOWN = 3;
            public static readonly int MAINTENANCE = 4;
            public static readonly int OTHER = 5;

            public static string convert2MES(int eqStatus)
            {
                string rtnCode = string.Empty;
                if (eqStatus == IDLE)
                {
                    rtnCode = CmdConst.EQST_IDLE;
                }
                else if (eqStatus == RUN)
                {
                    rtnCode = CmdConst.EQST_RUN;
                }
                else if (eqStatus == DOWN)
                {
                    rtnCode = CmdConst.EQST_DOWN;
                }
                else if (eqStatus == MAINTENANCE)
                {
                    rtnCode = CmdConst.EQST_MAINTENANCE;
                }
                else
                {
                    rtnCode = CmdConst.EQST_OTHER;
                }
                return rtnCode;
            }

            public static string convert2DisPlay(int eqStatus)
            {
                string rtnCode = string.Empty;
                if (eqStatus == IDLE)
                {
                    rtnCode = CmdConst.EQST_IDLE;
                }
                else if (eqStatus == RUN)
                {
                    rtnCode = CmdConst.EQST_RUN;
                }
                else if (eqStatus == DOWN)
                {
                    rtnCode = CmdConst.EQST_DOWN;
                }
                else if (eqStatus == MAINTENANCE)
                {
                    rtnCode = CmdConst.EQST_MAINTENANCE;
                }
                else
                {
                    rtnCode = CmdConst.EQST_OTHER;
                }
                return rtnCode;
            }

            public static int convert2BC(string eqStatus)
            {
                int rtnCode = 0;
                if (eqStatus == CmdConst.EQST_IDLE)
                {
                    rtnCode = EQPTStatus.IDLE;
                }
                else if (eqStatus == CmdConst.EQST_RUN)
                {
                    rtnCode = EQPTStatus.RUN;
                }
                else if (eqStatus == CmdConst.EQST_DOWN)
                {
                    rtnCode = EQPTStatus.DOWN;
                }
                else if (eqStatus == CmdConst.EQST_MAINTENANCE)
                {
                    rtnCode = EQPTStatus.MAINTENANCE;
                }
                else if (eqStatus == CmdConst.EQST_OTHER)
                {
                    rtnCode = EQPTStatus.OTHER;
                }
                return rtnCode;
            }
        }

        public class EQPTSTATUS
        {
            public static readonly string IDLE = "IDLE";
            public static readonly string RUN = "RUN";
            public static readonly string DOWN = "DOWN";
            public static readonly string MAINT = "MAINT";
        }

        public class EQPTProcessStatus
        {
            public static readonly int Normal = 0;
            public static readonly int Step = 1;
            public static readonly int Pause = 2;
            public static readonly int Stop = 3;
        }
        public class EQPTBatteryStatus
        {
            public static readonly int Normal = 0;
            public static readonly int Low_Battery = 1;
        }
        public class EQPTCIMMode
        {
            public static readonly int CIM_OFF = 0;
            public static readonly int CIM_ON = 1;
        }
        public class MPLC_CIMMode
        {
            public static readonly int CIM_OFF = 0;
            public static readonly int CIM_ON = 1;
        }
        public class MES_CIMMode
        {
            public static readonly int CIM_OFF = 0;
            public static readonly int CIM_ON = 1;
        }
        public class sEQPTCIMMode
        {
            public static readonly string CIM_OFF = "CIM OFF";
            public static readonly string CIM_ON = "CIM ON";
        }
        /****************************************************/
        /*************************Unit***********************/
        public class UnitStatus
        {
            public static readonly int IDLE = 1;
            public static readonly int RUN = 2;
            public static readonly int DOWN = 3;
            public static readonly int MAINTENANCE = 4;

            public static int convert2BC(string unitStatus)
            {
                int rtnCode = 0;
                if (BCFUtility.isMatche(unitStatus, CmdConst.EQST_IDLE))
                {
                    rtnCode = EQPTStatus.IDLE;
                }
                else if (BCFUtility.isMatche(unitStatus, CmdConst.EQST_RUN))
                {
                    rtnCode = EQPTStatus.RUN;
                }
                else if (BCFUtility.isMatche(unitStatus, CmdConst.EQST_DOWN))
                {
                    rtnCode = EQPTStatus.DOWN;
                }
                else if (BCFUtility.isMatche(unitStatus, CmdConst.EQST_MAINTENANCE))
                {
                    rtnCode = EQPTStatus.MAINTENANCE;
                }
                return rtnCode;
            }
        }
        /****************************************************/
        /*************************Port***********************/
        public class PortStatus
        {
            public static readonly int LDRQ = 0;
            public static readonly int Pre_LDCM = 1;
            public static readonly int LDCM = 2;
            public static readonly int UDRQ = 3;
            public static readonly int UDCM = 4;
            public static readonly int Disable = 5;
            public static readonly int No_Request = 6;

            public static string convert2MES(int portStatus)
            {
                switch (portStatus)
                {
                    case 0:
                        return "LR";
                    case 1:
                        return "PL";
                    case 2:
                        return "LC";
                    case 3:
                        return "UR";
                    case 4:
                        return "UC";
                    case 5:
                        return "DN";
                    default:
                        return Convert.ToString(portStatus);
                }
            }
            public static int convert2BC(string portStatus)
            {
                try
                {
                    return Convert.ToInt32(portStatus);
                }
                catch (Exception) { }
                return Disable;
            }
            public static string convert2MQ(int portStatus)
            {
                switch (portStatus)
                {
                    case 0:
                        return "LDRQ";
                    case 1:
                        return "PDCM";
                    case 2:
                        return "LDCM";
                    case 3:
                        return "UDRQ";
                    case 4:
                        return "UDCM";
                    case 5:
                        return "DISABLE";
                    default:
                        return Convert.ToString(portStatus);
                }
            }
        }

        public enum LogType
        {
            PLC_ForEQ,
            SECS_ForHost,
            MQ_ForHost
        }


        public class sPortStatus
        {
            public static readonly string LDRQ = "LDRQ";
            public static readonly string Pre_LDCM = "PDCM";
            public static readonly string LDCM = "LDCM";
            public static readonly string UDRQ = "UDRQ";
            public static readonly string UDCM = "UDCM";
            public static readonly string Disable = "Disable";
        }

        public class PortCommandStatus
        {
            public static readonly int Default = 0;

            public static readonly int CST_Data_Download_Step = 10;
            public static readonly int CST_Data_Download_OK = 11;
            public static readonly int CST_Data_Download_NG = 12;

            public static readonly int CST_Data_Check_Step = 20;
            public static readonly int CST_Data_Check_OK = 21;
            public static readonly int CST_Data_Check_NG = 22;

            public static readonly int CST_Data_Checking = 23;
            public static readonly int CST_Data_Creat_ING = 24;

            public static readonly int CST_Data_Download_To_Robot_OK = 25;
            public static readonly int CST_Data_Download_To_Robot_NG = 26;

            public static readonly int CST_Data_Robot_Map_OK = 27;
            public static readonly int CST_Data_Robot_Map_NG = 28;

            public static readonly int Prepare_Start_Step = 30;
            public static readonly int Ready_To_Start_By_Indexer = 31;
            public static readonly int Receive_Start_Command_Timeout = 32;
            public static readonly int Receive_Start_Command_By_MES_Data_Error = 33;
            public static readonly int Receive_Start_Command_By_MES_OK = 34;

            public static readonly int Cancel_Step = 40;
            public static readonly int Process_Cancel_By_MES = 41;
            public static readonly int Process_Cancel_By_OP = 42;
            public static readonly int Process_Cancel_By_MPC = 43;

            public static readonly int Process_Start_By_OP = 51;
            public static readonly int Process_Start_Wait_OK = 52;

            public static readonly int Lot_Process_Start = 55;

            public static readonly int Process_Abort_By_OP = 61;
        }

        public class PortRealType
        {
            public static readonly string Not_Used = "NotUsed";                      //0 
            public static readonly string Load_Port = "LD";                          //1  
            public static readonly string Unload_Port = "ULD";                       //2 
            public static readonly string Both_Port = "LD/ULD";                      //3 
            public static readonly string Buffer = "Buffer";                         //4
            public static readonly string Partial_UnloadPort = "ULDPartial";         //5 

            public static readonly string[] PortRealTypeRange_Normal =
            {
                Both_Port/*, Load_Port, Unload_Port, Sort_Port*/ //在Array段只有使用Both Port
            };

            public static readonly string[] PortRealTypeRange_NG =
            {
                Both_Port, Unload_Port/*, Sort_Port*/ //在Array段只有使用Both Port
            };


            public static string conver2PortRealType(int port_real_type)
            {
                if (port_real_type == PortRealType_PLC.LD)
                {
                    return Load_Port;
                }
                else if (port_real_type == PortRealType_PLC.ULD)
                {
                    return Unload_Port;
                }
                else if (port_real_type == PortRealType_PLC.LD_ULD)
                {
                    return Both_Port;
                }
                else if (port_real_type == PortRealType_PLC.Buffer)
                {
                    return Buffer;
                }
                else if (port_real_type == PortRealType_PLC.ULD_Partial)
                {
                    return Partial_UnloadPort;
                }
                return string.Empty;
            }
        }

        public class PortRealType_PLC
        {
            public static readonly int Not_Used = 0;
            public static readonly int LD = 1;
            public static readonly int ULD = 2;
            public static readonly int LD_ULD = 3;
            public static readonly int Buffer = 4;
            public static readonly int ULD_Partial = 5;
            public static int conver2PortRealType_PLC(string port_real_type)
            {
                if (port_real_type == PortRealType.Not_Used)
                {
                    return Not_Used;
                }
                else if (port_real_type == PortRealType.Load_Port)
                {
                    return LD;
                }
                else if (port_real_type == PortRealType.Unload_Port)
                {
                    return ULD;
                }
                else if (port_real_type == PortRealType.Both_Port)
                {
                    return LD_ULD;
                }
                else if (port_real_type == PortRealType.Buffer)
                {
                    return Buffer;
                }
                else if (port_real_type == PortRealType.Partial_UnloadPort)
                {
                    return ULD_Partial;
                }
                return 0;
            }
        }

        public class PortUseType
        {
            public static readonly string Normal = "OO";
            public static readonly string Dummy = "DM";
            public static readonly string Good = "GG";
            public static readonly string No_Good = "NG";
            public static readonly string Re_Work = "RW";
            public static readonly string Re_Pair = "RP";
            public static readonly string Scrap = "SC";
            public static readonly string Mask = "MS";
            public static readonly string Encap = "EN";
            public static readonly string Crate_Port_Type_Loader = "CR";
            public static readonly string Cassette_Cleaner_Type_Loader_And_Unloader = "CL";

            public static readonly string[] PortUseTypeRange =
            {
                Normal, Good, No_Good
                /*,ormal Dummy, Good, No_Good, Re_Work, Re_Pair, Scrap, Mask, Encap, Crate_Port_Type_Loader, 
                Cassette_Cleaner_Type_Loader_And_Unloader*/
            };

            public static readonly string[] NgPortUseTypeRange =
            {
                Normal,No_Good/*, Re_Pair, Scrap, Mask, Encap, Crate_Port_Type_Loader, 
                Cassette_Cleaner_Type_Loader_And_Unloader*/
            };
        }

        public class PortEnable
        {
            public static readonly int Disable = 0;
            public static readonly int Enable = 1;

            public static readonly int[] PortEnableRange =
            {
                Disable, Enable
            };
        }

        public class sPortEnable
        {
            public static readonly string sDisable = "Disabled";
            public static readonly string sEnable = "Enabled";

            public static readonly string[] sPortEnableRange =
            {
                sDisable, sEnable
            };
        }

        public class TransferMode
        {
            public static readonly int Auto = 1;
            public static readonly int Manual = 2;

            public static string convert2MES(int trsMode)
            {
                if (trsMode == Auto)
                {
                    return CmdConst.TRSMODE_AUTO;
                }
                else if (trsMode == Manual)
                {
                    return CmdConst.TRSMODE_Manual;
                }
                return string.Empty;
            }
            public static int convert2BC(string trsMode)
            {
                if (BCFUtility.isMatche(trsMode, CmdConst.TRSMODE_AUTO))
                {
                    return TransferMode.Auto;
                }
                else if (BCFUtility.isMatche(trsMode, CmdConst.TRSMODE_Manual))
                {
                    return TransferMode.Manual;
                }
                return TransferMode.Auto;
            }
        }

        public class sTransferMode
        {
            public static readonly string AGV = "AGV";
            public static readonly string MGV = "MGV";

            public static readonly string[] sPortAGVMGVRange =
            {
                AGV, MGV
            };
        }

        /****************************************************/
        /***********************Buffer***********************/
        public class BufferStatus
        {
            public static readonly int IDLE = 1;
            public static readonly int RUN = 2;
            public static readonly int DOWN = 3;
        }

        public class BufferCommand
        {
            public static readonly string STOP_FETCH_OUT = "1";
            public static readonly string STOP_STORE = "2";
            public static readonly string STOP_FETCH_OUT_AND_STORE = "3";
        }
        /****************************************************/

        /***********************Sample Flag***********************/
        public class SampleFlag
        {
            public static readonly string Y = "Selected";
            public static readonly string N = "Not Selected";
        }
        /****************************************************/

        /*************************Lot************************/
        public static readonly string MIX_LOT_ID = "MIX";
        /// <summary>
        /// </summary>
        public class LotStatus
        {
            public static readonly string PROC_COMP = "G";
            public static readonly string PROC_COMP_BUT_NON_MEASURE_UP = "W";
            public static readonly string WAIT_PROC = "S";
            public static readonly string ERROR = "E";
            public static readonly string REMOVE_OR_SCRAP = "X";
        }
        public class LotStat
        {
            public static readonly string Empty = "0";
            public static readonly string WaitforLotInformation = "1";
            public static readonly string WaitforCommand = "2";
            public static readonly string WaitforProcessing = "3";
            public static readonly string Processing = "4";
            public static readonly string ProcessNormalEnd = "5";
            public static readonly string ProcessCancelEnd = "6";
            public static readonly string ProcessAbortEnd = "7";
        }
        /// <summary>
        /// Lot一開始建立時，Process status應該為「WAIT_START_PROC」。
        /// 而等到Start Process之後，狀態再改為「START_PROC」。
        /// 當End Process之後，請將狀態改為「END_PROC」。
        /// </summary>
        public class LotProcessStatus
        {
            public static readonly string Wait_Start_Proc = "W";//等待Start Process
            public static readonly string Start_Proc = "S";     //已經Start Process
            public static readonly string End_Proc = "E";       //已經End Process
        }
        public class LotJudge
        {
            public static readonly string Good = "G";
            public static readonly string No_Good = "N";
            public static readonly string Rework = "R";
            public static readonly string RePair = "P";
            public static readonly string Hold = "H";
            public static readonly string Virtual = "V";
            public static readonly string Inspection = "I";

            public static readonly string[] Set = { Good, No_Good, Rework, RePair, Hold, Virtual, Inspection };
        }

        public class LotJudge_fullDesc
        {
            public static readonly string Good = "Good";
            public static readonly string No_Good = "No Good";
            public static readonly string Rework = "Rework";
            public static readonly string RePair = "Repair";
            public static readonly string Hold = "Hold";
            public static readonly string Virtual = "Virtual";
            public static readonly string Inspection = "Inspection";

            public static readonly string[] Set = { Good, No_Good, Rework, RePair, Hold, Virtual, Inspection };
        }
        /****************************************************/
        /************************Sheet***********************/
        public class SheetTakeOutStatus
        {
            public static readonly string Non = "0";
            public static readonly string Take_Out = "1";
            public static readonly string Erase = "2";
            public static readonly string Register = "3";
        }

        public class SheetTakeOutStatus_fullDesc
        {
            public static readonly string Non = "None";
            public static readonly string Take_Out = "Take Out";
            public static readonly string Erase = "Erase";
            public static readonly string Register = "Register";
        }

        /// <summary>
        /// Sheet一開始建立時，Process status應該為「WAIT_START_PROC」。
        /// 而等到Start Process之後，狀態再改為「START_PROC」。
        /// 當End Process之後，請將狀態改為「END_PROC」。
        /// </summary>
        public class SheetProcessStatus
        {
            public static readonly string WAIT_START_PROC = "W";              //等待Start Process
            public static readonly string START_PROC = "S";                   //已經Start Process
            public static readonly string END_PROC = "E";                     //已經End Process
        }
        public class SheetGrade
        {
            public static readonly string A = "A";
            public static readonly string B = "B";

            public static readonly string[] Set = { A, B };
        }
        public class SheetPositionType
        {
            public static readonly int Unit = 1;
            public static readonly int Port = 2;
            public static readonly int Buffer = 3;
        }

        public class CassetteDispatchInfoItem
        {
            public static readonly string CST_Data_Download = "Cassette data download";
            public static readonly string CST_Start_Command = "Cassette start command";
            public static readonly string BC_Request_Job = "BC request job";
        }
        public class SheetTypeCode
        {
            public static readonly string Mass_Prod = "1";      //量產品
            public static readonly string Test_Prod = "2";      //試作品
            public static readonly string Exp_Prod = "3";       //實驗品
            public static readonly string Dummy_Prod = "4";     //Dummy品
        }
        public class SheetPassFlag
        {
            public static readonly string ON = "1";
            public static readonly string OFF = "2";
        }
        public class MGBCRReadFlag
        {
            public static readonly string No_Read = "0";
            public static readonly string Read = "1";
            public static string initialALLReadFlag()
            {
                return new string(No_Read.ToArray()[0], MGALLBCRReadFlagLength);
            }
        }
        public static readonly int MGALLBCRReadFlagLength = 32;


        public class SheetStatus
        {
            public static readonly string Empty = "0";
            public static readonly string Wait_For_Command = "1";   //Recipe
            public static readonly string Wait_For_Process = "2";   //Start
            public static readonly string Processing = "3";
            public static readonly string Process_Normal_End = "4";
            public static readonly string Process_Abort_End = "5";
            public static readonly string TakeOut = "6";
            public static readonly string Erase = "7";
            public static readonly string Skip = "8";                   //也用於表示該Sheet不必被處理（參考Slot Selected）

            public static readonly string BOE_Empty = "E";
            public static readonly string BOE_Wait_For_Command = "W";   //Recipe
            public static readonly string BOE_Wait_For_Process = "W";   //Start
            public static readonly string BOE_Processing = "R";
            public static readonly string BOE_Process_Normal_End = "P";
            public static readonly string BOE_Process_Abort_End = "F";
            public static readonly string BOE_Skip = "S";                   //也用於表示該Sheet不必被處理（參考Slot Selected）



            public static int convertToBC(string SheetStatus)
            {
                return Convert.ToInt32(SheetStatus);
            }
            public static string convertToMES(int SheetStatus)
            {
                string sSheetStatus = BOE_Empty;
                if (SheetStatus.ToString() == Empty)
                {
                    sSheetStatus = BOE_Empty;
                }
                else if (SheetStatus.ToString() == Wait_For_Command)
                {
                    sSheetStatus = BOE_Wait_For_Command;
                }
                else if (SheetStatus.ToString() == Wait_For_Process)
                {
                    sSheetStatus = BOE_Wait_For_Process;
                }
                else if (SheetStatus.ToString() == Processing)
                {
                    sSheetStatus = BOE_Processing;
                }
                else if (SheetStatus.ToString() == Process_Normal_End)
                {
                    sSheetStatus = BOE_Process_Normal_End;
                }
                else if (SheetStatus.ToString() == Process_Abort_End)
                {
                    sSheetStatus = BOE_Process_Abort_End;
                }
                else if (SheetStatus.ToString() == Skip)
                {
                    sSheetStatus = BOE_Skip;
                }
                else
                {
                    sSheetStatus = BOE_Empty;
                }

                return sSheetStatus;
            }
            public static string convertToMES(string SheetStatus)
            {
                string sSheetStatus = BOE_Empty;
                if (SheetStatus == Empty)
                {
                    sSheetStatus = BOE_Empty;
                }
                else if (SheetStatus == Wait_For_Command)
                {
                    sSheetStatus = BOE_Wait_For_Command;
                }
                else if (SheetStatus == Wait_For_Process)
                {
                    sSheetStatus = BOE_Wait_For_Process;
                }
                else if (SheetStatus == Processing)
                {
                    sSheetStatus = BOE_Processing;
                }
                else if (SheetStatus == Process_Normal_End)
                {
                    sSheetStatus = BOE_Process_Normal_End;
                }
                else if (SheetStatus == Process_Abort_End)
                {
                    sSheetStatus = BOE_Process_Abort_End;
                }
                else if (SheetStatus == Skip)
                {
                    sSheetStatus = BOE_Skip;
                }
                else
                {
                    sSheetStatus = BOE_Empty;
                }

                return sSheetStatus;
            }
        }
        public class SheetProcessInfo
        {
            public static readonly string No_Process = "0";
            public static readonly string Process_Normal_End = "4";
            public static readonly string Process_Abort_End = "5";
            public static readonly string Process_Alarm_End = "6";
            public static readonly string Process_Fail_End = "7";

            public static string initialALLProcInfo()
            {
                return new string(No_Process.ToArray()[0], SheetALLProcessInfoLength);
            }

        }
        public static readonly int SheetALLProcessInfoLength = 8;

        public class SheetType
        {
            public static readonly string LTPS = "T";
            public static readonly string Encap = "E";
            public static readonly string Dummy = "D";
            public static readonly string ITO_Dummy = "I";
            public static readonly string Bare_Dummy = "B";
            public static readonly string UV_Mask = "U";
            public static readonly string Bare_TN_Dummy = "N";
            public static readonly string Bare_FFS_Dummy = "S";
            public static readonly string Bare_PI_Coating_Dummy = "P";
            public static readonly string ITO_PI_Coating_Dummy = "O";
            public static readonly string LTPS_PR = "L";

            public static readonly string[] Set =
            {
                LTPS, Encap, Dummy, ITO_Dummy, Bare_Dummy, UV_Mask,
                Bare_TN_Dummy, Bare_FFS_Dummy, Bare_PI_Coating_Dummy, ITO_PI_Coating_Dummy,LTPS_PR
            };
        }
        public class SheetIDType
        {
            public static readonly string Glass = "G";
            public static readonly string Q_Glass = "Q";
            public static readonly string Panel_Or_Cell = "P";

            public static readonly string[] Set =
            {
                Glass, Q_Glass, Panel_Or_Cell
            };
        }

        public class SheetIDType_fullDesc
        {
            public static readonly string Glass = "Glass";
            public static readonly string Q_Glass = "Q_Glass";
            public static readonly string Panel_Or_Cell = "Panel or Cell";

            public static readonly string[] Set =
            {
                Glass, Q_Glass, Panel_Or_Cell
            };
        }

        public class SheetJudge
        {
            public static readonly string Good = "G";
            public static readonly string No_Good = "N";
            public static readonly string Rework = "R";
            public static readonly string RePair = "P";
            public static readonly string Scrap = "S";
            public static readonly string Fault = "F";
            public static readonly string Virtual = "V";
            public static readonly string Inspection = "I";

            public static readonly string[] Set =
            {
                Good, No_Good, Rework, RePair, Scrap, Fault, Virtual, Inspection
            };
        }

        public class SheetStatus_fullDesc
        {
            public static readonly string Empty = "Empty";
            public static readonly string Wait_For_Command = "Wait for Command";
            public static readonly string Wait_For_Process = "Wait for Process";
            public static readonly string Processing = "Processing";
            public static readonly string Process_Normal_End = "Process End";
            public static readonly string Process_Abort_End = "Abort End";
            public static readonly string Process_Alarm_End = "Alarm End";
            public static readonly string Take_Out = "Take Out";
            public static readonly string Erase = "Erase";
            public static readonly string Process_Fail_End = "Fail End";
            public static readonly string Skip = "Skip";

            public static readonly string[] Set =
            {
                Empty,
                Wait_For_Command,
                Wait_For_Process,
                Processing,
                Process_Normal_End,
                Process_Abort_End,
                Process_Alarm_End,
                Process_Fail_End,
                Skip
            };

            public static readonly string[] Set1 =
            {
                Empty,
                Wait_For_Command,
                Wait_For_Process,
                Processing,
                Process_Normal_End,
                Process_Fail_End,
                Skip
            };
        }

        public class SheetJudge_fullDesc
        {
            public static readonly string Good = "Good";
            public static readonly string No_Good = "No Good";
            public static readonly string Rework = "Rework";
            public static readonly string RePair = "Repair";
            public static readonly string Scrap = "Scrap";
            public static readonly string Fault = "Fault";
            public static readonly string Virtual = "Virtual";
            public static readonly string Inspection = "Inspection";

            public static readonly string[] Set =
            {
                Good, No_Good, Rework, RePair, Scrap, Fault, Virtual, Inspection
            };
        }
        /****************************************************/
        /*************************Workorder************************/
        public class WorkorderStatus
        {
            public static readonly string Init = "0";//當前並無使用
            public static readonly string Wait = "1";//Workorder被Assign後變為此狀態
            public static readonly string Load = "2";//BC對Workorder的CST下帳後
            public static readonly string Processing = "3";//自Workorder的CST抽取玻璃
            public static readonly string Processing_No_CST_Left = "4";
            public static readonly string Process_Normal_End = "5";
            public static readonly string Process_Abort_End = "6";
        }
        /****************************************************/
        /*************************Route************************/
        public class Route
        {
            public static readonly string RouteA = "1";
            public static readonly string RouteB = "2";
        }

        /****************************************************/
        /*************************CST************************/
        public class CSTStatus
        {
            public static readonly int EMPT = 0;
            public static readonly int PRES = 1;
            public static readonly int MAPE = 2;
            public static readonly int WAIT = 3;
            public static readonly int PROC = 4;
            public static readonly int PREN = 5;
            public static readonly int ABORT = 6;
            public static readonly int CANCEL = 7;
            public static readonly int PAUS = 8;
        }
        public class CSTCode
        {
            public static readonly int Real_CST = 1;
            public static readonly int Empty_CST = 2;
            public static readonly int Substrate = 3;
        }
        public class CSTSlotStatus
        {
            public static readonly string EMPTY = "0";
            public static readonly string WAIT_FOR_PROC = "1";
        }
        public class CSTSlotMap
        {
            public static readonly string Not_Exist = "0";
            public static readonly string Exist = "1";
        }
        public class CSTSlotSelect
        {
            public static readonly string Deselected = "0";
            public static readonly string Selected = "1";
        }
        public class CSTSlotSelect_MES
        {
            public static readonly string Deselected = "X";
            public static readonly string Selected = "O";
        }
        public class CSTEndStatus
        {
            public static readonly string Normal_End = "0";
            public static readonly string Abort_End = "1";
        }

        public class LCVDREPAIRTYPE_MES
        {
            public static readonly string NONCUTRepair = "X";
            public static readonly string CUTRepair = "A";
        }
        /****************************************************/

        /*****************Command CMD Constants**************/
        public class commonReturnCode
        {
            public static readonly int OK = 1;
            public static readonly int NG = 2;
        }

        /*****************EP07 Cancel Request**************/
        public class EP07CancelReq_Co
        {
            public static readonly int Nothing = 0;
            public static readonly int Cancel = 1;
            public static readonly int Abort = 2;
        }
        /****************************************************/
        public enum PortSTAT
        {
            LDRQ = 0,
            Pre_LDCM = 1,
            LDCM = 2,
            UDRQ = 3,
            UDCM = 4,
            Disable = 5
        }

        public enum TranSTAT
        {
            Not_Ready = 0,
            Receive_Ready = 1,
            Send_Ready = 2,
            Transferring = 3
        }

        public class PortType
        {
            public static readonly string No_Used = "0";
            public static readonly string LD = "1";
            public static readonly string ULD = "2";
            public static readonly string LD_ULD = "3";
            public static readonly string Buffer = "4";
            public static readonly string SorterPort = "5";
        }

        public class sPortType
        {
            public static readonly string No_Used = "No_Used";
            public static readonly string LD = "LD";
            public static readonly string ULD = "ULD";
            public static readonly string LD_ULD = "LD_ULD";
            public static readonly string Buffer = "Buffer";
            public static readonly string SorterPort = "SorterPort";
            public static readonly string ULD_Partial = "ULD Partial";
        }

        public class TranMode
        {
            public static readonly string AGV = "1";
            public static readonly string MGV = "2";
        }

        public enum CstSTAT
        {
            EMPT = 0,
            PRES = 1,
            MAPE = 2,
            WAIT = 3,
            PROC = 4,
            PREN = 5,
            ABEN = 6,
            Cancel = 7,
            PAUS = 8
        }

        /**************Command Status************************/
        public class CmdStatus
        {
            public static readonly string Queue = "Q";
            public static readonly string Transferring = "T";
            public static readonly string Canceling = "C";
            public static readonly string Aborting = "A";
            public static readonly string Paused = "P";
            public static readonly string AbnormalFinish = "B";
            public static readonly string Finish = "F";
        }
        /****************************************************/

        /**************Command Type************************/
        public class CmdType
        {
            public static readonly string Abort = "A";
            public static readonly string Cancel = "C";
            public static readonly string Pause = "P";
            public static readonly string Resume = "R";
            public static readonly string Retry = "T";
        }
        /****************************************************/

        /**************Command Source************************/
        public class CmdSrc
        {
            public static readonly char MPLC = 'P';
            public static readonly char MES = 'M';
            public static readonly char MCS = 'C';
            public static readonly char LCS = 'L';
        }
        /****************************************************/

        /**************Command Send To LCS*******************/
        public class CmdLCS
        {
            public static readonly string NotSend = "0";
            public static readonly string Sended = "1";
        }

        public class CmdLCSQuery
        {
            public static readonly string NotSend = "0";
            public static readonly string Sended = "1";
            public static readonly string All = "2";
        }
        /****************************************************/

        /**************Command Sub Status********************/
        public class CmdSubStatus
        {
            public const string Default = "NA";
            public const string Complete = "0";
            public const string Double_Storage = "1";
            public const string Empty_Retrieve = "2";
            public const string BCR_ReadFail = "3";
            public const string Wait_Time_Over = "4";
            public const string BCR_MissMatch = "5";
            public const string Manual_Take_Out = "6";
        }
        /****************************************************/

        /**************Command Mode**************************/
        public class CmdMode
        {
            public const string StoreIn = "1";
            public const string StoreOut = "2";
            public const string Cycle = "3";
            public const string Port2Port = "4";
            public const string Shelf2Shelf = "5";
        }
        /****************************************************/

        /**************Transfer Complete Result To Host******/
        public class TrxCmpHostCode
        {
            public const int Complete = 1;
            public const int NG = 2;
            public const int Trx_Cycle_Time_Over = 3;
            public const int Oper_Cancel = 4;
        }
        /****************************************************/

        /**************Robot Command Status******************/
        public enum RobotCMDStatus
        {
            Gen = 1,
            Send = 2,
            Process_Wait = 3,
            Processing = 4,
            Process_End = 5,
            Robot_Cancel = 6,
            Manul_Cancel = 7
        }
        /****************************************************/

        /******************Command Prioty********************/
        public enum CMDPrioty
        {
            NA = 0,
            Semi_Mode = 5,
            Normal_Mode = 9
        }

        /****************************************************/

        /******************OperationMode********************/
        public class OperationMode
        {
            public static readonly int AUTO = 1;
            public static readonly int MANU = 0;
        }

        public class sOperationMode
        {
            /// <summary>
            /// The automatic
            /// </summary>
            public static readonly string sAUTO = "Auto";
            /// <summary>
            /// The manu
            /// </summary>
            public static readonly string sMANU = "Manual";
        }
        /****************************************************/

        /******************GenerateSource********************/
        public class GenerateSource
        {
            public static readonly int Transfer = 1;
            public static readonly int Get = 2;
            public static readonly int Put = 3;
            public static readonly int Move = 4;
            public static readonly int Cancel = 5;
            public static readonly int Scan = 6;
        }
        /****************************************************/

        /******************Empty Arm********************/
        public enum EmptyArm
        {
            U = 1,
            L = 2,
            B = 3,
            E = 4         //Add by Wei
        }
        /****************************************************/

        /******************Arm********************/
        public class RobotArm
        {
            public static readonly int None = 0;
            public static readonly int U = 1;
            public static readonly int L = 2;
            public static readonly int B = 3;
            public static readonly int E = 4;

            public static int conver2RobotArm_PLC(string robot_arm)
            {
                if (robot_arm == "N")
                {
                    return RobotArm.None;
                }
                else if (robot_arm == "U")
                {
                    return RobotArm.U;
                }
                else if (robot_arm == "L")
                {
                    return RobotArm.L;
                }
                else if (robot_arm == "B")
                {
                    return RobotArm.B;
                }
                else if (robot_arm == "E")
                {
                    return RobotArm.E;
                }
                return RobotArm.None;

            }

            public static int conver2RobotArm_ECV(string robot_arm)
            {
                if (robot_arm == "1")
                {
                    return RobotArm.U;
                }
                else if (robot_arm == "2")
                {
                    return RobotArm.L;
                }
                return RobotArm.U;
            }
        }
        /****************************************************/

        /******************Command Code*********************/
        public enum CommandCode
        {
            OK = 1,
            BUNDLE_ID_NOT_FOUND = 2,
            TBD = 3
        }
        /****************************************************/

        /******************Command Type*********************/
        public enum CommandType
        {
            Transfer = 1,
            Get = 2,
            Put = 3,
            Move = 4,
            Cancel = 5,
            Scan = 6
        }
        /****************************************************/

        /******************Stage Type ********************/
        public class StageType
        {
            public static readonly string Send = "S";
            public static readonly string Recive = "R";
            public static readonly string SendRecive = "B";
        }
        /****************************************************/

        /******************Command Type ********************/
        public class TranStatus
        {
            public static readonly string Not_Ready = "0";
            public static readonly string Recive_Ready = "1";
            public static readonly string Send_Ready = "2";
            public static readonly string Transferring = "3";
        }
        /****************************************************/

        /******************Lot Wait********************/
        public class LotWait
        {
            public static readonly string No_Wait = "0";
            public static readonly string Lot_Wait = "1";
        }
        /****************************************************/

        /******************Turn Glass********************/
        public class Turn_Glass
        {
            public static readonly string No_Turn = "No Turn";
            public static readonly string Turn = "Turn(180 rotation)";
        }
        /****************************************************/

        /******************Master Pc Ready********************/
        public class MasterPCReady
        {
            public static readonly string Not_Ready = "0";
            public static readonly string Ready = "1";
        }
        /****************************************************/

        /******************INDPosition OrderByConsition********************/
        public class INDPosition_OrderByConsition
        {
            public static readonly string STATUSTIME = "STATUSTIME";
            public static readonly string ROBOT_POSITION = "Robot_Position";
            public static readonly string STATUS = "STATUS";
        }
        /****************************************************/

        /******************INDPosition direction********************/
        public class INDPosition_Direction
        {
            public static readonly string ASC = "ASC";
            public static readonly string DES = "DES";
        }
        /****************************************************/

        /******************DCS Service Order********************/
        public class DCS_ServiceOrder
        {
            public static readonly string StatusTime_Priority = "0";
            public static readonly string SendReady_Priority = "1";
            public static readonly string INDPosition_Priority = "2";
            public static readonly string[] Set = { StatusTime_Priority, SendReady_Priority, INDPosition_Priority };

        }
        /****************************************************/

        /******************DCS Scan Items********************/
        public class DCS_ScanItems
        {
            public const string On_Robot = "0";
            public const string Position_Status = "1";
            public const string PreGet_PreMove = "2";

            public static readonly string[] Set_ServiceOrder_StatusTime = { On_Robot, Position_Status, PreGet_PreMove };
            public static readonly string[] Set_ServiceOrder_SendReady = { Position_Status, On_Robot, PreGet_PreMove };
        }
        /****************************************************/

        /******************DCS Pre Move********************/
        public class DCS_PreMove
        {
            public static readonly string None = "0";
            public static readonly string N2 = "1";
            public static readonly string N3 = "2";
            public static string convert2EQID_ECV(string eq_no)
            {
                if (BCFUtility.isMatche(eq_no, "0"))
                {
                    return "None";
                }
                else if (BCFUtility.isMatche(eq_no, "1"))
                {
                    return "N2";
                }
                else if (BCFUtility.isMatche(eq_no, "2"))
                {
                    return "N3";
                }
                return "None";
            }
            public static readonly string[] Set = { None, N2, N3 };

        }
        /****************************************************/
        /******************DCS Pre Get********************/
        public class DCS_PreGet
        {
            public static readonly string None = "0";
            public static readonly string N2 = "1";
            public static readonly string N3 = "2";

            public static string convert2EQID_ECV(string eq_no)
            {
                if (BCFUtility.isMatche(eq_no, "0"))
                {
                    return "None";
                }
                else if (BCFUtility.isMatche(eq_no, "1"))
                {
                    return "N2";
                }
                else if (BCFUtility.isMatche(eq_no, "2"))
                {
                    return "N3";
                }
                return "None";
            }
            public static readonly string[] Set = { None, N2, N3 };

        }
        /****************************************************/
        /******************DCS Mode********************/
        public class DCS_Mode
        {
            public const string StandardMode = "0";
            public const string EffectiveMode = "1";
            public const string ScanMode = "2";

            public static string convert2EQID_ECV(string mode)
            {
                if (BCFUtility.isMatche(mode, StandardMode))
                {
                    return "Standard Mode";
                }
                else if (BCFUtility.isMatche(mode, EffectiveMode))
                {
                    return "Effective Mode";
                }
                else if (BCFUtility.isMatche(mode, ScanMode))
                {
                    return "Scan Mode";
                }
                return "None";
            }
            public static readonly string[] Set = { StandardMode, EffectiveMode, ScanMode };

        }
        /****************************************************/

        /******************DCSMaskRule********************/
        public class DCSMaskRule
        {
            public const string Name = "DCSMaskRule";
            public const string NEXT_STATION_NAME = "NEXT_STATION_NAME";
            public const string Q_TIME_CONTROL = "Q_TIME_CONTROL";
        }
        /****************************************************/
        /******************DCSMaskRule********************/
        public class DCSSortRule
        {
            public const string Name = "DCSSortRule";
            public const string CstLogOn_Time = "CstLogOn_Time";
            public const string Source_Slot_NO = "Source_Slot_NO";
            public const string Job_Priority = "Job_Priority";
            public const string CstLastProc_Time = "CstLastProc_Time";
        }
        /****************************************************/
        /******************JobType***************************/
        public class JobType
        {
            public static readonly int None = 0;
            public static readonly int Glass = 1;
            public static readonly int COP = 2;
            public static readonly int Glass_COP = 3;
            public static readonly int COP_TPF_BPF = 4;

            public static int conver2JobType_PLC(string job_type)
            {
                if (job_type == "Glass")
                {
                    return JobType.Glass;
                }
                else if (job_type == "COP")
                {
                    return JobType.COP;
                }
                else if (job_type == "Glass+COP")
                {
                    return JobType.Glass_COP;
                }
                else if (job_type == "COP+TPF+BPF")
                {
                    return JobType.COP_TPF_BPF;
                }
                return JobType.None;

            }
        }
        /****************************************************/
        /******************JobSizeType***************************/
        public class JobSizeType
        {
            public static readonly string Glass = "G";
            public static readonly string QGlass = "Q";
            public static readonly string Panel = "P";
        }
        /****************************************************/
        /********************CST Type************************/
        public class CstType
        {
            public static readonly int CST = 0;
            public static readonly int PPBOX = 1;
            public static readonly int TRAY = 2;
        }
        /***************************************************/
        /******************Material Status******************/
        public class MtelStat
        {
            public static readonly int Unmount = 0;
            public static readonly int Mount = 1;
        }
        /***************************************************/
        /**************Robot Command Return******************/
        public class CMDReturn
        {
            public static int Complete = 1;
        }
        /****************************************************/

        public const string RECIPE_PARAMETER_NAME_TURNANGLE = "RotationAngle";
        public class TurnAngle
        {
            public const string Angle_0 = "0";
            public const string Angle_90 = "90";
            public const string Angle_180 = "180";
            public const string Angle_270 = "270";

            public static string convert2PLC(string real_value)
            {
                switch (real_value.Trim())
                {
                    case Angle_0:
                        return "0";
                    case Angle_90:
                        return "1";
                    case Angle_180:
                        return "2";
                    case Angle_270:
                        return "3";
                    default:
                        return string.Empty;
                }

            }
        }
        public class TurnAngle_PLC
        {
            public const string Angle_0 = "0";
            public const string Angle_90 = "1";
            public const string Angle_180 = "2";
            public const string Angle_270 = "3";

            public static string convert2RealAngle(string plc_value)
            {
                switch (plc_value.Trim())
                {
                    case Angle_0:
                        return TurnAngle.Angle_0;
                    case Angle_90:
                        return TurnAngle.Angle_90;
                    case Angle_180:
                        return TurnAngle.Angle_180;
                    case Angle_270:
                        return TurnAngle.Angle_270;
                    default:
                        return string.Empty;
                }
            }
        }

        #region MainAlarm
        public class MainAlarmCode
        {
            public const string EMPTY_RETRIVE_0 = "AL001";
            public const string DOUBLE_STORAGE_0_1 = "AL002";
            public const string BCR_ID_MISMATCH_0_1 = "AL003";
            public const string BCR_READ_FAIL_0 = "AL004";

            public const string COMMAND_NOT_FOUND_0 = "AM001";

            public const string HOST_CMD_MG_ID_EMPTY_0 = "AH001";
            public const string HOST_CMD_DEST_EMPTY_0_1 = "AH002";
            public const string HOST_CMD_DEST_ERROR_0_1_2 = "AH003";
            public const string HOST_CMD_MG_NOT_EXIST_0_1 = "AH004";

            public const string COMMAND_LOCATION_MISMATCH_0_1_2 = "WL001";
        }
        public class MainAlarmLevel
        {
            public const char Info = 'I';
            public const char Warn = 'W';
            public const char Alarm = 'A';
        }

        #endregion MainAlarm

        //================================================
        // 頁面共用方法
        //================================================

        //取得主頁面 版本號碼
        public static String getMainFormVersion(String appendStr)
        {
            return FileVersionInfo.GetVersionInfo(
                Assembly.GetExecutingAssembly().Location).FileVersion.ToString() + appendStr;
        }

        public static DateTime GetBuildDateTime()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.ToLocalTime();
            return dt;
        }
        public class GlassInterfaceMode
        {
            public const string EqptToEqpt = "0";
            public const string EqptToRobot = "1";
            public const string RobotToEqpt = "2";
        }

        public class ColorDefCate
        {
            public const string LINE_STAT = "LineStat";
            public const string EQ_STAT = "EqStat";
            public const string EQ_ALIVE = "EqAlive";
            public const string OP_MODE = "OpMode";
            public const string CIM_MODE = "CimMode";
            public const string INLINE_MODE = "InLineMode";
            public const string ALARM = "Alarm";
            public const string WARN = "Warn";
            public const string EQ_CURR_WIP = "EQCurrentWIP";
            public const string EQ_CURR_RECIPE = "EQCurrentRECIPE";
            public const string EQ_READY = "EQ_READY";

            public const string PORT_TRSMODE = "PortTransferMode";
            public const string PORT_TYPE = "PortType";
            public const string PORT_ENABLE = "PortEnable";
            public const string PORT_STAT = "PortStatus";
            public const string PORT_CST_STAT = "CSTStatus";
            public const string PORT_LOT_ID = "LotID";
            public const string PORT_CST_ID = "CSTID";
            public const string PORT_CARRIER_TYPE = "CarrierType";
            public const string PORT_GLS_QTY = "GlassQTY";
        }

        public class ColorDefLine
        {
            public const string IDLE = "IDLE";
            public const string RUN = "RUN";
            public const string DOWN = "DOWN";
            public const string MAINTENANCE = "MAINTENANCE";
            public const string OTHER = "OTHER";
        }

        public class ColorDefEqStat
        {
            public const string IDLE = "IDLE";
            public const string RUN = "RUN";
            public const string DOWN = "DOWN";
            public const string MAINTENANCE = "MAINTENANCE";
            public const string OTHER = "OTHER";
        }

        public class ColorDefEqAlive
        {
            public const string ALIVE = "Y";
            public const string NOT_ALIVE = "N";
        }

        public class ColorDefOpMode
        {
            public const string AUTO = "AUTO";
            public const string MANUAL = "MANUAL";
        }

        public class ColorDefCimMode
        {
            public const string ON = "ON";
            public const string OFF = "OFF";
        }

        public class ColorDefAlarm
        {
            public const string YES = "Y";
            public const string NO = "N";
        }

        public class ColorDefWarn
        {
            public const string YES = "Y";
            public const string NO = "N";
        }

        public class ColorDefInLineMode
        {
            public const string ON = "ON";
            public const string OFF = "OFF";
        }

        public class ColorDefEQCurrentWIP
        {
            public const string EQWIP_Non_zero = "N";
            public const string EQWIP_Zero = "Y";
        }

        public class ColorDefEQCurrentRECIPE
        {
            public const string EQRec_isExist = "Y";
            public const string EQRec_isntExist = "N";
        }

        public class EQWIPPositionJobStatus
        {
            public static readonly int NoWIP = 0;
            public static readonly int EQNoSupport = 1;
            public static readonly int Normal = 2;
            public static readonly int Abnormal = 3;
        }

        public class ColorDefEQReady
        {
            public const string ON = "ON";
            public const string OFF = "OFF";
        }



        public class ColorDefPortTransferMode
        {
            public const string AGV = "AGV";
            public const string MGV = "MGV";
        }

        public class ColorDefPortType
        {
            public const string LD = "LD";
            public const string ULD = "ULD";
            public const string BOTH = "LD_ULD";
            public const string BUFFER = "BUFFER";
            public const string ULDPARTIAL = "ULD_PARTIAL";
        }

        public class ColorDefPortEnable
        {
            public const string ENABLE = "Enable";
            public const string DISABLE = "Disable";
        }

        public class ColorDefPortStatus
        {
            public const string LDRQ = "LDRQ";
            public const string PDCM = "PDCM";
            public const string LDCM = "LDCM";
            public const string UDRQ = "UDRQ";
            public const string UDCM = "UDCM";
            public const string DISABLE = "DISABLE";
        }

        public class ColorDefCSTStatus
        {
            public const string EMPT = "EMPT";
            public const string PRES = "PRES";
            public const string MAPE = "MAPE";
            public const string WAIT = "WAIT";
            public const string PROC = "PROC";
            public const string PREN = "PREN";
            public const string ABOT = "ABOT";
            public const string CANCEL = "CANCEL";
            public const string PAUS = "PAUS";
        }

        public class ColorDefLotID
        {
            public const string isExist = "Y";
            public const string isnExist = "N";
        }

        public class ColorDefCSTID
        {
            public const string isExist = "Y";
            public const string isnExist = "N";
        }

        public class ColorDefPortCarrierType
        {
            public const string NORMAL = "NORMAL";
            public const string PPBOX = "PPBOX";
            public const string TRAY = "TRAY";
        }

        public class ColorDefGLSQTY
        {
            public const string GLSQTY_Zero = "Y";
            public const string GLSQTY_Non_zero = "N";
        }

        public class LineStatMap
        {
            public const string NodeName_Run = "RUN";
            public const string NodeName_Down = "DOWN";
            public const string NodeName_Idle = "IDLE";
            public const string NodeName_Main = "MAINT";
            public const string NodeName_Sub = "Sub Condition";
        }

        public class LineStatRelation
        {
            public const string Relation_And = "and";
            public const string Relation_Or = "or";
        }

        //Action Flag
        public const string ACT_FLAG_ADD = "Add";
        public const string ACT_FLAG_UPDATE = "Update";
        public const string ACT_FLAG_DELETE = "Delete";

        #region AOI、PACK
        public class PortID
        {          
            public const string Buffer_Group_Port = "GP01";
            public const string Buffer_Reject_Port = "RP01";
        }

        public class Tray_Type
        {
            public const int UNKNOWN = 0;
            public const int FULL_GOODS = 1;
            public const int LAST_GOODS = 2;
            public const int REJECT_GOODS = 3;
            public const int EMPTY_GOODS = 4;
            public const int BLUE_COVER_GOODS = 5;
            public const int GRAY_COVER_GOODS = 6;
            public const int RED_COVER_GOODS = 7;
        }

        public class LD_Port_Status 
        {
            public const int LD_Port_LDRQ = 1;
            public const int LD_Port_LDCM = 2;
            public const int LD_Port_UDRQ = 3;
        }
        #endregion AOI、PACK

        #region Socket
        public const string Host_Sever_IP = "Host_Sever_IP";
        public const string Host_Sever_Port = "Host_Sever_Port";
        public const string Host_Sever_Timeout = "Host_Sever_Timeout";
        #endregion Socket

        #region NATS
        public const string NATS_SUBJECT_SYSTEM_EVENT_INFO = "NATS_SUBJECT_KEY_SYSTEM_EVENT_INFO";
        public const string NATS_SUBJECT_ALARM_INFO = "NATS_SUBJECT_KEY_ALARM_INFO";
        public const string NATS_SUBJECT_CMD_INFO = "NATS_SUBJECT_KEY_CMD_INFO";
        public const string NATS_SUBJECT_STK_CMD_INFO = "NATS_SUBJECT_KEY_STK_CMD_INFO";
        public const string NATS_SUBJECT_LINE_INFO = "NATS_SUBJECT_KEY_LINE_INFO";
        public const string NATS_SUBJECT_BC_INFO = "NATS_SUBJECT_KEY_BC_INFO";
        public const string NATS_SUBJECT_TIP_INFO = "NATS_SUBJECT_KEY_TIP_INFO";
        public const string NATS_SUBJECT_EQPT_INFO_0 = "NATS_SUBJECT_KEY_EQPT_INFO_{0}";
        public const string NATS_SUBJECT_PORT_INFO_0 = "NATS_SUBJECT_KEY_PORT_INFO_{0}";
        #endregion NATS

        public class LocationType
        {
            public const int Port = 0;
            public const int Equipment = 1;
            public const int Shelf = 2;
        }

        public class CrrTrxStat
        {
            public const int Nothing = 0;
            public const int WaitIn = 1;
            public const int Transfer = 2;
            public const int Processing = 3;
            public const int Complete = 4;
            public const int Alternate = 5;
            public const int WaitOut = 6;
            public const int Maintenance = 7;
            public const int Unknow = 8;
        }

        public class CrrHoldStat
        {
            public const string Unhold = "0";
            public const string Hold = "1";
        }

        public class TransferType
        {
            public const int Put = 1;
            public const int Get = 2;
        }

        public class ParameterCate
        {
            public static readonly string System = "SYSTEM";
            public static readonly string Serial_No = "SERIALNO";
            public static readonly string Check_Water_Level = "CHK_LEVEL";
            public static readonly string Crr_Type = "MG_TYPE";
            public static readonly string Wait_CMD = "WAIT_CMD";
            public static readonly string Empty_Crr_Set = "EMPT_MG";
            public static readonly string EQ_MG_Type = "EQMG_TYPE";
        }

        public class ParameterID
        {
            public static readonly string ArmMode = "ARM_MODE";
            public static readonly string CranePriority = "CRANE_PRIORITY";
            public static readonly string CV_Water_Level = "CV_WATER_LEVEL";
            public static readonly string Unknow_Crr = "UNKNOWCRR";
            public static readonly string Merge_Cmd = "MERGECMD";
            public static readonly string Time = "TIME";
            public static readonly string Max = "MAX";
        }

        public class ControlStat
        {
            public const string On = "ON";
            public const string Off = "OFF";
        }

        #region EQ
        public class HW33_ReturnCode
        {
            public const int OK = 1;
            public const int NoBundleID = 2;
            public const int NoMoreBuffer = 3;
            public const int Other = 4;
            public const string EQ_Timeout = "Timeout";
        }

        public class EW36_Code
        {
            public const int OK = 1;
            public const int BCR_Read_Abnormal = 2;
            public const int Manual_Take_Out = 3;
        }

        public class HW36_ReturnCode
        {
            public const int OK = 1;
            public const int CIM_NoReply = 2;
            public const int Other = 3;
        }

        public class EW37_EventType
        {
            public const int Create = 1;
            public const int Delete = 2;
        }

        public class HW37_ReturnCode
        {
            public const int OK = 1;
            public const int Over_Crr_Type_Max_Cnt = 2;
            public const int Crr_Exist_In_Shelf = 3;
            public const int Crr_Exist_In_CV = 4;
            public const int Crr_Type_Length_Error = 5;
            public const int Other = 6;
        }

        public class ES56_ReturnCode
        {
            public const int OK = 1;
            public const int NG = 2;
            public const int Other = 3;
        }

        public class EC02_ReturnCode
        {
            public const int OK = 1;
            public const int Robot_Error = 2;
            public const int Robot_Run_Other_Cmd = 3;
            public const int Cmd_Error = 4;
            public const int Other = 5;
        }

        public class EC03_ReturnCode
        {
            public const int OK = 1;
            public const int Empty_Retrive = 2;
            public const int Double_Storage = 3;
            public const int MGID_Mismatch = 4;
            public const int Unknown_ID = 5;
            public const int Time_Out = 6;
            public const int Other = 7;
        }

        public class TranCMDReturnCode
        {
            public const int ACK = 0;
            public const int Busy = 1;
            public const int CIM_Mode_Is_Offline = 2;
            public const int Invalid_Parameter = 3;
            public const int Error = 10;
            public const int Cancel_By_User = 97; 
            public const int NoFindPosition = 98;
            public const int NoCMD = 99;
        }

        public class CrrStat
        {
            public static readonly int EMPTY = 0;
            public static readonly int WAIT_FOR_PROC = 1;
        }

        public class CrrExist
        {
            public static readonly int Not_Exist = 0;
            public static readonly int Exist = 1;
        }
        #endregion

        #region ASRS
        public static readonly string CrrLoc_Unknown = "UNKW";

        public class AsrsShelfStat
        {
            public const string Empty = "N";
            public const string EmptyCrr = "E";
            public const string Stored = "S";
            public const string Store_In_Reserve = "I";
            public const string Store_Out_Reserve = "O";
            public const string Cycle_Reserve = "C";
            public const string Cycle_Done = "P";
            public const string Disable = "X";
            public const string Double_Storage = "D";
        }

        public class AsrsShelfEnable
        {
            public const int Disable = 0;
            public const int Enable = 1;
            public const string DisableStr = "0";
            public const string EnableStr = "1";
        }

        public class AsrsAddCmdFuncType
        {
            public static readonly string Kick_In = "1";
            public static readonly string Kick_Out = "2";
            public static readonly string Inventory = "3";
            public static readonly string P2P_Cyle = "4";
            public static readonly string S2S = "5";
        }

        public class AsrsAddCmdIOType
        {
            public static readonly string MCS_In = "11";
            public static readonly string MCS_Out = "21";
            public static readonly string MCS_UI_In = "12";
            public static readonly string MCS_UI_Out = "22";
            public static readonly string Inventory_KickIn = "31";
            public static readonly string Inventory_KickOut = "32";
            public static readonly string P2P = "41";
            public static readonly string S2S = "51";
        }

        public class AsrsCmdStat
        {
            public static readonly string Init = "0";
            public static readonly string Started = "1";
            public static readonly string Cmd_Error_Wait_Cancel = "6";
            public static readonly string Cmd_Wait_Cmp = "7";
            public static readonly string Cmd_Wait_Cancel = "8";
            public static readonly string Cmd_Cmp = "9";
            public static readonly string Cmd_Cancel = "D";
            public static readonly string Post_Fail = "E";
        }

        public class AsrsUpdateCrrFuncType
        {
            public static readonly string Add = "1";
            public static readonly string Modify = "2";
            public static readonly string Delete = "3";
        }

        public class AsrsAUpdateCrrIOType
        {
            public static readonly string AddByBC = "13";
            public static readonly string UpdateByBC = "22";
            public static readonly string DeleteByBC = "32";
        }

        public class AsrsProhibitShelfFuncType
        {
            public static readonly string Prohibit = "1";
            public static readonly string Unprohibit = "2";
            public static readonly string Disable = "3";
            public static readonly string Enable = "4";
        }

        public class ToStockerNo
        {
            public static readonly string ToSKT01 = "9998";
            public static readonly string ToSKT02 = "9999";
        }

        public class AsrsRtnCode
        {
            public static readonly string FullStk = "00024";
        }

        public class EquipmentID
        {
            public const string Stocker1 = "STK01";
            public const string Stocker2 = "STK02";
            public const string CV1 = "CV01";
        }

        public class TicketNo
        {
            public static readonly string TicketNo_MPLC = "TICKETNO_P";
            public static readonly string TicketNo_MES = "TICKETNO_M";
        }
        #endregion ASRS

        #region API
        public class ApiReturnCode
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string Other_Code = "20040";
            public static readonly string Alarm_Other_Code = "PN040";
        }

        public class ApiRequestOnOffLine
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string System_ID_Error_Code = "20041";
            public static readonly string Alarm_System_ID_Error_Code = "PE041";

            public static readonly string Control_Status_Error_Code = "20042";
            public static readonly string Alarm_Control_Status_Error_Code = "PE042";

            public static readonly string Status_Error_Code = "20043";
            public static readonly string Main_Alarm_Status_Error_Code = "PE043";

            public static readonly string Already_OnOff_Line_Code = "20044";
            public static readonly string Alarm_Already_OnOff_Line_Code = "PE044";

            public static readonly string Cmd_Exist_Code = "20045";
            public static readonly string Alarm_Cmd_Exist_Code = "PE045";

            public static readonly string Other_Code = "20046";
            public static readonly string Alarm_Other_Code = "PE046";
        }

        public class ApiEmptyMGSet
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string Crr_Type_Error_Code = "20051";
            public static readonly string Alarm_Crr_Type_Error_Code = "PE051";

            public static readonly string Other_Code = "20052";
            public static readonly string Alarm_Other_Code = "PE052";
        }

        public class ApiShelfProhibit
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string Loc_Error_Code = "20061";
            public static readonly string Alarm_Loc_Error_Code = "PE061";

            public static readonly string Other_Code = "20062";
            public static readonly string Alarm_Other_Code = "PE062";
        }

        public class ApiAddStkCmd
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string Crr_ID_Error_Code = "20071";
            public static readonly string Alarm_Crr_ID_Error_Code = "PE071";

            public static readonly string Loc_Error_Code = "20072";
            public static readonly string Alarm_Loc_Error_Code = "PE072";


            public static readonly string Crr_Not_Exist_Code = "20073";
            public static readonly string Alarm_Crr_Not_Exist_Code = "PE073";

            public static readonly string Crr_Has_Cmd_Code = "20074";
            public static readonly string Alarm_Crr_Has_Cmd_Code = "PE074";

            public static readonly string Crr_Not_In_Shelf_Code = "20075";
            public static readonly string Alarm_Crr_Not_In_Shelf_Code = "PE075";

            public static readonly string Crr_Wait_Kick_Out_Code = "20076";
            public static readonly string Alarm_Crr_Wait_Kick_Out_Code = "PE076";

            public static readonly string ASRS_Error_Code = "20077";
            public static readonly string Alarm_ASRS_Error_Code = "";

            public static readonly string Other_Code = "20078";
            public static readonly string Alarm_Other_Code = "PE078";
        }

        public class ApiGetMGVPort
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string STK_ID_Error_Code = "20081";
            public static readonly string Alarm_STK_ID_Error_Code = "PE081";

            public static readonly string Other_Code = "20082";
            public static readonly string Alarm_Other_Code = "PE082";
        }

        public class ApiAddCmd
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string Crr_ID_Error_Code = "20091";
            public static readonly string Alarm_Crr_ID_Error_Code = "PE091";

            public static readonly string Crr_Not_Exist_Code = "20092";
            public static readonly string Alarm_Crr_Not_Exist_Code = "PE092";

            public static readonly string Crr_Has_Cmd_Code = "20093";
            public static readonly string Alarm_Crr_Has_Cmd_Code = "PE093";

            public static readonly string Crr_Wait_Kick_Out_Code = "20094";
            public static readonly string Alarm_Crr_Wait_Kick_Out_Code = "PE094";

            public static readonly string ASRS_Error_Code = "20095";
            public static readonly string Alarm_ASRS_Error_Code = "";

            public static readonly string Other_Code = "20096";
            public static readonly string Alarm_Other_Code = "PE096";
        }

        public class ApiOperChg
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string Oper_Mode_Error_Code = "20101";
            public static readonly string Alarm_Oper_Mode_Error_Code = "PE101";

            public static readonly string Other_Code = "20102";
            public static readonly string Alarm_Other_Code = "PE102";
        }

        public class ApiSemiStkCmd
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string STK_ID_Error_Code = "20111";
            public static readonly string Alarm_STK_ID_Error_Code = "PE111";

            public static readonly string Act_Error_Code = "20112";
            public static readonly string Alarm_Act_Error_Code = "PE112";

            public static readonly string Arm_Error_Code = "20113";
            public static readonly string Alarm_Arm_Error_Code = "PE113";

            public static readonly string From_Error_Code = "20114";
            public static readonly string Alarm_From_Error_Code = "PE114";

            public static readonly string Crr_Not_Exist_Code = "20115";
            public static readonly string Alarm_Crr_Not_Exist_Code = "PE115";

            public static readonly string Crr_Has_Cmd_Code = "20116";
            public static readonly string Alarm_Crr_Has_Cmd_Code = "PE116";

            public static readonly string Crane_Cannot_Run_Cmd_Code = "20117";
            public static readonly string Alarm_Crane_Cannot_Run_Cmd_Code = "PE117";

            public static readonly string Oper_Mode_Error_Code = "20118";
            public static readonly string Alarm_Oper_Mode_Error_Code = "PE118";

            public static readonly string ASRS_Error_Code = "20119";
            public static readonly string Alarm_ASRS_Error_Code = "";

            public static readonly string Other_Code = "20120";
            public static readonly string Alarm_Other_Code = "PE120";
        }

        public class ApiStkMergeCmd
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string STK_ID_Error_Code = "20121";
            public static readonly string Alarm_STK_ID_Error_Code = "PE121";

            public static readonly string Merge1_Error_Code = "20122";
            public static readonly string Alarm_Merge1_Error_Code = "PE122";

            public static readonly string Merge2_Error_Code = "20123";
            public static readonly string Alarm_Merge2_Error_Code = "PE123";

            public static readonly string Other_Code = "20124";
            public static readonly string Alarm_Other_Code = "PE124";
        }

        public class ApiStkPressureTest
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string STK_ID_Error_Code = "20131";
            public static readonly string Alarm_STK_ID_Error_Code = "PE131";

            public static readonly string Other_Code = "20132";
            public static readonly string Alarm_Other_Code = "PE132";
        }

        public class ApiCancelAllCmd
        {
            public static readonly string Ok_Code = "00000";
            public static readonly string Alarm_Ok_Code = "PN000";

            public static readonly string STK_ID_Error_Code = "20141";
            public static readonly string Alarm_STK_ID_Error_Code = "PE141";

            public static readonly string Other_Code = "20142";
            public static readonly string Alarm_Other_Code = "PE142";
        }
        #endregion API

        #region CIM
        public class S015_ReturnCode
        {
            public static readonly string Ok_Msg = "PASS";
            public static readonly string Error_Msg = "REJECT";

            public static readonly string Over_Loc_Cnt = "01";
            public static readonly string Crr_Type_Not_Exist = "02";
            public static readonly string Other_Error = "03";
        }
        #endregion CIM

        #region RAIL_CHANGER
        public class RC_Side
        {
            public const int RIGHT = 1;
            public const int LEFT = 2;
        }
        public class RC_Mode
        {
            public const int NOTTHING = 0;
            public const int MANUAL = 1;
            public const int AUTO = 2;
        }

        public class RC_OnOff
        {
            public const int OFF = 0;
            public const int ON = 1;
        }
        #endregion RAIL_CHANGER
    }
}
