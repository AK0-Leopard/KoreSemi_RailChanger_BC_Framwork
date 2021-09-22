//*********************************************************************************
//      SCUtility.cs
//*********************************************************************************
// File Name: SCUtility.cs
// Description: ScriptControl 共用工具元件
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/23    Steven Hong    N/A            A0.01   移除Cassette，將Cassette資料儲存於Carrier中
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using System.Data;
using System.Reflection;
using NLog;
using com.mirle.ibg3k0.stc.Data.SecsData;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.bcf.App;
using System.Collections;
using System.Diagnostics;
using com.mirle.ibg3k0.Utility.ul.Data.VO;
using System.ComponentModel;
using com.mirle.ibg3k0.mqc.tx;
using com.mirle.ibg3k0.sc.ValueHandler;

namespace com.mirle.ibg3k0.sc.Common
{
    public class SCUtility
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Logger SECSMsgLogger = LogManager.GetLogger("SECSMsgLogger");
        private static Logger CSTInfoLogger = LogManager.GetLogger("CSTInfoLogger");
        private static Logger OperationLogger = LogManager.GetLogger("OperationLogger");
        protected static Logger logger_MapActioLog = LogManager.GetLogger("MapActioLog");
        //private CommonInfo ci;

        public static void SystemEventLog(string msg, EventLogEntryType type)
        {
            try
            {
                string src_name = "SC Application";
                if (!EventLog.SourceExists(src_name))
                {
                    EventLog.CreateEventSource(src_name, src_name);
                }
                EventLog eLog = new EventLog();
                eLog.Source = src_name;
                eLog.WriteEntry(msg, type);
            }
            catch { }
        }

        public static Boolean isMatche(Object obj1, Object obj2)
        {
            return BCFUtility.isMatche(obj1, obj2);
        }

        public static Boolean isEmpty(Object obj)
        {
            return BCFUtility.isEmpty(obj);
        }

        public static String Trim(String source)
        {
            return Trim(source, false);
        }

        /// <summary>
        /// A0.02
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static String TrimAndToUpper(String source)
        {
            return ToUpper(Trim(source, false), false);
        }

        public static String Trim(string source, Boolean rtnEmptyStr)
        {
            if (source == null) { return (rtnEmptyStr ? string.Empty : source); }
            return source.Trim();
        }

        /// <summary>
        /// A0.02
        /// </summary>
        /// <param name="source"></param>
        /// <param name="rtnEmptyStr"></param>
        /// <returns></returns>
        public static String ToUpper(string source, Boolean rtnEmptyStr)
        {
            if (source == null) { return (rtnEmptyStr ? string.Empty : source); }
            return source.ToUpper();
        }


        public static String FillPadLeft(string source, char padChar, int length)
        {
            if (source == null) { return null; }
            return Trim(source).PadLeft(length, padChar);
        }

        public static String convert2SlotMapMES(string slotMap)
        {
            string rtnSlotMap = string.Empty;
            if (slotMap == null)
            {
                return rtnSlotMap;
            }
            rtnSlotMap = slotMap.Replace(SCAppConstants.CSTSlotMap.Not_Exist, SCAppConstants.X_FLAG);
            rtnSlotMap = rtnSlotMap.Replace(SCAppConstants.CSTSlotMap.Exist, SCAppConstants.O_FLAG);
            return rtnSlotMap;
        }


        public static String FillSlotMap(int capacity)
        {

            string rtnSlotMap = string.Empty;
            for (int i = 0; i < capacity; i++)
            {
                rtnSlotMap += SCAppConstants.X_FLAG;
            }
            return rtnSlotMap;
        }

        public static void Fill(object LogicObject, DataRow Row)
        {
            Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
            foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                props.Add(p.Name, p);
            foreach (DataColumn col in Row.Table.Columns)
            {
                string name = col.ColumnName;
                if (Row[name] != DBNull.Value && props.ContainsKey(name))
                {
                    object item = Row[name];
                    PropertyInfo p = props[name];
                    if (p.PropertyType != col.DataType)
                        item = Convert.ChangeType(item, p.PropertyType);
                    p.SetValue(LogicObject, item, null);
                }
            }

        }

        /// <summary>
        /// 更改系統時間
        /// </summary>
        /// <param name="hostTime"></param>
        public static void updateSystemTime(DateTime hostTime)
        {
            DateTime nowDateTime = DateTime.Now;
            string setBeforeTime = nowDateTime.ToString(SCAppConstants.TimestampFormat_16);
            logger.Info("Before set system time:{0}", setBeforeTime);

            SystemTime st = new SystemTime();
            st.FromDateTime(hostTime);
            SystemTime.SetSystemTime(ref st);
            SystemTime.GetSystemTime(ref st);
            logger.Info("Before set system time:{0},After set system Time:{1}", setBeforeTime
                , st.ToDateTime().ToString(SCAppConstants.TimestampFormat_16));
            dateDiff(nowDateTime, hostTime);
        }

        private static void dateDiff(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                string dateDiff = string.Empty;
                TimeSpan ts1 = new TimeSpan(dateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(dateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = string.Format("Difference time: [{0}] day [{1}] hour [{2}] min [{3}] sec."
                                         , ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                logger.Info(dateDiff);
                if (ts.Days > 1)
                {
                    logger.Warn("Difference time days:[{0}]", ts.Days);
                }
                else if (ts.Hours > 1)
                {
                    logger.Warn("Difference time hours:[{0}]", ts.Hours);
                }
                else if (ts.Minutes > 3)
                {
                    logger.Warn("Difference time minutes[{0}]", ts.Minutes);
                }
                else if (ts.Seconds > 10)
                {
                    logger.Warn("Difference time seconds[{0}]", ts.Seconds);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Exception:", ex);
            }
        }

        public static string stringListToString(string tagS, List<String> sList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String str in sList)
            {
                sb.Append(str);
                if (tagS != null)
                {
                    sb.Append(tagS);
                }
            }
            return sb.ToString();
        }

        public static void secsActionRecordMsg(SCApplication scApp, Boolean isReceive, SXFY sxfy)
        {
            try
            {
                string sDateTime = DateTime.Now.ToString(SCAppConstants.DateTimeFormat_23);
                if (sxfy == null) { return; }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("[{0}][{1}][{2}][{3}][{4}][{5}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    (isReceive ? "R" : "S"), sxfy.StreamFunction, sxfy.SystemByte, sxfy.W_Bit, sxfy.SECSAgentName));
                string msg = string.Format("{0}{1}", sb.ToString(), sxfy.GetType().Name);
                scApp.getEQObjCacheManager().CommonInfo.SECS_Msg = msg;
                SECSMsgLogger.Info(msg);

                Task.Run(() =>
                {
                    setLogInfo_SECS(scApp, isReceive, sxfy, sDateTime);
                });
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Exception:");
            }
        }

        public static void secsActionRecordMsg(SCApplication scApp, Boolean isReceive, int systemByte, string secsAgentName,
            string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("[{0}][{1}][{2}][{3}][{4}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                (isReceive ? "R" : "S"), systemByte, secsAgentName, msg));
            sb.AppendLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + (isReceive ? "[R]" : "[S]") +
                "[" + msg + "]");
            scApp.getEQObjCacheManager().CommonInfo.SECS_Msg = sb.ToString();
            SECSMsgLogger.Info(sb.ToString());
        }

        public static void actionRecordMsg(SCApplication scApp, String funID, String eqID, String msg, String result)
        {
            StringBuilder sb = new StringBuilder();
            String dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sb.Append(String.Format("[{0}][{1}][{2}][{3}][{4}]", dateTime, funID, eqID, msg, result));
            scApp.getEQObjCacheManager().CommonInfo.Action_Msg = sb.ToString();
            SECSMsgLogger.Info(sb.ToString());
        }

        static com.mirle.ibg3k0.Utility.ul.Data.LogUtility logUtility = com.mirle.ibg3k0.Utility.ul.Data.LogUtility.getInstance();
        static object lockSetLogInfo_SECS = new object();
        public static void setLogInfo_SECS(SCApplication scApp, Boolean isReceive, SXFY sxfy)
        {
            try
            {
                if (isEmpty(sxfy.SECSAgentName)) return;

                com.mirle.ibg3k0.stc.Common.SECS.SECSAgent secsAgent = scApp.getBCFApplication().getSECSAgent(sxfy.SECSAgentName);
                string device_id = secsAgent == null ? string.Empty : secsAgent.DeviceID.ToString();

                string s = sxfy.getS().ToString();
                string f = sxfy.getF().ToString();

                LogTitle_SECS logTitleTemp = new LogTitle_SECS()
                {
                    EQ_ID = sxfy.SECSAgentName,
                    SendRecive = isReceive ? FUNCTION_TRANSDFERTYPE_RECEIVE_FROM_HOST
                                            : FUNCTION_TRANSDFERTYPE_SEND_TO_HOST,

                    Sx = s,
                    Fy = f,
                    DeviceID = device_id,
                    FunName = sxfy.StreamFunction,
                    Message = sxfy.toSECSString()
                };
                
                logUtility.addLogInfo(logTitleTemp);
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Exception:");
            }
        }
        
        public static void setLogInfo_SECS(SCApplication scApp, Boolean isReceive, SXFY sxfy, string sDateTime)
        {
            try
            {

                if (isEmpty(sxfy.SECSAgentName)) return;

                com.mirle.ibg3k0.stc.Common.SECS.SECSAgent secsAgent = scApp.getBCFApplication().getSECSAgent(sxfy.SECSAgentName);
                string device_id = secsAgent == null ? string.Empty : secsAgent.DeviceID.ToString();

                string s = sxfy.getS().ToString();
                string f = sxfy.getF().ToString();

                LogTitle_SECS logTitleTemp = new LogTitle_SECS()
                {
                    EQ_ID = sxfy.SECSAgentName,
                    SendRecive = isReceive ? FUNCTION_TRANSDFERTYPE_RECEIVE_FROM_HOST
                                            : FUNCTION_TRANSDFERTYPE_SEND_TO_HOST,

                    Sx = s,
                    Fy = f,
                    DeviceID = device_id,
                    FunName = sxfy.StreamFunctionName ?? string.Empty,
                    Message = sxfy.toSECSString(),
                    LogType = SCAppConstants.LogType.SECS_ForHost.ToString()
                };
                logTitleTemp.Time = sDateTime;
                logUtility.addLogInfo(logTitleTemp);
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Exception:");
            }
        }

        public static void PLCActionRecordMsg(SCApplication scApp, string Node_ID, ref List<ValueWrite> vWriteList)
        {
            if (scApp == null)
                logger.Warn("scApp is null");
            if (Node_ID == null)
                logger.Warn("Node_ID is null");
            if (vWriteList == null)
                logger.Warn("vWriteList is null");

            if (scApp == null || Node_ID == null || vWriteList == null)
                return;

            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = string.Format("*************{0}*************", DateTime.Now.ToString());
            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = BCFUtility.writeEquipmentLog(Node_ID, vWriteList);
            vWriteList.Clear();
        }
        public static void PLCActionRecordMsg(SCApplication scApp, string Node_ID, ref List<ValueRead> vEventList)
        {
            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = string.Format("*************{0}*************", DateTime.Now.ToString());
            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = BCFUtility.writeEquipmentLog(Node_ID, vEventList);
            vEventList.Clear();
        }
        public static void PLCActionRecordMsg(SCApplication scApp, string Node_ID, ref List<ValueRead> vEventList, ref List<ValueWrite> vWriteList)
        {
            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = string.Format("*************{0}*************", DateTime.Now.ToString());
            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = BCFUtility.writeEquipmentLog(Node_ID, vEventList);
            scApp.getEQObjCacheManager().CommonInfo.PLC_Msg = BCFUtility.writeEquipmentLog(Node_ID, vWriteList);
            vEventList.Clear();
            vWriteList.Clear();
        }
        public static void RecordLog(Logger log, com.mirle.ibg3k0.sc.Data.PLC_Functions.PLC_FunBase fun, int send_received, SCAppConstants.LogType log_type = SCAppConstants.LogType.PLC_ForEQ)
        {
            string msg = fun.ToString();
            string type = "";
            if (isMatche(send_received, 1))
                type = FUNCTION_TRANSDFERTYPE_SEND;
            else
                type = FUNCTION_TRANSDFERTYPE_RECEIVE;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.Append("-EQ ID :").AppendFormat("[{0}]", fun.EQ_ID).AppendLine();
            builder.Append("-Fun ID:").AppendFormat("[{0}]", fun.FunctionName).AppendLine();
            builder.Append(msg);
            log.Info(builder.ToString());
            SCUtility.setLogInfo_PLCForEQ(fun.EQ_ID, "", fun.FunctionName, msg, log_type);
        }

        //不記錄到分開的EQ LOG
        public static void RecordLog(com.mirle.ibg3k0.sc.Data.PLC_Functions.PLC_FunBase fun, int send_received, SCAppConstants.LogType log_type = SCAppConstants.LogType.PLC_ForEQ)
        {
            string msg = fun.ToString();
            string type = "";
            if (isMatche(send_received, 1))
                type = FUNCTION_TRANSDFERTYPE_SEND;
            else
                type = FUNCTION_TRANSDFERTYPE_RECEIVE;

            SCUtility.setLogInfo_PLCForEQ(fun.EQ_ID, type, fun.FunctionName, msg, log_type);
        }
        public static void setLogInfo_PLCForEQ(string eq_id, string send_receive, string function_name, string msg, SCAppConstants.LogType log_type)
        {
            if (eq_id.Contains(CHAR_UNDERLINE))
            {
                eq_id = eq_id.Split(CHAR_UNDERLINE)[0];
            }

            LogTitle_PLC logTitleTemp = new LogTitle_PLC()
            {
                EQ_ID = eq_id,
                LogType = log_type.ToString(),
                SendRecive = send_receive,
                FunName = function_name,
                Message = msg
            };

            Task.Run(() => logUtility.addLogInfo(logTitleTemp));
        }

        public static int convertToInt(int int1, int iStartIndex1, int iEndIndex1, int int2, int iStartIndex2, int iEndIndex2)
        {
            int shiftInt2 = int2 * (int)Math.Pow(2, 12);
            UInt16[] iArray1 = new UInt16[1] { (UInt16)int1 };
            UInt16[] iArray2 = new UInt16[1] { (UInt16)shiftInt2 };
            Boolean[] bArray1 = convertToBooleans(iArray1, 0, 0);
            Boolean[] bArray2 = convertToBooleans(iArray2, 0, 0);
            BitArray ResultArray = new BitArray(16);

            int boolCount = 0;
            foreach (Boolean b in bArray1)
            {
                ResultArray[boolCount] = bArray1[boolCount] | bArray2[boolCount];
                boolCount++;
            }

            int[] intAry = new int[1];
            ResultArray.CopyTo(intAry, 0);
            return intAry[0];
        }

        public static Boolean[] convertToBooleans(UInt16[] dataTemp, int iStartIndex, int iEndIndex)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, iStartIndex, iEndIndex);
            return (Boolean[])BCFUtility.convertInt2TextByType(16, Type.GetType("System.Boolean[]"), rangeData);
        }

        public static void ConvertPLCMsg(string functionName, string Node_ID, StringBuilder convertValue)
        {
            string sDateTime = DateTime.Now.ToString(SCAppConstants.DateTimeFormat_23);
            string sconvertValue = convertValue.ToString();
            
            Task.Run(() => { ConvertPLCMsgAsync(functionName, Node_ID, sconvertValue, sDateTime); });
            convertValue.Clear();
        }
        
        public static void ConvertPLCMsgAsync(string functionName, string Node_ID, string convertValue, string sDateTime) 
        {
            //1.記錄到Total的Log
            convertPLClogger.Info(Environment.NewLine + "Trigger T:[{0}]{1}******************EQPT:{2}******************{3}{4}{5}{6}"
                                                    , sDateTime
                                                    , Environment.NewLine
                                                    , Node_ID
                                                    , Environment.NewLine
                                                    , functionName
                                                    , Environment.NewLine
                                                    , convertValue);
            //2.記錄到個別EQ的Log
            recodeConvertPLCInfoForEq(functionName, Node_ID, convertValue, sDateTime);
            //3.呈現到畫面上的Log
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, convertValue, sDateTime);
        }

        private static void recodeConvertPLCInfoForEq(string functionName, string Node_ID, string convertValue, string sDateTime)
        {
            switch (Node_ID.ToString())
            {
                case "CHANG1_NODE":
                    convertPLClogger_CHANG1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "CONVE1_NODE":
                    convertPLClogger_CONVE1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "UV_NODE":
                    convertPLClogger_UV.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "CLEAN_NODE":
                    convertPLClogger_CLEAN.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "IRCP_NODE":
                    convertPLClogger_IRCP.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "COATE1_NODE":
                    convertPLClogger_COATE1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "COATE2_NODE":
                    convertPLClogger_COATE2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "HPCP1_NODE":
                    convertPLClogger_HPCP1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "HPCP2_NODE":
                    convertPLClogger_HPCP2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "EXPOS1_NODE":
                    convertPLClogger_EXPOS1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "EXPOS2_NODE":
                    convertPLClogger_EXPOS2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "HPCV_NODE":
                    convertPLClogger_HPCV.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "CONVE2_NODE":
                    convertPLClogger_CONVE2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "DEVEL1_NODE":
                    convertPLClogger_DEVEL1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "DEVEL2_NODE":
                    convertPLClogger_DEVEL2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "CONVE3_NODE":
                    convertPLClogger_CONVE3.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "CHANG2_NODE":
                    convertPLClogger_CHANG2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "OVEN1_NODE":
                    convertPLClogger_OVEN1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "MACRO1_NODE":
                    convertPLClogger_MACRO1.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "CONVE4_NODE":
                    convertPLClogger_CONVE4.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "AOI_NODE":
                    convertPLClogger_AOI.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "OVEN2_NODE":
                    convertPLClogger_OVEN2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue);
                    break;
                case "MACRO2_NODE":
                    convertPLClogger_MACRO2.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}"
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
                case "CONVE5_NODE":
                    convertPLClogger_CONVE5.Info(Environment.NewLine +
                       "Trigger T:[{0}]{1}******************{2}******************{3}{4}" 
                        , sDateTime, Environment.NewLine, functionName, Environment.NewLine, convertValue); 
                    break;
            }
        }

        protected static Logger convertPLClogger = LogManager.GetLogger("ConvertPLCLog");
        public static void ConvertPLCMsg(string functionName, string Node_ID, Dictionary<string, string> convertValue)
        {
            try
            {
                StringBuilder ConvertPLCMsgSB = new StringBuilder();

                foreach (KeyValuePair<string, string> item in convertValue)
                {
                    ConvertPLCMsgSB.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
                }
                convertPLClogger.Info(Environment.NewLine + "*************EQPT:{0}*************{1}{2}{3}{4}", Node_ID, Environment.NewLine, functionName, Environment.NewLine, ConvertPLCMsgSB.ToString());

                switch (Node_ID.ToString())
                {
                    case "CHANG1_NODE":
                        ConvertPLCMsg_CHANG1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CONVE1_NODE":
                        ConvertPLCMsg_CONVE1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "UV_NODE":
                        ConvertPLCMsg_UV(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CLEAN_NODE":
                        ConvertPLCMsg_CLEAN(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "IRCP_NODE":
                        ConvertPLCMsg_IRCP(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "COATE1_NODE":
                        ConvertPLCMsg_COATE1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "COATE2_NODE":
                        ConvertPLCMsg_COATE2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "HPCP1_NODE":
                        ConvertPLCMsg_HPCP1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "HPCP2_NODE":
                        ConvertPLCMsg_HPCP2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "EXPOS1_NODE":
                        ConvertPLCMsg_EXPOS1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "EXPOS2_NODE":
                        ConvertPLCMsg_EXPOS2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "HPCV_NODE":
                        ConvertPLCMsg_HPCV(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CONVE2_NODE":
                        ConvertPLCMsg_CONVE2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "DEVEL1_NODE":
                        ConvertPLCMsg_DEVEL1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "DEVEL2_NODE":
                        ConvertPLCMsg_DEVEL2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CONVE3_NODE":
                        ConvertPLCMsg_CONVE3(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CHANG2_NODE":
                        ConvertPLCMsg_CHANG2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "OVEN1_NODE":
                        ConvertPLCMsg_OVEN1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "MACRO1_NODE":
                        ConvertPLCMsg_MACRO1(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CONVE4_NODE":
                        ConvertPLCMsg_CONVE4(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "AOI_NODE":
                        ConvertPLCMsg_AOI(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "OVEN2_NODE":
                        ConvertPLCMsg_OVEN2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "MACRO2_NODE":
                        ConvertPLCMsg_MACRO2(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;
                    case "CONVE5_NODE":
                        ConvertPLCMsg_CONVE5(functionName, Node_ID, convertValue, ConvertPLCMsgSB);
                        break;

                }
                ConvertPLCMsgSB = null; 
            }
            catch (Exception ex)
            {
                logger_MapActioLog.Error("SCUtility has Error,  method：ConvertPLCMsg 、Function name:{0}、Exception Description:{1}",
                    functionName, ex.ToString());
            }
        }
        protected static Logger convertPLClogger_CHANG1 = LogManager.GetLogger("ConvertPLCLog_CHANG1");
        public static void ConvertPLCMsg_CHANG1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CHANG1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CONVE1 = LogManager.GetLogger("ConvertPLCLog_CONVE1");
        public static void ConvertPLCMsg_CONVE1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CONVE1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }
        protected static Logger convertPLClogger_UV = LogManager.GetLogger("ConvertPLCLog_UV");
        public static void ConvertPLCMsg_UV(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_UV.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CLEAN = LogManager.GetLogger("ConvertPLCLog_CLEAN");
        public static void ConvertPLCMsg_CLEAN(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CLEAN.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_IRCP = LogManager.GetLogger("ConvertPLCLog_IRCP");
        public static void ConvertPLCMsg_IRCP(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_IRCP.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_COATE1 = LogManager.GetLogger("ConvertPLCLog_COATE1");
        public static void ConvertPLCMsg_COATE1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_COATE1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_COATE2 = LogManager.GetLogger("ConvertPLCLog_COATE2");
        public static void ConvertPLCMsg_COATE2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_COATE2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_HPCP1 = LogManager.GetLogger("ConvertPLCLog_HPCP1");
        public static void ConvertPLCMsg_HPCP1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_HPCP1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_HPCP2 = LogManager.GetLogger("ConvertPLCLog_HPCP2");
        public static void ConvertPLCMsg_HPCP2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_HPCP2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_EXPOS1 = LogManager.GetLogger("ConvertPLCLog_EXPOS1");
        public static void ConvertPLCMsg_EXPOS1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_EXPOS1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_EXPOS2 = LogManager.GetLogger("ConvertPLCLog_EXPOS2");
        public static void ConvertPLCMsg_EXPOS2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_EXPOS2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_HPCV = LogManager.GetLogger("ConvertPLCLog_HPCV");
        public static void ConvertPLCMsg_HPCV(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_HPCV.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CONVE2 = LogManager.GetLogger("ConvertPLCLog_CONVE2");
        public static void ConvertPLCMsg_CONVE2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CONVE2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_DEVEL1 = LogManager.GetLogger("ConvertPLCLog_DEVEL1");
        public static void ConvertPLCMsg_DEVEL1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_DEVEL1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_DEVEL2 = LogManager.GetLogger("ConvertPLCLog_DEVEL2");
        public static void ConvertPLCMsg_DEVEL2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_DEVEL2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CONVE3 = LogManager.GetLogger("ConvertPLCLog_CONVE3");
        public static void ConvertPLCMsg_CONVE3(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CONVE3.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CHANG2 = LogManager.GetLogger("ConvertPLCLog_CHANG2");
        public static void ConvertPLCMsg_CHANG2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CHANG2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_OVEN1 = LogManager.GetLogger("ConvertPLCLog_OVEN1");
        public static void ConvertPLCMsg_OVEN1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_OVEN1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_MACRO1 = LogManager.GetLogger("ConvertPLCLog_MACRO1");
        public static void ConvertPLCMsg_MACRO1(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_MACRO1.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CONVE4 = LogManager.GetLogger("ConvertPLCLog_CONVE4");
        public static void ConvertPLCMsg_CONVE4(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CONVE4.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_AOI = LogManager.GetLogger("ConvertPLCLog_AOI");
        public static void ConvertPLCMsg_AOI(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_AOI.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_OVEN2 = LogManager.GetLogger("ConvertPLCLog_OVEN2");
        public static void ConvertPLCMsg_OVEN2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_OVEN2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_MACRO2 = LogManager.GetLogger("ConvertPLCLog_MACRO2");
        public static void ConvertPLCMsg_MACRO2(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_MACRO2.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        protected static Logger convertPLClogger_CONVE5 = LogManager.GetLogger("ConvertPLCLog_CONVE5");
        public static void ConvertPLCMsg_CONVE5(string functionName, string Node_ID, Dictionary<string, string> convertValue, StringBuilder sb)
        {
            sb.Clear();
            foreach (KeyValuePair<string, string> item in convertValue)
            {
                sb.AppendFormat("      {0} = {1}{2}", item.Key, item.Value, Environment.NewLine);
            }
            convertPLClogger_CONVE5.Info(Environment.NewLine + "*****{0}*****{1}{2}", functionName, Environment.NewLine, sb.ToString());
            setLogInfo_PLCForEQ(Node_ID, selectPLCTransferType(functionName), functionName, sb.ToString());
            convertValue.Clear();
        }

        const char CHAR_UNDERLINE = '_';
        public static void setLogInfo_PLCForEQ(string eq_id, string send_receive, string function_name, string msg)
        {
            if (eq_id.Contains(CHAR_UNDERLINE))
            {
                eq_id = eq_id.Split(CHAR_UNDERLINE)[0];
            }

            LogTitle_PLC logTitleTemp = new LogTitle_PLC()
            {
                EQ_ID = eq_id,
                SendRecive = send_receive,
                FunName = function_name,
                Message = msg
            };

            //Task.Run(() => SCApplication.getInstance().LineService.PublishEqMsgInfo(logTitleTemp));
            Task.Run(() => logUtility.addLogInfo(logTitleTemp));
        }

        public static void setLogInfo_PLCForEQ(string eq_id, string send_receive, string function_name, string msg, string sDateTime)
        {
            if (eq_id.Contains(CHAR_UNDERLINE))
            {
                eq_id = eq_id.Split(CHAR_UNDERLINE)[0];
            }

            LogTitle_PLC logTitleTemp = new LogTitle_PLC()
            {
                EQ_ID = eq_id,
                SendRecive = send_receive,
                FunName = function_name,
                Message = msg,
                LogType = SCAppConstants.LogType.PLC_ForEQ.ToString()
            };
            logTitleTemp.Time = sDateTime;
            //Task.Run(() => SCApplication.getInstance().LineService.PublishEqMsgInfo(logTitleTemp));
            Task.Run(() => logUtility.addLogInfo(logTitleTemp));
        }

        #region MessageQueue
        protected static Logger convertMQlogger = LogManager.GetLogger("MessageQueue");
        public static void ConvertMQMsg(string send_receive, string functionName, string convertValue)
        {
            string sDateTime = DateTime.Now.ToString(SCAppConstants.DateTimeFormat_23);
            string sconvertValue = convertValue;
            
            Task.Run(() => { ConvertMQMsgAsync(send_receive, functionName, sconvertValue, sDateTime); });
        }

        public static void ConvertMQMsgAsync(string send_receive, string functionName, string convertValue, string sDateTime)
        {
            //1.記錄到Total的Log
            convertMQlogger.Info(Environment.NewLine + "Trigger T:[{0}]{1}{2}{3}{4}"
                                                    , sDateTime
                                                    , Environment.NewLine
                                                    , functionName
                                                    , Environment.NewLine
                                                    , convertValue);
            //2.呈現到畫面上的Log
            setLogInfo_MQForHost(send_receive, functionName, convertValue, sDateTime); 
        }

        public static void setLogInfo_MQForHost(string send_receive, string trx_name, string msg, string sDateTime) 
        {

            LogTitle_MQ logTitleTemp = new LogTitle_MQ()
            {
                SendRecive = send_receive,
                TrxName = trx_name,
                Message = msg,
                LogType = SCAppConstants.LogType.MQ_ForHost.ToString()
            };
            logTitleTemp.Time = sDateTime; 
            //Task.Run(() => SCApplication.getInstance().LineService.PublishHostMsgInfo(logTitleTemp));
            Task.Run(() =>
            {
                logUtility.addLogInfo(logTitleTemp);
            });
        }
        #endregion MessageQueue

        //Transfer Type的feature
        public const String FUNCTION_FEATURE_EC = "HH";
        public const String FUNCTION_FEATURE_EC2 = "HP";
        public const String FUNCTION_FEATURE_EC3 = "HR";
        public const String FUNCTION_FEATURE_EC4 = "HD";
        public const String FUNCTION_FEATURE_EC5 = "HW";
        public const String FUNCTION_FEATURE_EC6 = "HS";
        public const String FUNCTION_FEATURE_EC7 = "HC";
        //Transfer Type
        public const String FUNCTION_TRANSDFERTYPE_SEND_TO_HOST = "EAP  =>  MCS"; 
        public const String FUNCTION_TRANSDFERTYPE_RECEIVE_FROM_HOST = "EAP  <=  MCS";
        public const String FUNCTION_TRANSDFERTYPE_SEND = "EAP  =>  EQ"; 
        public const String FUNCTION_TRANSDFERTYPE_RECEIVE = "EAP  <=  EQ";
        private static string selectPLCTransferType(string function_name)
        {
            string type = string.Empty;
            if (function_name.Contains(FUNCTION_FEATURE_EC) || function_name.Contains(FUNCTION_FEATURE_EC2) ||
                function_name.Contains(FUNCTION_FEATURE_EC3) || function_name.Contains(FUNCTION_FEATURE_EC4) ||
                function_name.Contains(FUNCTION_FEATURE_EC5) || function_name.Contains(FUNCTION_FEATURE_EC6) ||
                function_name.Contains(FUNCTION_FEATURE_EC7))
            {
                type = FUNCTION_TRANSDFERTYPE_SEND;
            }
            else
            {
                type = FUNCTION_TRANSDFERTYPE_RECEIVE;
            }
            return type;
        }


        /// <summary>
        /// 在Type1 機台 執行FUN時發生錯誤後，顯示到畫面上
        /// </summary>
        /// <param name="errorFun"></param>
        public static void onFunErrorLog(string errorFun)
        {
            
        }

        public static String getPropertiesLength(object obj)
        {
            StringBuilder sb = new StringBuilder();
            var type = obj.GetType();

            // Get the PropertyInfo object:
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {

                if (property.PropertyType == typeof(string))
                {
                    String s;
                    if (property.GetValue(obj) != null)
                        s = property.GetValue(obj).ToString();
                    else
                        s = "";
                    sb.AppendFormat("{0}.length = '{1}'", property.Name, s.Length);
                    sb.AppendFormat("    {0}.value = '{1}'", property.Name, property.GetValue(obj));
                    sb.AppendLine();
                }
                else
                {
                    sb.AppendFormat("{0}.value = '{1}'", property.Name, property.GetValue(obj));
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        public static void TrimAllParameter(object obj)
        {
            var type = obj.GetType();
            // Get the PropertyInfo object:
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    if (property.PropertyType == typeof(string) && property.CanWrite)
                    {
                        if (property.GetValue(obj) != null)
                        {
                            String temp = property.GetValue(obj).ToString().Trim();
                            property.SetValue(obj, temp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception");
                }
            }
        }

        public static string ShowCallerInfo(StackTrace st, string remark)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                if (st == null)
                {
                    st = new StackTrace(true);
                }
                sb.AppendLine(new string('=', 80));
                sb.AppendLine(string.Format("Caller Remark: {0}", remark));
                StackFrame sf = st.GetFrame(1);
                MethodBase mb = sf.GetMethod();
                sb.AppendLine(string.Format("Caller Module: {0}", mb.Module.FullyQualifiedName));
                sb.AppendLine(string.Format("Caller Class & Method: {0}.{1}()", mb.ReflectedType.FullName, mb.Name));
                sb.AppendLine(string.Format("File Info: Line {0} in {1}", sf.GetFileLineNumber(), sf.GetFileName()));
                sb.AppendLine(new string('=', 80));
            }
            catch { }
            return sb.ToString();
        }

        public static void PrintPortCommandInfo(Port port)
        {
            try
            {
                string cmdStat = SCApplication.getMessageString("Port_CMD_Status_" + port.PortCommandStatus);
                string portStat = SCApplication.getMessageString("Port_Status_" + port.Port_Stat);
                //A0.01 Cassette cst = port.CassetteLoader.CassetteItem;
                string cstID = string.Empty;
                //A0.01 Start
                //if (cst != null)
                //{
                //    if (!BCFUtility.isEmpty(cst.CST_ID))
                //    {
                //        cstID = cst.CST_ID;
                //    }
                //}
                //A0.01 End
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(String.Format("Port {0} [Command Status:{1}] [Port Status:{2}][CST ID:{3}]",
                    port.Port_ID, cmdStat, portStat, cstID));
                CSTInfoLogger.Info(sb.ToString());
                sb.Clear();
            }
            catch (Exception ex)
            {
                CSTInfoLogger.Warn("SCUtility.PrintPortCommandInfo Occur Exception[{0}]", ex);
            }
        }

        public static void PrintCSTInfo(CSTDataInfo cstInfo)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();
                if (cstInfo == null) { return; }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine(string.Format("{0}Port ID: {1}", new string(' ', 5), cstInfo.Port_ID));
                sb.AppendLine(string.Format("{0}Port Type: {1}", new string(' ', 5), cstInfo.Port_Type));
                sb.AppendLine(string.Format("{0}Port Use Type: {1}", new string(' ', 5), cstInfo.Port_Use_Type));
                sb.AppendLine(string.Format("{0}CST ID: {1}", new string(' ', 5), cstInfo.CST_ID));

                if (cstInfo.GlassDataList != null)
                {
                    foreach (CSTDataInfo.GlassDataInfo glsInfo in cstInfo.GlassDataList)
                    {
                        sb.AppendLine(string.Format("{0}[Slot No: {1}][Glass ID: {2}]", new string(' ', 10), glsInfo.Slot_NO, glsInfo.Sheet_ID));
                    }
                }
                CSTInfoLogger.Info(sb.ToString());
                sb.Clear();
            }
            catch (Exception ex)
            {
                CSTInfoLogger.Warn("SCUtility.PrintCSTInfo Occur Exception[{0}]", ex);
            }
        }

        //public static void PrintTrayInfo(TrayDataInfo cstInfo)
        //{
        //    try
        //    {
        //        SCApplication scApp = SCApplication.getInstance();
        //        if (cstInfo == null) { return; }
        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendLine();
        //        sb.AppendLine(string.Format("{0}Port ID: {1}", new string(' ', 5), cstInfo.Port_ID));
        //        sb.AppendLine(string.Format("{0}Port Type: {1}", new string(' ', 5), cstInfo.Port_Type));
        //        sb.AppendLine(string.Format("{0}Port Use Type: {1}", new string(' ', 5), cstInfo.Port_Use_Type));
        //        sb.AppendLine(string.Format("{0}CST ID: {1}", new string(' ', 5), cstInfo.CST_ID));
        //        sb.AppendLine(string.Format("{0}CST Type: {1}", new string(' ', 5), cstInfo.CST_Type));
        //        sb.AppendLine(string.Format("{0}Quantity: {1}", new string(' ', 5), cstInfo.Quantity));
        //        sb.AppendLine(string.Format("{0}ES Flag: {1}", new string(' ', 5), cstInfo.ES_Flag));
        //        sb.AppendLine(string.Format("{0}Slot Select: {1}", new string(' ', 5), cstInfo.Slot_Sel));
        //        sb.AppendLine(string.Format("{0}Lot Judge: {1}", new string(' ', 5), cstInfo.Lot_Judge));
        //        sb.AppendLine(string.Format("{0}PPID: {1}", new string(' ', 5), cstInfo.PPID));
        //        sb.AppendLine(string.Format("{0}PPID Version: {1}", new string(' ', 5), cstInfo.PPID_Version));

        //        IndPPID indppid = scApp.LineBLL.getIndPPID(cstInfo.PPID);
        //        if (indppid != null)
        //        {
        //            int eqptCnt = scApp.getEQObjCacheManager().getProcessEquipmentCnt();
        //            PropertyInfo[] props = typeof(IndPPID).GetProperties();

        //            for (int i = 1; i <= eqptCnt; i++)
        //            {
        //                string recipe = (string)props.Where(o => o.Name == string.Format("St{0}_Recipe", i)).SingleOrDefault().GetValue(indppid);
        //                string eq = (string)props.Where(o => o.Name == string.Format("St{0}_Eq", i)).SingleOrDefault().GetValue(indppid);

        //                sb.AppendLine(string.Format("{0}[Station{1} EQ(Recipe ID): {2}({3})]"
        //                , new string(' ', 5), i, eq, recipe));
        //            }
        //        }

        //        sb.AppendLine(string.Format("{0}Material TYpe: {1}", new string(' ', 5), cstInfo.Mtrl_Type));

        //        if (cstInfo.GlassDataList != null)
        //        {
        //            foreach (TrayDataInfo.GlassDataInfo glsInfo in cstInfo.GlassDataList)
        //            {
        //                sb.AppendLine(string.Format("{0}[Slot No: {1}][Glass ID: {2}][Lot ID: {3}]", new string(' ', 10), glsInfo.Slot_NO, glsInfo.Glass_ID, glsInfo.Lot_ID));
        //                sb.AppendLine(string.Format("{0}[Print Flag: {1}][Sample Flag: {2}]", new string(' ', 10), glsInfo.Print_Flag, glsInfo.Sample_Flag));
        //                sb.AppendLine(string.Format("{0}[Oper ID: {1}][Rework Count: {2}]", new string(' ', 10), glsInfo.Oper_ID, glsInfo.Rework_Count));
        //                sb.AppendLine(string.Format("{0}[Prod ID: {1}][Prod Type: {2}]", new string(' ', 10), glsInfo.Prod_ID, glsInfo.Prod_Type));
        //                sb.AppendLine(string.Format("{0}[Glass Judge: {1}][COP ID: {2}]", new string(' ', 10), glsInfo.Glass_Judge, glsInfo.COP_ID));
        //                sb.AppendLine(string.Format("{0}[Panel Judge: {1}]", new string(' ', 10), glsInfo.Panel_Judge));
        //                sb.AppendLine(string.Format("{0}[Panel Grade: {1}]", new string(' ', 10), glsInfo.Panel_Grade));
        //                sb.AppendLine(string.Format("{0}[Batch ID: {1}][Batch Mix Flag: {2}]", new string(' ', 10), glsInfo.Batch_ID, glsInfo.Batch_Mix_Flag));

        //                sb.AppendLine(string.Format("{0}[Unit]", new string(' ', 10)));
        //                foreach (string unit in glsInfo.UnitList)
        //                {
        //                    sb.AppendLine(string.Format("{0}[Unit ID: {1}]", new string(' ', 12), unit));
        //                }

        //                sb.AppendLine(string.Format("{0}[Sample Unit]", new string(' ', 10)));
        //                foreach (string unit in glsInfo.SmplList)
        //                {
        //                    sb.AppendLine(string.Format("{0}[Sample Unit ID: {1}]", new string(' ', 12), unit));
        //                }
        //            }
        //        }
        //        CSTInfoLogger.Info(sb.ToString());
        //        sb.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        CSTInfoLogger.Warn("SCUtility.PrintCSTInfo Occur Exception[{0}]", ex);
        //    }
        //}

        //public static void PrintSortJobInfo(List<SorterJob> lstSj)
        //{
        //    try
        //    {
        //        SCApplication scApp = SCApplication.getInstance();
        //        StringBuilder sb = new StringBuilder();
        //        HashSet<string> cstSet = new HashSet<string>();

        //        sb.AppendLine();
        //        sb.AppendLine("Sort Job Info:");
        //        foreach (SorterJob sj in lstSj)
        //        {
        //            if (sj != null)
        //            {
        //                sb.AppendLine(string.Format("{0}Sht ID: {1}", new string(' ', 5), sj.Sht_ID));
        //                sb.AppendLine(string.Format("{0}[Sort Job ID: {1}][Lot ID: {2}][Port ID: {3}]"
        //                                            , new string(' ', 7), sj.Job_ID, sj.Lot_ID, sj.Port_ID));
        //                sb.AppendLine(string.Format("{0}[Cst ID: {1}][Sht ID: {2}][From Slot No: {3}]"
        //                                            , new string(' ', 7), sj.Cst_ID, sj.Sht_ID, sj.From_Slot_No));
        //                sb.AppendLine(string.Format("{0}[Target Port ID: {1}][Target Cst ID: {2}][Target Slot No: {3}]"
        //                                            , new string(' ', 7), sj.Target_Port_ID, sj.Target_Cst_ID, sj.Target_Slot_No));
        //                sb.AppendLine(string.Format("{0}[Sort Turn Flag: {1}][Sort Scrap Flag: {2}]"
        //                                            , new string(' ', 7), sj.Sort_Turn_Flag, sj.Sort_Scrap_Flag));
        //            }

        //            if (BCFUtility.isEmpty(sj.Cst_ID))
        //                continue;
        //            cstSet.Add(sj.Cst_ID);
        //        }
        //        CSTInfoLogger.Info(sb.ToString());
        //        sb.Clear();
        //        sb.AppendLine();
        //        sb.AppendLine("Sheet Info:");
        //        List<string> lstCstID = cstSet.ToList();
        //        foreach (string s in lstCstID)
        //        {
        //            List<VSheet> lstVs = scApp.SheetBLL.loadViewSheetInSourceCST(s);
        //            foreach (VSheet vs in lstVs)
        //            {
        //                sb.AppendLine(string.Format("{0}Sht ID: {1}", new string(' ', 5), vs.Sht_ID));
        //                sb.AppendLine(string.Format("{0}[Job No: {1}][Lot ID: {2}][Sht Stat: {3}]"
        //                                            , new string(' ', 7), vs.Job_NO, vs.Lot_ID, vs.Sht_Stat));
        //                sb.AppendLine(string.Format("{0}[Source CST ID: {1}][Source Slot NO: {2}][Source Port NO: {3}]"
        //                                            , new string(' ', 7), vs.Source_CST_ID, vs.Source_Slot_NO, vs.Source_Port_NO));
        //                sb.AppendLine(string.Format("{0}[Target CST ID: {1}][Target Slot NO: {2}][Target Port NO: {3}]"
        //                                            , new string(' ', 7), vs.Target_CST_ID, vs.Target_Slot_NO, vs.Target_Port_NO));
        //                sb.AppendLine(string.Format("{0}[Turn Flag: {1}][Scrap Flag: {2}]"
        //                                            , new string(' ', 7), vs.Turn_Flag, vs.Scrap_Flag));
        //            }
        //        }
        //        CSTInfoLogger.Info(sb.ToString());
        //        sb.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        CSTInfoLogger.Warn("SCUtility.PrintCSTInfo Occur Exception[{0}]", ex);
        //    }
        //}

        public static void PrintOperationLog(OperationHis opHis)
        {
            try
            {
                if (opHis == null) { return; }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendLine(string.Format("{0}Time: {1}", new string(' ', 5), opHis.T_Stamp));
                sb.AppendLine(string.Format("{0}User: {1}", new string(' ', 5), opHis.User_ID));
                sb.AppendLine(string.Format("{0}UI Name: {1}", new string(' ', 5), opHis.Form_Name));
                sb.AppendLine(string.Format("{0}Action: ", new string(' ', 5)));
                sb.AppendLine(string.Format("{0}         {1}", new string(' ', 5), opHis.Action));
                OperationLogger.Info(sb.ToString());
                sb.Clear();
            }
            catch (Exception ex)
            {
                OperationLogger.Warn("SCUtility.PrintOperationLog Occur Exception[{0}]", ex);
            }
        }


        /// <summary>
        /// 根據傳入的IntAry轉出有號數的Int
        /// </summary>
        /// <param name="expandBitCnt"></param>
        /// <param name="targetType"></param>
        /// <param name="intAry"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static double convertInt2TextByType(int expandBitCnt, Type targetType, int[] intAry, double multiplier)
        {
            double doubleVal = 0;
            string bitsVal = string.Empty;
            bool sign = false;
            string tureValue = string.Empty;

            if (targetType.Equals(Type.GetType("System.Int16")))
            {
                bitsVal = Convert.ToString(intAry[0], 2).PadLeft(16, '0');

                sign = bitsVal[0] == '1';
                tureValue = bitsVal.Substring(1);
                Int16 val = Convert.ToInt16(tureValue, 2);
                if (sign)
                    doubleVal = -val * multiplier;
                else
                    doubleVal = val * multiplier;
            }
            else if (targetType.Equals(Type.GetType("System.Int32")))
            {
                bitsVal = Convert.ToString(intAry[0], 2).PadLeft(16, '0');
                if (intAry.Length > 1)
                {
                    bitsVal = string.Format("{0}{1}",
                        Convert.ToString(intAry[1], 2).PadLeft(16, '0'), bitsVal);
                }

                sign = bitsVal[0] == '1';
                tureValue = bitsVal.Substring(1);
                Int32 val = Convert.ToInt32(tureValue, 2);
                if (sign)
                    doubleVal = -val * multiplier;
                else
                    doubleVal = val * multiplier;

            }
            else if (targetType.Equals(Type.GetType("System.Int64")))
            {
                bitsVal = Convert.ToString(intAry[0], 2).PadLeft(16, '0');
                if (intAry.Length > 1)
                {
                    bitsVal = string.Format("{0}{1}",
                        Convert.ToString(intAry[1], 2).PadLeft(16, '0'), bitsVal);
                }
                if (intAry.Length > 2)
                {
                    bitsVal = string.Format("{0}{1}",
                        Convert.ToString(intAry[2], 2).PadLeft(16, '0'), bitsVal);
                }
                if (intAry.Length > 3)
                {
                    bitsVal = string.Format("{0}{1}",
                        Convert.ToString(intAry[3], 2).PadLeft(16, '0'), bitsVal);
                }

                sign = bitsVal[0] == '1';
                tureValue = bitsVal.Substring(1);
                Int64 val = Convert.ToInt64(tureValue, 2);
                if (sign)
                    doubleVal = -val * multiplier;
                else
                    doubleVal = val * multiplier;

            }

            return doubleVal;
        }

        /// <summary>
        /// 根據傳入的ArrayUint16，傳換成DateTime。(For ER12、ER13使用) //A0.05
        /// </summary>
        /// <param name="arrayLastChangeTime"></param>
        /// <returns></returns>
        public static string convertArrayUInt16ToDateTime(UInt16[] arrayLastChangeTime)
        {
            string dateTime = string.Empty;

            dateTime = new string(convertToBCD(arrayLastChangeTime, 0, 2));

            return dateTime;
        }

        /**
        * 取得陣列範圍轉換成BCD
        **/
        public static char[] convertToBCD(UInt16[] dataTemp, int iStartIndex, int iEndIndex)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, iStartIndex, iEndIndex);
            int icount = iEndIndex - iStartIndex + 1;
            int iarrayCount = 0;
            char[] returnData = new char[icount * 4];//由於一個Word可由4個BCD碼組成，固可令它*4
            for (int j = 0; j < icount; j++)
            {
                char[] cTemp = rangeData[j].ToString("X4").ToCharArray(0, 4);
                for (int i = 0; i < 4; i++)
                {
                    returnData[iarrayCount] = cTemp[i];
                    iarrayCount++;
                }
            }
            return returnData;
        }

        /**
        * 取得BCD範圍轉換成String
        **/
        public static string convertToBCD(UInt16 dataTemp)
        {
            char[] data = ValueHandlerBase.convertToBCD(dataTemp);
            StringBuilder sb = new StringBuilder();
            int BCDcount = 0;

            foreach (char c in data)
            {
                sb.Append(c);
                BCDcount++;
                if (BCDcount == 4)
                    break;
            }

            return sb.ToString();
        }

        /// <summary>
        /// A0.07
        /// </summary>
        /// <param name="judge"></param>
        /// <returns></returns>
        public static bool checkSheetJudgeValid(string judge)
        {
            return SCAppConstants.SheetJudge.Set.Contains(judge);
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static List<RawData> ConvertValueReadToRawData(ValueRead valueData)
        {
            List<RawData> rawDataList = new List<RawData>();

            try
            {
                string sStartWord = valueData.ValueRange.Split('-')[0].Substring(1);
                int iStartWord = int.Parse(sStartWord, System.Globalization.NumberStyles.HexNumber);

                foreach (int iData in valueData.Value)
                {
                    RawData rawData = new RawData();
                    string str = Convert.ToString(iData, 2).PadLeft(16, '0');

                    rawData.PLC_Value = str.Substring(0, 4) + " " + str.Substring(4, 4) + " " + str.Substring(8, 4) + " " + str.Substring(12, 4);
                    rawData.PLC_Address = "W" + iStartWord.ToString("X");

                    iStartWord++;
                    rawDataList.Add(rawData);
                }
            }
            catch (Exception e)
            {
                throw new Exception(
                    String.Format("SCUtility has Error[Error method:{0}],[Error Message:{1}]", "ConvertValueReadToRawData", e.ToString()));
            }

            return rawDataList;
        }

        /**
         * 用來解析Value Read，length不為1的"Word/Bit Address"，將其中間的Address填滿
        **/
        public static string[] Analyze_rangeaddress(string srangeAddress)
        {
            string[] sArrayTemp = srangeAddress.Split('-');
            string[] sarrayrangeAddress;
            int iaddressStart = Convert.ToUInt16(sArrayTemp[0].Remove(0, 1), 16);
            int iaddressEnd = Convert.ToUInt16(sArrayTemp[sArrayTemp.Length - 1].Remove(0, 1), 16);
            sarrayrangeAddress = new string[iaddressEnd - iaddressStart + 1];
            if (srangeAddress.Substring(0, 1) == "B")
            {
                for (int i = iaddressStart, j = 0; i <= iaddressEnd; i++, j++)
                {
                    sarrayrangeAddress[j] = "B" + string.Format("{0:X}", i);
                }
            }
            else if (srangeAddress.Substring(0, 1) == "W")
            {
                for (int i = iaddressStart, j = 0; i <= iaddressEnd; i++, j++)
                {
                    sarrayrangeAddress[j] = "W" + string.Format("{0:X}", i);
                }
            }

            return sarrayrangeAddress;
        }

        #region 
        /// <summary>
        /// 壓縮ByteArray資料
        /// </summary>
        /// <param name="arrayByte"></param>
        /// <returns></returns>
        public static string CompressArrayByte(byte[] arrayByte)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.GZipStream compressedzipStream = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress, true);
            compressedzipStream.Write(arrayByte, 0, arrayByte.Length);
            compressedzipStream.Close();
            string compressStr = (string)(Convert.ToBase64String(ms.ToArray()));
            return compressStr;
        }

        /// <summary>
        /// 解壓縮BytyArray資料
        /// </summary>
        /// <param name="compressString">The compress string.</param>
        /// <returns>System.String.</returns>
        public static byte[] unCompressString(string compressString)
        {
            byte[] zippedData = Convert.FromBase64String(compressString.ToString());
            System.IO.MemoryStream ms = new System.IO.MemoryStream(zippedData);
            System.IO.Compression.GZipStream compressedzipStream = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress);
            System.IO.MemoryStream outBuffer = new System.IO.MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }
        #endregion
    }

    public static class StringBuilderExtensions
    {
        public static void Add(this StringBuilder sb, string key, string value)
        {
            try
            {
                sb.AppendFormat("      {0} = {1}{2}"
                                , key
                                , value
                                , Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("MapActioLog").Error("SCUtility has Error,  method：{0}、key:{1}、value:{2}、Exception Description:{3}",
                                                          "StringBuilderExtensions - Add",
                                                          key,
                                                          value,
                                                          ex.ToString());
            }
        }
    }
    
}