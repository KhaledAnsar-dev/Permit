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

namespace DVLD___V1._0
{
    public partial class frmShowPersonDetails : Form
    {
        int PersonID = -1;
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            personDetails1.LoadPersonInfo(PersonID);
        }

        public frmShowPersonDetails(string NO)
        {
            InitializeComponent();
            personDetails1.LoadPersonInfo(NO);
        }
    }
}
