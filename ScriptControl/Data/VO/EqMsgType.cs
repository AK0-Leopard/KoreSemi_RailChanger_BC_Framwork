//*********************************************************************************
//      EqMsg.cs
//*********************************************************************************
// File Name: EqMsg.cs
// Description: EqMsg Object
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2019/08/29    Steven Hong    N/A            N/A     Initial Release
//**********************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class EqMsgType
    {
        public virtual string Equipment_ID { get; set; }

        public virtual string Func_ID { get; set; }

        public virtual string Time_Stamp { get; set; }


        public virtual MsgData[] Param { get; set; }

        public class MsgData
        {
            public virtual string Name { get; set; }

            public virtual string Value { get; set; }
        }

        public static MsgData setParam(string name, string value)
        {
            MsgData msg = new MsgData();

            msg.Name = name;
            msg.Value = value;

            return msg;
        }
    }

}