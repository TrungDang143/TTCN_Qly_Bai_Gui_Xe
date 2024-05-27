using QlyBaiGuiXe.Entities;
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
    public partial class mainUI : Form
    {
        string nameChose = string.Empty;
        NhanVien currentNV =null;
        public bool isClose = true;

        public mainUI(NhanVien nv)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            currentNV = nv;
        }
        #region blur parent form
        static Setting.blurForm f;
        public void showBlur()
        {
            f = new Setting.blurForm();
            f.Owner = this;
            f.Location = this.Location;
            f.Size = this.ClientSize;
            f.Show();
        }
        public void closeBlur()
        {
            f.Close();
        }
        #endregion
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Setting.TitleBar.ReleaseCapture();
                Setting.TitleBar.SendMessage(Handle, Setting.TitleBar.WM_NCLBUTTONDOWN, Setting.TitleBar.HTCAPTION, 0);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            isClose = true;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_btnBaiXe_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                Panel panel = sender as Panel;
                panel.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            else if (sender is Label)
            {
                Label lb = sender as Label;
                Panel pnl = lb.Parent as Panel;
                pnl.BackColor = System.Drawing.Color.DarkSlateBlue;
            }
            else if (sender is PictureBox)
            {
                PictureBox pic = sender as PictureBox;
                Panel pnl = pic.Parent as Panel;
                pnl.BackColor = System.Drawing.Color.DarkSlateBlue;
            }

            if (nameChose.Equals("ucBaiXe")){
                pnl_btnBaiXe.BackColor = System.Drawing.Color.MidnightBlue;
            }
            else if (nameChose.Equals("ucVeXe"))
            {
                pnl_btnVeXe.BackColor = System.Drawing.Color.MidnightBlue;
            }
            else if (nameChose.Equals("ucThongKe"))
            {
                pnl_btnThongKe.BackColor = System.Drawing.Color.MidnightBlue;
            }
            else if (nameChose.Equals("ucTaiKhoan"))
            {
                pnl_btnTaiKhoan.BackColor = System.Drawing.Color.MidnightBlue;
            }
        }

        private void pnl_btnBaiXe_MouseMove(object sender, MouseEventArgs e)
        {
            if(sender is Panel)
            {
                Panel panel = sender as Panel;
                panel.BackColor = System.Drawing.Color.MidnightBlue;
            }
            else if(sender is Label)
            {
                Label lb = sender as Label;
                Panel pnl = lb.Parent as Panel;
                pnl.BackColor = System.Drawing.Color.MidnightBlue;
            }
            else if (sender is PictureBox)
            {
                PictureBox pic = sender as PictureBox;
                Panel pnl = pic.Parent as Panel;
                pnl.BackColor = System.Drawing.Color.MidnightBlue;

            }
        }

        private void resetSelect()
        {
            pnl_btnBaiXe.BackColor = System.Drawing.Color.DarkSlateBlue;
            pnl_btnVeXe.BackColor = System.Drawing.Color.DarkSlateBlue;
            pnl_btnThongKe.BackColor = System.Drawing.Color.DarkSlateBlue;
            pnl_btnTaiKhoan.BackColor = System.Drawing.Color.DarkSlateBlue;

            pnlMain.Controls.Clear();
        }


        private void mainUI_Load(object sender, EventArgs e)
        {
            resetSelect();
            pnl_btnBaiXe_Click(pnl_btnBaiXe, EventArgs.Empty);
            lbMaNV.Text = currentNV.HoTen + "\n" + currentNV.MaNv;
            int x = (panel4.Width - lbMaNV.Width) / 2;
            int y = (panel4.Height - lbMaNV.Height) / 2;
            lbMaNV.Location = new Point(x, y);
        }

        private void pnl_btnBaiXe_Click(object sender, EventArgs e)
        {
            nameChose = "ucBaiXe";

            resetSelect();
            pnl_btnBaiXe.BackColor = System.Drawing.Color.MidnightBlue;

            ucBaiXe newUC = new ucBaiXe(currentNV);
            pnlMain.Controls.Add(newUC);
        }

        private void pnl_btnVeXe_Click(object sender, EventArgs e)
        {
            nameChose = "ucVeXe";

            resetSelect();
            pnl_btnVeXe.BackColor = System.Drawing.Color.MidnightBlue;

            ucVeXe newUC = new ucVeXe();
            pnlMain.Controls.Add(newUC);
        }

        private void pnl_btnThongKe_Click(object sender, EventArgs e)
        {
            nameChose = "ucThongKe";

            resetSelect();
            pnl_btnThongKe.BackColor = System.Drawing.Color.MidnightBlue;

            ucThongKe newUC = new ucThongKe();
            pnlMain.Controls.Add(newUC);
        }

        private void pnl_btnTaiKhoan_Click(object sender, EventArgs e)
        {
            nameChose = "ucTaiKhoan";

            resetSelect();
            pnl_btnTaiKhoan.BackColor = System.Drawing.Color.MidnightBlue;

            ucTaiKhoan newUC = new ucTaiKhoan(currentNV);
            pnlMain.Controls.Add(newUC);
        }

        private void mainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose)
            {
                Application.Exit();
            }
        }
    }
}
