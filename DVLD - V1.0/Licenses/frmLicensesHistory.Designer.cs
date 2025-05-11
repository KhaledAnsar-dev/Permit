namespace DVLD___V1._0.LocalLicenses
{
    partial class frmLicensesHistory
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
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.ucLicensesHistory1 = new DVLD___V1._0.User_Controls.ucLicensesHistory();
            this.personDetails1 = new DVLD___V1._0.ucPersonDetails();
            this.SuspendLayout();
            // 
            // lblLicenseApp1
            // 
            this.lblLicenseApp1.AutoSize = true;
            this.lblLicenseApp1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseApp1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblLicenseApp1.Location = new System.Drawing.Point(85, 16);
            this.lblLicenseApp1.Name = "lblLicenseApp1";
            this.lblLicenseApp1.Size = new System.Drawing.Size(181, 21);
            this.lblLicenseApp1.TabIndex = 58;
            this.lblLicenseApp1.Text = "Person  Licenses History ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 57;
            this.label1.Text = "Permit";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 27;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(32, 379);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.BorderRadius = 20;
            this.guna2CustomGradientPanel1.ShadowDecoration.Depth = 6;
            this.guna2CustomGradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(612, 240);
            this.guna2CustomGradientPanel1.TabIndex = 61;
            // 
            // ucLicensesHistory1
            // 
            this.ucLicensesHistory1.Location = new System.Drawing.Point(32, 379);
            this.ucLicensesHistory1.Name = "ucLicensesHistory1";
            this.ucLicensesHistory1.Size = new System.Drawing.Size(612, 240);
            this.ucLicensesHistory1.TabIndex = 60;
            // 
            // personDetails1
            // 
            this.personDetails1.BackColor = System.Drawing.Color.White;
            this.personDetails1.Location = new System.Drawing.Point(32, 59);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(612, 303);
            this.personDetails1.TabIndex = 0;
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 648);
            this.Controls.Add(this.ucLicensesHistory1);
            this.Controls.Add(this.lblLicenseApp1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.personDetails1);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLicensesHistory";
            this.Text = "frmLicensesHistory";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPersonDetails personDetails1;
        private System.Windows.Forms.Label lblLicenseApp1;
        private System.Windows.Forms.Label label1;
        private User_Controls.ucLicensesHistory ucLicensesHistory1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}