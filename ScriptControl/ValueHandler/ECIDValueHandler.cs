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
    public class ECIDValueHandler : ValueHandlerBase
    {
        protected Equipment eqpt;

        //Data Item
        public List<ECIDMap> ECIDMapList { get; private set; }

        protected Logger ecidLog = null;
        public ECIDValueHandler(ValueRead vr, Equipment eq)
            : base(vr)
        {
            this.eqpt = eq;
            ecidLog = LogManager.GetLogger(eqpt.Eqpt_ID.Trim() + "_ECID");
            ECIDMapList = new List<ECIDMap>();
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
                UInt16[] dataItem = (UInt16[])vr.getText();
                analyzeECIDItem(dataItem);
            }
            catch (Exception ex) 
            {
                ecidLog.Warn(string.Format("analyzeECIDItem Exception.[Exception:{0}]", ex));
            }
        }

        private void analyzeECIDItem(UInt16[] dataItem)
        {
            ECIDConfigHandler handler = eqpt.getECIDConfigHandler();
            if (handler == null)
            {
                return;
            }
            List<ECIDDataType> svDataTypeList = handler.ECIDTypeList;
            if (svDataTypeList == null)
            {
                return;
            }
            int beginIndex = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            foreach (ECIDDataType dataType in svDataTypeList)
            {
                string name = dataType.Name;
                string ecid = dataType.ECID;
                int wordCount = dataType.WordCount;
                int[] dataAry = new int[wordCount];
                string valueStr = string.Empty;
                try
                {
                    Array.Copy(dataItem, beginIndex, dataAry, 0, wordCount);
                    beginIndex = beginIndex + wordCount;
                    if (dataType.ItemType == ECIDDataType.DataItemType.BCD)
                    {
                        double multiplier = dataType.Multiplier;
                        bool isContainSign = dataType.IsContainSign;
                        BCD_Common bcd = BCD_Common.toBCD_Common(dataAry, wordCount, multiplier, isContainSign);
                        double realValue = bcd.RealValue;
                        valueStr = Convert.ToString(realValue);
                        sb.AppendLine(string.Format("[ECID:{0}][Name:{1}][Value:{2}]", ecid, name, realValue));
                    }
                    else if (dataType.ItemType == ECIDDataType.DataItemType.ASCII)
                    {
                        string realStr = BCFUtility.convertIntAry2String(dataAry);
                        valueStr = realStr;
                        sb.AppendLine(string.Format("[ECID:{0}][Name:{1}][Value:{2}]", ecid, name, realStr));
                    }
                    else if (dataType.ItemType == ECIDDataType.DataItemType.INT)
                    {
                        double multiplier = dataType.Multiplier;
                        if (dataType.IsContainSign)
                        {
                            Int16 val = (Int16)BCFUtility.convertInt2TextByType(16, typeof(System.Int16), dataAry);
                            double doubleVal = val * multiplier;
                            valueStr = Convert.ToString(doubleVal);
                        }
                        else
                        {
                            UInt16 val = (UInt16)BCFUtility.convertInt2TextByType(16, typeof(System.UInt16), dataAry);
                            double doubleVal = val * multiplier;
                            valueStr = Convert.ToString(doubleVal);
                        }
                        sb.AppendLine(string.Format("[ECID:{0}][Name:{1}][Value:{2}]", ecid, name, valueStr));
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(string.Format("[ECID:{0}][Name:{1}][Exception:{2}]", ecid, name, ex));
                }
                //                DataItemList.Add(new KeyValuePair<string, string>(svid, valueStr));
                ECIDMapList.Add(new ECIDMap()
                {
                    EQPT_REAL_ID = eqpt.Real_ID,
                    ECID = ecid,
                    ECNAME = name,
                    EV = valueStr
                });
            }
            ecidLog.Info(sb.ToString());
        }

    }
}
