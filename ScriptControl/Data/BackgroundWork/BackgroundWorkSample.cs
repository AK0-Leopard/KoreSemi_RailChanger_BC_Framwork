//*********************************************************************************
//      BackgroundPLCWorkProcessData.cs
//*********************************************************************************
// File Name: BackgroundPLCWorkProcessData.cs
// Description: 背景執行上報Process Data至MES的實際作業
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/07/06    Hayes Chen     N/A            N/A     Initial Release
// 2014/07/17    Sean Wang      N/A            A0.01   修改dataItem的長度取決於MES_ValueDefs_simple.config設定
//
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Common.MPLC;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.bcf.Schedule;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;

namespace com.mirle.ibg3k0.sc.Data
{
    public class BackgroundWorkSample : IBackgroundWork
    {
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public long getMaxBackgroundQueueCount()
        {
            return 1000;
        }

        public string getDriverName()
        {
            return this.GetType().Name;
        }

        public void doWork(string workKey, BackgroundWorkItem item)
        {
            Object obj1 = item.Param[0];
            int value = Convert.ToInt16(obj1);
            //Do something.
            Console.WriteLine(value);
        }
    }
}
