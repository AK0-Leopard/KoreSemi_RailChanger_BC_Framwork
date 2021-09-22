//*********************************************************************************
//      Work_Stn.cs
//*********************************************************************************
// File Name: Work_Stn.cs
// Description: Work_Stn Object
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
    public class Work_Stn
    {
        public virtual string Stn_No { get; set; }
        public virtual string Stn_Name { get; set; }
        public virtual string Stn_Type { get; set; }
        public virtual string Work_Area { get; set; }
        public virtual string Cmd_Sno { get; set; }
    }

}