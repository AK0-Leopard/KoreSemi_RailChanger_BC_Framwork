//*********************************************************************************
//      MergeCmd.cs
//*********************************************************************************
// File Name: MergeCmd.cs
// Description: MergeCmd類別
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
using com.mirle.ibg3k0.sc.Common;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class MergeCmd : PropertyChangedVO
    {
        public virtual string Cmd_Sno { get; set; }
        public virtual string Crr_ID1 { get; set; }
        public virtual string Crr_ID2 { get; set; }
        public virtual string Cmd_Result { get; set; }
    }
}
