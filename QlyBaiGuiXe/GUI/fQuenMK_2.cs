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
    public partial class fQuenMK_2 : Form
    {
        public fQuenMK_2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void fQuenMK_2_Load(object sender, EventArgs e)
        { 

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            txbN1.Focus();
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Setting.TitleBar.ReleaseCapture();
                Setting.TitleBar.SendMessage(Handle, Setting.TitleBar.WM_NCLBUTTONDOWN, Setting.TitleBar.HTCAPTION, 0);
            }
        }

        private void txbN1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbN1.Text))
                txbN1.Focus();
            else
                txbN2.Focus();
        }

        private void txbN2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbN2.Text))
                txbN1.Focus();
            else
                txbN3.Focus();
        }

        private void txbN3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbN3.Text))
                txbN2.Focus();
            else
                txbN4.Focus();
        }

        private void txbN4_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txbN4.Text))
                txbN3.Focus();
        }
    }
}
