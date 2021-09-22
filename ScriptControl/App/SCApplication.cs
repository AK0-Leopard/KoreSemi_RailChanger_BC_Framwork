//*********************************************************************************
//      SCApplication.cs
//*********************************************************************************
// File Name: SCApplication.cs
// Description: SCApplication
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/03/19    Steven Hong    N/A            A0.01   增加Resend Host Message用的Function
//                                                     修正CIM Status更新問題
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.ConfigHandler;
using com.mirle.ibg3k0.bcf.Data.InitAction;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.bcf.Schedule;
using com.mirle.ibg3k0.sc.BLL;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.sc.WIF;
using NLog;
using System.Data;
using GenericParsing;
using com.mirle.ibg3k0.stc.Common.SECS;
using com.mirle.ibg3k0.sc.Data.SECS;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.TimerAction;
using System.IO;
using System.Threading;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.mqc.app;
using Nancy.Hosting.Self;
using Nancy;
using Nest;
using com.mirle.ibg3k0.WpfTools;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.mqc.tx;
using com.mirle.ibg3k0.sc.Data.JSON;
using Newtonsoft.Json;
using Mirle.AK0.Hlt.Communications.Sockets.TCPClients;
using System.Runtime.CompilerServices;
using System.Net;
using System.Net.Sockets;
using Grpc.Core;
using ConsoleAppServer;
using com.mirle.ibgAK0.EAP.HostMessage.H2E;
using com.mirle.ibg3k0.sc.WebAPI;
using com.mirle.ibgAK0.EAP.HostMessage.E2H;
using System.Windows.Forms;
using System.Diagnostics;
//using Excel = Microsoft.Office.Interop.Excel;
namespace com.mirle.ibg3k0.sc.App
{
    public class SCApplication
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Logger logger_SystemConsole = LogManager.GetLogger("System_Console_Log");
        private static Logger logger_CmdCheck = LogManager.GetLogger("CommandCheck");
        private static Logger logger_Job = LogManager.GetLogger("JobRouteModify");

        /// <summary>
        /// 專門用於查詢特定Bug使用，請於問題確認後將欲追蹤的Log刪除
        /// </summary>
        public static Logger logger_DebugUse { get; private set; }

        private EQPTConfigSections eqptCss = null;

        private NodeFlowRelConfigSections nodeFlowRelCss = null;

        private string eapSecsAgentName;
        public string EAPSecsAgentName { get { return eapSecsAgentName; } }
        public string BC_ID { get; private set; }
        private string loginUserID = null;
        public int SEQ_NO { get; set; } //00001~99999

        public string LoginUserID
        {
            get { return loginUserID; }
            set { loginUserID = value; }
        }
        private static Object _lock = new Object();
        private static SCApplication application;
        private static BCFApplication bcfApplication;
        private EQObjCacheManager eqObjCacheManager;

        private HostDefaultValueDefMapAction hostDefaultMapAction;

        //DAO
        private LineDao lineDao = null;
        public LineDao LineDao { get { return lineDao; } }
        private ZoneDao zoneDao = null;
        public ZoneDao ZoneDao { get { return zoneDao; } }
        private NodeDao nodeDao = null;
        public NodeDao NodeDao { get { return nodeDao; } }
        private EqptDao eqptDao = null;
        public EqptDao EqptDao { get { return eqptDao; } }
        private UnitDao unitDao = null;
        public UnitDao UnitDao { get { return unitDao; } }
        private PortDao portDao = null;
        public PortDao PortDao { get { return portDao; } }
        private UserDao userDao = null;
        public UserDao UserDao { get { return userDao; } }
        private FunctionCodeDao functionCodeDao = null;
        public FunctionCodeDao FunctionCodeDao { get { return functionCodeDao; } }
        private UserFuncDao userFuncDao = null;
        public UserFuncDao UserFuncDao { get { return userFuncDao; } }
        private AlarmDao alarmDao = null;
        public AlarmDao AlarmDao { get { return alarmDao; } }
        private CarrierDao carrierDao = null;
        public CarrierDao CarrierDao { get { return carrierDao; } }
        private BCStatusDao bcStatusDao = null;
        public BCStatusDao BCStatusDao { get { return bcStatusDao; } }
        private OperationHisDao operationHisDao = null;
        public OperationHisDao OperationHisDao { get { return operationHisDao; } }
        private UserGroupDao userGroupDao = null;
        public UserGroupDao UserGroupDao { get { return userGroupDao; } }
        private CmdMstDao cmdMstDao = null;
        public CmdMstDao CmdMstDao { get { return cmdMstDao; } }
        private CmdDtlDao cmdDtlDao = null;
        public CmdDtlDao CmdDtlDao { get { return cmdDtlDao; } }
        private LocMstDao locMstDao = null;
        public LocMstDao LocMstDao { get { return locMstDao; } }
        private LocDtlDao locDtlDao = null;
        public LocDtlDao LocDtlDao { get { return locDtlDao; } }
        private SnoCtlDao snoCtlDao = null;
        public SnoCtlDao SnoCtlDao { get { return snoCtlDao; } }
        private ParameterDao parameterDao = null;
        public ParameterDao ParameterDao { get { return parameterDao; } }
        private CarrierHisDao carrierHisDao = null;
        public CarrierHisDao CarrierHisDao { get { return carrierHisDao; } }
        private SequenceDao sequenceDao = null;
        public SequenceDao SequenceDao { get { return sequenceDao; } }
        private MergeCmdDao mergeCmdDao = null;
        public MergeCmdDao MergeCmdDao { get { return mergeCmdDao; } }
        private MergeCmdHisDao mergeCmdHisDao = null;
        public MergeCmdHisDao MergeCmdHisDao { get { return mergeCmdHisDao; } }

        //config DAO
        private UnitMapDao unitMapDao = null;
        public UnitMapDao UnitMapDao { get { return unitMapDao; } }

        private EqptMapDao eqptMapDao = null;
        public EqptMapDao EqptMapDao { get { return eqptMapDao; } }

        private AlarmMapDao alarmMapDao = null;
        public AlarmMapDao AlarmMapDao { get { return alarmMapDao; } }

        private MainAlarmDao mainAlarmDao = null;
        public MainAlarmDao MainAlarmDao { get { return mainAlarmDao; } }

        private SVDataMapDao svDataMapDao = null;
        public SVDataMapDao SVDataMapDao { get { return svDataMapDao; } }

        private ECDataMapDao ecDataMapDao = null;
        public ECDataMapDao ECDataMapDao { get { return ecDataMapDao; } }

        private PortPosMapDao portPosMapDao = null;
        public PortPosMapDao PortPosMapDao { get { return portPosMapDao; } }

        //Faced
        private RobotCMDUtility robotcmdutility = null;
        public RobotCMDUtility RobotCMDUtility { get { return robotcmdutility; } }
        private RCSFaced rcsfaced = null;
        public RCSFaced RCSFaced { get { return rcsfaced; } }

        //BLL
        private UserBLL userBLL = null;
        public UserBLL UserBLL { get { return userBLL; } }
        private BCSystemBLL bcSystemBLL = null;
        public BCSystemBLL BCSystemBLL { get { return bcSystemBLL; } }
        public LineBLL LineBLL { get { return lineBLL; } }
        private LineBLL lineBLL = null;
        public CarrierBLL CarrierBLL { get { return carrierBLL; } }
        private CarrierBLL carrierBLL = null;
        public AlarmBLL AlarmBLL { get { return alarmBLL; } }
        private AlarmBLL alarmBLL = null;
        private CmdBLL cmdBLL = null;
        public CmdBLL CmdBLL { get { return cmdBLL; } }
        private DcsBLL dcsBLL = null;
        public DcsBLL DcsBLL { get { return dcsBLL; } }
        private SequenceBLL sequenceBLL = null;
        public SequenceBLL SequenceBLL { get { return sequenceBLL; } }

        //WIF
        private BCSystemWIF bcSystemWIF = null;
        public BCSystemWIF BCSystemWIF { get { return bcSystemWIF; } }
        private LineWIF lineWIF = null;
        public LineWIF LineWIF { get { return lineWIF; } }

        //config
        private DataSet indxerConfig = null;
        public DataSet IndxerConfig { get { return indxerConfig; } }

        //INDPositionConfig
        private DataTable indPositionConfig = null;
        public DataTable IndPositionConfig { get { return indPositionConfig; } }

        private DataTable indEqParameters = null;
        public DataTable IndEqParameters { get { return indEqParameters; } }

        private DataTable alarmMap = null;
        public DataTable AlarmMap { get { return alarmMap; } }

        private DataTable mainAlarm = null;
        public DataTable MainAlarm { get { return mainAlarm; } }



        //BackgroundPLCWorkDriver
        public BackgroundWorkDriver BackgroundWorkSample { get; private set; }

        //Event Trx Dictionary
        public Dictionary<string, JobRoute> JobRouteDic = new Dictionary<string, JobRoute>();
        public Dictionary<string, string> ShelfProhibitDic = new Dictionary<string, string>();

        //pool
        public ObjectPool<List<ValueRead>> vEventListPool = new ObjectPool<List<ValueRead>>(() => new List<ValueRead>());
        public ObjectPool<List<ValueWrite>> vWriteList = new ObjectPool<List<ValueWrite>>(() => new List<ValueWrite>());
        public ObjectPool<Dictionary<string, string>> convertValue = new ObjectPool<Dictionary<string, string>>(() => new Dictionary<string, string>());
        public ObjectPool<StringBuilder> stringBuilder = new ObjectPool<StringBuilder>(() => new StringBuilder(""));

        //Socket
        public TCPClientAPI TcpClient;
        public List<UnSendMsg> UnSendToHostMsg = new List<UnSendMsg>();

        public bool bAutoStartFlg = false;

        //gRPC Service
        public ToHostCommand ToHostCommand = null;
        public EAP_K11_E2H.EAP_K11_E2HClient EAP_Client = null;

        //RailChanger Value
        public UInt16 RC_Alive = 0;
    

        private SCApplication()
        {
            init();
        }
        private static BCFApplication.BuildValueEventDelegate buildValueFunc;
        public static SCApplication getInstance(BCFApplication.BuildValueEventDelegate _buildValueFunc)
        {
            buildValueFunc = _buildValueFunc;
            return getInstance();
        }

        public static SCApplication getInstance()
        {
            if (application == null)
            {
                lock (_lock)
                {
                    if (application == null)
                    {
                        application = new SCApplication();
                    }
                    return application;
                }
            }
            return application;

        }

        public MQCApplication getMQCApplication()
        {
            return MQCApplication.getInstance();
        }

        private void init()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(new string('=', 80));
            sb.AppendLine("Do SCApplication Initialize...");
            sb.AppendLine(string.Format("Version: {0}", SCAppConstants.getMainFormVersion("")));
            sb.AppendLine(string.Format("Build Date: {0}", SCAppConstants.GetBuildDateTime().ToString()));
            sb.AppendLine(new string('=', 80));
            logger.Info(sb.ToString());
            sb.Clear();
            sb = null;
            logger_DebugUse = LogManager.GetLogger("DebugUse");
            bcfApplication = BCFApplication.getInstance(buildValueFunc);

            eapSecsAgentName = getString("EAPSecsAgentName", "");
            BC_ID = getString("BC_ID", "INDEXER");

            SystemParameter.SECSConversactionTimeout = getInt("SECSConversactionTimeout", 60);

            initDao();      //Initial DAO
            initBLL();      //Initial BLL
            initConfig();   //Initial Config
            initService();  //Initial Service

            eqptCss = bcfApplication.getEQPTConfigSections();
            nodeFlowRelCss = bcfApplication.getNodeFlowRelConfigSections();
            eqObjCacheManager = EQObjCacheManager.getInstance();
            eqObjCacheManager.setContext(eqptCss, nodeFlowRelCss);

            startBLL();
            initWIF();

            initBackgroundWork();

            initialRestfulServer();

        }

        public void addTipMessege(string msg, string msgLevel)
        {
            switch (msgLevel)
            {
                case "Info":
                    BCFApplication.onInfoMsg(msg);
                    break;
                case "Warning":
                    BCFApplication.onWarningMsg(msg);
                    break;
                case "Error":
                    BCFApplication.onErrorMsg(msg);
                    break;
            }
        }

        private void initialRestfulServer()
        {
            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };
            //NancyHost = new NancyHost(new Uri("http://localhost:3275"), new DefaultNancyBootstrapper(), hostConfigs);
        }

        public void addMsgToSystemConsole(string msg, string msgLevel)
        {
            try
            {
                Line line = getEQObjCacheManager().getLine();
                ConsoleMsg C_Msg = new ConsoleMsg(msg, msgLevel);
                line.SystemConsoleMsgQueue.Enqueue(C_Msg);
                line.onSystemConsoleMsgQueueChange();
                if (BCFUtility.isMatche(msgLevel, SCAppConstants.ConsoleMsgLvl.Info))
                {
                    logger_SystemConsole.Info("[" + C_Msg.recordTime.ToString("yyyy-MM-dd HH:mm:ss.fff ") + "INFO]:" + msg);
                }
                else if (BCFUtility.isMatche(msgLevel, SCAppConstants.ConsoleMsgLvl.Warning))
                {
                    logger_SystemConsole.Warn("[" + C_Msg.recordTime.ToString("yyyy-MM-dd HH:mm:ss.fff ") + "WARNING]:" + msg);
                }
                else if (BCFUtility.isMatche(msgLevel, SCAppConstants.ConsoleMsgLvl.Error))
                {
                    logger_SystemConsole.Error("[" + C_Msg.recordTime.ToString("yyyy-MM-dd HH:mm:ss.fff ") + "ERROR]:" + msg);
                }
                else
                {
                    logger_SystemConsole.Error("Not Defined Message Level!");
                }
                if (line.SystemConsoleMsgQueue.Count >= Convert.ToInt32(SCApplication.getMessageString("SYSTEM_CONSOLE_MSG_CAPACITY")))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (line.SystemConsoleMsgQueue.Count != 0)
                        {
                            line.SystemConsoleMsgQueue.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger_SystemConsole.Error("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff ") + "ERROR]:" + ex.Message);
            }
        }


        private void doHostOnline()
        {

        }

        public void enableAllevent()
        {
            if (bcfApplication.IsReBuildDB)
            {
            }
        }

        public void loadECDataToSystem()
        {
            List<ECDataMap> ecDataMaps = lineBLL.loadDefaultECDataList(null);

            logger.Info(string.Format("ReBuild DB flag:[{0}]", bcfApplication.IsReBuildDB));
            if (bcfApplication.IsReBuildDB && ecDataMaps != null && ecDataMaps.Count > 0)
            {
                string updateEcRtnMsg = string.Empty;
                if (!lineBLL.updateECData(ecDataMaps, out updateEcRtnMsg))
                {
                    logger.Warn(updateEcRtnMsg);
                }
            }

            //Equipment indexerEQPT = eqObjCacheManager.getIndexerEquipment();

            List<ECDataMap> lstECIDTemp = new List<ECDataMap>();
            foreach (ECDataMap ecdataMap in ecDataMaps)
            {
                if (lineBLL.getECData(ecdataMap.ECID) == null)
                {
                    lstECIDTemp.Add(new ECDataMap()
                    {
                        EQPT_REAL_ID = BC_ID,
                        ECID = ecdataMap.ECID.Trim(),
                        ECMIN = ecdataMap.ECMIN.Trim(),
                        ECMAX = ecdataMap.ECMAX.Trim(),
                        ECV = ecdataMap.ECV.Trim(),
                        ECNAME = ecdataMap.ECNAME.Trim()
                    });
                }
            }
            lineBLL.insertNewECData(lstECIDTemp);

            ecDataMaps = lineBLL.loadECDataList(BC_ID);
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            Boolean restartSecsAgent = false;

            foreach (ECDataMap item in ecDataMaps)
            {
                int defaultHostMode = SCAppConstants.LineHostMode.OffLine;

                if (agent != null)
                {
                    if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DEVICE_ID))
                    {
                        if (agent.DeviceID != Convert.ToInt32(item.ECV))
                        {
                            setSECSAgentDeviceID(Convert.ToInt32(item.ECV), false);
                            restartSecsAgent = true;
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T3))
                    {
                        if (agent.T3Timeout != Convert.ToInt32(item.ECV))
                        {
                            setSECSAgentT3Timeout(Convert.ToInt32(item.ECV), false);
                            restartSecsAgent = true;
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T5))
                    {
                        if (agent.T5Timeout != Convert.ToInt32(item.ECV))
                        {
                            setSECSAgentT5Timeout(Convert.ToInt32(item.ECV), false);
                            restartSecsAgent = true;
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T6))
                    {
                        if (agent.T6Timeout != Convert.ToInt32(item.ECV))
                        {
                            setSECSAgentT6Timeout(Convert.ToInt32(item.ECV), false);
                            restartSecsAgent = true;
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T7))
                    {
                        if (agent.T7Timeout != Convert.ToInt32(item.ECV))
                        {
                            setSECSAgentT7Timeout(Convert.ToInt32(item.ECV), false);
                            restartSecsAgent = true;
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T8))
                    {
                        if (agent.T8Timeout != Convert.ToInt32(item.ECV))
                        {
                            setSECSAgentT8Timeout(Convert.ToInt32(item.ECV), false);
                            restartSecsAgent = true;
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_CONVERSATION_TIMEOUT))
                    {
                        if (SystemParameter.SECSConversactionTimeout != Convert.ToInt32(item.ECV))
                        {
                            SystemParameter.setSECSConversactionTimeout(Convert.ToInt32(item.ECV));
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_AUTO_JOB_SWITCH))
                    {
                        if (SystemParameter.AutoJobSwitch != Convert.ToInt32(item.ECV))
                        {
                            SystemParameter.setAutoJobSwitch(Convert.ToInt32(item.ECV));
                        }
                    }
                    else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_GEM_INITIAL_CONTROL_STATE))
                    {
                        try
                        {
                            defaultHostMode = SCAppConstants.LineHostMode.convert2BC(item.ECV.Trim());
                            if (!BCFUtility.isMatche(SystemParameter.InitialControlState, item.ECV))
                            {
                                SystemParameter.setInitialHostMode(item.ECV);
                            }
                        }
                        catch (Exception) { }
                    }
                }

                else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_TACK_TIME_OVER))
                {
                    try
                    {
                        if (!BCFUtility.isMatche(SystemParameter.SheetTackTimeOver, Convert.ToInt32(item.ECV)))
                        {
                            SystemParameter.setSheetTackTimeOver(Convert.ToInt32(item.ECV));
                        }
                    }
                    catch (Exception) { }
                }

                // 加入DCS Parameter的初始化
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_SERIVE_ORDER))
                //{
                //    try
                //    {
                //        SystemParameter.setDCS_ServicesOrder(item.ECV.Trim());
                //    }
                //    catch (Exception) { }
                //}
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_ADVANCE_MOVE))
                //{
                //    try
                //    {
                //        SystemParameter.setDCS_AdvanceMove(item.ECV.Trim());
                //    }
                //    catch (Exception) { }
                //}
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_ADVANCE_GET))
                //{
                //    try
                //    {
                //        SystemParameter.setDCS_DCS_AdvanceGet(item.ECV.Trim());
                //    }
                //    catch (Exception) { }
                //}
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_ARM_PRIORITY))
                //{
                //    try
                //    {
                //        SystemParameter.setDCS_ArmPriority(item.ECV.Trim());
                //    }
                //    catch (Exception) { }
                //}
                //// 加入DCS Parameter的初始化 20150102 By KevinWei End
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_MODE)) 
                //{  
                //    try   
                //    {  
                //        SystemParameter.setDCS_Mode(item.ECV.Trim());
                //    }  
                //    catch (Exception) { }  
                //}
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_SINGLEARM))
                //{   
                //    try     
                //    {     
                //        SystemParameter.setEQPTParameters_SingleArm(item.ECV.Trim());  
                //    }       
                //    catch (Exception) { }
                //}

                else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_HEARTBEAT))
                {
                    try
                    {
                        int hearbeat = 0;
                        int.TryParse(item.ECV.Trim(), out hearbeat);
                        SystemParameter.setHeartBeatSec(hearbeat);
                    }
                    catch (Exception) { }
                }

                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_N2_Pre_Move_Stage))
                //{
                //    try
                //    {
                //        SystemParameter.Dcs_N2PreMoveStage = item.ECV.Trim();
                //    }
                //    catch (Exception) { }
                //}
                //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_N3_Pre_Move_Stage))
                //{
                //    try
                //    {
                //        SystemParameter.Dcs_N3PreMoveStage = item.ECV.Trim();
                //    }
                //    catch (Exception) { }
                //}
            }
            if (restartSecsAgent)
            {
                agent.refreshConnection();
            }
            ITimerAction timer = getBCFApplication().getTimerAction("SECSHeartBeat");
            if (timer != null)
            {
                timer.start();
            }
        }

        #region SECS Agent Parameter Change
        public void setSECSAgentDeviceID(int deviceID, Boolean refresh)
        {
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            agent.setDeviceID(deviceID);
            if (refresh)
            {
                agent.refreshConnection();
            }
        }

        public void setSECSAgentT3Timeout(int t3Timeout, Boolean refresh)
        {
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            agent.setT3(t3Timeout);
            if (refresh)
            {
                agent.refreshConnection();
            }
        }

        public void setSECSAgentT5Timeout(int t5Timeout, Boolean refresh)
        {
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            agent.setT5(t5Timeout);
            if (refresh)
            {
                agent.refreshConnection();
            }
        }

        public void setSECSAgentT6Timeout(int t6Timeout, Boolean refresh)
        {
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            agent.setT6(t6Timeout);
            if (refresh)
            {
                agent.refreshConnection();
            }
        }

        public void setSECSAgentT7Timeout(int t7Timeout, Boolean refresh)
        {
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            agent.setT7(t7Timeout);
            if (refresh)
            {
                agent.refreshConnection();
            }
        }

        public void setSECSAgentT8Timeout(int t8Timeout, Boolean refresh)
        {
            SECSAgent agent = bcfApplication.getSECSAgent(eapSecsAgentName);
            agent.setT8(t8Timeout);
            if (refresh)
            {
                agent.refreshConnection();
            }
        }
        #endregion SECS Agent Parameter Change

        private void initBackgroundWork()
        {
            BackgroundWorkSample = new BackgroundWorkDriver(new BackgroundWorkSample());
        }

        private void initDao()
        {
            lineDao = new LineDao();
            zoneDao = new ZoneDao();
            nodeDao = new NodeDao();
            eqptDao = new EqptDao();
            unitDao = new UnitDao();
            portDao = new PortDao();
            userDao = new UserDao();
            functionCodeDao = new FunctionCodeDao();
            userFuncDao = new UserFuncDao();
            alarmDao = new AlarmDao();
            carrierDao = new CarrierDao();
            bcStatusDao = new BCStatusDao();
            operationHisDao = new OperationHisDao();
            unitMapDao = new UnitMapDao();
            eqptMapDao = new EqptMapDao();
            alarmMapDao = new AlarmMapDao();
            mainAlarmDao = new MainAlarmDao();
            svDataMapDao = new SVDataMapDao();
            ecDataMapDao = new ECDataMapDao();
            userGroupDao = new UserGroupDao();
            cmdMstDao = new CmdMstDao();
            cmdDtlDao = new CmdDtlDao();
            locMstDao = new LocMstDao();
            locDtlDao = new LocDtlDao();
            snoCtlDao = new SnoCtlDao();
            parameterDao = new ParameterDao();
            carrierHisDao = new CarrierHisDao();
            portPosMapDao = new PortPosMapDao();
            sequenceDao = new SequenceDao();
            mergeCmdDao = new MergeCmdDao();
            mergeCmdHisDao = new MergeCmdHisDao();
        }

        public void loadEqParametetsConfig()
        {
            loadCSVToDataTable(ref indEqParameters, "EQPTPARAMETERS");
        }

        public void loadAlarmMapConfig()
        {
            loadCSVToDataTable(ref alarmMap, "ALARMMAP");
        }

        public void loadMainAlarmConfig()
        {
            string MAIN_TABLE_NAME = "MAINALARM";
            string language = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            string main_alarm_path = Environment.CurrentDirectory + @"\Config\" + MAIN_TABLE_NAME + "_" + language + ".csv";
            loadCSVToDataTable(ref mainAlarm, MAIN_TABLE_NAME, main_alarm_path);
        }

        private void initConfig()
        {
            logger.Info("init indxerConfig");

            loadEqParametetsConfig();

            if (indPositionConfig == null)
            {
                loadCSVToDataTable(ref indPositionConfig, "INDPOSITION");
            }
            else
            {
                logger.Info("already init indPositionConfig");
            }

            if (indxerConfig == null)
            {
                indxerConfig = new DataSet();
                logger.Info("new indxerConfig");

                loadCSVToDataset(indxerConfig, "EQPTMAP");
                loadCSVToDataset(indxerConfig, "ONLINEMAP");
                loadCSVToDataset(indxerConfig, "UNITPOSITION");
                loadCSVToDataset(indxerConfig, "UNITMAP");
                loadCSVToDataset(indxerConfig, "DcsListRule");
                loadCSVToDataset(indxerConfig, "DcsMaskRule");
                loadCSVToDataset(indxerConfig, "DcsSortRule");
                loadCSVToDataset(indxerConfig, "SVDATAMAP");
                loadCSVToDataset(indxerConfig, "ECDATAMAP");
                loadCSVToDataset(indxerConfig, "EQPTFUNC");
                loadCSVToDataset(indxerConfig, "PORTPOSMAP");

                //loadAlarmMapConfig();
                //loadMainAlarmConfig();

                logger.Info("init indxerConfig success");
            }
            else
            {
                logger.Info("already init indxerConfig");
            }
        }

        public string getCsvConfigPath()
        {
            return this.getString("CsvConfig", "");
        }

        public string getNatsURL()
        {
            return this.getString("NatsURL", "");
        }

        public string getElasticURL()
        {
            return this.getString("ElasticURL", "");
        }

        private void loadCSVToDataset(DataSet ds, string tableName)
        {
            string csvPath = Environment.CurrentDirectory + this.getString("CsvConfig", "") + tableName + ".csv";
            loadCSVToDataset(ds, tableName, csvPath);
        }

        private void loadCSVToDataset(DataSet ds, string tableName, string path)
        {
            using (GenericParser parser = new GenericParser())
            {
                parser.SetDataSource(path);

                parser.ColumnDelimiter = ',';
                parser.FirstRowHasHeader = true;
                parser.MaxBufferSize = 1024;

                DataTable dt = new System.Data.DataTable(tableName);
                int columnCount = dt.Columns.Count;

                bool isfirst = true;
                int count = 0;
                while (parser.Read())
                {
                    count++;
                    int cs = parser.ColumnCount;
                    if (isfirst)
                    {
                        for (int i = 0; i < cs; i++)
                        {
                            dt.Columns.Add(parser.GetColumnName(i), typeof(string));
                        }
                        isfirst = false;
                    }


                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < cs; i++)
                    {
                        try
                        {
                            string val = parser[i];

                            dr[i] = val;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
            }
        }

        private void loadCSVToDataTable(ref DataTable dt, string tableName, string path)
        {
            using (GenericParser parser = new GenericParser())
            {
                parser.SetDataSource(path, Encoding.Default);

                parser.ColumnDelimiter = ',';
                parser.FirstRowHasHeader = true;
                parser.MaxBufferSize = 1024;

                dt = new System.Data.DataTable(tableName);

                bool isfirst = true;
                while (parser.Read())
                {
                    int cs = parser.ColumnCount;
                    if (isfirst)
                    {
                        for (int i = 0; i < cs; i++)
                        {
                            dt.Columns.Add(parser.GetColumnName(i), typeof(string));
                        }
                        isfirst = false;
                    }


                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < cs; i++)
                    {
                        try
                        {
                            string val = parser[i];

                            dr[i] = val;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
        }

        private void loadCSVToDataTable(ref DataTable dt, string tableName)
        {
            using (GenericParser parser = new GenericParser())
            {
                parser.SetDataSource(Environment.CurrentDirectory + this.getString("CsvConfig", "") + tableName + ".csv");

                parser.ColumnDelimiter = ',';
                parser.FirstRowHasHeader = true;
                parser.MaxBufferSize = 1024;

                dt = new System.Data.DataTable(tableName);

                bool isfirst = true;
                while (parser.Read())
                {

                    int cs = parser.ColumnCount;
                    if (isfirst)
                    {
                        for (int i = 0; i < cs; i++)
                        {
                            dt.Columns.Add(parser.GetColumnName(i), typeof(string));
                        }
                        isfirst = false;
                    }


                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < cs; i++)
                    {
                        string val = parser[i];

                        dr[i] = val;
                    }
                    dt.Rows.Add(dr);
                }
            }
        }

        private void initBLL()
        {
            bcSystemBLL = new BCSystemBLL();
            lineBLL = new LineBLL();
            carrierBLL = new CarrierBLL();
            alarmBLL = new AlarmBLL();
            userBLL = new UserBLL();
            cmdBLL = new CmdBLL();
            dcsBLL = new DcsBLL();
            sequenceBLL = new SequenceBLL();

            //Robot CMD 產生使用
            rcsfaced = new RCSFaced();
            robotcmdutility = new RobotCMDUtility();
        }

        public void initService()
        {
            //eqptService = new EqptService();
            //lineService = new LineService();
        }

        private void startBLL()
        {
            bcSystemBLL.start(this);
            lineBLL.start(this);
            carrierBLL.start(this);
            alarmBLL.start(this);
            userBLL.start(this);
            cmdBLL.start(this);
            dcsBLL.start(this);
            sequenceBLL.start(this);

            rcsfaced.start(this);
            robotcmdutility.start(this);
        }

        private void initWIF()
        {
            bcSystemWIF = new BCSystemWIF(this);
            lineWIF = new LineWIF(this);
        }

        public BCFApplication getBCFApplication()
        {
            return bcfApplication;
        }

        private int getInt(string key, int defaultValue)
        {
            int rtn = defaultValue;
            try
            {
                rtn = Convert.ToInt32(ConfigurationManager.AppSettings.Get(key));
            }
            catch (Exception e)
            {
                logger.Warn("Get Config error[key:{0}][Exception:{1}]", key, e);
            }
            return rtn;
        }

        private long getLong(string key, long defaultValue)
        {
            long rtn = defaultValue;
            try
            {
                rtn = long.Parse(ConfigurationManager.AppSettings.Get(key));
            }
            catch (Exception e)
            {
                logger.Warn("Get Config error[key:{0}][Exception:{1}]", key, e);
            }
            return rtn;
        }

        private string getString(string key, string defaultValue)
        {
            string rtn = defaultValue;
            try
            {
                rtn = ConfigurationManager.AppSettings.Get(key);
            }
            catch (Exception e)
            {
                logger.Warn("Get Config error[key:{0}][Exception:{1}]", key, e);
            }
            return rtn;
        }

        public DBConnection getDBConnection()
        {
            return getBCFApplication().getDBConnection();
        }

        public DBConnection getDBStatelessConnection()
        {
            return getBCFApplication().getDBStatelessConnection();
        }

        private IShareMemoryInitProcess shareMemInitProc;

        private void injectValueDefMapAction(BaseMapActionConfigElement config, ref BaseEQObject baseEQObject)
        {
            List<string> subMapActs = config.ValueDefMapActionClasses.Split(
                            new string[] { ";" },
                            StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string mapAct in subMapActs)
            {
                try
                {
                    Type mapActType = Type.GetType(mapAct.Trim(), true);

                    IValueDefMapAction valMapAct =
                        (IValueDefMapAction)Activator.CreateInstance(mapActType);
                    baseEQObject.injectValueDefMapAction(valMapAct);
                }
                catch (Exception ex)
                {
                    logger.Warn(String.Format("Not Found ValueDefMapAction Class : {0}", mapAct), ex);
                    throw new Exception(String.Format("Not Found ValueDefMapAction Class : {0}", mapAct));
                }
            }
        }

        public Boolean canSelRevertSystem()
        {
            SCAppConstants.BCSystemInitialRtnCode rtnCode = application.bcSystemBLL.initialBCSystem();
            if (rtnCode == SCAppConstants.BCSystemInitialRtnCode.Error)
            {
                throw new Exception("Initial BC System Occur Error !!");
            }
            if (rtnCode == SCAppConstants.BCSystemInitialRtnCode.NonNormalShutdown)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 必須呼叫此method進行建立Equipment
        /// </summary>
        public void startBuildEqpts(Boolean recoverFromDB)
        {

            eqObjCacheManager.start(recoverFromDB);      //啟動EQ Object Cache.. 將從DB取得Line資訊建立EQ Object

            string shareMemoryInitClass = eqptCss.ShareMemoryInitClass;
            try
            {
                Type shareMemoryInitType = Type.GetType(shareMemoryInitClass.Trim(), true);
                shareMemInitProc =
                    (IShareMemoryInitProcess)Activator.CreateInstance(shareMemoryInitType);
            }
            catch
            {
                logger.Warn("Not Found ShareMemoryInitProcess Class : {0}", shareMemoryInitClass);
            }

            foreach (var config in eqptCss.ConfigSections)
            {
                string line_id = config.Line_ID;
                BaseEQObject line = eqObjCacheManager.getLine();
                if (line == null || !BCFUtility.isMatche(line_id, (line as Line).Line_ID))
                {
                    logger.Warn("MapActionDefs occur error: System Not Define Line[{0}]", line_id);
                    break;
                }
                injectValueDefMapAction(config, ref line);
                foreach (ZoneConfigSection zoneConfig in config.ZoneConfigList)
                {
                    string zone_id = zoneConfig.Zone_ID;
                    BaseEQObject zone = eqObjCacheManager.getZoneByZoneID(zone_id);
                    injectValueDefMapAction(zoneConfig, ref zone);
                    foreach (NodeConfigSection nodeConfig in zoneConfig.NodeConfigList)
                    {
                        string node_id = nodeConfig.Node_ID;
                        BaseEQObject node = eqObjCacheManager.getNodeByNodeID(node_id);
                        injectValueDefMapAction(nodeConfig, ref node);
                        foreach (EQPTConfigSection eqptConfig in nodeConfig.EQPTConfigList)
                        {
                            string eqpt_id = eqptConfig.EQPT_ID;
                            BaseEQObject eqpt = eqObjCacheManager.getEquipmentByEQPTID(eqpt_id);
                            injectValueDefMapAction(eqptConfig, ref eqpt);
                            foreach (UnitConfigSection unitConfig in eqptConfig.UnitConfigList)
                            {
                                string unit_id = unitConfig.Unit_ID;
                                BaseEQObject unit = eqObjCacheManager.getUnitByUnitID(unit_id);
                                injectValueDefMapAction(unitConfig, ref unit);
                            }
                            foreach (PortConfigSection portConfig in eqptConfig.PortConfigList)
                            {
                                string port_id = portConfig.Port_ID;
                                BaseEQObject port = eqObjCacheManager.getPortByPortID(port_id);
                                injectValueDefMapAction(portConfig, ref port);
                            }
                            //foreach (BufferConfigSection buffConfig in eqptConfig.BuffConfigList)
                            //{
                            //    string buff_id = buffConfig.Buff_ID;
                            //    BaseEQObject buff = eqObjCacheManager.getBuffByBuffID(buff_id);
                            //    injectValueDefMapAction(buffConfig, ref buff);
                            //}
                        }
                    }
                }
            }
        }

        public EQObjCacheManager getEQObjCacheManager()
        {
            return eqObjCacheManager;
        }

        /// <summary>
        /// 根據Equipment的腳本進行初始化
        /// </summary>
        private void initScriptForEquipment()
        {
            try
            {
                if (shareMemInitProc != null)
                {
                    shareMemInitProc.doInit();
                }

                Line line = eqObjCacheManager.getLine();
                foreach (BCFAppConstants.RUN_LEVEL runLevel in Enum.GetValues(typeof(BCFAppConstants.RUN_LEVEL)))
                {
                    line.doShareMemoryInit(runLevel);
                }
            }
            catch (Exception e)
            {
                logger.ErrorException("Initial Equipment Object Error!", e);
                throw;
            }
        }

        private Boolean started = false;
        /// <summary>
        /// 是否已啟動SC Timer
        /// </summary>
        public Boolean Started { get { return started; } }

        private void startProcess()
        {
            initScriptForEquipment();

            try
            {
                //Start EAP GRPC
                string mcs_ip = ConfigurationManager.AppSettings["Host_Sever_IP"];
                int mcs_port = int.Parse(ConfigurationManager.AppSettings["Host_Sever_Port"]);

                Channel eapChannel = new Channel(mcs_ip, mcs_port, ChannelCredentials.Insecure);
                EAP_Client = new EAP_K11_E2H.EAP_K11_E2HClient(eapChannel);

                Task.Run(async () => await gRPC_Server_StartAsync());
                ToHostCommand = new ToHostCommand(this);

            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:startProcess][Exception:{0}]", ex.ToString());
                return;
            }
        }

        private void sendEQOnLine(object obj)
        {
            try
            {


            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:{0}");
            }
        }

        /// <summary>
        /// 啟動Share Memory，與指定MPLC通訊
        /// </summary>
        /// <param name="mplcName"></param>
        public void startShareMemory(string mplcName)
        {
            lock (_lock)
            {
                if (started == false)
                    return;
                bcfApplication.startShareMemory(mplcName);
                logger.Info("Start Share Memory");
            }
        }

        /// <summary>
        /// 啟動Share Memory，與所有MPLC通訊
        /// </summary>
        public void startShareMemory()
        {
            lock (_lock)
            {
                if (started == false)
                    return;
                bcfApplication.startShareMemory();
                logger.Info("Start Share Memory");
            }
        }

        /// <summary>
        /// 啟動SECS Agent
        /// </summary>
        public void startSECSAgent()
        {
            lock (_lock)
            {
                if (started == false)
                    return;
                bcfApplication.startAllSECSAgent();
                logger.Info("Start SECS Agent");
            }
        }

        /// <summary>
        /// 開始執行
        /// </summary>
        public void start()
        {
            lock (_lock)
            {
                if (started == true)
                    return;
                bcfApplication.start(startProcess);
                //NancyHost.Start();
                logger.Info("Start Application");
                started = true;
            }
        }

        /// <summary>
        /// 停止Share Memory，與指定MPLC停止通訊
        /// </summary>
        /// <param name="mplcName"></param>
        public void stopShareMemory(string mplcName)
        {
            lock (_lock)
            {
                bcfApplication.stopShareMemory(mplcName);
                logger.Info("Stop Share Memory");
            }
        }

        /// <summary>
        /// 停止Share Memory，與所有MPLC停止通訊
        /// </summary>
        public void stopShareMemory()
        {
            lock (_lock)
            {
                bcfApplication.stopShareMemory();
                logger.Info("Stop Share Memory");
            }
        }

        /// <summary>
        /// 停止SECS Agent
        /// </summary>
        public void stopSECSAgent()
        {
            lock (_lock)
            {
                bcfApplication.stopAllSECSAgent();
                logger.Info("Stop SECS Agent");
            }
        }

        private void stopProcess()
        {

        }

        /// <summary>
        /// 停止執行
        /// </summary>
        public void stop()
        {
            lock (_lock)
            {
                Process.GetCurrentProcess().Kill();

                if (started == false)
                    return;
                bcfApplication.stop(stopProcess);
                //NancyHost.Stop();
                logger.Info("Stop Application");
                started = false;
                Application.Exit();
            }
        }

        public static string getMessageString(string key, params object[] args)
        {
            return BCFApplication.getMessageString(key, args);
        }

        public Boolean isSortLineMPC()
        {
            return BCFUtility.isMatche(getBCFApplication().BC_ID, "1ASS01");
        }

        object updateTraceCountToExcel_obj = new object();
        public void updateTraceCountToExcel(bool bSystemStart)
        {
            lock (updateTraceCountToExcel_obj)
            {
                StreamWriter csvCreateFile = null;
                StreamReader csvFile = null;
                StreamWriter csvTmpFile = null;

                try
                {
                    //檢查excel是否存在
                    if (Directory.Exists(@"D:\SystemTrace\"))
                    {
                        //資料夾存在
                    }
                    else
                    {
                        //新增資料夾
                        Directory.CreateDirectory(@"D:\SystemTrace\");
                    }


                    string curFile = @"D:\SystemTrace\SystemWorkTrace.csv";

                    if (!File.Exists(curFile))
                    {
                        //建立檔案
                        string columnTitle = "System Start Time,System End Time,WIP Count";
                        File.WriteAllText(curFile, columnTitle);
                    }

                    //update system time
                    if (bSystemStart)
                    {
                        String columnDate = DateTime.Now.ToString(SCAppConstants.DateTimeFormat_19) + "," + DateTime.Now.ToString(SCAppConstants.DateTimeFormat_19) + ",0";
                        File.AppendAllText(curFile, Environment.NewLine + columnDate);
                        SCApplication.getInstance().getEQObjCacheManager().getLine().TraceSystemRunShtCountToExcel = 0;
                    }
                    else
                    {
                        string tmpFile = @"D:\SystemTrace\SystemWorkTrace_tmp.csv";

                        csvFile = new StreamReader(curFile);
                        csvTmpFile = new StreamWriter(tmpFile);

                        String readLine = csvFile.ReadLine();

                        while (!csvFile.EndOfStream)
                        {
                            csvTmpFile.WriteLine(readLine);
                            readLine = csvFile.ReadLine();
                        }

                        var value = readLine.Split(',');
                        String newLine = value[0] + "," + DateTime.Now.ToString(SCAppConstants.DateTimeFormat_19) + "," +
                            SCApplication.getInstance().getEQObjCacheManager().getLine().TraceSystemRunShtCountToExcel.ToString();

                        csvTmpFile.WriteLine(newLine);

                        csvFile.Close();
                        csvTmpFile.Close();
                        csvFile = null;
                        csvTmpFile = null;

                        File.Delete(curFile);
                        File.Move(tmpFile, curFile);
                    }
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger("System Log").Error(ex.ToString());
                }
                finally
                {
                    if (csvCreateFile != null)
                    {
                        csvCreateFile.Close();
                    }

                    if (csvFile != null)
                    {
                        csvFile.Close();
                    }

                    if (csvTmpFile != null)
                    {
                        csvTmpFile.Close();
                    }
                }

            }

        }

        private System.Collections.Concurrent.ConcurrentDictionary<string, ObjectPool<PLC_FunBase>> dicPLC_FunBasePool =
            new System.Collections.Concurrent.ConcurrentDictionary<string, ObjectPool<PLC_FunBase>>();
        public PLC_FunBase getFunBaseObj<T>(string _id)
        {
            string type_name = typeof(T).Name;

            ObjectPool<PLC_FunBase> plc_funbase = dicPLC_FunBasePool.GetOrAdd(type_name, new ObjectPool<PLC_FunBase>(() => (PLC_FunBase)Activator.CreateInstance(typeof(T))));

            PLC_FunBase fun_base = plc_funbase.GetObject();
            fun_base.initial(_id);
            return fun_base;
        }

        public void putFunBaseObj<T>(PLC_FunBase put_obj)
        {
            if (put_obj == null) return;
            string type_name = typeof(T).Name;
            if (!dicPLC_FunBasePool.Keys.Contains(type_name))
            {
                return;
            }
            dicPLC_FunBasePool[type_name].PutObject(put_obj);
        }

        Object _prohibitLock = new Object();
        public void addProhibitShelf(string loc, string event_type)
        {
            lock (_prohibitLock)
            {
                try
                {
                    if (ShelfProhibitDic.ContainsKey(loc))
                    {
                        ShelfProhibitDic[loc] = event_type;
                    }
                    else
                    {
                        ShelfProhibitDic.Add(loc, event_type);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("Reply Error[Function:addPrihibitShelf][Exception:{0}]", ex.ToString());
                    return;
                }
            }
        }

        Object _cmdWaitLock = new Object();

        #region Scan Socket
        private bool initSocket()
        {
            try
            {
                Socket_Connect(true);
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:initSocket][Exception:{0}]", ex.ToString());
                return false;
            }

            return true;
        }

        public void Socket_Connect(bool initial)
        {
            try
            {
                string HostSocketServerIP = getString(SCAppConstants.Host_Sever_IP, "192.168.0.1");
                int HostSocketServerPort = getInt(SCAppConstants.Host_Sever_Port, 6000);
                int HostSocketServerTimeout = getInt(SCAppConstants.Host_Sever_Timeout, 3000);

                TcpClient = TCPClientAPI.Instance;

                if (initial)
                {
                    TcpClient.PropertyChanged += Socket_PropertyChanged;
                }

                TcpClient.ServerIP = HostSocketServerIP;
                TcpClient.ServerPort = HostSocketServerPort;
                TcpClient.ConnectionTimeoutMs = HostSocketServerTimeout;

                TcpClient.Connect(HostSocketServerIP, HostSocketServerPort, HostSocketServerTimeout);

                ConnectJson connJson = new ConnectJson();
                connJson.iPAddress = GetLocalIPAddress();
                //connJson.Subject = System.Environment.MachineName;
                connJson.Subject = "AutoChange";
                string json_string = JsonConvert.SerializeObject(connJson);
                TcpClient.SendAsync(json_string);
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:Socket_Connect][Exception:{0}]", ex.ToString());
            }
        }

        public static string GetLocalIPAddress()
        {
            string local_ip = string.Empty;

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        local_ip = ip.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:GetLocalIPAddress][Exception:{0}]", ex.ToString());
            }

            return local_ip;
        }

        public virtual async Task SendAndReceiveAsync(string json_string, string teid, string cmd_no)
        {
            try
            {
                if (!TcpClient.IsSocketAlive) return;
                var cancellationTokenSource = new CancellationTokenSource();
                await Task.Run(async () =>
                {
                    string result = await Task.Run(async () => await TcpClient.SendAndReceiveAsync(json_string, teid, cancellationTokenSource));
                    if (result is "Good")
                    {
                    }
                    else
                    {
                        UnSendMsg msg = new UnSendMsg();
                        msg.Cmd_No = cmd_no;
                        msg.TEID = teid;
                        msg.Msg = json_string;

                        UnSendToHostMsg.Add(msg);
                    }

                    //if (cancellationTokenSource.IsCancellationRequested) cancellationTokenSource.Token.ThrowIfCancellationRequested();
                }, cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:SendAndReceiveAsync][Exception:{0}]", ex.ToString());
            }
        }

        //A0.01 Start
        public virtual async Task SendAndReceiveAsyncForResend(UnSendMsg msg)
        {
            try
            {
                if (!TcpClient.IsSocketAlive) return;
                var cancellationTokenSource = new CancellationTokenSource();
                await Task.Run(async () =>
                {
                    string result = await Task.Run(async () => await TcpClient.SendAndReceiveAsync(msg.Msg, msg.TEID, cancellationTokenSource));
                    if (result is "Good")
                    {
                        UnSendToHostMsg.Remove(msg);
                    }
                }, cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:SendAndReceiveAsync][Exception:{0}]", ex.ToString());
            }
        }

        private void CimStat_Update(object obj)
        {
            try
            {
                int? cim_stat = obj as int?;
                getEQObjCacheManager().getLine().CIM_Link_Stat = cim_stat ?? SCAppConstants.LinkStatus.Link_Fail;
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:CimStat_Update][Exception:{0}]", ex.ToString());
            }
        }
        //A0.01 End

        public void Socket_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName is nameof(TcpClient.IsSocketAlive))
                {
                    if (TcpClient.IsSocketAlive)
                    {
                        //ConnectJson connJson = new ConnectJson();
                        //connJson.iPAddress = GetLocalIPAddress();
                        ////connJson.Subject = System.Environment.MachineName;
                        //connJson.Subject = "AutoChange";
                        //string json_string = JsonConvert.SerializeObject(connJson);
                        //TcpClient.SendAsync(json_string);

                        //Task.Run(async () => await receiveCIM());
                    }
                    else
                    {
                        System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(CimStat_Update), SCAppConstants.LinkStatus.Link_Fail);  //A0.01
                        logger.Error("Host Connection Failed");
                    }
                }
                //else if (e.PropertyName is nameof(TcpClient.ClientStatus))
                //{
                //    string status = TcpClient.ClientStatus;
                //    if (status is "Connected") { }
                //    else if (status is "RetryConnection") { }
                //}
            }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:Socket_PropertyChanged][Exception:{0}]", ex.ToString());
            }
        }

        private async Task receiveCIM()
        {
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(CimStat_Update), SCAppConstants.LinkStatus.Link_OK);  //A0.01

                var ct = TCPClientAPI.CTSReceive.Token;
                await Task.Factory.StartNew(() =>
                {
                    ct.ThrowIfCancellationRequested();
                    foreach (var message in TcpClient.BCReceivedMessages.GetConsumingEnumerable(ct))
                    {
                        if (message != null && !SCUtility.isEmpty(message))
                        {
                            BaseSendJson msg = JsonConvert.DeserializeObject<BaseSendJson>(message);

                            if (msg.FUNCTIONSEQUENCENO == null || SCUtility.isEmpty(msg.FUNCTIONSEQUENCENO))
                            {
                                SCUtility.ConvertMQMsg(SCUtility.FUNCTION_TRANSDFERTYPE_RECEIVE_FROM_HOST, string.Empty, message);
                            }
                            else
                            {
                                SCUtility.ConvertMQMsg(SCUtility.FUNCTION_TRANSDFERTYPE_RECEIVE_FROM_HOST, msg.FUNCTIONSEQUENCENO, message);
                            }
                        }

                        if (ct.IsCancellationRequested) ct.ThrowIfCancellationRequested();
                    }
                }, TCPClientAPI.CTSReceive.Token, TaskCreationOptions.LongRunning | TaskCreationOptions.PreferFairness, TaskScheduler.Default);
            }
            catch (ObjectDisposedException ode) { }
            catch (OperationCanceledException oce) { }
            catch (Exception ex)
            {
                logger.Error("Reply Error[Function:receiveCIM][Exception:{0}]", ex.ToString());
            }
        }

        #endregion Scan Socket

        /// <summary>
        /// 啟動gRPC Server
        /// </summary>
        public async Task gRPC_Server_StartAsync()
        {
            var server = new Server()
            {
                Services = { EAP_K11_H2E.BindService(new ReceiveHostCommad(this)) },
                Ports = { new ServerPort(IPAddress.Any.ToString(), int.Parse(ConfigurationManager.AppSettings["gRPC_Sever_Port"]), ServerCredentials.Insecure) }
            };
            server.Start();
            //await server.ShutdownAsync();
        }
    }

    public class SystemParameter
    {
        //System EC Data 
        public static int SECSConversactionTimeout = 60;
        public static string InitialControlState = CmdConst.CRST_Off_Line;
        public static int SheetTackTimeOver = 60;
        public static int AutoJobSwitch = 0;
        public static int HeartBeatSec = 0;
        private static string dcs_N3PreMoveStage = "1";

        public static string Dcs_N3PreMoveStage
        {
            get { return dcs_N3PreMoveStage; }
            set { dcs_N3PreMoveStage = value; }
        }
        private static string dcs_N2PreMoveStage = "1";
        public static string Dcs_N2PreMoveStage
        {
            get { return dcs_N2PreMoveStage; }
            set { dcs_N2PreMoveStage = value; }
        }

        public static bool IsNeed_Move_To = false;
        public static bool IsAboted_Finish_Job = false;
        /// <summary>
        /// 用來存入當Robot剩一一隻手臂能夠使用時，是哪隻手臂能使用。
        /// (預設為None，代表兩隻手臂皆可使用)
        /// </summary>
        public static int SingleArm = SCAppConstants.RobotArm.None;
        /// <summary>
        /// 判斷當EQ Status : Down / Matin的時候，是否要繼續對EQ執行取片的動作。
        /// </summary>
        public static bool IsForce_Get = false;
        /// <summary>
        /// 判斷當EQ Status : Down / Matin的時候，是否要繼續對EQ執行送片的動作。
        /// </summary>
        public static bool IsForce_Put = false;

        /// <summary>
        /// 判斷是否要使用Auto PM Mode(當EQ Down時，會自動將PM Mode開啟)
        /// </summary>
        public static bool IsAuto_PMMode = false;

        /// <summary>
        /// 判斷當前的線是否有使用QTime的控制。(DCS_Mode需要是EffectiveMode才可以使用)
        /// </summary>
        private static bool isqtime_control = false;
        public static bool IsQTime_Control
        {
            get
            {
                return isqtime_control /*&& SCUtility.isMatche(DCS_Mode, SCAppConstants.DCS_Mode.EffectiveMode)*/;
            }
            set
            {
                isqtime_control = value;
            }
        }

        /// <summary>
        /// 判斷當前的線是否有使用Job_Priority的控制。(DCS_Mode需要是EffectiveMode才可以使用)
        /// </summary>
        private static bool isjob_priority = false;
        public static bool IsJob_Priority
        {
            get
            {
                return isjob_priority /*&& SCUtility.isMatche(DCS_Mode, SCAppConstants.DCS_Mode.EffectiveMode)*/;
            }
            set
            {
                isjob_priority = value;
            }
        }

        public static void setSECSConversactionTimeout(int timeout)
        {
            SECSConversactionTimeout = timeout;
        }

        public static void setInitialHostMode(string hostMode)
        {
            InitialControlState = hostMode;
        }

        public static void setSheetTackTimeOver(int sheetTackTimeOver)
        {
            SheetTackTimeOver = sheetTackTimeOver;
        }

        public static void setAutoJobSwitch(int autoJobSwitch)
        {
            AutoJobSwitch = autoJobSwitch;
        }

        public static void setHeartBeatSec(int heartBeatSec)
        {
            HeartBeatSec = heartBeatSec;
        }

        public static void setEQPTParameters_NeedMoveTo(string need_move_to)
        {
            bool isNeedMove = SCUtility.isMatche(SCAppConstants.YES_FLAG, need_move_to);
            IsNeed_Move_To = isNeedMove;
        }
        public static void setEQPTParameters_Aborted_Finish_Job(string abort_fninsj_job)
        {
            bool isAbortFninshJob = SCUtility.isMatche(SCAppConstants.YES_FLAG, abort_fninsj_job);
            IsAboted_Finish_Job = isAbortFninshJob;
        }

        public static void setEQPTParameters_ForceGet(string force_get)
        {
            bool isForceGet = SCUtility.isMatche(SCAppConstants.YES_FLAG, force_get);
            IsForce_Get = isForceGet;
        }
        public static void setEQPTParameters_ForcePut(string force_put)
        {
            bool isForcePut = SCUtility.isMatche(SCAppConstants.YES_FLAG, force_put);
            IsForce_Put = isForcePut;
        }

        public static void setEQPTParameters_AutoPMMode(string auto_pm_mode)
        {
            bool isAuto_PMMode = SCUtility.isMatche(SCAppConstants.YES_FLAG, auto_pm_mode);
            IsAuto_PMMode = isAuto_PMMode;
        }

        public static void setEQPTParameters_QTimeControl(string qtimecontrol)
        {
            bool isqtime_control = SCUtility.isMatche(SCAppConstants.YES_FLAG, qtimecontrol);
            IsQTime_Control = isqtime_control;
        }

        public static void setEQPTParameters_JobPriority(string jobpriority)
        {
            bool isjob_priority = SCUtility.isMatche(SCAppConstants.YES_FLAG, jobpriority);
            IsJob_Priority = isjob_priority;
        }

        /// <summary>
        /// 設置IsSingleArm的Flag
        /// </summary>
        /// <param name="is_single_arm"></param>
        public static void setEQPTParameters_SingleArm(string is_single_arm)
        {
            int single_arm = SCAppConstants.RobotArm.None;
            if (int.TryParse(is_single_arm, out single_arm))
            {
                SingleArm = single_arm;
            }
            else
            {
                //Not Thing...
            }
        }





    }

}
