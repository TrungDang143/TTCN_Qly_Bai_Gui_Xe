using QlyBaiGuiXe.Entities;
using QlyBaiGuiXe.GUI;
using QlyBaiGuiXe.Setting;
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
            // neu dung thong tin o 2 o tk va email
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var check = (from nv in db.NhanVien
                             where nv.MaNv == txbTk.Text
                             && nv.Email == txbEmail.Text
                             select nv).Count() == 1;
                if (check)
                {
                    string code = sendEmail.send(txbEmail.Text);

                    fQuenMK_2 newForm = new fQuenMK_2(txbTk.Text, txbEmail.Text, code);
                    this.Hide();
                    newForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi trong quá trình gửi mã!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }

        private void fQuenMK_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fDangNhap newForm = new fDangNhap();
            newForm.Show(); 
        }
    }
}
