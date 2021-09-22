//*********************************************************************************
//      AlarmBLL.cs
//*********************************************************************************
// File Name: AlarmBLL.cs
// Description: 業務邏輯：Alarm
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
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.SECS;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using com.mirle.ibg3k0.bcf.App;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class AlarmBLL
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private AlarmDao alarmDao = null;
        private LineDao lineDao = null;
        private AlarmMapDao alarmMapDao = null;
        private MainAlarmDao mainAlarmDao = null;

        public AlarmBLL()
        {

        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            alarmDao = scApp.AlarmDao;
            lineDao = scApp.LineDao;
            alarmMapDao = scApp.AlarmMapDao;
            mainAlarmDao = scApp.MainAlarmDao;
        }

        public Boolean createAlarmToDB(Alarm alarm)
        {
            DBConnection conn = null;
            bool ReturnCode = false;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                //需判斷此筆Alarm Code是否已經存在，若存在則無法再次存入
                if (alarmDao.loadAlarmByCODE(conn, alarm.Alarm_Code, true) == null)
                {
                    alarmDao.insertAlarm(conn, alarm);
                    conn.Commit();
                    ReturnCode = true;
                }
                else
                {
                    ReturnCode = false;
                }
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to ALARM [EQPT:{0}][alarm_code:{1}]",
                    alarm.AlarmPK.EQPT_ID, alarm.Alarm_Code, ex);

                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return ReturnCode;
        }


        public Boolean createAlarm(string eqpt_id, int unit_num,
            string alarm_code, int alarm_lvl, string alarm_desc, out Alarm outAlarm)
        {
            DateTime now = DateTime.Now;

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                Alarm alarm = new Alarm()
                {
                    AlarmPK = new AlarmPKInfo
                    {
                        EQPT_ID = eqpt_id,
                        Unit_Num = unit_num,
                        Rpt_Date_Time = BCFUtility.formatDateTime(now, SCAppConstants.TimestampFormat_19)
                    },
                    Alarm_Code = alarm_code,
                    Alarm_Lvl = alarm_lvl,
                    Alarm_Stat = Convert.ToInt32(SCAppConstants.AlarmStatus.Set),
                    Alarm_Desc = alarm_desc
                };
                alarmDao.insertAlarm(conn, alarm);
                conn.Commit();

                outAlarm = alarm;
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to ALARM [EQPT:{0}][Unit Num:{1}][alarm_code:{2}]",
                    eqpt_id, unit_num, alarm_code, ex);

                outAlarm = null;
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public List<Alarm> loadAlarmByRptSourceFuzzy(string eqpt_id, string rpt_code, string dt_from, string dt_to, bool rpt_set, bool rpt_clear)
        {
            List<Alarm> alarmList = new List<Alarm>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                alarmList = alarmDao.loadAlarmByRptSourceFuzzy(conn, eqpt_id, rpt_code, dt_from, dt_to, rpt_set, rpt_clear);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From ALARM [EQPT:{0}][Code:{1}]",
                    eqpt_id, rpt_code, ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return alarmList;
        }

        public List<Alarm> loadAlarmByRptSource(string eqpt_id, string rpt_code, string dt_from, string dt_to, bool rpt_set, bool rpt_clear)
        {
            List<Alarm> alarmList = new List<Alarm>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                alarmList = alarmDao.loadAlarmByRptSource(conn, eqpt_id, rpt_code, dt_from, dt_to, rpt_set, rpt_clear);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From ALARM [EQPT:{0}][Code:{1}]",
                    eqpt_id, rpt_code, ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return alarmList;
        }

        public List<Alarm> loadAlarm(bool rpt_set, bool rpt_clear)
        {
            List<Alarm> alarmList = new List<Alarm>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                alarmList = alarmDao.loadAlarm(conn, rpt_set, rpt_clear);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From ALARM", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return alarmList;
        }

        public void updateAlarm(Alarm alarm)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                alarmDao.updateAlarm(conn, alarm);
                conn.Session.Flush();
            }
            catch (Exception ex)
            {
                logger.Warn("Update Failed From ALARM", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
        }

        public List<AlarmMap> loadAlarmMapsByEQRealID(string eqpt_real_id)
        {
            List<AlarmMap> alarmMapList = new List<AlarmMap>();
            try
            {
                alarmMapList = alarmMapDao.loadAlarmMapsByEQRealID(eqpt_real_id);
            }
            catch (Exception ex)
            {
                logger.WarnException("loadAlarmMapsByEQRealID Exception!", ex);
            }
            return alarmMapList;
        }

        public AlarmMap getAlarmMap(string eqpt_real_id, long alarm_id)
        {
            AlarmMap alarmMap = null;
            try
            {
                alarmMap = alarmMapDao.getAlarmMap(eqpt_real_id, alarm_id.ToString());
            }
            catch (Exception ex)
            {
                logger.WarnException("getAlarmMap Exception!", ex);
            }
            return alarmMap;
        }

        public AlarmMap getAlarmMap(string eqpt_real_id, string alarm_id)
        {
            AlarmMap alarmMap = null;
            try
            {
                alarmMap = alarmMapDao.getAlarmMap(eqpt_real_id, alarm_id);
            }
            catch (Exception ex)
            {
                logger.WarnException("getAlarmMap Exception!", ex);
            }
            return alarmMap;
        }

        public bool addAlarmMap(AlarmMap alarmMap)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = alarmMapDao.addAlarmMap(alarmMap);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        public bool updateAlarmMap(AlarmMap alarmMap)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = alarmMapDao.updateAlarmMap(alarmMap);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        public bool deleteAlarmMap(string eqpt_real_id, string alarm_id)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = alarmMapDao.deleteAlarmMap(eqpt_real_id, alarm_id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        public bool saveAllEqptAlarmMapToCsv(string eqpt_real_id, List<AlarmMap> lstAlarmMap)
        {
            bool rtnCode = false;

            try
            {
                List<Equipment> eqptLst = scApp.getEQObjCacheManager().getAllEquipment();

                foreach (Equipment eqpt in eqptLst)
                {
                    if (eqpt.Eqpt_ID.Contains("BC"))
                    {
                        continue;
                    }

                    if (SCUtility.isMatche(eqpt.Real_ID, eqpt_real_id))
                    {
                        continue;
                    }

                    List<AlarmMap> alarmMapLst = alarmMapDao.loadAlarmMapsByEQRealID(eqpt.Real_ID);

                    lstAlarmMap.AddRange(alarmMapLst);
                }

                rtnCode = alarmMapDao.saveAllEqptAlarmMapToCsv(lstAlarmMap);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        //機台On-Line時，先清空所有異常
        public void deleteAllAlarmByEQPT_ID(string eqpt_id)
        {
            //DBConnection conn = null;
            //try
            //{
            //    conn = SCApplication.getInstance().getDBConnection();
            //    conn.BeginTransaction();
            //    SCApplication.getInstance().AlarmDao.deleteAllAlarmByEQPT_ID(conn, eqpt_id);
            //    conn.Commit();
            //}
            //catch (Exception ex)
            //{
            //    logger.Warn("Delete All Alarm Error", ex);
            //}
            //finally
            //{
            //    if (conn != null) { try { conn.Close(); } catch { } }
            //}
        }

        public string onMainAlarm(string mAlarmCode, params object[] args)
        {
            MainAlarm mainAlarm = mainAlarmDao.getMainAlarmByCode(mAlarmCode);
            string msg = string.Empty;
            try
            {
                if (mainAlarm != null)
                {
                    msg = string.Format(mainAlarm.DESCRIPTION, args);
                    msg = string.Format("[{0}] {1}", mainAlarm.CODE, msg);
                    switch (mainAlarm.CODE[0])
                    {
                        case SCAppConstants.MainAlarmLevel.Info:
                            BCFApplication.onInfoMsg(msg);
                            break;
                        case SCAppConstants.MainAlarmLevel.Warn:
                            BCFApplication.onWarningMsg(msg);
                            break;
                        case SCAppConstants.MainAlarmLevel.Alarm:
                            BCFApplication.onErrorMsg(msg);
                            break;
                    }
                }
                else
                {
                    logger.Warn(string.Format("LFC alarm/warm happen, but no defin remark code:[{0}] !!!", mAlarmCode));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
            }
            return msg;
        }

        public string getMainAlarm(string mAlarmCode, params object[] args)
        {
            MainAlarm mainAlarm = mainAlarmDao.getMainAlarmByCode(mAlarmCode);
            string msg = string.Empty;
            try
            {
                if (mainAlarm != null)
                {
                    msg = string.Format(mainAlarm.DESCRIPTION, args);
                    msg = string.Format("[{0}] {1}", mainAlarm.CODE, msg);
                }
                else
                {
                    logger.Warn(string.Format("LFC alarm/warm happen, but no defin remark code:[{0}] !!!", mAlarmCode));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
            }
            return msg;
        }

        public MainAlarm getMainAlarmByCode(string code)
        {
            MainAlarm mainAlarm = null;

            try
            {
                mainAlarm = mainAlarmDao.getMainAlarmByCode(code);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
            }

            return mainAlarm;
        }

        public List<MainAlarm> loadAllMAINALARM()
        {
            List<MainAlarm> lstMainAlarm = null;

            try
            {
                lstMainAlarm = mainAlarmDao.loadAllMAINALARM();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
            }

            return lstMainAlarm;
        }

        public bool addMainAlarm(MainAlarm mainAlarm)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = mainAlarmDao.addMainAlarm(mainAlarm);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        public bool updateMainAlarm(MainAlarm mainAlarm)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = mainAlarmDao.updateMainAlarm(mainAlarm);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        public bool deleteMainAlarm(string code)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = mainAlarmDao.deleteMainAlarm(code);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }

        public bool saveMainAlarmToCsv(List<MainAlarm> lstMainAlarm)
        {
            bool rtnCode = false;

            try
            {
                rtnCode = mainAlarmDao.saveMainAlarmToCsv(lstMainAlarm);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return rtnCode;
        }
        
    }
}
