using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI.BaiXe
{
    public partial class fBTTTve : Form
    {
        public fBTTTve()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

        }

        private void fBTTTve_Load(object sender, EventArgs e)
        {
            dtpkTGN.Format = DateTimePickerFormat.Custom;
            dtpkTGN.CustomFormat = "HH:mm - dd/MM/yyyy";
            dtpkTGX.Format = DateTimePickerFormat.Custom;
            dtpkTGX.CustomFormat = "HH:mm - dd/MM/yyyy";
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
    }
}
