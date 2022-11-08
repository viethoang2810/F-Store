using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleWinApp
{
    public partial class frmAddMember : Form
    {
        IMemberRepository _memberRepository;
        public frmAddMember()
        {
            InitializeComponent();
            this._memberRepository = new MemberRepository();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var new_members = new Member
            {
                Email = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text,
                Orders = new HashSet<Order>(),
            };
            _memberRepository.CreateMember(new_members);
            if (_memberRepository.GetMember(txtEmail.Text) != null)
            {
                MessageBox.Show("Adding member successfully");
                this.DialogResult = DialogResult.OK; // load lai dgv
            }
            else
            {
                MessageBox.Show("Cannot adding new member to store");
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
