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
    public partial class frmUsersManager : Form
    {
        MySqlDataAdapter mySqlDataAdapter;
        MySqlDataReader reader;
        MySqlCommand command;
        string position;
        int isEnabled = 1;
        int selectedID = 0;



        public frmUsersManager()
        {
            InitializeComponent();
            openDB();
        }


        private void frmUsersManager_Load(object sender, EventArgs e)
        {
            formResize();
            initializeDisplay();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void txtBoxes_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstname.TextLength > 0 && txtLastname.TextLength > 0 && txtUsername.TextLength >= 4 && txtPassword.TextLength > 3 && txtAnswer1.TextLength >= 4 && txtAnswer2.TextLength >= 4)
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void showPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void showPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '●';
        }

        private void textBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }


        private void textBoxesName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(btnUpdate.Text == "UPDATE")
            {
                if (txtUsername.TextLength > 4 && txtPassword.TextLength > 3)
                {
                    var exists = dgvUsers.Rows.Cast<DataGridViewRow>()
                                 .Where(row => !row.IsNewRow)
                                 .Select(row => row.Cells[0].Value.ToString())
                                 .Any(x => this.txtID.Text == x);

                    if (exists)
                    {
                        using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                        {
                            string samp = "wtf";
                            MessageBox.Show(txtUsername.Text + "\n" + samp + "     " + selectedID);
                            connection.Open();
                            try
                            {
                                string query = "CALL updateUser(@Username, @Password, @Firstname, @Lastname, @Position, @Answer1, @Answer2, @Enabled, @selectedid); SELECT tempopw FROM " + DatabaseConnection.UsersTable + " WHERE loginid = @selectedid";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                                command.Parameters.AddWithValue("@Password", txtPassword.Text);
                                command.Parameters.AddWithValue("@Firstname", txtFirstname.Text.Trim());
                                command.Parameters.AddWithValue("@Lastname", txtLastname.Text.Trim());
                                command.Parameters.AddWithValue("@Position", position);
                                command.Parameters.AddWithValue("@Answer1", txtAnswer1.Text.Trim());
                                command.Parameters.AddWithValue("@Answer2", txtAnswer2.Text.Trim());
                                command.Parameters.AddWithValue("@Enabled", isEnabled);
                                command.Parameters.AddWithValue("@selectedid", selectedID);
                                reader = command.ExecuteReader();


                                while (reader.Read())
                                {
                                    samp = reader["tempopw"].ToString();
                                }

                                MessageBox.Show(txtUsername.Text + "\n" + samp + "     " + selectedID
                                    + "\n" + txtUsername.Text
                                    + "\n" + txtPassword.Text
                                    + "\n" + txtFirstname.Text
                                    + "\n" + txtLastname.Text
                                    + "\n" + position
                                    + "\n" + txtAnswer1.Text
                                    + "\n" + txtAnswer2.Text
                                    + "\n" + isEnabled
                                    + "\n" + selectedID
                                    );

                                reader.Close();
                                command.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            connection.Close();
                            initializeDisplay();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please select a user");
                    }
                }
                else
                {
                    MessageBox.Show("Username and Password must be 4 or more characters");
                }
            }
            else
            {
                if (txtUsername.TextLength > 4 && txtPassword.TextLength > 3)
                {
                    var exists = dgvUsers.Rows.Cast<DataGridViewRow>()
                                 .Where(row => !row.IsNewRow)
                                 .Select(row => row.Cells[0].Value.ToString())
                                 .Any(x => this.txtUsername.Text == x);

                    if (!exists)
                    {
                        using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
                        {
                            connection.Open();
                            try
                            {
                                string query = "CALL addUser(@Username, @Password, @Firstname, @Lastname, @Position, @Answer1, @Answer2, @Enabled);";
                                command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Username", txtUsername.Text);
                                command.Parameters.AddWithValue("@Password", txtPassword.Text);
                                command.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
                                command.Parameters.AddWithValue("@Lastname", txtLastname.Text);
                                command.Parameters.AddWithValue("@Position", position);
                                command.Parameters.AddWithValue("@Answer1", txtAnswer1.Text);
                                command.Parameters.AddWithValue("@Answer2", txtAnswer2.Text);
                                command.Parameters.AddWithValue("@Enabled", isEnabled);
                                reader = command.ExecuteReader();
                                reader.Close();
                                command.Dispose();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            connection.Close();
                            initializeDisplay();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username already exists!");
                    }
                }
                else
                {
                    MessageBox.Show("Username and Password must be 4 or more characters");
                }
            }
        }

        // --------------------- METHODS ---------------------

        private void initializeDisplay()
        {
            position = "Cashier";
            dgvUsers.ClearSelection();
            txtUsername.ResetText();
            txtPassword.ResetText();
            txtFirstname.ResetText();
            txtLastname.ResetText();
            txtID.ResetText();
            txtAnswer1.ResetText();
            txtAnswer2.ResetText();
            chkEnabled.Checked = true;
            radCashier.Checked = true;
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
                    mySqlDataAdapter = new MySqlDataAdapter("SELECT loginid 'UserID', username 'Username', firstname 'First Name', lastname 'Last Name', position 'Position', answer1 'Security 1', answer2 'Security 2', isEnabled 'Enabled', tempopw 'Tempo Pass' FROM " + DatabaseConnection.UsersTable + " WHERE POSITION = 'admin' or POSITION = 'cashier';", connection);
                    DataSet DS = new DataSet();
                    mySqlDataAdapter.Fill(DS);
                    dgvUsers.DataSource = DS.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                connection.Close();
            }
        }

        private void formResize()
        {
            btnBack.Location = new System.Drawing.Point(this.ClientRectangle.Width - btnBack.Width - 10, this.ClientRectangle.Height - btnBack.Height - 10);
            groupBox1.Location = new System.Drawing.Point(this.ClientRectangle.Width - groupBox1.Width - 10, dgvUsers.Location.Y);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvUsers.Rows[e.RowIndex];

                //populate the textbox from specific value of the coordinates of column and row.
                selectedID = Convert.ToInt32(row.Cells[0].Value);
                txtID.Text = selectedID.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtFirstname.Text = row.Cells[2].Value.ToString();
                txtLastname.Text = row.Cells[3].Value.ToString();
                txtAnswer1.Text = row.Cells[5].Value.ToString();
                txtAnswer2.Text = row.Cells[6].Value.ToString();
                txtPassword.Text = "";


                switch (row.Cells[4].Value.ToString().ToLower())
                {
                    case "developer":
                        break;
                    case "admin":
                        radAdmin.Checked = true;
                        radCashier.Checked = false;
                        break;
                    case "cashier":
                        radAdmin.Checked = false;
                        radCashier.Checked = true;
                        break;
                    default:
                        break;
                }

                if(Convert.ToBoolean(row.Cells[7].Value) == true)
                {
                    chkEnabled.Checked = true;
                }
                else
                {
                    chkEnabled.Checked = false;
                }
            }
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

        private void TextBoxes_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TextBoxes_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void positionCheckedChanged(object sender, EventArgs e)
        {
            position = ((RadioButton)sender).Text;
        }

        private void txtBoxes_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = Regex.Replace(((TextBox)sender).Text.Trim(), @"\s+", " ");
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "0")
            {
                txtID.Text = "";
            }
            else {}

            if(txtID.Text == "")
            {
                btnUpdate.Text = "SAVE";
            }
            else
            {
                btnUpdate.Text = "UPDATE";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            initializeDisplay();
        }
    }
}
