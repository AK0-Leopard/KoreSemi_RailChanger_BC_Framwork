//*********************************************************************************
//      Prog_List.cs
//*********************************************************************************
// File Name: Prog_List.cs
// Description: Prog_List Object
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
    public class Prog_List
    {
        public virtual string ProgID { get; set; }
        public virtual string ProgName { get; set; }
        public virtual string ProgFile { get; set; }
    }

}