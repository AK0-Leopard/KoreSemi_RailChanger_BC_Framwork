//*********************************************************************************
//      KickPosMap.cs
//*********************************************************************************
// File Name: KickPosMap.cs
// Description: Kick Position Map
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

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class PortPosMap
    {
        public String Port_ID { set; get; }
        public String Cim_EQ_ID { set; get; }
        public String Reader_ID { set; get; }
        public String Reader_ID_Upper { set; get; }
        public String Device_ID { set; get; }
        public String Index { set; get; }
        public String Description { set; get; }
    }
}
