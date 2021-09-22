//*********************************************************************************
//      ProcessDataValueHandler.cs
//*********************************************************************************
// File Name: ProcessDataValueHandler.cs
// Description: Type 1 EQ Process Data解析
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.ConfigHandler;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.ValueHandler
{
    public class ProcessDataValueHandler : ValueHandlerBase
    {
        protected Equipment eqpt;

        //Data
        public string Operator_ID { get; private set; }
        public string PPID { get; private set; }
        public int Process_Result { get; private set; }
        //Data Item
        public Dictionary<string, List<KeyValuePair<string, string>>> DataItemList { get; private set; }

        protected Logger procDataLog = null;
        public ProcessDataValueHandler(ValueRead vr, Equipment eq,
            string operator_id,  string ppid, int process_result)
            : base(vr)
        {
            this.eqpt = eq;
            procDataLog = LogManager.GetLogger(eqpt.Eqpt_ID.Trim() + "_ProcData");
            DataItemList = new Dictionary<string, List<KeyValuePair<string, string>>>();
            this.Operator_ID = operator_id;
            this.PPID = ppid;
            this.Process_Result = process_result;

            init();
        }

        private void init()
        {
            try
            {
                UInt16[] dataItem = (UInt16[])vr.getText();
                analyzeProcessDataItem(dataItem);
            }
            catch (Exception ex)
            {
                procDataLog.Warn(string.Format("analyzeProcessDataItem Exception.[Exception:{0}]", ex));
            }
        }

        private void analyzeProcessDataItem(UInt16[] dataItem)
        {
            ProcessDataConfigHandler handler = eqpt.getProcessDataConfigHandler();
            if (handler == null)
            {
                return;
            }
            List<ProcessDataType> procDataTypeList = handler.ProcDataTypeList;
            if (procDataTypeList == null)
            {
                return;
            }
            int beginIndex = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(string.Format("[Name:Operator ID][Value:{0}]", Operator_ID));
            sb.AppendLine(string.Format("[Name:PPID][Value:{0}]", PPID));
            foreach (ProcessDataType dataType in procDataTypeList)
            {
                string name = dataType.Name;
                string siteName = dataType.SiteName;
                
                if (String.Compare(name.Trim(), ProcessDataConfigHandler.SPARE_FORMAT.Trim(), true) == 0)
                {
                    beginIndex = beginIndex + 1;
                    continue;
                }
                
                int wordCount = dataType.WordCount;
                int[] dataAry = new int[wordCount];
                string valueStr = string.Empty;
                try
                {
                    Array.Copy(dataItem, beginIndex, dataAry, 0, wordCount);
                    beginIndex = beginIndex + wordCount;
                    if (dataType.ItemType == ProcessDataType.DataItemType.BCD)
                    {
                        double multiplier = dataType.Multiplier;
                        bool isContainSign = dataType.IsContainSign;
                        BCD_Common bcd = BCD_Common.toBCD_Common(dataAry, wordCount, multiplier, isContainSign);
                        double realValue = bcd.RealValue;
                        valueStr = Convert.ToString(realValue);
                        sb.AppendLine(string.Format("[Name:{0}][SitemName:{1}][Value:{2}]", name, siteName, realValue));
                    }
                    else if (dataType.ItemType == ProcessDataType.DataItemType.ASCII)
                    {
                        string realStr = BCFUtility.convertIntAry2String(dataAry);
                        valueStr = realStr;
                        sb.AppendLine(string.Format("[Name:{0}][SitemName:{1}][Value:{2}]", name, siteName, realStr));
                    }
                    else if (dataType.ItemType == ProcessDataType.DataItemType.INT)
                    {
                        double multiplier = dataType.Multiplier;
                        if (dataType.IsContainSign)
                        {
                            double doubleVal = 0;
                            if (dataAry.Length > 2)
                            {
                                //3個word以上，使用Int64
                                //64 bit(4 word)
                                doubleVal = SCUtility.convertInt2TextByType(16, typeof(System.Int64), dataAry, multiplier);

                            }
                            else if (dataAry.Length > 1)
                            {
                                //2個word，使用Int32
                                //32 bit(2 word)
                                doubleVal = SCUtility.convertInt2TextByType(16, typeof(System.Int32), dataAry, multiplier);

                            }
                            else
                            {
                                //1個word，使用Int16
                                //16 bit(1 word)
                                doubleVal = SCUtility.convertInt2TextByType(16, typeof(System.Int16), dataAry, multiplier);
                            }

                            valueStr = Convert.ToString(doubleVal);
                        }
                        else
                        {
                            double doubleVal = 0;
                            if (dataAry.Length > 2)
                            {
                                //3個word以上，使用UInt64
                                //64 bit(4 word)
                                UInt64 val = (UInt64)BCFUtility.convertInt2TextByType(16, typeof(System.UInt64), dataAry);
                                doubleVal = val * multiplier;
                            }
                            else if (dataAry.Length > 1)
                            {
                                //2個word，使用UInt32
                                //32 bit(2 word)
                                UInt32 val = (UInt32)BCFUtility.convertInt2TextByType(16, typeof(System.UInt32), dataAry);
                                doubleVal = val * multiplier;
                            }
                            else
                            {
                                //1個word，使用UInt16
                                //16 bit(1 word)
                                UInt16 val = (UInt16)BCFUtility.convertInt2TextByType(16, typeof(System.UInt16), dataAry);
                                doubleVal = val * multiplier;
                            }
                            
                            valueStr = Convert.ToString(doubleVal);
                        }
                        
                        sb.AppendLine(string.Format("[Name:{0}][SitemName:{1}][Value:{2}]", name, siteName, valueStr));
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(string.Format("[Name:{0}][Exception:{1}]", name, ex));
                }

                KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(siteName, valueStr);
                if (DataItemList.Keys.Contains(name))
                {
                    DataItemList[name].Add(keyValuePair);
                }
                else
                {
                    DataItemList.Add(name, new List<KeyValuePair<string, string>>() { keyValuePair });
                }
            }
            procDataLog.Info(sb.ToString());
        }

    }
}
