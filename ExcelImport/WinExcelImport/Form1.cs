using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ExcelImport;

namespace WinExcelImport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string path = ExcelFileUploder.FileName;
            ImportExcel _import = new ImportExcel();
            var result = _import.ImportExceltoPracownicy(path);
            if (result.NumberofRecords == result.SuccessRecords && result.NumberofRecords>0)
            {
                lblResult.Text = "All records inserted in the database successfully";
            }
            else if (result.SuccessRecords > 0 && result.FailureRecords > 0)
            {
                lblResult.Text = result.SuccessRecords + " records inserted in the database successfully out of " + result.NumberofRecords + "(Please check the log file for failure reason [Path: C:\\Logs\\'])";
            }
            else if (result.SuccessRecords == 0 && result.FailureRecords > 0)
            {
                lblfailure.Text = "All records fail to insert in the database, Please check the log file for exact reason [Path: C:\\Logs\\']";
            }
            else
            {
                lblfailure.Text = "Error in the program execution. here is the Exception " + result.Exception;
            }
            lblFileuploader.Text = "No file (Click to upload file)";
            Submit.Enabled = false;
        }

        private void lblFileuploader_Click(object sender, EventArgs e)
        {
            ExcelFileUploder.Multiselect = false;
            ExcelFileUploder.ShowDialog();
            //ExcelFileUploder.Filter = "allfiles|*.xls";
            if (ExcelFileUploder.ShowDialog() == DialogResult.OK)  
            { 
                lblFileuploader.Text = Path.GetFileName(ExcelFileUploder.FileName);
                Submit.Enabled = true;
                lblfailure.Text = "";
                lblResult.Text = "";
            }
        }

        private void btnUploader_Click(object sender, EventArgs e)
        {
            ExcelFileUploder.Multiselect = false;
            ExcelFileUploder.ShowDialog();
            //ExcelFileUploder.Filter = "allfiles|*.xls";
            if (ExcelFileUploder.ShowDialog() == DialogResult.OK)
            {
                lblFileuploader.Text = Path.GetFileName(ExcelFileUploder.FileName);
                Submit.Enabled = true;
                lblfailure.Text = "";
                lblResult.Text = "";
            }
        }
    }
}
