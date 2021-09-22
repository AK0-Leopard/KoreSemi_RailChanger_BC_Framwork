//*********************************************************************************
//      Cmd.cs
//*********************************************************************************
// File Name: Cmd.cs
// Description: Cmd Object
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
    public class PortCmd
    {
        public string Port_ID { get; set; }
        public string Crr_ID { get; set; }
        public string Crr_Type { get; set; }
        public int Crr_Condition { get; set; }
        public string Schedule { get; set; }
        public bool From_Manual { get; set; }
    }

}