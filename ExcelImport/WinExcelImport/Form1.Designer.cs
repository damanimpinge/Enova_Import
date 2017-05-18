namespace WinExcelImport
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ExcelFileUploder = new System.Windows.Forms.OpenFileDialog();
            this.lblFileuploader = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.btnUploader = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblfailure = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import data from Excel to Pracownicy Table";
            // 
            // ExcelFileUploder
            // 
            this.ExcelFileUploder.FileName = "ExcelFileUploder";
            // 
            // lblFileuploader
            // 
            this.lblFileuploader.AutoSize = true;
            this.lblFileuploader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileuploader.Location = new System.Drawing.Point(15, 62);
            this.lblFileuploader.Name = "lblFileuploader";
            this.lblFileuploader.Size = new System.Drawing.Size(162, 13);
            this.lblFileuploader.TabIndex = 3;
            this.lblFileuploader.Text = "No file (Click to upload file)";
            this.lblFileuploader.Click += new System.EventHandler(this.lblFileuploader_Click);
            // 
            // Submit
            // 
            this.Submit.Enabled = false;
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.Location = new System.Drawing.Point(92, 98);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(158, 23);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Export To Database";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // btnUploader
            // 
            this.btnUploader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploader.Location = new System.Drawing.Point(175, 59);
            this.btnUploader.Name = "btnUploader";
            this.btnUploader.Size = new System.Drawing.Size(75, 23);
            this.btnUploader.TabIndex = 5;
            this.btnUploader.Text = "Upload";
            this.btnUploader.UseVisualStyleBackColor = true;
            this.btnUploader.Click += new System.EventHandler(this.btnUploader_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblResult.Location = new System.Drawing.Point(15, 146);
            this.lblResult.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 17);
            this.lblResult.TabIndex = 6;
            // 
            // lblfailure
            // 
            this.lblfailure.AutoSize = true;
            this.lblfailure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfailure.ForeColor = System.Drawing.Color.Red;
            this.lblfailure.Location = new System.Drawing.Point(15, 146);
            this.lblfailure.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblfailure.Name = "lblfailure";
            this.lblfailure.Size = new System.Drawing.Size(0, 17);
            this.lblfailure.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 401);
            this.Controls.Add(this.lblfailure);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnUploader);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.lblFileuploader);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Excel Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ExcelFileUploder;
        private System.Windows.Forms.Label lblFileuploader;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button btnUploader;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblfailure;
    }
}

