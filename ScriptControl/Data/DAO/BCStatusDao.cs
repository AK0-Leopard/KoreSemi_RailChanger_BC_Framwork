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
    public class BCStatusDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void insertBCStat(DBConnection conn, BCStatus bc) 
        {
            try
            {
                conn.Save(bc);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public void updateBCStat(DBConnection conn, BCStatus bc)
        {
            try
            {
                conn.Update(bc);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public BCStatus getBCStatByID(DBConnection conn, Boolean readLock, string bc_id) 
        {
            BCStatus rtnBC = null;
            try
            {
                rtnBC = conn.Query<BCStatus>().Where(o => o.BC_ID.Trim() == bc_id.Trim()).FirstOrDefault();
                if (rtnBC != null && readLock)
                {
                    conn.Lock(rtnBC, LockMode.Upgrade);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnBC;
        }

        public void deleteBCStatByID(DBConnection conn, string bc_id) 
        {
            try
            {
                BCStatus deleteBC = conn.Query<BCStatus>().Where(l => l.BC_ID.Trim() == bc_id.Trim()).SingleOrDefault();
                if (deleteBC != null)
                {
                    conn.Delete(deleteBC);
                }
            }
            catch (Exception ex)
            {
                logger.WarnException("Delete BC Status", ex);
                throw;
            }
        }

    }
}
