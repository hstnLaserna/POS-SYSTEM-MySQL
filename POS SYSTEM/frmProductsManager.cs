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
    public partial class frmProductsManager : Form
    {
        MySqlDataReader reader;
        MySqlCommand command;
        int isEnabled = 1;
        int selectedID = 0;

        private MySqlDataAdapter mySqlDataAdapter;


        public frmProductsManager()
        {
            InitializeComponent();
            openDB();
        }


        private void frmProductsManager_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbposDataSet.tblproducts' table. You can move, or remove it, as needed.
            formResize();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "" && ((TextBox)sender).Tag.ToString() == "price")
            {
                ((TextBox)sender).Text = "0.00";
            }
            else { }
            if ((txtProductName.TextLength > 0) && ((Convert.ToDouble(txtPrice1.Text) > 0) || (Convert.ToDouble(txtPrice2.Text) > 0) || (Convert.ToDouble(txtPrice3.Text) > 0)))
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void TextPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void TextName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }


        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnabled.Checked == true)
            {
                isEnabled = 1;
            }
            else
            {
                isEnabled = 0;
            }
        }

        private void TextBoxes_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text.Trim(), @"\s+", " ");
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "0")
            {
                txtID.Text = "";
            }
            else { }

            if (txtID.Text == "")
            {
                btnUpdate.Text = "SAVE";
                listProductType.Enabled = true;
            }
            else
            {
                btnUpdate.Text = "UPDATE";
                listProductType.Enabled = false;
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            processProducts();
        }

        private void processProducts()
        {
            if (btnUpdate.Text == "UPDATE")
            {
                if (txtProductName.TextLength >= 4)
                {
                    var exists = dgvProducts.Rows.Cast<DataGridViewRow>()
                                 .Where(row => !row.IsNewRow)
                                 .Select(row => row.Cells[0].Value.ToString())
                                 .Any(x => this.txtID.Text == x);
                    if (exists)
                    {
                        using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                        {
                            int activatedProducts = 0;
                            connection.Open();
                            try
                            {
                                string query = "SELECT COUNT(*) as activatedProducts FROM " + DatabaseConnection.ProductsTable + " WHERE producttype = @ProductType AND isavailable = 1;";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@ProductType", listProductType.SelectedItem.ToString());
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    activatedProducts = Convert.ToInt32(reader["activatedProducts"]);
                                }

                                reader.Close();
                                command.Dispose();

                                string queryUpdate = "";

                                if (activatedProducts >= 0 && activatedProducts <= 14)
                                {
                                    queryUpdate = "CALL updateProduct(@ProductName, @Price1, @Price2, @Price3, @ProductType, @isAvailable, @SelectedID);";

                                    if (activatedProducts == 14 && chkEnabled.Checked == true)
                                    {
                                        MessageBox.Show("Maximum (15) available flavors for product: \n" + listProductType.SelectedItem.ToString() + "\n has been reached!", "Maxed Available Products", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }
                                else
                                {
                                    // Still update records. But isEnabled will be hard to 0
                                    queryUpdate = "CALL updateProduct(@ProductName, @Price1, @Price2, @Price3, @ProductType, @isAvailable, @SelectedID);";
                                    if (chkEnabled.Checked == true)
                                    {
                                        queryUpdate = "CALL updateProduct(@ProductName, @Price1, @Price2, @Price3, @ProductType, 0, @SelectedID);";
                                        MessageBox.Show("Limit Exceeded. \n Available flavors for each product must not exceed 15!", "Maxed Available Products", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }


                                command = new MySqlCommand(queryUpdate, connection);
                                command.Parameters.AddWithValue("@Productname", txtProductName.Text);
                                command.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                                command.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                                command.Parameters.AddWithValue("@Price3", txtPrice3.Text);
                                command.Parameters.AddWithValue("@ProductType", listProductType.SelectedItem.ToString());
                                command.Parameters.AddWithValue("@isAvailable", isEnabled);
                                command.Parameters.AddWithValue("@SelectedID", selectedID);
                                reader = command.ExecuteReader();
                                reader.Close();
                                command.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (ex.HResult != -2147467259)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Unable to update. \nThe product name: " + txtProductName.Text.ToUpper() + " already exists. \n Error #: -2147467259", "Duplicte Name Detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            connection.Close();
                            initializeDisplay();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a Product");
                    }
                }
                else
                {
                    MessageBox.Show("Product must be 4 or more characters");
                }
            }



            else
            {
                if (txtProductName.TextLength >= 4)
                {
                    using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                    {
                        int activatedProducts = 0;
                        connection.Open();
                        try
                        {
                            string query = "SELECT COUNT(*) as activatedProducts FROM " + DatabaseConnection.ProductsTable + " WHERE producttype = @ProductType AND isavailable = 1;";
                            command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@ProductType", listProductType.SelectedItem.ToString());
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                activatedProducts = Convert.ToInt32(reader["activatedProducts"]);
                            }

                            reader.Close();
                            command.Dispose();


                            if (activatedProducts == 15)
                            {
                                isEnabled = 0;
                                MessageBox.Show("Maximum available products for " + listProductType.SelectedItem.ToString() + " reached! \nAvailability set to NO");
                            }
                            else
                            { }


                            string queryUpdate = "CALL addProduct(@ProductName, @Price1, @Price2, @Price3, @ProductType, @isAvailable);";
                            command = new MySqlCommand(queryUpdate, connection);
                            command.Parameters.AddWithValue("@Productname", txtProductName.Text);
                            command.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                            command.Parameters.AddWithValue("@Price2", txtPrice2.Text);
                            command.Parameters.AddWithValue("@Price3", txtPrice3.Text);
                            command.Parameters.AddWithValue("@ProductType", listProductType.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@isAvailable", isEnabled);
                            reader = command.ExecuteReader();
                            reader.Close();
                            command.Dispose();

                        }
                        catch (Exception ex)
                        {
                            if (ex.HResult != -2147467259)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Unable to update. \nThe product name: " + txtProductName.Text.ToUpper() + " already exists. \n Error #: -2147467259", "Duplicte Name Detected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        connection.Close();
                        initializeDisplay();
                    }
                }
                else
                {
                    MessageBox.Show("Product must be 4 or more characters");
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            initializeDisplay();
        }


        private void dgvProducts_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvProducts.Rows[e.RowIndex];

                //populate the textbox from specific value of the coordinates of column and row.
                selectedID = Convert.ToInt32(row.Cells[0].Value);
                txtID.Text = selectedID.ToString();
                txtProductName.Text = row.Cells[1].Value.ToString();
                txtPrice1.Text = row.Cells[2].Value.ToString();
                txtPrice2.Text = row.Cells[3].Value.ToString();
                txtPrice3.Text = row.Cells[4].Value.ToString();

                switch (row.Cells[5].Value.ToString().ToLower())
                {
                    case "milktea":
                        listProductType.SelectedIndex = 0;
                        break;
                    case "milkshake":
                        listProductType.SelectedIndex = 1;
                        break;
                    case "frappe":
                        listProductType.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }

                if (Convert.ToBoolean(row.Cells[6].Value) == true)
                {
                    chkEnabled.Checked = true;
                }
                else
                {
                    chkEnabled.Checked = false;
                }
            }
        }


        // --------------------- METHODS ---------------------

        private void initializeDisplay()
        {
            dgvProducts.ClearSelection();
            txtID.ResetText();
            txtProductName.ResetText();
            txtPrice1.ResetText();
            txtPrice2.ResetText();
            txtPrice3.ResetText();
            listProductType.SelectedIndex = 0;
            chkEnabled.Checked = true;
            selectedID = 0;
            btnUpdate.Enabled = false;
            openDB();
        }
        private void openDB()
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string querystring = "SELECT  productID 'ID', name 'Product', price1 'Price (S)', price2 'Price (M)', price3 'Price (L)', productType 'Product Type', isAvailable, DATE(dateadded) 'Date Added' FROM " + DatabaseConnection.ProductsTable + " WHERE " + displayedProducts();
                    mySqlDataAdapter = new MySqlDataAdapter(querystring, connection);
                    DataSet DS = new DataSet();
                    mySqlDataAdapter.Fill(DS);
                    dgvProducts.DataSource = DS.Tables[0];

                    dgvProducts.Columns.RemoveAt(6);
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.HeaderText = "Product Available";
                    chk.Name = "isAvailable";
                    chk.DataPropertyName = "isAvailable";
                    dgvProducts.Columns.Insert(6, chk);
                    
                    dgvProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvProducts.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvProducts.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                connection.Close();
            }

            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void formResize()
        {
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
            groupBox1.Location = new System.Drawing.Point(this.ClientRectangle.Width - groupBox1.Width - 10, dgvProducts.Location.Y);
            btnAddonsManager.Location = new System.Drawing.Point(groupBox1.Location.X, groupBox1.Location.Y + groupBox1.Height + 10);
        }

        private void TextBoxPrice_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0.00";
            }
        }

        private void btnAddonsManager_Click(object sender, EventArgs e)
        {
            frmAddonsManager frmAddonsManager = new frmAddonsManager();
            frmAddonsManager.ShowDialog();
        }

        private void chkProducts_CheckStateChanged(object sender, EventArgs e)
        {
            openDB();
        }

        private string displayedProducts()
        {
            string displayedProduct;
            bool A = chkMilktea.Checked;
            bool B = chkMilkshake.Checked;
            bool C = chkFrappe.Checked;

            if( A && B && C)
            {
                displayedProduct = "productType = 'milktea' OR productType = 'milkshake' OR productType = 'FRAPPE'";
            }
            else if (A && B)
            {
                displayedProduct = "productType = 'milktea' OR productType = 'milkshake'";
            }
            else if (A && C)
            {
                displayedProduct = "productType = 'milktea' OR productType = 'FRAPPE'";
            }
            else if (B && C)
            {
                displayedProduct = "productType = 'milkshake' OR productType = 'FRAPPE'";
            }
            else if (A)
            {
                displayedProduct = "productType = 'milktea'";
            }
            else if (B)
            {
                displayedProduct = "productType = 'milkshake'";
            }
            else if (C)
            {
                displayedProduct = "productType = 'FRAPPE'";
            }
            else
            {
                displayedProduct = "productType = ''";
            }

            return displayedProduct;
        }




        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.N) || keyData == (Keys.Alt | Keys.U))
            {
                if (btnUpdate.Enabled)
                {
                    processProducts();
                }
                return true;
            }

            if (keyData == (Keys.Alt | Keys.C))
            {
                initializeDisplay();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.T))
            {
                if(chkMilktea.Checked)
                    chkMilktea.Checked = false;
                else
                    chkMilktea.Checked = true;
                return true;
            }

            if (keyData == (Keys.Alt | Keys.S))
            {
                if (chkMilkshake.Checked)
                    chkMilkshake.Checked = false;
                else
                    chkMilkshake.Checked = true;
                return true;
            }

            if (keyData == (Keys.Alt | Keys.F))
            {
                if (chkFrappe.Checked)
                    chkFrappe.Checked = false;
                else
                    chkFrappe.Checked = true;
                return true;
            }
            if (keyData == (Keys.Alt | Keys.M))
            {
                frmAddonsManager frmAddonsManager = new frmAddonsManager();
                frmAddonsManager.ShowDialog();
                return true;
            }



            //close
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
