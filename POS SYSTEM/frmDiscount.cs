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
    public partial class frmDiscount : Form
    {
        double discountValue;
        string discountType = "";
        public frmDiscount()
        {
            InitializeComponent();


            switch (Transact.DiscountType)
            {
                case "Senior Citizen":
                    lstDiscountType.SelectedIndex = 0;
                    break;
                case "PWD":
                    lstDiscountType.SelectedIndex = 1;
                    break;
                case "Other:":
                    lstDiscountType.SelectedIndex = 2;
                    break;
                default:
                    break;
            }
            txtDiscountValue.Text = string.Format("{0:#,##0}", (Transact.Discount * 100));
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (discountValue == (Convert.ToDouble(txtDiscountValue.Text) / 100))
            {
                Transact.Discount = discountValue;
            }
            else
            {
                Transact.Discount = Convert.ToDouble(txtDiscountValue.Text) / 100;
            }
            Transact.DiscountType = discountType;
            this.Close();
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.A))
            {
                Transact.Discount = discountValue;
                Transact.DiscountType = discountType;
                this.Close();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        // ----------------- Form Move Implementation  (Drag Form Body) ------------------

        private bool mouseDown;
        private Point lastLocation;
        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void listProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lstDiscountType.SelectedIndex)
            {
                case 0:
                    discountType = "SC";
                    discountValue = 0.20;
                    txtDiscountValue.Location = new System.Drawing.Point(357, 66);
                    lblPercent.Location = new System.Drawing.Point(427, 69);
                    txtDiscountName.Enabled = false;
                    txtDiscountValue.Enabled = false;
                    break;
                case 1:
                    discountType = "PWD";
                    discountValue = 0.20;
                    txtDiscountValue.Location = new System.Drawing.Point(357, 66);
                    lblPercent.Location = new System.Drawing.Point(427, 69);
                    txtDiscountName.Enabled = false;
                    txtDiscountValue.Enabled = false;
                    break;
                case 2:
                    discountType = "Other:";
                    if (txtDiscountValue.TextLength > 0)
                    {
                        discountValue = (Convert.ToDouble(txtDiscountValue.Text) / 100);
                    }
                    txtDiscountValue.Location = new System.Drawing.Point(357, 149);
                    lblPercent.Location = new System.Drawing.Point(427, 152);
                    txtDiscountName.Enabled = true;
                    txtDiscountValue.Enabled = true;
                    break;
                default:
                    break;
            }
            txtDiscountValue.Text = string.Format("{0:#,##0}", (discountValue * 100));
        }

        private void txtDiscountValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        private void txtDiscountValue_Leave(object sender, EventArgs e)
        {
            if(Convert.ToDouble(txtDiscountValue.Text) > 100 || Convert.ToDouble(txtDiscountValue.Text) < 0)
            {
                txtDiscountValue.Text = "0";
            }
        }

    }
}
