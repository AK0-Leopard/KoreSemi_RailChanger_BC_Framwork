//*********************************************************************************
//      LinkStatusCheck.cs
//*********************************************************************************
// File Name: LinkStatusCheck.cs
// Description: 
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/03/19    Steven Hong    N/A            A0.01   修正補送訊息失敗時，List內容不斷增加錯誤
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.TimerAction;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.stc.Common.SECS;
using Mirle.AK0.Hlt.Communications.Sockets.TCPClients;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.TimerAction
{
    public class HostConnectCheck : ITimerAction
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected TCPClientAPI TcpClient = null;

        public HostConnectCheck(string name, long intervalMilliSec)
            : base(name, intervalMilliSec)
        {
        }

        public override void initStart()
        {
            scApp = SCApplication.getInstance();
            TcpClient = scApp.TcpClient;
        }

        public override async void doProcess(object obj)
        {
            //try
            //{
                //if(TcpClient.IsSocketAlive && scApp.UnSendToHostMsg.Count > 0)
                //{
                //    List<UnSendMsg> newLst = new List<UnSendMsg>();

                //    //A0.01 Start
                //    List<UnSendMsg> currLst = scApp.UnSendToHostMsg;
                //    foreach (UnSendMsg msg in currLst)
                //    {
                //        if (TcpClient != null)
                //        {
                //            SCUtility.ConvertMQMsg(SCUtility.FUNCTION_TRANSDFERTYPE_SEND_TO_HOST, msg.Cmd_No, msg.Msg);

                //            await Task.Run(() => scApp.SendAndReceiveAsyncForResend(msg));
                //        }
                //    }
                    //foreach (UnSendMsg msg in scApp.UnSendToHostMsg)
                    //{
                    //    if (TcpClient != null)
                    //    {
                    //        SCUtility.ConvertMQMsg(SCUtility.FUNCTION_TRANSDFERTYPE_SEND_TO_HOST, msg.Cmd_No, msg.Msg);
                    //        await Task.Run(() => scApp.SendAndReceiveAsync(msg.Msg, msg.TEID, msg.Cmd_No));
                    //    }
                    //    else
                    //    {
                    //        newLst.Add(msg);
                    //    }
                    //}
                    //A0.01 End

        //            scApp.UnSendToHostMsg = newLst;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Exception");
        //    }
        }
    }
}