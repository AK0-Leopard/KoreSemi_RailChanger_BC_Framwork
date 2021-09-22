//*********************************************************************************
//      AlarmMapDao.cs
//*********************************************************************************
// File Name: AlarmMapDao.cs
// Description: AlarmMapDao
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using System.IO;
using System.Reflection;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class AlarmMapDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string filePath =
            Environment.CurrentDirectory + System.Configuration.ConfigurationManager.AppSettings.Get("CsvConfig") + "ALARMMAP" + ".csv";

        public List<AlarmMap> loadAlarmMapsByEQRealID(string eqpt_real_id) 
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();
                DataTable dt = scApp.AlarmMap;
                List<AlarmMap> rtnAlarmMapLst = null;

                lock (scApp.AlarmMap)
                {
                    var query = from c in dt.AsEnumerable()
                                where c.Field<string>("EQPT_REAL_ID").Trim() == eqpt_real_id.Trim()
                                select new AlarmMap
                                {
                                    EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                    ALARM_ID = c.Field<string>("ALARM_ID"),
                                    ALARM_LVL = c.Field<string>("ALARM_LVL"),
                                    ALARM_DESC = c.Field<string>("ALARM_DESC"),
                                    ALARM_STATION = c.Field<string>("ALARM_STATION"),
                                    SOLUTION = c.Field<string>("SOLUTION") 
                                };

                    rtnAlarmMapLst = query.OrderBy(a => a.ALARM_ID.PadLeft(10, ' ')).ToList();
                }

                return rtnAlarmMapLst;
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }       

        public AlarmMap getAlarmMap(string eqpt_real_id, string alarm_id) 
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();
                DataTable dt = scApp.AlarmMap;
                AlarmMap rtnAlarmMap = null;

                lock (scApp.AlarmMap)
                {
                    var query = from c in dt.AsEnumerable()
                                where c.Field<string>("EQPT_REAL_ID").Trim() == eqpt_real_id.Trim() &&
                                c.Field<string>("ALARM_ID").Trim() == alarm_id.Trim()
                                select new AlarmMap
                                {
                                    EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                    ALARM_ID = c.Field<string>("ALARM_ID"),
                                    ALARM_LVL = c.Field<string>("ALARM_LVL"),
                                    ALARM_DESC = c.Field<string>("ALARM_DESC"),
                                    ALARM_STATION = c.Field<string>("ALARM_STATION"),
                                    SOLUTION = c.Field<string>("SOLUTION")
                                };

                    rtnAlarmMap = query.SingleOrDefault();
                }

                return rtnAlarmMap;
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public bool addAlarmMap(AlarmMap alarmMap)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();
                DataRow newRow = scApp.AlarmMap.NewRow();

                newRow["EQPT_REAL_ID"] = alarmMap.EQPT_REAL_ID;
                newRow["ALARM_ID"] = alarmMap.ALARM_ID;
                newRow["ALARM_LVL"] = alarmMap.ALARM_LVL;
                newRow["ALARM_DESC"] = alarmMap.ALARM_DESC;
                newRow["ALARM_STATION"] = alarmMap.ALARM_STATION;
                newRow["SOLUTION"] = alarmMap.SOLUTION;

                lock (scApp.AlarmMap)
                {
                    scApp.AlarmMap.Rows.Add(newRow);
                }
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return true;
        }

        public bool updateAlarmMap(AlarmMap alarmMap)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();

                lock (scApp.AlarmMap)
                {
                    foreach (DataRow dr in scApp.AlarmMap.Rows)
                    {
                        if (BCFUtility.isMatche(dr["EQPT_REAL_ID"], alarmMap.EQPT_REAL_ID) && BCFUtility.isMatche(dr["ALARM_ID"], alarmMap.ALARM_ID))
                        {
                            dr["ALARM_LVL"] = alarmMap.ALARM_LVL;
                            dr["ALARM_DESC"] = alarmMap.ALARM_DESC;
                            dr["ALARM_STATION"] = alarmMap.ALARM_STATION;
                            dr["SOLUTION"] = alarmMap.SOLUTION;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return true;
        }

        public bool deleteAlarmMap(string eqpt_real_id, string alarm_id)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();

                lock (scApp.AlarmMap)
                {
                    foreach (DataRow dr in scApp.AlarmMap.Rows)
                    {
                        if (BCFUtility.isMatche(dr["EQPT_REAL_ID"], eqpt_real_id) && BCFUtility.isMatche(dr["ALARM_ID"], alarm_id))
                        {
                            dr.Delete();
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return true;
        }

        public bool saveAllEqptAlarmMapToCsv(List<AlarmMap> lstAlarmMap)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    string csv = ToCsv<AlarmMap>(",", lstAlarmMap);
                    wr.Write(csv);
                    wr.Close();
                }
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return true;
        }

        private static string ToCsv<T>(string separator, IEnumerable<T> objectlist)
        {
            Type t = typeof(T);
            PropertyInfo[] Propertys = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance
            | BindingFlags.Public);

            string header = String.Join(separator, Propertys.Select(f => f.Name).ToArray());

            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in objectlist)
                csvdata.AppendLine(ToCsvFields(separator, Propertys, o));

            return csvdata.ToString();
        }

        private static string ToCsvFields(string separator, PropertyInfo[] Propertys, object o)
        {
            StringBuilder linie = new StringBuilder();

            foreach (var f in Propertys)
            {
                if (linie.Length > 0)
                    linie.Append(separator);

                var x = f.GetValue(o);

                if (x != null)
                    linie.Append(x.ToString());
            }

            return linie.ToString();
        }

    }
}
