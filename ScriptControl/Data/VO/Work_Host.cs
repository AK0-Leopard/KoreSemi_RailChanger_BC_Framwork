//*********************************************************************************
//      Work_Host.cs
//*********************************************************************************
// File Name: Work_Host.cs
// Description: Work_Host Object
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

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Work_Host
    {
        public Work_Host()
        {
            WorkHostPK = new WorkHostPKInfo();
        }

        public virtual WorkHostPKInfo WorkHostPK { get; set; }

        public virtual string Host_Name { get { return WorkHostPK.Host_Name; } set { WorkHostPK.Host_Name = value; } }
        public virtual string Work_Area { get { return WorkHostPK.Work_Area; } set { WorkHostPK.Work_Area = value; } }
    }

    public class WorkHostPKInfo
    {
        public virtual string Host_Name { get; set; }

        public virtual string Work_Area { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is WorkHostPKInfo)
            {
                WorkHostPKInfo pk = obj as WorkHostPKInfo;
                if (BCFUtility.isMatche(this.Host_Name, pk.Host_Name)
                    && BCFUtility.isMatche(this.Work_Area, pk.Work_Area))
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