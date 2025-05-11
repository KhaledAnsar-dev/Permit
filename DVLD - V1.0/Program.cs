using DVLD___V1._0.InternationalLicenses;
using DVLD___V1._0.LocalLicenses;
using DVLD___V1._0.RenewLicense;
using DVLD___V1._0.TestAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___V1._0
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new PeopleRecordEditor());
            //Application.Run(new PeopleScreen());
            //Application.Run(new Test());
            //Application.Run(new frmScLocalLicenseApps());
            //Application.Run(new frmScTestAppointments());
            //Application.Run(new frmDriverLicense(37));
            //Application.Run(new frmLicensesHistory());
            //Application.Run(new frmReInternationLicenses());
            //Application.Run(new frmReRenewLicense());

            Application.Run(new frmLoginScreen());

        }
    }
}
