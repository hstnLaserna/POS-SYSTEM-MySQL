using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SYSTEM
{
    public partial class frmCash : Form
    {
        bool addOperation = true ;
        double cash;
        public frmCash()
        {
            InitializeComponent();
            btnAdd.Enabled = false;
            cash = Transact.Cash;
            lblCash.Text = string.Format("{0:#,##0.00}", cash);
        }

        private void buttonBill_Click(object sender, EventArgs e)
        {
            if (addOperation)
            {
                if ((cash + Convert.ToDouble(((Button)sender).Tag)) <= 9999999999)
                {
                    cash += Convert.ToDouble(((Button)sender).Tag);
                }
            }
            else if ((cash - Convert.ToDouble(((Button)sender).Tag)) >= 0)
            {
                cash -= Convert.ToDouble(((Button)sender).Tag);
            }
            else { }


            lblCash.Text = string.Format("{0:#,##0.00}", cash);
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnSubtract.Enabled = false; 
            if(((Button)sender).Text == "+")
            {
                addOperation = true;
                btnSubtract.Enabled = true;
                lblCash.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            }
            else
            {
                addOperation = false;
                btnAdd.Enabled = true;
                lblCash.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Transact.Cash = cash;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cash = 0;
            lblCash.Text = "0.00";
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Delete) || keyData == (Keys.Back))
            {
                cash = 0;
                lblCash.Text = "0.00";
                return true;
            }
            if (keyData == (Keys.Alt | Keys.A))
            {
                Transact.Cash = cash;
                this.Close();
                return true;
            }


            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            if (keyData == (Keys.RControlKey | Keys.F12))
            {
                Application.Exit();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
