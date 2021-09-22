using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.PLC_Functions
{
    public class Rail_Changer_W : PLC_FunBase
    {
        [PLCElement(ValueName = "RAIL_ALARMRESET_INDEX")]
        public UInt16 RAIL_ALARMRESET_INDEX;

        [PLCElement(ValueName = "RAIL_RAILSIDESET_INDEX")]
        public UInt16 RAIL_RAILSIDESET_INDEX;

        [PLCElement(ValueName = "RAIL_DELAYSET_INDEX")]
        public UInt16 RAIL_DELAYSET_INDEX;

        [PLCElement(ValueName = "RAIL_RESET_CAREXIST_INDEX")]
        public UInt16 RAIL_RESET_CAREXIST_INDEX;

        [PLCElement(ValueName = "RAIL_MODESET_INDEX")]
        public UInt16 RAIL_MODESET_INDEX;

        [PLCElement(ValueName = "RAIL_FORCESTOP_INDEX")]
        public UInt16 RAIL_FORCESTOP_INDEX;

        [PLCElement(ValueName = "RAIL_ISAUTORUN_INDEX")]
        public UInt16 RAIL_ISAUTORUN_INDEX;

        [PLCElement(ValueName = "RAIL_RAILSIDESET_VALUE")]
        public UInt16 RAIL_RAILSIDESET_VALUE;

        [PLCElement(ValueName = "RAIL_RAILSIDESET_DEFAUL")]
        public UInt16 RAIL_RAILSIDESET_DEFAUL;

        [PLCElement(ValueName = "RAIL_DELAYSET_VALUE")]
        public UInt16 RAIL_DELAYSET_VALUE;

        [PLCElement(ValueName = "RAIL_MODESET_VALUE")]
        public UInt16 RAIL_MODESET_VALUE;

        [PLCElement(ValueName = "RAIL_CHANGE_DELAYTIME")]
        public UInt16 RAIL_CHANGE_DELAYTIME;

        [PLCElement(ValueName = "RAIL_ISAUTORUN_VALUE")]
        public UInt16 RAIL_ISAUTORUN_VALUE;
    }
}