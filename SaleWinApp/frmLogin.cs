using System.Text.Json;
using System.Text.Json.Nodes;

namespace SaleWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var text = File.ReadAllText(@"D:\F_Store\F-Store\SaleWinApp\appsettings.json");

            JsonObject json = (JsonObject) JsonNode.Parse(text);
            if(txtUsername.Text == "")
            {
                MessageBox.Show("Please enter username !");
                txtUsername.Focus();
            }
            else if(txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password !");
                txtPassword.Focus();
            }
            else
            {
                if(txtUsername.Text.Equals(json["username"].ToString()) && txtPassword.Text.Equals(json["password"].ToString()))
                {
                    MessageBox.Show("Login successfully");
                }
                else
                {
                    MessageBox.Show("Something went wrong with username and password");
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}