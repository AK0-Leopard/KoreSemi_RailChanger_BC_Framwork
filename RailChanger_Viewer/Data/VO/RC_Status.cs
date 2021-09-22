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
    public class RC_Status : PropertyChangedVO
    {
        SCApplication scApp = null;
        public RC_Status() {
            scApp = SCApplication.getInstance();
        }
        private UInt16 myValue;

        public UInt16 MyValue
        {
            get { return scApp.RC_Alive; }
            set
            {
                if (value != scApp.RC_Alive)
                {
                    WhenMyValueChange();
                }
                scApp.RC_Alive = value;
            }
        }
        //定義的委託
        public delegate void MyValueChanged(object sender, EventArgs e);

        //與委託相關聯的事件
        public event MyValueChanged OnMyValueChanged;

        //事件觸發函式
        private void WhenMyValueChange()
        {
            if (OnMyValueChanged != null)
            {
                OnMyValueChanged(this, null);
            }
        }
    }

}
