//*********************************************************************************
//      RobotCommandListDao.cs
//*********************************************************************************
// File Name: RobotCommandListDao.cs
// Description: Robot Command List DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/03/02    Steven Hong    N/A            A0.01   修正同時執行複數命令，命令結束錯誤問題
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NHibernate.Criterion;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class RobotCommandListDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static public void insertRobotCMDList(DBConnection conn, RobotCommandList RobotCMDLst)
        {
            try
            {
                conn.SaveOrUpdate(RobotCMDLst);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw ;
            }
        }

        static public void updateRobotCMDList(DBConnection conn, RobotCommandList RobotCMDLst)
        {
            try
            {
                conn.Update(RobotCMDLst);
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
        }

        static public RobotCommandList getRobotCMDListbySeqNoANDStep(DBConnection conn, Boolean readLock, SeqNoANDCMDStep seqStep)
        {
            RobotCommandList rtnRobotCMDList = null;
            try
            {

                rtnRobotCMDList = conn.Session.Get<RobotCommandList>(seqStep);

                if (rtnRobotCMDList != null && readLock)
                {
                    conn.Lock(rtnRobotCMDList, NHibernate.LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
            return rtnRobotCMDList;
        }

        static public List<RobotCommandList> getRobotCMDListbySeqNo(DBConnection conn, Boolean readLock, int Seq_No)
        {
            List<RobotCommandList> rtnRobotCMDList = null;
            try
            {
                rtnRobotCMDList = conn.Query<RobotCommandList>().Where(c => c.SeqCMD.Seq_No == Seq_No).ToList();
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
            return rtnRobotCMDList;
        }

        //A0.01 Start
        static public List<RobotCommandList> getRobotCMDListbyOrgSeqNo(DBConnection conn, Boolean readLock, int Seq_No)
        {
            List<RobotCommandList> rtnRobotCMDList = null;
            try
            {
                rtnRobotCMDList = conn.Query<RobotCommandList>().Where(c => c.Org_Seq_No == Seq_No).ToList();
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
            return rtnRobotCMDList;
        }
        //A0.01 End

        static public int getRobotCMDListOfCMDTypebySeqNoANDStep(DBConnection conn, Boolean readLock, SeqNoANDCMDStep seqStep)
        {
            int rtnRobotCMDPositionNo = 0;
            try
            {

                rtnRobotCMDPositionNo = conn.Query<RobotCommandList>().Where(o => o.SeqCMD.Seq_No == seqStep.Seq_No && o.SeqCMD.CMD_Step == seqStep.CMD_Step).Select(c => c.CMD_Type).SingleOrDefault();
                //rtnRobotCMDPositionNo = conn.Session.Get<RobotCommandList>(seqStep).CMD_Type;

                //if (rtnRobotCMDPositionNo != null && readLock)
                //{
                //    conn.Lock(rtnRobotCMDPositionNo, NHibernate.LockMode.Upgrade);
                //}
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
            return rtnRobotCMDPositionNo;
        }

        static public void deleteRobotCMDListbySeqNo(DBConnection conn, int RobotCMDList_SeqNo)
        {
            try
            {
                //A0.01 Start
                List<RobotCommandList> delRobotCMDLst = conn.Query<RobotCommandList>().Where(c => c.SeqCMD.Seq_No == RobotCMDList_SeqNo).ToList();
                foreach(RobotCommandList delRbobtCMD in delRobotCMDLst)
                {
                    conn.Delete(delRbobtCMD);
                }
                //RobotCommandList delRobotCMD = conn.Query<RobotCommandList>().Where(c => c.SeqCMD.Seq_No == RobotCMDList_SeqNo).SingleOrDefault();
                //conn.Delete(delRbobtCMD);
                //A0.01 End
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
        }

        //A0.01 Start
        static public void deleteRobotCMDListbyOrgSeqNo(DBConnection conn, int RobotCMDList_SeqNo)
        {
            try
            {
                List<RobotCommandList> delRobotCMDLst = conn.Query<RobotCommandList>().Where(c => c.Org_Seq_No == RobotCMDList_SeqNo).ToList();
                foreach (RobotCommandList delRbobtCMD in delRobotCMDLst)
                {
                    conn.Delete(delRbobtCMD);
                }
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
        }
        //A0.01 End

        //static public void deleteAllRobotCMDLst(DBConnection conn)
        //{
        //    try
        //    {
        //        List<RobotCommandList> delRobotCMDList = conn.Query<RobotCommandList>().ToList();
        //        foreach (RobotCommandList delRobotCMDLst in delRobotCMDList)
        //        {
        //            conn.Delete(delRobotCMDLst);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.Warn(ex);
        //        throw;
        //    }
        //}

        static public void deleteAllRobotCMDLst(DBConnection conn)
        {
            try
            {
                const string query = "DELETE FROM ROBOTCMD_LST";
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
