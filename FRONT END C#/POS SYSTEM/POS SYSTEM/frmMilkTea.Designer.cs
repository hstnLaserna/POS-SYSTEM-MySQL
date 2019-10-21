namespace POS_SYSTEM
{
    partial class frmMilkTea
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.cbRedBean = new System.Windows.Forms.CheckBox();
            this.cbCoconutJelly = new System.Windows.Forms.CheckBox();
            this.cbCoffeeJelly = new System.Windows.Forms.CheckBox();
            this.cbPudding = new System.Windows.Forms.CheckBox();
            this.cbPearl = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAloe = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMilkTeaName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.radSize3 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panel3.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(5, 12);
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
            this.label4.Location = new System.Drawing.Point(8, 5);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.radSize3);
            this.panel1.Controls.Add(this.radSize2);
            this.panel1.Controls.Add(this.radSize1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 49);
            this.panel1.TabIndex = 71;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtn100P);
            this.panel2.Controls.Add(this.rbtn75P);
            this.panel2.Controls.Add(this.rbtn50P);
            this.panel2.Controls.Add(this.rbtn25P);
            this.panel2.Controls.Add(this.rbtn0P);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(16, 117);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 60);
            this.panel2.TabIndex = 72;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numQuantity);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(17, 308);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(239, 66);
            this.panel4.TabIndex = 74;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(72, 28);
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
            // cbRedBean
            // 
            this.cbRedBean.AutoSize = true;
            this.cbRedBean.Location = new System.Drawing.Point(160, 91);
            this.cbRedBean.Margin = new System.Windows.Forms.Padding(4);
            this.cbRedBean.Name = "cbRedBean";
            this.cbRedBean.Size = new System.Drawing.Size(93, 21);
            this.cbRedBean.TabIndex = 9;
            this.cbRedBean.Text = "Red Bean";
            this.cbRedBean.UseVisualStyleBackColor = true;
            this.cbRedBean.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // cbCoconutJelly
            // 
            this.cbCoconutJelly.AutoSize = true;
            this.cbCoconutJelly.Location = new System.Drawing.Point(35, 91);
            this.cbCoconutJelly.Margin = new System.Windows.Forms.Padding(4);
            this.cbCoconutJelly.Name = "cbCoconutJelly";
            this.cbCoconutJelly.Size = new System.Drawing.Size(114, 21);
            this.cbCoconutJelly.TabIndex = 7;
            this.cbCoconutJelly.Text = "Coconut Jelly";
            this.cbCoconutJelly.UseVisualStyleBackColor = true;
            this.cbCoconutJelly.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // cbCoffeeJelly
            // 
            this.cbCoffeeJelly.AutoSize = true;
            this.cbCoffeeJelly.Location = new System.Drawing.Point(35, 63);
            this.cbCoffeeJelly.Margin = new System.Windows.Forms.Padding(4);
            this.cbCoffeeJelly.Name = "cbCoffeeJelly";
            this.cbCoffeeJelly.Size = new System.Drawing.Size(103, 21);
            this.cbCoffeeJelly.TabIndex = 6;
            this.cbCoffeeJelly.Text = "Coffee Jelly";
            this.cbCoffeeJelly.UseVisualStyleBackColor = true;
            this.cbCoffeeJelly.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // cbPudding
            // 
            this.cbPudding.AutoSize = true;
            this.cbPudding.Location = new System.Drawing.Point(160, 34);
            this.cbPudding.Margin = new System.Windows.Forms.Padding(4);
            this.cbPudding.Name = "cbPudding";
            this.cbPudding.Size = new System.Drawing.Size(82, 21);
            this.cbPudding.TabIndex = 8;
            this.cbPudding.Text = "Pudding";
            this.cbPudding.UseVisualStyleBackColor = true;
            this.cbPudding.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // cbPearl
            // 
            this.cbPearl.AutoSize = true;
            this.cbPearl.Location = new System.Drawing.Point(35, 34);
            this.cbPearl.Margin = new System.Windows.Forms.Padding(4);
            this.cbPearl.Name = "cbPearl";
            this.cbPearl.Size = new System.Drawing.Size(63, 21);
            this.cbPearl.TabIndex = 3;
            this.cbPearl.Text = "Pearl";
            this.cbPearl.UseVisualStyleBackColor = true;
            this.cbPearl.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "SINKERS:";
            // 
            // cbAloe
            // 
            this.cbAloe.AutoSize = true;
            this.cbAloe.Location = new System.Drawing.Point(160, 63);
            this.cbAloe.Margin = new System.Windows.Forms.Padding(4);
            this.cbAloe.Name = "cbAloe";
            this.cbAloe.Size = new System.Drawing.Size(58, 21);
            this.cbAloe.TabIndex = 10;
            this.cbAloe.Text = "Aloe";
            this.cbAloe.UseVisualStyleBackColor = true;
            this.cbAloe.CheckStateChanged += new System.EventHandler(this.getSinkers);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbAloe);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbPearl);
            this.panel3.Controls.Add(this.cbPudding);
            this.panel3.Controls.Add(this.cbCoffeeJelly);
            this.panel3.Controls.Add(this.cbCoconutJelly);
            this.panel3.Controls.Add(this.cbRedBean);
            this.panel3.Location = new System.Drawing.Point(17, 183);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 117);
            this.panel3.TabIndex = 75;
            // 
            // lblMilkTeaName
            // 
            this.lblMilkTeaName.AutoSize = true;
            this.lblMilkTeaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilkTeaName.Location = new System.Drawing.Point(4, 21);
            this.lblMilkTeaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMilkTeaName.Name = "lblMilkTeaName";
            this.lblMilkTeaName.Size = new System.Drawing.Size(151, 20);
            this.lblMilkTeaName.TabIndex = 76;
            this.lblMilkTeaName.Text = "MILK TEA NAME";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(272, 313);
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
            // frmMilkTea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 398);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblMilkTeaName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMilkTea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMilkTea";
            this.Load += new System.EventHandler(this.frmMilkTea_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cbRedBean;
        private System.Windows.Forms.CheckBox cbCoconutJelly;
        private System.Windows.Forms.CheckBox cbCoffeeJelly;
        private System.Windows.Forms.CheckBox cbPudding;
        private System.Windows.Forms.CheckBox cbPearl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAloe;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMilkTeaName;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radSize3;
    }
}