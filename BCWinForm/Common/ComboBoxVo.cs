using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.bc.winform.Common
{
    class ComboBoxVo
    {
        private string displayValue;
        private string value;

        public ComboBoxVo(string sDisplayValue, string sValue)
        {

            this.displayValue = sDisplayValue;
            this.value = sValue;
        }

        public string DisplayValue
        {
            get
            {
                return displayValue;
            }
        }

        public string Value
        {

            get
            {
                return value;
            }
        }
    }
}
