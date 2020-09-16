namespace POS_SYSTEM
{
    partial class frmAdminNumber
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAdminID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.DarkGray;
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(396, 106);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(324, 60);
            this.btnAccept.TabIndex = 15;
            this.btnAccept.Text = "ACCEPT";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(66, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(324, 60);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtAdminID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(33, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 54);
            this.panel1.TabIndex = 18;
            // 
            // txtAdminID
            // 
            this.txtAdminID.Enabled = false;
            this.txtAdminID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminID.Location = new System.Drawing.Point(231, 9);
            this.txtAdminID.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdminID.MaxLength = 8;
            this.txtAdminID.Name = "txtAdminID";
            this.txtAdminID.PasswordChar = '•';
            this.txtAdminID.Size = new System.Drawing.Size(474, 30);
            this.txtAdminID.TabIndex = 36;
            this.txtAdminID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdminID_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "Enter Adminstrator ID:";
            // 
            // frmAdminNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(783, 202);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminNumber";
            this.Tag = "10";
            this.Text = "Cash window";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAdminID;
    }
}