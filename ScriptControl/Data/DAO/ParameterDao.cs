//*********************************************************************************
//      ParameterDao.cs
//*********************************************************************************
// File Name: ParameterDao.cs
// Description: ParameterDao類別
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
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.DAO
{
    public class ParameterDao : DaoBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 新增Parameter
        /// </summary>
        /// <param name="para">Parameter</param>
        /// <returns></returns>
        public void inserParameter(DBConnection conn, Parameter para)
        {
            try
            {
                conn.SaveOrUpdate(para);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 更新Parameter
        /// </summary>
        /// <param name="para">Parameter</param>
        /// <returns></returns>
        public void updateParameter(DBConnection conn, Parameter para)
        {
            try
            {
                conn.Update(para);
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

        /// <summary>
        /// 根據Category、ID取得Parameter
        /// </summary>
        /// <param name="para_cate">Parameter Category</param>
        /// <param name="para_id">Parameter ID</param>
        /// <returns>回覆找到的Parameter</returns>
        public Parameter getParameter(DBConnection conn, string para_cate, string para_id)
        {
            Parameter rtnPara = null;
            try
            {
                rtnPara = conn.Query<Parameter>().Where(p => p.ParaPK.Para_Cate.Trim() == para_cate.Trim() && p.ParaPK.Para_ID.Trim() == para_id.Trim()).SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnPara;
        }

        /// <summary>
        /// 根據Category取得Parameter
        /// </summary>
        /// <param name="para_cate">Parameter Category</param>
        /// <returns>回覆找到的Parameter List</returns>
        public List<Parameter> loadParameterByCate(DBConnection conn, string para_cate)
        {
            List<Parameter> rtnParaList = null;
            try
            {
                rtnParaList = conn.Query<Parameter>().Where(p => p.ParaPK.Para_Cate.Trim() == para_cate.Trim()).ToList();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
            return rtnParaList;
        }

        /// <summary>
        /// 根據Category、ID刪除Parameter
        /// </summary>
        /// <param name="para_cate">Parameter Category</param>
        /// <param name="para_id">Parameter ID</param>
        /// <returns></returns>
        public void deleteParameter(DBConnection conn, string para_cate, string para_id)
        {
            try
            {
                Parameter delPara = conn.Query<Parameter>().Where(p => p.ParaPK.Para_Cate.Trim() == para_cate.Trim() && p.ParaPK.Para_ID.Trim() == para_id.Trim()).SingleOrDefault();
                if (delPara != null)  //A0.01
                {                     //A0.01
                    conn.Delete(delPara);
                }                     //A0.01
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
                throw;
            }
        }

    }
}
