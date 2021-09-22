//*********************************************************************************
//      RgvPortMapDao.cs
//*********************************************************************************
// File Name: RgvPortMapDao.cs
// Description: RGV Port Map DAO
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/23    Steven Hong    N/A            A0.01   增加By Port讀取RgvPortMap
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class PortPosMapDao
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PortPosMap getPortPosMapByPortID(string port_id)
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["PORTPOSMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("PORT_ID").Trim() == port_id.Trim()
                            select new PortPosMap
                            {
                                Port_ID = c.Field<string>("PORT_ID"),
                                Cim_EQ_ID = c.Field<string>("CIM_EQ_ID"),
                                Reader_ID = c.Field<string>("READER_ID"),
                                Reader_ID_Upper = c.Field<string>("READER_ID_UPPER"),
                                Device_ID = c.Field<string>("DEVICE_ID"),
                                Index = c.Field<string>("INDEX"),
                                Description = c.Field<string>("DESCRIPTION")
                            };
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        public PortPosMap getPortPosMapByCIMEQID(string eq_id)
        {
            try
            {
                DataTable dt = SCApplication.getInstance().IndxerConfig.Tables["PORTPOSMAP"];
                var query = from c in dt.AsEnumerable()
                            where c.Field<string>("CIM_EQ_ID").Trim() == eq_id.Trim()
                            select new PortPosMap
                            {
                                Port_ID = c.Field<string>("PORT_ID"),
                                Cim_EQ_ID = c.Field<string>("CIM_EQ_ID"),
                                Reader_ID = c.Field<string>("READER_ID"),
                                Reader_ID_Upper = c.Field<string>("READER_ID_UPPER"),
                                Device_ID = c.Field<string>("DEVICE_ID"),
                                Index = c.Field<string>("INDEX"),
                                Description = c.Field<string>("DESCRIPTION")
                            };
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }
}
