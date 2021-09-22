//*********************************************************************************
//      PortCmdChk.cs
//*********************************************************************************
// File Name: PortCmdChk.cs
// Description: PortCmdChk
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/29    Steven Hong    N/A            N/A     Initial
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class PortCmdChk
    {
        public String Port_ID { set; get; }
        public String Time { set; get; }
        public String Ticket_No { set; get; }
        public String Result { set; get; }
        public String Message { set; get; }
    }
}
