namespace POS_SYSTEM
{
    partial class frmDiscount
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
            this.lstDiscountType = new System.Windows.Forms.ListBox();
            this.txtDiscountName = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.txtDiscountValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(140)))));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(110, 251);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(324, 60);
            this.btnAccept.TabIndex = 15;
            this.btnAccept.Text = "ACCEPT";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Bisque;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(110, 317);
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
            this.panel1.Controls.Add(this.lstDiscountType);
            this.panel1.Controls.Add(this.txtDiscountName);
            this.panel1.Controls.Add(this.lblPercent);
            this.panel1.Controls.Add(this.txtDiscountValue);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(33, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 204);
            this.panel1.TabIndex = 18;
            // 
            // lstDiscountType
            // 
            this.lstDiscountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDiscountType.FormattingEnabled = true;
            this.lstDiscountType.ItemHeight = 25;
            this.lstDiscountType.Items.AddRange(new object[] {
            "Senior Citizen",
            "PWD",
            "Other:"});
            this.lstDiscountType.Location = new System.Drawing.Point(28, 66);
            this.lstDiscountType.Margin = new System.Windows.Forms.Padding(2);
            this.lstDiscountType.Name = "lstDiscountType";
            this.lstDiscountType.Size = new System.Drawing.Size(316, 79);
            this.lstDiscountType.TabIndex = 44;
            this.lstDiscountType.SelectedIndexChanged += new System.EventHandler(this.listProductType_SelectedIndexChanged);
            // 
            // txtDiscountName
            // 
            this.txtDiscountName.Enabled = false;
            this.txtDiscountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountName.Location = new System.Drawing.Point(28, 149);
            this.txtDiscountName.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiscountName.MaxLength = 20;
            this.txtDiscountName.Name = "txtDiscountName";
            this.txtDiscountName.Size = new System.Drawing.Size(316, 30);
            this.txtDiscountName.TabIndex = 36;
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(427, 69);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(31, 25);
            this.lblPercent.TabIndex = 46;
            this.lblPercent.Text = "%";
            // 
            // txtDiscountValue
            // 
            this.txtDiscountValue.Enabled = false;
            this.txtDiscountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountValue.Location = new System.Drawing.Point(357, 66);
            this.txtDiscountValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiscountValue.MaxLength = 3;
            this.txtDiscountValue.Name = "txtDiscountValue";
            this.txtDiscountValue.Size = new System.Drawing.Size(67, 30);
            this.txtDiscountValue.TabIndex = 45;
            this.txtDiscountValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountValue_KeyPress);
            this.txtDiscountValue.Leave += new System.EventHandler(this.txtDiscountValue_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "Discount Type:";
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(567, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDiscount";
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
        private System.Windows.Forms.TextBox txtDiscountName;
        private System.Windows.Forms.ListBox lstDiscountType;
        private System.Windows.Forms.TextBox txtDiscountValue;
        private System.Windows.Forms.Label lblPercent;
    }
}