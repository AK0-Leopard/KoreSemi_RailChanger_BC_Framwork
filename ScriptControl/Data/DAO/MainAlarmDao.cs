//*********************************************************************************
//      MainAlarmDao.cs
//*********************************************************************************
// File Name: MainAlarmDao.cs
// Description: MainAlarmDao
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************

using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class MainAlarmDao
    {
        string TableName_MAINALARM = "MAINALARM";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string filePath = Environment.CurrentDirectory + @"\Config\" + "MAINALARM" + ".csv";

        public List<MainAlarm> loadAllMAINALARM()
        {
            List<MainAlarm> lstMainAlarm = null;
            try
            {
                //查尋DataTable的欄位
                SCApplication scApp = SCApplication.getInstance();
                DataTable dt = scApp.MainAlarm;

                lock (scApp.MainAlarm)
                {
                    if (dt != null)
                    {
                        var query = from c in dt.AsEnumerable()
                                    select new MainAlarm
                                    {
                                        CODE = c.Field<string>("CODE"),
                                        DESCRIPTION = c.Field<string>("DESCRIPTION"),
                                        ACTION = c.Field<string>("ACTION"),
                                    };
                        lstMainAlarm = query.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            return lstMainAlarm;
        }

        public MainAlarm getMainAlarmByCode(string code)
        {
            MainAlarm mainAlarm = null;
            try
            {
                //查尋DataTable的欄位
                SCApplication scApp = SCApplication.getInstance();
                DataTable dt = scApp.MainAlarm;

                lock (scApp.MainAlarm)
                {
                    if (dt != null)
                    {
                        var query = from c in dt.AsEnumerable()
                                    where c.Field<string>("CODE").Trim() == code.Trim()
                                    select new MainAlarm
                                    {
                                        CODE = c.Field<string>("CODE"),
                                        DESCRIPTION = c.Field<string>("DESCRIPTION"),
                                        ACTION = c.Field<string>("ACTION"),
                                    };
                        mainAlarm = query.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
            return mainAlarm;
        }

        public bool addMainAlarm(MainAlarm mainAlarm)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();
                DataRow newRow = scApp.MainAlarm.NewRow();

                newRow["CODE"] = mainAlarm.CODE;
                newRow["DESCRIPTION"] = mainAlarm.DESCRIPTION;
                newRow["ACTION"] = mainAlarm.ACTION;

                lock (scApp.MainAlarm)
                {
                    scApp.MainAlarm.Rows.Add(newRow);
                }
            }
            catch (IOException ex)
            {
                logger.Error(ex, "Exception:");
                return false;
            }

            return true;
        }

        public bool updateMainAlarm(MainAlarm mainAlarm)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();

                lock (scApp.MainAlarm)
                {
                    foreach (DataRow dr in scApp.MainAlarm.Rows)
                    {
                        if (BCFUtility.isMatche(dr["CODE"], mainAlarm.CODE))
                        {
                            dr["DESCRIPTION"] = mainAlarm.DESCRIPTION;
                            dr["ACTION"] = mainAlarm.ACTION;
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

        public bool deleteMainAlarm(string code)
        {
            try
            {
                SCApplication scApp = SCApplication.getInstance();

                lock (scApp.MainAlarm)
                {
                    foreach (DataRow dr in scApp.MainAlarm.Rows)
                    {
                        if (BCFUtility.isMatche(dr["CODE"], code))
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

        public bool saveMainAlarmToCsv(List<MainAlarm> lstMainAlarm)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    string csv = ToCsv<MainAlarm>(",", lstMainAlarm);
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