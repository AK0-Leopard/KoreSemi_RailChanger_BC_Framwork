using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class SequenceDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertSequence(DBConnection conn, Sequence seq)
        {
            try
            {
                conn.Save(seq);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public void updateSequence(DBConnection conn, Sequence seq)
        {
            try
            {
                conn.Update(seq);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public Sequence getSequence(DBConnection conn, Boolean readLock, string seq_name)
        {
            Sequence rtnSeq = null;
            try
            {
                rtnSeq = conn.Query<Sequence>().Where(s => s.Seq_Name.Trim() == seq_name.Trim()).SingleOrDefault();
                if (rtnSeq != null && readLock)
                {
                    conn.Lock(rtnSeq, LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnSeq;
        }

    }
}
