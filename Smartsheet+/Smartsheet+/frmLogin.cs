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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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




        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e, object conn, SqlCommand cmd)
        {
            conn.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
            cmd = new SqlCommand(login, (SqlConnection)conn);
            SqlDataAdapter dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {

            }
        }
    }
}
