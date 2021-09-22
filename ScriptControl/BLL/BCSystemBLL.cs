//*********************************************************************************
//      BCSystemBLL.cs
//*********************************************************************************
// File Name: BCSystemBLL.cs
// Description: BCSystemBLL
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
using com.mirle.ibg3k0.bcf.Data.TimerAction;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.bcf.App;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class BCSystemBLL
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private BCStatusDao bcStatusDao = null;
        private OperationHisDao operationHisDao = null;

        public BCSystemBLL()
        {

        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            this.bcStatusDao = scApp.BCStatusDao;
            this.operationHisDao = scApp.OperationHisDao;
        }

        public SCAppConstants.BCSystemInitialRtnCode initialBCSystem()
        {
            string bc_id = scApp.getBCFApplication().BC_ID;
            DBConnection conn = null;
            SCAppConstants.BCSystemInitialRtnCode rtnCode = SCAppConstants.BCSystemInitialRtnCode.Normal;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                BCStatus bc = bcStatusDao.getBCStatByID(conn, true, bc_id);
                if (bc == null)
                {
                    bc = new BCStatus()
                    {
                        BC_ID = bc_id,
                        Close_Mode = SCAppConstants.BCSystemStatus.Default,
                        Run_Timestamp = BCFUtility.formatDateTime(DateTime.Now, SCAppConstants.TimestampFormat_16)
                    };
                    bcStatusDao.insertBCStat(conn, bc);
                }
                else
                {
                    if (BCFUtility.isMatche(bc.Close_Mode, SCAppConstants.BCSystemStatus.NormalClosed))
                    {
                        logger.Info("Normal shutdown BC System!");
                        rtnCode = SCAppConstants.BCSystemInitialRtnCode.Normal;
                    }
                    else
                    {
                        logger.Info("Non-normal shutdown BC System!");
                        rtnCode = SCAppConstants.BCSystemInitialRtnCode.NonNormalShutdown;
                    }
                    bc.Close_Mode = SCAppConstants.BCSystemStatus.Default;
                    bcStatusDao.updateBCStat(conn, bc);
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to BCSTAT [BC_ID:{0}]", bc_id, ex);
                rtnCode = SCAppConstants.BCSystemInitialRtnCode.Error;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnCode;
        }

        public void reWriteBCSystemRunTime()
        {
            string bc_id = scApp.getBCFApplication().BC_ID;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                BCStatus bc = bcStatusDao.getBCStatByID(conn, true, bc_id);
                bc.Run_Timestamp = BCFUtility.formatDateTime(DateTime.Now, SCAppConstants.TimestampFormat_16);
                bcStatusDao.updateBCStat(conn, bc);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to BCSTAT [BC_ID:{0}]", bc_id, ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public Boolean closeBCSystem()
        {
            string bc_id = scApp.getBCFApplication().BC_ID;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                BCStatus bc = bcStatusDao.getBCStatByID(conn, true, bc_id);
                bc.Close_Mode = SCAppConstants.BCSystemStatus.NormalClosed;
                bcStatusDao.updateBCStat(conn, bc);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to BCSTAT [BC_ID:{0}]", bc_id, ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        //EC Data
        public void updateSystemParameter(string ecid, string val, Boolean refreshSecsAgent)
        {
            try
            {
                if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_CONVERSATION_TIMEOUT))
                {
                    SystemParameter.setSECSConversactionTimeout(Convert.ToInt16(val));
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_GEM_INITIAL_CONTROL_STATE))
                {
                    SystemParameter.setInitialHostMode(val);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_AUTO_JOB_SWITCH))
                {
                    SystemParameter.setAutoJobSwitch(Convert.ToInt16(val));
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_HEARTBEAT))
                {
                    SystemParameter.setHeartBeatSec(Convert.ToInt32(val));
                    //Restart Timer
                    ITimerAction timer = scApp.getBCFApplication().getTimerAction("SECSHeartBeat");
                    if (timer != null)
                    {
                        timer.start();
                    }
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_TACK_TIME_OVER))
                {
                    SystemParameter.setSheetTackTimeOver(Convert.ToInt16(val));
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_DEVICE_ID))
                {
                    scApp.setSECSAgentDeviceID(Convert.ToInt32(val), refreshSecsAgent);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_T3))
                {
                    scApp.setSECSAgentT3Timeout(Convert.ToInt32(val), refreshSecsAgent);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_T5))
                {
                    scApp.setSECSAgentT5Timeout(Convert.ToInt32(val), refreshSecsAgent);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_T6))
                {
                    scApp.setSECSAgentT6Timeout(Convert.ToInt32(val), refreshSecsAgent);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_T7))
                {
                    scApp.setSECSAgentT7Timeout(Convert.ToInt32(val), refreshSecsAgent);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_T8))
                {
                    scApp.setSECSAgentT8Timeout(Convert.ToInt32(val), refreshSecsAgent);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_DCS_SINGLEARM))
                {
                    SystemParameter.setEQPTParameters_SingleArm(val);
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_N2_Pre_Move_Stage))
                {
                    SystemParameter.Dcs_N2PreMoveStage = val;
                }
                else if (BCFUtility.isMatche(ecid, SCAppConstants.ECID_N3_Pre_Move_Stage))
                {
                    SystemParameter.Dcs_N3PreMoveStage = val;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("updateSystemParameter Exception ! ", ex);
            }
        }

        #region Operation History

        public void addOperationHis(string user_id, string formName, string action)
        {
            //DBConnection conn = null;
            try
            {
                //conn = scApp.getDBConnection();
                //conn.BeginTransaction();
                //string timeStamp = BCFUtility.formatDateTime(DateTime.Now, SCAppConstants.TimestampFormat_19);
                //OperationHis his = new OperationHis()
                //{
                //    T_Stamp = timeStamp,
                //    User_ID = user_id,
                //    Form_Name = formName,
                //    Action = action
                //};
                //SCUtility.PrintOperationLog(his);
                //deleteOperationHis(conn);
                //operationHisDao.insertOperationHis(conn, his);
                //conn.Commit();
            }
            catch (Exception)
            {
                //if (conn != null) { try { conn.Rollback(); } catch { } }
            }
            finally
            {
               //if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public void deleteOperationHis(DBConnection conn)
        {
            Boolean isBatchMode = (conn != null);
            int keepDay = 60;
            try
            {
                if (!isBatchMode)
                {
                    conn = scApp.getDBConnection();
                    conn.BeginTransaction();
                }
                operationHisDao.deleteOperationHis(conn, DateTime.Now.AddDays(-keepDay));
                if (!isBatchMode)
                {
                    conn.Commit();
                }
            }
            catch (Exception ex)
            {
                if (conn != null && !isBatchMode) { try { conn.Rollback(); } catch { } }
                logger.Warn("FUN:deleteOperationHis Failed [ex:{0}]", ex);
            }
            finally
            {
                if (conn != null && !isBatchMode) { try { conn.Close(); } catch { } }
            }
        }

        public List<OperationHis> getOperationHis(string dt_from, string dt_to)
        {
            DBConnection conn = null;
            List<OperationHis> rtnOperHisList = new List<OperationHis>();

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnOperHisList = operationHisDao.getOperationHis(conn, dt_from, dt_to);
                conn.Commit();
            }
            catch (Exception)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnOperHisList;
        }

        public List<OperationHis> getOperationHisByUserUD(string user_id, string dt_from, string dt_to)
        {
            DBConnection conn = null;
            List<OperationHis> rtnOperHisList = new List<OperationHis>();

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnOperHisList = operationHisDao.getOperationHisByUserUD(conn, user_id, dt_from, dt_to);
                conn.Commit();
            }
            catch (Exception)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnOperHisList;
        }

        public List<OperationHis> getOperationHisByTime(string user_id, string start_time, string end_time)
        {
            DBConnection conn = null;
            List<OperationHis> rtnOperHisList = new List<OperationHis>();

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnOperHisList = operationHisDao.getOperationHisByTime(conn, user_id, start_time, end_time);
                conn.Commit();
            }
            catch (Exception)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnOperHisList;
        }
        #endregion Operation History
        
    }
}
