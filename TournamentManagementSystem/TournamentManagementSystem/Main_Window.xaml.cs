using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TournamentManagementSystem
{
    /// <summary>
    /// Interaction logic for Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        public Main_Window()
        {
            InitializeComponent();
            FillDataGrid();
        }
        private void FillDataGrid()

        {

            string ConString = "workstation id = IBTCOLLEGE.mssql.somee.com; packet size = 4096; user id = ibtcollege_SQLLogin_1; pwd = dd69kxzi3m; data source = IBTCOLLEGE.mssql.somee.com; persist security info = False; initial catalog = IBTCOLLEGE";

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT * FROM Teams";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Teams");

                sda.Fill(dt);

                TeamGrid.ItemsSource = dt.DefaultView;

            }
           

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string ConString = "workstation id = IBTCOLLEGE.mssql.somee.com; packet size = 4096; user id = ibtcollege_SQLLogin_1; pwd = dd69kxzi3m; data source = IBTCOLLEGE.mssql.somee.com; persist security info = False; initial catalog = IBTCOLLEGE";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from Teams", con);
            SqlCommandBuilder build = new SqlCommandBuilder(adp);
            DataTable ds = ((DataView)TeamGrid.ItemsSource).ToTable();
            //adp.Update(ds);
            using (var bulkCopy = new SqlBulkCopy(ConString, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in ds.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = "Teams";
                bulkCopy.WriteToServer(ds);
            }
            con.Close();
        }
    }
}
