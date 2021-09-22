//*********************************************************************************
//      FileExport.cs
//*********************************************************************************
// File Name: FileExport.cs
// Description: Excel File Export Utility 
//
//(c) Copyright 2014, MIRLE Automation Corporation
//
// Date          Author         Request No.    Tag     Description
// ------------- -------------  -------------  ------  -----------------------------
//**********************************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NLog;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style; 

namespace com.mirle.ibg3k0.bc.winform.Common
{
    class FileExport
    {
        private static Logger logger = LogManager.GetLogger("System Log");

        private DataGridView gridView;
        private string excelFileName = string.Empty;
        ExcelPackage pck = null;
        Dictionary<int, ColumnSet> dataColumnSet = new Dictionary<int, ColumnSet>();

        public FileExport(string fileName)
        {
            try
            {
                excelFileName = DateTime.Now.ToString("yyyy-MM-dd") + fileName + ".xlsx";
                pck = new ExcelPackage();
            }
            catch (Exception ex)
            {
                logger.Error("FileExport.cs has Error[Error method:{0}],[Error Message:{1}",
                        "FileExport", ex.ToString());
            }
        }

        public bool setWorkSheet(DataGridView gridView, string workSheetID, Dictionary<int, ColumnSet> columnSet)
        {
            try
            {
                if (pck == null)
                    return false;

                if (columnSet != null)
                    dataColumnSet = columnSet;

                this.gridView = gridView;
                var currentWorksheet = pck.Workbook.Worksheets.Add(workSheetID);

                currentWorksheet.Cells.Style.Font.Name = "微軟正黑體";
                currentWorksheet.Cells.Style.Font.Size = 11;

                Color rowGreen = System.Drawing.ColorTranslator.FromHtml("#ECF5E7");
                Color headerGreen = System.Drawing.ColorTranslator.FromHtml("#A9D08E");

                //建立標頭
                for (int j = 0; j < this.gridView.Columns.Count; j++)
                {
                    int rowj = j + 1;
                    string header = this.gridView.Columns[j].HeaderText.Trim();

                    currentWorksheet.Cells[1, rowj].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    currentWorksheet.Cells[1, rowj].Value = header;
                    currentWorksheet.Cells[1, rowj].Style.Fill.BackgroundColor.SetColor(headerGreen);
                }

                //填入資料
                for (int i = 0; i < this.gridView.Rows.Count; i++)
                {
                    int rowi = i + 2;

                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < this.gridView.Columns.Count; j++)
                        {
                            int rowj = j + 1;
                            currentWorksheet.Cells[rowi, rowj].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            currentWorksheet.Cells[rowi, rowj].Style.Fill.BackgroundColor.SetColor(rowGreen);
                            currentWorksheet.Cells[rowi, rowj].Value = getCellData(this.gridView.Rows[i].Cells, j);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < this.gridView.Columns.Count; j++)
                        {
                            int rowj = j + 1;
                            currentWorksheet.Cells[rowi, rowj].Value = getCellData(this.gridView.Rows[i].Cells, j);
                        }
                    }
                }

                //調整欄位設定
                List<int> columnList = columnSet.Keys.ToList();
                foreach (int columnIndex in columnList)
                {
                    if (columnIndex < currentWorksheet.Dimension.End.Column)
                    {
                        int index = columnIndex + 1;

                        if (dataColumnSet[columnIndex].Auto_Width)
                            currentWorksheet.Column(index).AutoFit();
                        else
                            currentWorksheet.Column(index).Width = dataColumnSet[columnIndex].Column_Width;

                        if (dataColumnSet[columnIndex].Wrap_Text)
                            currentWorksheet.Column(index).Style.WrapText = true;

                        currentWorksheet.Column(index).Style.HorizontalAlignment = dataColumnSet[columnIndex].Alignment;

                        currentWorksheet.Cells[1, index].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("FileExport.cs has Error[Error method:{0}],[Error Message:{1}",
                        "setWorkSheet", ex.ToString());
                return false;
            }

            return true;
        }

        public bool exportFile()
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = excelFileName;
                savefile.Filter = "Excel files (*.xlsx)|*.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string fullFileName = savefile.FileName;
                    pck.File = new FileInfo(fullFileName);
                    pck.Save();
                }
            }
            catch (Exception ex)
            {
                logger.Error("FileExport.cs has Error[Error method:{0}],[Error Message:{1}",
                        "exportFile", ex.ToString());
                return false;
            }

            return true;
        }

        private string getCellData(DataGridViewCellCollection cell, int index)
        {
            string strData = string.Empty;

            try
            {
                if (cell[index].Value.ToString().Trim().Equals("&nbsp;"))
                    strData = "";
                else
                    strData = cell[index].Value.ToString();
            }
            catch (Exception ex)
            {
                logger.Error("FileExport.cs has Error[Error method:{0}],[Error Message:{1}",
                        "getCellData", ex.ToString());
            }

            return strData;
        }

    }

    public class ColumnSet
    {
        public virtual int Column_Width { get; set; }

        public virtual bool Auto_Width { get; set; }

        public virtual bool Wrap_Text { get; set; }

        public virtual ExcelHorizontalAlignment Alignment { get; set; }
    }
}
