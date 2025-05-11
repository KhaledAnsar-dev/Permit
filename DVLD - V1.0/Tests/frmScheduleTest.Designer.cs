namespace DVLD___V1._0.TestAppointment
{
    partial class frmScheduleTest
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
            this.ucScheduleTest1 = new DVLD___V1._0.Tests.ucScheduleTest();
            this.SuspendLayout();
            // 
            // ucScheduleTest1
            // 
            this.ucScheduleTest1.Location = new System.Drawing.Point(5, 4);
            this.ucScheduleTest1.Name = "ucScheduleTest1";
            this.ucScheduleTest1.Size = new System.Drawing.Size(565, 547);
            this.ucScheduleTest1.TabIndex = 0;
            this.ucScheduleTest1.TestType = DVLD_Business.clsTestTypes.enTestType.VisionTest;
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 572);
            this.Controls.Add(this.ucScheduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScheduleTest";
            this.Text = "frmScheduleTest";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tests.ucScheduleTest ucScheduleTest1;
    }
}