namespace POS_SYSTEM
{
    partial class frmAddonsManager
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddonName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listProductType = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.dgvAddons = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFrappe = new System.Windows.Forms.CheckBox();
            this.chkMilkshake = new System.Windows.Forms.CheckBox();
            this.chkMilktea = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).BeginInit();
            this.grpFilter.SuspendLayout();
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
            this.lblHeader.Size = new System.Drawing.Size(239, 35);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Manage Products";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "For Product:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Addon name:";
            // 
            // txtAddonName
            // 
            this.txtAddonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddonName.Location = new System.Drawing.Point(228, 86);
            this.txtAddonName.MaxLength = 20;
            this.txtAddonName.Name = "txtAddonName";
            this.txtAddonName.Size = new System.Drawing.Size(263, 30);
            this.txtAddonName.TabIndex = 1;
            this.txtAddonName.Click += new System.EventHandler(this.TextBoxes_Enter);
            this.txtAddonName.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            this.txtAddonName.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtAddonName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextName_KeyPress);
            this.txtAddonName.Leave += new System.EventHandler(this.TextBoxes_Leave);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(140)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(147, 275);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(144, 60);
            this.btnUpdate.TabIndex = 7;
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
            this.chkEnabled.Location = new System.Drawing.Point(228, 242);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(18, 17);
            this.chkEnabled.TabIndex = 6;
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPrice1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.listProductType);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkEnabled);
            this.groupBox1.Controls.Add(this.txtAddonName);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1042, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 24);
            this.label1.TabIndex = 10007;
            this.label1.Text = "Clear details before creating new addon";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(223, 349);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 25);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(146, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Price:";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice1.Location = new System.Drawing.Point(228, 121);
            this.txtPrice1.MaxLength = 10;
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(263, 30);
            this.txtPrice1.TabIndex = 2;
            this.txtPrice1.Click += new System.EventHandler(this.TextBoxes_Enter);
            this.txtPrice1.TextChanged += new System.EventHandler(this.TextBoxes_TextChanged);
            this.txtPrice1.Enter += new System.EventHandler(this.TextBoxes_Enter);
            this.txtPrice1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPrice_KeyPress);
            this.txtPrice1.Leave += new System.EventHandler(this.TextBoxPrice_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "AddOn is Available:";
            // 
            // listProductType
            // 
            this.listProductType.FormattingEnabled = true;
            this.listProductType.ItemHeight = 25;
            this.listProductType.Items.AddRange(new object[] {
            "Milktea",
            "Milkshake",
            "Frappe"});
            this.listProductType.Location = new System.Drawing.Point(228, 157);
            this.listProductType.Name = "listProductType";
            this.listProductType.Size = new System.Drawing.Size(263, 79);
            this.listProductType.TabIndex = 5;
            this.listProductType.SelectedValueChanged += new System.EventHandler(this.listProductType_SelectedValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(347, 275);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 60);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(106, 54);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(100, 25);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Addon ID:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(228, 51);
            this.txtID.MaxLength = 20;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(263, 30);
            this.txtID.TabIndex = 0;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // dgvAddons
            // 
            this.dgvAddons.AllowUserToAddRows = false;
            this.dgvAddons.AllowUserToDeleteRows = false;
            this.dgvAddons.AllowUserToResizeColumns = false;
            this.dgvAddons.AllowUserToResizeRows = false;
            this.dgvAddons.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgvAddons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddons.Location = new System.Drawing.Point(33, 70);
            this.dgvAddons.MultiSelect = false;
            this.dgvAddons.Name = "dgvAddons";
            this.dgvAddons.ReadOnly = true;
            this.dgvAddons.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAddons.RowTemplate.Height = 24;
            this.dgvAddons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddons.Size = new System.Drawing.Size(915, 625);
            this.dgvAddons.TabIndex = 0;
            this.dgvAddons.TabStop = false;
            this.dgvAddons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddons_CellClick);
            this.dgvAddons.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvAddons_RowPostPaint);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(1452, 624);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 47);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Adobe Gothic Std B", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.label7.Location = new System.Drawing.Point(274, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 35);
            this.label7.TabIndex = 0;
            this.label7.Text = "- Addons";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.label2);
            this.grpFilter.Controls.Add(this.chkFrappe);
            this.grpFilter.Controls.Add(this.chkMilkshake);
            this.grpFilter.Controls.Add(this.chkMilktea);
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(1042, 461);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(521, 151);
            this.grpFilter.TabIndex = 15;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Display Product:";
            // 
            // chkFrappe
            // 
            this.chkFrappe.AutoSize = true;
            this.chkFrappe.Checked = true;
            this.chkFrappe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFrappe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFrappe.Location = new System.Drawing.Point(228, 112);
            this.chkFrappe.Name = "chkFrappe";
            this.chkFrappe.Size = new System.Drawing.Size(96, 29);
            this.chkFrappe.TabIndex = 11;
            this.chkFrappe.Text = "Frappe";
            this.chkFrappe.UseVisualStyleBackColor = true;
            this.chkFrappe.CheckStateChanged += new System.EventHandler(this.chkProducts_CheckStateChanged);
            // 
            // chkMilkshake
            // 
            this.chkMilkshake.AutoSize = true;
            this.chkMilkshake.Checked = true;
            this.chkMilkshake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMilkshake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMilkshake.Location = new System.Drawing.Point(228, 77);
            this.chkMilkshake.Name = "chkMilkshake";
            this.chkMilkshake.Size = new System.Drawing.Size(122, 29);
            this.chkMilkshake.TabIndex = 10;
            this.chkMilkshake.Text = "Milkshake";
            this.chkMilkshake.UseVisualStyleBackColor = true;
            this.chkMilkshake.CheckStateChanged += new System.EventHandler(this.chkProducts_CheckStateChanged);
            // 
            // chkMilktea
            // 
            this.chkMilktea.AutoSize = true;
            this.chkMilktea.Checked = true;
            this.chkMilktea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMilktea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMilktea.Location = new System.Drawing.Point(228, 42);
            this.chkMilktea.Name = "chkMilktea";
            this.chkMilktea.Size = new System.Drawing.Size(96, 29);
            this.chkMilktea.TabIndex = 9;
            this.chkMilktea.Text = "Milktea";
            this.chkMilktea.UseVisualStyleBackColor = true;
            this.chkMilktea.CheckStateChanged += new System.EventHandler(this.chkProducts_CheckStateChanged);
            // 
            // frmAddonsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1596, 771);
            this.ControlBox = false;
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvAddons);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmAddonsManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Addons";
            this.Load += new System.EventHandler(this.frmAddonsManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddons)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddonName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAddons;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listProductType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFrappe;
        private System.Windows.Forms.CheckBox chkMilkshake;
        private System.Windows.Forms.CheckBox chkMilktea;

    }
}