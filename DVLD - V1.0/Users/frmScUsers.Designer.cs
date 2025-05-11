namespace DVLD___V1._0.Users
{
    partial class frmScUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScUsers));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2VSeparator4 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.btnEditPassword = new Guna.UI2.WinForms.Guna2Button();
            this.guna2VSeparator3 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.btnDetails = new Guna.UI2.WinForms.Guna2Button();
            this.dgvUsersTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2VSeparator2 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(85, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 44;
            this.label2.Text = "Manage Users";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 43;
            this.label1.Text = "Permit";
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
            "None",
            "UserName",
            "FullName",
            "UserID",
            "PersonID",
            "Active",
            "NotActive"});
            this.cbFilterType.Location = new System.Drawing.Point(117, 61);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.ShadowDecoration.BorderRadius = 15;
            this.cbFilterType.ShadowDecoration.Depth = 5;
            this.cbFilterType.ShadowDecoration.Enabled = true;
            this.cbFilterType.Size = new System.Drawing.Size(164, 36);
            this.cbFilterType.TabIndex = 42;
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
            this.txtFilter.Location = new System.Drawing.Point(298, 61);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.PasswordChar = '\0';
            this.txtFilter.PlaceholderText = "";
            this.txtFilter.SelectedText = "";
            this.txtFilter.ShadowDecoration.BorderRadius = 15;
            this.txtFilter.ShadowDecoration.Depth = 5;
            this.txtFilter.ShadowDecoration.Enabled = true;
            this.txtFilter.Size = new System.Drawing.Size(584, 36);
            this.txtFilter.TabIndex = 41;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2VSeparator4);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnEditPassword);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2VSeparator3);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnDetails);
            this.guna2CustomGradientPanel1.Controls.Add(this.dgvUsersTable);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2VSeparator2);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2VSeparator1);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2Separator1);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnDelete);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnEdit);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnAdd);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(34, 129);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.BorderRadius = 25;
            this.guna2CustomGradientPanel1.ShadowDecoration.Depth = 5;
            this.guna2CustomGradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(938, 397);
            this.guna2CustomGradientPanel1.TabIndex = 40;
            // 
            // guna2VSeparator4
            // 
            this.guna2VSeparator4.Location = new System.Drawing.Point(423, 24);
            this.guna2VSeparator4.Name = "guna2VSeparator4";
            this.guna2VSeparator4.Size = new System.Drawing.Size(8, 23);
            this.guna2VSeparator4.TabIndex = 36;
            // 
            // btnEditPassword
            // 
            this.btnEditPassword.Animated = true;
            this.btnEditPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnEditPassword.BorderColor = System.Drawing.Color.IndianRed;
            this.btnEditPassword.BorderRadius = 10;
            this.btnEditPassword.CustomImages.HoveredImage = global::DVLD___V1._0.Properties.Resources.padlock__5_;
            this.btnEditPassword.CustomImages.Image = global::DVLD___V1._0.Properties.Resources.padlock__2_;
            this.btnEditPassword.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditPassword.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnEditPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditPassword.FillColor = System.Drawing.Color.SlateGray;
            this.btnEditPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEditPassword.ForeColor = System.Drawing.Color.White;
            this.btnEditPassword.Location = new System.Drawing.Point(433, 17);
            this.btnEditPassword.Name = "btnEditPassword";
            this.btnEditPassword.Size = new System.Drawing.Size(157, 36);
            this.btnEditPassword.TabIndex = 35;
            this.btnEditPassword.Text = "Edit Password";
            this.btnEditPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEditPassword.TextOffset = new System.Drawing.Point(25, 0);
            this.btnEditPassword.UseTransparentBackground = true;
            this.btnEditPassword.Click += new System.EventHandler(this.btnEditPassword_Click);
            // 
            // guna2VSeparator3
            // 
            this.guna2VSeparator3.Location = new System.Drawing.Point(312, 24);
            this.guna2VSeparator3.Name = "guna2VSeparator3";
            this.guna2VSeparator3.Size = new System.Drawing.Size(8, 23);
            this.guna2VSeparator3.TabIndex = 34;
            // 
            // btnDetails
            // 
            this.btnDetails.Animated = true;
            this.btnDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnDetails.BorderColor = System.Drawing.Color.IndianRed;
            this.btnDetails.BorderRadius = 10;
            this.btnDetails.CustomImages.HoveredImage = global::DVLD___V1._0.Properties.Resources.info__2_;
            this.btnDetails.CustomImages.Image = global::DVLD___V1._0.Properties.Resources.info__1_;
            this.btnDetails.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDetails.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetails.FillColor = System.Drawing.Color.SlateGray;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(322, 17);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(99, 36);
            this.btnDetails.TabIndex = 33;
            this.btnDetails.Text = "Details";
            this.btnDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDetails.TextOffset = new System.Drawing.Point(25, 0);
            this.btnDetails.UseTransparentBackground = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // dgvUsersTable
            // 
            this.dgvUsersTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvUsersTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsersTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsersTable.ColumnHeadersHeight = 30;
            this.dgvUsersTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsersTable.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvUsersTable.Location = new System.Drawing.Point(0, 83);
            this.dgvUsersTable.Name = "dgvUsersTable";
            this.dgvUsersTable.ReadOnly = true;
            this.dgvUsersTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsersTable.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dgvUsersTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsersTable.RowTemplate.Height = 30;
            this.dgvUsersTable.Size = new System.Drawing.Size(938, 292);
            this.dgvUsersTable.TabIndex = 32;
            this.dgvUsersTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsersTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvUsersTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvUsersTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvUsersTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvUsersTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsersTable.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvUsersTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvUsersTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsersTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsersTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsersTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUsersTable.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvUsersTable.ThemeStyle.ReadOnly = true;
            this.dgvUsersTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvUsersTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsersTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsersTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvUsersTable.ThemeStyle.RowsStyle.Height = 30;
            this.dgvUsersTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvUsersTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2VSeparator2
            // 
            this.guna2VSeparator2.Location = new System.Drawing.Point(201, 24);
            this.guna2VSeparator2.Name = "guna2VSeparator2";
            this.guna2VSeparator2.Size = new System.Drawing.Size(8, 23);
            this.guna2VSeparator2.TabIndex = 31;
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Location = new System.Drawing.Point(105, 24);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(8, 23);
            this.guna2VSeparator1.TabIndex = 30;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(-3, 59);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(938, 18);
            this.guna2Separator1.TabIndex = 29;
            // 
            // btnDelete
            // 
            this.btnDelete.Animated = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderColor = System.Drawing.Color.IndianRed;
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.CustomImages.HoveredImage = ((System.Drawing.Image)(resources.GetObject("resource.HoveredImage")));
            this.btnDelete.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnDelete.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelete.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.SlateGray;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(211, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 36);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelete.TextOffset = new System.Drawing.Point(25, 0);
            this.btnDelete.UseTransparentBackground = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Animated = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BorderColor = System.Drawing.Color.IndianRed;
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.CustomImages.HoveredImage = global::DVLD___V1._0.Properties.Resources.edit_text__1_;
            this.btnEdit.CustomImages.Image = global::DVLD___V1._0.Properties.Resources.edit_text;
            this.btnEdit.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEdit.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.SlateGray;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(115, 17);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 36);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEdit.TextOffset = new System.Drawing.Point(25, 0);
            this.btnEdit.UseTransparentBackground = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.CustomImages.HoveredImage = ((System.Drawing.Image)(resources.GetObject("resource.HoveredImage1")));
            this.btnAdd.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnAdd.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdd.CustomImages.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(19, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 36);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdd.TextOffset = new System.Drawing.Point(25, 0);
            this.btnAdd.UseTransparentBackground = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmScUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterType);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScUsers";
            this.Text = "frmUsersScreen";
            this.Load += new System.EventHandler(this.frmUsersScreen_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterType;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator3;
        private Guna.UI2.WinForms.Guna2Button btnDetails;
        private Guna.UI2.WinForms.Guna2DataGridView dgvUsersTable;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator2;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator4;
        private Guna.UI2.WinForms.Guna2Button btnEditPassword;
    }
}