using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.ConfigHandler
{
    public class RecipeParameterConfigHandler
    {
        public static readonly string SPARE_FORMAT = "SPARE";
        //;Name,"length(PLC LW)","type(BCD:2,INT:1,CHAR:0)",dot,"symbol(1:有,0:無)"
        private static readonly int TPYE_DEF_ELEMENT_COUNT = 5;
        private string filename;
        public string FileName { get { return filename; } }
        public List<RecipeParameterDataType> RecipeParameterTypeList { get; private set; }

        public RecipeParameterConfigHandler(string file) 
        {
            RecipeParameterTypeList = new List<RecipeParameterDataType>();
            reload(file);
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(String filename)
        {
            this.filename = filename;
            RecipeParameterTypeList.Clear();
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

                    string name = string.Empty;
                    if (valueAry.Length > 0)
                    {
                        try
                        {
                            name = valueAry[0];
                        }
                        catch { }
                    }
                    //A0.01 Begin
                    if (string.Compare(name.Trim(), SPARE_FORMAT.Trim(), true) == 0)
                    {
                        RecipeParameterDataType spare_dataType = new RecipeParameterDataType(
                            RecipeParameterDataType.DataItemType.INT,
                            name, 1, 1, false);
                        RecipeParameterTypeList.Add(spare_dataType);
                        continue;
                    }
                    //A0.01 End
                    int wordCount = 1;
                    if (valueAry.Length > 1)
                    {
                        try
                        {
                            wordCount = Convert.ToInt32(valueAry[1]);
                        }
                        catch { }
                    }
                    RecipeParameterDataType.DataItemType itemType = RecipeParameterDataType.DataItemType.ASCII;
                    if (valueAry.Length > 2)
                    {
                        try
                        {
                            itemType = (RecipeParameterDataType.DataItemType)Convert.ToInt32(valueAry[2]);
                        }
                        catch { }
                    }
                    double multiplier = 1;
                    if (valueAry.Length > 3)
                    {
                        try
                        {
//                            multiplier = Convert.ToDouble(valueAry[3]);
                            int dot = Convert.ToInt16(valueAry[3]);
                            multiplier = Math.Pow(0.1, dot);
                        }
                        catch { }
                    }
                    bool isContainSign = false;
                    if (valueAry.Length > 4)
                    {
                        try
                        {
                            isContainSign = (Convert.ToInt32(valueAry[4]) == 1) ? true : false;
                        }
                        catch { }
                    }
                    RecipeParameterDataType dataType = new RecipeParameterDataType(itemType, name, wordCount, 
                        multiplier, isContainSign);
                    RecipeParameterTypeList.Add(dataType);
                }
            }
        }

    }

    public class RecipeParameterDataType 
    {
        public enum DataItemType 
        {
            ASCII = 0,
            INT = 1,
            BCD = 2
        }
        public DataItemType ItemType { get; private set; }
        public string Name { get; private set; }

        public int WordCount { get; private set; }  //PLC LW個數

        public double Multiplier { get; private set; }  //乘數
        public Boolean IsContainSign { get; private set; }  //是否為有號數

        public RecipeParameterDataType(DataItemType itemType, string name, int wordCound,
            double multiplier, bool isContainSign) 
        {
            this.ItemType = itemType;
            this.Name = name;
            this.WordCount = wordCound;
            this.Multiplier = multiplier;
            this.IsContainSign = isContainSign;
        }
    }

}
