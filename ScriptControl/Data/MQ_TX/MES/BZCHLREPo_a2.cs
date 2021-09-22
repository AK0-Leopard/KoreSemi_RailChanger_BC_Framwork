//*********************************************************************************
//      BZCHLREPo_a2.cs
//*********************************************************************************
// File Name: BZCHLREPo_a2.cs
// Description: BZCHLREPo_a2
//
//(c) Copyright 2013, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   修改欄位名稱
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class BZCHLREPo_a2 : BaseTX
    {
        //Transaction Input Variables
        public String crr_id;                                     //       Carrier ID
        public String rtn_code;                                   //       Return code  //A0.01
        //A0.01 public String return_code;                                //       Return code
    }
}
