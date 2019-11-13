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
    public partial class frmAddonsManager : Form
    {
        MySqlDataReader reader;
        MySqlCommand command;
        int isEnabled = 1;
        int selectedID = 0;
        string msg;

        private MySqlDataAdapter mySqlDataAdapter;


        public frmAddonsManager()
        {
            InitializeComponent();
            openDB();
        }


        private void frmAddonsManager_Load(object sender, EventArgs e)
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
            if ((txtAddonName.TextLength > 0) && (txtPrice1.TextLength > 0))
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
            processAddons();
        }

        private void processAddons()
        {
            if (btnUpdate.Text == "UPDATE")
            {
                if (txtAddonName.TextLength >= 4)
                {
                    var exists = dgvAddons.Rows.Cast<DataGridViewRow>()
                                 .Where(row => !row.IsNewRow)
                                 .Select(row => row.Cells[0].Value.ToString())
                                 .Any(x => this.txtID.Text == x);
                    if (exists)
                    {
                        using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                        {
                            int activatedAddOns = 0;
                            connection.Open();
                            try
                            {
                                string query = "SELECT COUNT(*) as activatedAddOns from " + DatabaseConnection.AddonsTable + " where forProductType = @ForProductType AND isavailable = 1;";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@ForProductType", listProductType.SelectedItem.ToString());
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    activatedAddOns = Convert.ToInt32(reader["activatedAddOns"]);
                                }

                                reader.Close();
                                command.Dispose();

                                MessageBox.Show(activatedAddOns.ToString());
                                string queryUpdate = "";

                                if (activatedAddOns >= 0 && activatedAddOns < 6)
                                {
                                    queryUpdate = "CALL updateAddOns(@ProductName, @Price1, @ForProductType, @isAvailable, @SelectedID);";

                                    if (activatedAddOns == 6 && chkEnabled.Checked == true)
                                    {
                                        MessageBox.Show("Maximum (6) available AddOns for product: \n" + listProductType.SelectedItem.ToString() + "\n has been reached!", "Maxed Available Addons", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }
                                else
                                {
                                    // Still update records. But isEnabled will be hard to 0
                                    queryUpdate = "CALL updateAddOns(@ProductName, @Price1, @ForProductType, 0, @SelectedID);";
                                    if (chkEnabled.Checked == true)
                                    {
                                        MessageBox.Show("Limit Exceeded. \n Available addons for each product must not exceed 6!", "Maxed Available Addons", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }


                                command = new MySqlCommand(queryUpdate, connection);
                                command.Parameters.AddWithValue("@Productname", txtAddonName.Text);
                                command.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                                command.Parameters.AddWithValue("@ForProductType", listProductType.SelectedItem.ToString());
                                command.Parameters.AddWithValue("@isAvailable", isEnabled);
                                command.Parameters.AddWithValue("@SelectedID", selectedID);
                                reader = command.ExecuteReader();
                                reader.Close();
                                command.Dispose();
                                msg = "Addon: '" + txtAddonName.Text + "' updated!";
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
                                    MessageBox.Show("Unable to update. \nThe Addon name: " + txtAddonName.Text.ToUpper() + " already exists. \n Error #: -2147467259 xxx");
                                }
                            }
                            connection.Close();
                            initializeDisplay();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an Addon");
                    }
                }
                else
                {
                    MessageBox.Show("Addon must be 4 or more characters");
                }
            }
            else
            {
                if (txtAddonName.TextLength >= 4)
                {
                    var nameExists = dgvAddons.Rows.Cast<DataGridViewRow>()
                                 .Where(row => !row.IsNewRow)
                                 .Select(row => row.Cells[1].Value.ToString())
                                 .Any(x => this.txtAddonName.Text == x);

                    if (!nameExists)
                    {
                        using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                        {
                            int activatedAddOns = 0;
                            connection.Open();
                            try
                            {
                                string query = "SELECT COUNT(*) as activatedAddOns FROM " + DatabaseConnection.AddonsTable + " WHERE forProductType = @ForProductType AND isavailable = 1;";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@ForProductType", listProductType.SelectedItem.ToString());
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    activatedAddOns = Convert.ToInt32(reader["activatedAddOns"]);
                                }

                                reader.Close();
                                command.Dispose();

                                MessageBox.Show(activatedAddOns.ToString());

                                if (activatedAddOns == 6)
                                {
                                    isEnabled = 0;
                                    MessageBox.Show("Maximum available addons for " + listProductType.SelectedItem.ToString() + " reached! \nAvailability set to NO");
                                }
                                else
                                { }


                                string queryUpdate = "CALL addAddOns(@ProductName, @Price1, @ForProductType, @isAvailable);";
                                command = new MySqlCommand(queryUpdate, connection);
                                command.Parameters.AddWithValue("@Productname", txtAddonName.Text);
                                command.Parameters.AddWithValue("@Price1", txtPrice1.Text);
                                command.Parameters.AddWithValue("@ForProductType", listProductType.SelectedItem.ToString());
                                command.Parameters.AddWithValue("@isAvailable", isEnabled);
                                reader = command.ExecuteReader();
                                reader.Close();
                                command.Dispose();
                                msg = "Addon " + txtAddonName.Text + " added!";

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


        private void dgvAddons_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dgvAddons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvAddons.Rows[e.RowIndex];

                //populate the textbox from specific value of the coordinates of column and row.
                selectedID = Convert.ToInt32(row.Cells[0].Value);
                txtID.Text = selectedID.ToString();
                txtAddonName.Text = row.Cells[1].Value.ToString();
                txtPrice1.Text = row.Cells[2].Value.ToString();

                switch (row.Cells[3].Value.ToString().ToLower())
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

                if (Convert.ToBoolean(row.Cells[4].Value) == true)
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
            dgvAddons.ClearSelection();
            txtID.ResetText();
            txtAddonName.ResetText();
            txtPrice1.ResetText();
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
                    mySqlDataAdapter = new MySqlDataAdapter("SELECT addonID '#', name 'Addons', price 'Price', forProductType 'AddOn for', isAvailable FROM " + DatabaseConnection.AddonsTable + ";", connection);
                    DataSet DS = new DataSet();
                    mySqlDataAdapter.Fill(DS);
                    dgvAddons.DataSource = DS.Tables[0];


                    dgvAddons.Columns.RemoveAt(4);
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.HeaderText = "Addon Available";
                    chk.Name = "isAvailable";
                    chk.DataPropertyName = "isAvailable";
                    dgvAddons.Columns.Insert(4, chk);
                    dgvAddons.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvAddons.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvAddons.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                connection.Close();
            }

            dgvAddons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void formResize()
        {
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
            groupBox1.Location = new System.Drawing.Point(this.ClientRectangle.Width - groupBox1.Width - 10, dgvAddons.Location.Y);
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



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.N) || keyData == (Keys.Alt | Keys.U))
            {
                if (btnUpdate.Enabled)
                {
                    processAddons();
                }
                return true;
            }

            if (keyData == (Keys.Alt | Keys.C))
            {
                initializeDisplay();
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
