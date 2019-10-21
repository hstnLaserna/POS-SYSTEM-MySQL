using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS_SYSTEM
{
    public partial class frmMilkTea : Form
    {
        MilkTea Milktea = new MilkTea();
        Transact Transact = new Transact();
        CheckBox chk;
        RadioButton rb;
        double sinkers;
        double Price1, Price2, Price3;
        double quantity = 0;
        public static string hist;


        public frmMilkTea(string MilkTeaName, double price1, double price2, double price3)
        {
            InitializeComponent();
            Milktea.MilkteaName = MilkTeaName;
            Price1 = price1;
            Price2 = price2;
            Price3 = price3;
            lblMilkTeaName.Text = Milktea.MilkteaName;
            numQuantity.Text = quantity.ToString();
            rbtn100P.Checked = true;
        }

        private void frmMilkTea_Load(object sender, EventArgs e)
        {
            if (Price1 > 0)
            {
                radSize1.Enabled = true;
            }
            else { }
            if (Price2 > 0)
            {
                radSize2.Enabled = true;
            }
            else { }
            if (Price3 > 0)
            {
                radSize3.Enabled = true;
            }
            else { }
            formResize();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Milktea.Quantity = Convert.ToDouble(numQuantity.Value);
            Milktea.ComputePrice();
            TransactionHistory.priceTotal.Add(Milktea.MilkteaPrice);
            Transact.Total = TransactionHistory.priceTotal.Sum();
            Transact.isVATable(Transact.Total);
            hist = "Milktea: " + Milktea.MilkteaName + "\r\n" + "Size: " + Milktea.Size + "\r\n" + "Sugar Level: " + Milktea.SugarLevel + "\r\n" + "Add-ons: " + Milktea.Sinkers + "\r\n" + "Price: " + Milktea.MilkteaPrice.ToString() + "\r\n";
            TransactionHistory.History.Add(hist);
            this.Close();
        }



        private void getSizePrice(object sender, EventArgs e)
        {
            rb = sender as RadioButton;
            if (rb.Text == "Regular")
            {
                Milktea.SizePrice = Price1;
            }
            else if (rb.Text == "Large")
            {
                Milktea.SizePrice = Price2;
            }
            Milktea.Size = rb.Text;
        }
        private void getSugarLevel(object sender, EventArgs e)
        {
            rb = sender as RadioButton;
            Milktea.SugarLevel = rb.Text;
        }

        private double getSinkersPrice(object sender)
        {
            chk = sender as CheckBox;
            if (chk.Text == "Pearl")
            {
                sinkers = 10;
            }
            else if (chk.Text == "Coffee Jelly")
            {
                sinkers = 10;
            }
            else if (chk.Text == "Coconut Jelly")
            {
                sinkers = 15;
            }
            else if (chk.Text == "Pudding")
            {
                sinkers = 20;
            }
            else if (chk.Text == "Aloe")
            {
                sinkers = 15;
            }
            else if (chk.Text == "Red Bean")
            {
                sinkers = 20;
            }
            return sinkers;
        }
        private void getSinkers(object sender, EventArgs e)
        {
            chk = sender as CheckBox;
            if (chk.Checked == true)
            {
                Milktea.Sinkers += chk.Text + " ";
                Milktea.SinkerPrice += getSinkersPrice(sender);
                sinkers = 0;
            }
            else if (chk.Checked == false)
            {
                Milktea.Sinkers = Milktea.Sinkers.Replace(chk.Text, "");
                Milktea.SinkerPrice -= getSinkersPrice(sender);
                sinkers = 0;
            }
        }

        #region Misc Methods

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
                this.Opacity = 0.8;
                this.Update();
            }
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Opacity = 1;
        }

        private void formResize()
        {
            lblMilkTeaName.Location = new System.Drawing.Point(ClientSize.Width / 2 - (lblMilkTeaName.Size.Width / 2), lblMilkTeaName.Location.Y);
            //tabControl1.Size = new System.Drawing.Size(ClientSize.Width * 3 / 4, ClientSize.Height - 5);
            /*grpVendoUI.Size = new System.Drawing.Size(ClientSize.Width * 4 / 5, 850);
            grpVendoUI.Location = new System.Drawing.Point(ClientSize.Width / 2 - ((grpVendoUI.Size.Width) / 2), ClientSize.Height / 2 - ((grpVendoUI.Size.Height) / 2));
            txtName.Size = new System.Drawing.Size(grpVendoUI.Size.Width - 4, 45);
            txtCurrentCredit.Size = new System.Drawing.Size(grpVendoUI.Size.Width - lblCreditAmount.Size.Width, 45);
            txtCurrentCredit.Location = new System.Drawing.Point(lblCreditAmount.Size.Width + 2, txtName.Location.Y + txtName.Size.Height + 5);
            btnCash.Location = new System.Drawing.Point((grpVendoUI.Size.Width / 3) - (btnCash.Size.Width / 2) - (50), txtCurrentCredit.Location.Y + txtCurrentCredit.Size.Height + 15);
            btnCredit.Location = new System.Drawing.Point((grpVendoUI.Size.Width * 2 / 3) - (btnCredit.Size.Width / 2) + (50), btnCash.Location.Y);
            lblCoinsInserted.Location = new System.Drawing.Point((grpVendoUI.Size.Width / 2) - (lblCoinsInserted.Size.Width / 2), btnCredit.Location.Y + btnCredit.Size.Height + 15);
            btnCancel.Location = new System.Drawing.Point(grpVendoUI.Size.Width / 2 - ((btnCancel.Size.Width) / 2), lblProduct10.Location.Y + lblProduct10.Size.Height + 15);
            txtEmpID.Location = new System.Drawing.Point(ClientSize.Width / 2, ClientSize.Height / 2);
        
              */
        }  
        #endregion
    }
}
