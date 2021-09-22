using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class EqptMapDao
    {
        public EqptMap getByIND_ID(String IND_ID,String NX)
        {            
            try
            {
                //查尋DataTable的欄位
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["EQPTMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("IND_ID") == IND_ID.Trim() && c.Field<string>("EQPT_NAME") == NX.Trim()
                            select new EqptMap
                            {
                                IND_ID = c.Field<string>("IND_ID"),
                                EQPT_NAME = c.Field<string>("EQPT_NAME"),
                                EQPT_REAL_ID = c.Field<string>("EQPT_ID"),
                            };
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                //logger.Warn(ex);
                throw;
            }
        }
    }
}