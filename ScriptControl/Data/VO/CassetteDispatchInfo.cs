//*********************************************************************************
//      ZoneRoute.cs
//*********************************************************************************
// File Name: ZoneRoute.cs
// Description: ZoneRoute類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2019/05/30    Mark Chou     N/A            N/A     Initial Release
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;


namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CassetteDispatchInfo
    {
        public virtual string Item { get; set; }
        public virtual string Note_Message { get; set; }

        public CassetteDispatchInfo(string item ,string note)
        {
            Item = item;
            Note_Message = note;
        }
    }
}
