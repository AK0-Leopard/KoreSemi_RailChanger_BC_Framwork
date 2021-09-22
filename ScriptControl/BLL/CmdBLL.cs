//*********************************************************************************
//      CmdBLL.cs
//*********************************************************************************
// File Name: CmdBLL.cs
// Description: 業務邏輯：Cmd
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
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.SECS;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using com.mirle.ibg3k0.bcf.App;
using System.Globalization;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using Nancy.Json;
using com.mirle.ibg3k0.WpfTools;
using com.mirle.ibg3k0.sc.webAPI;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.sc.ValueHandler.Vo;
using System.Threading;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class CmdBLL
    {
        private SCApplication scApp = null;
        private MirleGoUiApp mgoApp = null;
        private RobotCMDUtility RCU = null;
        private Line line = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Logger logger_CmdCheck = LogManager.GetLogger("CommandCheck");
        private Logger logger_ASRSRequest = LogManager.GetLogger("ASRSRequest");

        CmdMstDao cmdMstDao = null;
        CmdDtlDao cmdDtlDao = null;
        MergeCmdDao mergeCmdDao = null;
        MergeCmdHisDao mergeCmdHisDao = null;
        HostDefaultValueDefMapAction hostDefaultMapAction = null;

        public CmdBLL()
        {

        }

        public void start(SCApplication app)
        {
            this.scApp = app;
            RCU = scApp.RobotCMDUtility;
            cmdMstDao = scApp.CmdMstDao;
            cmdDtlDao = scApp.CmdDtlDao;
            mergeCmdDao = scApp.MergeCmdDao;
            mergeCmdHisDao = scApp.MergeCmdHisDao;
        }
    }
}
