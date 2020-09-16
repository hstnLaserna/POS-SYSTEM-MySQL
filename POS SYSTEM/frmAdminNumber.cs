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

namespace POS_SYSTEM
{
    public partial class frmAdminNumber : Form
    {
        bool adminValid;
        int validatedAdmin;
        MySqlDataReader reader;
        MySqlCommand command;
        MySqlCommand cmd = new MySqlCommand();

        public frmAdminNumber()
        {
            InitializeComponent();

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtAdminID.TextLength == 8)
            {
                validateAdmin(Convert.ToInt32(txtAdminID.Text));
            }
            else
            {
                txtAdminID.SelectAll();
            }
            this.Close();
        }

        private void validateAdmin(int adminNumber)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT loginid FROM " + DatabaseConnection.UsersTable + " WHERE loginid = @adminNumber;";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", adminNumber);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["loginid"] == null)
                        {
                            MessageBox.Show("Invalid admin", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAdminID.Clear();
                            txtAdminID.Focus();
                        }
                        else
                        {
                            validatedAdmin = Convert.ToInt32(reader["loginid"]);
                            this.Close();
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
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


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


        private void txtAdminID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }
    }
}
