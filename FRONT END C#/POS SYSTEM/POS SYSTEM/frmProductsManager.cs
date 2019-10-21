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
        string msg;

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
            if ((txtProductName.TextLength > 0) && ((txtPrice1.TextLength > 0) || (txtPrice2.TextLength > 0) || (txtPrice3.TextLength > 0)))
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
                chkEnabled.Text = "Yes";
            }
            else
            {
                isEnabled = 0;
                chkEnabled.Text = "No";
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
            }
            else
            {
                btnUpdate.Text = "UPDATE";
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
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
                                string query = "SELECT COUNT(*) as activatedProducts from tblproducts where producttype = @ProductType AND isavailable = 1;";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@ProductType", listProductType.SelectedItem.ToString());
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    activatedProducts = Convert.ToInt32(reader["activatedProducts"]);
                                }

                                reader.Close();
                                command.Dispose();

                                MessageBox.Show(activatedProducts.ToString());

                                if (activatedProducts <= 14)
                                {
                                    {
                                        string queryUpdate = "CALL updateProduct(@ProductName, @Price1, @Price2, @Price3, @ProductType, @isAvailable, @SelectedID);";
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
                                        msg = "Product " + txtProductName.Text + " updated!";

                                        if (activatedProducts == 15)
                                        {
                                            MessageBox.Show("Maximum available products for " + listProductType.SelectedItem.ToString() + " reached!");
                                        }
                                        else { }
                                    }
                                    if (activatedProducts == 14 && chkEnabled.Checked == true)
                                    {
                                        MessageBox.Show("Maximum available products for " + listProductType.SelectedItem.ToString() + " reached!");
                                    }
                                }
                                else if (activatedProducts <= 15 && chkEnabled.Checked == false)
                                {
                                    {
                                        string queryUpdate = "CALL updateProduct(@ProductName, @Price1, @Price2, @Price3, @ProductType, @isAvailable, @SelectedID);";
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
                                        msg = "Product " + txtProductName.Text + " updated!";

                                        if (activatedProducts == 15)
                                        {
                                            MessageBox.Show("Limit Exceeded. Available products for each Product Type must not exceed 15!");
                                        }
                                        else { }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Limit Exceeded. Available products for each Product Type must not exceed 15!");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());

                                if (ex.HResult != -2147467259)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Unable to update. \nThe product name: " + txtProductName.Text.ToUpper() + " already exists. \n Error #: -2147467259 xxx");
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
                    var nameExists = dgvProducts.Rows.Cast<DataGridViewRow>()
                                 .Where(row => !row.IsNewRow)
                                 .Select(row => row.Cells[1].Value.ToString())
                                 .Any(x => this.txtProductName.Text == x);

                    if (!nameExists)
                    {
                        using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                        {
                            int activatedProducts = 0;
                            connection.Open();
                            try
                            {
                                string query = "SELECT COUNT(*) as activatedProducts from tblproducts where producttype = @ProductType AND isavailable = 1;";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@ProductType", listProductType.SelectedItem.ToString());
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    activatedProducts = Convert.ToInt32(reader["activatedProducts"]);
                                }

                                reader.Close();
                                command.Dispose();

                                MessageBox.Show(activatedProducts.ToString());

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
                                msg = "Product " + txtProductName.Text + " added!";

                            }
                            catch (Exception ex)
                            {
                                if (ex.HResult != -2147467259)
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Unable to create. The product name already exists. \n Error Number: -2147467259");
                                }
                            }
                            connection.Close();
                            initializeDisplay();
                        }
                    }
                    else
                    {
                        msg = "Unable to create. The Product name already exists!";
                        MessageBox.Show("Unable to create. The Product name already exists");
                    }
                }
                else
                {
                    msg = "Product name must be 4 or more characters!";
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
            lblStatus.Text = msg;
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
                    mySqlDataAdapter = new MySqlDataAdapter("SELECT  productid 'ProductID', name 'Product', price1 'Price (S)', price2 'Price (M)', price3 'Price (L)', productType 'Product Type', isAvailable 'Product Available', DATE(dateadded) 'Date Added' FROM " + DatabaseConnection.ProductsTable + ";", connection);
                    DataSet DS = new DataSet();
                    mySqlDataAdapter.Fill(DS);
                    dgvProducts.DataSource = DS.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                connection.Close();
            }
            //foreach (DataGridViewRow row in dgvProducts.Rows)
            //{

            //    switch (row.Cells[5].Value.ToString().ToLower())
            //    {
            //        case "milktea":
            //            row.DefaultCellStyle.BackColor = Color.Red;
            //            break;
            //        case "milkshake":
            //            row.DefaultCellStyle.BackColor = Color.Blue;
            //            break;
            //        case "frappe":
            //            row.DefaultCellStyle.BackColor = Color.Yellow;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private void formResize()
        {
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
            groupBox1.Location = new System.Drawing.Point(this.ClientRectangle.Width - groupBox1.Width - 10, dgvProducts.Location.Y);
        }

        private void listProductType_SelectedValueChanged(object sender, EventArgs e)
        {
            lblStatus.Text = listProductType.SelectedItem.ToString();
        }

        private void TextBoxPrice_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0.00";
            }
        }

    }
}
