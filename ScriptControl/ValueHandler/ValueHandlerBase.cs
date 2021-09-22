//*********************************************************************************
//      DataHandlerBase.cs
//*********************************************************************************
// File Name: DataHandlerBase.cs
// Description: 作為從MPLC取值回來之後，對整個區塊值進行解析的類別(Sample)
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/03/14    Sean Wang      N/A            N/A     Initial Release
//
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Common;
using System.Collections;
using NLog;

namespace com.mirle.ibg3k0.sc.ValueHandler
{
    public class ValueHandlerBase
    {
        protected ValueRead vr = null;
        protected Logger logger = LogManager.GetLogger("EquipmentLog");

        public ValueHandlerBase()
        {

        }

        public ValueHandlerBase(ValueRead vr)
        {
            this.vr = vr;
        }

        public void setValueRead(ValueRead vr)
        {
            this.vr = vr;
        }

        public ValueRead getValueRead()
        {
            return vr;
        }

        /**
          * dataTemp : 資料來源為  (UInt16[])ValueRead.getText()
         **/
        public UInt16 convertToInt16(UInt16[] dataTemp, int iStartIndex, int iEndIndex)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, iStartIndex, iEndIndex);
            return (UInt16)rangeData[0];
        }

        /**
         * dataTemp : 資料來源為  (UInt16[])ValueRead.getText()
         **/
        public String convertToString(UInt16[] dataTemp, int iStartIndex, int iEndIndex)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, iStartIndex, iEndIndex);

            foreach (int loopInt in rangeData)
            {

                if (loopInt != 0)
                {
                    return ((String)BCFUtility.convertInt2TextByType(vr.MPLCConfigDevice.DeviceBitCount,
                        Type.GetType("System.String"), rangeData)).Trim();
                }
            }

            return " ";

        }

        /**
         * dataTemp : 資料來源為  (UInt16[])ValueRead.getText()
         **/
        public Boolean[] convertToBooleans(UInt16[] dataTemp, int iStartIndex, int iEndIndex)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, iStartIndex, iEndIndex);
            return (Boolean[])BCFUtility.convertInt2TextByType(vr.MPLCConfigDevice.DeviceBitCount, Type.GetType("System.Boolean[]"), rangeData);
        }

        /**
         * dataTemp : 資料來源為  (UInt16[])ValueRead.getText()
         **/
        public UInt16 convertToInt16(UInt16[] dataTemp, int index)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, index, index);
            return (UInt16)rangeData[0];
        }

        /**
         * dataTemp : 資料來源為  (UInt16[])ValueRead.getText()
         **/
        public DateTime convertToDateTime(UInt16[] dataTemp, int iStartIndex, int iEndIndex)
        {
            int[] rangeData = BCFUtility.getArrayRange(dataTemp, iStartIndex, iEndIndex);
            String sTimeArray = (String)BCFUtility.convertInt2TextByType(vr.MPLCConfigDevice.DeviceBitCount, Type.GetType("System.String"), rangeData);

            try
            {
                IFormatProvider timeStyle = new System.Globalization.CultureInfo("zh-TW", true);
                return DateTime.ParseExact(sTimeArray, "yyyyMMddHHmmssff", timeStyle);
            }
            catch
            {
                //格式錯誤
            }

            return new DateTime();
        }

        /**
         * 取得陣列範圍轉換成數字
         **/
        public int convertToInt(Boolean[] temp, int startIndex, int endIndex)
        {

            int minIndex = Math.Min(startIndex, endIndex);
            int maxIndex = Math.Max(startIndex, endIndex);
            if (temp.Count() < (maxIndex + 1))
            {
                return 0;
            }

            int loopCount = maxIndex - minIndex + 1;
            int[] intAry = new int[1];
            BitArray bitArray = new BitArray(loopCount);
            for (int i = 0; i < loopCount; i++)
            {
                bitArray[i] = temp[minIndex + i];
            }

            bitArray.CopyTo(intAry, 0);

            return intAry[0];
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

        public static char[] convertToBCD(UInt16 dataTemp)
        {
            int iarrayCount = 0;
            char[] returnData = new char[4];//由於一個Word可由4個BCD碼組成，固可令它*4
            char[] cTemp = dataTemp.ToString("X4").ToCharArray(0, 4);
            for (int i = 0; i < 4; i++)
            {
                returnData[iarrayCount] = cTemp[i];
                iarrayCount++;
            }

            return returnData;
        }

        public int[] getTwoDigitalBCDInt(double realValue, double multiplier, bool isContainSign)
        {
            return new BCD_FTB(realValue, 1, 2, multiplier, isContainSign).toWriteBCDInt();
        }

        public int[] getCommonTwoDigitalBCDInt(double realValue)
        {
            return new BCD_FTB(realValue, 1, 2, 1, false).toWriteBCDInt();
        }
    }
}
