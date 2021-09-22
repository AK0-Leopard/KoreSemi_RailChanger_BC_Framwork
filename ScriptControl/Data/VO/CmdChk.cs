//*********************************************************************************
//      CmdChk.cs
//*********************************************************************************
// File Name: CmdChk.cs
// Description: CmdChk
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/10    Steven Hong    N/A            N/A     Initial
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CmdChk
    {
        public String Time { set; get; }
        public String Cmd_Master { set; get; }
        public String Type { set; get; }
        public String Ticket_No { set; get; }
        public String Port { set; get; }
        public String Request_Mode { set; get; }
        public String Return_Code { set; get; }
        public String Message { set; get; }
    }
}
