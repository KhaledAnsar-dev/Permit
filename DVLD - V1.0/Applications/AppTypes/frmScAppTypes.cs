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

namespace DVLD___V1._0.AppTypes
{
    public partial class frmScAppTypes : Form
    {

        private DataTable _dtAllApplicationTypes;

        public frmScAppTypes()
        {
            InitializeComponent();
        }

        private void frmAppTypesScreen_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();

            dgvAppTypesTable.DataSource = _dtAllApplicationTypes;

            if(dgvAppTypesTable.Rows.Count > 0)
            {
                dgvAppTypesTable.Columns[0].HeaderText = "ID";

                dgvAppTypesTable.Columns[1].HeaderText = "Title";

                dgvAppTypesTable.Columns[2].HeaderText = "Fees";
            }         
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAppTypesTable.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select User");
                return;
            }
            frmReAppTypes ReAppTypes = new frmReAppTypes((int)dgvAppTypesTable.CurrentRow.Cells[0].Value);
            ReAppTypes.ShowDialog();

            frmAppTypesScreen_Load(null,null);
        }
    }
}
