//*********************************************************************************
//      ShareMemoryInitProcess_Base.cs
//*********************************************************************************
// File Name: ShareMemoryInitProcess_Base.cs
// Description: 基本Shere Memory初始化作業
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/02/19    Hayes Chen     N/A            N/A     Initial Release
//
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.InitAction;

namespace com.mirle.ibg3k0.sc.Data.InitAction
{
    public class ShareMemoryInitProcess_Base : IShareMemoryInitProcess
    {
        BCFApplication bcfApp = BCFApplication.getInstance();
        public ShareMemoryInitProcess_Base()
        {
        }
        public void doInit()
        {
            Dictionary<string, ISMControl> smControlDic = bcfApp.getMPLCSMControlDic();
            foreach (ISMControl control in smControlDic.Values)
            {
                control.readDeviceBlock();
                control.syncLoopValueEvent();
            }
        }
    }
}
