//*********************************************************************************
//      EQObjCacheManager.cs
//*********************************************************************************
// File Name: EQObjCacheManager.cs
// Description: Equipment Cache Manager
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.ConfigHandler;
using com.mirle.ibg3k0.bcf.Data.FlowRule;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using NLog;
using com.mirle.ibg3k0.sc.ConfigHandler;

namespace com.mirle.ibg3k0.sc.Common
{
    public class EQObjCacheManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static EQObjCacheManager instance = null;
        private static Object _lock = new Object();
        private SCApplication scApp = null;

        //Cache Object
        private Line line = null;
        private Object _lockLine = new Object();
        private List<Zone> zoneList = new List<Zone>();
        private Dictionary<string, Object> _lockZoneDic = new Dictionary<string, object>();
        private List<Node> nodeList = new List<Node>();
        private Dictionary<string, Object> _lockNodeDic = new Dictionary<string, object>();
        private List<Equipment> eqptList = new List<Equipment>();
        private Dictionary<string, Object> _lockEqptDic = new Dictionary<string, object>();
        private List<Unit> unitList = new List<Unit>();
        private Dictionary<string, Object> _lockUnitDic = new Dictionary<string, object>();
        private List<Port> portList = new List<Port>();
        private Dictionary<string, Object> _lockPortDic = new Dictionary<string, object>();
        //private List<BufferPort> buffList = new List<BufferPort>();
        private Dictionary<string, Object> _lockBuffDic = new Dictionary<string, object>();
        private EQPTConfigSections eqptCss = null;
        //private Dictionary<string, FlowRelation> flowRelationDic = new Dictionary<string, FlowRelation>();
        private NodeFlowRelConfigSections nodeFlowRelCss = null;

        private CommonInfo commonInfo = new CommonInfo(); 
        public CommonInfo CommonInfo { get { return commonInfo; } }

        private EQObjCacheManager() { }
        public static EQObjCacheManager getInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new EQObjCacheManager();
                }
                return instance;
            }
        }


        public void setContext(EQPTConfigSections eqptCss, NodeFlowRelConfigSections nodeFlowRelCss)
        {
            this.eqptCss = eqptCss;
            this.nodeFlowRelCss = nodeFlowRelCss;
        }

        public void start(Boolean recoverFromDB)
        {
            scApp = SCApplication.getInstance();

            buildEQObjFromConfig();

            //insertToDB(recoverFromDB);
            buildFlowRelationFromConfig();
            registerFileWatchDog();
            //alarmHandler();
        }

        public void stop()
        {
            clearCache();
            clearFlowRelCache();
        }

        private void clearFlowRelCache()
        {
            //flowRelationDic.Clear();
        }

        private void clearCache()
        {
            line = null;
            zoneList.Clear();
            _lockZoneDic.Clear();
            nodeList.Clear();
            _lockNodeDic.Clear();
            eqptList.Clear();
            _lockEqptDic.Clear();
            unitList.Clear();
            _lockUnitDic.Clear();
            portList.Clear();
            _lockPortDic.Clear();
            //buffList.Clear();
            _lockBuffDic.Clear();
        }

        private void buildFlowRelationFromConfig()
        {
            clearFlowRelCache();
            if (nodeFlowRelCss != null)
            {
                List<NodeFlowRelConfigSection> configs = nodeFlowRelCss.ConfigSections;
                foreach (NodeFlowRelConfigSection config in configs)
                {
                    string upstream_id = config.Upstream_ID.Trim();
                    string flow_rule_name = config.Flow_Rule.Trim();
                    Boolean isDonotCareFlowRule = config.isDonotCareFlowRule();

                    IFlowRule flowRule = null;
                    if (!isDonotCareFlowRule)
                    {
                        Type flowRuleType = Type.GetType(flow_rule_name);
                        flowRule =
                            (IFlowRule)Activator.CreateInstance(flowRuleType);
                    }

                    //List<FlowRelationItem> items = new List<FlowRelationItem>();
                    //foreach (Downstream ds in config.DownstreamList)
                    //{
                    //    string downstream_id = ds.ID.Trim();
                    //    FlowRelationItem item = new FlowRelationItem()
                    //    {
                    //        FlowRelationPK = new FlowRelationPKInfo() { Upstream_ID = upstream_id, Downstream_ID = downstream_id },
                    //        Fr_ID = upstream_id,
                    //        Rel_Type = SCAppConstants.REL_TYPE_NODE
                    //    };
                    //    items.Add(item);
                    //}
                    //FlowRelation flowRel = new FlowRelation(upstream_id, flowRule, items, isDonotCareFlowRule);
                    //flowRelationDic.Add(upstream_id, flowRel);
                }
            }
        }

        private void buildEQObjFromConfig()
        {
            clearCache();
            //Line
            string line_id = eqptCss.ConfigSections[0].Line_ID.Trim();
            line = new Line()
            {
                Line_ID = line_id,
                Real_ID = line_id,
                SECSAgentName = eqptCss.ConfigSections[0].SECSAgentName 
            };
            string shareMemoryInitClass = eqptCss.ShareMemoryInitClass.Trim();
            //Zone
            List<ZoneConfigSection> zoneConfigs = eqptCss.ConfigSections[0].ZoneConfigList;
            foreach (ZoneConfigSection zoneConfig in zoneConfigs)
            {
                string zone_id = zoneConfig.Zone_ID.Trim();
                _lockZoneDic.Add(zone_id, new Object());
                zoneList.Add(new Zone()
                {
                    Zone_ID = zone_id,
                    Real_ID = zone_id,
                    Line_ID = line_id,
                    SECSAgentName = zoneConfig.SECSAgentName 
                });
                //Node
                foreach (NodeConfigSection nodeConfig in zoneConfig.NodeConfigList)
                {
                    string node_id = nodeConfig.Node_ID.Trim();
                    int recipe_index = nodeConfig.Recipe_Index;
                    int node_num = nodeConfig.Node_Num;
                    _lockNodeDic.Add(node_id, new Object());
                    nodeList.Add(new Node()
                    {
                        Node_ID = node_id,
                        Real_ID = node_id,
                        Zone_ID = zone_id,
                        Recipe_Index = recipe_index,
                        Node_Num = node_num,
                        SECSAgentName = nodeConfig.SECSAgentName
                    });
                    //Eqpt
                    foreach (EQPTConfigSection eqptConfig in nodeConfig.EQPTConfigList)
                    {
                        string eqpt_id = eqptConfig.EQPT_ID.Trim();
                        //string eqpt_real_id = scApp.LineBLL.getEQPTReadID(eqpt_id);
                        string eqpt_real_id = "";
                        _lockEqptDic.Add(eqpt_id, new Object());
                        int max_sht_cnt = eqptConfig.Max_Sht_Cnt;
                        int min_sht_cnt = eqptConfig.Min_Sht_Cnt;
                        string alarmListFile = eqptConfig.Alarm_List_File;
                        string procDataFormat = eqptConfig.Process_Data_Format;
                        string svDataFormat = eqptConfig.SV_Data_Format; 
                        string recipeParameterFormat = eqptConfig.Recipe_Parameter_Format; 
                        string ecidFormat = eqptConfig.ECID_Format;  
                        //List<UnitMap> unitMapList = scApp.LineBLL.getAllUnitByEqptID(eqpt_real_id);
                        List<Unit> unitListOfEQPT = new List<Unit>();
                        //Unit
                        foreach (UnitConfigSection unitConfig in eqptConfig.UnitConfigList)
                        {
                            string unit_id = unitConfig.Unit_ID.Trim();
                            _lockUnitDic.Add(unit_id, new Object());
                            string unit_cate = unitConfig.Unit_Cate.Trim();
                            string eqpt_type = unitConfig.EQPT_Type.Trim();
                            int capacity = unitConfig.Capacity;
                            unitList.Add(new Unit()
                            {
                                Unit_ID = unit_id,
                                //Real_ID = scApp.LineBLL.getUnitRealID(eqpt_real_id, unitConfig.Unit_Num),//unit_id,
                                Real_ID = unit_id,
                                Unit_Num = unitConfig.Unit_Num,
                                Eqpt_ID = eqpt_id,
                                Unit_Cate = unit_cate,
                                Eqpt_Type = eqpt_type,
                                Capacity = capacity,
                                SECSAgentName = unitConfig.SECSAgentName 
                            });
                        }

                        eqptList.Add(new Equipment()
                        {
                            Eqpt_ID = eqpt_id,
                            //Real_ID = eqpt_real_id,//eqpt_id,
                            Real_ID = eqpt_id,
                            Node_ID = node_id,
                            //Max_Sht_Cnt = max_sht_cnt,
                            //Min_Sht_Cnt = min_sht_cnt,
                            Alarm_List_File = alarmListFile,
                            Process_Data_Format = procDataFormat,
                            SV_Data_Format = svDataFormat,
                            Recipe_Parameter_Format = recipeParameterFormat,
                            ECID_Format = ecidFormat,  
                            SECSAgentName = eqptConfig.SECSAgentName, 
                            CommunicationType = eqptConfig.CommunicationType,
                            UnitList = unitList.Where(unit => unit.Eqpt_ID == eqpt_id).ToList()
                        });
                        com.mirle.ibg3k0.sc.ConfigHandler.ProcessDataConfigHandler handler =
                            eqptList.Last().getProcessDataConfigHandler();
                        SVDataConfigHandler svDataConfigHandler = eqptList.Last().getSVDataConfigHandler();
                        RecipeParameterConfigHandler recipeParameterHandler = eqptList.Last().getRecipeParameterConfigHandler();

                        foreach (PortConfigSection portConfig in eqptConfig.PortConfigList)
                        {
                            string port_id = portConfig.Port_ID.Trim();
                            _lockPortDic.Add(port_id, new Object());
                            string port_type = portConfig.Port_Type.Trim();
                            int capacity = portConfig.Capacity;
                            portList.Add(new Port()
                            {
                                Port_ID = port_id,
                                Real_ID = port_id,
                                Unit_Num = portConfig.Unit_Num,
                                Port_Num = portConfig.Port_Num,
                                Eqpt_ID = eqpt_id,
                                Port_Type = port_type,
                                Capacity = capacity,
                                SECSAgentName = portConfig.SECSAgentName,
                                Port_Type_Alias = string.Empty,
                                Lyt_Dir = string.Empty
                            });
                        }
                        foreach (BufferConfigSection buffConfig in eqptConfig.BuffConfigList)
                        {
                            string buff_id = buffConfig.Buff_ID.Trim();
                            _lockBuffDic.Add(buff_id, new Object());
                            int capacity = buffConfig.Capacity;
                            //buffList.Add(new BufferPort()
                            //{
                            //    Buff_ID = buff_id,
                            //    Real_ID = buff_id,
                            //    Unit_Num = buffConfig.Unit_Num,
                            //    Eqpt_ID = eqpt_id,
                            //    Capacity = capacity,
                            //    SECSAgentName = buffConfig.SECSAgentName 
                            //});
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 如果要以MPLC目前資料為主，則需先清除DB內舊有資料，再重新rebuild，並透過腳本更新
        /// </summary>
        private void removeFromDB()
        {

        }

        /// <summary>
        /// 當「reloadDataFromDB」為true時，會把DB現有資料放回cache中
        /// ...TODO: 還要把附掛上去的資料一起放回才完整
        /// </summary>
        /// <param name="recoverFromDB"></param>
        private void insertToDB(Boolean recoverFromDB)
        {
            try
            {
                recoverFromDB = false;  //A0.06  由於目前在RecoverFromDB此功能尚未完全，因此目前一律不使用 2015/04/13 by Kevin Wei

                Line tmpLine = scApp.LineBLL.getLineByIDAndDeleteOtherLine(line.Line_ID);
                if (tmpLine == null)
                {
                    if (!scApp.LineBLL.createLine(line))
                    {
                        logger.Error("insert Line[{0}] Failed.", line.Line_ID);
                    }
                }
                else
                {
                    if (recoverFromDB)
                    {
                        put(tmpLine);
                    }
                    //else
                    //{
                    //    line.Next_Route = tmpLine.Next_Route;
                    //}
                }
                foreach (Zone zone in zoneList)
                {
                    Zone tmpZone = scApp.LineBLL.getZoneByZoneID(zone.Zone_ID);
                    if (tmpZone == null)
                    {
                        if (!scApp.LineBLL.createZone(zone))
                        {
                            logger.Error("insert Zone[{0}] Failed.", zone.Zone_ID);
                        }
                    }
                    else
                    {
                        if (recoverFromDB)
                        {
                            put(tmpZone);
                        }
                    }
                }

                //scApp.SheetBLL.deleteAllUnitPosition(); //在建立新的Unit Table時，先刪除之前的
                foreach (Equipment eqpt in eqptList)
                {
                    Equipment tmpEQPT = scApp.LineBLL.getEqptByEqptID(eqpt.Eqpt_ID);
                    if (tmpEQPT == null)
                    {
                        if (!scApp.LineBLL.createEquipment(eqpt))
                        {
                            logger.Error("insert EQPT[{0}] Failed.", eqpt.Eqpt_ID);
                        }
                    }
                    else
                    {
                        if (recoverFromDB)
                        {
                            put(tmpEQPT);
                        }
                    }

                    //List<UnitPosition> lstPosition = scApp.UnitPositionDao.getByEQPTID_DataSet(eqpt.Real_ID);
                    //foreach (UnitPosition unitposition in lstPosition)
                    //{
                    //    scApp.SheetBLL.insertUnitPosition(unitposition.EQPT_ID, unitposition.POSITION.PadLeft(2, '0'), unitposition.UNIT_ID, unitposition.SLOT_NO, unitposition.GLASS_ID, unitposition.DESCRIPTION);  
                    //}
                }
                foreach (Unit unit in unitList)
                {
                    Unit tmpUnit = scApp.LineBLL.getUnitByUnitID(unit.Unit_ID);
                    if (tmpUnit == null)
                    {
                        if (!scApp.LineBLL.createUnit(unit))
                        {
                            logger.Error("insert Unit[{0}] Failed.", unit.Unit_ID);
                        }
                    }
                    else
                    {
                        if (recoverFromDB)
                        {
                            put(tmpUnit);
                        }
                    }
                }
                foreach (Port port in portList)
                {
                    Port tmpPort = scApp.LineBLL.getPortByPortID(port.Port_ID);
                    if (tmpPort == null)
                    {
                        if (!scApp.LineBLL.createPort(port))
                        {
                            logger.Error("insert Port[{0}] Failed.", port.Port_ID);
                        }
                    }
                    else
                    {
                        if (recoverFromDB)
                        {
                            put(tmpPort);
                        }
                    }
                }
                //foreach (BufferPort buff in buffList)
                //{
                //    BufferPort tmpBuff = scApp.LineBLL.getBufferPortByPortID(buff.Buff_ID);
                //    if (tmpBuff == null)
                //    {
                //        if (!scApp.LineBLL.createBufferPort(buff))
                //        {
                //            logger.Error("insert Buffer[{0}] Failed.", buff.Buff_ID);
                //        }
                //    }
                //    else
                //    {
                //        if (recoverFromDB)
                //        {
                //            put(tmpBuff);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                logger.ErrorException("insert defined eqpt object to DB Failed.", ex);
            }
        }

        private void buildEQObj()
        {
            clearCache();

            //Line
            line = scApp.LineBLL.getFirstLine();
            if (line == null)
            {
                logger.Warn("Not Found Line Setting.");
                return;
            }

            //Zone
            zoneList.AddRange(scApp.LineBLL.loadZoneListByLine(line.Line_ID).ToList());

            //Node
            foreach (Zone zone in zoneList)
            {
                _lockZoneDic.Add(zone.Zone_ID, new Object());
                nodeList.AddRange(scApp.LineBLL.loadNodeListByZone(zone.Zone_ID).ToList());
            }
            //EQPT
            foreach (Node node in nodeList)
            {
                _lockNodeDic.Add(node.Node_ID, new Object());
                eqptList.AddRange(scApp.LineBLL.loadEqptListByNode(node.Node_ID).ToList());
            }
            //Unit
            foreach (Equipment eqpt in eqptList)
            {
                _lockEqptDic.Add(eqpt.Eqpt_ID, new Object());
                unitList.AddRange(scApp.LineBLL.loadUnitListByEqpt(eqpt.Eqpt_ID).ToList());
            }
            foreach (Unit unit in unitList)
            {
                _lockUnitDic.Add(unit.Unit_ID, new Object());
            }
        }

        private void alarmHandler()
        {
            List<Alarm> alarmList = scApp.AlarmBLL.loadAlarm(true, false);
            commonInfo.resetAlarmHis(alarmList);
        }


        /// <summary>
        /// 取得此Node(Upstream)可以流向的Downstream List
        /// </summary>
        /// <param name="upstream_id"></param>
        /// <returns></returns>
        public List<Node> getDownstreamList(string upstream_id)
        {
            List<Node> downstreams = new List<Node>();
            //if (!flowRelationDic.ContainsKey(upstream_id.Trim())
            //    || flowRelationDic[upstream_id.Trim()] == null)
            //{
            //    return downstreams;
            //}
            //foreach (string downstreamID in flowRelationDic[upstream_id.Trim()].getDownstreamIDList())
            //{
            //    downstreams.Add(getNodeByNodeID(downstreamID));
            //}
            return downstreams;
        }

        /// <summary>
        /// 根據流向設定，以及指定的判斷規則進行選擇下一個流向的Node
        /// </summary>
        /// <param name="upstream_id">當前的Node ID</param>
        /// <returns>下一個流向的Node。如果沒有適合的Node，將會回傳null</returns>
        public Node getDownstream(string upstream_id)
        {
            //if (!flowRelationDic.ContainsKey(upstream_id.Trim()))
            //{
            //    return null;
            //}
            //Node upstream = getNodeByNodeID(upstream_id);
            //List<BaseEQObject> downstreams = new List<BaseEQObject>();
            //foreach (string downstreamID in flowRelationDic[upstream_id.Trim()].getDownstreamIDList())
            //{
            //    downstreams.Add(getNodeByNodeID(downstreamID));
            //}
            //int selIndex = 0;
            //if (!flowRelationDic[upstream_id.Trim()].IsDonotCareFlowRule)
            //{
            //    selIndex = flowRelationDic[upstream_id.Trim()].Flow_Rule.doDecide(upstream, downstreams);
            //}
            //if (selIndex >= 0 && downstreams.Count > selIndex)
            //{
            //    return downstreams[selIndex] as Node;
            //}
            return null;
        }

        #region 取得各種EQ Object的方法
        //
        public Line getLine()
        {
            return line;
        }

        public Zone getZoneByZoneID(string zone_id)
        {
            return zoneList.Where(z => z.Zone_ID.Trim() == zone_id.Trim()).FirstOrDefault();
        }

        public List<Zone> getZoneListByLine()
        {
            return zoneList.Where(z => z.Line_ID.Trim() == line.Line_ID.Trim()).ToList();
        }

        public List<Node> getNodeListByZone(string zone_id)
        {
            return nodeList.Where(n => n.Zone_ID.Trim() == zone_id.Trim()).ToList();
        }

        public Node getNodeByNodeID(string node_id)
        {
            return nodeList.Where(n => n.Node_ID.Trim() == node_id.Trim()).FirstOrDefault();
        }

        public Node getNodeByNodeNum(int node_num)
        {
            return nodeList.Where(n => n.Node_Num == node_num).FirstOrDefault();
        }

        public Node getParentNodeByEQPTID(string eqpt_id)
        {
            Equipment eqpt = getEquipmentByEQPTID(eqpt_id);
            if (eqpt == null)
            {
                return null;
            }
            return nodeList.Where(n => n.Node_ID.Trim() == eqpt.Node_ID.Trim()).FirstOrDefault();
        }

        public Equipment getEquipmentByEQPTID(string eqpt_id)
        {
            //如果設備不存在，這邊會錯誤，所以修正
            Equipment eqpt = null;
            try
            {
                eqpt = eqptList.Where(e => e.Eqpt_ID.Trim() == eqpt_id.Trim()).FirstOrDefault();
            }
            catch { };
            return eqpt;
        }

        public Equipment getEquipmentByEQPTRealID(string eqpt_real_id)
        {
            return eqptList.Where(e => e.Real_ID.Trim() == eqpt_real_id.Trim()).FirstOrDefault();
        }

        public List<Equipment> getEuipmentListByNode(string node_id)
        {
            return eqptList.Where(e => e.Node_ID.Trim() == node_id.Trim()).ToList();
        }

        //public List<Equipment> getAllEquipment()
        //{
        //    return eqptList;
        //}
        public Equipment getIndexerEquipment()
        {
            Equipment IndexerEQPT = scApp.getEQObjCacheManager().getEquipmentByEQPTID("IND");
            return IndexerEQPT;
        }
        /// <summary>
        /// 取得實際使用到的Equipment List
        /// </summary>
        /// <returns></returns>
        public List<Equipment> getAllEquipment()
        {
            return eqptList;
        }

        public List<Equipment> getAllProcessEquipment()
        {
            return eqptList;
        }

        public int getProcessEquipmentCnt()
        {
            return (eqptList.Count - 1);
        }

        public Unit getUnitByUnitID(string unit_id)
        {
            return unitList.Where(u => u.Unit_ID.Trim() == unit_id.Trim()).FirstOrDefault();
        }

        public Unit getUnitByUnitRealID(string unit_real_id)
        {
            return unitList.Where(u => u.Real_ID.Trim() == unit_real_id.Trim()).FirstOrDefault();
        }

        public List<Unit> getAllUnit()
        {
            return unitList.ToList();
        }

        public List<Node> getAllNode()
        {
            return nodeList.ToList();
        }

        public List<Port> getAllPort()
        {
            return portList.ToList();
        }

        //public List<BufferPort> getAllBuffer()
        //{
        //    return buffList.ToList();
        //}

        public Unit getUnitByUnitNumber(string eqpt_id, int Unit_num)
        {
            return unitList.Where(u => u.Eqpt_ID.Trim() == eqpt_id.Trim() && u.Unit_Num == Unit_num).FirstOrDefault();
        }

        public BaseUnitObject getBaseUnitObjByUnitNumber(string eqpt_id, int unit_num)
        {
            Unit unit = unitList.Where(u => u.Eqpt_ID.Trim() == eqpt_id.Trim() && u.Unit_Num == unit_num).FirstOrDefault();
            if (unit != null)
            {
                return unit;
            }
            //BufferPort buff = buffList.Where(b => b.Eqpt_ID.Trim() == eqpt_id.Trim() && b.Unit_Num == unit_num).FirstOrDefault();
            //if (buff != null)
            //{
            //    return buff;
            //}
            Port port = portList.Where(p => p.Eqpt_ID.Trim() == eqpt_id.Trim() && p.Unit_Num == unit_num).FirstOrDefault();
            return port;
        }

        public List<Unit> getUnitListByEquipment(string eqpt_id)
        {
            return unitList.Where(u => u.Eqpt_ID.Trim() == eqpt_id.Trim()).ToList();
        }

        public Port getPortByPortID(string port_id)
        {
            return portList.Where(p => p.Port_ID.Trim() == port_id.Trim()).SingleOrDefault();
        }

        public Port getPortByUnitNumber(string eqpt_id, int unit_num)
        {
            return portList.Where(p => p.Eqpt_ID.Trim() == eqpt_id.Trim() && p.Unit_Num == unit_num).SingleOrDefault();
        }

        public Port getPortByPortNumber(string eqpt_id, int port_num)
        {
            return portList.Where(p => p.Eqpt_ID.Trim() == eqpt_id.Trim() && p.Port_Num == port_num).SingleOrDefault();
        }

        public Port getIndexerPortByPortNumber(int port_num)
        {
            return portList.Where(p => p.Eqpt_ID.Trim() == getIndexerEquipment().Eqpt_ID.Trim() && p.Port_Num == port_num).SingleOrDefault();
        }

        //A0.01 Start
        //public Port getPortByCSTID(string eqpt_id, string cst_id)
        //{
        //    return portList.Where(p => p.Eqpt_ID.Trim() == eqpt_id.Trim()
        //        && SCUtility.Trim(p.CassetteLoader.CassetteItem.CST_ID) == cst_id.Trim()).SingleOrDefault();
        //}
        //A0.01 End

        //public Port getPortByLotID(string eqpt_id, string lot_id)
        //{
        //    return portList.Where(p => p.Eqpt_ID.Trim() == eqpt_id.Trim()
        //        && SCUtility.Trim(p.CassetteLoader.LotItem.Lot_ID) == lot_id.Trim()).SingleOrDefault();
        //}

        public List<Port> getPortListByEquipment(string eqpt_id)
        {
            return portList.Where(p => p.Eqpt_ID.Trim() == eqpt_id.Trim()).ToList();
        }

        public List<Port> getPortListByRequest()
        {
            return portList.Where(p => p.Port_Stat == SCAppConstants.PortStatus.LDRQ || p.Port_Stat == SCAppConstants.PortStatus.UDRQ).ToList();
        }

        //public BufferPort getBuffByBuffID(string buff_id)
        //{
        //    return buffList.Where(b => b.Buff_ID.Trim() == buff_id.Trim()).SingleOrDefault();
        //}

        //public BufferPort getBuffByUnitNumber(string eqpt_id, int unit_num)
        //{
        //    return buffList.Where(b => b.Eqpt_ID.Trim() == eqpt_id.Trim() && b.Unit_Num == unit_num).SingleOrDefault();
        //}

        //public List<BufferPort> getBuffListByEquipment(string eqpt_id)
        //{
        //    return buffList.Where(b => b.Eqpt_ID.Trim() == eqpt_id.Trim()).ToList();
        //}

        public Zone getParentZoneByNode(string node_id)
        {
            Node node = nodeList.Where(n => n.Node_ID.Trim() == node_id.Trim()).FirstOrDefault();
            if (node == null) { return null; }
            return getZoneByZoneID(node.Zone_ID);
        }

        public Zone getParentZoneByEQPT(string eqpt_id)
        {
            Equipment eqpt = getEquipmentByEQPTID(eqpt_id);
            Node node = getNodeByNodeID(eqpt.Node_ID);
            Zone zone = getZoneByZoneID(node.Zone_ID);
            return zone;
        }

        public Zone getParentZoneByPort(string port_id)
        {
            Port port = getPortByPortID(port_id);
            Equipment eqpt = getEquipmentByEQPTID(port.Eqpt_ID);
            Node node = getNodeByNodeID(eqpt.Node_ID);
            Zone zone = getZoneByZoneID(node.Zone_ID);
            return zone;
        }
        #endregion

        /// <summary>
        /// 更新物件的範例：
        /// 1. 透過BLL函式進行更新。
        /// 2. 更新完成後，利用「put()」 Method放回Cache。(更新Cache內的物件資料)
        /// </summary>
        /// <param name="host_mode"></param>
        public void updateLineHostMode(int host_mode)
        {
            //1. 透過BLL去更新host mode
            Boolean isSuccess = scApp.LineBLL.updateLineHostMode(null, line.Line_ID, host_mode);
            //2. DB更新成功後，再把此Manager內的Line更改屬性值
            put(scApp.LineBLL.getLineByIDAndDeleteOtherLine(line.Line_ID));
        }

        private void setValueToPropety<T>(ref T sourceObj, ref T destinationObj)
        {
            BCFUtility.setValueToPropety(ref sourceObj, ref destinationObj);
        }

        #region 將最新物件資料，放置入Cache的方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source_line"></param>
        public void put(Line source_line)
        {
            if (source_line == null) { return; }
            if (line == null)
            {
                //line = source_line;
                return;
            }
            if (!BCFUtility.isMatche(line.Line_ID, source_line.Line_ID))
            {
                return;
            }
            lock (_lockLine)
            {
                setValueToPropety<Line>(ref source_line, ref line);
            }
        }

        public void put(Zone source_zone)
        {
            if (source_zone == null) { return; }
            Zone zone = getZoneByZoneID(source_zone.Zone_ID);
            if (zone == null)
            {
                //zoneList.Add(source_zone);
                //_lockZoneDic.Add(source_zone.Zone_ID, new Object());
                return;
            }
            lock (_lockZoneDic[zone.Zone_ID])
            {
                setValueToPropety<Zone>(ref source_zone, ref zone);
            }
        }

        public void put(Node source_node)
        {
            if (source_node == null) { return; }
            Node node = getNodeByNodeID(source_node.Node_ID);
            if (node == null)
            {
                //nodeList.Add(source_node);
                //_lockNodeDic.Add(source_node.Node_ID, new Object());
                return;
            }
            lock (_lockNodeDic[node.Node_ID])
            {
                setValueToPropety<Node>(ref source_node, ref node);
            }
        }

        public void put(Equipment source_eqpt)
        {
            if (source_eqpt == null) { return; }
            Equipment eqpt = getEquipmentByEQPTID(source_eqpt.Eqpt_ID);
            if (eqpt == null)
            {
                //eqptList.Add(source_eqpt);
                //_lockEqptDic.Add(source_eqpt.Eqpt_ID, new Object());
                return;
            }
            lock (_lockEqptDic[eqpt.Eqpt_ID])
            {
                if (eqpt != source_eqpt)
                {
                    setValueToPropety<Equipment>(ref source_eqpt, ref eqpt);
                }
                scApp.LineBLL.updateEQPT(eqpt);////////////Hayes To Do..
            }
        }

        public void put(Unit source_unit)
        {
            if (source_unit == null) { return; }
            Unit unit = getUnitByUnitID(source_unit.Unit_ID);
            if (unit == null)
            {
                //unitList.Add(source_unit);
                //_lockUnitDic.Add(source_unit.Unit_ID, new Object());
                return;
            }
            lock (_lockUnitDic[unit.Unit_ID])
            {
                setValueToPropety<Unit>(ref source_unit, ref unit);
            }
        }

        public void put(Port source_port)
        {
            if (source_port == null) { return; }
            Port port = getPortByPortID(source_port.Port_ID);
            if (port == null)
            {
                //portList.Add(source_port);
                //_lockPortDic.Add(source_port.Port_ID, new Object());
                return;
            }
            lock (_lockPortDic[port.Port_ID])
            {
                setValueToPropety<Port>(ref source_port, ref port);
            }
        }

        //public void put(BufferPort source_buff)
        //{
        //    if (source_buff == null) { return; }
        //    BufferPort buff = getBuffByBuffID(source_buff.Buff_ID);
        //    if (buff == null) { return; }
        //    lock (_lockBuffDic[buff.Buff_ID])
        //    {
        //        setValueToPropety<BufferPort>(ref source_buff, ref buff);
        //    }
        //}
        #endregion

        private void removeLine()
        {
            line = null;
        }

        #region 從DB取得最新EQ Object，並更新Cache
        public void refreshLine()
        {
            Line tmpLine = scApp.LineBLL.getLineByIDAndDeleteOtherLine(line.Line_ID);

            put(tmpLine);
        }

        public void refreshZone(string zone_id)
        {
            put(scApp.LineBLL.getZoneByZoneID(zone_id));
        }

        public void refreshNode(string node_id)
        {
            put(scApp.LineBLL.getNodeByNodeID(node_id));
        }

        public void refreshEqpt(string eqpt_id)
        {
            put(scApp.LineBLL.getEqptByEqptID(eqpt_id));
        }

        public void refreshUnit(string unit_id)
        {
            put(scApp.LineBLL.getUnitByUnitID(unit_id));
        }

        public void refreshPort(string port_id)
        {
            put(scApp.LineBLL.getPortByPortID(port_id));
        }

        //public void refreshBuffer(string buff_id)
        //{
        //    put(scApp.LineBLL.getBufferPortByPortID(buff_id));
        //}

        public void refreshAll()
        {
            refreshLine();
            foreach (Zone zone in zoneList)
            {
                refreshZone(zone.Zone_ID);
            }
            foreach (Node node in nodeList)
            {
                refreshNode(node.Node_ID);
            }
            foreach (Equipment eqpt in eqptList)
            {
                refreshEqpt(eqpt.Eqpt_ID);
            }
            foreach (Unit unit in unitList)
            {
                refreshUnit(unit.Unit_ID);
            }
            foreach (Port port in portList)
            {
                refreshPort(port.Port_ID);
            }
            //foreach (BufferPort buff in buffList)
            //{
            //    refreshBuffer(buff.Buff_ID);
            //}
        }
        #endregion
        /// <summary>
        /// 重新載入Alarm Desc File
        /// </summary>
        public void reloadAlarmDescFile()
        {
            foreach (Equipment eqpt in eqptList)
            {
                eqpt.reloadAlarmDesc();
            }
        }

        private void registerFileWatchDog()
        {
            foreach (Equipment eqpt in eqptList)
            {
                //Alarm Desc
                FileSystemWatcher alarmDescWatcher = new FileSystemWatcher();
                if (BCFUtility.isEmpty(eqpt.Alarm_List_File) || !File.Exists(eqpt.Alarm_List_File))
                {
                    continue;
                }
                FileInfo fileInfo = new FileInfo(eqpt.Alarm_List_File);
                alarmDescWatcher.Path = fileInfo.DirectoryName;
                alarmDescWatcher.IncludeSubdirectories = false;
                alarmDescWatcher.NotifyFilter = NotifyFilters.Attributes |
                        NotifyFilters.CreationTime |
                        NotifyFilters.FileName |
                        NotifyFilters.LastWrite |
                        NotifyFilters.Size;

                alarmDescWatcher.Filter = fileInfo.Name;
                alarmDescWatcher.Changed += new FileSystemEventHandler((source, e) =>
                    OnAlarmDescFileChanged(source, e, eqpt));
                alarmDescWatcher.EnableRaisingEvents = true;
                //EQPT Process Data
                FileSystemWatcher procDataFormatWatcher = new FileSystemWatcher();
                if (BCFUtility.isEmpty(eqpt.Process_Data_Format) || !File.Exists(eqpt.Process_Data_Format))
                {
                    continue;
                }
                fileInfo = new FileInfo(eqpt.Process_Data_Format);
                procDataFormatWatcher.Path = fileInfo.DirectoryName;
                procDataFormatWatcher.IncludeSubdirectories = false;
                procDataFormatWatcher.NotifyFilter = NotifyFilters.Attributes |
                        NotifyFilters.CreationTime |
                        NotifyFilters.FileName |
                        NotifyFilters.LastWrite |
                        NotifyFilters.Size;

                procDataFormatWatcher.Filter = fileInfo.Name;
                procDataFormatWatcher.Changed += new FileSystemEventHandler((source, e) =>
                    onProcDataFormatFileChanged(source, e, eqpt));
                procDataFormatWatcher.EnableRaisingEvents = true;
            }
        }

        private void OnAlarmDescFileChanged(object source, FileSystemEventArgs e, Equipment eqpt)
        {
            eqpt.reloadAlarmDesc();
            logger.Info("Reload Equipment[{0}] Alarm List File[{1}]", eqpt.Eqpt_ID, e.FullPath);
        }

        private void onProcDataFormatFileChanged(object source, FileSystemEventArgs e, Equipment eqpt)
        {
            eqpt.reloadProcessDataFormatFile();
            logger.Info("Reload Equipment[{0}] Process Data Format File[{1}]", eqpt.Eqpt_ID, e.FullPath);
        }
    }
}
