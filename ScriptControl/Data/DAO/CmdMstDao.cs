//*********************************************************************************
//      CmdMstDao.cs
//*********************************************************************************
// File Name: CmdMstDao.cs
// Description: CmdMstDao
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/10    Steven Hong    N/A            A0.01   增加By Source Location查詢命令功能
// 2020/09/18    Steven Hong    N/A            A0.02   Delete動作增加檢查
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class CmdMstDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 新增Cmd Mst
        /// </summary>
        /// <param name="cmd">Cmd Mst</param>
        /// <returns></returns>
        public void insertCmdMst(DBConnection conn, Cmd_Mst cmd)
        {
            try
            {
                conn.SaveOrUpdate(cmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 更新Cmd Mst
        /// </summary>
        /// <param name="cmd">Cmd Mst</param>
        /// <returns></returns>
        public void updateCmdMst(DBConnection conn, Cmd_Mst cmd)
        {
            try
            {
                conn.Update(cmd);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 根據Cmd No取得Cmd Mst
        /// </summary>
        /// <param name="readLock">是否Lock查詢結果</param>
        /// <param name="cmd_sno">Cmd No</param>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public Cmd_Mst getCmdMst(DBConnection conn, Boolean readLock, string cmd_sno)
        {
            Cmd_Mst rtnCmd = null;

            try
            {
                rtnCmd = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Sno.Trim() == cmd_sno.Trim()).SingleOrDefault();
                if (rtnCmd != null && readLock)
                {
                    conn.Lock(rtnCmd, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmd;
        }

        /// <summary>
        /// 取得所有命令
        /// </summary>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public List<Cmd_Mst> loadAllCmdMst(DBConnection conn)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 取得狀態為Queue的命令
        /// </summary>
        /// <param name="to_Lcs">To LCS Flag</param>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public List<Cmd_Mst> loadCmdMstIsQueue(DBConnection conn, bool to_Lcs)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                string toLCsStr = SCAppConstants.CmdLCS.NotSend;
                if(to_Lcs)
                {
                    toLCsStr = SCAppConstants.CmdLCS.Sended;
                }

                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Queue && c.Trace.Trim() == toLCsStr.Trim()).OrderByDescending(c => c.Prty)
                                                         .ThenBy(c => c.Crt_Date).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 取得狀態為Queue的命令
        /// </summary>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public List<Cmd_Mst> loadAllCmdMstIsQueue(DBConnection conn)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Queue).OrderByDescending(c => c.Prty)
                                                         .ThenBy(c => c.Crt_Date).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 取得還未結束的命令
        /// </summary>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public List<Cmd_Mst> loadCmdIsUnfinished(DBConnection conn)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Queue || c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Transferring ||
                                                         c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Paused).OrderByDescending(c => c.Prty).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 取得執行中的命令
        /// </summary>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public List<string> loadIsExcuteCmdID(DBConnection conn)
        {
            List<Cmd_Mst> rtnCmdLst;
            List<string> ticketNoLst = new List<string>();

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Transferring || c.Cmd_Stat.Trim() ==  SCAppConstants.CmdStatus.Canceling ||
                                                             c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Aborting || c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Paused).ToList();

                foreach(Cmd_Mst cmd in rtnCmdLst)
                {
                    ticketNoLst.Add(cmd.Ticket_No);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return ticketNoLst;
        }

        /// <summary>
        /// 根據目標位置取得搬送命令
        /// </summary>
        /// <param name="loc">目標位置</param>
        /// <param name="queryFlg">Query Flag</param>
        /// <param name="getFinish">Get Finish Command Flag</param>
        /// <returns>回覆查到的搬送命令</returns>
        public List<Cmd_Mst> loadCmdByTargetLocation(DBConnection conn, string loc, string queryFlg, bool getFinish)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.New_Loc.Trim() == loc.Trim()).ToList();

                if (SCUtility.isMatche(queryFlg, SCAppConstants.CmdLCSQuery.Sended) || SCUtility.isMatche(queryFlg, SCAppConstants.CmdLCSQuery.NotSend))
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Trace.Trim() == queryFlg.Trim()).OrderBy(c => c.Prty).ToList();
                }

                if (getFinish)
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Cmp ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Cancel ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Post_Fail).ToList();
                }
                else
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Init ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Started ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Wait_Cmp ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Wait_Cancel).ToList();
                }

                rtnCmdLst = rtnCmdLst.OrderBy(c => c.Prty).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 根據起始Port取得搬送命令
        /// </summary>
        /// <param name="port_no">port_no</param>
        /// <param name="queryFlg">Query Flag(Is Send To LCS)</param>
        /// <param name="getFinish">Get Finish Command Flag</param>
        /// <returns>回覆查到的搬送命令</returns>
        public List<Cmd_Mst> loadCmdBySourcePort(DBConnection conn, string port_no, string queryFlg, bool getFinish)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Stn_No.Trim() == port_no.Trim()).ToList();

                if (SCUtility.isMatche(queryFlg, SCAppConstants.CmdLCSQuery.Sended) || SCUtility.isMatche(queryFlg, SCAppConstants.CmdLCSQuery.NotSend))
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Trace.Trim() == queryFlg.Trim()).ToList();
                }
                
                if(getFinish)
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Cmp ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Cancel ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Post_Fail).ToList();
                }
                else
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Init ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Started ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Wait_Cmp ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Wait_Cancel).ToList();
                }

                rtnCmdLst = rtnCmdLst.OrderBy(c => c.Prty).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        //A0.01 Start
        /// <summary>
        /// 根據起始Location取得搬送命令
        /// </summary>
        /// <param name="loc">Location</param>
        /// <param name="queryFlg">Query Flag(Is Send To LCS)</param>
        /// <param name="getFinish">Get Finish Command Flag</param>
        /// <returns>回覆查到的搬送命令</returns>
        public List<Cmd_Mst> loadCmdBySourceLoc(DBConnection conn, string loc, string queryFlg, bool getFinish)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Loc.Trim() == loc.Trim()).ToList();

                if (SCUtility.isMatche(queryFlg, SCAppConstants.CmdLCSQuery.Sended) || SCUtility.isMatche(queryFlg, SCAppConstants.CmdLCSQuery.NotSend))
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Trace.Trim() == queryFlg.Trim()).ToList();
                }

                if (getFinish)
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Cmp ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Cancel ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Post_Fail).ToList();
                }
                else
                {
                    rtnCmdLst = rtnCmdLst.Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Init ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Started ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Wait_Cmp ||
                                                     c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Cmd_Wait_Cancel).ToList();
                }

                rtnCmdLst = rtnCmdLst.OrderBy(c => c.Prty).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }
        //A0.01 End

        /// <summary>
        /// 取得還未下給LCS的搬送命令
        /// </summary>
        /// <returns>回覆查到的搬送命令</returns>
        public List<Cmd_Mst> loadCmdNotSendToLCS(DBConnection conn)
        {
            List<Cmd_Mst> rtnCmdLst;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Sts.Trim() == SCAppConstants.AsrsCmdStat.Init &&
                    c.Cmd_Stat.Trim() == SCAppConstants.CmdStatus.Queue && c.Trace == SCAppConstants.CmdLCS.NotSend).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 根據Ticket No取得Cmd Mst
        /// </summary>
        /// <param name="ticket_no">Ticket No</param>
        /// <returns>回覆取得的Cmd_Mst</returns>
        public List<Cmd_Mst> loadCmdMstByTicket(DBConnection conn, Boolean readLock, string ticket_no)
        {
            List<Cmd_Mst> rtnCmdLst = null;

            try
            {
                rtnCmdLst = conn.Query<Cmd_Mst>().Where(c => c.Ticket_No.Trim() == ticket_no.Trim()).ToList();
                if (rtnCmdLst != null && readLock)
                {
                    conn.Lock(rtnCmdLst, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }

            return rtnCmdLst;
        }

        /// <summary>
        /// 刪除搬送命令
        /// </summary>
        /// <param name="cmd_sno">Cmd No</param>
        /// <returns></returns>
        public void deleteCmdMst(DBConnection conn, string cmd_sno)
        {
            try
            {
                Cmd_Mst delCmd = conn.Query<Cmd_Mst>().Where(c => c.Cmd_Sno.Trim() == cmd_sno.Trim()).SingleOrDefault();
                if (delCmd != null)  //A0.02
                {                    //A0.02
                    conn.Delete(delCmd);
                }                    //A0.02
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }

}
