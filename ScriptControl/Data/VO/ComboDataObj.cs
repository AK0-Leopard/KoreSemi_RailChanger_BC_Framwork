using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class ComboDataObj
    {
        private string m_display = string.Empty;
        private string m_value = string.Empty;

        public ComboDataObj(string display, string value)
        {
            this.m_display = display;
            this.m_value = value;
        }
        public string Display
        {
            get { return this.m_display; }
            set { this.m_display = value; }
        }
        public string Value
        {
            get { return this.m_value; }
            set { this.m_value = value; }
        }

    }
}
