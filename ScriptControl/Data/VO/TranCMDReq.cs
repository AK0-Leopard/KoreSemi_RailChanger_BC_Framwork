using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.Data.VO
{
    public class TranCMDReq
    {
        public int SeqNo { get; set; }

        public int Step1_Motion { get; set; }
        public int Step1_No { get; set; }
        public int Step1_Arm { get; set; }
        public string Step1_MG_ID { get; set; }
        public string Step1_From_Loc { get; set; }
        public string Step1_To_Loc { get; set; }

        public int Step2_Motion { get; set; }
        public int Step2_No { get; set; }
        public int Step2_Arm { get; set; }
        public string Step2_MG_ID { get; set; }
        public string Step2_From_Loc { get; set; }
        public string Step2_To_Loc { get; set; }

        public int Step3_Motion { get; set; }
        public int Step3_No { get; set; }
        public int Step3_Arm { get; set; }
        public string Step3_MG_ID { get; set; }
        public string Step3_From_Loc { get; set; }
        public string Step3_To_Loc { get; set; }

        public int Step4_Motion { get; set; }
        public int Step4_No { get; set; }
        public int Step4_Arm { get; set; }
        public string Step4_MG_ID { get; set; }
        public string Step4_From_Loc { get; set; }
        public string Step4_To_Loc { get; set; }

        private string PARAMETER_MOTION = "Motion";
        private string PARAMETER_ARM = "Arm";
        public override string ToString()
        {
            PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
            StringBuilder builder = new StringBuilder();
            foreach (PropertyDescriptor pd in coll)
            {

                string name = pd.Name;
                int value = (int)pd.GetValue(this);
                string sValue = value.ToString();
                if (name.Contains(PARAMETER_MOTION))
                {
                    if (Enum.IsDefined(typeof(SCAppConstants.CommandType), value))
                    {
                        sValue = ((SCAppConstants.CommandType)value).ToString();
                    }
                }
                else if (name.Contains(PARAMETER_ARM))
                {
                    if (Enum.IsDefined(typeof(SCAppConstants.EmptyArm), value))
                    {
                        sValue = ((SCAppConstants.EmptyArm)value).ToString();
                    }
                }
                builder.Append("\r\n");
                builder.Append("\t\t\t\t\t\t\t\t\t\t\t\t\t");
                builder.Append(string.Format("{0} : {1}", pd.Name, sValue));

            }
            return builder.ToString();
        }



    }
}
