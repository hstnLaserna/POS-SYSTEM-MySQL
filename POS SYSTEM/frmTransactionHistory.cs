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
        string from, to, groupBy = "day";


        public frmTransactionHistory()
        {
            InitializeComponent();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            fetchTransaction();
        }

        private void fetchTransaction()
        {
            from = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
            to = dtpTo.Value.Year.ToString() + "-" + dtpTo.Value.Month.ToString() + "-" + dtpTo.Value.Day.ToString();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT sino 'SI Number', Customer 'Customer', vatable 'VATable', vat 'VAT', total 'Total', userid 'Cashier ID', transdate 'Transaction Date' FROM " + DatabaseConnection.SalesTable + " WHERE date(transdate) BETWEEN '" + from + "' AND '" + to + "';";
                    mySqlDataAdapter = new MySqlDataAdapter(query, connection);
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
            chartSales.Series["Sales"].XValueMember = groupBy;
            chartSales.Series["Sales"].YValueMembers = "Total";
            chartSales.DataBind();
        }

        private void frmTransactionHistory_Load(object sender, EventArgs e)
        {

            formResize();
            //chartSales.DataSource = GetData();
            //chartSales.Series["SalesByDay"].XValueMember = groupBy;
            //chartSales.Series["SalesByDay"].YValueMembers = "Total";
        }

        private object GetData(string fetchFrom, string fetchTo)
        {
            DataTable dtData = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT sum(total) AS 'Total', " + groupBy + "(transdate) AS '" + groupBy + "' FROM " + DatabaseConnection.SalesTable + " WHERE date(transdate) BETWEEN '" + fetchFrom + "' AND '" + fetchTo + "' GROUP BY " + groupBy + "; ";
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formResize()
        {
            dgvTransactionHistory.Size = new System.Drawing.Size((ClientSize.Width * 2 / 3) - 50, ClientSize.Height - 130);
            chartSales.Size = new System.Drawing.Size((ClientSize.Width * 1 / 3), dgvTransactionHistory.Height / 2);
            dgvTransactionHistory.Location = new System.Drawing.Point(20, 80);
            chartSales.Location = new System.Drawing.Point(dgvTransactionHistory.Location.X + dgvTransactionHistory.Width + 10, dgvTransactionHistory.Location.Y + (dgvTransactionHistory.Height / 2));
            panel1.Location = new System.Drawing.Point(chartSales.Location.X, dgvTransactionHistory.Location.Y);
            panel1.Size = new System.Drawing.Size((ClientSize.Width * 1 / 3), panel1.Height);
            panel2.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y + panel1.Height + 10);
            btnFetch.Size = new System.Drawing.Size(panel1.Width - btnFetch.Location.X - 5, panel1.Height - 8);
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
        }

        private void btnDisplayBy_Click(object sender, EventArgs e)
        {
            groupBy = ((Button)sender).Tag.ToString();
            btnDay.Enabled = true;
            btnMonth.Enabled = true;
            btnYear.Enabled = true;
            ((Button)sender).Enabled = false;

            fetchTransaction();
        }

        private void dgvTransactionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvTransactionHistory.Rows[e.RowIndex];
                // sino 'SI Number', Customer 'Customer', vatable 'VATable', vat 'VAT', total 'Total', userid 'Cashier ID', transdate 'Transaction Date'
                //populate the textbox from specific value of the coordinates of column and row.
                txtSINumber.Text = row.Cells[0].Value.ToString();
                txtCustomer.Text = row.Cells[1].Value.ToString();
                txtVATable.Text = row.Cells[2].Value.ToString();
                txtVAT.Text = row.Cells[3].Value.ToString();
                txtTotal.Text = row.Cells[4].Value.ToString();
                txtCashierID.Text = row.Cells[5].Value.ToString();
                txtDateTime.Text = row.Cells[6].Value.ToString();
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            //double tempo = Convert.ToDouble(((TextBox)sender).Text);
            //((TextBox)sender).Text = tempo.ToString("F");
        }






        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.D))
            {
                groupBy = btnDay.Tag.ToString();
                btnDay.Enabled = false;
                btnMonth.Enabled = true;
                btnYear.Enabled = true;
                fetchTransaction();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.M))
            {
                groupBy = btnMonth.Tag.ToString();
                btnDay.Enabled = true;
                btnMonth.Enabled = false;
                btnYear.Enabled = true;
                fetchTransaction();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.Y))
            {
                groupBy = btnYear.Tag.ToString();
                btnDay.Enabled = true;
                btnMonth.Enabled = true;
                btnYear.Enabled = false;
                fetchTransaction();
                return true;
            }


            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            if (keyData == (Keys.RControlKey | Keys.F12))
            {
                Application.Exit();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
