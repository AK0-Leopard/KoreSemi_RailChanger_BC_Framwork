using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.PLC_Functions
{
    public class Rail_Changer_R : PLC_FunBase
    {
        [PLCElement(ValueName = "RAIL_RC_ALIVE")]
        public UInt16 RAIL_RC_ALIVE;

        [PLCElement(ValueName = "RAIL_RC_MODE")]
        public UInt16 RAIL_RC_MODE;

        [PLCElement(ValueName = "RAIL_RC_SIDE")]
        public UInt16 RAIL_RC_SIDE;

        [PLCElement(ValueName = "RAIL_RC_BLOCKSTATUS")]
        public UInt16 RAIL_RC_BLOCKSTATUS;

        [PLCElement(ValueName = "RAIL_RC_AUTOMODE_ONOFF")]
        public UInt16 RAIL_RC_AUTOMODE_ONOFF;

        [PLCElement(ValueName = "RAIL_RC_AUTOMODE_DEFAULTSIDE")]
        public UInt16 RAIL_RC_AUTOMODE_DEFAULTSIDE;

        [PLCElement(ValueName = "RAIL_RC_CHANGE_COUNT")]
        public UInt16 RAIL_RC_CHANGE_COUNT;

        [PLCElement(ValueName = "RAIL_RC_ERROR_REPORT")]
        public UInt16 RAIL_RC_ERROR_REPORT;

        [PLCElement(ValueName = "RAIL_RC_VERSION")]
        public UInt16 RAIL_RC_VERSION;
    }
}