namespace DVLD___V1._0.InternationalLicenses
{
    partial class frmDriverInterLicense
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
            this.components = new System.ComponentModel.Container();
            this.lblLicenseApp1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucDriverInternationalLicenseInfo1 = new DVLD___V1._0.Licenses.InternationalLicenses.Controls.ucDriverInternationalLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLicenseApp1
            // 
            this.lblLicenseApp1.AutoSize = true;
            this.lblLicenseApp1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseApp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblLicenseApp1.Location = new System.Drawing.Point(85, 16);
            this.lblLicenseApp1.Name = "lblLicenseApp1";
            this.lblLicenseApp1.Size = new System.Drawing.Size(200, 21);
            this.lblLicenseApp1.TabIndex = 59;
            this.lblLicenseApp1.Text = "Driver International License";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 58;
            this.label1.Text = "Permit";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucDriverInternationalLicenseInfo1
            // 
            this.ucDriverInternationalLicenseInfo1.Location = new System.Drawing.Point(17, 64);
            this.ucDriverInternationalLicenseInfo1.Name = "ucDriverInternationalLicenseInfo1";
            this.ucDriverInternationalLicenseInfo1.Size = new System.Drawing.Size(866, 322);
            this.ucDriverInternationalLicenseInfo1.TabIndex = 60;
            // 
            // frmDriverInterLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 403);
            this.Controls.Add(this.ucDriverInternationalLicenseInfo1);
            this.Controls.Add(this.lblLicenseApp1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDriverInterLicense";
            this.Text = "frmDriverInterLicense";
            this.Load += new System.EventHandler(this.frmDriverInterLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLicenseApp1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Licenses.InternationalLicenses.Controls.ucDriverInternationalLicenseInfo ucDriverInternationalLicenseInfo1;
    }
}