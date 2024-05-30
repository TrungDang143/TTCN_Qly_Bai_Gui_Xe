using Microsoft.IdentityModel.Tokens;
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

namespace QlyBaiGuiXe.GUI.VeXe
{
    public partial class fBTbangGia : Form
    {
        private int oldPrice;
        public fBTbangGia()
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

        private void fBTbangGia_Load(object sender, EventArgs e)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryLX = (from lx in db.LoaiXe
                               select lx).ToList();
                var queryLV = (from lv in db.LoaiVe
                               select lv).ToList();

                foreach (var item in queryLX)
                {
                    cbbLoaiXe.Items.Add(item.TenXe);
                }
                foreach (var item in queryLV)
                {
                    cbbLoaiVe.Items.Add(item.TenLoai);
                }
                cbbLoaiVe.Items.Add("Qua đêm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu bảng giá!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private string getMaXe(string name)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                return (from lx in db.LoaiXe where lx.TenXe.Equals(name) select lx.MaLoaiXe).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu loại xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
            
        }
        private string getMaVe(string name)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                return (from lv in db.LoaiVe where lv.TenLoai.Equals(name) select lv.MaLoaiVe).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu loại vé!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;

        }
        private void cbbLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                if(!cbbLoaiVe.Text.IsNullOrEmpty() && !cbbLoaiXe.Text.IsNullOrEmpty())
                    if (cbbLoaiVe.SelectedItem.Equals("Qua đêm"))
                    {
                        var queryGia = (from bg in db.GiaQuaDem
                                        where bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text)
                                        select bg.Gia).FirstOrDefault();
                        txbGia.Text = queryGia.ToString();
                        oldPrice = queryGia;
                    }
                    else
                    {
                        var queryGia = (from bg in db.BangGia
                                        where bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text) && bg.MaLoaiVe == getMaVe(cbbLoaiVe.Text)
                                        select bg.Gia).FirstOrDefault();
                        txbGia.Text = queryGia.ToString();
                        oldPrice = queryGia;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu bảng giá!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txbGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbGia.Text, out int result))
            {
                DialogResult kq = MessageBox.Show("Xác nhận cập nhật bảng giá:\n" + cbbLoaiXe.Text + " - " + cbbLoaiVe.Text + "\n" +"Từ " + oldPrice.ToString() + " thành " + txbGia.Text, "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == DialogResult.Yes)
                {
                    try
                    {
                        BaiXeDBContext db = new BaiXeDBContext();

                        if (cbbLoaiVe.SelectedItem.Equals("Qua đêm"))
                        {
                            var queryGia = (from bg in db.GiaQuaDem
                                            where bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text)
                                            select bg).FirstOrDefault();
                            queryGia.Gia = int.Parse(txbGia.Text);
                            db.SaveChanges();
                        }
                        else
                        {
                            var queryGia = (from bg in db.BangGia
                                            where bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text) && bg.MaLoaiVe == getMaVe(cbbLoaiVe.Text)
                                            select bg).FirstOrDefault();
                            queryGia.Gia = int.Parse(txbGia.Text);
                            db.SaveChanges();
                        }
                        MessageBox.Show("Thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật thông tin bảng giá!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
