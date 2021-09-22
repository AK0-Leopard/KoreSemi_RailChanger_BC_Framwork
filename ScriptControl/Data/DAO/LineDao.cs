//*********************************************************************************
//      LineDao.cs
//*********************************************************************************
// File Name: LineDao.cs
// Description: Line DAO
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
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NHibernate.Linq;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class LineDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertLine(DBConnection conn, Line line) 
        {
            try
            {
                conn.Save(line);
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateLine(DBConnection conn, Line line) 
        {
            try
            {
                conn.Update(line);
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
                throw;
            }
        }

        public Line getFirstLine(DBConnection conn, Boolean readLock)
        {
            Line rtnLine = null;
            try 
            {
                rtnLine = conn.Query<Line>().FirstOrDefault();
                if (rtnLine != null && readLock) 
                {
                    conn.Lock(rtnLine, LockMode.Upgrade);
                }
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLine;
        }

        public Line getLineByID(DBConnection conn, Boolean readLock, string line_id) 
        {
            Line rtnLine = null;
            try
            {
                rtnLine = conn.Query<Line>().Where(o => o.Line_ID == line_id).FirstOrDefault();
                if (rtnLine != null && readLock)
                {
                    conn.Lock(rtnLine, LockMode.Upgrade);
                }
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLine;
        }

        public List<Line> loadAllLineInDB(DBConnection conn) 
        {
            List<Line> rtnLine = new List<Line>();
            try
            {
                rtnLine = conn.Query<Line>().ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnLine;
        }

        public void updateLineHostMode(DBConnection conn, string line_id, int host_mode) 
        {
            try
            {
                Line line = getLineByID(conn, true, line_id);
                line.Host_Mode = host_mode;
                conn.Update(line);
            }
            catch (Exception ex) 
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateLineStatus(DBConnection conn, string line_id, int line_stat)
        {
            try
            {
                Line line = getLineByID(conn, true, line_id);
                line.Line_Stat = line_stat;
                conn.Update(line);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void deleteLineByLineID(DBConnection conn, string line_id) 
        {
            try
            {
                Line line = getLineByID(conn, false, line_id);
                if (line != null)  //A0.01
                {                  //A0.01
                    conn.Delete(line);
                }                  //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void deleteAllLine(DBConnection conn) 
        {
            try
            {
                List<Line> allLines = loadAllLineInDB(conn);
                if (allLines != null)  //A0.01
                {                      //A0.01
                    foreach (Line line in allLines)
                    {
                        conn.Delete(line);
                    }
                }                      //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }
    }
}
