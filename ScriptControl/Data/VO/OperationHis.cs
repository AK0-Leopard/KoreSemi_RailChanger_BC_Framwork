using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class OperationHis
    {
        public string Seq_No { get; set; }
        //TimestampFormat_19
        public virtual string T_Stamp { get; set; }

        public virtual string User_ID { get; set; }

        public virtual string Form_Name { get; set; }

        public virtual string Action { get; set; }
    }
}
