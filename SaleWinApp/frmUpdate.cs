using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleWinApp
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void LoadMemberData()
        {
            txtCompany.Text = frmMain.SetValueForCompanyName;
            txtCity.Text = frmMain.SetValueForCity;
            txtCountry.Text = frmMain.SetValueForCountry;
            txtPassword.Text = frmMain.SetValueForPassword;
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            LoadMemberData();
        }
    }
}
