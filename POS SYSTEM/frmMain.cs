using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace POS_SYSTEM
{
    public partial class frmMain : Form
    {
        private List<string> mtFlavors, msFlavors, frFlavors;
        private List<double> mtPrice1, mtPrice2, mtPrice3;
        private List<double> msPrice1, msPrice2, msPrice3;
        private List<double> frPrice1, frPrice2, frPrice3;
        private List<Button> milkteaButtons, milkshakeButtons, frappeButtons;
        private List<Label> milkteaLabels, milkshakeLabels, frappeLabels;
        string password = "", hashedTempo = "";
        string user = frmLogin.user.ToUpper();
        string position = frmLogin.position.ToUpper();
        int loginid = frmLogin.loginid;
        int salesinvoice;
        int purchasedHeight, paperHeight;
        int selectedRowIndex;



        MySqlCommand command;
        DataTable dataTable;
        MySqlDataAdapter mySqlDataAdapter;
        MySqlDataReader reader;

        public frmMain()
        {
            InitializeComponent();

            lblUser.Text = user.ToUpper();
            lblPosition.Text = "(LoginID: " + loginid + ") " + frmLogin.position;
            initializeFlavors();
            initializeButtons();
            initializeLabels();
            newTransaction();
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE " + DatabaseConnection.UsersTable + " SET log_attempts = 0 WHERE loginid = @LoginID;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LoginID", loginid);
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            formResize();
            updateDisplay();
            if (position.ToLower() == "developer" || position.ToLower() == "admin")
            {
                btnProductsManager.Visible = true;
                btnUsersManager.Visible = true;
            }
            else
            {
                btnProductsManager.Visible = false;
                btnUsersManager.Visible = false;
            }

            lblDate.Text = DateTime.Now.ToLongDateString();// + " " + DateTime.Now.Day + ", " + DateTime.Now.Year; //30.5.2012
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss"); //result 22:11:45
            lblDate.Location = new Point(dgvOrders.Location.X, dgvOrders.Location.Y - lblDate.Height);
            lblTime.Location = new Point(dgvOrders.Location.X + dgvOrders.Width - lblTime.Width, lblDate.Location.Y);
        }

        private void initializeFlavors()
        {
            dataTable = new DataTable();

            mtFlavors = new List<string>(dataTable.Rows.Count);
            msFlavors = new List<string>(dataTable.Rows.Count);
            frFlavors = new List<string>(dataTable.Rows.Count);
            mtPrice1 = new List<double>(dataTable.Rows.Count);
            mtPrice2 = new List<double>(dataTable.Rows.Count);
            mtPrice3 = new List<double>(dataTable.Rows.Count);
            msPrice1 = new List<double>(dataTable.Rows.Count);
            msPrice2 = new List<double>(dataTable.Rows.Count);
            msPrice3 = new List<double>(dataTable.Rows.Count);
            frPrice1 = new List<double>(dataTable.Rows.Count);
            frPrice2 = new List<double>(dataTable.Rows.Count);
            frPrice3 = new List<double>(dataTable.Rows.Count);

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    mySqlDataAdapter = new MySqlDataAdapter("SELECT name, price1, price2, price3 FROM " + DatabaseConnection.ProductsTable + " WHERE isAvailable = 1 AND productType = 'milktea' ORDER BY name ASC;", connection);
                    mySqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mtFlavors.Add((string)row["name"]);
                        mtPrice1.Add(Convert.ToDouble(row["price1"]));
                        mtPrice2.Add(Convert.ToDouble(row["price2"]));
                        mtPrice3.Add(Convert.ToDouble(row["price3"]));
                    }

                    dataTable.Clear();

                    mySqlDataAdapter = new MySqlDataAdapter("SELECT name, price1, price2, price3 FROM " + DatabaseConnection.ProductsTable + " WHERE isAvailable = 1 AND productType = 'milkshake' ORDER BY name ASC;", connection);
                    mySqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        msFlavors.Add((string)row["name"]);
                        msPrice1.Add(Convert.ToDouble(row["price1"]));
                        msPrice2.Add(Convert.ToDouble(row["price2"]));
                        msPrice3.Add(Convert.ToDouble(row["price3"]));
                    }
                    dataTable.Clear();


                    mySqlDataAdapter = new MySqlDataAdapter("SELECT name, price1, price2, price3 FROM " + DatabaseConnection.ProductsTable + " WHERE isAvailable = 1 AND productType = 'frappe' ORDER BY name ASC;", connection);
                    mySqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        frFlavors.Add((string)row["name"]);
                        frPrice1.Add(Convert.ToDouble(row["price1"]));
                        frPrice2.Add(Convert.ToDouble(row["price2"]));
                        frPrice3.Add(Convert.ToDouble(row["price3"]));
                    }
                    dataTable.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }
        }

        private void initializeButtons()
        {
            milkteaButtons = new List<Button>()
            {
                btnMT1, btnMT2, btnMT3, btnMT4, btnMT5,
                btnMT6, btnMT7, btnMT8, btnMT9, btnMT10,
                btnMT11, btnMT12, btnMT13, btnMT14, btnMT15
            };

            for (int i = 0; i < milkteaButtons.Count; i++)
            {
                milkteaButtons[i].Visible = false;
            }

            for (int i = 0; i < mtFlavors.Count; i++)
            {
                milkteaButtons[i].Tag = i;
                milkteaButtons[i].Visible = true;
            }

            milkshakeButtons = new List<Button>()
            {
                btnMS1, btnMS2, btnMS3, btnMS4, btnMS5,
                btnMS6, btnMS7, btnMS8, btnMS9, btnMS10,
                btnMS11, btnMS12, btnMS13, btnMS14, btnMS15
            };

            for (int i = 0; i < milkshakeButtons.Count; i++)
            {
                milkshakeButtons[i].Visible = false;
            }

            for (int i = 0; i < msFlavors.Count; i++)
            {
                milkshakeButtons[i].Tag = i;
                milkshakeButtons[i].Visible = true;
            }

            frappeButtons = new List<Button>()
            {
                btnFR1, btnFR2, btnFR3, btnFR4, btnFR5,
                btnFR6, btnFR7, btnFR8, btnFR9, btnFR10,
                btnFR11, btnFR12, btnFR13, btnFR14, btnFR15
            };

            for (int i = 0; i < frappeButtons.Count; i++)
            {
                frappeButtons[i].Visible = false;
            }

            for (int i = 0; i < frFlavors.Count; i++)
            {
                frappeButtons[i].Tag = i;
                frappeButtons[i].Visible = true;
            }

        }

        private void initializeLabels()
        {
            milkteaLabels = new List<Label>()
            { 
                lblMT1, lblMT2, lblMT3, lblMT4, lblMT5,
                lblMT6, lblMT7, lblMT8, lblMT9, lblMT10,
                lblMT11, lblMT12, lblMT13, lblMT14, lblMT15
            };
            for (int j = 0; j < milkteaLabels.Count; j++)
            {
                milkteaLabels[j].Visible = false;
            }

            for (int j = 0; j < mtFlavors.Count; j++)
            {
                milkteaLabels[j].Text = mtFlavors[j] + "\n" + string.Format("{0:#,##0}", mtPrice1[j]) + "  /  " + string.Format("{0:#,##0}", mtPrice2[j]) + "  /  " + string.Format("{0:#,##0}", mtPrice3[j]);
                milkteaLabels[j].Visible = true;
            }

            milkshakeLabels = new List<Label>()
            {
                lblMS1, lblMS2, lblMS3, lblMS4, lblMS5,
                lblMS6, lblMS7, lblMS8, lblMS9, lblMS10,
                lblMS11, lblMS12, lblMS13, lblMS14, lblMS15
            };



            //milkshakeLabels = new List<Label>();

            //string heh = "";
            //for (int i = 0; i <= milkshakeLabels.Count; i++)
            //{
            //    heh = "lblMS" + (i + 1);
            //    Label lbl_text = this.Controls.Find(heh, true).FirstOrDefault() as Label;
            //    milkshakeLabels.Add(lbl_text);
            //}

            for (int j = 0; j < milkshakeLabels.Count; j++)
            {
                milkshakeLabels[j].Visible = false;
            }

            for (int j = 0; j < msFlavors.Count; j++)
            {
                milkshakeLabels[j].Text = msFlavors[j] + "\n" + string.Format("{0:#,##0}", msPrice1[j]) + "  /  " + string.Format("{0:#,##0}", msPrice2[j]) + "  /  " + string.Format("{0:#,##0}", msPrice3[j]);
                milkshakeLabels[j].Visible = true;
            }

            frappeLabels = new List<Label>() {  
                lblFR1, lblFR2, lblFR3, lblFR4, lblFR5,
                lblFR6, lblFR7, lblFR8, lblFR9, lblFR10,
                lblFR11, lblFR12, lblFR13, lblFR14, lblFR15
            };

            for (int j = 0; j < frappeLabels.Count; j++)
            {
                frappeLabels[j].Visible = false;
            }

            for (int j = 0; j < frFlavors.Count; j++)
            {
                frappeLabels[j].Text = frFlavors[j] + "\n" + string.Format("{0:#,##0}", frPrice1[j]) + "  /  " + string.Format("{0:#,##0}", frPrice2[j]) + "  /  " + string.Format("{0:#,##0}", frPrice3[j]);
                frappeLabels[j].Visible = true;
            }
        }
        private void buttonMT_Click(object sender, EventArgs e)
        {
            int selectedIndex = Convert.ToInt32(((Button)sender).Tag);

            frmAddProduct frmAddProduct = new frmAddProduct("Milktea", mtFlavors[selectedIndex], mtPrice1[selectedIndex], mtPrice2[selectedIndex], mtPrice3[selectedIndex]);
            frmAddProduct.ShowDialog();

            updateDisplay();
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            int selectedIndex = Convert.ToInt32(((Button)sender).Tag);
            frmAddProduct frmMilkTea = new frmAddProduct("Milkshake", msFlavors[selectedIndex], msPrice1[selectedIndex], msPrice2[selectedIndex], msPrice3[selectedIndex]);
            frmMilkTea.ShowDialog();
            updateDisplay();
        }
        private void buttonFR_Click(object sender, EventArgs e)
        {
            int selectedIndex = Convert.ToInt32(((Button)sender).Tag);
            frmAddProduct frmMilkTea = new frmAddProduct("Frappe", frFlavors[selectedIndex], frPrice1[selectedIndex], frPrice2[selectedIndex], frPrice3[selectedIndex]);
            frmMilkTea.ShowDialog();
            updateDisplay();
        }


        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword();
            frmChangePassword.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Close();
            frmLogin.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                removeOrder();
            }
            catch
            {
                MessageBox.Show("Please select an existing order");
            }
        }

        private void removeOrder()
        {
            TransactionHistory.History.RemoveAt(selectedRowIndex);
            TransactionHistory.priceTotal.RemoveAt(selectedRowIndex);
            TransactionHistory.transactionOrders.RemoveAt(selectedRowIndex);
            Transact.Total = TransactionHistory.priceTotal.Sum();
            Transact.isVATable(Transact.Total);
            updateDisplay();
        }

        private bool transactOnGoing()
        {
            if (dgvOrders.RowCount != 0)
            {
                MessageBox.Show("Unable to leave form. A transaction is on-going.");
                return true;
            }
            else
                return false;
        }

        private void buttonsSettings_Click(object sender, EventArgs e)
        {
            if (!transactOnGoing())
            {
                switch (((Button)sender).Tag.ToString())
                {
                    case "TransactionHistory":
                        frmTransactionHistory frmTransactionHistory = new frmTransactionHistory();
                        frmTransactionHistory.ShowDialog();
                        break;
                    case "UsersManager":
                        frmUsersManager frmUsersManager = new frmUsersManager();
                        frmUsersManager.ShowDialog();
                        break;
                    case "ProductsManager":
                        frmProductsManager frmProductsManager = new frmProductsManager();
                        frmProductsManager.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            else { }

            initializeFlavors();
            initializeButtons();
            initializeLabels();
            formResize();
        }

        private void txtCash_Leave(object sender, EventArgs e)
        {
            leaveCash();
        }

        private void txtCash_Enter(object sender, EventArgs e)
        {
            tabControl.Enabled = false;
            txtCash.SelectAll();
        }



        private void openDB()
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT password, MD5(tempopw) AS hashedTempo FROM " + DatabaseConnection.UsersTable + " WHERE loginid = @id;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", loginid);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        password = reader["password"].ToString();
                        hashedTempo = reader["hashedTempo"].ToString();
                    }

                    reader.Close();
                    command.Dispose();

                    if (password == hashedTempo)
                    {
                        MessageBox.Show("It seems you haven't changed your password yet. Please change your password first.", "Temporary Password Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        frmChangePassword frmChangePassword = new frmChangePassword();
                        frmChangePassword.ShowDialog();
                    }
                    else { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }
        }



        private void saveTransaction()
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MAX(sino) as si FROM " + DatabaseConnection.SalesTable + ";";
                    command = new MySqlCommand(query, connection);
                    reader = command.ExecuteReader();



                    while (reader.Read())
                    {
                        salesinvoice = Convert.ToInt32(reader["si"]);
                        if (salesinvoice != 0)
                        {
                            salesinvoice++;
                        }
                        else
                        {
                            salesinvoice = 190001;
                        }
                    }
                    reader.Close();
                    command.Dispose();


                    query = "INSERT INTO " + DatabaseConnection.SalesTable + "(sino, customer, total,vatable,vat,loginid) values(@si, @customer, @total,@vatable,@vat,@loginid);";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@si", salesinvoice);
                    command.Parameters.AddWithValue("@customer", txtCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@total", Transact.Total);
                    command.Parameters.AddWithValue("@vatable", Transact.VATable);
                    command.Parameters.AddWithValue("@vat", Transact.VatAmt);
                    command.Parameters.AddWithValue("@loginid", loginid);
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }


            print();
            newTransaction();
            updateDisplay();
        }

        private void updateDisplay()
        {
            //lblDate.Text = DateTime.Now.Date.ToShortDateString();
            //lblTime.Text = DateTime.Now.TimeOfDay.ToString();
            DataTable table = new DataTable();
            table.Columns.Add("Order", typeof(string));
            for (int order = 0; order < TransactionHistory.History.Count(); order++)
            {
                table.Rows.Add(TransactionHistory.History[order]);
            }

            foreach (DataGridViewColumn column in dgvOrders.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvOrders.DataSource = table;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtCash.Text = string.Format("{0:#,##0.00}", Transact.Cash);
            txtTotalAmtDue.Text = string.Format("{0:#,##0.00}", Transact.Total);
            txtVATable.Text = string.Format("{0:#,##0.00}", Transact.VATable);
            txtVATAmount.Text = string.Format("{0:#,##0.00}", Transact.VatAmt);



            computeChange();

            if (Transact.Change >= 0 && TransactionHistory.priceTotal.Sum() != 0)
            {
                txtChange.Text = string.Format("{0:#,##0.00}", Transact.Change); ;
                btnTransact.Enabled = true;
            }
            else if (Transact.Change >= 0 && TransactionHistory.priceTotal.Sum() != 0)
            {
                btnTransact.Enabled = false;
                txtChange.Text = "0.00";
            }
            else
            {
                btnTransact.Enabled = false;
                txtChange.Text = "0.00";
            }


        }


        public void computeChange()
        {
            try
            {
                Transact.Change = Double.Parse(txtCash.Text) - Double.Parse(txtTotalAmtDue.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void newTransaction()
        {
            openDB();
            Transact.Cash = 0;
            Transact.Total = 0;
            Transact.VATable = 0;
            Transact.VatAmt = 0;
            TransactionHistory.priceTotal.Clear();
            TransactionHistory.History.Clear();
            TransactionHistory.transactionOrders.Clear();
            txtCash.Text = "0.00";
            txtCustomer.ResetText();
        }

        private void leaveCash()
        {
            if (txtCash.TextLength > 0)
            {
                try
                {
                    Transact.Cash = Double.Parse(txtCash.Text);
                    tabControl.Enabled = true;
                }
                catch
                {
                    txtCash.Text = "0.00";
                    txtCash.Focus();
                }

                updateDisplay();
            }
            else
            {
                txtCash.Focus();
            }
        }


        #region Miscellaneous Methods

        // ----------------- Form Move Implementation  (Drag Form Body) ------------------

        private bool mouseDown;
        private Point lastLocation;
        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            formResize();
        }



        private void formResize()
        {
            lblUser.Size = new System.Drawing.Size(this.ClientRectangle.Width, lblUser.Height);
            lblPosition.Size = new System.Drawing.Size(this.ClientRectangle.Width, lblPosition.Height);
            lblUser.Location = new System.Drawing.Point(0, 0);
            lblPosition.Location = new System.Drawing.Point(0, lblUser.Height);
            tabControl.Location = new System.Drawing.Point(10, lblPosition.Location.Y + lblPosition.Height + 10);

            btnTransactionHistory.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnTransactionHistory.Width - 10, tabControl.Location.Y + 21);
            btnUsersManager.Location = new System.Drawing.Point(btnTransactionHistory.Location.X, btnTransactionHistory.Location.Y + btnTransactionHistory.Height + 10);
            btnProductsManager.Location = new System.Drawing.Point(btnTransactionHistory.Location.X, btnUsersManager.Location.Y + btnUsersManager.Height + 10);

            dgvOrders.Location = new System.Drawing.Point(btnTransactionHistory.Location.X - 20 - dgvOrders.Width, btnTransactionHistory.Location.Y);
            dgvOrders.Height = this.ClientRectangle.Height - dgvOrders.Location.Y - (10 + panel1.Height + 10 + btnRemove.Height + 10);

            btnRemove.Location = new System.Drawing.Point(dgvOrders.Location.X, dgvOrders.Location.Y + dgvOrders.Height + 10);

            panel1.Location = new System.Drawing.Point(dgvOrders.Location.X, btnRemove.Location.Y + btnRemove.Height + 10);

            tabControl.Size = new System.Drawing.Size(dgvOrders.Location.X - 20, ClientRectangle.Height - tabControl.Location.Y - 10);

            btnLogout.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnLogout.Width - 10, this.ClientRectangle.Height - btnLogout.Height - 10);
            btnChangePassword.Location = new System.Drawing.Point(btnLogout.Location.X, btnLogout.Location.Y - btnChangePassword.Height - 10);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            lblProducts1.Location = new System.Drawing.Point(tabControl.Width / 2 - (lblProducts1.Width / 2), 4);
            lblProducts2.Location = new System.Drawing.Point(tabControl.Width / 2 - (lblProducts2.Width / 2), 4);
            lblProducts3.Location = new System.Drawing.Point(tabControl.Width / 2 - (lblProducts3.Width / 2), 4);




            btnMT1.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMT1.Width / 2), lblProducts1.Location.Y + lblProducts1.Height + 20);
            btnMT2.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMT2.Width / 2), btnMT1.Location.Y);
            btnMT3.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMT3.Width / 2), btnMT1.Location.Y);
            btnMT4.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMT4.Width / 2), btnMT1.Location.Y);
            btnMT5.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMT5.Width / 2), btnMT1.Location.Y);
            btnMT6.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMT6.Width / 2), btnMT1.Location.Y + btnMT1.Height + 130);
            btnMT7.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMT7.Width / 2), btnMT6.Location.Y);
            btnMT8.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMT8.Width / 2), btnMT6.Location.Y);
            btnMT9.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMT9.Width / 2), btnMT6.Location.Y);
            btnMT10.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMT10.Width / 2), btnMT6.Location.Y);
            btnMT11.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMT11.Width / 2), btnMT6.Location.Y + btnMT6.Height + 130);
            btnMT12.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMT12.Width / 2), btnMT11.Location.Y);
            btnMT13.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMT13.Width / 2), btnMT11.Location.Y);
            btnMT14.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMT14.Width / 2), btnMT11.Location.Y);
            btnMT15.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMT15.Width / 2), btnMT11.Location.Y);

            lblMT1.Location = new System.Drawing.Point((btnMT1.Location.X + (btnMT1.Width) / 2) - lblMT1.Width / 2, btnMT1.Location.Y + btnMT1.Height + 5);
            lblMT2.Location = new System.Drawing.Point((btnMT2.Location.X + (btnMT2.Width) / 2) - lblMT2.Width / 2, lblMT1.Location.Y);
            lblMT3.Location = new System.Drawing.Point((btnMT3.Location.X + (btnMT3.Width) / 2) - lblMT3.Width / 2, lblMT1.Location.Y);
            lblMT4.Location = new System.Drawing.Point((btnMT4.Location.X + (btnMT4.Width) / 2) - lblMT4.Width / 2, lblMT1.Location.Y);
            lblMT5.Location = new System.Drawing.Point((btnMT5.Location.X + (btnMT5.Width) / 2) - lblMT5.Width / 2, lblMT1.Location.Y);
            lblMT6.Location = new System.Drawing.Point((btnMT6.Location.X + (btnMT6.Width) / 2) - lblMT6.Width / 2, btnMT6.Location.Y + btnMT6.Height + 5);
            lblMT7.Location = new System.Drawing.Point((btnMT7.Location.X + (btnMT7.Width) / 2) - lblMT7.Width / 2, lblMT6.Location.Y);
            lblMT8.Location = new System.Drawing.Point((btnMT8.Location.X + (btnMT8.Width) / 2) - lblMT8.Width / 2, lblMT6.Location.Y);
            lblMT9.Location = new System.Drawing.Point((btnMT9.Location.X + (btnMT9.Width) / 2) - lblMT9.Width / 2, lblMT6.Location.Y);
            lblMT10.Location = new System.Drawing.Point((btnMT10.Location.X + (btnMT10.Width) / 2) - lblMT10.Width / 2, lblMT6.Location.Y);
            lblMT11.Location = new System.Drawing.Point((btnMT11.Location.X + (btnMT11.Width) / 2) - lblMT11.Width / 2, btnMT11.Location.Y + btnMT11.Height + 5);
            lblMT12.Location = new System.Drawing.Point((btnMT12.Location.X + (btnMT12.Width) / 2) - lblMT12.Width / 2, lblMT11.Location.Y);
            lblMT13.Location = new System.Drawing.Point((btnMT13.Location.X + (btnMT13.Width) / 2) - lblMT13.Width / 2, lblMT11.Location.Y);
            lblMT14.Location = new System.Drawing.Point((btnMT14.Location.X + (btnMT14.Width) / 2) - lblMT14.Width / 2, lblMT11.Location.Y);
            lblMT15.Location = new System.Drawing.Point((btnMT15.Location.X + (btnMT15.Width) / 2) - lblMT15.Width / 2, lblMT11.Location.Y);




            btnMS1.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMS1.Width / 2), lblProducts2.Location.Y + lblProducts2.Height + 20);
            btnMS2.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMS2.Width / 2), btnMS1.Location.Y);
            btnMS3.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMS3.Width / 2), btnMS1.Location.Y);
            btnMS4.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMS4.Width / 2), btnMS1.Location.Y);
            btnMS5.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMS5.Width / 2), btnMS1.Location.Y);
            btnMS6.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMS6.Width / 2), btnMS1.Location.Y + btnMS1.Height + 130);
            btnMS7.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMS7.Width / 2), btnMS6.Location.Y);
            btnMS8.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMS8.Width / 2), btnMS6.Location.Y);
            btnMS9.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMS9.Width / 2), btnMS6.Location.Y);
            btnMS10.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMS10.Width / 2), btnMS6.Location.Y);
            btnMS11.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMS11.Width / 2), btnMS6.Location.Y + btnMS6.Height + 130);
            btnMS12.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMS12.Width / 2), btnMS11.Location.Y);
            btnMS13.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMS13.Width / 2), btnMS11.Location.Y);
            btnMS14.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMS14.Width / 2), btnMS11.Location.Y);
            btnMS15.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMS15.Width / 2), btnMS11.Location.Y);

            lblMS1.Location = new System.Drawing.Point((btnMS1.Location.X + (btnMS1.Width) / 2) - lblMS1.Width / 2, btnMS1.Location.Y + btnMS1.Height + 5);
            lblMS2.Location = new System.Drawing.Point((btnMS2.Location.X + (btnMS2.Width) / 2) - lblMS2.Width / 2, lblMS1.Location.Y);
            lblMS3.Location = new System.Drawing.Point((btnMS3.Location.X + (btnMS3.Width) / 2) - lblMS3.Width / 2, lblMS1.Location.Y);
            lblMS4.Location = new System.Drawing.Point((btnMS4.Location.X + (btnMS4.Width) / 2) - lblMS4.Width / 2, lblMS1.Location.Y);
            lblMS5.Location = new System.Drawing.Point((btnMS5.Location.X + (btnMS5.Width) / 2) - lblMS5.Width / 2, lblMS1.Location.Y);
            lblMS6.Location = new System.Drawing.Point((btnMS6.Location.X + (btnMS6.Width) / 2) - lblMS6.Width / 2, btnMS6.Location.Y + btnMS6.Height + 5);
            lblMS7.Location = new System.Drawing.Point((btnMS7.Location.X + (btnMS7.Width) / 2) - lblMS7.Width / 2, lblMS6.Location.Y);
            lblMS8.Location = new System.Drawing.Point((btnMS8.Location.X + (btnMS8.Width) / 2) - lblMS8.Width / 2, lblMS6.Location.Y);
            lblMS9.Location = new System.Drawing.Point((btnMS9.Location.X + (btnMS9.Width) / 2) - lblMS9.Width / 2, lblMS6.Location.Y);
            lblMS10.Location = new System.Drawing.Point((btnMS10.Location.X + (btnMS10.Width) / 2) - lblMS10.Width / 2, lblMS6.Location.Y);
            lblMS11.Location = new System.Drawing.Point((btnMS11.Location.X + (btnMS11.Width) / 2) - lblMS11.Width / 2, btnMS11.Location.Y + btnMS11.Height + 5);
            lblMS12.Location = new System.Drawing.Point((btnMS12.Location.X + (btnMS12.Width) / 2) - lblMS12.Width / 2, lblMS11.Location.Y);
            lblMS13.Location = new System.Drawing.Point((btnMS13.Location.X + (btnMS13.Width) / 2) - lblMS13.Width / 2, lblMS11.Location.Y);
            lblMS14.Location = new System.Drawing.Point((btnMS14.Location.X + (btnMS14.Width) / 2) - lblMS14.Width / 2, lblMS11.Location.Y);
            lblMS15.Location = new System.Drawing.Point((btnMS15.Location.X + (btnMS15.Width) / 2) - lblMS15.Width / 2, lblMS11.Location.Y);




            btnFR1.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnFR1.Width / 2), lblProducts3.Location.Y + lblProducts3.Height + 20);
            btnFR2.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnFR2.Width / 2), btnFR1.Location.Y);
            btnFR3.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnFR3.Width / 2), btnFR1.Location.Y);
            btnFR4.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnFR4.Width / 2), btnFR1.Location.Y);
            btnFR5.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnFR5.Width / 2), btnFR1.Location.Y);
            btnFR6.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnFR6.Width / 2), btnFR1.Location.Y + btnFR1.Height + 130);
            btnFR7.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnFR7.Width / 2), btnFR6.Location.Y);
            btnFR8.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnFR8.Width / 2), btnFR6.Location.Y);
            btnFR9.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnFR9.Width / 2), btnFR6.Location.Y);
            btnFR10.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnFR10.Width / 2), btnFR6.Location.Y);
            btnFR11.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnFR11.Width / 2), btnFR6.Location.Y + btnFR6.Height + 130);
            btnFR12.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnFR12.Width / 2), btnFR11.Location.Y);
            btnFR13.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnFR13.Width / 2), btnFR11.Location.Y);
            btnFR14.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnFR14.Width / 2), btnFR11.Location.Y);
            btnFR15.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnFR15.Width / 2), btnFR11.Location.Y);

            lblFR1.Location = new System.Drawing.Point((btnFR1.Location.X + (btnFR1.Width) / 2) - lblFR1.Width / 2, btnFR1.Location.Y + btnFR1.Height + 5);
            lblFR2.Location = new System.Drawing.Point((btnFR2.Location.X + (btnFR2.Width) / 2) - lblFR2.Width / 2, lblFR1.Location.Y);
            lblFR3.Location = new System.Drawing.Point((btnFR3.Location.X + (btnFR3.Width) / 2) - lblFR3.Width / 2, lblFR1.Location.Y);
            lblFR4.Location = new System.Drawing.Point((btnFR4.Location.X + (btnFR4.Width) / 2) - lblFR4.Width / 2, lblFR1.Location.Y);
            lblFR5.Location = new System.Drawing.Point((btnFR5.Location.X + (btnFR5.Width) / 2) - lblFR5.Width / 2, lblFR1.Location.Y);
            lblFR6.Location = new System.Drawing.Point((btnFR6.Location.X + (btnFR6.Width) / 2) - lblFR6.Width / 2, btnFR6.Location.Y + btnFR6.Height + 5);
            lblFR7.Location = new System.Drawing.Point((btnFR7.Location.X + (btnFR7.Width) / 2) - lblFR7.Width / 2, lblFR6.Location.Y);
            lblFR8.Location = new System.Drawing.Point((btnFR8.Location.X + (btnFR8.Width) / 2) - lblFR8.Width / 2, lblFR6.Location.Y);
            lblFR9.Location = new System.Drawing.Point((btnFR9.Location.X + (btnFR9.Width) / 2) - lblFR9.Width / 2, lblFR6.Location.Y);
            lblFR10.Location = new System.Drawing.Point((btnFR10.Location.X + (btnFR10.Width) / 2) - lblFR10.Width / 2, lblFR6.Location.Y);
            lblFR11.Location = new System.Drawing.Point((btnFR11.Location.X + (btnFR11.Width) / 2) - lblFR11.Width / 2, btnFR11.Location.Y + btnFR11.Height + 5);
            lblFR12.Location = new System.Drawing.Point((btnFR12.Location.X + (btnFR12.Width) / 2) - lblFR12.Width / 2, lblFR11.Location.Y);
            lblFR13.Location = new System.Drawing.Point((btnFR13.Location.X + (btnFR13.Width) / 2) - lblFR13.Width / 2, lblFR11.Location.Y);
            lblFR14.Location = new System.Drawing.Point((btnFR14.Location.X + (btnFR14.Width) / 2) - lblFR14.Width / 2, lblFR11.Location.Y);
            lblFR15.Location = new System.Drawing.Point((btnFR15.Location.X + (btnFR15.Width) / 2) - lblFR15.Width / 2, lblFR11.Location.Y);
        }
        #endregion

        private void btnTransact_Click(object sender, EventArgs e)
        {
            saveTransaction();
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar);
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                leaveCash();
            }
        }

        private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text.Trim(), @"\s+", " ");
        }

        private void txtCash_Click(object sender, EventArgs e)
        {
            txtCash.SelectAll();
        }

        public void print()
        {
            paperHeight = 70 + (TransactionHistory.transactionOrders.Count() * 45) + 210;
            PrinterSettings ps = new PrinterSettings();
            PaperSize psize = new PaperSize("Custom", 250, paperHeight);
            ps.DefaultPageSettings.PaperSize = psize;
            printPreview.Document = printDocument;
            printPreview.Document.DefaultPageSettings.PaperSize = psize;
            printPreview.ShowDialog();
        }


        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font f1 = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Pixel);
            Font f2 = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Pixel);
            Font f3 = new Font("Arial", 8, FontStyle.Italic, GraphicsUnit.Pixel);
            Bitmap bmp = Properties.Resources.HTlogob;
            Image img = bmp;
            //if left use this > e.Graphics.DrawString("Purchased : ", f1, Brushes.Black, new RectangleF(329, 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            // if center use this>  e.Graphics.DrawString("Happy Thirsday", f2, Brushes.Black, new RectangleF(0, 10, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });

            //e.Graphics.DrawString(img, img.Size); TransactionHistory.History.Count();
            e.Graphics.DrawImage(img, new Rectangle(125 - 51, 3, 102, 36));
            //e.Graphics.DrawString("Happy Thirstday", f2, Brushes.Black, new RectangleF(0, 10, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(" ", f3, Brushes.Black, new RectangleF(0, 30, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("1423 JP Laurel St", f1, Brushes.Black, new RectangleF(0, 40, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("Brgy 639 zone 065 San Miguel Manila", f1, Brushes.Black, new RectangleF(0, 50, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("Contact Number: (+63) 917 920 3638", f1, Brushes.Black, new RectangleF(0, 60, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SI # " + salesinvoice, f1, Brushes.Black, new RectangleF(0, 70, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });

            if (txtCustomer.Text == "")
            {
                e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            }
            else
            {
                e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("  Customer Name : " + txtCustomer.Text, f1, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            }

            purchasedHeight = 90;

            string miscNotes = "";
            for (int i = 0; i < TransactionHistory.transactionOrders.Count(); i++)
            {
                e.Graphics.DrawString(string.Format("{0:#,##0}", TransactionHistory.transactionOrders[i].Quantity), f1, Brushes.Black, new RectangleF(20, purchasedHeight + 10, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].ProductName), f1, Brushes.Black, new RectangleF(40, purchasedHeight + 10, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].ProductPrice), f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 10, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });



                miscNotes = TransactionHistory.transactionOrders[i].Addons + " " + TransactionHistory.transactionOrders[i].Notes;
                int multipler = (miscNotes.Length / 35) + 1;
                e.Graphics.DrawString(TransactionHistory.transactionOrders[i].Size + " (Sugar: " + TransactionHistory.transactionOrders[i].SugarLevel + ")", f3, Brushes.Black, new RectangleF(50, purchasedHeight + 20, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].SizePrice), f3, Brushes.Black, new RectangleF(-40, purchasedHeight + 20, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });
                //e.Graphics.DrawString("Qty:", f3, Brushes.Black, new RectangleF(60, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
                //e.Graphics.DrawString(TransactionHistory.transactionOrders[i].Quantity.ToString(), f3, Brushes.Black, new RectangleF(-70, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });

                if (TransactionHistory.transactionOrders[i].Addons != null)
                {
                    e.Graphics.DrawString("Addon Price:", f3, Brushes.Black, new RectangleF(50, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString(string.Format("{0:#,##0.00}", TransactionHistory.transactionOrders[i].SinkerPrice), f3, Brushes.Black, new RectangleF(-40, purchasedHeight + 30, e.PageBounds.Width, 10), new StringFormat() { Alignment = StringAlignment.Far });
                
                }
                e.Graphics.DrawString(miscNotes, f3, Brushes.Black, new RectangleF(50, purchasedHeight + 40, 160, (20 + 10*multipler)), new StringFormat() { Alignment = StringAlignment.Near });

                purchasedHeight += 35 + (10 * multipler);
            }

            //e.Graphics.DrawString(orders, f1, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, purchasedHeight), new StringFormat() { Alignment = StringAlignment.Center });
            //e.Graphics.DrawString(orders, f1, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, purchasedHeight), new StringFormat() { Alignment = StringAlignment.Center });

            e.Graphics.DrawString(" * * * * *  NOTHING FOLLOWS  * * * * * ", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 13, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            purchasedHeight += 10; 
            e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 20, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("Total :", f2, Brushes.Black, new RectangleF(20, purchasedHeight + 30, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("VATable :", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 40, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("VATAmount :", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 50, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Cash :", f2, Brushes.Black, new RectangleF(20, purchasedHeight + 60, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Change :", f2, Brushes.Black, new RectangleF(20, purchasedHeight + 70, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Processed By:", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Date Time:", f1, Brushes.Black, new RectangleF(20, purchasedHeight + 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(txtTotalAmtDue.Text, f2, Brushes.Black, new RectangleF(-20, purchasedHeight + 30, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString(txtVATable.Text, f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 40, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString(txtVATAmount.Text, f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 50, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString(txtCash.Text, f2, Brushes.Black, new RectangleF(-20, purchasedHeight + 60, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString(txtChange.Text, f2, Brushes.Black, new RectangleF(-20, purchasedHeight + 70, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString(loginid.ToString(), f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 80, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString(DateTime.Now.ToString(), f1, Brushes.Black, new RectangleF(-20, purchasedHeight + 90, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 100, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SURVEY", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 110, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("----------------------------------------------------------------------", f2, Brushes.Black, new RectangleF(0, purchasedHeight + 120, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SERVICE ✰  ✰  ✰  ✰  ✰", f1, Brushes.Black, new RectangleF(0, purchasedHeight + 130, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("PRODUCT ✰  ✰  ✰  ✰  ✰", f1, Brushes.Black, new RectangleF(0, purchasedHeight + 140, e.PageBounds.Width, 25), new StringFormat() { Alignment = StringAlignment.Center });
            //paperHeight = purchasedHeight + 190;
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();// + " " + DateTime.Now.Day + ", " + DateTime.Now.Year; //30.5.2012
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss"); //result 22:11:45
            lblDate.Location = new Point(dgvOrders.Location.X, dgvOrders.Location.Y - lblDate.Height);
            lblTime.Location = new Point(dgvOrders.Location.X + dgvOrders.Width - lblTime.Width, lblDate.Location.Y);
        }

        private void lblCash_Click(object sender, EventArgs e)
        {
            frmCash frmCash = new frmCash();
            frmCash.ShowDialog();
            updateDisplay();
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.C))
            {
                frmChangePassword frmChangePassword = new frmChangePassword();
                frmChangePassword.ShowDialog();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.T))
            {
                frmTransactionHistory frmTransactionHistory = new frmTransactionHistory();
                frmTransactionHistory.ShowDialog();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.U))
            {
                frmUsersManager frmUsersManager = new frmUsersManager();
                frmUsersManager.ShowDialog();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.P))
            {
                frmProductsManager frmProductsManager = new frmProductsManager();
                frmProductsManager.ShowDialog();
                return true;
            }
            if (keyData == (Keys.Delete))
            {
                try
                {
                    removeOrder();
                }
                catch
                {
                    MessageBox.Show("Please select an existing order");
                }
                return true;
            }
            if (keyData == (Keys.ControlKey | Keys.Alt | Keys.Enter))
            {
                saveTransaction();
                return true;
            }


            // CLOSING
            if (keyData == (Keys.F10))
            {
                frmLogin frmLogin = new frmLogin();
                this.Close();
                frmLogin.Show();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.F12))
            {
                System.Windows.Forms.Application.ExitThread();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            frmDevelopers frmDevelopers = new frmDevelopers();
            frmDevelopers.ShowDialog();
        }


    }
}
