namespace DVLD___V1._0.LocalLicenses
{
    partial class frmLocalLicenseAppDetails
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
            this.ucLocalLicenseApp1 = new DVLD___V1._0.User_Controls.ucLocalLicenseApp();
            this.SuspendLayout();
            // 
            // lblLicenseApp1
            // 
            this.lblLicenseApp1.AutoSize = true;
            this.lblLicenseApp1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseApp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblLicenseApp1.Location = new System.Drawing.Point(85, 16);
            this.lblLicenseApp1.Name = "lblLicenseApp1";
            this.lblLicenseApp1.Size = new System.Drawing.Size(234, 21);
            this.lblLicenseApp1.TabIndex = 56;
            this.lblLicenseApp1.Text = "Local License Application Details";
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
            // ucLocalLicenseApp1
            // 
            this.ucLocalLicenseApp1.Location = new System.Drawing.Point(-4, 58);
            this.ucLocalLicenseApp1.Name = "ucLocalLicenseApp1";
            this.ucLocalLicenseApp1.Size = new System.Drawing.Size(668, 578);
            this.ucLocalLicenseApp1.TabIndex = 57;
            // 
            // frmLocalLicenseAppDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 648);
            this.Controls.Add(this.ucLocalLicenseApp1);
            this.Controls.Add(this.lblLicenseApp1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLocalLicenseAppDetails";
            this.Text = "frmLocalLicenseAppDetails";
            this.Load += new System.EventHandler(this.frmLocalLicenseAppDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLicenseApp1;
        private System.Windows.Forms.Label label1;
        private User_Controls.ucLocalLicenseApp ucLocalLicenseApp1;
    }
}