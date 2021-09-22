//*********************************************************************************
//      OperationHisDao.cs
//*********************************************************************************
// File Name: OperationHisDao.cs
// Description: OperationHisDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   Delete動作增加檢查
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class OperationHisDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertOperationHis(DBConnection conn, OperationHis opHis) 
        {
            try
            {
                conn.Save(opHis);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public List<OperationHis> loadOperationHis(DBConnection conn) 
        {
            List<OperationHis> rtnList = new List<OperationHis>();
            try 
            {
                rtnList = conn.Query<OperationHis>().OrderBy(oh => oh.T_Stamp).ToList();
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
            }
            return rtnList;
        }

        public List<OperationHis> getOperationHis(DBConnection conn, string dt_from, string dt_to)
        {
            List<OperationHis> rtnOperHisList = new List<OperationHis>();
            try
            {
                rtnOperHisList = conn.Query<OperationHis>().OrderBy(oh => oh.T_Stamp).ToList();
                if (dt_from.Equals("") && dt_to.Equals(""))
                {

                }
                else
                {
                    rtnOperHisList =
                              rtnOperHisList.Where(oh => oh.T_Stamp.CompareTo(dt_from) >= 0
                                  && oh.T_Stamp.CompareTo(dt_to) <= 0).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            return rtnOperHisList;
        }

        public List<OperationHis> getOperationHisByUserUD(DBConnection conn, string user_id, string dt_from, string dt_to)
        {
            List<OperationHis> rtnOperHisList = new List<OperationHis>();
            try
            {
                rtnOperHisList = conn.Query<OperationHis>().Where(oh => oh.User_ID.Trim().Contains(user_id.Trim())).
                    OrderBy(oh => oh.T_Stamp).ToList();
                if (dt_from.Equals("") && dt_to.Equals(""))
                {

                }
                else
                {
                    rtnOperHisList =
                              rtnOperHisList.Where(oh => oh.T_Stamp.CompareTo(dt_from) >= 0
                                  && oh.T_Stamp.CompareTo(dt_to) <= 0).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            return rtnOperHisList;
        }

        public List<OperationHis> getOperationHisByTime(DBConnection conn, string user_id, string start_time, string end_time)
        {
            List<OperationHis> rtnOperHisList = new List<OperationHis>();
            try
            {
                if (!SCUtility.isEmpty(user_id))
                {
                    rtnOperHisList = conn.Query<OperationHis>().Where(oh => oh.User_ID.Trim().Contains(user_id.Trim())).OrderBy(oh => oh.T_Stamp).ToList();
                }
                else
                {
                    rtnOperHisList = conn.Query<OperationHis>().ToList();
                }

                if (!SCUtility.isEmpty(start_time) && !SCUtility.isEmpty(end_time))
                {
                    rtnOperHisList =
                              rtnOperHisList.Where(oh => oh.T_Stamp.CompareTo(start_time) >= 0
                                  && oh.T_Stamp.CompareTo(end_time) <= 0).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            return rtnOperHisList;
        }

        public void deleteOperationHis(DBConnection conn, DateTime beforeDate) 
        {
            try
            {
                string beforeDateStr = BCFUtility.formatDateTime(beforeDate, SCAppConstants.TimestampFormat_19);
                List<OperationHis> deleteList =
                    conn.Query<OperationHis>().Where(oh => string.Compare(oh.T_Stamp, beforeDateStr) < 0).ToList();
                if (deleteList != null)  //A0.01
                {                        //A0.01
                    foreach (OperationHis his in deleteList)
                    {
                        conn.Delete(his);
                    }
                }                        //A0.01
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
            }
        }

    }
}
