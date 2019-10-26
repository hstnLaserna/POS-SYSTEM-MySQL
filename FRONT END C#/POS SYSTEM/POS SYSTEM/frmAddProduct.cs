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
            productCheckBox = new List<CheckBox>() { chkAddon1, chkAddon2, chkAddon3, chkAddon4, chkAddon5, chkAddon6};
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

        private void frmMilkTea_Load(object sender, EventArgs e)
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
            txtQuantity.Text = quantity.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (quantity == 0)
            {
                MessageBox.Show("Quantity must not be 0!");
                txtQuantity.SelectAll();
            }
            else
            {
                Product.Quantity = quantity;
                Product.Notes = txtNotes.Text;
                Product.ComputePrice();
                TransactionHistory.priceTotal.Add(Product.ProductPrice);
                Transact.Total = TransactionHistory.priceTotal.Sum();
                Transact.isVATable(Transact.Total);
                if (Product.Notes != "")
                {
                    hist = Product.Type + ": " + Product.ProductName + "\r\n" + "Size: " + Product.Size + "\r\n" + "Sugar Level: " + Product.SugarLevel + "\r\n" + "Add-ons: " + Product.Addons + "\r\n" + "Quantity: " + Product.Quantity + "\r\n" + "Price: " + Product.ProductPrice.ToString() + "\r\n" + "Added Note:\r\n" + Product.Notes + "\r\n";
                }
                else
                {
                    hist = Product.Type + ": " + Product.ProductName + "\r\n" + "Size: " + Product.Size + "\r\n" + "Sugar Level: " + Product.SugarLevel + "\r\n" + "Add-ons: " + Product.Addons + "\r\n" + "Quantity: " + Product.Quantity + "\r\n" + "Price: " + Product.ProductPrice.ToString() + "\r\n";
                }
                TransactionHistory.History.Add(hist);
                this.Close();
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
                Product.Addons += chk.Text + " ";
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
            //tabControl1.Size = new System.Drawing.Size(ClientSize.Width * 3 / 4, ClientSize.Height - 5);
            /*grpVendoUI.Size = new System.Drawing.Size(ClientSize.Width * 4 / 5, 850);
            grpVendoUI.Location = new System.Drawing.Point(ClientSize.Width / 2 - ((grpVendoUI.Size.Width) / 2), ClientSize.Height / 2 - ((grpVendoUI.Size.Height) / 2));
            txtName.Size = new System.Drawing.Size(grpVendoUI.Size.Width - 4, 45);
            txtCurrentCredit.Size = new System.Drawing.Size(grpVendoUI.Size.Width - lblCreditAmount.Size.Width, 45);
            txtCurrentCredit.Location = new System.Drawing.Point(lblCreditAmount.Size.Width + 2, txtName.Location.Y + txtName.Size.Height + 5);
            btnCash.Location = new System.Drawing.Point((grpVendoUI.Size.Width / 3) - (btnCash.Size.Width / 2) - (50), txtCurrentCredit.Location.Y + txtCurrentCredit.Size.Height + 15);
            btnCredit.Location = new System.Drawing.Point((grpVendoUI.Size.Width * 2 / 3) - (btnCredit.Size.Width / 2) + (50), btnCash.Location.Y);
            lblCoinsInserted.Location = new System.Drawing.Point((grpVendoUI.Size.Width / 2) - (lblCoinsInserted.Size.Width / 2), btnCredit.Location.Y + btnCredit.Size.Height + 15);
            btnCancel.Location = new System.Drawing.Point(grpVendoUI.Size.Width / 2 - ((btnCancel.Size.Width) / 2), lblProduct10.Location.Y + lblProduct10.Size.Height + 15);
            txtEmpID.Location = new System.Drawing.Point(ClientSize.Width / 2, ClientSize.Height / 2);
        
              */
        }  
        #endregion
    }
}
