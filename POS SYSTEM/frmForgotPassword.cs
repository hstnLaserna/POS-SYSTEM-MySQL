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
    public partial class frmForgotPassword : Form
    {
        MySqlDataReader reader;
        MySqlCommand command;
        string password ="";
        string uname = "";



        public frmForgotPassword()
        {
            InitializeComponent();
            this.txtUsername.Text = frmLogin.uname;
        }


        private void openDB()
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseConnection.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT tempopw, username FROM " + DatabaseConnection.UsersTable + " WHERE username = @Uname AND answer1 = @Answer1 OR answer2 = @Answer2; ";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Uname", txtUsername.Text);
                    command.Parameters.AddWithValue("@Answer1", txtAnswer1.Text);
                    command.Parameters.AddWithValue("@Answer2", txtAnswer2.Text);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        uname = reader["username"].ToString();
                    }
                    reader.Close();
                    command.Dispose();



                    if (uname != "")
                    {


                        string query2 = "UPDATE " + DatabaseConnection.UsersTable + " SET tempopw=(SELECT substring(MD5(RAND()), -4)) WHERE username=@Uname;" +
                            "UPDATE " + DatabaseConnection.UsersTable + " SET password=MD5(tempopw), isEnabled = 1, log_attempts = 0 WHERE username=@Uname;" +
                            "SELECT tempopw FROM " + DatabaseConnection.UsersTable + " WHERE username = @Uname" ;
                        command = new MySqlCommand(query2, connection);
                        command.Parameters.AddWithValue("@Uname", uname);
                        reader = command.ExecuteReader();


                        while (reader.Read())
                        {
                            password = reader["tempopw"].ToString();
                        }

                        reader.Close();
                        command.Dispose();


                        MessageBox.Show("Your temporary password is : " + password, "Reset password successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.ResetText();
                        txtAnswer1.ResetText();
                        txtAnswer2.ResetText();
                        uname = "";
                        frmLogin.uname = this.txtUsername.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username and Answers did not match!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            openDB();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin.uname = this.txtUsername.Text;
            this.Close();
        }

        private void form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                openDB();
            }
        }

        public void txtBoxes_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        public void txtBoxes_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                btnSubmit.Enabled = true;
            }
        }





        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.R))
            {
                openDB();
                return true;
            }


            // CLOSING

            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            if (keyData == (Keys.Alt | Keys.F12))
            {
                Application.Exit();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
