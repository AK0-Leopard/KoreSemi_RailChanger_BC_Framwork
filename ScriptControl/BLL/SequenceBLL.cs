using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class SequenceBLL
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private SequenceDao seqDao = null;

        public SequenceBLL()        
        {
        }

        public void start(SCApplication scApp) 
        {
            this.scApp = scApp;
            seqDao = scApp.SequenceDao;
        }

        /// <summary>
        /// 取得Robot CMD Sequence
        /// </summary>
        /// <returns></returns>
        public int getRobotCMDNumberString()
        {
            long seqVal = getRobotCMDSeqNumber();
            return Convert.ToInt32(seqVal);
        }

        /// <summary>
        /// 取得CST Sequence
        /// </summary>
        /// <returns></returns>
        public long getRobotCMDSeqNumber()
        {
            lock (SCAppConstants.SEQUENCE_NAME_RobotCMD_SEQUENCE)
            {
                long seqVal = 0;
                DBConnection conn = null;
                try
                {
                    conn = scApp.getDBConnection();
                    conn.BeginTransaction();

                    Sequence seq = seqDao.getSequence(conn, true, SCAppConstants.SEQUENCE_NAME_RobotCMD_SEQUENCE);
                    if (seq == null)
                    {
                        seqVal = SCAppConstants.ROBOTCMD_SEQUENCE_NUMBER_MIN;
                        seq = new Sequence()
                        {
                            Seq_Name = SCAppConstants.SEQUENCE_NAME_RobotCMD_SEQUENCE,
                            Record_Time = DateTime.Now,
                            Nxt_Val = seqVal + 1
                        };
                        seqDao.insertSequence(conn, seq);
                    }
                    else
                    {
                        seqVal = seq.Nxt_Val;
                        if (seqVal >= SCAppConstants.ROBOTCMD_SEQUENCE_NUMBER_MAX)
                        {
                            seq.Nxt_Val = SCAppConstants.ROBOTCMD_SEQUENCE_NUMBER_MIN;
                        }
                        else
                        {
                            seq.Nxt_Val = seqVal + 1;
                        }
                        seq.Record_Time = DateTime.Now;
                        seqDao.updateSequence(conn, seq);
                    }
                    conn.Commit();
                }
                catch (Exception ex)
                {
                    if (conn != null) { try { conn.Rollback(); } catch { } }
                    return seqVal;
                }
                finally
                {
                    if (conn != null) { try { conn.Close(); } catch { } }
                }
                return seqVal;
            }
        }

        /// <summary>
        /// 取得JSON HOST Sequence
        /// </summary>
        /// <returns></returns>
        public String getHostSeqNumberString()
        {
            long seqVal = getHostSeqNumber();
            return seqVal.ToString().PadLeft(5, '0');
        }

        /// <summary>
        /// 取得JSON HOST Sequence
        /// </summary>
        /// <returns></returns>
        public long getHostSeqNumber()
        {
            lock (SCAppConstants.SEQUENCE_NAME_HOST_SEQUENCE)
            {
                if (scApp.SEQ_NO == null || scApp.SEQ_NO == 0) {
                    scApp.SEQ_NO = SCAppConstants.JSON_HOST_SEQUENCE_NUMBER_MIN;
                }
                else if (scApp.SEQ_NO > SCAppConstants.JSON_HOST_SEQUENCE_NUMBER_MAX) {
                    scApp.SEQ_NO = SCAppConstants.JSON_HOST_SEQUENCE_NUMBER_MIN;
                }
                long seqVal = scApp.SEQ_NO;
                scApp.SEQ_NO++;

                return seqVal;
            }
        }


    }
}
