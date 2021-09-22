//*********************************************************************************
//      AlarmMap.cs
//*********************************************************************************
// File Name: AlarmMap.cs
// Description: AlarmMap
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

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class AlarmMap
    {
        public String EQPT_REAL_ID { set; get; }
        public String ALARM_ID { set; get; }
        public String ALARM_LVL { set; get; }
        public String ALARM_DESC { set; get; }
        public String ALARM_STATION { set; get; }
        public String SOLUTION { set; get; } 
    }
}
