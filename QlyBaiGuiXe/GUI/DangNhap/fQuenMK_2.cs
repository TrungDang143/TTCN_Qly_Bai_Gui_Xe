using Microsoft.IdentityModel.Tokens;
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

namespace QlyBaiGuiXe.GUI
{
    public partial class fQuenMK_2 : Form
    {
        private string code;
        private string email;
        private string manv;
        public fQuenMK_2(string manv, string email, string code)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            this.code = code;
            this.email = email;
            this.manv = manv;
        }

        private void fQuenMK_2_Load(object sender, EventArgs e)
        {
            lbEmail.Text = "Mã bảo mật đã được gửi về email:\n" + email;
            int x = (panel1.Width - lbEmail.Width) / 2;
            int y = (panel1.Height - lbEmail.Height) / 2;
            lbEmail.Location = new Point(x, y);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //neu dung ma xac nhan
            if (checkHopLe())
            {
                fQuenMK_3 newForm = new fQuenMK_3(manv);
                this.Hide();
                newForm.ShowDialog();
                this.Close();
            }

            
        }

        private void fQuenMK_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //fDangNhap newForm = new fDangNhap();
            //newForm.Show();
        }

        private string getInput()
        {
            return txbN1.Text + txbN2.Text + txbN3.Text + txbN4.Text;
        }
        private bool checkHopLe()
        {
            if(txbN1.Text.IsNullOrEmpty() ||
                txbN2.Text.IsNullOrEmpty() ||
                txbN3.Text.IsNullOrEmpty() ||
                txbN4.Text.IsNullOrEmpty())
            {
                lbCanhBao.Visible = true;
                lbCanhBao.Text = "Nhập mã xác thực gồm 4 ký tự số";
                return false;
            }
            else
            {
                string input = getInput();
                if (input.Equals(code))
                {
                    lbCanhBao.Visible = false;
                    return true;
                }
                else
                {
                    lbCanhBao.Visible = true;
                    lbCanhBao.Text = "Vui lòng kiểm tra lại mã xác nhận";
                    return false;
                }
            }
        }

        private void lbGuiLai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            code = sendEmail.send(email);
            MessageBox.Show("Gửi mã thành công. Vui lòng kiểm tra email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);   
        }
    }
}
