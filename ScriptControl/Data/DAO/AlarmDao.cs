//*********************************************************************************
//      AlarmDao.cs
//*********************************************************************************
// File Name: AlarmDao.cs
// Description: AlarmDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/18    Steven Hong    N/A            A0.01   Delete動作增加檢查
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate.Linq;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class AlarmDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertAlarm(DBConnection conn, Alarm alarm) 
        {
            try
            {
                conn.Save(alarm);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateAlarm(DBConnection conn, Alarm alarm)
        {
            try
            {
                conn.Update(alarm);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public List<Alarm> loadAlarmByRptSourceFuzzy(DBConnection conn, string eqpt_id, string rpt_code, string dt_from, string dt_to, bool rpt_set, bool rpt_clear) 
        {
            List<Alarm> rtnAlarmList = new List<Alarm>();
            try
            {
                rtnAlarmList = conn.Query<Alarm>().ToList();
                if (!eqpt_id.Trim().Equals(""))
                {
                    rtnAlarmList = rtnAlarmList.Where(a => a.AlarmPK.EQPT_ID.Trim() == eqpt_id.Trim()).ToList();
                }
                if (!rpt_code.Equals(""))
                {
                    rtnAlarmList = rtnAlarmList.Where(a => a.Alarm_Code.Trim().Contains(rpt_code.Trim())).ToList();
                }

                if (dt_from.Equals("") && dt_to.Equals(""))
                {

                }
                else
                {
                    rtnAlarmList =
                              rtnAlarmList.Where(a => a.AlarmPK.Rpt_Date_Time.CompareTo(dt_from) >= 0
                                  && a.AlarmPK.Rpt_Date_Time.CompareTo(dt_to) <= 0).ToList();
                }

                int rpt_status = -1;
                if (rpt_set && rpt_clear)
                {

                }
                else if (rpt_set && !rpt_clear)
                {
                    rpt_status = (int)SCAppConstants.AlarmStatus.Set;
                }
                else if (!rpt_set && rpt_clear)
                {
                    rpt_status = (int)SCAppConstants.AlarmStatus.Clear;
                }
                else if (!rpt_set && !rpt_clear)
                {

                }

                if (rpt_status != -1)
                {
                    rtnAlarmList = rtnAlarmList.Where(a => a.Alarm_Stat == rpt_status).ToList();
                }
                
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnAlarmList;
        }

        public List<Alarm> loadAlarmByRptSource(DBConnection conn, string eqpt_id, string rpt_code, string dt_from, string dt_to, bool rpt_set, bool rpt_clear)
        {
            List<Alarm> rtnAlarmList = new List<Alarm>();
            try
            {
                rtnAlarmList = conn.Query<Alarm>().ToList();
                if (!eqpt_id.Trim().Equals(""))
                {
                    rtnAlarmList = rtnAlarmList.Where(a => a.AlarmPK.EQPT_ID.Trim() == eqpt_id.Trim()).ToList();
                }
                if (!rpt_code.Equals(""))
                {
                    rtnAlarmList = rtnAlarmList.Where(a => a.Alarm_Code.Trim() == rpt_code.Trim()).ToList();
                }

                if (dt_from.Equals("") && dt_to.Equals(""))
                {

                }
                else
                {
                    rtnAlarmList =
                              rtnAlarmList.Where(a => a.AlarmPK.Rpt_Date_Time.CompareTo(dt_from) >= 0
                                  && a.AlarmPK.Rpt_Date_Time.CompareTo(dt_to) <= 0).ToList();
                }

                int rpt_status = -1;
                if (rpt_set && rpt_clear)
                {

                }
                else if (rpt_set && !rpt_clear)
                {
                    rpt_status = (int)SCAppConstants.AlarmStatus.Set;
                }
                else if (!rpt_set && rpt_clear)
                {
                    rpt_status = (int)SCAppConstants.AlarmStatus.Clear;
                }
                else if (!rpt_set && !rpt_clear)
                {

                }

                if (rpt_status != -1)
                {
                    rtnAlarmList = rtnAlarmList.Where(a => a.Alarm_Stat == rpt_status).ToList();
                }

            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnAlarmList;
        }
        public List<Alarm> loadAlarm(DBConnection conn, bool rpt_set, bool rpt_clear) 
        {
            List<Alarm> rtnAlarmList = new List<Alarm>();
            try
            {
                int rpt_status = -1;
                if (rpt_set && rpt_clear)
                {

                }
                else if (rpt_set && !rpt_clear)
                {
                    rpt_status = (int)SCAppConstants.AlarmStatus.Set;
                }
                else if (!rpt_set && rpt_clear)
                {
                    rpt_status = (int)SCAppConstants.AlarmStatus.Clear;
                }
                else if (!rpt_set && !rpt_clear)
                {

                }

                if (rpt_status != -1)
                {
                    rtnAlarmList =
                        conn.Query<Alarm>().Where(a => a.Alarm_Stat == rpt_status).OrderByDescending(a => a.AlarmPK.Rpt_Date_Time).ToList();
                }
                else
                {
                    rtnAlarmList =
                        conn.Query<Alarm>().OrderByDescending(a => a.AlarmPK.Rpt_Date_Time).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnAlarmList;
        }

        public List<Alarm> loadAlarmByEQPT(DBConnection conn, string eqpt_id) 
        {
            List<Alarm> rtnAlarmList = new List<Alarm>();
            try
            {
                rtnAlarmList =
                        conn.Query<Alarm>().Where(a => a.AlarmPK.EQPT_ID.Trim() == eqpt_id.Trim()).
                        OrderByDescending(a => a.AlarmPK.Rpt_Date_Time).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnAlarmList;
        }

        public void deleteAllAlarmByEQPT_ID(DBConnection conn, string eqpt_id)
        {
            //try
            //{
            //    List<Alarm> delList = conn.Query<Alarm>().Where(c => c.AlarmPK.EQPT_ID.Trim() == eqpt_id.Trim()).ToList();
            //    if (delList != null)  //A0.01
            //    {                     //A0.01
            //        foreach (Alarm delCst in delList)
            //        {
            //            conn.Delete(delCst);
            //        }
            //    }                     //A0.01
            //}
            //catch (Exception ex)
            //{
            //    logger.Warn(ex);
            //    throw;
            //}
        }

        public Alarm loadAlarmByCODE(DBConnection conn, string Code, Boolean isSet)
        {
            Alarm rtnAlarm = new Alarm();
            try
            {
                rtnAlarm =
                        conn.Query<Alarm>().Where(
                            a => a.Alarm_Code.Trim() == Code.Trim()
                                && a.Alarm_Stat == (isSet ? SCAppConstants.AlarmStatus.Set : 
                                                           SCAppConstants.AlarmStatus.Clear)
                        ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnAlarm;
        }

    }
}
