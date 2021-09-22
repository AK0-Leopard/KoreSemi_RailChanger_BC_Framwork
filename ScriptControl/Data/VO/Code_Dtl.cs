//*********************************************************************************
//      Code_Dtl.cs
//*********************************************************************************
// File Name: Code_Dtl.cs
// Description: Code_Dtl Object
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
    public class Code_Dtl
    {
        public Code_Dtl()
        {
            CodeDtlPK = new CodeDtlPKInfo();
        }

        public virtual CodeDtlPKInfo CodeDtlPK { get; set; }

        public virtual string Code_Type { get { return CodeDtlPK.Code_Type; } set { CodeDtlPK.Code_Type = value; } }
        public virtual string Code_No { get { return CodeDtlPK.Code_No; } set { CodeDtlPK.Code_No = value; } }
        public virtual string Code_Name { get; set; }
        public virtual int Limit_Len { get; set; }
        public virtual string Code_Color { get; set; }
        public virtual string Code_Ul { get; set; }
        public virtual string Code_Ll { get; set; }
        public virtual string Is_Sys { get; set; }
    }

    public class CodeDtlPKInfo
    {
        public virtual string Code_Type { get; set; }

        public virtual string Code_No { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is CodeDtlPKInfo)
            {
                CodeDtlPKInfo pk = obj as CodeDtlPKInfo;
                if (BCFUtility.isMatche(this.Code_Type, pk.Code_Type)
                    && BCFUtility.isMatche(this.Code_No, pk.Code_No))
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