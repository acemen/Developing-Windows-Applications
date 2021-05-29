using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Smartsheet_
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {   //Server-LAPTOP-C3E3H3E3\\SQLEXPRESS;Database-ContactsManager;User id-dbusers;Password-password123;
            InitializeComponent();
        
            //Connect db with the system
            string connectionString = "amen4creation.mssql.somee.com";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Contacts";

                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        string FirstName = dr["FirstName"].ToString();
                        string LastName = dr["LastName"].ToString();

                        Console.WriteLine(FirstName + " " + LastName);
                    }
                    dr.Close();
                    
                }
                Console.ReadKey();
            }
        }

        private void button1_Click(object sender, EventArgs e, SqlCommand cmd, SqlConnection conn)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and Password field are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                conn.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtUsername.Text + "' , '" + txtPassword.Text + "')"; 
                cmd = new SqlCommand(register, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Password does not match, Please Re-enter", "Registartion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtPassword.Focus();
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        { //navigate login page
            new frmLogin().Show();
            this.Hide();
        }
    }
}
