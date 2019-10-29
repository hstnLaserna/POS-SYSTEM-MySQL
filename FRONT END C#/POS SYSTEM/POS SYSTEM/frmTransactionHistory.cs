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
                    string query = @"SELECT * FROM " + DatabaseConnection.SalesTable + " WHERE date(transdate) BETWEEN '" + from + "' AND '" + to + "';";
                    mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                    txt.Text = query;
                    DataTable dt = new DataTable();
                    mySqlDataAdapter.Fill(dt);
                    dgvTransactionHistory.DataSource = dt;
                    dgvTransactionHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }

            chartSales.DataSource = GetData(from, to);
            chartSales.Update();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
            label4.Text = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
        }

        private void frmTransactionHistory_Load(object sender, EventArgs e)
        {
            formResize();
            chartSales.DataSource = GetData();
            chartSales.Series["SalesByDay"].XValueMember = "Days";
            chartSales.Series["SalesByDay"].YValueMembers = "Total";
        }

        private object GetData(string fetchFrom, string fetchTo)
        {
            DataTable dtData = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT sum(total) AS 'Total', day(transdate) AS 'Days' FROM " + DatabaseConnection.SalesTable + " WHERE date(transdate) BETWEEN '" + fetchFrom + "' AND '" + fetchTo + "' GROUP BY Days; ";
                    command = new MySqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    dtData.Load(reader);
                    txt.Text = query;
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

        private object GetData()
        {
            DataTable dtData = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT sum(total) AS 'Total', day(transdate) AS 'Days' FROM " + DatabaseConnection.SalesTable + " GROUP BY Days; ";
                    command = new MySqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    dtData.Load(reader);
                    txt.Text = query;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formResize()
        {
            dgvTransactionHistory.Size = new System.Drawing.Size((ClientSize.Width / 2) - 110, ClientSize.Height - 130);
            chartSales.Size = new System.Drawing.Size((ClientSize.Width / 2) - 10, dgvTransactionHistory.Height / 2);
            dgvTransactionHistory.Location = new System.Drawing.Point(20, 80);
            chartSales.Location = new System.Drawing.Point(dgvTransactionHistory.Location.X + dgvTransactionHistory.Width + 10, dgvTransactionHistory.Location.Y + (dgvTransactionHistory.Height / 2));
            panel1.Location = new System.Drawing.Point(chartSales.Location.X + dgvTransactionHistory.Width - panel1.Width, dgvTransactionHistory.Location.Y - panel1.Height - 5);
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
        }
    }
}
