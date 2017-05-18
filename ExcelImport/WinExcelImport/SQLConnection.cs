using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelImport;
using System.Configuration;

namespace WinExcelImport
{
    public partial class SQLConnection : Form
    {
        public SQLConnection()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            String Connectionstring = "Data Source=" + txtservername.Text + ";Database=" + txtdatabasename.Text + ";User Id=" + txtusername.Text + ";password=" + txtpass.Text + "";
       
            ImportExcel _import = new ImportExcel();
            if (_import.IsServerConnected(Connectionstring))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Add("ConnString", Connectionstring);
                config.Save(ConfigurationSaveMode.Minimal);
                this.Hide();
                Form1 _Form1 = new Form1();
                _Form1.Show();
            }
            else {
                MessageBox.Show("Invalid SQl server connection values, please check");
            }
        }
    }
}
