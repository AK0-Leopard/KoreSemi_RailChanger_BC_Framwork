using com.mirle.ibg3k0.bcf.App;
using com.mirle.ibg3k0.sc.App;
using com.mirle.ibg3k0.sc.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class ConsoleMsg
    {
        public DateTime recordTime { get; set; }
        public virtual string sRecordTime
        {
            get
            {
                return recordTime.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
        public string msg { get; set; }
        public string msgLevel { get; set; }
        public virtual string smsgLevel
        { get { return BCFApplication.getMessageString(string.Format("MessageLevel_{0}", msgLevel)); } }
        public ConsoleMsg(string msg, string msgLevel)
        {
            this.recordTime = DateTime.Now;
            this.msg = msg;
            this.msgLevel = msgLevel;
        }

    }
}
