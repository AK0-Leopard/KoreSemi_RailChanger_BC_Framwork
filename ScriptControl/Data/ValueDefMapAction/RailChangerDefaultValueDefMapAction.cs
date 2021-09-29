//*********************************************************************************
//      BCDefaultValueDefMapAction.cs
//*********************************************************************************
// File Name: BCDefaultValueDefMapAction.cs
// Description: BC PC Map Action
//
//(c) Copyright 2013, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.bcf.Controller;
using com.mirle.ibg3k0.bcf.Data.VO;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Data.VO;
using com.mirle.ibg3k0.sc.Common;
using com.mirle.ibg3k0.bcf.Common.MPLC;
using System.Collections;
using com.mirle.ibg3k0.sc.ValueHandler;
using System.Threading;
using com.mirle.ibg3k0.sc.Data.PLC_Functions;
using com.mirle.ibg3k0.bcf.Data.ValueDefMapAction;
using com.mirle.ibg3k0.sc.Data.JSON;
using NLog;

namespace com.mirle.ibg3k0.sc.Data.ValueDefMapAction
{
    public class RailChangerDefaultValueDefMapAction : IValueDefMapAction
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected SCApplication scApp = null;
        protected BCFApplication bcfApp = null;
        protected Node node = null;
        protected Port port = null;
        protected Equipment eqpt = null;

        protected bool PLCIsConnect = true;
        protected object set_lock = new object();        

        public RailChangerDefaultValueDefMapAction()
            : base()
        {
            scApp = SCApplication.getInstance();
            bcfApp = scApp.getBCFApplication();
        }

        public virtual string getIdentityKey()
        {
            return this.GetType().Name;
        }

        public virtual void setContext(BaseEQObject baseEQ)
        {
            this.eqpt = baseEQ as Equipment;
        }

        public virtual void unRegisterEvent()
        {

        }

        public virtual void doShareMemoryInit(BCFAppConstants.RUN_LEVEL runLevel)
        {
            try
            {
                switch (runLevel)
                {
                    case BCFAppConstants.RUN_LEVEL.ZERO:
                        init_RC_Status();
                        break;
                    case BCFAppConstants.RUN_LEVEL.ONE:
                        break;
                    case BCFAppConstants.RUN_LEVEL.TWO:
                        break;
                    case BCFAppConstants.RUN_LEVEL.NINE:
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }

        public virtual void doInit()
        {
            ValueRead RAIL_RC_ALIVE = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_ALIVE", out RAIL_RC_ALIVE))
            {
                RAIL_RC_ALIVE.afterValueChange += (_sender, _e) => RC_ALIVE_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_MODE = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_MODE", out RAIL_RC_MODE))
            {
                RAIL_RC_MODE.afterValueChange += (_sender, _e) => RC_Mode_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_SIDE = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_SIDE", out RAIL_RC_SIDE))
            {
                RAIL_RC_SIDE.afterValueChange += (_sender, _e) => RC_SIDE_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_BLOCKSTATUS = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_BLOCKSTATUS", out RAIL_RC_BLOCKSTATUS))
            {
                RAIL_RC_BLOCKSTATUS.afterValueChange += (_sender, _e) => RC_BLOCKSTATUS_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_AUTOMODE_ONOFF = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_AUTOMODE_ONOFF", out RAIL_RC_AUTOMODE_ONOFF))
            {
                RAIL_RC_AUTOMODE_ONOFF.afterValueChange += (_sender, _e) => RC_AUTOMODE_ONOFF_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_AUTOMODE_DEFAULTSIDE = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_AUTOMODE_DEFAULTSIDE", out RAIL_RC_AUTOMODE_DEFAULTSIDE))
            {
                RAIL_RC_AUTOMODE_DEFAULTSIDE.afterValueChange += (_sender, _e) => RC_AUTOMODE_DEFAULTSIDE_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_CHANGE_COUNT = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_CHANGE_COUNT", out RAIL_RC_CHANGE_COUNT))
            {
                RAIL_RC_CHANGE_COUNT.afterValueChange += (_sender, _e) => RC_CHANGE_COUNT_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_ERROR_REPORT = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_ERROR_REPORT", out RAIL_RC_ERROR_REPORT))
            {
                RAIL_RC_ERROR_REPORT.afterValueChange += (_sender, _e) => RC_ERROR_REPORT_Index_Change(_sender, _e);
            }

            ValueRead RAIL_RC_VERSION = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_VERSION", out RAIL_RC_VERSION))
            {
                RAIL_RC_VERSION.afterValueChange += (_sender, _e) => RC_VERSION_Index_Change(_sender, _e);
            }

        }

        public virtual void RAIL_Sync_Start()
        {

        }

        public virtual void RAIL_Sync_Stop()
        {
            /*ValueRead Alive = null;
            if (bcfApp.tryGetReadValueEventstring(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RC_ALIVE", out Alive))
            {
                Alive.RemoveAllEvents();
            }*/
        }

        protected virtual void RC_ALIVE_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Eq_Alive = (UInt16)vr.getText();
                eqpt.Eq_Alive_Last_Change_time = DateTime.Now;
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }            
        }

        protected virtual void RC_Mode_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Oper_Mode = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }
        private void RC_VERSION_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.RC_Version = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }
        private void RC_ERROR_REPORT_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Error_Report = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }
        private void RC_CHANGE_COUNT_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Change_Count = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }
        private void RC_AUTOMODE_DEFAULTSIDE_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Default_Side = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }

        private void RC_AUTOMODE_ONOFF_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Mode_Onoff = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }
        private void RC_BLOCKSTATUS_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.Block_Status = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }

        private void RC_SIDE_Index_Change(object sender, ValueChangedEventArgs e)
        {
            try
            {
                ValueRead vr = sender as ValueRead;
                eqpt.RC_Side = (UInt16)vr.getText();
            }
            catch (Exception ex)
            {
                logger.Error("RailChangerDefaultValueDefMapAction has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                    eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
            }
        }

        public virtual void init_RC_Status()
        {
            Rail_Changer_R receive_function = scApp.getFunBaseObj<Rail_Changer_R>(eqpt.Eqpt_ID) as Rail_Changer_R;
            receive_function.Read(bcfApp, SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID);

            eqpt.Oper_Mode = receive_function.RAIL_RC_MODE;
            eqpt.RC_Side = receive_function.RAIL_RC_SIDE;
            eqpt.Block_Status = receive_function.RAIL_RC_BLOCKSTATUS;
            eqpt.Mode_Onoff = receive_function.RAIL_RC_AUTOMODE_ONOFF;
            eqpt.Default_Side = receive_function.RAIL_RC_AUTOMODE_DEFAULTSIDE;
            eqpt.Change_Count = receive_function.RAIL_RC_CHANGE_COUNT;
            eqpt.Error_Report = receive_function.RAIL_RC_ERROR_REPORT;
            eqpt.RC_Version = receive_function.RAIL_RC_VERSION;

        }

        //Alarm復歸要求
        public virtual bool RAIL_ALARMRESET()
            {
                bool isSuccessful = false;
                MPLCSMControl smControl = null;
                ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_ALARMRESET_INDEX");

                lock (set_lock)
                {
                    if (PLCIsConnect)
                    {
                        smControl = scApp.getBCFApplication().getMPLCSMControl(RPVW_Trigger.MPLCName) as MPLCSMControl;

                        int x = (UInt16)RPVW_Trigger.getText() + 1;
                        if (x > 65536) { x = 1; }
                        RPVW_Trigger.setWriteValue((UInt16)x);

                        try
                        {
                            isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                        }
                        catch (Exception ex)
                        {
                            logger.Error("RailChangerDefaultValueDefMapAction_RAIL_ALARMRESET has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                             eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                            isSuccessful = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Write EQ=>" + eqpt.Eqpt_ID);
                        Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                        Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                    }
                }

                return isSuccessful;
            }

        //軌道方向切換要求
        public virtual bool RAIL_RAILSIDESET(int RC_Side)
        {
            bool isSuccessful = false;
            MPLCSMControl smControl = null;
            ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RAILSIDESET_INDEX");
            ValueWrite RPVW_RC_Side = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RAILSIDESET_VALUE");
           
            lock (set_lock)
            {
                RPVW_RC_Side.setWriteValue(RC_Side.ToString());

                if (PLCIsConnect)
                {
                    smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;

                    int x = (UInt16)RPVW_Trigger.getText() + 1;
                    if (x > 65536) { x = 1; }
                    RPVW_Trigger.setWriteValue((UInt16)x);

                    try
                    {
                        isSuccessful = smControl.writeDeviceBlock(RPVW_RC_Side);
                        if (isSuccessful)
                        {
                            Thread.Sleep(200);
                            isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("RailChangerDefaultValueDefMapAction_RAIL_RAILSIDESET has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                         eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                        isSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("EQ=>" + eqpt.Eqpt_ID);
                    Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                    Console.WriteLine("PLC Position=>" + RPVW_RC_Side.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_RC_Side.getText().ToString());
                }
            }
            return isSuccessful;
        }

        //換軌檢查延遲時間設置
        public virtual bool RAIL_DELAYSET(int Delay_Time)
        {
            bool isSuccessful = false;
            MPLCSMControl smControl = null;
            ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_DELAYSET_INDEX");
            ValueWrite RPVW_Delay_TIme = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_DELAYSET_VALUE");

            lock (set_lock)
            {
                RPVW_Delay_TIme.setWriteValue(Delay_Time.ToString());

                if (PLCIsConnect)
                {
                    smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;

                    int x = (UInt16)RPVW_Trigger.getText() + 1;
                    if (x > 65536) { x = 1; }
                    RPVW_Trigger.setWriteValue((UInt16)x);

                    try
                    {
                        isSuccessful = smControl.writeDeviceBlock(RPVW_Delay_TIme);
                        if (isSuccessful)
                        {
                            Thread.Sleep(200);
                            isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("RailChangerDefaultValueDefMapAction_RAIL_DELAYSET has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                         eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                        isSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("EQ=>" + eqpt.Eqpt_ID);
                    Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                    Console.WriteLine("PLC Position=>" + RPVW_Delay_TIme.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Delay_TIme.getText().ToString());
                }
            }
            return isSuccessful;
        }

        //重置管轄軌道內有/無車的訊號
        public virtual bool RAIL_RESET_CAREXIST()
        {
            bool isSuccessful = false;
            MPLCSMControl smControl = null;
            ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RESET_CAREXIST_INDEX");

            lock (set_lock)
            {
                if (PLCIsConnect)
                {
                    smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;

                    int x = (UInt16)RPVW_Trigger.getText() + 1;
                    if (x > 65536) { x = 1; }
                    RPVW_Trigger.setWriteValue((UInt16)x);

                    try
                    {
                            isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("RailChangerDefaultValueDefMapAction_RAIL_RESET_CAREXIST has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                         eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                        isSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("EQ=>" + eqpt.Eqpt_ID);
                    Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                }
            }
            return isSuccessful;
        }

        //軌道Auto/Manual要求
        public virtual bool RAIL_MODESET(int Mode)
        {
            bool isSuccessful = false;
            MPLCSMControl smControl = null;
            ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_MODESET_INDEX");
            ValueWrite RPVW_Mode = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_MODESET_VALUE");

            lock (set_lock)
            {
                RPVW_Mode.setWriteValue(Mode.ToString());

                if (PLCIsConnect)
                {
                    smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;

                    int x = (UInt16)RPVW_Trigger.getText() + 1;
                    if (x > 65536) { x = 1; }
                    RPVW_Trigger.setWriteValue((UInt16)x);

                    try
                    {
                        isSuccessful = smControl.writeDeviceBlock(RPVW_Mode);
                        if (isSuccessful)
                        {
                            Thread.Sleep(200);
                            isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("RailChangerDefaultValueDefMapAction_RAIL_MODESET has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                         eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                        isSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("EQ=>" + eqpt.Eqpt_ID);
                    Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                    Console.WriteLine("PLC Position=>" + RPVW_Mode.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Mode.getText().ToString());
                }
            }
            return isSuccessful;
        }

        //強制停止
        public virtual bool RAIL_FORCESTOP()
        {
            bool isSuccessful = false;
            MPLCSMControl smControl = null;
            ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_FORCESTOP_INDEX");

            lock (set_lock)
            {
                if (PLCIsConnect)
                {
                    smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;

                    int x = (UInt16)RPVW_Trigger.getText() + 1;
                    if (x > 65536) { x = 1; }
                    RPVW_Trigger.setWriteValue((UInt16)x);

                    try
                    {
                        isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("RailChangerDefaultValueDefMapAction_RAIL_FORCESTOP_INDEX has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                         eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                        isSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("Write EQ=>" + eqpt.Eqpt_ID);
                    Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                }
            }

            return isSuccessful;
        }

        //軌道Auto/Manual要求
        public virtual bool RAIL_ISAUTORUN(int Side, int OnOff, int DelayTime)
        {
            bool isSuccessful = false;
            MPLCSMControl smControl = null;
            ValueWrite RPVW_Trigger = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_ISAUTORUN_INDEX");
            ValueWrite RPVW_OnOff = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_ISAUTORUN_VALUE");
            ValueWrite RPVW_Side = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_RAILSIDESET_DEFAULTVALUE");
            ValueWrite RPVW_DelayTime = scApp.getBCFApplication().getWriteValueEvent(SCAppConstants.EQPT_OBJECT_CATE_EQPT, eqpt.Eqpt_ID, "RAIL_CHANGE_DELAYTIME");

            lock (set_lock)
            {
                RPVW_OnOff.setWriteValue(OnOff.ToString());
                RPVW_Side.setWriteValue(Side.ToString());
                RPVW_DelayTime.setWriteValue((DelayTime*1000).ToString());
                if (PLCIsConnect)
                {
                    smControl = scApp.getBCFApplication().getMPLCSMControl("EQ") as MPLCSMControl;

                    int x = (UInt16)RPVW_Trigger.getText() + 1;
                    if (x > 65536) { x = 1; }
                    RPVW_Trigger.setWriteValue((UInt16)x);

                    try
                    {
                        isSuccessful = smControl.writeDeviceBlock(RPVW_OnOff);
                        if (isSuccessful)
                            isSuccessful = smControl.writeDeviceBlock(RPVW_Side);
                            if (isSuccessful)
                                isSuccessful = smControl.writeDeviceBlock(RPVW_DelayTime);
                                if (isSuccessful)
                                        isSuccessful = smControl.writeDeviceBlock(RPVW_Trigger);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("RailChangerDefaultValueDefMapAction_RAIL_ISAUTORUN has Error[EQPT Name:{0}],[Error method:{1}],[Error Message:{2}",
                         eqpt.Eqpt_ID, "doShareMemoryInit", ex.ToString());
                        isSuccessful = false;
                    }
                }
                else
                {
                    Console.WriteLine("EQ=>" + eqpt.Eqpt_ID);
                    Console.WriteLine("PLC Position=>" + RPVW_Trigger.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_Trigger.getText().ToString());
                    Console.WriteLine("PLC Position=>" + RPVW_OnOff.ValueRange);
                    Console.WriteLine("Content=>" + RPVW_OnOff.getText().ToString());
                }
            }
            return isSuccessful;
        }

    }
}
