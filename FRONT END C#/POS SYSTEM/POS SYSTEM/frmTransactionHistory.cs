using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS_SYSTEM
{
    public partial class frmTransactionHistory : Form
    {
        MySqlDataReader reader;
        MySqlCommand command;
        MySqlDataAdapter mySqlDataAdapter;


        public frmTransactionHistory()
        {
            InitializeComponent();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            string from = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
            string to = dtpTo.Value.Year.ToString() + "-" + dtpTo.Value.Month.ToString() + "-" + dtpTo.Value.Day.ToString();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = @"select * from tblsales where date(transdate) between '" + from + "' and '" + to + "';";
                    mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    mySqlDataAdapter.Fill(dt);
                    dgvTransactionHistory.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }


        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
            label4.Text = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
            //dtpTo.Format = "yyyy-mm-dd";
        }

        private void frmTransactionHistory_Load(object sender, EventArgs e)
        {
            chartSales.DataSource = GetData();
            chartSales.Series["SalesByDay"].XValueMember = "Days";
            chartSales.Series["SalesByDay"].YValueMembers = "Total";
        }

        private object GetData()
        {
            DataTable dtData = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "select sum(total) AS 'Total', day(transdate) as 'Days' from tblsales group by Days; ";
                    command = new MySqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    dtData.Load(reader);
                    
                    reader.Close();
                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                connection.Close();
            }

            return dtData;
        }
    }
}
