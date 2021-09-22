//*********************************************************************************
//      Cmd_Com.cs
//*********************************************************************************
// File Name: Cmd_Com.cs
// Description: Cmd_Com Object
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
using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.bcf.Common;
using com.mirle.ibg3k0.sc.App;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Cmd_Com
    {
        public virtual string Cmd_Sno { get; set; }
        public virtual string Ticket_No { get; set; }
        public virtual string Cmd_Stat { get; set; }
        public virtual string sCmd_Stat
        { get { return BCFApplication.getMessageString(string.Format("Cmd_Stat_{0}", Cmd_Stat)); } }

        public virtual string Cmd_Abnormal { get; set; }
        public virtual string sCmd_Abnormal
        { get { return BCFApplication.getMessageString(string.Format("Cmd_Abnormal_{0}", Cmd_Abnormal)); } }

        public virtual string Proc_LotNo { get; set; }
        public virtual int Prty { get; set; }
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual string Xfr_Speed { get; set; }
        public virtual string Zone_ID { get; set; }
        public virtual string Crr_ID { get; set; }
        public virtual string Cst1_ID { get; set; }
        public virtual string Cst2_ID { get; set; }
        public virtual string Cst3_ID { get; set; }
        public virtual string Crt_Date { get; set; }
        public virtual string Exp_Date { get; set; }
        public virtual string End_Date { get; set; }
    }

}