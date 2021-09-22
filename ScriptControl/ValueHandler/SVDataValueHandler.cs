using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data;
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
    public class SVDataValueHandler : ValueHandlerBase
    {
        protected Equipment eqpt;

        //Data Item
//        public List<KeyValuePair<string, string>> DataItemList { get; private set; }
        public List<SVDataMap> SVDataMapList { get; private set; }

        protected Logger svDataLog = null;
        public SVDataValueHandler(ValueRead vr, Equipment eq)
            : base(vr)
        {
            this.eqpt = eq;
            svDataLog = LogManager.GetLogger(eqpt.Eqpt_ID.Trim() + "_SVData");
//            DataItemList = new List<KeyValuePair<string, string>>();
            SVDataMapList = new List<SVDataMap>();

            init();
        }

        public void refresh(ValueRead vr) 
        {
            this.vr = vr;
            init();
        }

        private void init()
        {
            try
            {
                SVDataMapList.Clear();
                if (vr == null) 
                {
                    //SVDataMapList.Clear();
                    return;
                }
                UInt16[] dataItem = (UInt16[])vr.getText();
                analyzeSVDataItem(dataItem);
            }
            catch (Exception ex)
            {
                svDataLog.Warn(string.Format("analyzeSVDataItem Exception.[Exception:{0}]", ex));
            }
        }

        private void analyzeSVDataItem(UInt16[] dataItem)
        {
            SVDataConfigHandler handler = eqpt.getSVDataConfigHandler();
            if (handler == null)
            {
                return;
            }
            List<SVDataType> svDataTypeList = handler.SVDataTypeList;
            if (svDataTypeList == null)
            {
                return;
            }
            int beginIndex = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            foreach (SVDataType dataType in svDataTypeList)
            {
                string name = dataType.Name;
                string svid = dataType.SVID;
                int wordCount = dataType.WordCount;
                int[] dataAry = new int[wordCount];
                string valueStr = string.Empty;
                try
                {
                    Array.Copy(dataItem, beginIndex, dataAry, 0, wordCount);
                    beginIndex = beginIndex + wordCount;
                    if (dataType.ItemType == SVDataType.DataItemType.BCD)
                    {
                        double multiplier = dataType.Multiplier;
                        bool isContainSign = dataType.IsContainSign;
                        BCD_Common bcd = BCD_Common.toBCD_Common(dataAry, wordCount, multiplier, isContainSign);
                        double realValue = bcd.RealValue;
                        valueStr = Convert.ToString(realValue);
                        sb.AppendLine(string.Format("[SVID:{0}][Name:{1}][Value:{2}]", svid, name, realValue));
                    }
                    else if (dataType.ItemType == SVDataType.DataItemType.ASCII)
                    {
                        string realStr = BCFUtility.convertIntAry2String(dataAry);
                        valueStr = realStr;
                        sb.AppendLine(string.Format("[SVID:{0}][Name:{1}][Value:{2}]", svid, name, realStr));
                    }
                    else if (dataType.ItemType == SVDataType.DataItemType.INT)
                    {
                        double multiplier = dataType.Multiplier;
                        if (dataType.IsContainSign)
                        {
                            double doubleVal = 0;
                            if (dataAry.Length > 2)
                            {
                                //3個word以上，使用Int64
                                //64 bit(4 word)
                                Int64 val = (Int64)BCFUtility.convertInt2TextByType(16, typeof(System.Int64), dataAry);
                                doubleVal = val * multiplier;
                            }
                            else if (dataAry.Length > 1)
                            {
                                //2個word，使用Int32
                                //32 bit(2 word)
                                Int32 val = (Int32)BCFUtility.convertInt2TextByType(16, typeof(System.Int32), dataAry);
                                doubleVal = val * multiplier;
                            }
                            else
                            {
                                //1個word，使用Int16
                                //16 bit(1 word)
                                Int16 val = (Int16)BCFUtility.convertInt2TextByType(16, typeof(System.Int16), dataAry);
                                doubleVal = val * multiplier;
                            }
                            //                            Int16 val = (Int16)BCFUtility.convertInt2TextByType(16, typeof(System.Int16), dataAry);
                            //                            double doubleVal = val * multiplier;
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
                            //                            UInt16 val = (UInt16)BCFUtility.convertInt2TextByType(16, typeof(System.UInt16), dataAry);
                            //                            double doubleVal = val * multiplier;
                            valueStr = Convert.ToString(doubleVal);
                        }
                        sb.AppendLine(string.Format("[SVID:{0}][Name:{1}][Value:{2}]", svid, name, valueStr));
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(string.Format("[SVID:{0}][Name:{1}][Exception:{2}]", svid, name, ex));
                }
//                DataItemList.Add(new KeyValuePair<string, string>(svid, valueStr));
                SVDataMapList.Add(new SVDataMap() 
                {
                    EQPT_REAL_ID = eqpt.Real_ID,
                    SVID = svid,
                    SVNAME = name,
                    SV = valueStr
                });
            }
            svDataLog.Info(sb.ToString());
        }

    }
}
