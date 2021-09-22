using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.JSON
{
    public class BaseReplyJson
    {
        public virtual string FUNCTIONID { get; set; }
        public virtual string FUNCTIONSEQUENCENO { get; set; }
        public virtual string FUNCTIONNAME { get; set; }
        public virtual string EQID { get; set; }
        public virtual string REPORT_TIME { get; set; }
    }
}
