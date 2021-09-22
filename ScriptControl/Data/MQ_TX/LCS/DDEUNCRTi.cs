//*********************************************************************************
//      DDEUNCRTi.cs
//*********************************************************************************
// File Name: DDEUNCRTi.cs
// Description: DDEUNCRTi類別
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2020/09/23    Steven Hong    N/A            A0.01   格式修改
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.mqc.tx
{
    public class DDEUNCRTi : BaseTX
    {
        //Transaction Input Variables
        public String trx_id = "DDEUNCRT";				             //       Transaction ID
        public String type_id = TX_TYPE_INPUT;			             //       input / output
        public String carrier_loc;			                         //       Carrier Location
        public String carrier_id;                                    //       Carrier ID     //A0.01
        public DDEUNCRTi_a1[] cassette_list = new DDEUNCRTi_a1[1];   //       Cassette List  //A0.01 
    }

    //A0.01 Start
    public class DDEUNCRTi_a1 : BaseTX
    {
        //Transaction Variables
        private static readonly int DDEUNCRT_IARY = 3;

        //Sub Array References
        public DDEUNCRTi_a[] cassette_info = new DDEUNCRTi_a[DDEUNCRT_IARY];
    }
    //A0.01 End
}
