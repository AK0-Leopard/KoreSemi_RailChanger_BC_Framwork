//*********************************************************************************
//      JobRoute.cs
//*********************************************************************************
// File Name: JobRoute.cs
// Description: Job Route Object
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
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class JobRoute
    {
        public string Crr_ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string BCRRead_Flag { get; set; }
        public int Crr_Stat { get; set; }
        public DateTime Initial_Time { get; set; }
    }

}