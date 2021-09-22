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

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class CarrierHis : PropertyChangedVO
    {
        public CarrierHis()
        {
            CarrierHisPK = new CarrierHisPKInfo();
        }

        public virtual CarrierHisPKInfo CarrierHisPK { get; set; }

        public virtual string Log_Sno { get { return CarrierHisPK.Log_Sno; } set { CarrierHisPK.Log_Sno = value; } }
        public virtual string Crr_ID { get { return CarrierHisPK.Crr_ID; } set { CarrierHisPK.Crr_ID = value; } }
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
        public string Trn_User { get; set; }
        public string Trn_Date { get; set; }
        public string Schedule { get; set; }
        public string RotFlag { get; set; }
        public string FliFlag { get; set; }
        public string BCRRead_Flag { get; set; }
        public string Reject_Flag { get; set; }
        public string Crr_Size { get; set; }
    }

    public class CarrierHisPKInfo
    {
        public virtual string Log_Sno { get; set; }

        public virtual string Crr_ID { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CarrierHisPKInfo)
            {
                CarrierHisPKInfo pk = obj as CarrierHisPKInfo;
                if (BCFUtility.isMatche(this.Log_Sno, pk.Log_Sno)
                    && BCFUtility.isMatche(this.Crr_ID, pk.Crr_ID))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
