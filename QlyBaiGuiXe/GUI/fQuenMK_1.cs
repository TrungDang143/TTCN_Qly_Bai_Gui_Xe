using QlyBaiGuiXe.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe
{
    public partial class fQuenMK_1 : Form
    {
        public fQuenMK_1()
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

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            fQuenMK_2 newForm = new fQuenMK_2();
            this.Hide();
            newForm.ShowDialog();
            this.Show();
        }
    }
}
