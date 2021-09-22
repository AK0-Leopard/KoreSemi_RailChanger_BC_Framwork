//*********************************************************************************
//      CarrierHisDao.cs
//*********************************************************************************
// File Name: CarrierHisDao.cs
// Description: CarrierHisDao類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Data;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class CarrierHisDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 新增Carrier History
        /// </summary>
        /// <param name="crrHis">Carrier History</param>
        /// <returns></returns>
        public void insertCarrierHis(DBConnection conn, CarrierHis crrHis)
        {
            try
            {
                conn.SaveOrUpdate(crrHis);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 刪除Carrier History
        /// </summary>
        /// <param name="crrHis">Carrier History</param>
        /// <returns></returns>
        public void deleteCarrierHis(DBConnection conn, CarrierHis crrHis)
        {
            try
            {
                if (crrHis != null) 
                {
                    conn.Delete(crrHis);
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }


    }
}
