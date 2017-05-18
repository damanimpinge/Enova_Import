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
    public partial class ImportExcel
    {
        /// <summary>
        /// 
        /// </summary>
        public OutputClass ImportExceltoPracownicy(string excelPath)
        {
            OutputClass _result = new OutputClass();
            try
            {
                //Excel file Path

                string conString = string.Empty;
                //Get excel file extension
                string extension = Path.GetExtension("C.xlsx");
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

                    dtExcelData.Columns.AddRange(new DataColumn[7] {
                                                 new DataColumn("Guid", typeof(Guid)),
                                                 new DataColumn("RAZEM", typeof(Int32)),
                                                 new DataColumn("RACH#1", typeof(String)),
                                                 new DataColumn("RACH#2", typeof(Decimal)),                                               
                                                 new DataColumn("NAZWISKO",typeof(String)),
                                                 new DataColumn("PESEL",typeof(String)),
                                                 new DataColumn("IMIĘ",typeof(String)) });

                    //Get data from excel Sheet using sheet name and fill that data in the datatable object.
                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                        foreach (DataRow dr in dtExcelData.Rows)
                        {
                            dr["Guid"] = Guid.NewGuid();
                        }
                    }
                    //Close excel code
                    excel_con.Close();
                    _result.NumberofRecords = dtExcelData.Rows.Count;
                    //Get SQL connection string from App config
                    string consString = ConfigurationManager.AppSettings["ConnString"];
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        try
                        {
                            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                            {
                                // Set the database table name
                                sqlBulkCopy.DestinationTableName = "dbo.Pracownicy";
                                //[OPTIONAL]: Map the Excel columns with that of the database table
                                sqlBulkCopy.ColumnMappings.Add("Guid", "Guid");
                                sqlBulkCopy.ColumnMappings.Add("NAZWISKO", "Nazwisko");
                                sqlBulkCopy.ColumnMappings.Add("IMIĘ", "Imie");
                                sqlBulkCopy.ColumnMappings.Add("PESEL", "PESEL");
                                sqlBulkCopy.ColumnMappings.Add("RACH#2", "Kod");
                                sqlBulkCopy.ColumnMappings.Add("RACH#1", "KwotaValue");
                                sqlBulkCopy.ColumnMappings.Add("RAZEM", "Typ");
                                con.Open();
                                sqlBulkCopy.WriteToServer(dtExcelData);
                                con.Close();
                                _result.SuccessRecords = dtExcelData.Rows.Count;
                                _result.FailureRecords = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            Int32 _Success = 0;
                            Int32 _Failure = 0;
                            using (SqlConnection connection = new SqlConnection(consString))
                            {
                                foreach (DataRow dr in dtExcelData.Rows)
                                {
                                    try
                                    {
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.CommandText = "INSERT INTO dbo.Pracownicy (Guid,Nazwisko,Imie,PESEL,Kod,KwotaValue,Typ)VALUES ('" + dr["Guid"] + "','" + dr["NAZWISKO"] + "','" + dr["IMIĘ"] + "'," + dr["PESEL"] + "," + dr["RACH#2"] + "," + dr["RACH#1"] + "," + dr["RAZEM"] + ");";
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Connection = connection;
                                        if (connection.State != ConnectionState.Open)
                                        { connection.Open(); }
                                        cmd.ExecuteNonQuery();
                                        _Success = _Success + 1;
                                    }
                                    catch (Exception exInner)
                                    {
                                        _Failure = _Failure + 1;
                                        String error = "{ErrorMessage:" + exInner.Message.ToString() + ",Record:Guid:'" + dr["Guid"] + "',NAZWISKO:'" + dr["NAZWISKO"] + "',IMIĘ:'" + dr["IMIĘ"] + "',PESEL:" + dr["PESEL"] + ",RACH#2:" + dr["RACH#2"] + ",RACH#1:" + dr["RACH#1"] + ",RAZEM:" + dr["RAZEM"] + "}";
                                        WriteLog(error);
                                    }

                                }
                            }
                            _result.SuccessRecords = _Success;
                            _result.FailureRecords = _Failure;
                        }

                    }
                }
                _result.Exception = "";
                return _result;
            }
            catch (Exception ex)
            {
                _result.NumberofRecords = 0;
                _result.SuccessRecords = 0;
                _result.FailureRecords = 0;
                _result.Exception = ex.Message.ToString();
                return _result;
            }
        }
        public static void WriteLog(string strLog)
        {
            try
            {
                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                string logFilePath = "C:\\Logs\\";
                logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
                logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.WriteLine(strLog);
                log.Close();
            }
            catch (Exception)
            {
                
                
            }
           
        }

        public bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
    public class OutputClass
    {
        public Int32 NumberofRecords { get; set; }
        public Int32 SuccessRecords { get; set; }
        public Int32 FailureRecords { get; set; }
        public String Exception { get; set; }
    }
}
