using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI.TaiKhoan
{
    public partial class fQlyNhanVien : Form
    {
        public fQlyNhanVien()
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool showPass = false;
        private void picMk_Click(object sender, EventArgs e)
        {
            if (showPass == false)
            {
                this.picMk.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMk.PasswordChar = '\0';
                showPass = true;
            }
            else
            {
                this.picMk.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMk.PasswordChar = '\u2022';
                showPass = false;
            }
        }
        bool showEmail = false;
        private void picEmail_Click(object sender, EventArgs e)
        {
            if (showEmail == false)
            {
                this.picEmail.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbEmail.PasswordChar = '\0';
                showEmail = true;
            }
            else
            {
                this.picEmail.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbEmail.PasswordChar = '\u2022';
                showEmail = false;
            }
        }

        private void fQlyNhanVien_Load(object sender, EventArgs e)
        {
            dtpk.Format = DateTimePickerFormat.Custom;
            dtpk.CustomFormat = "dd/MM/yyyy)";
        }
    }
}
