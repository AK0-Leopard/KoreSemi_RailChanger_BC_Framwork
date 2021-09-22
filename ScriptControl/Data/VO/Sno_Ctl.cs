//*********************************************************************************
//      Sno_Ctl.cs
//*********************************************************************************
// File Name: Sno_Ctl.cs
// Description: Sno_Ctl Object
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
    public class Sno_Ctl
    {
        public virtual string Sno_Type { get; set; }
        public virtual string Trn_Month { get; set; }
        public virtual int Sno { get; set; }
    }

}