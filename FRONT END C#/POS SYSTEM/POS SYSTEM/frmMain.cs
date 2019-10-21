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

namespace POS_SYSTEM
{
    public partial class frmMain : Form
    {
        private List<Button> milkteaButtons, milkshakeButtons, frappeButtons;
        private List<Label> milkteaLabels, milkshakeLabels, frappeLabels;
        private List<string> mtFlavors, msFlavors, frFlavors;
        private List<double> mtPrice1, mtPrice2, mtPrice3;
        private List<double> msPrice1, msPrice2, msPrice3;
        private List<double> frPrice1, frPrice2, frPrice3;
        string password = "x", hashedTempo = "z";
        string user = frmLogin.user.ToUpper();
        string position = frmLogin.position.ToUpperInvariant();
        int loginid = frmLogin.loginid;
        int salesinvoice;
        DataTable dataTable;
        MySqlDataAdapter mySqlDataAdapter;
        MySqlDataReader reader;
        MySqlCommand command;


        string MilkTeaName;
        MilkTea mt = new MilkTea();
        int order;

        public frmMain()
        {
            InitializeComponent();

            lblUser.Text = user.ToUpper();
            lblPosition.Text = frmLogin.position;
            initializeFlavors();
            initializeButtons();
            initializeLabels();
            newTransaction();
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
                connection.Open();
                try
                {
                    mySqlDataAdapter = new MySqlDataAdapter("SELECT name, price1, price2, price3 FROM " + DatabaseConnection.ProductsTable + " WHERE isAvailable = 1 AND productType = 'milktea';", connection);
                    mySqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mtFlavors.Add((string)row["name"]);
                        mtPrice1.Add(Convert.ToDouble(row["price1"]));
                        mtPrice2.Add(Convert.ToDouble(row["price2"]));
                        mtPrice3.Add(Convert.ToDouble(row["price3"]));
                    }

                    dataTable.Clear();

                    mySqlDataAdapter = new MySqlDataAdapter("SELECT name, price1, price2, price3 FROM " + DatabaseConnection.ProductsTable + " WHERE isAvailable = 1 AND productType = 'milkshake';", connection);
                    mySqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        msFlavors.Add((string)row["name"]);
                        msPrice1.Add(Convert.ToDouble(row["price1"]));
                        msPrice2.Add(Convert.ToDouble(row["price2"]));
                        msPrice3.Add(Convert.ToDouble(row["price3"]));
                    }
                    dataTable.Clear();


                    mySqlDataAdapter = new MySqlDataAdapter("SELECT name, price1, price2, price3 FROM " + DatabaseConnection.ProductsTable + " WHERE isAvailable = 1 AND productType = 'frappe';", connection);
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
            milkteaButtons = new List<Button>();
            milkteaButtons.Add(btnMT1);
            milkteaButtons.Add(btnMT2);
            milkteaButtons.Add(btnMT3);
            milkteaButtons.Add(btnMT4);
            milkteaButtons.Add(btnMT5);
            milkteaButtons.Add(btnMT6);
            milkteaButtons.Add(btnMT7);
            milkteaButtons.Add(btnMT8);
            milkteaButtons.Add(btnMT9);
            milkteaButtons.Add(btnMT10);
            milkteaButtons.Add(btnMT11);
            milkteaButtons.Add(btnMT12);
            milkteaButtons.Add(btnMT13);
            milkteaButtons.Add(btnMT14);
            milkteaButtons.Add(btnMT15);
            for (int i = 0; i < milkteaButtons.Count; i++)
            {
                milkteaButtons[i].Visible = false;
            }

            for (int i = 0; i < mtFlavors.Count; i++)
            {
                milkteaButtons[i].Tag = i;
                milkteaButtons[i].Visible = true;
            }

            milkshakeButtons = new List<Button>();
            milkshakeButtons.Add(btnMS1);
            milkshakeButtons.Add(btnMS2);
            milkshakeButtons.Add(btnMS3);
            milkshakeButtons.Add(btnMS4);
            milkshakeButtons.Add(btnMS5);
            milkshakeButtons.Add(btnMS6);
            milkshakeButtons.Add(btnMS7);
            milkshakeButtons.Add(btnMS8);
            milkshakeButtons.Add(btnMS9);
            milkshakeButtons.Add(btnMS10);
            milkshakeButtons.Add(btnMS11);
            milkshakeButtons.Add(btnMS12);
            milkshakeButtons.Add(btnMS13);
            milkshakeButtons.Add(btnMS14);
            milkshakeButtons.Add(btnMS15);


            for (int i = 0; i < milkshakeButtons.Count; i++)
            {
                milkshakeButtons[i].Visible = false;
            }

            for (int i = 0; i < msFlavors.Count; i++)
            {
                milkshakeButtons[i].Tag = i;
                milkshakeButtons[i].Visible = true;
            }

            frappeButtons = new List<Button>();
            frappeButtons.Add(btnFR1);
            frappeButtons.Add(btnFR2);
            frappeButtons.Add(btnFR3);
            frappeButtons.Add(btnFR4);
            frappeButtons.Add(btnFR5);
            frappeButtons.Add(btnFR6);
            frappeButtons.Add(btnFR7);
            frappeButtons.Add(btnFR8);
            frappeButtons.Add(btnFR9);
            frappeButtons.Add(btnFR10);
            frappeButtons.Add(btnFR11);
            frappeButtons.Add(btnFR12);
            frappeButtons.Add(btnFR13);
            frappeButtons.Add(btnFR14);
            frappeButtons.Add(btnFR15);


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
            milkteaLabels = new List<Label>();
            milkteaLabels.Add(lblMT1);
            milkteaLabels.Add(lblMT2);
            milkteaLabels.Add(lblMT3);
            milkteaLabels.Add(lblMT4);
            milkteaLabels.Add(lblMT5);
            milkteaLabels.Add(lblMT6);
            milkteaLabels.Add(lblMT7);
            milkteaLabels.Add(lblMT8);
            milkteaLabels.Add(lblMT9);
            milkteaLabels.Add(lblMT10);
            milkteaLabels.Add(lblMT11);
            milkteaLabels.Add(lblMT12);
            milkteaLabels.Add(lblMT13);
            milkteaLabels.Add(lblMT14);
            milkteaLabels.Add(lblMT15);
            for (int j = 0; j < milkteaLabels.Count; j++)
            {
                milkteaLabels[j].Visible = false;
            }

            for (int j = 0; j < mtFlavors.Count; j++)
            {
                milkteaLabels[j].Text = mtFlavors[j];
                milkteaLabels[j].Visible = true;
            }

            milkshakeLabels = new List<Label>();
            milkshakeLabels.Add(lblMS1);
            milkshakeLabels.Add(lblMS2);
            milkshakeLabels.Add(lblMS3);
            milkshakeLabels.Add(lblMS4);
            milkshakeLabels.Add(lblMS5);
            milkshakeLabels.Add(lblMS6);
            milkshakeLabels.Add(lblMS7);
            milkshakeLabels.Add(lblMS8);
            milkshakeLabels.Add(lblMS9);
            milkshakeLabels.Add(lblMS10);
            milkshakeLabels.Add(lblMS11);
            milkshakeLabels.Add(lblMS12);
            milkshakeLabels.Add(lblMS13);
            milkshakeLabels.Add(lblMS14);
            milkshakeLabels.Add(lblMS15);

            for (int j = 0; j < milkshakeLabels.Count; j++)
            {
                milkshakeLabels[j].Visible = false;
            }

            for (int j = 0; j < msFlavors.Count; j++)
            {
                milkshakeLabels[j].Text = msFlavors[j];
                milkshakeLabels[j].Visible = true;
            }

            frappeLabels = new List<Label>();
            frappeLabels.Add(lblFR1);
            frappeLabels.Add(lblFR2);
            frappeLabels.Add(lblFR3);
            frappeLabels.Add(lblFR4);
            frappeLabels.Add(lblFR5);
            frappeLabels.Add(lblFR6);
            frappeLabels.Add(lblFR7);
            frappeLabels.Add(lblFR8);
            frappeLabels.Add(lblFR9);
            frappeLabels.Add(lblFR10);
            frappeLabels.Add(lblFR11);
            frappeLabels.Add(lblFR12);
            frappeLabels.Add(lblFR13);
            frappeLabels.Add(lblFR14);
            frappeLabels.Add(lblFR15);
            for (int j = 0; j < frappeLabels.Count; j++)
            {
                frappeLabels[j].Visible = false;
            }

            for (int j = 0; j < frFlavors.Count; j++)
            {
                frappeLabels[j].Text = frFlavors[j];
                frappeLabels[j].Visible = true;
            }
        }
        private void buttonMT_Click(object sender, EventArgs e)
        {
            int selectedIndex = Convert.ToInt32(((Button)sender).Tag);
            MilkTeaName = mtFlavors[selectedIndex];
            frmMilkTea frmMilkTea = new frmMilkTea(MilkTeaName, mtPrice1[selectedIndex], mtPrice2[selectedIndex], mtPrice3[selectedIndex]);
            frmMilkTea.ShowDialog();
            updateDisplay();
        }
        private void buttonMS_Click(object sender, EventArgs e)
        {
            int selectedIndex = Convert.ToInt32(((Button)sender).Tag);
            MilkTeaName = msFlavors[selectedIndex];
            frmMilkTea frmMilkTea = new frmMilkTea(MilkTeaName, msPrice1[selectedIndex], msPrice2[selectedIndex], msPrice3[selectedIndex]);
            frmMilkTea.ShowDialog();
            updateDisplay();
        }
        private void buttonFR_Click(object sender, EventArgs e)
        {
            int selectedIndex = Convert.ToInt32(((Button)sender).Tag);
            MilkTeaName = frFlavors[selectedIndex];
            frmMilkTea frmMilkTea = new frmMilkTea(MilkTeaName, frPrice1[selectedIndex], frPrice2[selectedIndex], frPrice3[selectedIndex]);
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
            //this.Close();
            Application.Exit();
            frmLogin.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                order = (Convert.ToInt32(txtRemove.Text) - 1);
                TransactionHistory.History.RemoveAt(order);
                TransactionHistory.priceTotal.RemoveAt(order);
                Transact.Total = TransactionHistory.priceTotal.Sum();
                Transact.isVATable(Transact.Total);
                updateDisplay();
            }
            catch
            {
                MessageBox.Show("Please input an existing order");
                txtRemove.ResetText();
            }

            txtRemove.Text = "Type the Order #";
            this.txtRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemove.ForeColor = System.Drawing.Color.Gray;
        }

        private bool transactOnGoing()
        {
            if (txtDisplay.Text != "")
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
        private void btnManUsers_Click(object sender, EventArgs e)
        {
            frmUsersManager frmUsersManager = new frmUsersManager();
            frmUsersManager.ShowDialog();
        }

        private void btnManProds_Click(object sender, EventArgs e)
        {
            frmProductsManager frmProductsManager = new frmProductsManager();
            frmProductsManager.ShowDialog();
        }
        
        private void txtCash_Leave(object sender, EventArgs e)
        {
            leaveCash();
        }

        private void txtCash_Enter(object sender, EventArgs e)
        {
            txtCash.SelectAll();
        }



        private void openDB()
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT password, MD5(tempopw) AS hashedTempo FROM " + DatabaseConnection.UsersTable +" WHERE loginid = @id;";
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
                connection.Open();
                try
                {
                    string query = "INSERT INTO " + DatabaseConnection.SalesTable + "(sino, customer, total,vatable,vat,userid) values(@si, @customer, @total,@vatable,@vat,@userid);";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@si", salesinvoice);
                    command.Parameters.AddWithValue("@customer", txtCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@total", Transact.Total);
                    command.Parameters.AddWithValue("@vatable", Transact.VATable);
                    command.Parameters.AddWithValue("@vat", Transact.VatAmt);
                    command.Parameters.AddWithValue("@userid", loginid);
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

        private void updateDisplay()
        {
            txtDisplay.Clear();

            for (order = 0; order < TransactionHistory.History.Count(); order++)
            {
                txtDisplay.Text += "Order #: " + (order + 1) + "\r\n\n" + TransactionHistory.History[order] + "\r\n\n";
            }


            txtTotalAmtDue.Text = Transact.Total.ToString("F");
            txtVATable.Text = Transact.VATable.ToString("F");
            txtVATAmount.Text = Transact.VatAmt.ToString("F");

            txtDisplay.SelectionStart = txtDisplay.Text.Length;
            txtDisplay.ScrollToCaret();

            computeChange();

            if (Transact.Change >= 0 && order > 0)
            {
                txtChange.Text = Transact.Change.ToString("F");
                btnTransact.Enabled = true;
            }
            else if (Transact.Change >= 0 && order == 0)
            {
                btnTransact.Enabled = false;
                txtChange.Text = ("0.00");
            }
            else
            {
                btnTransact.Enabled = false;
                txtChange.Text = ("Enter a valid cash amount");
            }


        }

        
        private void computeChange()
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
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT MAX(sino) as si FROM tblsales;";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                connection.Close();
            }

            openDB();
            Transact.Cash = 0;
            Transact.Total = 0;
            Transact.VATable = 0;
            Transact.VatAmt = 0;
            order = 0;
            TransactionHistory.priceTotal.Clear();
            TransactionHistory.History.Clear();
            txtCash.Text = "0.00";
            txtCustomer.ResetText();

            if (txtRemove.Text == "")
            {
                txtRemove.Text = "Type the Order #";
                this.txtRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtRemove.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {

            }

            lblSINumber.Text = "SI No: " + salesinvoice;
        }

        private void leaveCash()
        {
            if (txtCash.Text != "")
            {
                try
                {
                    double cashin = Double.Parse(txtCash.Text);
                    txtCash.Text = cashin.ToString("F");
                }
                catch
                {
                    MessageBox.Show("Cash must not be less than total!");
                    txtCash.ResetText();
                    txtCash.Focus();
                }

                updateDisplay();
            }
            else
                txtCash.Focus();
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
                this.Opacity = 0.9;
                this.Update();
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Opacity = 1;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            formResize();
        }



        private void formResize()
        {
            lblUser.Location = new System.Drawing.Point(10, 10);
            lblPosition.Location = new System.Drawing.Point(10, 10 + lblUser.Height + 10);
            tabControl.Location = new System.Drawing.Point(10, lblPosition.Location.Y + lblPosition.Height + 10);

            btnTransactionHistory.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnTransactionHistory.Width - 10, tabControl.Location.Y + 21);
            btnUsersManager.Location = new System.Drawing.Point(btnTransactionHistory.Location.X, btnTransactionHistory.Location.Y + btnTransactionHistory.Height + 10);
            btnProductsManager.Location = new System.Drawing.Point(btnTransactionHistory.Location.X, btnUsersManager.Location.Y + btnUsersManager.Height + 10);

            txtDisplay.Location = new System.Drawing.Point(btnTransactionHistory.Location.X - 20 - txtDisplay.Width, btnTransactionHistory.Location.Y);

            txtDisplay.Height = this.ClientRectangle.Height - txtDisplay.Location.Y - (10 + panel1.Height + 10 + btnRemove.Height + 10);

            btnRemove.Location = new System.Drawing.Point(txtDisplay.Location.X, txtDisplay.Location.Y + txtDisplay.Height + 10);
            txtRemove.Location = new System.Drawing.Point(txtDisplay.Location.X + txtDisplay.Width - txtRemove.Width, btnRemove.Location.Y);

            panel1.Location = new System.Drawing.Point(txtDisplay.Location.X, btnRemove.Location.Y + btnRemove.Height + 10);

            tabControl.Size = new System.Drawing.Size(txtDisplay.Location.X - 20, ClientRectangle.Height - tabControl.Location.Y - 10);

            btnLogout.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnLogout.Width - 10, this.ClientRectangle.Height - btnLogout.Height - 10);
            btnChangePassword.Location = new System.Drawing.Point(btnLogout.Location.X, btnLogout.Location.Y - btnChangePassword.Height - 10);


            /////////////////////////////////////////////////////////////////////////////////////////////

            lblProducts1.Location = new System.Drawing.Point(tabControl.Width / 2 - (lblProducts1.Width / 2), 4);
            lblProducts2.Location = new System.Drawing.Point(tabControl.Width / 2 - (lblProducts2.Width / 2), 4);
            lblProducts3.Location = new System.Drawing.Point(tabControl.Width / 2 - (lblProducts3.Width / 2), 4);

            btnMT1.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMT1.Width / 2), lblProducts1.Location.Y + lblProducts1.Height + 20);
            btnMT2.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMT2.Width / 2), btnMT1.Location.Y);
            btnMT3.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMT3.Width / 2), btnMT1.Location.Y);
            btnMT4.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMT4.Width / 2), btnMT1.Location.Y);
            btnMT5.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMT5.Width / 2), btnMT1.Location.Y);
            btnMT6.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMT6.Width / 2), btnMT1.Location.Y + btnMT1.Height + 70);
            btnMT7.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMT7.Width / 2), btnMT6.Location.Y);
            btnMT8.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMT8.Width / 2), btnMT6.Location.Y);
            btnMT9.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMT9.Width / 2), btnMT6.Location.Y);
            btnMT10.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMT10.Width / 2), btnMT6.Location.Y);
            btnMT11.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMT11.Width / 2), btnMT6.Location.Y + btnMT6.Height + 70);
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
            btnMS6.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMS6.Width / 2), btnMS1.Location.Y + btnMS1.Height + 70);
            btnMS7.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnMS7.Width / 2), btnMS6.Location.Y);
            btnMS8.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnMS8.Width / 2), btnMS6.Location.Y);
            btnMS9.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnMS9.Width / 2), btnMS6.Location.Y);
            btnMS10.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnMS10.Width / 2), btnMS6.Location.Y);
            btnMS11.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnMS11.Width / 2), btnMS6.Location.Y + btnMS6.Height + 70);
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
            btnFR6.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnFR6.Width / 2), btnFR1.Location.Y + btnFR1.Height + 70);
            btnFR7.Location = new System.Drawing.Point((tabPage1.Width * 2 / 6) - (btnFR7.Width / 2), btnFR6.Location.Y);
            btnFR8.Location = new System.Drawing.Point((tabPage1.Width * 3 / 6) - (btnFR8.Width / 2), btnFR6.Location.Y);
            btnFR9.Location = new System.Drawing.Point((tabPage1.Width * 4 / 6) - (btnFR9.Width / 2), btnFR6.Location.Y);
            btnFR10.Location = new System.Drawing.Point((tabPage1.Width * 5 / 6) - (btnFR10.Width / 2), btnFR6.Location.Y);
            btnFR11.Location = new System.Drawing.Point((tabPage1.Width * 1 / 6) - (btnFR11.Width / 2), btnFR6.Location.Y + btnFR6.Height + 70);
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













            //btnMS1.Location = btnMT1.Location;
            //btnMS2.Location = btnMT2.Location;
            //btnMS3.Location = btnMT3.Location;

            //lblMS1.Location = new System.Drawing.Point((btnMS1.Location.X + (btnMS1.Width) / 2) - lblMS1.Width / 2, btnMS1.Location.Y + btnMS1.Height + 5);
            //lblMS2.Location = new System.Drawing.Point((btnMS2.Location.X + (btnMS2.Width) / 2) - lblMS2.Width / 2, lblMS1.Location.Y);
            //lblMS3.Location = new System.Drawing.Point((btnMS3.Location.X + (btnMS3.Width) / 2) - lblMS3.Width / 2, lblMS1.Location.Y);


            //btnFR1.Location = btnMT1.Location;
            //btnFR2.Location = btnMT2.Location;
            //btnFR3.Location = btnMT3.Location;

            //lblFR1.Location = new System.Drawing.Point((btnFR1.Location.X + (btnFR1.Width) / 2) - lblFR1.Width / 2, btnFR1.Location.Y + btnFR1.Height + 5);
            //lblFR2.Location = new System.Drawing.Point((btnFR2.Location.X + (btnFR2.Width) / 2) - lblFR2.Width / 2, lblFR1.Location.Y);
            //lblFR3.Location = new System.Drawing.Point((btnFR3.Location.X + (btnFR3.Width) / 2) - lblFR3.Width / 2, lblFR1.Location.Y);



            //lblProduct4.Location = new System.Drawing.Point((btnItem4.Location.X + (btnItem4.Width) / 2) - lblProduct4.Width / 2, btnItem4.Location.Y + btnItem4.Height + 5);
            //lblProduct5.Location = new System.Drawing.Point((btnItem5.Location.X + (btnItem5.Width) / 2) - lblProduct5.Width / 2, lblProduct4.Location.Y);
            //lblProduct6.Location = new System.Drawing.Point((btnItem6.Location.X + (btnItem6.Width) / 2) - lblProduct6.Width / 2, lblProduct4.Location.Y);

            //tabControl1.Size = new System.Drawing.Size(ClientSize.Width * 3 / 4, ClientSize.Height - 5);
            /*grpVendoUI.Size = new System.Drawing.Size(ClientSize.Width * 4 / 5, 850);
            grpVendoUI.Location = new System.Drawing.Point(ClientSize.Width / 2 - ((grpVendoUI.Width) / 2), ClientSize.Height / 2 - ((grpVendoUI.Height) / 2));
            txtName.Size = new System.Drawing.Size(grpVendoUI.Width - 4, 45);
            txtCurrentCredit.Size = new System.Drawing.Size(grpVendoUI.Width - lblCreditAmount.Width, 45);
            txtCurrentCredit.Location = new System.Drawing.Point(lblCreditAmount.Width + 2, txtName.Location.Y + txtName.Height + 5);
            btnCash.Location = new System.Drawing.Point((grpVendoUI.Width / 3) - (btnCash.Width / 2) - (50), txtCurrentCredit.Location.Y + txtCurrentCredit.Height + 15);
            btnCredit.Location = new System.Drawing.Point((grpVendoUI.Width * 2 / 3) - (btnCredit.Width / 2) + (50), btnCash.Location.Y);
            lblCoinsInserted.Location = new System.Drawing.Point((grpVendoUI.Width / 2) - (lblCoinsInserted.Width / 2), btnCredit.Location.Y + btnCredit.Height + 15);
            btnCancel.Location = new System.Drawing.Point(grpVendoUI.Width / 2 - ((btnCancel.Width) / 2), lblProduct10.Location.Y + lblProduct10.Height + 15);
            txtEmpID.Location = new System.Drawing.Point(ClientSize.Width / 2, ClientSize.Height / 2);
        
              */
        } 
        #endregion

        private void btnTransact_Click(object sender, EventArgs e)
        {
            saveTransaction();
            newTransaction();
            updateDisplay();

        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtRemove_Enter(object sender, EventArgs e)
        {
            txtRemove.Clear();
            this.txtRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemove.ForeColor = System.Drawing.Color.Black;
            //txtRemove.ForeColor = System.Win
        }

        private void txtRemove_Leave(object sender, EventArgs e)
        {
            if(txtRemove.Text == "")
            {
                txtRemove.Text = "Type the Order #";
                this.txtRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtRemove.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {

            }
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

    }
}
