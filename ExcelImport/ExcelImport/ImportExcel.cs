using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;


namespace ExcelImport
{
    public class ImportExcel
    {

        /// <summary>
        /// 
        /// </summary>
        public bool ImportExceltoEnovaDb()
        {
            try
            {
                //Excel file Path
                string excelPath = @"D:\Impinge Data\ExcelImport\ExcelImport\ExcelImport\ExcelFile\DBItems.xls";
                string conString = string.Empty;
                //Get excel file extension
                string extension = Path.GetExtension("DBItems.xls");
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conString = ConfigurationManager.AppSettings["Excel03ConString"];
                        break;
                    case ".xlsx": //Excel 07 or higher
                        conString = ConfigurationManager.AppSettings["Excel07ConString"];
                        break;

                }
                conString = string.Format(conString, excelPath);
                //Open Ole Db connection using excel file and connection string 
                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    //Open excel code
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();
                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                    dtExcelData.Columns.AddRange(new DataColumn[5] {
                                                 new DataColumn("Guid", typeof(Guid)),
                                                 new DataColumn("Name", typeof(string)),
                                                 new DataColumn("FirmName", typeof(string)),
                                                 new DataColumn("Client",typeof(Int32)),
                                                 new DataColumn("ClientType",typeof(string)) });

                    //Get data from excel Sheet using sheet name and fill that data in the datatable object.
                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT Name,FirmName,Client,ClientType FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                        foreach (DataRow dr in dtExcelData.Rows)
                        {
                           dr["Guid"] = Guid.NewGuid();
                        }
                    }
                    //Close excel code
                    excel_con.Close();

                    //Get SQL connection string from App config
                    string consString = ConfigurationManager.AppSettings["ConnString"];
                    using (SqlConnection con = new SqlConnection(consString))
                    {

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            // Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.DBItems";

                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add("Guid", "Guid");
                            sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                            sqlBulkCopy.ColumnMappings.Add("FirmName", "FirmName");
                            sqlBulkCopy.ColumnMappings.Add("Client", "Client");
                            sqlBulkCopy.ColumnMappings.Add("ClientType", "ClientType");
                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
