using BusinessObject;
using DataAccess.Repository;
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
        IMemberRepository _memberRepository;

        public frmUpdate()
        {
            InitializeComponent();
            this._memberRepository = new MemberRepository();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var new_members = new Member
            {
                Email = txtEmail.Text,
                CompanyName = txtCompany.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text,
                Orders = new HashSet<Order>(),
            };
            bool updateChecked = _memberRepository.UpdateMember(new_members);
            if (updateChecked)
            {
                frmMain main = new frmMain();
                MessageBox.Show("Updating successfully");
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Updating failed");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void LoadMemberData()
        {
            txtEmail.Text = frmMain.SetValueForEmail;
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
