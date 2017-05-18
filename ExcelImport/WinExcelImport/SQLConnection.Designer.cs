namespace WinExcelImport
{
    partial class SQLConnection
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
            this.lblservername = new System.Windows.Forms.Label();
            this.lbldatabaseName = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtservername = new System.Windows.Forms.TextBox();
            this.txtdatabasename = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblservername
            // 
            this.lblservername.AutoSize = true;
            this.lblservername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblservername.Location = new System.Drawing.Point(15, 13);
            this.lblservername.Name = "lblservername";
            this.lblservername.Size = new System.Drawing.Size(102, 17);
            this.lblservername.TabIndex = 0;
            this.lblservername.Text = "Server Name";
            // 
            // lbldatabaseName
            // 
            this.lbldatabaseName.AutoSize = true;
            this.lbldatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatabaseName.Location = new System.Drawing.Point(15, 40);
            this.lbldatabaseName.Name = "lbldatabaseName";
            this.lbldatabaseName.Size = new System.Drawing.Size(123, 17);
            this.lbldatabaseName.TabIndex = 1;
            this.lbldatabaseName.Text = "Database Name";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.Location = new System.Drawing.Point(15, 71);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(86, 17);
            this.lblusername.TabIndex = 2;
            this.lblusername.Text = "User name";
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpassword.Location = new System.Drawing.Point(15, 101);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(77, 17);
            this.lblpassword.TabIndex = 3;
            this.lblpassword.Text = "Password";
            // 
            // txtservername
            // 
            this.txtservername.Location = new System.Drawing.Point(140, 13);
            this.txtservername.Name = "txtservername";
            this.txtservername.Size = new System.Drawing.Size(200, 20);
            this.txtservername.TabIndex = 4;
            this.txtservername.Text = "IMPINGE57";
            // 
            // txtdatabasename
            // 
            this.txtdatabasename.Location = new System.Drawing.Point(140, 40);
            this.txtdatabasename.Name = "txtdatabasename";
            this.txtdatabasename.Size = new System.Drawing.Size(200, 20);
            this.txtdatabasename.TabIndex = 5;
            this.txtdatabasename.Text = "Nowa_firma";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(140, 71);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(200, 20);
            this.txtusername.TabIndex = 6;
            this.txtusername.Text = "sa";
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(140, 101);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(200, 20);
            this.txtpass.TabIndex = 7;
            this.txtpass.Text = "Impinge250";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(149, 155);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // SQLConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 262);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.txtdatabasename);
            this.Controls.Add(this.txtservername);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.lbldatabaseName);
            this.Controls.Add(this.lblservername);
            this.Name = "SQLConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLConnection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblservername;
        private System.Windows.Forms.Label lbldatabaseName;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.TextBox txtservername;
        private System.Windows.Forms.TextBox txtdatabasename;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button btnConnect;
    }
}