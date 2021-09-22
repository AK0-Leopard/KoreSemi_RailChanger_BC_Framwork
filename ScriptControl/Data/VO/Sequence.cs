using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class Sequence
    {
        public virtual string Seq_Name { get; set; }
        public virtual long Nxt_Val { get; set; }
        public virtual DateTime Record_Time { get; set; }
    }
}
