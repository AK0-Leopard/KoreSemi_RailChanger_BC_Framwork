//*********************************************************************************
//      RCSFaced.cs
//*********************************************************************************
// File Name: RCSFaced.cs
// Description: Robot Command Faced(DAO、Value Read對外訪問層)
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************

using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Common.MPLC;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.BLL;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.sc.ValueHandler.Vo;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Common
{
    public class RCSFaced
    {
        RobotCMDUtility RCU = null;
        RobotCommandTable CMDVo = null;
        protected SCApplication scApp = null;
        protected BCFApplication bcfApp = null;
        protected MPLCSMControl smControl;
        ISMControl mplcControl;
        static int robotCancelCMDCount = 0;

        protected static Logger logger_RobotCMD = LogManager.GetLogger("RobotCommandSystem");
        protected static Logger logger_Exception = LogManager.GetLogger("MapActioLog");

        protected Equipment eqpt_IND = null;

        //提供紀錄Robot 下命令中的各段時間
        public DateTimeOffset? Start_WritePLC;

        public RCSFaced()
        {
            
        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            RCU = scApp.RobotCMDUtility;
            smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;
            mplcControl = scApp.getBCFApplication().getMPLCSMControl("EQ");

            bcfApp = scApp.getBCFApplication();
        }

        public bool createRobotCommandTable(RobotCommandTable _CMDVo, string eqpt_id)
        {
            //更新DB(Robot CMDTable 的 CMD Gen Time=Current Time、CMD STAT=1)
            if (_CMDVo == null)
                return false;
            try
            {
                if (eqpt_IND == null)
                    eqpt_IND = scApp.getEQObjCacheManager().getEquipmentByEQPTID(eqpt_id);

                _CMDVo.Command_Gen_Time = DateTimeOffset.Now;
                _CMDVo.Seq_No = scApp.SequenceBLL.getRobotCMDNumberString();

                if (_CMDVo.Seq_No == SCAppConstants.ROBOTCMD_SEQUENCE_NUMBER_MIN)
                {
                    RCU.deleteEndOrCancelRobotCMD();
                }

                scApp.RobotCMDUtility.SetRobotCMDTableDB(_CMDVo, eqpt_id);
                logger_RobotCMD.Info("=========Gen Robot CommandTable Success=========");
                scApp.DcsBLL.HasCMDExecute(eqpt_id);
                return true;
            }
            catch (Exception ex)
            {
                logger_RobotCMD.Error(string.Format("=========Gen Robot CommandTable Failed=========,[{0}]", ex));
                return false;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private Boolean deleteALLRobotCMD()
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBStatelessConnection();
                conn.BeginTransaction();
                conn.StatelessSess.SetBatchSize(300);

                scApp.RobotCMDUtility.deleteAllRobotCMDTable(conn);
                scApp.RobotCMDUtility.deleteAllRobotCMDLst(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger_RobotCMD.Warn("deleteALLRobotCMD Failed !!", ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;

        }

        private bool IsFromToPort(string FromToEq)
        {
            return FromToEq.StartsWith("CAS");
        }

        public void robotArmNotInArm()
        {

        }

        public void ManulCanel()
        {

        }

        public RobotCommandTable createRobotCMD(int gen_source, string crr_id, string from_loc, string to_loc, string use_arm, int priority, string eqpt_id, string cmd_sno, string user_id)
        {
            RobotCommandTable CMDVo = new RobotCommandTable();
            DateTime NowTime = DateTime.Now;
            CMDVo.Gen_Source = gen_source;
            CMDVo.Crr_ID = crr_id;
            CMDVo.Seq_No_Year = NowTime.Year;
            CMDVo.Seq_No_Month = NowTime.Month;
            CMDVo.Seq_No_Day = NowTime.Day;
            CMDVo.Seq_No_Hour = NowTime.Hour;
            CMDVo.From_Loc = from_loc;
            CMDVo.To_Loc = to_loc;
            CMDVo.Command_Gen_Time = NowTime;
            CMDVo.Command_Send_Time = null;
            CMDVo.Command_Start_Time = null;
            CMDVo.Command_End_Time = null;
            CMDVo.Command_Status = (int)SCAppConstants.RobotCMDStatus.Gen;
            CMDVo.Command_Excute_Retune_Code = null;
            CMDVo.Command_Prioty = priority;
            CMDVo.UsingArm = use_arm;
            CMDVo.Stk_ID = eqpt_id;
            CMDVo.Cmd_Sno = cmd_sno;
            CMDVo.User_ID = user_id;

            return CMDVo;
        }
    }
}
