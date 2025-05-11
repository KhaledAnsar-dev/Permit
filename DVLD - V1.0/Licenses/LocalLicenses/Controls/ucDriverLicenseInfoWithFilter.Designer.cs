namespace DVLD___V1._0.User_Controls
{
    partial class ucDriverLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ucSimplifiedDriverLicenseInfo1 = new DVLD___V1._0.Licenses.LocalLicenses.Controls.ucSimplifiedDriverLicenseInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.BorderRadius = 30;
            this.pnlFilter.Controls.Add(this.txtFilter);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Location = new System.Drawing.Point(16, 20);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.ShadowDecoration.BorderRadius = 35;
            this.pnlFilter.ShadowDecoration.Depth = 5;
            this.pnlFilter.ShadowDecoration.Enabled = true;
            this.pnlFilter.Size = new System.Drawing.Size(750, 86);
            this.pnlFilter.TabIndex = 2;
            // 
            // txtFilter
            // 
            this.txtFilter.BackColor = System.Drawing.Color.Transparent;
            this.txtFilter.BorderRadius = 10;
            this.txtFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilter.DefaultText = "";
            this.txtFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilter.Location = new System.Drawing.Point(153, 23);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PasswordChar = '\0';
            this.txtFilter.PlaceholderText = "";
            this.txtFilter.SelectedText = "";
            this.txtFilter.ShadowDecoration.BorderRadius = 15;
            this.txtFilter.ShadowDecoration.Depth = 5;
            this.txtFilter.Size = new System.Drawing.Size(394, 36);
            this.txtFilter.TabIndex = 89;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderColor = System.Drawing.Color.IndianRed;
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.CustomImages.HoveredImage = global::DVLD___V1._0.Properties.Resources.magnifying_glass__1_1;
            this.btnSearch.CustomImages.Image = global::DVLD___V1._0.Properties.Resources.magnifying_glass;
            this.btnSearch.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearch.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(557, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 36);
            this.btnSearch.TabIndex = 88;
            this.btnSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearch.TextOffset = new System.Drawing.Point(25, 0);
            this.btnSearch.UseTransparentBackground = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 87;
            this.label1.Text = "Filter";
            // 
            // ucSimplifiedDriverLicenseInfo1
            // 
            this.ucSimplifiedDriverLicenseInfo1.Location = new System.Drawing.Point(7, 115);
            this.ucSimplifiedDriverLicenseInfo1.Name = "ucSimplifiedDriverLicenseInfo1";
            this.ucSimplifiedDriverLicenseInfo1.Size = new System.Drawing.Size(769, 417);
            this.ucSimplifiedDriverLicenseInfo1.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucSimplifiedDriverLicenseInfo1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "ucDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(779, 542);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.Label label1;
        private Licenses.LocalLicenses.Controls.ucSimplifiedDriverLicenseInfo ucSimplifiedDriverLicenseInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
