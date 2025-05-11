namespace DVLD___V1._0.LocalLicenses
{
    partial class frmScLocalLicenseApps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScLocalLicenseApps));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dgvLocalLicenseAppsTable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsLicenseTests = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTests = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIssueLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPersonLicensesHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseAppsTable)).BeginInit();
            this.cmsLicenseTests.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label2.Location = new System.Drawing.Point(85, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 21);
            this.label2.TabIndex = 49;
            this.label2.Text = "Manage Local License Apps";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 30);
            this.label1.TabIndex = 48;
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
            "Local License ID",
            "NO",
            "FullName",
            "New",
            "Canceled",
            "Completed"});
            this.cbFilterType.Location = new System.Drawing.Point(117, 61);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.ShadowDecoration.BorderRadius = 15;
            this.cbFilterType.ShadowDecoration.Depth = 5;
            this.cbFilterType.ShadowDecoration.Enabled = true;
            this.cbFilterType.Size = new System.Drawing.Size(164, 36);
            this.cbFilterType.TabIndex = 47;
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
            this.txtFilter.TabIndex = 46;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderRadius = 20;
            this.guna2CustomGradientPanel1.Controls.Add(this.dgvLocalLicenseAppsTable);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2VSeparator1);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2Separator1);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnAdd);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(34, 129);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.BorderRadius = 25;
            this.guna2CustomGradientPanel1.ShadowDecoration.Depth = 5;
            this.guna2CustomGradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(938, 397);
            this.guna2CustomGradientPanel1.TabIndex = 45;
            // 
            // dgvLocalLicenseAppsTable
            // 
            this.dgvLocalLicenseAppsTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenseAppsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicenseAppsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicenseAppsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalLicenseAppsTable.ColumnHeadersHeight = 30;
            this.dgvLocalLicenseAppsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLocalLicenseAppsTable.ContextMenuStrip = this.cmsLicenseTests;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalLicenseAppsTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocalLicenseAppsTable.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvLocalLicenseAppsTable.Location = new System.Drawing.Point(0, 83);
            this.dgvLocalLicenseAppsTable.Name = "dgvLocalLicenseAppsTable";
            this.dgvLocalLicenseAppsTable.ReadOnly = true;
            this.dgvLocalLicenseAppsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicenseAppsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLocalLicenseAppsTable.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.dgvLocalLicenseAppsTable.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLocalLicenseAppsTable.RowTemplate.Height = 30;
            this.dgvLocalLicenseAppsTable.Size = new System.Drawing.Size(938, 292);
            this.dgvLocalLicenseAppsTable.TabIndex = 32;
            this.dgvLocalLicenseAppsTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenseAppsTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLocalLicenseAppsTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLocalLicenseAppsTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLocalLicenseAppsTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLocalLicenseAppsTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenseAppsTable.ThemeStyle.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvLocalLicenseAppsTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLocalLicenseAppsTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLocalLicenseAppsTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocalLicenseAppsTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLocalLicenseAppsTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLocalLicenseAppsTable.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvLocalLicenseAppsTable.ThemeStyle.ReadOnly = true;
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.Height = 30;
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLocalLicenseAppsTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cmsLicenseTests
            // 
            this.cmsLicenseTests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripSeparator2,
            this.btnTests,
            this.btnIssueLicense,
            this.btnShowLicense,
            this.toolStripSeparator3,
            this.btnPersonLicensesHistory,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsLicenseTests.Name = "guna2ContextMenuStrip1";
            this.cmsLicenseTests.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsLicenseTests.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsLicenseTests.RenderStyle.ColorTable = null;
            this.cmsLicenseTests.RenderStyle.RoundedEdges = true;
            this.cmsLicenseTests.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsLicenseTests.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsLicenseTests.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsLicenseTests.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsLicenseTests.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsLicenseTests.Size = new System.Drawing.Size(206, 198);
            this.cmsLicenseTests.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLicenseTests_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.showToolStripMenuItem.Text = "Show Application Details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // btnTests
            // 
            this.btnTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewTest,
            this.btnWrittenTest,
            this.btnStreetTest});
            this.btnTests.Enabled = false;
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(205, 22);
            this.btnTests.Text = "Tests";
            // 
            // btnViewTest
            // 
            this.btnViewTest.Enabled = false;
            this.btnViewTest.Name = "btnViewTest";
            this.btnViewTest.Size = new System.Drawing.Size(180, 22);
            this.btnViewTest.Tag = "1";
            this.btnViewTest.Text = "Veiw Test";
            this.btnViewTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnWrittenTest
            // 
            this.btnWrittenTest.Enabled = false;
            this.btnWrittenTest.Name = "btnWrittenTest";
            this.btnWrittenTest.Size = new System.Drawing.Size(180, 22);
            this.btnWrittenTest.Tag = "2";
            this.btnWrittenTest.Text = "Writen Test";
            this.btnWrittenTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStreetTest
            // 
            this.btnStreetTest.Enabled = false;
            this.btnStreetTest.Name = "btnStreetTest";
            this.btnStreetTest.Size = new System.Drawing.Size(180, 22);
            this.btnStreetTest.Tag = "3";
            this.btnStreetTest.Text = "Street Test";
            this.btnStreetTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.Enabled = false;
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(205, 22);
            this.btnIssueLicense.Text = "Issue License (FT)";
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // btnShowLicense
            // 
            this.btnShowLicense.Enabled = false;
            this.btnShowLicense.Name = "btnShowLicense";
            this.btnShowLicense.Size = new System.Drawing.Size(205, 22);
            this.btnShowLicense.Text = "Show License";
            this.btnShowLicense.Click += new System.EventHandler(this.btnShowLicense_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
            // 
            // btnPersonLicensesHistory
            // 
            this.btnPersonLicensesHistory.Enabled = false;
            this.btnPersonLicensesHistory.Name = "btnPersonLicensesHistory";
            this.btnPersonLicensesHistory.Size = new System.Drawing.Size(205, 22);
            this.btnPersonLicensesHistory.Text = "Person Licenses History";
            this.btnPersonLicensesHistory.Click += new System.EventHandler(this.btnPersonLicensesHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.CustomImages.HoveredImage = ((System.Drawing.Image)(resources.GetObject("resource.HoveredImage")));
            this.btnAdd.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
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
            // frmScLocalLicenseApps
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
            this.Name = "frmScLocalLicenseApps";
            this.Text = "frmScLocalLicenseApps";
            this.Load += new System.EventHandler(this.frmScLocalLicenseApps_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseAppsTable)).EndInit();
            this.cmsLicenseTests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterType;
        private Guna.UI2.WinForms.Guna2TextBox txtFilter;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLocalLicenseAppsTable;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsLicenseTests;
        private System.Windows.Forms.ToolStripMenuItem btnShowLicense;
        private System.Windows.Forms.ToolStripMenuItem btnIssueLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnTests;
        private System.Windows.Forms.ToolStripMenuItem btnViewTest;
        private System.Windows.Forms.ToolStripMenuItem btnWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem btnStreetTest;
        private System.Windows.Forms.ToolStripMenuItem btnPersonLicensesHistory;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}