using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.mirle.ibg3k0.bcf.Data;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class FunctionCode
    {

        public virtual string Func_Code { get; set; }
        public virtual string Func_Name { get; set; }
        public virtual string Func_Discription
        {
            get
            {
                return com.mirle.ibg3k0.sc.App.SCApplication.getMessageString(Func_Code);
            }
        }
    }
}
