using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI
{
    public partial class fQuenMK_3 : Form
    {
        public fQuenMK_3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Setting.TitleBar.ReleaseCapture();
                Setting.TitleBar.SendMessage(Handle, Setting.TitleBar.WM_NCLBUTTONDOWN, Setting.TitleBar.HTCAPTION, 0);
            }
        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            // neu mat khau o 2 o textbox trung nhau.......
            this.Close();
        }

        bool showPass1 = false;
        private void picMk_Click(object sender, EventArgs e)
        {
            if (showPass1 == false)
            {
                this.picMk1.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMk1.PasswordChar = '\0';
                showPass1 = true;
            }
            else
            {
                this.picMk1.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMk1.PasswordChar = '\u2022';
                showPass1 = false;
            }
        }
        bool showPass2 = false;
        private void picMk2_Click(object sender, EventArgs e)
        {
            if (showPass2 == false)
            {
                this.picMk2.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMk2.PasswordChar = '\0';
                showPass2 = true;
            }
            else
            {
                this.picMk2.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMk2.PasswordChar = '\u2022';
                showPass2 = false;
            }
        }

        private void fQuenMK_3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //fDangNhap newForm = new fDangNhap();
            //newForm.Show();
        }
    }
}
