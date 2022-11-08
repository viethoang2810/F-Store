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
    public partial class frmMain : Form
    {
        IMemberRepository _memberRepository;
        BindingSource _bindingSource;
        public frmMain()
        {
            InitializeComponent();
            this._memberRepository = new MemberRepository();
        }

        private void btnMemberManagement_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are standing at Member Management");
        }

        private void btnOrderManagement_Click(object sender, EventArgs e)
        {
            frmOrders order = new frmOrders();
            order.Show();
            this.Hide();
        }

        private void btnProductManagement_Click(object sender, EventArgs e)
        {
            frmProducts product = new frmProducts();
            product.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDataToDgv();
        }

        private void LoadDataToDgv()
        {
            dgvMembers.DataSource = null;
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _memberRepository.GetAllMembers();
            dgvMembers.DataSource = _bindingSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddMember addMember = new frmAddMember();
            addMember.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadDataToDgv();
        }
}
