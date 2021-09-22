//*********************************************************************************
//      LineBLL.cs
//*********************************************************************************
// File Name: LineBLL.cs
// Description: 業務邏輯：Line、Zone、Node、Equipment、Unit機台基本修改
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//*********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.DAO;
using com.mirle.ibg3k0.sc.Data.VO;
using NHibernate;
using NLog;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.bcf.App;
using System.Reflection;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.sc.ValueHandler;
using com.mirle.ibg3k0.sc.ProtocolFormat;
using com.mirle.ibg3k0.Utility.ul.Data.VO;
using com.mirle.ibg3k0.sc.Data.SECS;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class LineBLL
    {
        private SCApplication scApp = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private LineDao lineDao = null;
        private ZoneDao zoneDao = null;
        private NodeDao nodeDao = null;
        private EqptDao eqptDao = null;
        private UnitDao unitDao = null;
        private PortDao portDao = null;
        private EqptMapDao eqptMapDao = null;
        private UnitMapDao unitMapDao = null;
        private SVDataMapDao svDataMapDao = null;
        private ECDataMapDao ecDataMapDao = null;
        private LocMstDao locMstDao = null;
        private LocDtlDao locDtlDao = null;
        private SnoCtlDao snoCtlDao = null;
        private ParameterDao parameterDao = null;
        private PortPosMapDao portPosMapDao = null;

        public LineBLL()
        {

        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            lineDao = scApp.LineDao;
            zoneDao = scApp.ZoneDao;
            nodeDao = scApp.NodeDao;
            eqptDao = scApp.EqptDao;
            unitDao = scApp.UnitDao;
            portDao = scApp.PortDao;
            eqptMapDao = scApp.EqptMapDao;
            unitMapDao = scApp.UnitMapDao;
            svDataMapDao = scApp.SVDataMapDao;
            ecDataMapDao = scApp.ECDataMapDao;
            locMstDao = scApp.LocMstDao;
            locDtlDao = scApp.LocDtlDao;
            snoCtlDao = scApp.SnoCtlDao;
            parameterDao = scApp.ParameterDao;
            portPosMapDao = scApp.PortPosMapDao;
        }

        public Line getFirstLine()
        {
            Line rtnLine = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnLine = lineDao.getFirstLine(conn, false);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Not Found Any Record from ALINE", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnLine;
        }

        /// <summary>
        /// 為確保系統僅保存一個Line，所以此Method還會刪除非此Line_id的資料
        /// </summary>
        /// <param name="line_id"></param>
        /// <returns></returns>
        public Line getLineByIDAndDeleteOtherLine(string line_id)
        {
            Line rtnLine = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                List<Line> allLines = lineDao.loadAllLineInDB(conn);
                foreach (Line line in allLines)
                {
                    if (BCFUtility.isMatche(line_id, line.Line_ID))
                    {
                        continue;
                    }
                    lineDao.deleteLineByLineID(conn, line.Line_ID);
                }
                rtnLine = lineDao.getLineByID(conn, false, line_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Not Found Record from ALINE [line_id:{0}][Message:{1}]", line_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnLine;
        }

        public List<Line> loadAllLineInDB()
        {
            List<Line> rtnLine = new List<Line>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnLine = lineDao.loadAllLineInDB(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Not Found Record from ALINE", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnLine;
        }

        public Boolean createLine(Line line)
        {
            return createLine(line.Line_ID, line.Host_Mode, line.Line_Stat);
        }

        public Boolean createLine(string line_id, int host_mode, int line_stat)
        {
            Boolean isSuccess = false;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                lineDao.deleteAllLine(conn);
                Line line = new Line()
                {
                    Line_ID = line_id,
                    Host_Mode = host_mode,
                    Line_Stat = line_stat
                };
                lineDao.insertLine(conn, line);
                conn.Commit();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to ALINE [line_id:{0}][Message:{1}]", line_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return isSuccess;
        }

        public Zone getZoneByZoneID(string zone_id)
        {
            Zone rtnZone = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnZone = zoneDao.getZoneByZoneID(conn, false, zone_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Not Found Record from AZONE [zone_id:{0}][Message:{1}]", zone_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnZone;
        }

        public Boolean createZone(Zone zone)
        {
            return createZone(zone.Zone_ID, zone.Line_ID);
        }

        public Boolean createZone(string zone_id, string line_id)
        {
            Boolean isSuccess = false;

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                Zone zone = new Zone
                {
                    Zone_ID = zone_id,
                    Line_ID = line_id
                };

                zoneDao.insertZone(conn, zone);

                conn.Commit();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to AZONE [zone_id:{0}][Message:{1}]", zone_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return isSuccess;
        }

        public Boolean createEquipment(Equipment eqpt)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                eqptDao.insertEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt.Eqpt_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }


        public Boolean updateLineHostMode(DBConnection conn, string line_id, int host_mode)
        {
            Boolean isBatchMode = (conn != null);
            try
            {
                if (!isBatchMode)
                {
                    conn = scApp.getDBConnection();
                    conn.BeginTransaction();
                }
                lineDao.updateLineHostMode(conn, line_id, host_mode);
                if (!isBatchMode)
                {
                    conn.Commit();
                }
            }
            catch (Exception ex)
            {
                if (conn != null && !isBatchMode) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Status Failed to ALINE [line_id:{0}][Message:{1}]", line_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null && !isBatchMode) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateLineStatus(DBConnection conn, string line_id, int line_stat)
        {
            Boolean isBatchMode = (conn != null);
            try
            {
                if (!isBatchMode)
                {
                    conn = scApp.getDBConnection();
                    conn.BeginTransaction();
                }
                lineDao.updateLineStatus(conn, line_id, line_stat);
                if (!isBatchMode)
                {
                    conn.Commit();
                }
            }
            catch (Exception ex)
            {
                if (conn != null && !isBatchMode) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to ALINE [line_id:{0}][Message:{1}]", line_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null && !isBatchMode) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateEQPT(Equipment eqpt)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                eqpt = conn.Session.Merge(eqpt);
                eqptDao.updateEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt.Eqpt_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateEQPTMode(string eqpt_id, int cim_mode, int oper_mode, int inline_mode)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Equipment eqpt = eqptDao.getEqptByEqptID(conn, true, eqpt_id);
                eqpt.CIM_Mode = cim_mode;
                eqptDao.updateEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Mode Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateEQPTAlarmStat(string eqpt_id, int alarm_stat, int warn_stat)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Equipment eqpt = eqptDao.getEqptByEqptID(conn, true, eqpt_id);
                eqptDao.updateEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Alarm Status Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateEQPTProcStat(string eqpt_id, int eqpt_proc_stat)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Equipment eqpt = eqptDao.getEqptByEqptID(conn, true, eqpt_id);
                eqpt.Eqpt_Proc_Stat = eqpt_proc_stat;
                eqptDao.updateEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Process Status Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateEQPTStat(string eqpt_id, string eqpt_stat)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Equipment eqpt = eqptDao.getEqptByEqptID(conn, true, eqpt_id);
                eqpt.Eqpt_Stat = eqpt_stat;
                eqptDao.updateEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Status Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateEQPTInlineMode(string eqpt_id, int inline_mode)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Equipment eqpt = eqptDao.getEqptByEqptID(conn, true, eqpt_id);
                //eqpt.Inline_Mode = inline_mode;
                eqptDao.updateEqpt(conn, eqpt);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to AEQPT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        #region checkLine Status For Ng Mode
        public bool checkHasNGPort()
        {
            bool hasNGPort = false;
            List<Port> listPort = SCApplication.getInstance().getEQObjCacheManager().getAllPort();
            foreach (Port p in listPort)
            {
                if (p.Port_Use_Typ == SCAppConstants.PortUseType.No_Good)
                {
                    hasNGPort = true;
                    break;
                }
            }
            return hasNGPort;
        }
        #endregion checkLine Status For Ng Mode

        public List<Zone> loadZoneListByLine(string line_id)
        {
            List<Zone> rtnList = new List<Zone>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnList = zoneDao.loadZoneListByLineID(conn, line_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Query Failed from AZONE [line_id:{0}][Message:{1}]", line_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnList;
        }

        public Boolean createNode(Node node)
        {
            return createNode(node.Node_ID, node.Zone_ID);
        }

        public Boolean createNode(string node_id, string zone_id)
        {
            Boolean isSuccess = false;

            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                Node node = new Node()
                {
                    Node_ID = node_id,
                    Zone_ID = zone_id
                };

                nodeDao.insertNode(conn, node);

                conn.Commit();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to ANODE [node_id:{0}][Message:{1}]", node_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return isSuccess;
        }

        public Node getNodeByNodeID(string node_id)
        {
            Node rtnNode = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnNode = nodeDao.getNodeByNodeID(conn, false, node_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from ANode [node_id:{0}][Message:{1}]", node_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnNode;
        }

        public List<Node> loadNodeListByZone(string zone_id)
        {
            List<Node> rtnList = new List<Node>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnList = nodeDao.loadNodeListByZone(conn, zone_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Query Failed from ANode [zone_id:{0}][Message:{1}]", zone_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnList;
        }

        public Equipment getEqptByEqptID(string eqpt_id)
        {
            Equipment rtnEqpt = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnEqpt = eqptDao.getEqptByEqptID(conn, false, eqpt_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from AEQPT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnEqpt;
        }

        public List<Equipment> loadEqptListByNode(string node_id)
        {
            List<Equipment> rtnList = new List<Equipment>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnList = eqptDao.loadEqptListByNode(conn, node_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from AEQPT [node_id:{0}][Message:{1}]", node_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnList;
        }

        public Boolean createUnit(Unit unit)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                unitDao.insertUnit(conn, unit);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to AUNIT [unit_id:{0}][Message:{1}]", unit.Unit_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Unit getUnitByUnitID(string unit_id)
        {
            Unit rtnUnit = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnUnit = unitDao.getUnitByUnitID(conn, false, unit_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from AUNIT [unit_id:{0}][Message:{1}]", unit_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnUnit;
        }

        public List<Unit> loadAllUnit()
        {
            List<Unit> unitList = new List<Unit>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                unitList = unitDao.loadAllUnit(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from AUNIT", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return unitList;
        }

        public List<Unit> loadUnitListByEqpt(string eqpt_id)
        {
            List<Unit> unitList = new List<Unit>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                unitList = unitDao.loadUnitListByEqpt(conn, eqpt_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from AUNIT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return unitList;
        }

        public Boolean updateUnitStatus(string unit_id, string unit_stat)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Unit unit = unitDao.getUnitByUnitID(conn, true, unit_id);
                unit.Unit_Stat = unit_stat;
                unitDao.updateUnit(conn, unit);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update status Failed from AUNIT [unit_id:{0}][Message:{1}]", unit_id, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updateUnit(Unit unit)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                unitDao.updateUnit(conn, unit);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update status Failed from AUNIT [unit_id:{0}][Message:{1}]", unit.Unit_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean createPort(Port port)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                portDao.insertPort(conn, port);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to APORT [port_id:{0}][Message:{1}]", port.Port_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updatePort(Port port)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Port sv_port = portDao.getPortByPortID(conn, true, port.Port_ID);
                port = conn.Session.Merge(port);
                portDao.updatePort(conn, port);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to APORT [port_id:{0}][Message:{1}]", port.Port_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean updatePORT(Port port)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                Port sv_port = portDao.getPortByPortID(conn, true, port.Port_ID);
                sv_port.Port_Stat = port.Port_Stat;
                sv_port.Port_Enable = port.Port_Enable;
                sv_port.Port_Type = port.Port_Type;
                sv_port.Port_Real_Typ = port.Port_Real_Typ;
                sv_port.Port_Num = port.Port_Num;
                sv_port.Trs_Mode = port.Trs_Mode;
                sv_port.Port_Use_Typ = port.Port_Use_Typ;
                portDao.updatePort(conn, sv_port);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to AEQPT [port_id:{0}][Message:{1}]", port.Port_ID, ex.ToString());
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Port getPortByPortID(string port_id)
        {
            Port rtnPort = null;
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnPort = portDao.getPortByPortID(conn, false, port_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from APORT [port_id:{0}][Message:{1}]", port_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnPort;
        }

        public List<Port> loadPortListByEqpt(string eqpt_id)
        {
            List<Port> portList = new List<Port>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                portList = portDao.loadPortListByEqpt(conn, eqpt_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from APORT [eqpt_id:{0}][Message:{1}]", eqpt_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return portList;
        }

        public List<Port> loadAllPort()
        {
            List<Port> portList = new List<Port>();
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                portList = portDao.loadAllPort(conn);
                conn.Commit();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed from APORT", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return portList;
        }

        public string getEQPTReadID(string eqpt_name)
        {
            String real_id = eqpt_name;
            try
            {
                string indexer_id = scApp.getBCFApplication().BC_ID.Trim();
                EqptMap eqptMap = eqptMapDao.getByIND_ID(indexer_id, eqpt_name);
                if (eqptMap != null)
                {
                    real_id = eqptMap.EQPT_REAL_ID;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("getEQPTReadID Exception!", ex);
            }
            return real_id;
        }

        public string getUnitRealID(string eqpt_real_id, int unit_no)
        {
            String real_id = Convert.ToString(unit_no);
            try
            {
                real_id = unitMapDao.getByEqptPosition(eqpt_real_id, Convert.ToString(unit_no)).FULL_UNIT_ID;
            }
            catch (Exception ex)
            {
                logger.ErrorException("getUnitRealID Exception!", ex);
            }
            return real_id;
        }

        public List<UnitMap> getAllUnitByEqptID(string eqpt_real_id)
        {
            List<UnitMap> rtnList = new List<UnitMap>();
            try
            {
                rtnList = unitMapDao.getAllUnitByEqptID(eqpt_real_id);
            }
            catch (Exception ex)
            {
                logger.ErrorException("getAllUnitByEqptID Exception!", ex);
            }
            return rtnList;
        }
        public string Robot_CrtPositiopn = "";

        #region SorterJob
        public Boolean isAllPortReady_UDCM()
        {
            List<Port> lstPort = scApp.getEQObjCacheManager().getAllPort();

            bool isReady = true;
            foreach (Port port in lstPort)
            {
                if (BCFUtility.isMatche(port.Port_Stat, SCAppConstants.PortStatus.LDCM)
                    || BCFUtility.isMatche(port.Port_Stat, SCAppConstants.PortStatus.UDRQ))
                    isReady = false;
            }

            return isReady;
        }
        #endregion

        #region SVID

        /// <summary>
        /// 取出SVDataMap結構List。其SV值僅是預設值，非實際值。
        /// </summary>
        /// <param name="svidList"></param>
        /// <returns></returns>
        public List<SVDataMap> loadSVDataList(List<string> svidList)
        {
            List<SVDataMap> rtnList = new List<SVDataMap>();
            try
            {
                List<SVDataMap> svDatas = new List<SVDataMap>();
                if (svidList == null || svidList.Count == 0)
                {
                    //Load ALL SVID Data
                    svDatas = svDataMapDao.loadAllSVData();
                }
                else
                {
                    foreach (string svid in svidList)
                    {
                        SVDataMap item = svDataMapDao.getBySVID(svid);
                        if (item == null)
                        {
                            continue;
                        }
                        svDatas.Add(item);
                    }
                }
                foreach (SVDataMap item in svDatas)
                {
                    //Default Value is Empty
                    item.SV = " ";
                    rtnList.Add(item);
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("loadSVDataList Exception!", ex);
            }
            return rtnList;
        }
        #endregion SVID

        #region ECID
        public List<ECDataMap> loadDefaultECDataList(List<string> ecidList)
        {
            List<ECDataMap> rtnList = new List<ECDataMap>();
            try
            {
                if (ecidList == null || ecidList.Count == 0)
                {
                    rtnList = ecDataMapDao.loadAllDefaultECData();
                }
                else
                {
                    foreach (string ecid in ecidList)
                    {
                        ECDataMap item = ecDataMapDao.getDefaultByECID(ecid.Trim());
                        if (item == null) { continue; }
                        rtnList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("loadDefaultECDataList Exception!", ex);
            }
            return rtnList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ecDataMapList"></param>
        /// <param name="rtnMsg"></param>
        /// <param name="IsInitial"></param>
        /// <returns></returns>
        public Boolean updateECData(List<ECDataMap> ecDataMapList, out string rtnMsg, Boolean IsInitial)
        {
            return updateECData(ecDataMapList, out rtnMsg);
        }

        public Boolean updateECData(List<ECDataMap> ecDataMapList, out string rtnMsg)
        {
            DBConnection conn = null;
            rtnMsg = string.Empty;
            try
            {
                if (ecDataMapList != null && ecDataMapList.Count > 0
                    && scApp.getEQObjCacheManager().getLine().Host_Mode != SCAppConstants.LineHostMode.OffLine)
                {
                    foreach (ECDataMap item in ecDataMapList)
                    {
                        //if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DEVICE_ID))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_DEVICE_ID);
                        //    return false;
                        //}
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T3))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_T3); 
                        //    return false;
                        //}
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T5))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_T5);
                        //    return false;
                        //}
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T6))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_T6);
                        //    return false;
                        //}
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T7))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_T7);
                        //    return false;
                        //}
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_T8))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_T8);
                        //    return false;
                        //}
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_SINGLEARM))  
                        //{  
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_DCS_SINGLEARM); 
                        //    return false;   
                        //} 
                        //else if (BCFUtility.isMatche(item.ECID, SCAppConstants.ECID_DCS_MODE))
                        //{
                        //    rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_IS_ONLINE_MODE_0_1,
                        //                                        CmdConst.EAC_Denied_Busy,
                        //                                        SCAppConstants.ECID_DCS_MODE);
                        //    return false; 
                        //}  
                    }
                }

                if (ecDataMapList != null && ecDataMapList.Count > 0)
                {
                    int evc = 0;
                    int ecmin = 0;
                    int ecmax = 0;
                    foreach (ECDataMap item in ecDataMapList)
                    {
                        if (int.TryParse(item.ECV, out evc))
                        {
                            ecmin = Convert.ToInt16(item.ECMIN);
                            ecmax = Convert.ToInt16(item.ECMAX);
                            if (evc < ecmin || evc > ecmax)
                            {
                                //rtnMsg = scApp.AlarmBLL.getMainAlarm(SCAppConstants.MainAlarmCode.UPDATE_ECID_FAIL_OVER_RANGE_0_1,
                                //                                    CmdConst.EAC_Denied_At_least_one_constant_out_of_range,
                                //                                    item.ECNAME);
                                return false;
                            }
                        }
                    }
                }

                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                if (ecDataMapList != null && ecDataMapList.Count > 0)
                {
                    foreach (ECDataMap item in ecDataMapList)
                    {
                        ecDataMapDao.updateECData(conn, item);
                        scApp.BCSystemBLL.updateSystemParameter(item.ECID, item.ECV, true);
                    }
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("updateECData Exception !", ex);
                rtnMsg = string.Format("updateECData Exception ![{0}]", ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean insertNewECData(List<ECDataMap> ecDataMapList)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                if (ecDataMapList != null && ecDataMapList.Count > 0)
                {
                    foreach (ECDataMap item in ecDataMapList)
                    {
                        ECDataMap sv_item = ecDataMapDao.getByECID(conn, false, item.ECID);
                        if (sv_item == null)
                        {
                            ecDataMapDao.insertECData(conn, item);
                            scApp.BCSystemBLL.updateSystemParameter(item.ECID, item.ECV, false);
                        }
                    }
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("insertNewECData Exception !", ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public Boolean deleteECDataList(List<string> ecidList)
        {
            DBConnection conn = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                ecDataMapDao.deleteECData(conn, ecidList);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("insertNewECData Exception !", ex);
                return false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return true;
        }

        public List<ECDataMap> loadECDataList(List<string> ecidList)
        {
            DBConnection conn = null;
            List<ECDataMap> rtnList = new List<ECDataMap>();
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                if (ecidList == null || ecidList.Count == 0)
                {
                    rtnList = ecDataMapDao.loadAllECData(conn);
                }
                else
                {
                    foreach (string ecid in ecidList)
                    {
                        ECDataMap item = ecDataMapDao.getByECID(conn, false, ecid.Trim());
                        if (item == null) { continue; }
                        rtnList.Add(item);
                    }
                }
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("loadECDataList Exception !", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnList;
        }

        public List<ECDataMap> loadECDataList(string eqpt_real_id)
        {
            DBConnection conn = null;
            List<ECDataMap> rtnList = new List<ECDataMap>();
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                rtnList = ecDataMapDao.loadECDataMapsByEQRealID(conn, eqpt_real_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("loadECDataList Exception !", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return rtnList;
        }

        public ECDataMap getECData(string ecid)
        {
            DBConnection conn = null;
            ECDataMap ecData = null;
            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();
                ecData = ecDataMapDao.getByECID(conn, false, ecid);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("getECData Exception !", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }
            return ecData;
        }

        #endregion ECID

        #region Port Position Map
        /// <summary>
        /// 查詢Port對應Reader、Unload Port列表
        /// </summary>
        /// <param name="port_id">Port ID</param>
        /// <returns>Port Position Map List</returns>
        public PortPosMap getPortPosMapByPortID(string port_id)
        {
            PortPosMap rtnPortPosMap = null;
            try
            {
                rtnPortPosMap = portPosMapDao.getPortPosMapByPortID(port_id);
            }
            catch (Exception ex)
            {
                logger.ErrorException("getPortPosMapByPortID Exception!", ex);
            }
            return rtnPortPosMap;
        }

        /// <summary>
        /// 查詢CIM Equipment對應Reader、Unload Port列表
        /// </summary>
        /// <param name="eq_id">CIM Equipment ID</param>
        /// <returns>Port Position Map List</returns>
        public PortPosMap getPortPosMapByCIMEQID(string eq_id)
        {
            PortPosMap rtnPortPosMap = null;
            try
            {
                rtnPortPosMap = portPosMapDao.getPortPosMapByCIMEQID(eq_id);
            }
            catch (Exception ex)
            {
                logger.ErrorException("getPortPosMapByEQID Exception!", ex);
            }
            return rtnPortPosMap;
        }
        #endregion Port Position Map

        #region Location
        /// <summary>
        /// 更新Loc_Mst
        /// </summary>
        /// <param name="loc">LocMst</param>
        /// <returns></returns>
        public void updateLocMst(Loc_Mst loc)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locMstDao.updateLocMst(conn, loc);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed To Loc_Mst [Location ID:{0}][Message:{1}]", loc.Loc, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return;
        }

        /// <summary>
        /// 根據Location ID取得Loc_Mst
        /// </summary>
        /// <param name="loc">Location ID</param>
        /// <returns>回覆取得的Loc_Mst</returns>
        public Loc_Mst getLocMst(string locID)
        {
            Loc_Mst loc = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                loc = locMstDao.getLocMst(conn, locID);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From Loc_Mst [Location ID:{0}][Message:{1}]", locID, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return loc;
        }

        /// <summary>
        /// 取得所有Loc_Mst
        /// </summary>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadAllLocMst()
        {
            List<Loc_Mst> rtnLocLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnLocLst = locMstDao.loadAllLocMst(conn);
            }
            catch (Exception ex)
            {
                logger.Warn("Query All Failed From Loc_Mst", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnLocLst;
        }

        /// <summary>
        /// 根據WH ID取得Loc_Mst
        /// </summary>
        /// <param name="wh_id">WH ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWhID(string wh_id)
        {
            List<Loc_Mst> rtnLocLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnLocLst = locMstDao.loadLocMstByWhID(conn, wh_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From Loc_Mst [WH ID:{0}][Message:{1}]", wh_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnLocLst;
        }

        /// <summary>
        /// 根據WH ID取得Loc_Mst
        /// </summary>
        /// <param name="wh_id">WH ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWIP(string wip_id)
        {
            List<Loc_Mst> rtnLocLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnLocLst = locMstDao.loadLocMstByWIPAll(conn, wip_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From Loc_Mst [WIP:{0}][Message:{1}]", wip_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnLocLst;
        }

        /// <summary>
        /// 根據WIP ID取得Loc_Mst數量
        /// </summary>
        /// <param name="wip_id">WIP ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public string loadLocMstCntStrByWIP(string wip_id)
        {
            List<Loc_Mst> locMstLst = null;
            List<Loc_Mst> emptyLocMstLst = null;
            int locCnt = 0;
            int emptyLocCnt = 0;
            string rtnStr = string.Empty;

            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();

                locMstLst = locMstDao.loadLocMstByWIP(conn, wip_id);
                emptyLocMstLst = locMstDao.loadEmptyLocMstByWIP(conn, wip_id);

                if(locMstLst != null)
                {
                    locCnt = locMstLst.Count;
                }

                if (emptyLocMstLst != null)
                {
                    emptyLocCnt = emptyLocMstLst.Count;
                }

                rtnStr = emptyLocCnt.ToString() + "-" + locCnt.ToString();
            }
            catch (Exception ex)
            {
                logger.Warn("Query Location Failed From Loc_Mst [WIP:{0}][Message:{1}]", wip_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnStr;
        }

        /// <summary>
        /// 根據WH ID、Zone ID取得Loc_Mst
        /// </summary>
        /// <param name="wh_id">WH ID</param>
        /// <param name="zone_id">Zone ID</param>
        /// <returns>回覆取得的Loc_Mst List</returns>
        public List<Loc_Mst> loadLocMstByWhIDAndZone(string wh_id, string zone_id)
        {
            List<Loc_Mst> rtnLocLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnLocLst = locMstDao.loadLocMstByWhIDAndZone(conn, wh_id, zone_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From Loc_Mst [WH ID:{0}][Zone ID:{1}][Message:{2}]", wh_id, zone_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnLocLst;
        }

        /// <summary>
        /// 更新Loc_Dtl
        /// </summary>
        /// <param name="loc">LocDtl</param>
        /// <returns></returns>
        public void updateLocDtl(Loc_Dtl loc)
        {
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDtlDao.updateLocDtl(conn, loc);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed To LOC_DTL [Location ID:{0}][Message:{1}]", loc.Loc, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return;
        }

        /// <summary>
        /// 根據Location ID、Tx No取得Loc_Dtl
        /// </summary>
        /// <param name="loc">Location ID</param>
        /// <param name="tx_no">Tx No</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public Loc_Dtl getLocDtl(string loc, string tx_no)
        {
            Loc_Dtl locDtl = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDtl = locDtlDao.getLocDtl(conn, loc, tx_no);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From LOC_DTL [Location ID:{0}][Tx No:{1}][Message:{2}]", loc, tx_no, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return locDtl;
        }

        /// <summary>
        /// 取得所有Loc_Dtl
        /// </summary>
        /// <returns>回覆取得的Loc_Dtl List</returns>
        public List<Loc_Dtl> loadAllLocDtl()
        {
            List<Loc_Dtl> locDtlLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDtlLst = locDtlDao.loadAllLocDtl(conn);
            }
            catch (Exception ex)
            {
                logger.Warn("Query All Failed From LOC_DTL", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return locDtlLst;
        }

        /// <summary>
        /// 根據Location ID取得Loc_Dtl
        /// </summary>
        /// <param name="loc">Location ID</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public List<Loc_Dtl> loadLocDtlByLoc(string loc)
        {
            List<Loc_Dtl> locDtlLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDtlLst = locDtlDao.loadLocDtlByLoc(conn, loc);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From LOC_DTL [Location ID:{0}][Message:{1}]", loc, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return locDtlLst;
        }

        /// <summary>
        /// 根據Caassette ID取得Loc_Dtl
        /// </summary>
        /// <param name="cstID">Cassette ID</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public Loc_Dtl getLocDtlByCst(string cstID)
        {
            Loc_Dtl locDt = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDt = locDtlDao.getLocDtlByCst(conn, cstID);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From LOC_DTL [Cassette ID:{0}][Message:{1}]", cstID, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return locDt;
        }

        /// <summary>
        /// WH ID取得Loc_Dtl
        /// </summary>
        /// <param name="wh_id">Wh ID</param>
        /// <returns>回覆取得的Loc_Dtl</returns>
        public List<Loc_Dtl> loadLocDtlByWhID(string wh_id)
        {
            List<Loc_Dtl> locDtlLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDtlLst = locDtlDao.loadLocDtlByWhID(conn, wh_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From LOC_DTL [Wh ID:{0}][Message:{1}]", wh_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return locDtlLst;
        }

        /// <summary>
        /// 取得實Loc_Dtl
        /// </summary>
        /// <returns>回覆取得的實Loc_Dtl</returns>
        public List<Loc_Dtl> loadFullLocDtl()
        {
            List<Loc_Dtl> locDtlLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                locDtlLst = locDtlDao.loadFullLocDtl(conn);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Full Cassette Failed From LOC_DTL", ex);
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return locDtlLst;
        }

        public bool updateLoc(Loc_Mst locMst, List<Loc_Dtl> locDtlLst)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                locMstDao.updateLocMst(conn, locMst);

                foreach (Loc_Dtl locDtl in locDtlLst)
                {
                    locDtlDao.updateLocDtl(conn, locDtl);
                }

                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to Loc_Mst, Loc_Dtl", ex);

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }
        #endregion

        #region Serial Number
        /// <summary>
        /// 新增Serial Number
        /// </summary>
        /// <param name="sno">Sno Ctl</param>
        /// <returns></returns>
        public bool insertSnoCtl(Sno_Ctl sno)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                snoCtlDao.insertSnoCtl(conn, sno);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to Sno_Ctl [Sno Type:{0}][Message:{1}]", sno.Sno_Type, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 更新Serial Number
        /// </summary>
        /// <param name="sno">Sno Ctl</param>
        /// <returns></returns>
        public bool updateSnoCtl(Sno_Ctl sno)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                snoCtlDao.updateSnoCtl(conn, sno);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to Sno_Ctl [Sno Type:{0}][Message:{1}]", sno.Sno_Type, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 根據Sno Type取得Sno Ctl
        /// </summary>
        /// <param name="sno_type">Sno Ctl</param>
        /// <returns>回覆取得的Sno_Ctl</returns>
        public Sno_Ctl getSnoCtl(string sno_type)
        {
            Sno_Ctl sno = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                sno = snoCtlDao.getSnoCtl(conn, sno_type);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From Sno_Ctl [Sno Type:{0}][Message:{1}]", sno_type, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return sno;
        }

        /// <summary>
        /// 刪除Sno Ctl
        /// </summary>
        /// <param name="sno_type">Sno Ctl</param>
        /// <returns></returns>
        public bool deleteSnoCtl(string sno_type)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                snoCtlDao.deleteSnoCtl(conn, sno_type);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete Failed to Sno_Ctl [Sno Type:{0}][Message:{1}]", sno_type, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }
        #endregion

        #region Parameter
        /// <summary>
        /// 新增Parameter
        /// </summary>
        /// <param name="para">Parameter</param>
        /// <returns></returns>
        public bool creatParameter(Parameter para)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                parameterDao.inserParameter(conn, para);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Insert Failed to APARAMETER [Category:{0}][ID:{1}][Message:{2}]", para.Para_Cate, para.Para_ID, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 更新Parameter
        /// </summary>
        /// <param name="para">Parameter</param>
        /// <returns></returns>
        public bool updateParameter(Parameter para)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                parameterDao.updateParameter(conn, para);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Update Failed to APARAMETER [Category:{0}][ID:{1}][Message:{2}]", para.Para_Cate, para.Para_ID, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 根據Category、ID取得Parameter
        /// </summary>
        /// <param name="para_cate">Parameter Category</param>
        /// <param name="para_id">Parameter ID</param>
        /// <returns>回覆找到的Parameter</returns>
        public Parameter getParameter(string para_cate, string para_id)
        {
            Parameter rtnPara = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnPara = parameterDao.getParameter(conn, para_cate, para_id);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From APARAMETER [Category:{0}][ID:{1}][Message:{1}]", para_cate, para_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnPara;
        }

        /// <summary>
        /// 根據Category取得Parameter
        /// </summary>
        /// <param name="para_cate">Parameter Category</param>
        /// <returns>回覆找到的Parameter List</returns>
        public List<Parameter> loadParameterByCate(string para_cate)
        {
            List<Parameter> rtnParaLst = null;
            DBConnection conn = null;

            try
            {
                conn = scApp.getDBConnection();
                rtnParaLst = parameterDao.loadParameterByCate(conn, para_cate);
            }
            catch (Exception ex)
            {
                logger.Warn("Query Failed From APARAMETER [Category:{0}][Message:{1}]", para_cate, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnParaLst;
        }

        /// <summary>
        /// 根據Category、ID刪除Parameter
        /// </summary>
        /// <param name="para_cate">Parameter Category</param>
        /// <param name="para_id">Parameter ID</param>
        /// <returns></returns>
        public bool deleteParameter(string para_cate, string para_id)
        {
            DBConnection conn = null;
            bool rtnCode = true;

            try
            {
                conn = scApp.getDBConnection();
                conn.BeginTransaction();

                parameterDao.deleteParameter(conn, para_cate, para_id);
                conn.Commit();
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Delete Failed to APARAMETER [Category:{0}][ID:{1}][Message:{2}]", para_cate, para_id, ex.ToString());

                rtnCode = false;
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return rtnCode;
        }

        /// <summary>
        /// 取得及更新Serial No
        /// </summary>
        /// <param name="para_id">Parameter ID</param>
        /// <returns>回覆Serial No</returns>
        protected object _lockSerial = new object();
        public int getSerialNoByID(string para_id)
        {
            Parameter para = null;
            int serial_No = 0;
            int max_SerialNo;
            int new_SerialNo;
            DBConnection conn = null;

            try
            {
                lock (_lockSerial)
                {
                    conn = scApp.getDBConnection();
                    para = parameterDao.getParameter(conn, SCAppConstants.ParameterCate.Serial_No, para_id);

                    if (para != null)
                    {
                        serial_No = int.Parse(para.Val_1);
                        max_SerialNo = int.Parse(para.Val_2);
                        new_SerialNo = serial_No + 1;

                        if (new_SerialNo > max_SerialNo)
                        {
                            new_SerialNo = 1;
                        }

                        para.Val_1 = new_SerialNo.ToString();
                        parameterDao.updateParameter(conn, para);
                    }

                    conn.Commit();
                }  
            }
            catch (Exception ex)
            {
                if (conn != null) { try { conn.Rollback(); } catch { } }
                logger.Warn("Query Failed From APARAMETER [Category:SERIALNO][ID:{0}][Message:{1}]", para_id, ex.ToString());
            }
            finally
            {
                if (conn != null) { try { conn.Close(); } catch { } }
            }

            return serial_No;
        }
        #endregion
    }
}