using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=NAAJI\\SQLEXPRESS;Initial Catalog=Grifindo_Toys_Payroll_System;Integrated Security=True;Encrypt=False");
        string id = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();
            try
            {
                if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }
                if (txtusername.Text.Trim() != "" && txtpassword.Text.Trim() != "")
                {
                    con.Open();
                    string qry = "SELECT * FROM Users WHERE username = '" + username + "' AND password = '" + password + "'";

                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        MessageBox.Show("Login Successfull!!");
                        DashboardView dashboard = new DashboardView();
                        dashboard.Show();

                    }
                    else
                        MessageBox.Show("Incorrect Username or Password");
                }
                else
                    MessageBox.Show("Incorrect Username or Password");
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
