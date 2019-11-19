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
    public partial class frmDevelopers : Form
    {
        private List<Panel> panels;
        private List<PictureBox> pics;
        public frmDevelopers()
        {
            InitializeComponent();
            panels = new List<Panel>()
            {
                panel1, panel2, panel3, panel4
            };
            pics = new List<PictureBox>()
            {
                pic1, pic2, pic3, pic4
            };

            foreach (Panel item in panels)
            {
                item.Visible = false;
            }
            formResize();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void formResize()
        {
            lbl1.Location = new System.Drawing.Point((this.ClientSize.Width / 2) - (lbl1.Width / 2), lbl1.Location.Y);
            picBusiness.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - (picBusiness.Width / 2), picBusiness.Location.Y);
            lbl2.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - (lbl2.Width / 2), lbl2.Location.Y);
            picISee.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - (picISee.Width / 2), picISee.Location.Y);
            lbl3.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - (lbl3.Width / 2), lbl3.Location.Y);


            pic1.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 1) - (pic1.Width / 2), pic1.Location.Y);
            pic2.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 2) - (pic2.Width / 2), pic2.Location.Y);
            pic3.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 3) - (pic3.Width / 2), pic3.Location.Y);
            pic4.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 4) - (pic4.Width / 2), pic4.Location.Y);

            panel1.Location = pic1.Location;
            panel2.Location = pic2.Location;
            panel3.Location = pic3.Location;
            panel4.Location = pic4.Location;

            lblPO.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 1) - (lblPO.Width / 2), lblPO.Location.Y);
            lblPM.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 2) - (lblPM.Width / 2), lblPM.Location.Y);
            lblBA.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 3) - (lblBA.Width / 2), lblBA.Location.Y);
            lblSE.Location = new System.Drawing.Point((this.ClientSize.Width / 5 * 4) - (lblSE.Width / 2), lblSE.Location.Y);

            btnCancel.Location = new System.Drawing.Point(this.ClientSize.Width - btnCancel.Width - 10, 10);
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

        private void devIcon_Click(object sender, EventArgs e)
        {
            PictureBox pic = ((PictureBox)sender);
            
            if(pic.Visible == true)
            {
                panels[Convert.ToInt32(pic.Tag)].Visible = true;
                pic.Visible = false;
            }
        }

        private void devPanel_Click(object sender, EventArgs e)
        {
            Panel pan = ((Panel)sender);

            if (pan.Visible == true)
            {
                pics[Convert.ToInt32(pan.Tag)].Visible = true;
                pan.Visible = false;
            }
        }

        private void frmDevelopers_Resize(object sender, EventArgs e)
        {
            formResize();
        }

        private void devIcon_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = ((PictureBox)sender);

            pic.Size = new System.Drawing.Size(290, 290);
        }

        private void devIcon_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = ((PictureBox)sender);
            pic.Size = new System.Drawing.Size(280, 280);
        }

    }
}
