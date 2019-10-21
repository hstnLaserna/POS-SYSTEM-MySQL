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
            this.panelMT1 = new System.Windows.Forms.Panel();
            this.panelQty = new System.Windows.Forms.Panel();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.chkMT6 = new System.Windows.Forms.CheckBox();
            this.chkMT3 = new System.Windows.Forms.CheckBox();
            this.chkMT2 = new System.Windows.Forms.CheckBox();
            this.chkMT4 = new System.Windows.Forms.CheckBox();
            this.chkMT1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMT5 = new System.Windows.Forms.CheckBox();
            this.panelMT2 = new System.Windows.Forms.Panel();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelMS = new System.Windows.Forms.Panel();
            this.chkMS5 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkMS1 = new System.Windows.Forms.CheckBox();
            this.chkMS4 = new System.Windows.Forms.CheckBox();
            this.chkMS2 = new System.Windows.Forms.CheckBox();
            this.chkMS3 = new System.Windows.Forms.CheckBox();
            this.chkMS6 = new System.Windows.Forms.CheckBox();
            this.panelFR = new System.Windows.Forms.Panel();
            this.chkFR5 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFR1 = new System.Windows.Forms.CheckBox();
            this.chkFR4 = new System.Windows.Forms.CheckBox();
            this.chkFR2 = new System.Windows.Forms.CheckBox();
            this.chkFR3 = new System.Windows.Forms.CheckBox();
            this.chkFR6 = new System.Windows.Forms.CheckBox();
            this.panelSize.SuspendLayout();
            this.panelMT1.SuspendLayout();
            this.panelQty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelMT2.SuspendLayout();
            this.panelMS.SuspendLayout();
            this.panelFR.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SIZE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "SUGAR LEVEL:";
            // 
            // radSize1
            // 
            this.radSize1.AutoSize = true;
            this.radSize1.Enabled = false;
            this.radSize1.Location = new System.Drawing.Point(17, 27);
            this.radSize1.Margin = new System.Windows.Forms.Padding(4);
            this.radSize1.Name = "radSize1";
            this.radSize1.Size = new System.Drawing.Size(63, 21);
            this.radSize1.TabIndex = 4;
            this.radSize1.TabStop = true;
            this.radSize1.Tag = "rb1";
            this.radSize1.Text = "Small";
            this.radSize1.UseVisualStyleBackColor = true;
            this.radSize1.CheckedChanged += new System.EventHandler(this.getSizePrice);
            // 
            // radSize2
            // 
            this.radSize2.AutoSize = true;
            this.radSize2.Enabled = false;
            this.radSize2.Location = new System.Drawing.Point(128, 27);
            this.radSize2.Margin = new System.Windows.Forms.Padding(4);
            this.radSize2.Name = "radSize2";
            this.radSize2.Size = new System.Drawing.Size(78, 21);
            this.radSize2.TabIndex = 5;
            this.radSize2.TabStop = true;
            this.radSize2.Tag = "rb2";
            this.radSize2.Text = "Medium";
            this.radSize2.UseVisualStyleBackColor = true;
            this.radSize2.CheckedChanged += new System.EventHandler(this.getSizePrice);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "QUANTITY:";
            // 
            // rbtn0P
            // 
            this.rbtn0P.AutoSize = true;
            this.rbtn0P.Location = new System.Drawing.Point(13, 36);
            this.rbtn0P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn0P.Name = "rbtn0P";
            this.rbtn0P.Size = new System.Drawing.Size(49, 21);
            this.rbtn0P.TabIndex = 12;
            this.rbtn0P.TabStop = true;
            this.rbtn0P.Text = "0%";
            this.rbtn0P.UseVisualStyleBackColor = true;
            this.rbtn0P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn25P
            // 
            this.rbtn25P.AutoSize = true;
            this.rbtn25P.Location = new System.Drawing.Point(73, 36);
            this.rbtn25P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn25P.Name = "rbtn25P";
            this.rbtn25P.Size = new System.Drawing.Size(57, 21);
            this.rbtn25P.TabIndex = 13;
            this.rbtn25P.TabStop = true;
            this.rbtn25P.Text = "25%";
            this.rbtn25P.UseVisualStyleBackColor = true;
            this.rbtn25P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn50P
            // 
            this.rbtn50P.AutoSize = true;
            this.rbtn50P.Location = new System.Drawing.Point(141, 36);
            this.rbtn50P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn50P.Name = "rbtn50P";
            this.rbtn50P.Size = new System.Drawing.Size(57, 21);
            this.rbtn50P.TabIndex = 14;
            this.rbtn50P.TabStop = true;
            this.rbtn50P.Text = "50%";
            this.rbtn50P.UseVisualStyleBackColor = true;
            this.rbtn50P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn75P
            // 
            this.rbtn75P.AutoSize = true;
            this.rbtn75P.Location = new System.Drawing.Point(209, 36);
            this.rbtn75P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn75P.Name = "rbtn75P";
            this.rbtn75P.Size = new System.Drawing.Size(57, 21);
            this.rbtn75P.TabIndex = 15;
            this.rbtn75P.TabStop = true;
            this.rbtn75P.Text = "75%";
            this.rbtn75P.UseVisualStyleBackColor = true;
            this.rbtn75P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // rbtn100P
            // 
            this.rbtn100P.AutoSize = true;
            this.rbtn100P.Location = new System.Drawing.Point(269, 36);
            this.rbtn100P.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn100P.Name = "rbtn100P";
            this.rbtn100P.Size = new System.Drawing.Size(65, 21);
            this.rbtn100P.TabIndex = 16;
            this.rbtn100P.TabStop = true;
            this.rbtn100P.Text = "100%";
            this.rbtn100P.UseVisualStyleBackColor = true;
            this.rbtn100P.CheckedChanged += new System.EventHandler(this.getSugarLevel);
            // 
            // panelSize
            // 
            this.panelSize.Controls.Add(this.radSize3);
            this.panelSize.Controls.Add(this.radSize2);
            this.panelSize.Controls.Add(this.radSize1);
            this.panelSize.Controls.Add(this.label1);
            this.panelSize.Location = new System.Drawing.Point(16, 60);
            this.panelSize.Margin = new System.Windows.Forms.Padding(4);
            this.panelSize.Name = "panelSize";
            this.panelSize.Size = new System.Drawing.Size(344, 49);
            this.panelSize.TabIndex = 71;
            // 
            // radSize3
            // 
            this.radSize3.AutoSize = true;
            this.radSize3.Enabled = false;
            this.radSize3.Location = new System.Drawing.Point(247, 27);
            this.radSize3.Margin = new System.Windows.Forms.Padding(4);
            this.radSize3.Name = "radSize3";
            this.radSize3.Size = new System.Drawing.Size(66, 21);
            this.radSize3.TabIndex = 6;
            this.radSize3.TabStop = true;
            this.radSize3.Tag = "rb2";
            this.radSize3.Text = "Large";
            this.radSize3.UseVisualStyleBackColor = true;
            // 
            // panelMT1
            // 
            this.panelMT1.Controls.Add(this.rbtn100P);
            this.panelMT1.Controls.Add(this.rbtn75P);
            this.panelMT1.Controls.Add(this.rbtn50P);
            this.panelMT1.Controls.Add(this.rbtn25P);
            this.panelMT1.Controls.Add(this.rbtn0P);
            this.panelMT1.Controls.Add(this.label2);
            this.panelMT1.Location = new System.Drawing.Point(16, 117);
            this.panelMT1.Margin = new System.Windows.Forms.Padding(4);
            this.panelMT1.Name = "panelMT1";
            this.panelMT1.Size = new System.Drawing.Size(344, 60);
            this.panelMT1.TabIndex = 72;
            // 
            // panelQty
            // 
            this.panelQty.Controls.Add(this.numQuantity);
            this.panelQty.Controls.Add(this.label4);
            this.panelQty.Location = new System.Drawing.Point(16, 560);
            this.panelQty.Margin = new System.Windows.Forms.Padding(4);
            this.panelQty.Name = "panelQty";
            this.panelQty.Size = new System.Drawing.Size(344, 47);
            this.panelQty.TabIndex = 74;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(118, 12);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.numQuantity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.ReadOnly = true;
            this.numQuantity.Size = new System.Drawing.Size(79, 22);
            this.numQuantity.TabIndex = 78;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkMT6
            // 
            this.chkMT6.AutoSize = true;
            this.chkMT6.Location = new System.Drawing.Point(181, 91);
            this.chkMT6.Margin = new System.Windows.Forms.Padding(4);
            this.chkMT6.Name = "chkMT6";
            this.chkMT6.Size = new System.Drawing.Size(93, 21);
            this.chkMT6.TabIndex = 9;
            this.chkMT6.Text = "Red Bean";
            this.chkMT6.UseVisualStyleBackColor = true;
            this.chkMT6.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // chkMT3
            // 
            this.chkMT3.AutoSize = true;
            this.chkMT3.Location = new System.Drawing.Point(35, 91);
            this.chkMT3.Margin = new System.Windows.Forms.Padding(4);
            this.chkMT3.Name = "chkMT3";
            this.chkMT3.Size = new System.Drawing.Size(114, 21);
            this.chkMT3.TabIndex = 7;
            this.chkMT3.Text = "Coconut Jelly";
            this.chkMT3.UseVisualStyleBackColor = true;
            this.chkMT3.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // chkMT2
            // 
            this.chkMT2.AutoSize = true;
            this.chkMT2.Location = new System.Drawing.Point(35, 63);
            this.chkMT2.Margin = new System.Windows.Forms.Padding(4);
            this.chkMT2.Name = "chkMT2";
            this.chkMT2.Size = new System.Drawing.Size(103, 21);
            this.chkMT2.TabIndex = 6;
            this.chkMT2.Text = "Coffee Jelly";
            this.chkMT2.UseVisualStyleBackColor = true;
            this.chkMT2.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // chkMT4
            // 
            this.chkMT4.AutoSize = true;
            this.chkMT4.Location = new System.Drawing.Point(181, 34);
            this.chkMT4.Margin = new System.Windows.Forms.Padding(4);
            this.chkMT4.Name = "chkMT4";
            this.chkMT4.Size = new System.Drawing.Size(82, 21);
            this.chkMT4.TabIndex = 8;
            this.chkMT4.Text = "Pudding";
            this.chkMT4.UseVisualStyleBackColor = true;
            this.chkMT4.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // chkMT1
            // 
            this.chkMT1.AutoSize = true;
            this.chkMT1.Location = new System.Drawing.Point(35, 34);
            this.chkMT1.Margin = new System.Windows.Forms.Padding(4);
            this.chkMT1.Name = "chkMT1";
            this.chkMT1.Size = new System.Drawing.Size(63, 21);
            this.chkMT1.TabIndex = 3;
            this.chkMT1.Text = "Pearl";
            this.chkMT1.UseVisualStyleBackColor = true;
            this.chkMT1.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "SINKERS:";
            // 
            // chkMT5
            // 
            this.chkMT5.AutoSize = true;
            this.chkMT5.Location = new System.Drawing.Point(181, 63);
            this.chkMT5.Margin = new System.Windows.Forms.Padding(4);
            this.chkMT5.Name = "chkMT5";
            this.chkMT5.Size = new System.Drawing.Size(58, 21);
            this.chkMT5.TabIndex = 10;
            this.chkMT5.Text = "Aloe";
            this.chkMT5.UseVisualStyleBackColor = true;
            this.chkMT5.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // panelMT2
            // 
            this.panelMT2.Controls.Add(this.chkMT5);
            this.panelMT2.Controls.Add(this.label3);
            this.panelMT2.Controls.Add(this.chkMT1);
            this.panelMT2.Controls.Add(this.chkMT4);
            this.panelMT2.Controls.Add(this.chkMT2);
            this.panelMT2.Controls.Add(this.chkMT3);
            this.panelMT2.Controls.Add(this.chkMT6);
            this.panelMT2.Location = new System.Drawing.Point(16, 185);
            this.panelMT2.Margin = new System.Windows.Forms.Padding(4);
            this.panelMT2.Name = "panelMT2";
            this.panelMT2.Size = new System.Drawing.Size(344, 117);
            this.panelMT2.TabIndex = 75;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(117, 21);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(157, 20);
            this.lblProductName.TabIndex = 76;
            this.lblProductName.Text = "PRODUCT NAME";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(144, 615);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 79;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(339, 13);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(33, 28);
            this.btnBack.TabIndex = 80;
            this.btnBack.Text = "x";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panelMS
            // 
            this.panelMS.Controls.Add(this.chkMS5);
            this.panelMS.Controls.Add(this.label5);
            this.panelMS.Controls.Add(this.chkMS1);
            this.panelMS.Controls.Add(this.chkMS4);
            this.panelMS.Controls.Add(this.chkMS2);
            this.panelMS.Controls.Add(this.chkMS3);
            this.panelMS.Controls.Add(this.chkMS6);
            this.panelMS.Location = new System.Drawing.Point(16, 310);
            this.panelMS.Margin = new System.Windows.Forms.Padding(4);
            this.panelMS.Name = "panelMS";
            this.panelMS.Size = new System.Drawing.Size(344, 117);
            this.panelMS.TabIndex = 76;
            // 
            // chkMS5
            // 
            this.chkMS5.AutoSize = true;
            this.chkMS5.Location = new System.Drawing.Point(181, 63);
            this.chkMS5.Margin = new System.Windows.Forms.Padding(4);
            this.chkMS5.Name = "chkMS5";
            this.chkMS5.Size = new System.Drawing.Size(132, 21);
            this.chkMS5.TabIndex = 10;
            this.chkMS5.Text = "Choco Sprinkles";
            this.chkMS5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "TOPPERS:";
            // 
            // chkMS1
            // 
            this.chkMS1.AutoSize = true;
            this.chkMS1.Location = new System.Drawing.Point(35, 34);
            this.chkMS1.Margin = new System.Windows.Forms.Padding(4);
            this.chkMS1.Name = "chkMS1";
            this.chkMS1.Size = new System.Drawing.Size(116, 21);
            this.chkMS1.TabIndex = 3;
            this.chkMS1.Text = "Oreo Cookies";
            this.chkMS1.UseVisualStyleBackColor = true;
            // 
            // chkMS4
            // 
            this.chkMS4.AutoSize = true;
            this.chkMS4.Location = new System.Drawing.Point(181, 34);
            this.chkMS4.Margin = new System.Windows.Forms.Padding(4);
            this.chkMS4.Name = "chkMS4";
            this.chkMS4.Size = new System.Drawing.Size(132, 21);
            this.chkMS4.TabIndex = 8;
            this.chkMS4.Text = "Candy Sprinkles";
            this.chkMS4.UseVisualStyleBackColor = true;
            // 
            // chkMS2
            // 
            this.chkMS2.AutoSize = true;
            this.chkMS2.Location = new System.Drawing.Point(35, 63);
            this.chkMS2.Margin = new System.Windows.Forms.Padding(4);
            this.chkMS2.Name = "chkMS2";
            this.chkMS2.Size = new System.Drawing.Size(72, 21);
            this.chkMS2.TabIndex = 6;
            this.chkMS2.Text = "Cherry";
            this.chkMS2.UseVisualStyleBackColor = true;
            // 
            // chkMS3
            // 
            this.chkMS3.AutoSize = true;
            this.chkMS3.Location = new System.Drawing.Point(35, 91);
            this.chkMS3.Margin = new System.Windows.Forms.Padding(4);
            this.chkMS3.Name = "chkMS3";
            this.chkMS3.Size = new System.Drawing.Size(102, 21);
            this.chkMS3.TabIndex = 7;
            this.chkMS3.Text = "Wafer Stick";
            this.chkMS3.UseVisualStyleBackColor = true;
            // 
            // chkMS6
            // 
            this.chkMS6.AutoSize = true;
            this.chkMS6.Location = new System.Drawing.Point(181, 91);
            this.chkMS6.Margin = new System.Windows.Forms.Padding(4);
            this.chkMS6.Name = "chkMS6";
            this.chkMS6.Size = new System.Drawing.Size(111, 21);
            this.chkMS6.TabIndex = 9;
            this.chkMS6.Text = "Marshmallow";
            this.chkMS6.UseVisualStyleBackColor = true;
            // 
            // panelFR
            // 
            this.panelFR.Controls.Add(this.chkFR5);
            this.panelFR.Controls.Add(this.label6);
            this.panelFR.Controls.Add(this.chkFR1);
            this.panelFR.Controls.Add(this.chkFR4);
            this.panelFR.Controls.Add(this.chkFR2);
            this.panelFR.Controls.Add(this.chkFR3);
            this.panelFR.Controls.Add(this.chkFR6);
            this.panelFR.Location = new System.Drawing.Point(16, 435);
            this.panelFR.Margin = new System.Windows.Forms.Padding(4);
            this.panelFR.Name = "panelFR";
            this.panelFR.Size = new System.Drawing.Size(344, 117);
            this.panelFR.TabIndex = 81;
            // 
            // chkFR5
            // 
            this.chkFR5.AutoSize = true;
            this.chkFR5.Location = new System.Drawing.Point(208, 63);
            this.chkFR5.Margin = new System.Windows.Forms.Padding(4);
            this.chkFR5.Name = "chkFR5";
            this.chkFR5.Size = new System.Drawing.Size(132, 21);
            this.chkFR5.TabIndex = 10;
            this.chkFR5.Text = "Choco Sprinkles";
            this.chkFR5.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "ADD ONS:";
            // 
            // chkFR1
            // 
            this.chkFR1.AutoSize = true;
            this.chkFR1.Location = new System.Drawing.Point(35, 34);
            this.chkFR1.Margin = new System.Windows.Forms.Padding(4);
            this.chkFR1.Name = "chkFR1";
            this.chkFR1.Size = new System.Drawing.Size(131, 21);
            this.chkFR1.TabIndex = 3;
            this.chkFR1.Text = "Whipped Cream";
            this.chkFR1.UseVisualStyleBackColor = true;
            // 
            // chkFR4
            // 
            this.chkFR4.AutoSize = true;
            this.chkFR4.Location = new System.Drawing.Point(208, 34);
            this.chkFR4.Margin = new System.Windows.Forms.Padding(4);
            this.chkFR4.Name = "chkFR4";
            this.chkFR4.Size = new System.Drawing.Size(72, 21);
            this.chkFR4.TabIndex = 8;
            this.chkFR4.Text = "Vanilla";
            this.chkFR4.UseVisualStyleBackColor = true;
            // 
            // chkFR2
            // 
            this.chkFR2.AutoSize = true;
            this.chkFR2.Location = new System.Drawing.Point(35, 63);
            this.chkFR2.Margin = new System.Windows.Forms.Padding(4);
            this.chkFR2.Name = "chkFR2";
            this.chkFR2.Size = new System.Drawing.Size(111, 21);
            this.chkFR2.TabIndex = 6;
            this.chkFR2.Text = "Choco Syrup";
            this.chkFR2.UseVisualStyleBackColor = true;
            // 
            // chkFR3
            // 
            this.chkFR3.AutoSize = true;
            this.chkFR3.Location = new System.Drawing.Point(35, 91);
            this.chkFR3.Margin = new System.Windows.Forms.Padding(4);
            this.chkFR3.Name = "chkFR3";
            this.chkFR3.Size = new System.Drawing.Size(93, 21);
            this.chkFR3.TabIndex = 7;
            this.chkFR3.Text = "Cinnamon";
            this.chkFR3.UseVisualStyleBackColor = true;
            // 
            // chkFR6
            // 
            this.chkFR6.AutoSize = true;
            this.chkFR6.Location = new System.Drawing.Point(208, 91);
            this.chkFR6.Margin = new System.Windows.Forms.Padding(4);
            this.chkFR6.Name = "chkFR6";
            this.chkFR6.Size = new System.Drawing.Size(68, 21);
            this.chkFR6.TabIndex = 9;
            this.chkFR6.Text = "Sugar";
            this.chkFR6.UseVisualStyleBackColor = true;
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 654);
            this.ControlBox = false;
            this.Controls.Add(this.panelFR);
            this.Controls.Add(this.panelMS);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.panelMT2);
            this.Controls.Add(this.panelQty);
            this.Controls.Add(this.panelMT1);
            this.Controls.Add(this.panelSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMilkTea";
            this.Load += new System.EventHandler(this.frmMilkTea_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.panelSize.ResumeLayout(false);
            this.panelSize.PerformLayout();
            this.panelMT1.ResumeLayout(false);
            this.panelMT1.PerformLayout();
            this.panelQty.ResumeLayout(false);
            this.panelQty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelMT2.ResumeLayout(false);
            this.panelMT2.PerformLayout();
            this.panelMS.ResumeLayout(false);
            this.panelMS.PerformLayout();
            this.panelFR.ResumeLayout(false);
            this.panelFR.PerformLayout();
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
        private System.Windows.Forms.Panel panelMT1;
        private System.Windows.Forms.Panel panelQty;
        private System.Windows.Forms.CheckBox chkMT6;
        private System.Windows.Forms.CheckBox chkMT3;
        private System.Windows.Forms.CheckBox chkMT2;
        private System.Windows.Forms.CheckBox chkMT4;
        private System.Windows.Forms.CheckBox chkMT1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkMT5;
        private System.Windows.Forms.Panel panelMT2;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radSize3;
        private System.Windows.Forms.Panel panelMS;
        private System.Windows.Forms.CheckBox chkMS5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMS1;
        private System.Windows.Forms.CheckBox chkMS4;
        private System.Windows.Forms.CheckBox chkMS2;
        private System.Windows.Forms.CheckBox chkMS3;
        private System.Windows.Forms.CheckBox chkMS6;
        private System.Windows.Forms.Panel panelFR;
        private System.Windows.Forms.CheckBox chkFR5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkFR1;
        private System.Windows.Forms.CheckBox chkFR4;
        private System.Windows.Forms.CheckBox chkFR2;
        private System.Windows.Forms.CheckBox chkFR3;
        private System.Windows.Forms.CheckBox chkFR6;
    }
}   