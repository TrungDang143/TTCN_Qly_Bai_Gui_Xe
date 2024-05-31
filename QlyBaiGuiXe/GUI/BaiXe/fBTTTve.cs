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

namespace QlyBaiGuiXe.GUI.BaiXe
{
    public partial class fBTTTve : Form
    {
        HoaDon HD;
        public fBTTTve(HoaDon a)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            HD = a;
        }

        private void fBTTTve_Load(object sender, EventArgs e)
        {
            dtpkTGN.Format = DateTimePickerFormat.Custom;
            dtpkTGN.CustomFormat = "HH:mm - dd/MM/yyyy";
            dtpkTGX.Format = DateTimePickerFormat.Custom;
            dtpkTGX.CustomFormat = "HH:mm - dd/MM/yyyy";
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                var loaixe = (from lx in db.LoaiXe
                              select lx.TenXe).ToList();
                foreach (var l in loaixe)
                {
                    cbbLoaiXe.Items.Add(l);
                }

                var queryBaiXe = (from hd in db.HoaDon
                                  join LV in db.LoaiVe on hd.MaLoaiVe equals LV.MaLoaiVe
                                  join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                  where hd.MaHd == HD.MaHd
                                  select new
                                  {
                                      hd.MaVe,
                                      LV.TenLoai,
                                      maLX.TenXe,
                                      hd.BienSo,
                                      hd.TgVao,
                                      hd.TgRa,
                                      hd.Gia
                                  }).FirstOrDefault();

                txbMaVe.Text = queryBaiXe.MaVe;
                txbLoaiVe.Text = queryBaiXe.TenLoai;
                cbbLoaiXe.SelectedItem = queryBaiXe.TenXe;
                txbBienSo.Text = queryBaiXe.BienSo;
                dtpkTGN.Value = queryBaiXe.TgVao;
                txbMucPhi.Text = HD.Gia.ToString("N0");
                if (queryBaiXe.TgRa == null)
                {
                    dtpkTGN.Enabled = true;
                    dtpkTGX.Visible = false;
                }
                else
                {
                    dtpkTGX.Value = queryBaiXe.TgRa.Value;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu hoá đơn!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if(HD.MaLoaiVe == "VT")
            {
                cbbLoaiXe.Enabled = false;
                txbBienSo.Enabled = false;
                txbBienSo.BackColor = Color.Lavender;
            }

        }
        private string getMaLoaiXe(string name)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                var loaixe = (from lx in db.LoaiXe
                              where lx.TenXe.CompareTo(name) == 0
                              select lx.MaLoaiXe).FirstOrDefault();
                return loaixe;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã loại xe!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private string getMucPhi()
        {
            if (!cbbLoaiXe.Text.IsNullOrEmpty())
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();

                    var mp = (from bg in db.BangGia
                              where bg.MaLoaiVe == HD.MaLoaiVe
                              && bg.MaLoaiXe == getMaLoaiXe(cbbLoaiXe.Text)
                              select bg.Gia).FirstOrDefault();
                    return mp.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu mức phí!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return null;
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

        private void cbbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbMucPhi.Text = getMucPhi();
        }

        private bool checkHopLe()
        {
            if(cbbLoaiXe.Text.IsNullOrEmpty() ||
                txbBienSo.Text.IsNullOrEmpty() ||
                dtpkTGN.Value > DateTime.Now)
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkHopLe())
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();

                    var hoadon = db.HoaDon.Find(HD.MaHd);

                    if (hoadon.MaLoaiVe == "VL")
                    {
                        hoadon.MaLoaiXe = getMaLoaiXe(cbbLoaiXe.Text);
                        hoadon.TgVao = dtpkTGN.Value;
                        var ve = (from vl in db.VeLuot
                                  where vl.MaVe == hoadon.MaVe
                                  select vl).FirstOrDefault();
                        ve.BienSo = txbBienSo.Text;
                        db.SaveChanges();
                    }
                    else
                    {
                        hoadon.TgVao = dtpkTGN.Value;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật thông tin vé!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
