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

namespace QlyBaiGuiXe.GUI.TaiKhoan
{
    public partial class fDoiMatKhau : Form
    {
        private NhanVien currentNV = null;
        public fDoiMatKhau(NhanVien currentNV)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            this.currentNV = currentNV;
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

        bool showPassCu = false;
        private void picMk_Click(object sender, EventArgs e)
        {
            if (showPassCu == false)
            {
                this.picMk1.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMkCu.PasswordChar = '\0';
                showPassCu = true;
            }
            else
            {
                this.picMk1.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMkCu.PasswordChar = '\u2022';
                showPassCu = false;
            }
        }

        bool showPass1 = false;
        private void picMk1_Click(object sender, EventArgs e)
        {
            if (showPass1 == false)
            {
                this.picMk2.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMk1.PasswordChar = '\0';
                showPass1 = true;
            }
            else
            {
                this.picMk2.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMk1.PasswordChar = '\u2022';
                showPass1 = false;
            }
        }
        bool showPass2 = false;
        private void picMk2_Click(object sender, EventArgs e)
        {
            if (showPass2 == false)
            {
                this.picMk3.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMk2.PasswordChar = '\0';
                showPass2 = true;
            }
            else
            {
                this.picMk3.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMk2.PasswordChar = '\u2022';
                showPass2 = false;
            }
        }

        private void txbMk2_TextChanged(object sender, EventArgs e)
        {
            if(txbMk1.Text.CompareTo(txbMk2.Text) != 0)
            {
                lbCanhBao.Visible = true;
            }
            else
            {
                lbCanhBao.Visible = false;
            }
        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            if(lbCanhBao.Visible == true)
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();

                    Entities.TaiKhoan tk = db.TaiKhoan.Find(currentNV.MaTk);
                    if (tk != null)
                    {
                        tk.MatKhau = txbMk1.Text;

                        db.SaveChanges();
                    }
                    DialogResult ok = MessageBox.Show("Vui lòng đăng nhập lại hệ thống!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy cập nhật thông tin nhân viên!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
