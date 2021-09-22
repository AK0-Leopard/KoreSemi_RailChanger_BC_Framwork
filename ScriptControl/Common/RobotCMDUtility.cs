//*********************************************************************************
//      RobotCMDUtility.cs
//*********************************************************************************
// File Name: RobotCMDUtility.cs
// Description: Robot Command Utility
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/02/24    Steven Hong    N/A            A0.01   增加Shelf To Shelf命令查詢
// 2021/03/02    Steven Hong    N/A            A0.02   修正同時執行複數命令，命令結束錯誤問題
//                                                     增加根據Carreier ID查詢命令
// 2021/03/15    Steven Hong    N/A            A0.03   新增查詢未執行Robot Command
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace com.mirle.ibg3k0.sc.Common
{
    public class RobotCMDUtility
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected SCApplication scApp = null;
        protected Equipment eqpt_IND = null;


        public RobotCMDUtility()
        {
        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
        }

        public void SetRobotCMDTableDB(RobotCommandTable CMDVo, string eqpt_id)
        {
            eqpt_IND = scApp.getEQObjCacheManager().getEquipmentByEQPTID(eqpt_id);
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                RobotCommandTableDao.insertRobotCMD(conn, CMDVo);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void UpdateRobotCMDTableDB(RobotCommandTable CMDVo, string eqpt_id)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                eqpt_IND = scApp.getEQObjCacheManager().getEquipmentByEQPTID(eqpt_id);
                conn.BeginTransaction();
                RobotCommandTableDao.updateRobotCMD(conn, CMDVo);
                conn.Commit();
                eqpt_IND.RobotTableChange = true;
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

        }

        public void UpdateRobotCMDTableDB_CMDSendTime(RobotCommandTable CMDVo)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                CMDVo.Command_Send_Time = DateTime.Now;
                RobotCommandTableDao.updateRobotCMD(conn, CMDVo);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void UpdateRobotCMDTableDB_CMDStartTime(RobotCommandTable CMDVo)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                CMDVo.Command_Start_Time = DateTime.Now;
                RobotCommandTableDao.updateRobotCMD(conn, CMDVo);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void UpdateRobotCMDTableDB_CMDEndTime(RobotCommandTable CMDVo)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                CMDVo.Command_End_Time = DateTime.Now;
                RobotCommandTableDao.updateRobotCMD(conn, CMDVo);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void deleteCMDTableDBbySeqNo(int SeqNo)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                RobotCommandTableDao.deleteRobotCMDbySeqNo(conn, SeqNo);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        /// <summary>
        /// 刪除所有Robot CMD Table
        /// </summary>
        public void deleteAllRobotCMDTable(DBConnection conn)
        {
            Boolean isBatch = (conn != null);

            try
            {
                if (!isBatch)
                {
                    conn = scApp.getDBConnection();
                    conn.BeginTransaction();
                } 
                RobotCommandTableDao.deleteAllRobotCMD(conn);
                if (!isBatch)
                {
                    conn.Commit();
                }
            }
            catch (Exception ex)
            {
                if (!isBatch && conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn(ex);
            }
            finally
            {
                if (!isBatch && conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void deleteEndOrCancelRobotCMD()
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                List<RobotCommandTable> delRobotCMDLst = RobotCommandTableDao.loadEndOrCancelRobotCMD(conn);

                foreach(RobotCommandTable cmd in delRobotCMDLst)
                {
                    RobotCommandTableDao.deleteRobotCMDbySeqNo(conn, cmd.Seq_No);
                    RobotCommandListDao.deleteRobotCMDListbySeqNo(conn, cmd.Seq_No);
                }

                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public RobotCommandTable QueryCMDTableDBbySeqNo(int SeqNo)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                return RobotCommandTableDao.getRobotCMDbySeqNo(conn, true, SeqNo);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public int QueryCMDTableDBMaxSeqNo()
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                return RobotCommandTableDao.getRobotCMDSeqNoMax(conn, true);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return 0;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public int[] QueryCMDTableDBAllNotExcuteOfSeqNo()
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getRobotCMDAllNotExcuteOfSeqNo(conn, true);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public RobotCommandTable QueryCMDTableDBbyFirstExctue(string stk_id)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getRobotCMDbyFirstExctue(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> QueryAllCMDTable()
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadAllRobotCMD(conn);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> QueryCMDTableDB(string stk_id)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadRobotCMD(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> QueryManualCMDTableDB(string stk_id)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadManualRobotCMD(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public RobotCommandTable QueryCMDTableDBbyPortNo(string port_id)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getRobotCMDbyPortNO(conn, port_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public RobotCommandTable QueryCMDTableDBbyToLoc(string loc)
        {

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getRobotCMDbyToLoc(conn, loc);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public RobotCommandTable QueryProcessRobotCMDbyCrrID(string crr_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getProcessRobotCMDbyCrrID(conn, crr_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        //A0.02 Start
        public RobotCommandTable QueryRobotCMDbyCrrID(string crr_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getRobotCMDbyCrrID(conn, crr_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }
        //A0.02 End

        public int QueryExecuteRobotCMDCount(string stk_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.getExecuteRobotCMDCount(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return 0;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> loadExecuteRobotCMD(string stk_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadExecuteRobotCMD(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        //A0.03 Start
        public List<RobotCommandTable> loadQueueRobotCMD(string stk_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadQueueRobotCMD(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }
        //A0.03 End

        public RobotCommandTable loadExecuteRobotCMDByCrr(string crr_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadExecuteRobotCMDByCrr(conn, crr_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> loadExecuteRobotCMDByUnknownCrr()
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadExecuteRobotCMDByUnknownCrr(conn);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public bool upDataRobotCMDStatus(RobotCommandTable CMDTable, int CMDStatus, string eqpt_id)
        {
            DBConnection conn = null;
            try
            {
                eqpt_IND = scApp.getEQObjCacheManager().getEquipmentByEQPTID(eqpt_id);

                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                CMDTable.Command_Status = CMDStatus;
                RobotCommandTableDao.updateRobotCMD(conn, CMDTable);
                conn.Commit();

                eqpt_IND.RobotTableChange = true;

                return true;
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> loadExecuteRobotCMDStkOut(string stk_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadExecuteRobotCMDStkOut(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<RobotCommandTable> loadExecuteRobotCMDStkIn(string stk_id)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadExecuteRobotCMDStkIn(conn, stk_id);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        //A0.01 Start
        public List<RobotCommandTable> loadExecuteRobotCMDShelfToShelf(string stk_id, string bay1, string bay2)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadExecuteRobotCMDShelfToShelf(conn, stk_id, bay1, bay2);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }
        //A0.01 End

        public List<RobotCommandTable> loadRobotCMDbySeqNoTime(int seq_no, DateTimeOffset? start_time, DateTimeOffset? end_time)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                return RobotCommandTableDao.loadRobotCMDbySeqNoTime(conn, seq_no, start_time, end_time);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        //RobotCMDList
        public void SetRobotCMDListDB(RobotCommandList CMDVo, string eqpt_id)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                eqpt_IND = scApp.getEQObjCacheManager().getEquipmentByEQPTID(eqpt_id);
                conn.BeginTransaction();
                RobotCommandListDao.insertRobotCMDList(conn, CMDVo);
                conn.Commit();
                eqpt_IND.RobotListChange = true;
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }
        public void UpdateRobotCMDListDB(RobotCommandList CMDVo, string eqpt_id)
        {


            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                eqpt_IND = scApp.getEQObjCacheManager().getEquipmentByEQPTID(eqpt_id);
                conn.BeginTransaction();
                RobotCommandListDao.updateRobotCMDList(conn, CMDVo);
                conn.Commit();
                eqpt_IND.RobotListChange = true;
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

        }
        public RobotCommandList QueryCMDListDBbySeqNoAndStep(int Seq_No, int CMD_Step)
        {

            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                return RobotCommandListDao.getRobotCMDListbySeqNoANDStep(conn, true, new SeqNoANDCMDStep { Seq_No = Seq_No, CMD_Step = CMD_Step });
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }
        public List<RobotCommandList> QueryCMDListDBbySeqNo(int Seq_No)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                return RobotCommandListDao.getRobotCMDListbySeqNo(conn, true, Seq_No);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return null;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public int QueryCMDListDBOfCMDTypebySeqNoAndStep(int Seq_No, int CMD_Step)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                return RobotCommandListDao.getRobotCMDListOfCMDTypebySeqNoANDStep(conn, true, new SeqNoANDCMDStep { Seq_No = Seq_No, CMD_Step = CMD_Step });
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                return 0;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void deleteRobotCMDLstBySeq(int seq_no)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                RobotCommandListDao.deleteRobotCMDListbySeqNo(conn, seq_no);

                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        /// <summary>
        /// 刪除所有Robot CMD Table、Robot CMD List
        /// </summary>
        public void deleteAllRobotCMDLst(DBConnection conn)
        {
            Boolean isBatch = (conn != null);
            try
            {
                if (!isBatch)
                {
                    conn = scApp.getDBConnection();
                    conn.BeginTransaction();
                }
                RobotCommandListDao.deleteAllRobotCMDLst(conn);
                if (!isBatch)
                {
                    conn.Commit();
                }
            }
            catch (Exception ex)
            {
                if (!isBatch && conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn(ex);
            }
            finally
            {
                if (!isBatch && conn != null) { try { conn.Close(); } catch { } }
            }
        }

        #region Robot Command History
        public void moveRobotCommandToHistory(int seq_no)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                string curr_time = DateTime.Now.ToString(SCAppConstants.TimestampFormat_19);

                RobotCommandTable cmdTable = RobotCommandTableDao.getRobotCMDbySeqNo(conn, false, seq_no);
                //A0.02 List<RobotCommandList> cmdLst = RobotCommandListDao.getRobotCMDListbySeqNo(conn, false, seq_no);
                List<RobotCommandList> cmdLst = RobotCommandListDao.getRobotCMDListbyOrgSeqNo(conn, false, seq_no);  //A0.02

                if (cmdTable != null)
                {
                    RobotCommandTableHis cmdTableHis = new RobotCommandTableHis();
                    cmdTableHis.Log_Sno = curr_time;
                    cmdTableHis.Seq_No = cmdTable.Seq_No;
                    cmdTableHis.Stk_ID = cmdTable.Stk_ID;
                    cmdTableHis.Crr_ID = cmdTable.Crr_ID;
                    cmdTableHis.Gen_Source = cmdTable.Gen_Source;
                    cmdTableHis.Seq_No_Year = cmdTable.Seq_No_Year;
                    cmdTableHis.Seq_No_Month = cmdTable.Seq_No_Month;
                    cmdTableHis.Seq_No_Day = cmdTable.Seq_No_Day;
                    cmdTableHis.Seq_No_Hour = cmdTable.Seq_No_Hour;
                    cmdTableHis.From_Loc = cmdTable.From_Loc;
                    cmdTableHis.To_Loc = cmdTable.To_Loc;
                    cmdTableHis.Status_Time = cmdTable.Status_Time;
                    cmdTableHis.Command_Gen_Time = cmdTable.Command_Gen_Time;
                    cmdTableHis.Step_Gen_Time = cmdTable.Step_Gen_Time;
                    cmdTableHis.Command_Send_Time = cmdTable.Command_Send_Time;
                    cmdTableHis.Command_Start_Time = cmdTable.Command_Start_Time;
                    cmdTableHis.Command_End_Time = cmdTable.Command_End_Time;
                    cmdTableHis.Command_Status = cmdTable.Command_Status;
                    cmdTableHis.Command_Excute_Retune_Code = cmdTable.Command_Excute_Retune_Code;
                    cmdTableHis.Step_Return_Code = cmdTable.Step_Return_Code;
                    cmdTableHis.Command_Prioty = cmdTable.Command_Prioty;
                    cmdTableHis.UsingArm = cmdTable.UsingArm;
                    cmdTableHis.Cmd_Sno = cmdTable.Cmd_Sno;
                    cmdTableHis.User_ID = cmdTable.User_ID;

                    RobotCommandTableHisDao.insertRobotCMDHis(conn, cmdTableHis);
                }

                if(cmdLst != null && cmdLst.Count > 0)
                {
                    foreach(RobotCommandList cmdList in cmdLst)
                    {
                        RobotCommandListHis cmdListHis = new RobotCommandListHis();
                        cmdListHis.Log_Sno = curr_time;
                        cmdListHis.Seq_No = cmdList.Seq_No;
                        cmdListHis.CMD_Step = cmdList.CMD_Step;
                        cmdListHis.Seq_No_Year = cmdList.Seq_No_Year;
                        cmdListHis.Seq_No_Month = cmdList.Seq_No_Month;
                        cmdListHis.Seq_No_Day = cmdList.Seq_No_Day;
                        cmdListHis.Seq_No_Houre = cmdList.Seq_No_Houre;
                        cmdListHis.CMD_Type = cmdList.CMD_Type;
                        cmdListHis.Arm = cmdList.Arm;
                        cmdListHis.From_Loc = cmdList.From_Loc;
                        cmdListHis.To_Loc = cmdList.To_Loc;
                        cmdListHis.Return_Code = cmdList.Return_Code;
                        cmdListHis.Step_Start_Time = cmdList.Step_Start_Time;
                        cmdListHis.Step_End_Time = cmdList.Step_End_Time;
                        cmdListHis.Crr_ID = cmdList.Crr_ID;
                        cmdListHis.Org_Seq_No = cmdList.Org_Seq_No;  //A0.01

                        RobotCommandListHisDao.insertRobotCMDListHis(conn, cmdListHis);
                    }
                }

                RobotCommandTableDao.deleteRobotCMDbySeqNo(conn, seq_no);
                //A0.01 RobotCommandListDao.deleteRobotCMDListbySeqNo(conn, seq_no);
                RobotCommandListDao.deleteRobotCMDListbyOrgSeqNo(conn, seq_no);  //A0.01

                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn(ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }
        #endregion

    }
}
