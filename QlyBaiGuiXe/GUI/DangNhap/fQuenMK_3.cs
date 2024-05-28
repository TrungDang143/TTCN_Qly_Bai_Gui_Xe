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
    public partial class fQuenMK_3 : Form
    {
        string manv;
        public fQuenMK_3(string manv)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            this.manv = manv;
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
            if(lbCanhBao.Visible == false)
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();

                    var taiKhoan = (from tk in db.TaiKhoan
                                    where tk.TenDangNhap == manv
                                    select tk).FirstOrDefault();
                    taiKhoan.MatKhau = txbMk1.Text;

                    db.SaveChanges();
                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu nhân viên!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }      
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

        private void txbMk1_TextChanged(object sender, EventArgs e)
        {
            if (txbMk1.Text.Equals(txbMk2.Text))
            {
                lbCanhBao.Visible = false;
            }
            else
            {
                lbCanhBao.Visible = true;
            }
        }
    }
}
