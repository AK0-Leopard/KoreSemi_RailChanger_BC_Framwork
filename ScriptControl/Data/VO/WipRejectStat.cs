//*********************************************************************************
//      WipRejectStat.cs
//*********************************************************************************
// File Name: WipRejectStat.cs
// Description: WIP Reject Status Object
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
    public class WipRejectStat
    {
        public bool Crr_Exist { get; set; }

        public bool Reserve { get; set; }
    }

}