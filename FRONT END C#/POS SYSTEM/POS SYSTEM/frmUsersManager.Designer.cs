namespace POS_SYSTEM
{
    partial class frmUsersManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.radCashier = new System.Windows.Forms.RadioButton();
            this.radAdmin = new System.Windows.Forms.RadioButton();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.lblSecurity1 = new System.Windows.Forms.Label();
            this.lblSecurity2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Adobe Gothic Std B", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.lblHeader.Location = new System.Drawing.Point(27, 25);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(194, 35);
            this.lblHeader.TabIndex = 30;
            this.lblHeader.Text = "Manage Users";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Firstname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Lastname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 33;
            this.label3.Text = "Type of User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "Password:";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassword_MouseDown);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassword_MouseUp);
            // 
            // txtFirstname
            // 
            this.txtFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstname.Location = new System.Drawing.Point(228, 158);
            this.txtFirstname.MaxLength = 50;
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(263, 30);
            this.txtFirstname.TabIndex = 6;
            this.txtFirstname.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            this.txtFirstname.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxesName_KeyPress);
            this.txtFirstname.Leave += new System.EventHandler(this.txtBoxes_Leave);
            // 
            // txtLastname
            // 
            this.txtLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastname.Location = new System.Drawing.Point(228, 193);
            this.txtLastname.MaxLength = 50;
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(263, 30);
            this.txtLastname.TabIndex = 7;
            this.txtLastname.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            this.txtLastname.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxesName_KeyPress);
            this.txtLastname.Leave += new System.EventHandler(this.txtBoxes_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(228, 87);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(263, 30);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Click += new System.EventHandler(this.TextBoxes_Click);
            this.txtUsername.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            this.txtUsername.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(140)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(150, 375);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(144, 60);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "NEW";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnabled.Location = new System.Drawing.Point(228, 339);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(18, 17);
            this.chkEnabled.TabIndex = 12;
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.radCashier);
            this.groupBox1.Controls.Add(this.radAdmin);
            this.groupBox1.Controls.Add(this.txtAnswer1);
            this.groupBox1.Controls.Add(this.txtAnswer2);
            this.groupBox1.Controls.Add(this.lblSecurity1);
            this.groupBox1.Controls.Add(this.lblSecurity2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkEnabled);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFirstname);
            this.groupBox1.Controls.Add(this.txtLastname);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1352, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 455);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 10005;
            this.label6.Text = "User is Enabled:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(350, 375);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 60);
            this.btnClear.TabIndex = 10002;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(124, 54);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(83, 25);
            this.lblID.TabIndex = 10001;
            this.lblID.Text = "User ID:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(228, 51);
            this.txtID.MaxLength = 20;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(263, 30);
            this.txtID.TabIndex = 10000;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // radCashier
            // 
            this.radCashier.AutoSize = true;
            this.radCashier.Checked = true;
            this.radCashier.Location = new System.Drawing.Point(228, 231);
            this.radCashier.Name = "radCashier";
            this.radCashier.Size = new System.Drawing.Size(101, 29);
            this.radCashier.TabIndex = 8;
            this.radCashier.TabStop = true;
            this.radCashier.Tag = "";
            this.radCashier.Text = "Cashier";
            this.radCashier.UseVisualStyleBackColor = true;
            this.radCashier.CheckedChanged += new System.EventHandler(this.positionCheckedChanged);
            // 
            // radAdmin
            // 
            this.radAdmin.AutoSize = true;
            this.radAdmin.Location = new System.Drawing.Point(352, 231);
            this.radAdmin.Name = "radAdmin";
            this.radAdmin.Size = new System.Drawing.Size(89, 29);
            this.radAdmin.TabIndex = 9;
            this.radAdmin.Tag = "";
            this.radAdmin.Text = "Admin";
            this.radAdmin.UseVisualStyleBackColor = true;
            this.radAdmin.CheckedChanged += new System.EventHandler(this.positionCheckedChanged);
            // 
            // txtAnswer1
            // 
            this.txtAnswer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer1.Location = new System.Drawing.Point(228, 265);
            this.txtAnswer1.MaxLength = 20;
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(263, 30);
            this.txtAnswer1.TabIndex = 10;
            this.txtAnswer1.Click += new System.EventHandler(this.TextBoxes_Click);
            this.txtAnswer1.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            this.txtAnswer1.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtAnswer1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            this.txtAnswer1.Leave += new System.EventHandler(this.txtBoxes_Leave);
            // 
            // txtAnswer2
            // 
            this.txtAnswer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer2.Location = new System.Drawing.Point(228, 300);
            this.txtAnswer2.MaxLength = 20;
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(263, 30);
            this.txtAnswer2.TabIndex = 11;
            this.txtAnswer2.Click += new System.EventHandler(this.TextBoxes_Click);
            this.txtAnswer2.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            this.txtAnswer2.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtAnswer2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            this.txtAnswer2.Leave += new System.EventHandler(this.txtBoxes_Leave);
            // 
            // lblSecurity1
            // 
            this.lblSecurity1.AutoSize = true;
            this.lblSecurity1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity1.Location = new System.Drawing.Point(31, 268);
            this.lblSecurity1.Name = "lblSecurity1";
            this.lblSecurity1.Size = new System.Drawing.Size(176, 25);
            this.lblSecurity1.TabIndex = 38;
            this.lblSecurity1.Text = "Security Answer 1:";
            // 
            // lblSecurity2
            // 
            this.lblSecurity2.AutoSize = true;
            this.lblSecurity2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity2.Location = new System.Drawing.Point(31, 303);
            this.lblSecurity2.Name = "lblSecurity2";
            this.lblSecurity2.Size = new System.Drawing.Size(176, 25);
            this.lblSecurity2.TabIndex = 39;
            this.lblSecurity2.Text = "Security Answer 2:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(228, 122);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(263, 30);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Click += new System.EventHandler(this.TextBoxes_Click);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxes_KeyPress);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(33, 70);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1303, 942);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            this.dgvUsers.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(1798, 1011);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 28);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmUsersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsersManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUsersManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmUsersManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.Label lblSecurity1;
        private System.Windows.Forms.Label lblSecurity2;
        private System.Windows.Forms.RadioButton radCashier;
        private System.Windows.Forms.RadioButton radAdmin;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;

    }
}