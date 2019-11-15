namespace POS_SYSTEM
{
    partial class frmTransactionHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionHistory));
            this.dgvTransactionHistory = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkWithTransactionHistory = new System.Windows.Forms.CheckBox();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnYear = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDay = new System.Windows.Forms.Button();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactionHistory
            // 
            this.dgvTransactionHistory.AllowUserToAddRows = false;
            this.dgvTransactionHistory.AllowUserToDeleteRows = false;
            this.dgvTransactionHistory.AllowUserToResizeColumns = false;
            this.dgvTransactionHistory.AllowUserToResizeRows = false;
            this.dgvTransactionHistory.BackgroundColor = System.Drawing.Color.OldLace;
            this.dgvTransactionHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Sienna;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactionHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTransactionHistory.Location = new System.Drawing.Point(37, 595);
            this.dgvTransactionHistory.MultiSelect = false;
            this.dgvTransactionHistory.Name = "dgvTransactionHistory";
            this.dgvTransactionHistory.ReadOnly = true;
            this.dgvTransactionHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTransactionHistory.RowHeadersVisible = false;
            this.dgvTransactionHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTransactionHistory.RowTemplate.Height = 24;
            this.dgvTransactionHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactionHistory.Size = new System.Drawing.Size(1350, 355);
            this.dgvTransactionHistory.TabIndex = 1;
            this.dgvTransactionHistory.Visible = false;
            this.dgvTransactionHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionHistory_CellClick);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(23, 39);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(240, 22);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(23, 87);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(240, 22);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "From:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(1454, 962);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 28);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkWithTransactionHistory);
            this.panel1.Controls.Add(this.btnViewHistory);
            this.panel1.Controls.Add(this.btnYear);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1393, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 528);
            this.panel1.TabIndex = 12;
            // 
            // chkWithTransactionHistory
            // 
            this.chkWithTransactionHistory.AutoSize = true;
            this.chkWithTransactionHistory.Location = new System.Drawing.Point(59, 495);
            this.chkWithTransactionHistory.Name = "chkWithTransactionHistory";
            this.chkWithTransactionHistory.Size = new System.Drawing.Size(185, 21);
            this.chkWithTransactionHistory.TabIndex = 16;
            this.chkWithTransactionHistory.Text = "With Transaction History";
            this.chkWithTransactionHistory.UseVisualStyleBackColor = true;
            this.chkWithTransactionHistory.Visible = false;
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewHistory.ForeColor = System.Drawing.Color.Black;
            this.btnViewHistory.Location = new System.Drawing.Point(59, 416);
            this.btnViewHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(160, 64);
            this.btnViewHistory.TabIndex = 15;
            this.btnViewHistory.Tag = "year";
            this.btnViewHistory.Text = "Display Transactions";
            this.btnViewHistory.UseVisualStyleBackColor = false;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnYear
            // 
            this.btnYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.btnYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYear.ForeColor = System.Drawing.Color.Black;
            this.btnYear.Location = new System.Drawing.Point(57, 303);
            this.btnYear.Margin = new System.Windows.Forms.Padding(4);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(160, 64);
            this.btnYear.TabIndex = 6;
            this.btnYear.Tag = "year";
            this.btnYear.Text = "Year";
            this.btnYear.UseVisualStyleBackColor = false;
            this.btnYear.Click += new System.EventHandler(this.btnDisplayBy_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.ForeColor = System.Drawing.Color.Black;
            this.btnMonth.Location = new System.Drawing.Point(57, 231);
            this.btnMonth.Margin = new System.Windows.Forms.Padding(4);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(160, 64);
            this.btnMonth.TabIndex = 5;
            this.btnMonth.Tag = "month";
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = false;
            this.btnMonth.Click += new System.EventHandler(this.btnDisplayBy_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Display By";
            // 
            // btnDay
            // 
            this.btnDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(184)))), ((int)(((byte)(60)))));
            this.btnDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.ForeColor = System.Drawing.Color.Black;
            this.btnDay.Location = new System.Drawing.Point(57, 160);
            this.btnDay.Margin = new System.Windows.Forms.Padding(4);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(160, 64);
            this.btnDay.TabIndex = 4;
            this.btnDay.Tag = "day";
            this.btnDay.Text = "Day";
            this.btnDay.UseVisualStyleBackColor = false;
            this.btnDay.Click += new System.EventHandler(this.btnDisplayBy_Click);
            // 
            // chartSales
            // 
            this.chartSales.BackColor = System.Drawing.Color.Cornsilk;
            this.chartSales.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartSales.BorderlineColor = System.Drawing.Color.Empty;
            this.chartSales.BorderlineWidth = 2;
            this.chartSales.BorderSkin.BackColor = System.Drawing.Color.DarkGray;
            this.chartSales.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartSales.BorderSkin.BorderColor = System.Drawing.Color.Maroon;
            chartArea2.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSales.Legends.Add(legend2);
            this.chartSales.Location = new System.Drawing.Point(37, 98);
            this.chartSales.Name = "chartSales";
            this.chartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Sales";
            this.chartSales.Series.Add(series2);
            this.chartSales.Size = new System.Drawing.Size(1350, 491);
            this.chartSales.TabIndex = 9;
            this.chartSales.Text = "MONTHS";
            // 
            // printPreview
            // 
            this.printPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreview.Enabled = true;
            this.printPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreview.Icon")));
            this.printPreview.Name = "printPreview";
            this.printPreview.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // frmTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1689, 991);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.dgvTransactionHistory);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTransactionHistory";
            this.Text = "Transaction History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTransactionHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactionHistory;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.Button btnYear;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.CheckBox chkWithTransactionHistory;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}