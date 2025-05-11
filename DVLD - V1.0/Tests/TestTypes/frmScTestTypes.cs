using DVLD___V1._0.AppTypes;
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

namespace DVLD___V1._0.TestTypes
{
    public partial class frmScTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public frmScTestTypes()
        {
            InitializeComponent();
        }
        private void frmScTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestTypes.GetAllTestTypes();
            dgvTestTypesTable.DataSource = _dtAllTestTypes;

            if(dgvTestTypesTable.Rows.Count != 0)
            {
                dgvTestTypesTable.Columns[0].HeaderText = "ID";
                dgvTestTypesTable.Columns[1].HeaderText = "Title";
                dgvTestTypesTable.Columns[2].HeaderText = "Description";
                dgvTestTypesTable.Columns[3].HeaderText = "Fees";
            }            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTestTypesTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select User");
                return;
            }
            frmEditTestTypes ReAppTypes = new frmEditTestTypes((clsTestTypes.enTestType)dgvTestTypesTable.CurrentRow.Cells[0].Value);
            ReAppTypes.ShowDialog();
            frmScTestTypes_Load(null,null);
        }
    }
}
