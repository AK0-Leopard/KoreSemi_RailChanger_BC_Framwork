//*********************************************************************************
//      DcsBLL.cs
//*********************************************************************************
// File Name: DcsBLL.cs
// Description: BC DcsBLL
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date               Author           Request No.  Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.sc.Data.VO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.Data.DAO;
using NLog;
using System.Timers;
using com.mirle.ibg3k0.sc.Data.ValueDefMapAction;
using com.mirle.ibg3k0.bcf.App;
using System.Globalization;
using System.Threading;

namespace com.mirle.ibg3k0.sc.BLL
{
    public class DcsBLL
    {
        protected static Logger logger_RobotCMD = LogManager.GetLogger("RobotCommandSystem");
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected Line line = null;
        RCSFaced RCSF = null;


        private readonly int maxThreadSeqCount = 16888;
        private int _threadSequenceNo = 0;
        /// <summary>
        /// when call set operation this variable always add 1
        /// until the value over 16888 this variable will set to 0
        /// </summary>
        public int threadSequenceNo
        {
            set
            {
                if (this._threadSequenceNo > maxThreadSeqCount)
                    this._threadSequenceNo = 0;
                else
                    this._threadSequenceNo += 1;

            }
            get { return this._threadSequenceNo; }
        }

        public DcsBLL()
        {

        }

        public void start(SCApplication scApp)
        {
            this.scApp = scApp;
            RCSF = scApp.RCSFaced;
        }

        public bool DCSgenerator_Transfer(string eqpt_id, string from, string to)
        {
            RobotCommandTable RobotCMDTable = null;

            try
            {
                RobotCMDTable = generateRobotCMDTable(SCAppConstants.GenerateSource.Transfer, eqpt_id, from, to);

                RCSF.createRobotCommandTable(RobotCMDTable, eqpt_id);
            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DCSgenerator_Get(string eqpt_id, string from)
        {
            RobotCommandTable RobotCMDTable = null;

            try
            {
                RobotCMDTable = generateRobotCMDTable(SCAppConstants.GenerateSource.Get, eqpt_id, from, "");

                RCSF.createRobotCommandTable(RobotCMDTable, eqpt_id);
            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DCSgenerator_Put(string eqpt_id, string to)
        {
            RobotCommandTable RobotCMDTable = null;

            try
            {
                RobotCMDTable = generateRobotCMDTable(SCAppConstants.GenerateSource.Put, eqpt_id, "", to);

                RCSF.createRobotCommandTable(RobotCMDTable, eqpt_id);
            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DCSgenerator_Move(string eqpt_id, string to)
        {
            RobotCommandTable RobotCMDTable = null;

            try
            {
                RobotCMDTable = generateRobotCMDTable(SCAppConstants.GenerateSource.Put, eqpt_id, "", to);

                RCSF.createRobotCommandTable(RobotCMDTable, eqpt_id);
            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DCSgenerator_Cancel(string eqpt_id)
        {
            RobotCommandTable RobotCMDTable = null;

            try
            {
                RobotCMDTable = generateRobotCMDTable(SCAppConstants.GenerateSource.Cancel, eqpt_id, "", "");

                RCSF.createRobotCommandTable(RobotCMDTable, eqpt_id);
            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return false;
            }

            return true;
        }

        public bool DCSgenerator_Scan(string eqpt_id)
        {
            RobotCommandTable RobotCMDTable = null;

            try
            {
                RobotCMDTable = generateRobotCMDTable(SCAppConstants.GenerateSource.Scan, eqpt_id, "", "");

                RCSF.createRobotCommandTable(RobotCMDTable, eqpt_id);
            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return false;
            }

            return true;
        }


        /// <summary>
        /// 產生From Or To 的Robot Command Table
        /// </summary>
        private RobotCommandTable generateRobotCMDTable(int Gen_Source, string Stk_ID, string From_Loc, string To_Loc)
        {
            DateTime NowTime = DateTime.Now;
            RobotCommandTable CMDVo = new RobotCommandTable();

            try
            {
                CMDVo.Gen_Source = Gen_Source;
                CMDVo.Seq_No_Year = NowTime.Year;
                CMDVo.Seq_No_Month = NowTime.Month;
                CMDVo.Seq_No_Day = NowTime.Day;
                CMDVo.Seq_No_Hour = NowTime.Hour;
                CMDVo.UsingArm = "";
                CMDVo.Stk_ID = Stk_ID;

                if (Gen_Source == SCAppConstants.GenerateSource.Transfer)
                {
                    CMDVo.From_Loc = From_Loc;
                    CMDVo.To_Loc = To_Loc;
                }
                else if (Gen_Source == SCAppConstants.GenerateSource.Get)
                {
                    CMDVo.From_Loc = From_Loc;
                    CMDVo.To_Loc = "";
                }
                else if (Gen_Source == SCAppConstants.GenerateSource.Put || Gen_Source == SCAppConstants.GenerateSource.Move)
                {
                    CMDVo.From_Loc = "";
                    CMDVo.To_Loc = To_Loc;
                }
                else
                {
                    CMDVo.From_Loc = "";
                    CMDVo.To_Loc = "";
                }

                CMDVo.Command_Gen_Time = NowTime;
                CMDVo.Command_Send_Time = null;
                CMDVo.Command_Start_Time = null;
                CMDVo.Command_End_Time = null;
                CMDVo.Command_Status = (int)SCAppConstants.RobotCMDStatus.Gen;
                CMDVo.Command_Excute_Retune_Code = null;
                CMDVo.Command_Prioty = (int)SCAppConstants.CMDPrioty.Normal_Mode;

            }
            catch (Exception ex)
            {
                logger.Error("Exception:{0}", ex.ToString());
                return null;
            }
            
            return CMDVo;
        }

        public bool HasCMDExecute(string stk_id)
        {
            return scApp.getEQObjCacheManager().getEquipmentByEQPTID(stk_id).HasCMDExecute = scApp.RobotCMDUtility.QueryExecuteRobotCMDCount(stk_id) == 0 ? false : true;
        }

        //------------------------------------------------

        public void recodeRobotCMDLog(string msg)
        {
            CommonInfo ci = scApp.getEQObjCacheManager().CommonInfo;
            if (ci.IsRecodeTraceRobotCMD)
            {
                logger_RobotCMD.Debug(msg);
                ci.TraceRobotCMD = msg;
            }
        }
    }

    public class ArmInfo
    {
        public string GlassID { get { return getArmGlassID(); } }
        public int Status { get { return getArmSTAT(); } }
        public bool IsExist { get { return getArmExist(); } }
        public bool IsGlassOnArm { get { return IsExist && !SCUtility.isEmpty(GlassID); } } 
        ValueRead RS01_STATVR = null;
        ValueRead RS01_ExistFlagVR = null;
        ValueRead RS01_GlassIDVR = null;
        protected SCApplication scApp = null;
        private static ArmInfo application_Upper;
        private static ArmInfo application_Lower;
        private static Object _lock = new Object();

        public static ArmInfo getInstance(string UorL)
        {
            ArmInfo application = null;
            lock (_lock)
            {
                if (BCFUtility.isMatche(UorL, "U"))
                {
                    if (application_Upper == null)
                    {
                        application_Upper = new ArmInfo(UorL);
                    }
                    application = application_Upper;
                }
                else if (BCFUtility.isMatche(UorL, "L"))
                {
                    if (application_Lower == null)
                    {
                        application_Lower = new ArmInfo(UorL);
                    }
                    application = application_Lower;
                }

                return application;
            }
        }

        private ArmInfo(string UorL)
        {
            scApp = SCApplication.getInstance();

            string sArm = string.Empty;
            if(SCUtility.isMatche(UorL, "U"))
            {
                sArm = "UP";
            }
            else
            {
                sArm = "DOWN";
            }

            RS01_STATVR = scApp.getBCFApplication().getReadValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, "ROBOT", string.Format("RS01_{0}_ARM_STAT", sArm));
            RS01_ExistFlagVR = scApp.getBCFApplication().getReadValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, "ROBOT", string.Format("RS01_{0}_GLASS_EX", sArm));
            RS01_GlassIDVR = scApp.getBCFApplication().getReadValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, "ROBOT", string.Format("RS01_{0}_GLASS_ID", sArm));
        }

        private string getArmGlassID()
        {
            return (string)RS01_GlassIDVR.getText();
        }
        private int getArmSTAT()
        {
            return (int)RS01_STATVR.getText();
        }
        private bool getArmExist()
        {
            return (bool)RS01_ExistFlagVR.getText();
        }
    }


    public static class LinqSortExtensions
    {
        private const string Ascending = "ASC";

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property, string dirrection)
        {
            return dirrection == Ascending ? source.OrderBy(property) : source.OrderByDescending(property);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderBy");
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property, string dirrection)
        {
            return dirrection == Ascending ? source.ThenBy(property) : source.ThenByDescending(property);
        }
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenBy");
        }
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenByDescending");
        }
        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            var props = property.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (var pi in props.Select(prop => type.GetProperty(prop)))
            {
                if (pi == null) { continue; }
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}
