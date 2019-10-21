using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace POS_SYSTEM
{
    public partial class frmLogin : Form
    {
        MySqlDataReader reader;
        MySqlCommand command;
        MySqlCommand cmd = new MySqlCommand();
        public static string user = "";
        public static string position = "";
        public static int loginid;
        private int isEnabled;
        public static string unamez = "";


        public frmLogin()
        {
            InitializeComponent();
            txtUsername.Text = frmLogin.unamez;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logIn();
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logIn();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        // ----------------------------------- Methods -----------------------------------




        private void logIn()
        {
            unamez = txtUsername.Text;
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT CONCAT(FirstName,' ',LastName) AS FullName, Position, loginid, isEnabled FROM " + DatabaseConnection.UsersTable + " WHERE username = @Username AND PassWord = MD5(@Password)";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user = reader["FullName"].ToString();
                        position = reader["Position"].ToString().ToUpper();
                        loginid = Convert.ToInt32(reader["loginid"]);
                        loginid = Convert.ToInt32(reader["loginid"]);
                        isEnabled = Convert.ToInt32(reader["isEnabled"]);
                    }
                    reader.Close();
                    command.Dispose();



                    if (user == "")
                    {
                        MessageBox.Show("Invalid login details", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtUsername.Focus();

                        string queryinvalid = "call invalidLogin(@Username);";
                        command = new MySqlCommand(queryinvalid, connection);
                        command.Parameters.AddWithValue("@Username", txtUsername.Text);
                        reader = command.ExecuteReader();
                        command.Dispose();
                    }
                    else if (isEnabled == 0)
                    {
                        MessageBox.Show("Your account is deactivated. Sad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtUsername.Focus();
                    }
                    else
                    {
                        frmMain frmMain = new frmMain();
                        this.Hide();
                        frmMain.Show();
                    }
                    user = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connection.Close();
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            unamez = this.txtUsername.Text;
            frmForgotPassword frmForgotPassword = new frmForgotPassword();
            this.Hide();
            frmForgotPassword.ShowDialog();
            this.Show();
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
                this.Opacity = 0.8;
                this.Update();
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Opacity = 1;
        }

        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}