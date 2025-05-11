using DVLD___V1._0.User_Controls;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD___V1._0.frmRePeople;

namespace DVLD___V1._0.TestAppointment
{
    public partial class frmScheduleTest : Form
    {

        private int _LocalDLA_ID = -1;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private int _TestAppointmentID = -1;

        public frmScheduleTest(int LocalDLA_ID , clsTestTypes.enTestType TestTypeID , int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDLA_ID = LocalDLA_ID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ucScheduleTest1.TestType = _TestTypeID;
            ucScheduleTest1.LoadInfo(_LocalDLA_ID, _TestAppointmentID);
        }
    }
}
