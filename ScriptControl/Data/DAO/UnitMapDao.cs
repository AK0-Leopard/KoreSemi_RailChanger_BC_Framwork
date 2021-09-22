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
    public class UnitMapDao
    {
        public UnitMap getByEqptPosition(String Eqpt_ID, String UNIT_NO)
        {
            try
            {
                //查尋DataTable的欄位
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["UNITMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("EQPT_ID") == Eqpt_ID && c.Field<string>("UNIT_NO") == UNIT_NO
                            select new UnitMap
                            {
                                EQPT_ID = c.Field<string>("EQPT_ID"),
                                UNIT_NO = c.Field<string>("UNIT_NO"),
                                UNIT_ID = c.Field<string>("UNIT_ID"),
                                FULL_UNIT_ID = c.Field<string>("FULL_UNIT_ID"),
                                DESCRIPTION = c.Field<string>("DESCRIPTION"),
                            };
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UnitMap> getAllUnitByEqptID(String Eqpt_ID)
        {
            try
            {
                //查尋DataTable的欄位
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["UNITMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("EQPT_ID") == Eqpt_ID
                            select new UnitMap
                            {
                                EQPT_ID = c.Field<string>("EQPT_ID"),
                                UNIT_NO = c.Field<string>("UNIT_NO"),
                                UNIT_ID = c.Field<string>("UNIT_ID"),
                                FULL_UNIT_ID = c.Field<string>("FULL_UNIT_ID"),
                                DESCRIPTION = c.Field<string>("DESCRIPTION"),
                            };
                if (query.Count() == 0)
                    return null;
                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
    }
}