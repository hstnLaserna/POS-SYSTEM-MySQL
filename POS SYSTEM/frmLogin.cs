﻿using System;
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
using System.Threading;
using System.Reflection;
using System.Diagnostics;

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
        public static string uname = "";
        int counter = 0;



        
        public frmLogin()
        {
            InitializeComponent();
            txtUsername.Text = frmLogin.uname;

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;

            lblVersion.Text = "v" + version;
            lblVersion.Location = new Point(panel1.Width - lblVersion.Width - 5, panel1.Height - lblVersion.Height - 5);
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
            uname = txtUsername.Text;
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CONCAT(LastName, ', ', FirstName) AS FullName, Position, loginid, isEnabled FROM " + DatabaseConnection.UsersTable + " WHERE username = @Username AND PassWord = MD5(@Password)";
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
            uname = this.txtUsername.Text;
            frmForgotPassword frmForgotPassword = new frmForgotPassword();
            frmForgotPassword.ShowDialog();
            this.Show();
        }



        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(ClientSize.Width);
            panel1.Location = new System.Drawing.Point(ClientSize.Width / 2 - (panel1.Size.Width / 2), ClientSize.Height / 2 - (panel1.Size.Height / 2));

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            counter = 0;
            if (txtServer.TextLength == 0 || txtSchema.TextLength == 0)
            {
                txtServer.Visible = false;
                txtSchema.Visible = false;
            }
        }

        private void TextChangeConnection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DatabaseConnection.server = txtServer.Text;
                DatabaseConnection.schema = txtSchema.Text;
                DatabaseConnection.connectionString = @"server=" + DatabaseConnection.server + ";database=" + DatabaseConnection.schema + ";uid=" + DatabaseConnection.dbuser + ";pwd=" + DatabaseConnection.dbpassword + "";
                txtServer.Visible = false;
                txtSchema.Visible = false;
                txtUsername.Text = DatabaseConnection.server;
            }
        }

        private void picLogo_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            counter++;
            if (counter == 5)
            {
                txtServer.Text = DatabaseConnection.server;
                txtServer.Visible = true;
                txtSchema.Text = DatabaseConnection.schema;
                txtSchema.Visible = true;
                txtServer.Select();
            }
            timer1.Enabled = true;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F))
            {
                uname = this.txtUsername.Text;
                frmForgotPassword frmForgotPassword = new frmForgotPassword();
                frmForgotPassword.ShowDialog();
                this.Show();
                return true;
            }


            // CLOSING
            if (keyData == (Keys.Alt | Keys.F12))
            {
                Application.Exit();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}