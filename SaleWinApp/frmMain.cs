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
            int selectRowIndex = dgvMembers.CurrentCell.RowIndex;
            DataGridViewRow rowData = dgvMembers.Rows[selectRowIndex];
            bool deleteChecked = _memberRepository.DeleteMember(dgvMembers.Rows[selectRowIndex].Cells[1].Value.ToString());
            if (deleteChecked)
            {
                MessageBox.Show($"Delete member {dgvMembers.Rows[selectRowIndex].Cells[1].Value.ToString()} successfully");
            }
            else
            {
                MessageBox.Show("Delete failed");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadDataToDgv();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMembers.DataSource = null;
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _memberRepository.GetMember(txtSearch.Text);
            dgvMembers.DataSource = _bindingSource;
        }
    }
}
