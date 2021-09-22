//*********************************************************************************
//      MainAlarm.cs
//*********************************************************************************
// File Name: MainAlarm.cs
// Description: MainAlarm
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2018/06/26    Steven Hong    N/A            A0.01   移除REMARK欄位
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.sc.Common;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class MainAlarm
    {
        public virtual string CODE { get; set; }
        public virtual string DESCRIPTION { get; set; }
        //A0.01 public virtual string REMARK { get; set; }
        public virtual string ACTION { get; set; }
    }
}
