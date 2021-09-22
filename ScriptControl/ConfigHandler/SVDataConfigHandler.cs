using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.ConfigHandler
{
    public class SVDataConfigHandler
    {
        //;SVID,Name,"length(PLC LW)","type(BCD:2,INT:1,CHAR:0)",dot,"symbol(1:有,0:無)"
        private static readonly int TPYE_DEF_ELEMENT_COUNT = 6;
        private string filename;
        public string FileName { get { return filename; } }
        public List<SVDataType> SVDataTypeList { get; private set; }

        public SVDataConfigHandler(string file) 
        {
            SVDataTypeList = new List<SVDataType>();
            reload(file);
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(String filename)
        {
            this.filename = filename;
            SVDataTypeList.Clear();
            //Environment.CurrentDirectory+this.getString("CsvConfig", "") + tableName + ".csv"
            string real_file_name =
                Environment.CurrentDirectory + SCApplication.getInstance().getCsvConfigPath() + "\\" + filename;
            if (System.IO.File.Exists(real_file_name))
                loadFromFile(real_file_name);
            else
                System.IO.File.Create(real_file_name);
        }

        private void loadFromFile(String file)
        {
            foreach (String line in System.IO.File.ReadAllLines(file))
            {
                if ((!String.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")))
                {
                    string[] valueAry = line.Split(new char[] { ',' },
                        TPYE_DEF_ELEMENT_COUNT, StringSplitOptions.None);

                    if (valueAry.Length < 6)
                    {
                        throw new Exception("Process Data Config Has Error!");
                    }
                    string svid = string.Empty;
                    if (valueAry.Length > 0)
                    {
                        try
                        {
                            svid = valueAry[0];
                        }
                        catch { }
                    }
                    string name = string.Empty;
                    if (valueAry.Length > 1)
                    {
                        try
                        {
                            name = valueAry[1];
                        }
                        catch { }
                    }
                    int wordCount = 1;
                    if (valueAry.Length > 2)
                    {
                        try
                        {
                            wordCount = Convert.ToInt32(valueAry[2]);
                        }
                        catch { }
                    }
                    SVDataType.DataItemType itemType = SVDataType.DataItemType.ASCII;
                    if (valueAry.Length > 3)
                    {
                        try
                        {
                            itemType = (SVDataType.DataItemType)Convert.ToInt32(valueAry[3]);
                        }
                        catch { }
                    }
                    double multiplier = 1;
                    if (valueAry.Length > 4)
                    {
                        try
                        {
                            //                            multiplier = Convert.ToDouble(valueAry[4]);
                            int dot = Convert.ToInt16(valueAry[4]);
                            multiplier = Math.Pow(0.1, dot);
                        }
                        catch { }
                    }
                    bool isContainSign = false;
                    if (valueAry.Length > 5)
                    {
                        try
                        {
                            isContainSign = (Convert.ToInt32(valueAry[5]) == 1) ? true : false;
                        }
                        catch { }
                    }
                    SVDataType dataType = new SVDataType(itemType, svid, name, wordCount, multiplier, isContainSign);
                    SVDataTypeList.Add(dataType);
                }
            }
        }

    }

    public class SVDataType
    {
        public enum DataItemType
        {
            ASCII = 0,
            INT = 1,
            BCD = 2
        }
        public DataItemType ItemType { get; private set; }

        public string SVID { get; private set; }

        public string Name { get; private set; }

        public int WordCount { get; private set; }  //PLC LW個數

        public double Multiplier { get; private set; }  //乘數
        public Boolean IsContainSign { get; private set; }  //是否為有號數

        public SVDataType(DataItemType itemType, string svid, string name, int wordCound,
            double multiplier, bool isContainSign)
        {
            this.ItemType = itemType;
            this.SVID = svid;
            this.Name = name;
            this.WordCount = wordCound;
            this.Multiplier = multiplier;
            this.IsContainSign = isContainSign;
        }
    }
}
