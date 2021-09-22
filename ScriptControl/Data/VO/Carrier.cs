//*********************************************************************************
//      Carrier.cs
//*********************************************************************************
// File Name: Carrier.cs
// Description: Carrier類別
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
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Carrier : PropertyChangedVO
    {
        public virtual string Crr_ID { get; set; }
        public virtual int Crr_Stat { get; set; }
        public virtual int Crr_TrxStat { get; set; }
        public virtual string Loc { get; set; }
        public virtual string To_PortNo { get; set; }
        public virtual int Priority { get; set; }
        public virtual string Cst_Type { get; set; }
        public DateTime? CrrStockIn_Time { get; set; }
        public DateTime? CrrLogOn_Time { get; set; }
        public DateTime? CrrLogOff_Time { get; set; }
        public string CrrLogOff_Port { get; set; }
        public string HoldFlag { get; set; }
        public string Ticket_No { get; set; }
        public string Alternate { get; set; }
        public string Reserve_Flag { get; set; }
        public string Zone_Code { get; set; }
        public string Inventory_Flag { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Schedule { get; set; }
        public string RotFlag { get; set; }
        public string FliFlag { get; set; }
        public string BCRRead_Flag { get; set; }
        public string Reject_Flag { get; set; }
        public string Crr_Size { get; set; }

        //public string Wh_ID
        //{
        //    get
        //    {
        //        string wh_id = null;

        //        if (Loc.Length == 8)
        //        {
        //            if(SCUtility.isMatche(Loc.Substring(0, 2), "11") || SCUtility.isMatche(Loc.Substring(0, 2), "12") || SCUtility.isMatche(Loc.Substring(0, 2), "13"))
        //            {
        //                wh_id = SCAppConstants.StockerName.Stocker1;
        //            }
        //            else if(SCUtility.isMatche(Loc.Substring(0, 2), "21") || SCUtility.isMatche(Loc.Substring(0, 2), "22") ||
        //                    SCUtility.isMatche(Loc.Substring(0, 2), "23") || SCUtility.isMatche(Loc.Substring(0, 2), "24"))
        //            {
        //                wh_id = SCAppConstants.StockerName.Stocker2;
        //            }
        //        }

        //        return wh_id;
        //    }
        //}

        //public int Equ_No
        //{
        //    get
        //    {
        //        int equ_no = 0;

        //        if(Loc.Length == 8)
        //        {
        //            if (!int.TryParse(Loc.Substring(0, 2), out equ_no))
        //            {
        //                equ_no = 0;
        //            }
        //        }

        //        return equ_no;
        //    }
        //}

        //public int Row_X
        //{
        //    get
        //    {
        //        int row_x = 0;

        //        if (Loc.Length == 8)
        //        {
        //            if (!int.TryParse(Loc.Substring(2, 2), out row_x))
        //            {
        //                row_x = 0;
        //            }
        //        }

        //        return row_x;
        //    }
        //}

        //public int Bay_Y
        //{
        //    get
        //    {
        //        int bay_y = 0;

        //        if (Loc.Length == 8)
        //        {
        //            if (!int.TryParse(Loc.Substring(4, 2), out bay_y))
        //            {
        //                bay_y = 0;
        //            }
        //        }

        //        return bay_y;
        //    }
        //}

        //public int Lvl_Z
        //{
        //    get
        //    {
        //        int lvl_z = 0;

        //        if (Loc.Length == 8)
        //        {
        //            if (!int.TryParse(Loc.Substring(6, 2), out lvl_z))
        //            {
        //                lvl_z = 0;
        //            }
        //        }

        //        return lvl_z;
        //    }
        //}
    }
}
