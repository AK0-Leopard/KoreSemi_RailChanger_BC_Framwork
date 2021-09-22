using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.ConfigHandler
{
    public class ECIDConfigHandler
    {
        //;Name,"length(PLC LW)","type(BCD:2,INT:1,CHAR:0)",dot,"symbol(1:有,0:無)"
        private static readonly int TPYE_DEF_ELEMENT_COUNT = 6;
        private string filename;
        public string FileName { get { return filename; } }
        public List<ECIDDataType> ECIDTypeList { get; private set; }

        public ECIDConfigHandler(string file)
        {
            ECIDTypeList = new List<ECIDDataType>();
            reload(file);
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(String filename)
        {
            this.filename = filename;
            ECIDTypeList.Clear();
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

                    if (valueAry.Length < TPYE_DEF_ELEMENT_COUNT)
                    {
                        throw new Exception(string.Format("Process Data Config Has Error! [{0}]", line));
                    }
                    string ecid = string.Empty;
                    if (valueAry.Length > 0)
                    {
                        try
                        {
                            ecid = valueAry[0];
                        }
                        catch { }
                    }
                    string name = string.Empty;
                    if (valueAry.Length > 0)
                    {
                        try
                        {
                            name = valueAry[1];
                        }
                        catch { }
                    }
                    int wordCount = 1;
                    if (valueAry.Length > 1)
                    {
                        try
                        {
                            wordCount = Convert.ToInt32(valueAry[1]);
                        }
                        catch { }
                    }
                    ECIDDataType.DataItemType itemType = ECIDDataType.DataItemType.ASCII;
                    if (valueAry.Length > 2)
                    {
                        try
                        {
                            itemType = (ECIDDataType.DataItemType)Convert.ToInt32(valueAry[2]);
                        }
                        catch { }
                    }
                    double multiplier = 1;
                    if (valueAry.Length > 3)
                    {
                        try
                        {
                            //                            multiplier = Convert.ToDouble(valueAry[3]);
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
                    ECIDDataType dataType = new ECIDDataType(itemType, ecid, name, wordCount,
                        multiplier, isContainSign);
                    ECIDTypeList.Add(dataType);
                }
            }
        }

    }

    public class ECIDDataType
    {
        public enum DataItemType
        {
            ASCII = 0,
            INT = 1,
            BCD = 2
        }
        public DataItemType ItemType { get; private set; }

        public string ECID { get; private set; }

        public string Name { get; private set; }

        public int WordCount { get; private set; }  //PLC LW個數

        public double Multiplier { get; private set; }  //乘數
        public Boolean IsContainSign { get; private set; }  //是否為有號數

        public ECIDDataType(DataItemType itemType, string ecid, string name, int wordCound,
            double multiplier, bool isContainSign)
        {
            this.ItemType = itemType;
            this.ECID = ecid;
            this.Name = name;
            this.WordCount = wordCound;
            this.Multiplier = multiplier;
            this.IsContainSign = isContainSign;
        }
    }

}
