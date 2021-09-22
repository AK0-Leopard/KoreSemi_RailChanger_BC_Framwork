//*********************************************************************************
//      ProcessDataConfigHandler.cs
//*********************************************************************************
// File Name: ProcessDataConfigHandler.cs
// Description: Type 1 EQ Process Data format解析
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
// 2014/12/18    Hayes Chen     N/A            A0.01   將預留空間(Spare)納入一個Format Type內
// 2016/06/27    Kevin Wei      N/A            A0.02   加入SiteName的管理。
//**********************************************************************************
using com.mirle.ibg3k0.sc.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.mirle.ibg3k0.sc.ConfigHandler
{
    public class ProcessDataConfigHandler
    {
        public static readonly string SPARE_FORMAT = "SPARE";
        public static readonly string KEY_WORD_SITENAME = "SiteName"; //A0.02
        //;Name,"length(PLC LW)","type(BCD:2,INT:1,CHAR:0)",dot,"symbol(1:有,0:無)"
        //A0.02 private static readonly int TPYE_DEF_ELEMENT_COUNT = 5;
        private int TPYE_DEF_ELEMENT_COUNT = 5;                         //A0.02
        private static readonly int TPYE_DEF_ELEMENT_COUNT_NORMAL = 5;  //A0.02
        private static readonly int TPYE_DEF_ELEMENT_COUNT_SITENAME = 6;//A0.02
        private string filename;
        public string FileName { get { return filename; } }
        public List<ProcessDataType> ProcDataTypeList { get; private set; }

        public ProcessDataConfigHandler(string file)
        {
            ProcDataTypeList = new List<ProcessDataType>();
            TPYE_DEF_ELEMENT_COUNT = TPYE_DEF_ELEMENT_COUNT_NORMAL; //A0.02
            reload(file);
        }

        public void reload()
        {
            reload(this.filename);
        }

        public void reload(String filename)
        {
            this.filename = filename;
            ProcDataTypeList.Clear();
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
                        //A0.02 ProcessDataType spare_dataType = new ProcessDataType(ProcessDataType.DataItemType.INT,
                        //A0.02 name, 1, 1, false);
                        ProcessDataType spare_dataType = new ProcessDataType(ProcessDataType.DataItemType.INT, //A0.02 
                            name, 1, 1, false, SCAppConstants.DEFAULT_SITE_NAME);                              //A0.02 
                        ProcDataTypeList.Add(spare_dataType);
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
                    ProcessDataType.DataItemType itemType = ProcessDataType.DataItemType.ASCII;
                    if (valueAry.Length > 2)
                    {
                        try
                        {
                            itemType = (ProcessDataType.DataItemType)Convert.ToInt32(valueAry[2]);
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

                    //A0.02 Start 1/2
                    string siteName = string.Empty;
                    if (valueAry.Length > 5)
                    {
                        try
                        {
                            siteName = valueAry[5];
                        }
                        catch { }
                    }
                    else
                    {
                        siteName = SCAppConstants.DEFAULT_SITE_NAME;
                    }
                    //A0.02 End 1/2

                    ProcessDataType dataType = new ProcessDataType(itemType, name, wordCount,
                        multiplier, isContainSign, siteName);
                    ProcDataTypeList.Add(dataType);
                }
                else //A0.02 Start 2/2
                {
                    if (line.Contains(KEY_WORD_SITENAME))
                    {
                        TPYE_DEF_ELEMENT_COUNT = TPYE_DEF_ELEMENT_COUNT_SITENAME;
                    }
                }   //A0.02 End 2/2
            }
        }

    }

    public class ProcessDataType
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

        public string SiteName { get; private set; }  //Site Name //A0.02


        //A0.02 public ProcessDataType(DataItemType itemType, string name, int wordCound,
        //A0.02    double multiplier, bool isContainSign)
        public ProcessDataType(DataItemType itemType, string name, int wordCound, //A0.02
            double multiplier, bool isContainSign, string siteName)               //A0.02
        {
            this.ItemType = itemType;
            this.Name = name;
            this.WordCount = wordCound;
            this.Multiplier = multiplier;
            this.IsContainSign = isContainSign;
            this.SiteName = siteName;  //A0.02
        }
    }

}
