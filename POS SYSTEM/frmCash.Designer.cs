namespace POS_SYSTEM
{
    partial class frmCash
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
            this.btn5cent = new System.Windows.Forms.Button();
            this.btn25cent = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn20 = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btn200 = new System.Windows.Forms.Button();
            this.btn50 = new System.Windows.Forms.Button();
            this.btn1000 = new System.Windows.Forms.Button();
            this.btn500 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.lblCash = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn5cent
            // 
            this.btn5cent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.btn5cent.BackgroundImage = global::POS_SYSTEM.Properties.Resources._0_05;
            this.btn5cent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn5cent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn5cent.Location = new System.Drawing.Point(174, 646);
            this.btn5cent.Name = "btn5cent";
            this.btn5cent.Size = new System.Drawing.Size(100, 100);
            this.btn5cent.TabIndex = 7;
            this.btn5cent.Tag = "0.05";
            this.btn5cent.UseVisualStyleBackColor = false;
            this.btn5cent.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn25cent
            // 
            this.btn25cent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.btn25cent.BackgroundImage = global::POS_SYSTEM.Properties.Resources._0_25s;
            this.btn25cent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn25cent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn25cent.Location = new System.Drawing.Point(294, 646);
            this.btn25cent.Name = "btn25cent";
            this.btn25cent.Size = new System.Drawing.Size(100, 100);
            this.btn25cent.TabIndex = 8;
            this.btn25cent.Tag = "0.25";
            this.btn25cent.UseVisualStyleBackColor = false;
            this.btn25cent.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.btn5.BackgroundImage = global::POS_SYSTEM.Properties.Resources._5s;
            this.btn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn5.Location = new System.Drawing.Point(544, 616);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(130, 130);
            this.btn5.TabIndex = 10;
            this.btn5.Tag = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.btn1.BackgroundImage = global::POS_SYSTEM.Properties.Resources._1s;
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1.Location = new System.Drawing.Point(414, 631);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(115, 115);
            this.btn1.TabIndex = 9;
            this.btn1.Tag = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn10
            // 
            this.btn10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.btn10.BackgroundImage = global::POS_SYSTEM.Properties.Resources._10s;
            this.btn10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn10.Location = new System.Drawing.Point(694, 606);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(140, 140);
            this.btn10.TabIndex = 11;
            this.btn10.Tag = "10";
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn20
            // 
            this.btn20.BackColor = System.Drawing.Color.Transparent;
            this.btn20.BackgroundImage = global::POS_SYSTEM.Properties.Resources._20s;
            this.btn20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn20.Location = new System.Drawing.Point(22, 69);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(408, 168);
            this.btn20.TabIndex = 1;
            this.btn20.Tag = "20";
            this.btn20.UseVisualStyleBackColor = false;
            this.btn20.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn100
            // 
            this.btn100.BackColor = System.Drawing.Color.Transparent;
            this.btn100.BackgroundImage = global::POS_SYSTEM.Properties.Resources._100s;
            this.btn100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn100.Location = new System.Drawing.Point(22, 243);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(408, 168);
            this.btn100.TabIndex = 3;
            this.btn100.Tag = "100";
            this.btn100.UseVisualStyleBackColor = false;
            this.btn100.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn200
            // 
            this.btn200.BackColor = System.Drawing.Color.Transparent;
            this.btn200.BackgroundImage = global::POS_SYSTEM.Properties.Resources._200s;
            this.btn200.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn200.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn200.Location = new System.Drawing.Point(445, 243);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(408, 168);
            this.btn200.TabIndex = 4;
            this.btn200.Tag = "200";
            this.btn200.UseVisualStyleBackColor = false;
            this.btn200.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn50
            // 
            this.btn50.BackColor = System.Drawing.Color.Transparent;
            this.btn50.BackgroundImage = global::POS_SYSTEM.Properties.Resources._50s;
            this.btn50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn50.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn50.Location = new System.Drawing.Point(445, 69);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(408, 168);
            this.btn50.TabIndex = 2;
            this.btn50.Tag = "50";
            this.btn50.UseVisualStyleBackColor = false;
            this.btn50.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn1000
            // 
            this.btn1000.BackColor = System.Drawing.Color.Transparent;
            this.btn1000.BackgroundImage = global::POS_SYSTEM.Properties.Resources._1000s;
            this.btn1000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn1000.Location = new System.Drawing.Point(445, 421);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(408, 168);
            this.btn1000.TabIndex = 6;
            this.btn1000.Tag = "1000";
            this.btn1000.UseVisualStyleBackColor = false;
            this.btn1000.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btn500
            // 
            this.btn500.BackColor = System.Drawing.Color.Transparent;
            this.btn500.BackgroundImage = global::POS_SYSTEM.Properties.Resources._500s;
            this.btn500.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn500.Location = new System.Drawing.Point(22, 421);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(408, 168);
            this.btn500.TabIndex = 5;
            this.btn500.Tag = "500";
            this.btn500.UseVisualStyleBackColor = false;
            this.btn500.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(216, 125);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 60);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSubtract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSubtract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubtract.Location = new System.Drawing.Point(9, 125);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(117, 60);
            this.btnSubtract.TabIndex = 12;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = false;
            this.btnSubtract.Click += new System.EventHandler(this.btnOperation_Click);
            // 
            // lblCash
            // 
            this.lblCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(9, 16);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(324, 86);
            this.lblCash.TabIndex = 15;
            this.lblCash.Text = "0.00";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(200)))), ((int)(((byte)(140)))));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(881, 452);
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
            this.btnCancel.Location = new System.Drawing.Point(881, 529);
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
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.lblCash);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSubtract);
            this.panel1.Location = new System.Drawing.Point(870, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 255);
            this.panel1.TabIndex = 18;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Bisque;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(132, 139);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 32);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(1260, 781);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btn1000);
            this.Controls.Add(this.btn500);
            this.Controls.Add(this.btn200);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn25cent);
            this.Controls.Add(this.btn5cent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCash";
            this.Tag = "10";
            this.Text = "Cash window";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn5cent;
        private System.Windows.Forms.Button btn25cent;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btn200;
        private System.Windows.Forms.Button btn50;
        private System.Windows.Forms.Button btn1000;
        private System.Windows.Forms.Button btn500;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
    }
}