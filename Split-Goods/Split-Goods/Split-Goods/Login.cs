using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Split_Goods
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserID.Text;
            string password = txtPassword.Text;
            if ((this.txtUserID.Text == "Admin") && (this.txtPassword.Text == "Admin"))
            {
                Form frm = new Test();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect, please enter the correct username and password");
                txtUserID.Clear();
                txtPassword.Clear();
            }
        }
    }
}
