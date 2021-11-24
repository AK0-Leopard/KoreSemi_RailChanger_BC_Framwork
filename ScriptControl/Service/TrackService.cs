using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using RailChangerProtocol;
using System.IO;
using NLog;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;

namespace GrpcService
{
    public class TrackService : Greeter.GreeterBase
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected Line line = EQObjCacheManager.getInstance().getLine();
        protected SCApplication scApp = null;
        private string logPath = @"Log\GrpcService\";
        private StreamWriter sw;
        private int currentDay = 0;
        public TrackService(SCApplication _scApp)
        {
            scApp = _scApp;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }


        //Write
        private void saveLog(string eventType, string railChangeNumber, string cmdInfo, string result)
        {
            sw = new StreamWriter(logPath + DateTime.Now.ToString("yyyyMMdd") + ".txt", true);
            #region 開始寫Log
            sw.WriteLine("System DateTime:" + DateTime.Now.ToString("G"));
            sw.WriteLine("   eventType:" + eventType);
            sw.WriteLine("   railChangerNumber:" + railChangeNumber);
            sw.WriteLine("   cmdInfo:" + cmdInfo);
            sw.WriteLine("   result:" + result);
            sw.Close();
            #endregion
            Console.WriteLine(DateTime.Now.ToString("G") + "," + eventType + "," + railChangeNumber + "," + cmdInfo + "," + result);
        }
        public override Task<alarmRstReply> alarmRst(alarmRstRequest request, ServerCallContext context)
        {
            string result = String.Empty;

            saveLog("alarmRst", request.RailChangerNumber, "null", result);
            return Task.FromResult(new alarmRstReply
            {
                Message = result
            });
        }
        public override Task<blockRstReply> blockRst(blockRstRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            //saveLog("blockRst", request.RailChangerNumber, "null", result);
            Equipment voEQ = scApp.getEQObjCacheManager().getEquipmentByEQPTRealID(request.RailChangerNumber);
            RailChangerDefaultValueDefMapAction MapAction = voEQ.getMapActionByIdentityKey(typeof(RailChangerDefaultValueDefMapAction).Name) as RailChangerDefaultValueDefMapAction;
            result = MapAction.RAIL_RESET_CAREXIST().ToString();
            return Task.FromResult(new blockRstReply
            {
                Message = result
            });
        }
        public override Task<changeDirReply> changeDir(changeDirRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("change dir", request.RailChangerNumber, "dir:" + request.Dir, result);
            return Task.FromResult(new changeDirReply
            {
                Message = result
            });
        }

        //Read
        public override Task<isAliveReply> isAlive(isAliveRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("is Alive", request.RailChangerNumber, "null", result);
            return Task.FromResult(new isAliveReply
            {
                Message = result
            }); ;
        }
        public override Task<getDirReply> getDir(getDirRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("get Dir", request.RailChangerNumber, "null", result);
            return Task.FromResult(new getDirReply
            {
                Message = result
            });
        }
        public override Task<getStatusReply> getStatus(getStatusRequest request, ServerCallContext context)
        {
            string result = String.Empty;

            saveLog("get Status", request.RailChangerNumber, "null", result);
            return Task.FromResult(new getStatusReply
            {
                Message = result
            });
        }
        public override Task<getBlockReply> getBlock(getBlockRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("閉塞區內有無車", request.RailChangerNumber, "null", result);
            return Task.FromResult(new getBlockReply
            {
                Message = result
            });
        }
        public override Task<getChangerTimerReply> getChangerTimer(getChangerTimerRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("取得切換軌次數", request.RailChangerNumber, "null", result);
            return Task.FromResult(new getChangerTimerReply
            {
                Message = result
            });
        }
        public override Task<getErrorReportReply> getErrorReport(getErrorReportRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("取得Error代號", request.RailChangerNumber, "null", result);
            return Task.FromResult(new getErrorReportReply
            {
                Message = result
            });
        }
        public override Task<getVersionReply> getVersion(getVersionRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("取得換軌器版本", request.RailChangerNumber, "null", result);
            return Task.FromResult(new getVersionReply
            {
                Message = result
            });
        }
        public override Task<changeModeReply> changeMode(changeModeRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("改變換軌器狀態", request.RailChangerNumber, request.Mode, result);
            return Task.FromResult(new changeModeReply
            {
                Message = result
            });
        }
        public TrackStatus conver2TrackStatus(int mode) {
            TrackStatus result = TrackStatus.NotDefine;
            switch (mode)
            {
                case 0:
                    result = TrackStatus.NotDefine;
                    break;
                case 1:
                    result = TrackStatus.Manaul;
                    break;
                case 2:
                    result = TrackStatus.Auto;
                    break;
                case 3:
                    result = TrackStatus.Alarm;
                    break;
            }
            return result;
        }
        public override Task<stopSetReply> stopSet(stopSetRequest request, ServerCallContext context)
        {
            string result = String.Empty;
            saveLog("緊急停止", request.RailChangerNumber, "null", result);
            return Task.FromResult(new stopSetReply
            {
                Message = result
            });
        }
        public override Task<ReplyTracksInfo> RequestTracksInfo(Empty request, ServerCallContext context)
        {
            string result = String.Empty;
            ReplyTracksInfo tracksInfo = new ReplyTracksInfo();
            List<Equipment> voEQ = null;
            voEQ = scApp.getEQObjCacheManager().getEuipmentListByNode("RC_NODE");
            foreach (Equipment eq in voEQ) {
                TrackInfo trackInfo = new TrackInfo();
                trackInfo.TrackId = eq.Real_ID;
                trackInfo.Alive = eq.Is_EqAlive;
                trackInfo.AlarmCode = eq.Alarm_Happen_Code;
                trackInfo.Dir = (eq.RC_Side == 1) ? TrackDir.Straight : TrackDir.Curve;
                trackInfo.IsBlock = (eq.Block_Status == 1) ? TrackBlock.Block : TrackBlock.NonBlock;
                trackInfo.Status = conver2TrackStatus(eq.Oper_Mode);
                tracksInfo.TracksInfo.Add(trackInfo);
            }
            return Task.FromResult(tracksInfo);
        }
    }
}
