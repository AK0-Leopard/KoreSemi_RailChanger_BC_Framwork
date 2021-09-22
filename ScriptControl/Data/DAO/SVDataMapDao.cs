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
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class SVDataMapDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<SVDataMap> loadSVDataMapsByEQRealID(string eqpt_real_id)
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["SVDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("EQPT_REAL_ID") == eqpt_real_id
                            select new SVDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                SVID = c.Field<string>("SVID"),
                                SVNAME = c.Field<string>("SVNAME")
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public List<SVDataMap> loadBySVID(List<string> svidList)
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["SVDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            where svidList.Contains(c.Field<string>("SVID").Trim())
                            select new SVDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                SVID = c.Field<string>("SVID"),
                                SVNAME = c.Field<string>("SVNAME")
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public SVDataMap getBySVID(string svid) 
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["SVDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            where BCFUtility.isMatche(c.Field<string>("SVID"), svid)
                            select new SVDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                SVID = c.Field<string>("SVID"),
                                SVNAME = c.Field<string>("SVNAME")
                            };
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

        public List<SVDataMap> loadAllSVData()
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["SVDATAMAP"];
                var query = from c in dt.AsEnumerable()
                            select new SVDataMap
                            {
                                EQPT_REAL_ID = c.Field<string>("EQPT_REAL_ID"),
                                SVID = c.Field<string>("SVID"),
                                SVNAME = c.Field<string>("SVNAME")
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw ;
            }
        }

    }
}
