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
    public partial class fBTTTveThang : Form
    {
        public fBTTTveThang()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

        }

        private void showVeThang()
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryVT = (from vt in db.VeThang
                               join x in db.Xe on vt.BienSo equals x.BienSo
                               join lx in db.LoaiXe on x.MaLoaiXe equals lx.MaLoaiXe
                               join kh in db.KhachHang on vt.MaKh equals kh.MaKh
                               select new
                               {
                                   vt.MaVe,
                                   kh.HoTen,
                                   lx.TenXe,
                                   x.BienSo,
                                   tg = vt.ThoiHan.Date.ToString("dd/MM/yyyy"),
                               }).ToList();
                dgvVT.DataSource = queryVT;

                dgvVT.Columns[0].HeaderText = "Mã vé";
                dgvVT.Columns[1].HeaderText = "Họ tên";
                dgvVT.Columns[2].HeaderText = "Loại xe";
                dgvVT.Columns[3].HeaderText = "Biển số";
                dgvVT.Columns[4].HeaderText = "Thời hạn";

                dgvVT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvVT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvVT.AutoResizeColumns();
                dgvVT.AutoResizeRows();

                var queryLX = (from lx in db.LoaiXe
                               select lx.TenXe).ToList();
                foreach (var x in queryLX)
                {
                    cbbLoaiXe.Items.Add(x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fBTTTveThang_Load(object sender, EventArgs e)
        {
            dtpkTH.Format = DateTimePickerFormat.Custom;
            dtpkTH.CustomFormat = "dd/MM/yyyy";
            dtpkTH.Text = string.Empty;

            showVeThang();

            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn xoá vé tháng?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                // xu ly sql
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();

                    var vt = db.VeThang.Find(txbMaVe.Text);
                    var kh = db.KhachHang.Find(vt.MaKh);
                    var xe = db.Xe.Find(vt.BienSo);

                    db.Remove(vt);
                    db.Remove(xe);
                    db.Remove(kh);
                    db.SaveChanges();

                    MessageBox.Show("Xoá vé tháng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetSelect();
                    showVeThang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xoá vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryVT = (from vt in db.VeThang
                               join x in db.Xe on vt.BienSo equals x.BienSo
                               join lx in db.LoaiXe on x.MaLoaiXe equals lx.MaLoaiXe
                               join kh in db.KhachHang on vt.MaKh equals kh.MaKh
                               where kh.HoTen.Contains(txbTimKiem.Text)
                               select new
                               {
                                   vt.MaVe,
                                   kh.HoTen,
                                   lx.TenXe,
                                   x.BienSo,
                                   tg = vt.ThoiHan.Date.ToString("dd/MM/yyyy"),
                               }).ToList();
                dgvVT.DataSource = queryVT.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin nhân viên!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void dgvVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                DataGridViewRow dataRow = dgvVT.Rows[row];
                //choseNV = dataRow.Cells[0].Value.ToString();.
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();
                    var queryVT = (from vt in db.VeThang
                                   join x in db.Xe on vt.BienSo equals x.BienSo
                                   join lx in db.LoaiXe on x.MaLoaiXe equals lx.MaLoaiXe
                                   join kh in db.KhachHang on vt.MaKh equals kh.MaKh
                                   where vt.MaVe == dataRow.Cells[0].Value.ToString()
                                   select new
                                   {
                                       mave = vt.MaVe,
                                       tenxe = lx.TenXe,
                                       bienso = x.BienSo,
                                       chuxe = kh.HoTen,
                                       gt = kh.GioiTinh?"Nam":"Nữ",
                                       dc = kh.DiaChi,
                                       sdt = kh.Sdt,
                                       tg = vt.ThoiHan.Date,
                                   }).FirstOrDefault();

                    txbMaVe.Text = queryVT.mave;
                    cbbLoaiXe.SelectedItem = queryVT.tenxe;
                    cbbGioiTinh.SelectedItem = queryVT.gt;
                    txbBienSo.Text = queryVT.bienso;
                    txbChuXe.Text = queryVT.chuxe;
                    txbDiaChi.Text = queryVT.dc;
                    txbSDT.Text = queryVT.sdt;
                    dtpkTH.Value = queryVT.tg;

                    txbMucPhi.Text = (from bg in db.BangGia
                                      where bg.MaLoaiVe == "VT" && bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text)
                                      select bg.Gia).FirstOrDefault().ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy thông tin vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool checkHopLe()
        {
            if (txbBienSo.Text.IsNullOrEmpty() ||
                txbChuXe.Text.IsNullOrEmpty() ||
                txbDiaChi.Text.IsNullOrEmpty() ||
                txbMaVe.Text.IsNullOrEmpty() ||
                txbMucPhi.Text.IsNullOrEmpty() ||
                txbSDT.Text.IsNullOrEmpty() ||
                cbbGioiTinh.Text.IsNullOrEmpty() ||
                cbbLoaiXe.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void resetSelect()
        {
            txbBienSo.Text = string.Empty;
            txbChuXe.Text = string.Empty;
            txbDiaChi.Text = string.Empty;
            txbMaVe.Text = string.Empty;
            txbMucPhi.Text = string.Empty;
            txbSDT.Text = string.Empty;
            txbTimKiem.Text = string.Empty;
            cbbGioiTinh.Text = string.Empty;
            cbbLoaiXe.Text = string.Empty;
            dtpkTH.Text = string.Empty;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkHopLe())
            {
                DialogResult kq = MessageBox.Show("Xác nhận cập nhật thông tin vé tháng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    // xu ly sql
                    try
                    {
                        BaiXeDBContext db = new BaiXeDBContext();
                        VeThang vt = db.VeThang.Find(txbMaVe.Text);
                        KhachHang kh = db.KhachHang.Find(vt.MaKh);

                        kh.DiaChi = txbDiaChi.Text;
                        kh.HoTen = txbChuXe.Text;
                        kh.Sdt = txbSDT.Text;
                        kh.GioiTinh = cbbGioiTinh.Text == "Nam" ? true : false;

                        db.SaveChanges();
                        try
                        {
                            Xe xe = db.Xe.Find(vt.BienSo);
                            xe.BienSo = txbBienSo.Text;
                            xe.MaLoaiXe = getMaXe(cbbLoaiXe.Text);

                            db.SaveChanges();

                            try
                            {
                                vt.BienSo = xe.BienSo;

                                db.SaveChanges();

                                MessageBox.Show("Thay đổi thông tin vé tháng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                showVeThang();
                                resetSelect();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi thay đổi thông tin vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi thay đổi thông tin xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thay đổi thông tin khách hàng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cbbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaiXeDBContext db = new BaiXeDBContext();
            txbMucPhi.Text = (from bg in db.BangGia
                              where bg.MaLoaiVe == "VT" && bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text)
                              select bg.Gia).FirstOrDefault().ToString();
        }
    }
}
