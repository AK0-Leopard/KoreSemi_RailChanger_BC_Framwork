//*********************************************************************************
//      RobotCommandTableDao.cs
//*********************************************************************************
// File Name: RobotCommandTableDao.cs
// Description: Robot Command Table DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/02/24    Steven Hong    N/A            A0.01   修正Stock In命令查詢錯誤
//                                                     增加Shelf To Shelf命令查詢
// 2021/03/03    Steven Hong    N/A            A0.02   增加根據Carreier ID查詢命令
// 2021/03/15    Steven Hong    N/A            A0.03   新增查詢未執行Robot Command
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class RobotCommandTableDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static public void insertRobotCMD(DBConnection conn, RobotCommandTable RobotCMD)
        {
            try
            {
                conn.SaveOrUpdate(RobotCMD);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
            }
        }

        static public void updateRobotCMD(DBConnection conn, RobotCommandTable RobotCMD)
        {
            try
            {
                conn.Update(RobotCMD);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
            }
        }

        static public RobotCommandTable getRobotCMDbySeqNo(DBConnection conn, Boolean readLock, int Seq_No)
        {
            RobotCommandTable rtnRobotCMD = null;
            try
            {
                rtnRobotCMD = conn.Query<RobotCommandTable>().Where(c => c.Seq_No == Seq_No).SingleOrDefault();
                if (rtnRobotCMD != null && readLock)
                {
                    conn.Lock(rtnRobotCMD, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
            return rtnRobotCMD;
        }

        static public RobotCommandTable getRobotCMDbyMGIDAndOrderbySeq(DBConnection conn, Boolean readLock, string mg_id)
        {
            RobotCommandTable rtnRobotCMD = null;
            try
            {
                rtnRobotCMD = conn.Query<RobotCommandTable>().Where(c => c.Crr_ID.Trim() == mg_id.Trim()).OrderByDescending(o => o.Seq_No).FirstOrDefault();
                if (rtnRobotCMD != null && readLock)
                {
                    conn.Lock(rtnRobotCMD, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rtnRobotCMD;
        }

        static public int getRobotCMDSeqNoMax(DBConnection conn, Boolean readLock)
        {
            int rtnRobotCMDSeq = 0;
            try
            {
                if (conn.Query<RobotCommandTable>().Select(c => c.Seq_No).Count() != 0)
                    rtnRobotCMDSeq = conn.Query<RobotCommandTable>().Select(c => c.Seq_No).Max();
                else
                    rtnRobotCMDSeq = 0;

                if (rtnRobotCMDSeq != null && readLock)
                {
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rtnRobotCMDSeq;
        }

        static public int[] getRobotCMDAllNotExcuteOfSeqNo(DBConnection conn, Boolean readLock)
        {
            int[] rtnRobotCMDSeq = null;
            try
            {
                rtnRobotCMDSeq = conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen).Select(c => c.Seq_No).ToArray();
                if (rtnRobotCMDSeq != null && readLock)
                {
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return rtnRobotCMDSeq;
        }

        /// <summary>
        /// 取出第一筆要執行的命令(無論Auto Manual Mode的)
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public RobotCommandTable getRobotCMDbyFirstExctue(DBConnection conn, string stk_id)
        {
            try
            {
                IOrderedQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen && o.Stk_ID.Trim() == stk_id.Trim()).
                    OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    RobotCommandTable robotCMD = lstRobotCMD.First();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }

        }

        /// <summary>
        /// 取出所有的命令
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public List<RobotCommandTable> loadAllRobotCMD(DBConnection conn)
        {
            try
            {
                IOrderedQueryable<RobotCommandTable> lstRobotCMD = conn.Query<RobotCommandTable>().OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<RobotCommandTable> robotCMDLst = lstRobotCMD.ToList();
                    return robotCMDLst;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }
        }

        /// <summary>
        /// 取出可執行的命令(無論Auto Manual Mode的)
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public List<RobotCommandTable> loadRobotCMD(DBConnection conn, string stk_id)
        {
            try
            {
                IOrderedQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen && o.Stk_ID.Trim() == stk_id.Trim()).
                    OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<RobotCommandTable> robotCMDLst = lstRobotCMD.ToList();
                    return robotCMDLst;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }
        }

        /// <summary>
        /// 取出可執行的命令(Manual Mode)
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public List<RobotCommandTable> loadManualRobotCMD(DBConnection conn, string stk_id)
        {
            try
            {
                IOrderedQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen && o.Stk_ID.Trim() == stk_id.Trim() &&
                    o.Gen_Source != SCAppConstants.GenerateSource.Transfer).OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<RobotCommandTable> robotCMDLst = lstRobotCMD.ToList();
                    return robotCMDLst;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }
        }

        /// <summary>
        /// 根據Carrier ID取出可執行的命令(無論Auto Manual Mode的)
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public RobotCommandTable loadExecuteRobotCMDByCrr(DBConnection conn, string crr_id)
        {
            try
            {
                IOrderedQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen && o.Crr_ID.Trim() == crr_id.Trim())
                    .OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    RobotCommandTable robotCMD = lstRobotCMD.First();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }
        }

        /// <summary>
        /// 根據Unknown Carrier取出可執行的命令(無論Auto Manual Mode的)
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public List<RobotCommandTable> loadExecuteRobotCMDByUnknownCrr(DBConnection conn)
        {
            try
            {
                IOrderedQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen && o.Crr_ID.Trim().StartsWith("UN"))
                    .OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    List<RobotCommandTable> robotCMD = lstRobotCMD.ToList();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }
        }

        /// <summary>
        /// 取出是否有命令正在對此Port做取片的動作。主要用來防止當在Cst Status 還在Wait剛下命令給Robot到Cst中搬取Glass，但Cst 狀態還沒變成PROC，
        /// 而此時，來下Cst Cancel命令，會發生帳料處理問題。
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public RobotCommandTable getRobotCMDbyPortNO(DBConnection conn, string port_id)
        {
            try
            {
                IQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => (o.From_Loc == port_id)
                                                                && (o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Send
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Process_Wait
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Processing));
                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    RobotCommandTable robotCMD = lstRobotCMD.First();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        static public RobotCommandTable getRobotCMDbyToLoc(DBConnection conn, string loc)
        {
            try
            {
                IQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => (o.To_Loc == loc)
                                                                && (o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Send
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Process_Wait
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Processing));
                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    RobotCommandTable robotCMD = lstRobotCMD.First();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// 透過ShtID或ShtIDs找出此片Sht是否已經有產生命令，並正在執行中
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public RobotCommandTable getProcessRobotCMDbyCrrID(DBConnection conn, string mg_id)
        {
            try
            {
                IQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Crr_ID == mg_id
                                                                && (o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Process_Wait
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Processing));

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    RobotCommandTable robotCMD = lstRobotCMD.First();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }

        }

        //A0.02 Start
        /// <summary>
        /// 透過ShtID或ShtIDs找出此片Sht是否已經有產生命令，並正在執行中
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public RobotCommandTable getRobotCMDbyCrrID(DBConnection conn, string mg_id)
        {
            try
            {
                IQueryable<RobotCommandTable> lstRobotCMD =
                    conn.Query<RobotCommandTable>().Where(o => o.Crr_ID == mg_id);

                if (lstRobotCMD.Count() == 0)
                {
                    return null;
                }
                else
                {
                    RobotCommandTable robotCMD = lstRobotCMD.First();
                    return robotCMD;
                }
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }
        }
        //A0.02 End

        /// <summary>
        /// 回傳現在目前正在執行的命令數量
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public int getExecuteRobotCMDCount(DBConnection conn, string stk_id)
        {
            int RobotCMDExecuteCount = 0;
            try
            {
                RobotCMDExecuteCount =
                    conn.Query<RobotCommandTable>().Where(o => (o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Send
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Process_Wait
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Processing)
                                                                 && o.Stk_ID.Trim() == stk_id.Trim()).Count();
                return RobotCMDExecuteCount;
            }
            catch (Exception ex)
            {
                //throw (ex);
                return 0;
            }

        }

        /// <summary>
        /// 找出正在執行的Command
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public List<RobotCommandTable> loadExecuteRobotCMD(DBConnection conn, string stk_id)
        {
            List<RobotCommandTable> lstRobotCMDExecute;
            try
            {
                lstRobotCMDExecute =
                    conn.Query<RobotCommandTable>().Where(o => (o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Send
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Process_Wait
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Processing)
                                                                 && o.Stk_ID.Trim() == stk_id.Trim()).ToList();
                return lstRobotCMDExecute;
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }

        }

        //A0.03 Start
        /// <summary>
        /// 找出未執行的Command
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        static public List<RobotCommandTable> loadQueueRobotCMD(DBConnection conn, string stk_id)
        {
            List<RobotCommandTable> lstRobotCMDExecute;
            try
            {
                lstRobotCMDExecute =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen && o.Stk_ID.Trim() == stk_id.Trim()).ToList();
                return lstRobotCMDExecute;
            }
            catch (Exception ex)
            {
                //throw (ex);
                return null;
            }

        }
        //A0.03 End

        static public List<RobotCommandTable> loadRobotCMDbySeqNoTime(DBConnection conn, int seq_no, DateTimeOffset? start_time, DateTimeOffset? end_time)
        {
            List<RobotCommandTable> rtnRobotCMDLst = null;
            try
            {
                rtnRobotCMDLst = conn.Query<RobotCommandTable>().ToList();

                if(seq_no != 0)
                {
                    rtnRobotCMDLst = rtnRobotCMDLst.Where(c => c.Seq_No == seq_no).ToList();
                }

                if(start_time != null && end_time != null)
                {
                    rtnRobotCMDLst = rtnRobotCMDLst.Where(w => w.Command_Gen_Time >= (start_time) && w.Command_Gen_Time <= end_time).ToList();
                }
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
            return rtnRobotCMDLst;
        }

        static public List<RobotCommandTable> loadExecuteRobotCMDStkOut(DBConnection conn, string stk_id)
        {
            List<RobotCommandTable> rtnRobotCMDLst = null;
            try
            {
                rtnRobotCMDLst = conn.Query<RobotCommandTable>().Where(c => c.Stk_ID.Trim() == stk_id.Trim() && c.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen &&
                !c.From_Loc.StartsWith("IP") && !c.From_Loc.StartsWith("M") &&
                (c.To_Loc.StartsWith("IP") || c.To_Loc.StartsWith("M"))).OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return rtnRobotCMDLst;
        }

        static public List<RobotCommandTable> loadExecuteRobotCMDStkIn(DBConnection conn, string stk_id)
        {
            List<RobotCommandTable> rtnRobotCMDLst = null;
            try
            {
                rtnRobotCMDLst = conn.Query<RobotCommandTable>().Where(c => c.Stk_ID.Trim() == stk_id.Trim() && c.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen  &&
                //A0.01 c.From_Loc.StartsWith("IP") && !c.To_Loc.StartsWith("IP") && !c.To_Loc.StartsWith("M")).
                !c.To_Loc.StartsWith("IP") && !c.To_Loc.StartsWith("M")).  //A0.01
                  OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return rtnRobotCMDLst;
        }

        //A0.01 Start
        static public List<RobotCommandTable> loadExecuteRobotCMDShelfToShelf(DBConnection conn, string stk_id, string bay1, string bay2)
        {
            List<RobotCommandTable> rtnRobotCMDLst = null;
            try
            {
                rtnRobotCMDLst = conn.Query<RobotCommandTable>().Where(c => c.Stk_ID.Trim() == stk_id.Trim() && c.Command_Status == (int)SCAppConstants.RobotCMDStatus.Gen &&
                (c.From_Loc.StartsWith(bay1) || c.From_Loc.StartsWith(bay2)) && (c.To_Loc.StartsWith(bay1) || c.To_Loc.StartsWith(bay2))).
                  OrderBy(o => o.Command_Prioty).ThenBy(o => o.Command_Gen_Time).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return rtnRobotCMDLst;
        }
        //A0.01 End

        static public List<RobotCommandTable> loadEndOrCancelRobotCMD(DBConnection conn)
        {
            List<RobotCommandTable> rtnRobotCMDLst = null;

            try
            {
                rtnRobotCMDLst =
                    conn.Query<RobotCommandTable>().Where(o => o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Process_End
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Robot_Cancel
                                                                 || o.Command_Status == (int)SCAppConstants.RobotCMDStatus.Manul_Cancel).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

            return rtnRobotCMDLst;
        }

        static public void deleteRobotCMDbySeqNo(DBConnection conn, int RobotCMD_SeqNo)
        {
            try
            {
                RobotCommandTable delRbobtCMD = conn.Query<RobotCommandTable>().Where(c => c.Seq_No == RobotCMD_SeqNo).SingleOrDefault();
                conn.Delete(delRbobtCMD);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
        }

        static public void deleteAllRobotCMD(DBConnection conn)
        {
            try
            {
                const string query = "DELETE FROM ROBOTCMD_TABLE";
                if (conn.UsingStateless)
                {
                    conn.StatelessSess
                            .CreateSQLQuery(query)
                            .ExecuteUpdate();
                }
                else
                {
                    conn.Session
                            .CreateSQLQuery(query)
                            .ExecuteUpdate();
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }
    }
}
