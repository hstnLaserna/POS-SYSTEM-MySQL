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

        private void btnFetch_Click(object sender, EventArgs e)
        {
            fetchTransaction();
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
            chartSales.Series["Sales"].ShadowColor = Color.LightSlateGray;
            chartSales.Series["Sales"].ShadowOffset = 2;
            chartSales.Series["Sales"].IsValueShownAsLabel = true;
            chartSales.Series["Sales"].LabelFormat = "{0:#,##0.00}";
            chartSales.Series["Sales"].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartSales.Series["Sales"].LabelForeColor = Color.SaddleBrown;
            chartSales.Series["Sales"].LabelBackColor = Color.White;
            chartSales.ChartAreas[0].AxisX.Title = "Period by " + groupBy;
            chartSales.ChartAreas[0].AxisY.Title = "Sales";
            //chartSales.Series[]
            chartSales.DataBind();
            }
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
                    //textBox1.Text = query;
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
            chartSales.Location = new System.Drawing.Point(10, 80);
            chartSales.Size = new System.Drawing.Size((ClientSize.Width - panel1.Width - 25), ClientSize.Height - 130);

            dgvTransactionHistory.Size = chartSales.Size;
            dgvTransactionHistory.Location = chartSales.Location;

            panel1.Location = new System.Drawing.Point(chartSales.Location.X + chartSales.Width + 5, dgvTransactionHistory.Location.Y);
            //panel1.Size = new System.Drawing.Size((ClientSize.Width * 6 / 11), panel1.Height);
            //panel2.Size = new System.Drawing.Size((ClientSize.Width * 6 / 11), panel2.Height);
            //panel2.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y + panel1.Height + 10);
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
        }

        private void btnDisplayBy_Click(object sender, EventArgs e)
        {
            groupBy = ((Button)sender).Tag.ToString();

            fetchTransaction();
        }

        private void dgvTransactionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    //gets a collection that contains all the rows
            //    DataGridViewRow row = this.dgvTransactionHistory.Rows[e.RowIndex];
            //    // sino 'SI Number', Customer 'Customer', vatable 'VATable', vat 'VAT', total 'Total', userid 'Cashier ID', transdate 'Transaction Date'
            //    //populate the textbox from specific value of the coordinates of column and row.
            //    txtSINumber.Text = row.Cells[0].Value.ToString();
            //    txtCustomer.Text = row.Cells[1].Value.ToString();
            //    txtVATable.Text = row.Cells[2].Value.ToString();
            //    txtVAT.Text = row.Cells[3].Value.ToString();
            //    txtTotal.Text = row.Cells[4].Value.ToString();
            //    txtCashierID.Text = row.Cells[5].Value.ToString();
            //    txtDateTime.Text = row.Cells[6].Value.ToString();
            //}
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
                chartSales.Size = new System.Drawing.Size((ClientSize.Width - panel1.Width - 25), ClientSize.Height - 130);
                dgvTransactionHistory.Size = chartSales.Size;
                
            }
            else
            {
                btnViewHistory.Text = "Hide Transactions";
                chartSales.Size = new System.Drawing.Size((ClientSize.Width - panel1.Width - 25), (ClientSize.Height - 130) / 2);
                dgvTransactionHistory.Size = chartSales.Size;
                dgvTransactionHistory.Location = new System.Drawing.Point(chartSales.Location.X, chartSales.Location.Y + chartSales.Height + 10);
                dgvTransactionHistory.Visible = true;
            }
        }


        public void print()
        {
            PrinterSettings ps = new PrinterSettings();

            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeLetter = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.Letter); // setting paper size to A4 size
            
            ps.DefaultPageSettings.PaperSize = sizeLetter;
            printPreview.Document = printDocument;
            printPreview.Document.DefaultPageSettings.PaperSize = sizeLetter;
            printPreview.ShowDialog();
        }


        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
        //    Graphics graphics = e.Graphics;
        //    Font f1 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Pixel);
        //    Font f2 = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Pixel);
        //    Font f3 = new Font("Arial", 8, FontStyle.Italic, GraphicsUnit.Pixel);
        //    Bitmap bmp = Properties.Resources.HTlogob;
        //    Image img = bmp;
        //    //if left use this > e.Graphics.DrawString("Purchased : ", f1, Brushes.Black, new RectangleF(329, 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    // if center use this>  e.Graphics.DrawString("Happy Thirsday", f2, Brushes.Black, new RectangleF(0, 10, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });

        //    //e.Graphics.DrawString(img, img.Size); TransactionHistory.History.Count();
        //    e.Graphics.DrawImage(img, new Rectangle(125 - 51, 3, 102, 36));
        //    //e.Graphics.DrawString("Happy Thirstday", f2, Brushes.Black, new RectangleF(0, 10, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString(" ", f3, Brushes.Black, new RectangleF(0, 30, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("1423 JP Laurel St", f1, Brushes.Black, new RectangleF(0, 40, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("Brgy 639 zone 065 San Miguel Manila", f1, Brushes.Black, new RectangleF(0, 50, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("Contact Number: (+63) 917 920 3638", f1, Brushes.Black, new RectangleF(0, 60, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("SI # " + salesinvoice, f1, Brushes.Black, new RectangleF(0, 70, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });

        //    if (txtCustomer.Text == "")
        //    {
        //        e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    }
        //    else
        //    {
        //        e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //        e.Graphics.DrawString("  Customer Name : " + txtCustomer.Text, f1, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    }

        //    purchasedHeight = 90;

        //    for (int i = 0; i < TransactionHistory.transactionOrders.Count(); i++)
        //    {
        //        e.Graphics.DrawString(string.Format("{0:#,##0}", TransactionHistory.transactionOrders[i].Quantity), f1, Brushes.Black, new RectangleF(20, purchasedHeight + 10, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
        //        e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].ProductName), f1, Brushes.Black, new RectangleF(40, purchasedHeight + 10, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
        //        e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].ProductPrice), f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 10, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });




        //        e.Graphics.DrawString(TransactionHistory.transactionOrders[i].Size, f3, Brushes.Black, new RectangleF(50, purchasedHeight + 20, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
        //        e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].SizePrice), f3, Brushes.Black, new RectangleF(-40, purchasedHeight + 20, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });
        //        //e.Graphics.DrawString("Qty:", f3, Brushes.Black, new RectangleF(60, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
        //        //e.Graphics.DrawString(TransactionHistory.transactionOrders[i].Quantity.ToString(), f3, Brushes.Black, new RectangleF(-70, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });
        //        e.Graphics.DrawString("Addon Price:", f3, Brushes.Black, new RectangleF(50, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
        //        e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].SinkerPrice), f3, Brushes.Black, new RectangleF(-40, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });
        //        e.Graphics.DrawString(TransactionHistory.transactionOrders[i].SugarLevel + " " + TransactionHistory.transactionOrders[i].Addons + " " + TransactionHistory.transactionOrders[i].Notes, f3, Brushes.Black, new RectangleF(50, purchasedHeight + 40, 160, 40), new StringFormat() { Alignment = StringAlignment.Near });

        //        purchasedHeight += 45;
        //    }

        //    //e.Graphics.DrawString(orders, f1, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, purchasedHeight), new StringFormat() { Alignment = StringAlignment.Center });
        //    //e.Graphics.DrawString(orders, f1, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, purchasedHeight), new StringFormat() { Alignment = StringAlignment.Center });

        //    e.Graphics.DrawString(" * * * * *  NOTHING FOLLOWS  * * * * * ", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 13, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    purchasedHeight += 10;
        //    e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 20, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("Total :", f2, Brushes.Black, new RectangleF(20, purchasedHeight + 30, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString("VATable :", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 40, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString("VATAmount :", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 50, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString("Cash :", f2, Brushes.Black, new RectangleF(20, purchasedHeight + 60, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString("Change :", f2, Brushes.Black, new RectangleF(20, purchasedHeight + 70, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString("Processed By:", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString("Date Time:", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
        //    e.Graphics.DrawString(txtTotalAmtDue.Text, f2, Brushes.Black, new RectangleF(-20, purchasedHeight + 30, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString(txtVATable.Text, f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 40, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString(txtVATAmount.Text, f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 50, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString(txtCash.Text, f2, Brushes.Black, new RectangleF(-20, purchasedHeight + 60, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString(txtChange.Text, f2, Brushes.Black, new RectangleF(-20, purchasedHeight + 70, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString(loginid.ToString(), f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString(DateTime.Now.ToString(), f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
        //    e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 100, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("SURVEY", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 110, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 120, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("SERVICE ✰  ✰  ✰  ✰  ✰", f1, Brushes.Black, new RectangleF(0, purchasedHeight + 130, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    e.Graphics.DrawString("PRODUCT ✰  ✰  ✰  ✰  ✰", f1, Brushes.Black, new RectangleF(0, purchasedHeight + 140, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
        //    //paperHeight = purchasedHeight + 190;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
        }

    }
}
