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
    public class Shelf : PropertyChangedVO
    {


        private int capacity_alarm;
        public virtual int Capacity_Alarm
        {
            get { return capacity_alarm; }
            set
            {
                if (capacity_alarm != value)
                {
                    capacity_alarm = value;
                    OnPropertyChanged(BCFUtility.getPropertyName(() => this.Capacity_Alarm));
                }
            }
        }
             

       
    }
}
