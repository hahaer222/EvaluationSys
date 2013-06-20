using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace EvaluationSys
{
    public class ExcelAccess
    {
        public static ExcelAccess excel = null;

        public static ExcelAccess GetInstance()
        {
            if (null == excel)
            {
                excel = new ExcelAccess();
            }
            return excel;
        }


        /// <summary>
        /// 读取Excel 数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public DataSet GetExcelData(string filePath)
        {
            DataSet ds = new DataSet();
            #region 读取Excel 数据

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended properties='Excel 12.0;HDR=YES;'";

            try
            {
                ds = getExcelDetSets(connectionString);
            }
            catch (OleDbException e)
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended properties='Excel 12.0;HDR=YES;'";
                //connectionString = "provider=Microsoft.JET.OLEDB.4.0;Data Source=" + filePath + ";Extended properties='Excel 8.0;HDR=YES;'";
                return getExcelDetSets(connectionString);
            }
            catch (System.Exception ex)
            {
                throw ex;
                //return null;
            }
            return ds;
            #endregion

        }


        /// <summary>
        /// 根据连接字符串，获取数据集
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns></returns>
        private DataSet getExcelDetSets(string connectionString)
        {
            DataSet ds = new DataSet();
            OleDbConnection con = null;
            try
            {
                con = new OleDbConnection(connectionString);
                con.Open();
                DataTable dtSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    string strTableName = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                    string sql = "select * from [" + strTableName + "] ";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    OleDbDataAdapter adapt = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dt.TableName = strTableName;
                    ds.Tables.Add(dt);
                }
                con.Close();
                return ds;
            }
            catch (System.Exception ex)
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                throw ex;
            }
        }

        public string ReadXlsRangeValue(string path, int sheetIndex, int rownumber, int colnumber)
        {
            if (!File.Exists(path)) { return ""; }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Microsoft.Office.Interop.Excel.Workbooks workbooks = null;
            Microsoft.Office.Interop.Excel.Workbook book = null;
            Excel.Worksheet sheet = null; 
            Excel.Range range = null;
            object oV = System.Reflection.Missing.Value;
            try
            {
                // 步骤1：打开某人的表xls 
                book = excel.Workbooks.Open(path, oV, oV, oV, oV,
                oV, oV, oV, oV, oV, oV, oV, oV, oV, oV);
                sheet = (Excel.Worksheet)excel.Sheets.get_Item(sheet);
                sheet.Name = "Salary详细";
                excel.Visible = false;
                // 步骤2：读取数据 
                range = (Excel.Range)sheet.Cells[rownumber, colnumber];
                string value = range.Value2.ToString();
                // 步骤3：保存表格 
                book.Save();
                // 步骤4：关闭book
                excel.Workbooks.Close();
                return value;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                book = null;
                sheet = null;
                range = null;
                excel = null;
                GC.Collect();
            }
        }


    }
}
