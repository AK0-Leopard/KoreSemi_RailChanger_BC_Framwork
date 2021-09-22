//*********************************************************************************
//      Sno_Max.cs
//*********************************************************************************
// File Name: Sno_Max.cs
// Description: Sno_Max Object
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
    public class Sno_Max
    {
        public virtual string Sno_Type { get; set; }
        public virtual string Month_Flag { get; set; }
        public virtual int Init_Sno { get; set; }
        public virtual int Max_Sno { get; set; }
        public virtual int Sno_Len { get; set; }
    }

}