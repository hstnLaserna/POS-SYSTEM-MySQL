namespace POS_SYSTEM
{
    partial class frmAddProduct
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddProduct));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radSize1 = new System.Windows.Forms.RadioButton();
            this.radSize2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtn0P = new System.Windows.Forms.RadioButton();
            this.rbtn25P = new System.Windows.Forms.RadioButton();
            this.rbtn50P = new System.Windows.Forms.RadioButton();
            this.rbtn75P = new System.Windows.Forms.RadioButton();
            this.rbtn100P = new System.Windows.Forms.RadioButton();
            this.panelSize = new System.Windows.Forms.Panel();
            this.radSize3 = new System.Windows.Forms.RadioButton();
            this.panelSugarLevel = new System.Windows.Forms.Panel();
            this.panelQty = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.chkAddon6 = new System.Windows.Forms.CheckBox();
            this.chkAddon3 = new System.Windows.Forms.CheckBox();
            this.chkAddon2 = new System.Windows.Forms.CheckBox();
            this.chkAddon4 = new System.Windows.Forms.CheckBox();
            this.chkAddon1 = new System.Windows.Forms.CheckBox();
            this.lblAddOns = new System.Windows.Forms.Label();
            this.chkAddon5 = new System.Windows.Forms.CheckBox();
            this.panelAddOns = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.panelNote = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelSize.SuspendLayout();
            this.panelSugarLevel.SuspendLayout();
            this.panelQty.SuspendLayout();
            this.panelAddOns.SuspendLayout();
            this.panelNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "SIZE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "SUGAR LEVEL:";
            // 
            // radSize1
            // 
            this.radSize1.AutoSize = true;
            this.radSize1.Enabled = false;
            this.radSize1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSize1.Location = new System.Drawing.Point(14, 37);
            this.radSize1.Margin = new System.Windows.Forms.Padding(4);
            this.radSize1.Name = "radSize1";
            this.radSize1.Size = new System.Drawing.Size(99, 33);
            this.radSize1.TabIndex = 2;
            this.radSize1.TabStop = true;
            this.radSize1.Tag = "rb1";
            this.radSize1.Text = "Small";
            this.radSize1.UseVisualStyleBackColor = true;
            this.radSize1.CheckedChanged += new System.EventHandler(this.getSizePrice);
            this.radSize1.MouseHover += new System.EventHandler(this.size_MouseHover);
            // 
            // radSize2
            // 
            this.radSize2.AutoSize = true;
            this.radSize2.Enabled = false;
            this.radSize2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSize2.Location = new System.Drawing.Point(178, 36);
            this.radSize2.Margin = new System.Windows.Forms.Padding(4);
            this.radSize2.Name = "radSize2";
            this.radSize2.Size = new System.Drawing.Size(125, 33);
            this.radSize2.TabIndex = 3;
            this.radSize2.TabStop = true;
            this.radSize2.Tag = "rb2";
            this.radSize2.Text = "Medium";
            this.radSize2.UseVisualStyleBackColor = true;
            this.radSize2.CheckedChanged += new System.EventHandler(this.getSizePrice);
            this.radSize2.MouseHover += new System.EventHandler(this.size_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "QUANTITY:";
            // 
            // rbtn0P
            // 
            this.rbtn0P.AutoSize = true;
            this.rbtn0P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn0P.Location = new System.Drawing.Point(18, 45);
            this.rbtn0P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn0P.Name = "rbtn0P";
            this.rbtn0P.Size = new System.Drawing.Size(62, 29);
            this.rbtn0P.TabIndex = 13;
            this.rbtn0P.TabStop = true;
            this.rbtn0P.Text = "0%";
            this.rbtn0P.UseVisualStyleBackColor = true;
            this.rbtn0P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn25P
            // 
            this.rbtn25P.AutoSize = true;
            this.rbtn25P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn25P.Location = new System.Drawing.Point(97, 45);
            this.rbtn25P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn25P.Name = "rbtn25P";
            this.rbtn25P.Size = new System.Drawing.Size(73, 29);
            this.rbtn25P.TabIndex = 14;
            this.rbtn25P.TabStop = true;
            this.rbtn25P.Text = "25%";
            this.rbtn25P.UseVisualStyleBackColor = true;
            this.rbtn25P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn50P
            // 
            this.rbtn50P.AutoSize = true;
            this.rbtn50P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn50P.Location = new System.Drawing.Point(188, 45);
            this.rbtn50P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn50P.Name = "rbtn50P";
            this.rbtn50P.Size = new System.Drawing.Size(73, 29);
            this.rbtn50P.TabIndex = 15;
            this.rbtn50P.TabStop = true;
            this.rbtn50P.Text = "50%";
            this.rbtn50P.UseVisualStyleBackColor = true;
            this.rbtn50P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn75P
            // 
            this.rbtn75P.AutoSize = true;
            this.rbtn75P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn75P.Location = new System.Drawing.Point(280, 45);
            this.rbtn75P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn75P.Name = "rbtn75P";
            this.rbtn75P.Size = new System.Drawing.Size(73, 29);
            this.rbtn75P.TabIndex = 16;
            this.rbtn75P.TabStop = true;
            this.rbtn75P.Text = "75%";
            this.rbtn75P.UseVisualStyleBackColor = true;
            this.rbtn75P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn100P
            // 
            this.rbtn100P.AutoSize = true;
            this.rbtn100P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn100P.Location = new System.Drawing.Point(363, 45);
            this.rbtn100P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn100P.Name = "rbtn100P";
            this.rbtn100P.Size = new System.Drawing.Size(84, 29);
            this.rbtn100P.TabIndex = 17;
            this.rbtn100P.TabStop = true;
            this.rbtn100P.Text = "100%";
            this.rbtn100P.UseVisualStyleBackColor = true;
            this.rbtn100P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // panelSize
            // 
            this.panelSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelSize.Controls.Add(this.radSize3);
            this.panelSize.Controls.Add(this.radSize2);
            this.panelSize.Controls.Add(this.radSize1);
            this.panelSize.Controls.Add(this.label1);
            this.panelSize.Location = new System.Drawing.Point(16, 60);
            this.panelSize.Margin = new System.Windows.Forms.Padding(4);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(464, 73);
            this.panelSize.TabIndex = 1;
            // 
            // radSize3
            // 
            this.radSize3.AutoSize = true;
            this.radSize3.Enabled = false;
            this.radSize3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSize3.Location = new System.Drawing.Point(359, 36);
            this.radSize3.Margin = new System.Windows.Forms.Padding(4);
            this.radSize3.Name = "radSize3";
            this.radSize3.Size = new System.Drawing.Size(98, 33);
            this.radSize3.TabIndex = 4;
            this.radSize3.TabStop = true;
            this.radSize3.Tag = "rb2";
            this.radSize3.Text = "Large";
            this.radSize3.UseVisualStyleBackColor = true;
            this.radSize3.CheckedChanged += new System.EventHandler(this.getSizePrice);
            this.radSize3.MouseHover += new System.EventHandler(this.size_MouseHover);
            // 
            // panelSugarLevel
            // 
            this.panelSugarLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelSugarLevel.Controls.Add(this.rbtn100P);
            this.panelSugarLevel.Controls.Add(this.rbtn75P);
            this.panelSugarLevel.Controls.Add(this.rbtn50P);
            this.panelSugarLevel.Controls.Add(this.rbtn25P);
            this.panelSugarLevel.Controls.Add(this.rbtn0P);
            this.panelSugarLevel.Controls.Add(this.label2);
            this.panelSugarLevel.Location = new System.Drawing.Point(16, 291);
            this.panelSugarLevel.Margin = new System.Windows.Forms.Padding(4);
            this.panelSugarLevel.Name = "panelSugarLevel";
            this.panelSugarLevel.Size = new System.Drawing.Size(464, 82);
            this.panelSugarLevel.TabIndex = 12;
            // 
            // panelQty
            // 
            this.panelQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelQty.Controls.Add(this.txtQuantity);
            this.panelQty.Controls.Add(this.btnMinus);
            this.panelQty.Controls.Add(this.btnPlus);
            this.panelQty.Controls.Add(this.label4);
            this.panelQty.Location = new System.Drawing.Point(488, 60);
            this.panelQty.Margin = new System.Windows.Forms.Padding(4);
            this.panelQty.Name = "panelQty";
            this.panelQty.Size = new System.Drawing.Size(207, 149);
            this.panelQty.TabIndex = 19;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(13, 45);
            this.txtQuantity.MaxLength = 3;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(168, 40);
            this.txtQuantity.TabIndex = 19;
            this.txtQuantity.Text = "0";
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            this.txtQuantity.Leave += new System.EventHandler(this.txtQuantity_Leave);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMinus.Image = ((System.Drawing.Image)(resources.GetObject("btnMinus.Image")));
            this.btnMinus.Location = new System.Drawing.Point(51, 94);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(40, 40);
            this.btnMinus.TabIndex = 20;
            this.btnMinus.Tag = "minus";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.Transparent;
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlus.Image = ((System.Drawing.Image)(resources.GetObject("btnPlus.Image")));
            this.btnPlus.Location = new System.Drawing.Point(104, 94);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(40, 40);
            this.btnPlus.TabIndex = 21;
            this.btnPlus.Tag = "plus";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // chkAddon6
            // 
            this.chkAddon6.AutoSize = true;
            this.chkAddon6.Location = new System.Drawing.Point(236, 104);
            this.chkAddon6.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddon6.Name = "chkAddon6";
            this.chkAddon6.Size = new System.Drawing.Size(38, 21);
            this.chkAddon6.TabIndex = 11;
            this.chkAddon6.Text = "6";
            this.chkAddon6.UseVisualStyleBackColor = true;
            this.chkAddon6.CheckStateChanged += new System.EventHandler(this.getSinkers);
            this.chkAddon6.MouseHover += new System.EventHandler(this.addonHover);
            // 
            // chkAddon3
            // 
            this.chkAddon3.AutoSize = true;
            this.chkAddon3.Location = new System.Drawing.Point(18, 104);
            this.chkAddon3.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddon3.Name = "chkAddon3";
            this.chkAddon3.Size = new System.Drawing.Size(38, 21);
            this.chkAddon3.TabIndex = 8;
            this.chkAddon3.Text = "3";
            this.chkAddon3.UseVisualStyleBackColor = true;
            this.chkAddon3.CheckStateChanged += new System.EventHandler(this.getSinkers);
            this.chkAddon3.MouseHover += new System.EventHandler(this.addonHover);
            // 
            // chkAddon2
            // 
            this.chkAddon2.AutoSize = true;
            this.chkAddon2.Location = new System.Drawing.Point(18, 76);
            this.chkAddon2.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddon2.Name = "chkAddon2";
            this.chkAddon2.Size = new System.Drawing.Size(38, 21);
            this.chkAddon2.TabIndex = 7;
            this.chkAddon2.Text = "2";
            this.chkAddon2.UseVisualStyleBackColor = true;
            this.chkAddon2.CheckStateChanged += new System.EventHandler(this.getSinkers);
            this.chkAddon2.MouseHover += new System.EventHandler(this.addonHover);
            // 
            // chkAddon4
            // 
            this.chkAddon4.AutoSize = true;
            this.chkAddon4.Location = new System.Drawing.Point(236, 47);
            this.chkAddon4.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddon4.Name = "chkAddon4";
            this.chkAddon4.Size = new System.Drawing.Size(38, 21);
            this.chkAddon4.TabIndex = 9;
            this.chkAddon4.Text = "4";
            this.chkAddon4.UseVisualStyleBackColor = true;
            this.chkAddon4.CheckStateChanged += new System.EventHandler(this.getSinkers);
            this.chkAddon4.MouseHover += new System.EventHandler(this.addonHover);
            // 
            // chkAddon1
            // 
            this.chkAddon1.AutoSize = true;
            this.chkAddon1.Location = new System.Drawing.Point(18, 47);
            this.chkAddon1.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddon1.Name = "chkAddon1";
            this.chkAddon1.Size = new System.Drawing.Size(38, 21);
            this.chkAddon1.TabIndex = 6;
            this.chkAddon1.Text = "1";
            this.chkAddon1.UseVisualStyleBackColor = true;
            this.chkAddon1.CheckStateChanged += new System.EventHandler(this.getSinkers);
            this.chkAddon1.MouseHover += new System.EventHandler(this.addonHover);
            // 
            // lblAddOns
            // 
            this.lblAddOns.AutoSize = true;
            this.lblAddOns.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddOns.Location = new System.Drawing.Point(9, 14);
            this.lblAddOns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddOns.Name = "lblAddOns";
            this.lblAddOns.Size = new System.Drawing.Size(143, 29);
            this.lblAddOns.TabIndex = 2;
            this.lblAddOns.Text = "ADD-ONS:";
            // 
            // chkAddon5
            // 
            this.chkAddon5.AutoSize = true;
            this.chkAddon5.Location = new System.Drawing.Point(236, 76);
            this.chkAddon5.Margin = new System.Windows.Forms.Padding(4);
            this.chkAddon5.Name = "chkAddon5";
            this.chkAddon5.Size = new System.Drawing.Size(38, 21);
            this.chkAddon5.TabIndex = 10;
            this.chkAddon5.Text = "5";
            this.chkAddon5.UseVisualStyleBackColor = true;
            this.chkAddon5.CheckStateChanged += new System.EventHandler(this.getSinkers);
            this.chkAddon5.MouseHover += new System.EventHandler(this.addonHover);
            // 
            // panelAddOns
            // 
            this.panelAddOns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelAddOns.Controls.Add(this.chkAddon5);
            this.panelAddOns.Controls.Add(this.lblAddOns);
            this.panelAddOns.Controls.Add(this.chkAddon1);
            this.panelAddOns.Controls.Add(this.chkAddon4);
            this.panelAddOns.Controls.Add(this.chkAddon2);
            this.panelAddOns.Controls.Add(this.chkAddon3);
            this.panelAddOns.Controls.Add(this.chkAddon6);
            this.panelAddOns.Location = new System.Drawing.Point(16, 141);
            this.panelAddOns.Margin = new System.Windows.Forms.Padding(4);
            this.panelAddOns.Name = "panelAddOns";
            this.panelAddOns.Size = new System.Drawing.Size(464, 142);
            this.panelAddOns.TabIndex = 5;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(218, 21);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(228, 29);
            this.lblProductName.TabIndex = 76;
            this.lblProductName.Text = "PRODUCT NAME";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(140)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(488, 299);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(207, 246);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(655, 10);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 40);
            this.btnBack.TabIndex = 80;
            this.btnBack.Text = "x";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(14, 48);
            this.txtNotes.MaxLength = 64;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(443, 116);
            this.txtNotes.TabIndex = 18;
            this.txtNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotes_KeyPress);
            this.txtNotes.Leave += new System.EventHandler(this.txtNotes_Leave);
            // 
            // panelNote
            // 
            this.panelNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelNote.Controls.Add(this.label3);
            this.panelNote.Controls.Add(this.txtNotes);
            this.panelNote.Location = new System.Drawing.Point(16, 381);
            this.panelNote.Margin = new System.Windows.Forms.Padding(4);
            this.panelNote.Name = "panelNote";
            this.panelNote.Size = new System.Drawing.Size(464, 180);
            this.panelNote.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "NOTE:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(703, 566);
            this.ControlBox = false;
            this.Controls.Add(this.panelNote);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.panelAddOns);
            this.Controls.Add(this.panelQty);
            this.Controls.Add(this.panelSugarLevel);
            this.Controls.Add(this.panelSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Products";
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.panelSize.ResumeLayout(false);
            this.panelSize.PerformLayout();
            this.panelSugarLevel.ResumeLayout(false);
            this.panelSugarLevel.PerformLayout();
            this.panelQty.ResumeLayout(false);
            this.panelQty.PerformLayout();
            this.panelAddOns.ResumeLayout(false);
            this.panelAddOns.PerformLayout();
            this.panelNote.ResumeLayout(false);
            this.panelNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radSize1;
        private System.Windows.Forms.RadioButton radSize2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtn0P;
        private System.Windows.Forms.RadioButton rbtn25P;
        private System.Windows.Forms.RadioButton rbtn50P;
        private System.Windows.Forms.RadioButton rbtn75P;
        private System.Windows.Forms.RadioButton rbtn100P;
        private System.Windows.Forms.Panel panelSize;
        private System.Windows.Forms.Panel panelSugarLevel;
        private System.Windows.Forms.Panel panelQty;
        private System.Windows.Forms.CheckBox chkAddon6;
        private System.Windows.Forms.CheckBox chkAddon3;
        private System.Windows.Forms.CheckBox chkAddon2;
        private System.Windows.Forms.CheckBox chkAddon4;
        private System.Windows.Forms.CheckBox chkAddon1;
        private System.Windows.Forms.Label lblAddOns;
        private System.Windows.Forms.CheckBox chkAddon5;
        private System.Windows.Forms.Panel panelAddOns;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radSize3;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel panelNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}   