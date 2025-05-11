namespace DVLD___V1._0
{
    partial class frmDriverLicense
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
            this.lblLicenseApp1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucSimplifiedDriverLicenseInfo1 = new DVLD___V1._0.Licenses.LocalLicenses.Controls.ucSimplifiedDriverLicenseInfo();
            this.SuspendLayout();
            // 
            // lblLicenseApp1
            // 
            this.lblLicenseApp1.AutoSize = true;
            this.lblLicenseApp1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseApp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblLicenseApp1.Location = new System.Drawing.Point(85, 16);
            this.lblLicenseApp1.Name = "lblLicenseApp1";
            this.lblLicenseApp1.Size = new System.Drawing.Size(108, 21);
            this.lblLicenseApp1.TabIndex = 56;
            this.lblLicenseApp1.Text = "Driver License";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 55;
            this.label1.Text = "Permit";
            // 
            // ucSimplifiedDriverLicenseInfo1
            // 
            this.ucSimplifiedDriverLicenseInfo1.Location = new System.Drawing.Point(17, 53);
            this.ucSimplifiedDriverLicenseInfo1.Name = "ucSimplifiedDriverLicenseInfo1";
            this.ucSimplifiedDriverLicenseInfo1.Size = new System.Drawing.Size(769, 417);
            this.ucSimplifiedDriverLicenseInfo1.TabIndex = 57;
            // 
            // frmDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 482);
            this.Controls.Add(this.ucSimplifiedDriverLicenseInfo1);
            this.Controls.Add(this.lblLicenseApp1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDriverLicense";
            this.Text = "frmDriverLicense";
            this.Load += new System.EventHandler(this.frmDriverLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLicenseApp1;
        private System.Windows.Forms.Label label1;
        private Licenses.LocalLicenses.Controls.ucSimplifiedDriverLicenseInfo ucSimplifiedDriverLicenseInfo1;
    }
}