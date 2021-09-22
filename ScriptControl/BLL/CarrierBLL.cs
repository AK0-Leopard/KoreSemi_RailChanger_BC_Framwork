//*********************************************************************************
//      CarrierBLL.cs
//*********************************************************************************
// File Name: CarrierBLL.cs
// Description: 業務邏輯：Sheet
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2021/03/15    Steven Hong    N/A            A0.01   新增Load Carrier By Bay
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using System.Reflection;
using com.mirle.ibg3k0.sc.Data.SECS;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using System.Threading;
using System.Diagnostics;
using Nancy.Json;
using com.mirle.ibg3k0.WpfTools;
using com.mirle.ibg3k0.sc.webAPI;
using com.mirle.ibg3k0.mqc.tx;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class CarrierBLL
    {
        protected SCApplication scApp = null;
        private MirleGoUiApp mgoApp = null;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        private Logger logger_ASRSRequest = LogManager.GetLogger("ASRSRequest");

        private CarrierDao carrierDao = null;
        private CarrierHisDao carrierHisDao = null;

        private LineBLL lineBLL = null;

        public CarrierBLL()
        {

        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            carrierDao = scApp.CarrierDao;
            carrierHisDao = scApp.CarrierHisDao;
            lineBLL = scApp.LineBLL; 
        }

        public bool creatCarrier(Carrier crr)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                carrierDao.insertCarrier(conn, crr);
                creatCarrierHisByCarrier(conn, crr);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to ACARRIER [Carrier ID:{0}][Message:{1}]", crr.Crr_ID, ex.ToString());

                rtnCode =  false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        public bool updateCarrier(Carrier crr)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                carrierDao.updateCarrier(conn, crr);
                creatCarrierHisByCarrier(conn, crr);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to ACARRIER [Carrier ID:{0}][Message:{1}]", crr.Crr_ID, ex.ToString());

                rtnCode =  false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 根據ID取的對應Carrier
        /// </summary>
        /// <param name="crr_id">Carrier ID</param>
        /// <returns>Carrier</returns>
        public Carrier getCarrier(string crr_id)
        {
            Carrier crr = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                crr = carrierDao.getCarrier(conn, false, crr_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From ACARRIER [Carrier ID:{0}][Message:{1}]", crr_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return crr;
        }

        public Carrier getCarrierByLocation(string location)
        {
            Carrier crr = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                crr = carrierDao.getCarrierByLocation(conn, location);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From ACARRIER [Location:{0}][Message:{1}]", location, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return crr;
        }

        public List<Carrier> getCarrierAtMGV(string location)
        {
            List<Carrier> crrLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                crrLst = carrierDao.getCarrierAtMGV(conn, location);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From ACARRIER [Location:{0}][Message:{1}]", location, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return crrLst;
        }

        /// <summary>
        /// 要求空Carrier
        /// </summary>
        /// <returns>回覆空Carrier</returns>
        public List<Carrier> loadEmptyCarrier()
        {
            List<Carrier> rtnCrrList = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnCrrList = carrierDao.loadEmptyCarrier(conn);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Empty Carrier Failed From ACARRIER", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCrrList;
        }

        /// <summary>
        /// 根據Carrier Type要求Carrier
        /// </summary>
        /// <param name="crr_type">Carrier Type</param>
        /// <returns>回覆Carrier</returns>
        public List<Carrier> loadCarrierByType(string crr_type)
        {
            List<Carrier> rtnCrrList = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnCrrList = carrierDao.loadCarrierByType(conn, crr_type);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Carrier Failed From ACARRIER By [Type:{0}][Message:{1}]", crr_type.ToString(), ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCrrList;
        }

        /// <summary>
        /// 根據Carrier Type要求空Carrier
        /// </summary>
        /// <param name="crr_type">Carrier Type</param>
        /// <returns>回覆空Carrier</returns>
        public List<Carrier> loadEmptyCarrierByType(string crr_type)
        {
            List<Carrier> rtnCrrList = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnCrrList = carrierDao.loadEmptyCarrierByType(conn, crr_type);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Empty Carrier Failed From ACARRIER By [Type:{0}][Message:{1}]", crr_type.ToString(), ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCrrList;
        }

        /// <summary>
        /// 要求不在Stocker、搬出口的Carrier
        /// </summary>
        /// <returns>回覆Carrier</returns>
        public List<Carrier> loadTransferCarrier()
        {
            List<Carrier> rtnCrrList = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnCrrList = carrierDao.loadTransferCarrier(conn);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Transfer Carrier Failed From ACARRIER By [Message:{0}]", ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCrrList;
        }

        //A0.0 1 Start
        /// <summary>
        /// 根據Bay ID要求Carrier
        /// </summary>
        /// <param name="bay_id">Bay ID</param>
        /// <returns>回覆Carrier</returns>
        public List<Carrier> loadCarrierByBay(string bay_id)
        {
            List<Carrier> rtnCrrList = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnCrrList = carrierDao.loadCarrierByBay(conn, bay_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Carrier Failed From ACARRIER By [Bay ID:{0}][Message:{1}]", bay_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCrrList;
        }
        //A0.01 End

        public bool deleteCarrier(string crr_id)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                carrierDao.deleteCarrier(conn, crr_id);
                creatCarrierHisByCarrierForDelete(conn, crr_id);  //A0.04
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete Failed to ACARRIER [Carrier ID:{0}][Message:{1}]", crr_id, ex.ToString());

                rtnCode =  false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 新增Carrier History
        /// </summary>
        /// <param name="crrHis">Carrier History</param>
        /// <returns></returns>
        public bool creatCarrierHis(CarrierHis crrHis)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                carrierHisDao.insertCarrierHis(conn, crrHis);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to ACARRIERHIS [Carrier ID:{0}][Message:{1}]", crrHis.Crr_ID, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 新增Carrier History By Carrier
        /// </summary>
        /// <param name="conn">DB Connection</param>
        /// <param name="crr">Carrier</param>
        /// <returns></returns>
        public bool creatCarrierHisByCarrier(DBConnection conn, Carrier crr)
        {
            bool rtnCode = true;

            try
            {
                CarrierHis crrHis = new CarrierHis();
                crrHis.Log_Sno = DateTime.Now.ToString(SCAppConstants.TimestampFormat_17);
                crrHis.Crr_ID = crr.Crr_ID;
                crrHis.Crr_Stat = crr.Crr_Stat;
                crrHis.Crr_TrxStat = crr.Crr_TrxStat;
                crrHis.Loc = crr.Loc;
                crrHis.To_PortNo = crr.To_PortNo;
                crrHis.Priority = crr.Priority;
                crrHis.Cst_Type = crr.Cst_Type;
                crrHis.CrrStockIn_Time = crr.CrrStockIn_Time;
                crrHis.CrrLogOn_Time = crr.CrrLogOn_Time;
                crrHis.CrrLogOff_Time = crr.CrrLogOff_Time;
                crrHis.CrrLogOff_Port = crr.CrrLogOff_Port;
                crrHis.HoldFlag = crr.HoldFlag;
                crrHis.Ticket_No = crr.Ticket_No;
                crrHis.Alternate = crr.Alternate;
                crrHis.Reserve_Flag = crr.Reserve_Flag;
                crrHis.Zone_Code = crr.Zone_Code;
                crrHis.Inventory_Flag = crr.Inventory_Flag;
                crrHis.Create_Time = crr.Create_Time;
                crrHis.Trn_User = "BC";
                crrHis.Trn_Date = DateTime.Now.ToString(SCAppConstants.DateTimeFormat_19);
                crrHis.Schedule = crr.Schedule;
                crrHis.RotFlag = crr.RotFlag;
                crrHis.FliFlag = crr.FliFlag;
                crrHis.BCRRead_Flag = crr.BCRRead_Flag;
                crrHis.Reject_Flag = crr.Reject_Flag;
                crrHis.Crr_Size = crr.Crr_Size;

                carrierHisDao.insertCarrierHis(conn, crrHis);
            }
            catch (Exception ex)
            {
                logger.Warn("Insert Failed to ACARRIERHIS [Carrier ID:{0}][Message:{1}]", crr.Crr_ID, ex.ToString());
                rtnCode = false;
                throw;
            }

            return rtnCode;
        }

        /// <summary>
        /// 新增Carrier History By Carrier For Delete
        /// </summary>
        /// <param name="conn">DB Connection</param>
        /// <param name="crr">Carrier</param>
        /// <returns></returns>
        public bool creatCarrierHisByCarrierForDelete(DBConnection conn, string crr_id)
        {
            bool rtnCode = true;

            try
            {
                CarrierHis crrHis = new CarrierHis();
                crrHis.Log_Sno = DateTime.Now.ToString(SCAppConstants.TimestampFormat_17);
                crrHis.Crr_ID = crr_id;
                crrHis.Crr_Stat = 0;
                crrHis.Crr_TrxStat = 0;
                crrHis.Loc = string.Empty;
                crrHis.To_PortNo = string.Empty;
                crrHis.Priority = 0;
                crrHis.Cst_Type = string.Empty;
                crrHis.CrrStockIn_Time = null;
                crrHis.CrrLogOn_Time = null;
                crrHis.CrrLogOff_Time = null;
                crrHis.CrrLogOff_Port = string.Empty;
                crrHis.HoldFlag = string.Empty;
                crrHis.Ticket_No = string.Empty;
                crrHis.Alternate = string.Empty;
                crrHis.Reserve_Flag = string.Empty;
                crrHis.Zone_Code = string.Empty;
                crrHis.Inventory_Flag = string.Empty;
                crrHis.Create_Time = null;
                crrHis.Trn_User = "BC";
                crrHis.Trn_Date = DateTime.Now.ToString(SCAppConstants.DateTimeFormat_19);
                crrHis.Schedule = string.Empty;
                crrHis.RotFlag = string.Empty;
                crrHis.FliFlag = string.Empty;
                crrHis.BCRRead_Flag = string.Empty;
                crrHis.Reject_Flag = string.Empty;
                crrHis.Crr_Size = string.Empty;

                carrierHisDao.insertCarrierHis(conn, crrHis);
            }
            catch (Exception ex)
            {
                logger.Warn("Insert Failed to ACARRIERHIS [Carrier ID:{0}][Message:{1}]", crr_id, ex.ToString());
                rtnCode = false;
                throw;
            }

            return rtnCode;
        }

        /// <summary>
        /// 刪除Carrier History
        /// </summary>
        /// <param name="crrHis">Carrier History</param>
        /// <returns></returns>
        public bool deleteCarrierHis(CarrierHis crrHis)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                carrierHisDao.deleteCarrierHis(conn, crrHis);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete Failed to ACARRIERHIS [Carrier ID:{0}][Message:{1}]", crrHis.Crr_ID, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        public Carrier creatUnknownCrr(string loc)
        {
            Carrier crr = new Carrier();

            try
            {
                crr.Crr_ID = getUnknownCrrID();
                crr.Crr_Stat = SCAppConstants.CrrStat.EMPTY;
                crr.Crr_TrxStat = SCAppConstants.CrrTrxStat.Complete;
                crr.HoldFlag = SCAppConstants.CrrHoldStat.Hold;
                crr.Loc = loc;
                crr.BCRRead_Flag = SCAppConstants.MGBCRReadFlag.initialALLReadFlag();
                crr.Reject_Flag = SCAppConstants.NO_FLAG;
                crr.Reserve_Flag = SCAppConstants.NO_FLAG;
                crr.Schedule = "NA";

                creatCarrier(crr);
            }
            catch (Exception ex)
            {
                logger.Warn("Get Unknown Crr ID Failed[Message:{0}]", ex.ToString());
            }

            return crr;
        }

        Object _serLock = new Object();
        private string getUnknownCrrID()
        {
            string crr_id = string.Empty;

            lock (_serLock)
            {
                try
                {
                    string dateTime = DateTime.Now.ToString("yy") + DateTime.Now.DayOfYear.ToString().PadLeft(3, '0');
                    int serial = 0;

                    Parameter para = scApp.LineBLL.getParameter(SCAppConstants.ParameterCate.Serial_No, SCAppConstants.ParameterID.Unknow_Crr);
                    if (para == null)
                    {
                        para = new Parameter();
                        para.Para_Cate = SCAppConstants.ParameterCate.Serial_No;
                        para.Para_ID = SCAppConstants.ParameterID.Unknow_Crr;
                        para.Val_1 = "1";
                        para.Val_2 = "999";
                        para.Val_3 = dateTime;
                        para.Para_Desc = "Serial No-Unknow Crr";

                        scApp.LineBLL.creatParameter(para);
                    }

                    if (!SCUtility.isMatche(para.Val_3, dateTime))
                    {
                        para.Val_1 = "2";
                        para.Val_3 = dateTime;
                        scApp.LineBLL.updateParameter(para);

                        serial = 1;
                    }
                    else
                    {
                        serial = int.Parse(para.Val_1);

                        para.Val_1 = (serial + 1).ToString();
                        scApp.LineBLL.updateParameter(para);
                    }

                    crr_id = "UN" + dateTime + serial.ToString().PadLeft(3, '0');
                }
                catch (Exception ex)
                {
                    logger.Warn("Get Unknown Crr ID Failed[Message:{0}]", ex.ToString());
                }
            }

            return crr_id;
        }

    }
}
