namespace DVLD___V1._0.Users
{
    partial class ucPersonDetailsWithFilter
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
            this.pnlPersonFilter = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.cbFilterType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.personDetails1 = new DVLD___V1._0.ucPersonDetails();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlPersonFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPersonFilter
            // 
            this.pnlPersonFilter.BorderRadius = 30;
            this.pnlPersonFilter.Controls.Add(this.btnAddPerson);
            this.pnlPersonFilter.Controls.Add(this.cbFilterType);
            this.pnlPersonFilter.Controls.Add(this.txtFilter);
            this.pnlPersonFilter.Controls.Add(this.btnSearch);
            this.pnlPersonFilter.Controls.Add(this.label1);
            this.pnlPersonFilter.Location = new System.Drawing.Point(18, 18);
            this.pnlPersonFilter.Name = "pnlPersonFilter";
            this.pnlPersonFilter.Size = new System.Drawing.Size(612, 86);
            this.pnlPersonFilter.TabIndex = 1;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Animated = true;
            this.btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAddPerson.BorderRadius = 10;
            this.btnAddPerson.CustomImages.HoveredImage = global::DVLD___V1._0.Properties.Resources.user_avatar;
            this.btnAddPerson.CustomImages.Image = global::DVLD___V1._0.Properties.Resources.user_avatar__1_;
            this.btnAddPerson.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAddPerson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPerson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPerson.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddPerson.ForeColor = System.Drawing.Color.White;
            this.btnAddPerson.Location = new System.Drawing.Point(549, 23);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(36, 36);
            this.btnAddPerson.TabIndex = 91;
            this.btnAddPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.TextOffset = new System.Drawing.Point(25, 0);
            this.btnAddPerson.UseTransparentBackground = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // cbFilterType
            // 
            this.cbFilterType.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterType.BorderRadius = 10;
            this.cbFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilterType.ItemHeight = 30;
            this.cbFilterType.Items.AddRange(new object[] {
            "PersonID",
            "NO"});
            this.cbFilterType.Location = new System.Drawing.Point(90, 23);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.ShadowDecoration.BorderRadius = 15;
            this.cbFilterType.ShadowDecoration.Depth = 5;
            this.cbFilterType.Size = new System.Drawing.Size(164, 36);
            this.cbFilterType.TabIndex = 90;
            this.cbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbFilterType_SelectedIndexChanged);
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
            this.txtFilter.Location = new System.Drawing.Point(267, 23);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PasswordChar = '\0';
            this.txtFilter.PlaceholderText = "";
            this.txtFilter.SelectedText = "";
            this.txtFilter.ShadowDecoration.BorderRadius = 15;
            this.txtFilter.ShadowDecoration.Depth = 5;
            this.txtFilter.Size = new System.Drawing.Size(220, 36);
            this.txtFilter.TabIndex = 89;
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            this.txtFilter.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilter_Validating);
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
            this.btnSearch.Location = new System.Drawing.Point(500, 23);
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
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // personDetails1
            // 
            this.personDetails1.BackColor = System.Drawing.Color.White;
            this.personDetails1.Location = new System.Drawing.Point(18, 125);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(612, 303);
            this.personDetails1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPersonDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPersonFilter);
            this.Controls.Add(this.personDetails1);
            this.Name = "ucPersonDetailsWithFilter";
            this.Size = new System.Drawing.Size(648, 449);
            this.Load += new System.EventHandler(this.ucPersonDetailsWithFilter_Load);
            this.pnlPersonFilter.ResumeLayout(false);
            this.pnlPersonFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucPersonDetails personDetails1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlPersonFilter;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterType;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
