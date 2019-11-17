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
using System.Drawing.Printing;

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

        private void fetchTransaction()
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;
                MessageBox.Show("'Date From' must be earlier than 'Date To'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
            from = dtpFrom.Value.Year.ToString() + "-" + dtpFrom.Value.Month.ToString() + "-" + dtpFrom.Value.Day.ToString();
            to = dtpTo.Value.Year.ToString() + "-" + dtpTo.Value.Month.ToString() + "-" + dtpTo.Value.Day.ToString();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT sino 'SI Number', Customer 'Customer', vatable 'VATable', vat 'VAT', total 'Total', loginid 'Cashier ID', transdate 'Transaction Date' FROM " + DatabaseConnection.SalesTable + " WHERE date(transdate) BETWEEN '" + from + "' AND '" + to + "';";
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
            chartSales.Series["Sales"].ShadowColor = Color.LightSlateGray;
            chartSales.Series["Sales"].ShadowOffset = 2;
            chartSales.Series["Sales"].IsValueShownAsLabel = true;
            chartSales.Series["Sales"].LabelFormat = "{0:#,##0.00}";
            chartSales.Series["Sales"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartSales.Series["Sales"].LabelForeColor = Color.SaddleBrown;
            chartSales.Series["Sales"].LabelBackColor = Color.White;
            chartSales.ChartAreas[0].AxisX.Title = "Period by " + groupBy;
            chartSales.ChartAreas[0].AxisY.Title = "Sales";
            chartSales.DataBind();
            }
        }

        private void frmTransactionHistory_Load(object sender, EventArgs e)
        {
            formResize();
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
            chartSales.Size = new System.Drawing.Size((ClientSize.Width - panel1.Width - 50), ClientSize.Height - 130);

            dgvTransactionHistory.Size = chartSales.Size;
            dgvTransactionHistory.Location = chartSales.Location;

            panel1.Location = new System.Drawing.Point(chartSales.Location.X + chartSales.Width + 5, dgvTransactionHistory.Location.Y);
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
        }

        private void btnDisplayBy_Click(object sender, EventArgs e)
        {
            groupBy = ((Button)sender).Tag.ToString();

            fetchTransaction();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.D))
            {
                groupBy = btnDay.Tag.ToString();
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


        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            //print();
            if (dgvTransactionHistory.Visible)
            {
                btnViewHistory.Text = "Display Transactions";
                dgvTransactionHistory.Visible = false;
                chartSales.Size = new System.Drawing.Size((ClientSize.Width - panel1.Width - 50), ClientSize.Height - 130);
                dgvTransactionHistory.Size = chartSales.Size;
                
            }
            else
            {
                btnViewHistory.Text = "Hide Transactions";
                chartSales.Size = new System.Drawing.Size((ClientSize.Width - panel1.Width - 50), (ClientSize.Height - 130) / 2);
                dgvTransactionHistory.Size = chartSales.Size;
                dgvTransactionHistory.Location = new System.Drawing.Point(chartSales.Location.X, chartSales.Location.Y + chartSales.Height + 10);
                dgvTransactionHistory.Visible = true;
            }
        }
    }
}
