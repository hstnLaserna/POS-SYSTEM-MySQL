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
    public partial class frmAddProduct : Form
    {
        Product Product = new Product();
        Transact Transact = new Transact();
        CheckBox chk;
        RadioButton rb;
        double Price1, Price2, Price3;
        private List<CheckBox> productCheckBox;
        private List<string> addons;
        private List<double> price;
        int quantity = 0;
        public static string hist;

        MySqlCommand command;
        DataTable dataTable;
        MySqlDataAdapter mySqlDataAdapter;

        public frmAddProduct(string ProductType, string ProductName, double price1, double price2, double price3)
        {
            InitializeComponent();
            Product.ProductName = ProductName;
            Product.Type = ProductType;
            Price1 = price1;
            Price2 = price2;
            Price3 = price3;
            lblProductName.Text = Product.ProductName;
        }

        private void initializeCheckBoxes()
        {
            productCheckBox = new List<CheckBox>() { chkAddon1, chkAddon2, chkAddon3, chkAddon4, chkAddon5, chkAddon6 };
            for (int i = 0; i < productCheckBox.Count; i++)
            {
                productCheckBox[i].Visible = false;
            }

            for (int i = 0; i < addons.Count; i++)
            {
                productCheckBox[i].Tag = i;
                productCheckBox[i].Text = addons[i];
                productCheckBox[i].Visible = true;
            }
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {

            rbtn100P.Checked = true;

            dataTable = new DataTable();

            addons = new List<string>(dataTable.Rows.Count);
            price = new List<double>(dataTable.Rows.Count);

            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    mySqlDataAdapter = new MySqlDataAdapter();
                    string query = "SELECT name, price FROM " + DatabaseConnection.AddonsTable + " WHERE forProductType = @selectedProductType AND isAvailable = 1;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@selectedProductType", Product.Type);
                    mySqlDataAdapter.SelectCommand = command;


                    mySqlDataAdapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        addons.Add((string)row["name"]);
                        price.Add(Convert.ToDouble(row["price"]));
                    }

                    //string heh = "";
                    //foreach (object o in addons)
                    //{
                    //    heh = heh + o + "\n";
                    //}
                    //MessageBox.Show(heh);
                    dataTable.Clear();
                    command.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }

            initializeCheckBoxes();

            if (Price1 > 0)
            {
                radSize1.Enabled = true;
            }
            else { }
            if (Price2 > 0)
            {
                radSize2.Enabled = true;
            }
            else { }
            if (Price3 > 0)
            {
                radSize3.Enabled = true;
            }
            else { }
            formResize();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (quantity < 999)
            {
                quantity++;
            }
            else { }
            txtQuantity.Text = quantity.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
            }
            else { }
            txtQuantity.Text = string.Format("{0:#,##0}", quantity);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addProduct();
        }

        private void addProduct()
        {
            double orderSum = (Transact.Total + ((Product.SizePrice + Product.SinkerPrice) * quantity));
            if (quantity == 0)
            {
                MessageBox.Show("Quantity must not be 0!");
                txtQuantity.SelectAll();
            }
            else if (orderSum <= 9999999999)
            {
                Product.Quantity = quantity;
                Product.Notes = txtNotes.Text;
                Product.ComputePrice();
                TransactionHistory.priceTotal.Add(Product.ProductPrice);
                Transact.Total = TransactionHistory.priceTotal.Sum();
                Transact.isVATable(Transact.Total);
                if (Product.Notes != "" && Product.Type.ToLower() == "milktea")
                {
                    hist = Product.Type + ": " + Product.ProductName + "\r\n" + "Size: " + Product.Size + "\r\n" + "Sugar Level: " + Product.SugarLevel + "\r\n" + "Add-ons: " + Product.Addons + "\r\n" + "Quantity: " + Product.Quantity + "\r\n" + "Price: " + Product.ProductPrice.ToString() + "\r\n" + "Added Note:\r\n" + Product.Notes + "\r\n";
                }
                else if (Product.Notes != "" && Product.Type.ToLower() != "milktea")
                {
                    hist = Product.Type + ": " + Product.ProductName + "\r\n" + "Size: " + Product.Size + "\r\n" + "Add-ons: " + Product.Addons + "\r\n" + "Quantity: " + Product.Quantity + "\r\n" + "Price: " + Product.ProductPrice.ToString() + "\r\n" + "Added Note:\r\n" + Product.Notes + "\r\n";
                }
                else if (Product.Type.ToLower() == "milktea")
                {
                    hist = Product.Type + ": " + Product.ProductName + "\r\n" + "Size: " + Product.Size + "\r\n" + "Sugar Level: " + Product.SugarLevel + "\r\n" + "Add-ons: " + Product.Addons + "\r\n" + "Quantity: " + Product.Quantity + "\r\n" + "Price: " + Product.ProductPrice.ToString() + "\r\n";
                }
                else
                {
                    hist = Product.Type + ": " + Product.ProductName + "\r\n" + "Size: " + Product.Size + "\r\n" + "Add-ons: " + Product.Addons + "\r\n" + "Quantity: " + Product.Quantity + "\r\n" + "Price: " + Product.ProductPrice.ToString() + "\r\n";
                }
                TransactionHistory.History.Add(hist);
                TransactionHistory.transactionOrders.Add(Product);

                this.Close();
            }
            else
            {
                MessageBox.Show("Adding this order will exceed the allowable transaction amount of:\nP 9,999,999,999.00\n Please render additional products to a new transaction. \n\n Total due after this order: " + string.Format("{0:#,##0}", orderSum), "MAXED ALLOWED TRANSACTION AMOUNT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                quantity = 0;
                txtQuantity.Text = string.Format("{0:#,##0}", quantity);
            }
        }

        // ----------------------------- METHODS ----------------------------- 

        private void getSizePrice(object sender, EventArgs e)
        {
            rb = ((RadioButton)sender);
            if (rb.Name == "radSize1")
            {
                Product.SizePrice = Price1;
            }
            else if (rb.Name == "radSize2")
            {
                Product.SizePrice = Price2;
            }
            else if (rb.Name == "radSize3")
            {
                Product.SizePrice = Price3;
            }
            else { }
            Product.Size = rb.Text;
        }

        private void getSugarLevel(object sender, EventArgs e)
        {
            Product.SugarLevel = ((RadioButton)sender).Text;
        }

        private void getSinkers(object sender, EventArgs e)
        {
            chk = sender as CheckBox;
            if (chk.Checked == true)
            {
                Product.Addons += chk.Text + "   ";
                Product.SinkerPrice += price[Convert.ToInt32(((CheckBox)sender).Tag)];
            }
            else if (chk.Checked == false)
            {
                Product.Addons = Product.Addons.Replace(chk.Text, "");
                Product.SinkerPrice -= price[Convert.ToInt32(((CheckBox)sender).Tag)];
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
                quantity = Convert.ToInt32(((TextBox)sender).Text);
            }
            else
            {
                try
                {
                    quantity = Convert.ToInt32(((TextBox)sender).Text);
                }
                catch
                { }
            }
        }

        private void txtNotes_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text.Trim(), @"\s+", " ");
        }

        private void txtNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Add))
            {
                if (quantity < 999)
                {
                    quantity++;
                }
                else { }
                txtQuantity.Text = quantity.ToString();
                return true;
            }
            if (keyData == (Keys.Subtract))
            {
                if (quantity > 1)
                {
                    quantity--;
                }
                else { }
                txtQuantity.Text = string.Format("{0:#,##0}", quantity);
                return true;
            }
            if (keyData == (Keys.Enter))
            {
                addProduct();
                return true;
            }


            // CLOSING
            if (keyData == (Keys.Alt | Keys.L) || keyData == (Keys.F10))
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
        #region Misc Methods

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
                this.Opacity = 0.8;
                this.Update();
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Opacity = 1;
        }

        private void formResize()
        {
            lblProductName.Location = new System.Drawing.Point(ClientSize.Width / 2 - (lblProductName.Size.Width / 2), lblProductName.Location.Y);

            if (Product.Type.ToLower() != "milktea")
            {
                panelSugarLevel.Visible = false;
                panelNote.Location = new Point(panelNote.Location.X, panelNote.Location.Y - panelSugarLevel.Height - 10);
                btnAdd.Location = new Point(btnAdd.Location.X, btnAdd.Location.Y - panelSugarLevel.Height - 10);
                this.Size = new System.Drawing.Size(ClientSize.Width, ClientSize.Height - panelSugarLevel.Height);
            }
            else { }
        }
        #endregion
    }
}
