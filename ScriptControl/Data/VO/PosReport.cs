//*********************************************************************************
//      PosReport.cs
//*********************************************************************************
// File Name: PosReport.cs
// Description: Position Report Object
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
    public class PosReport
    {
        public string Crr_ID { get; set; }

        public string Loc { get; set; }
    }

}