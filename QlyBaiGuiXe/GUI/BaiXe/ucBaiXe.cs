using Microsoft.EntityFrameworkCore;
using QlyBaiGuiXe.GUI.BaiXe;
using QlyBaiGuiXe.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;

namespace QlyBaiGuiXe.GUI
{
    public partial class ucBaiXe : UserControl
    {
        BaiXeDBContext db = new BaiXeDBContext();
        NhanVien currentNV;
        HoaDon hoadon;

        public ucBaiXe(NhanVien nv)
        {
            InitializeComponent();
            currentNV = nv;
            lbNgay.Text = "Ngày: " + DateTime.Now.Date.ToString("dd/MM/yyyy");
            ucBaiXeLoad();
        }
        private void LoadComboBox_LoaiVe()
        {
            cbbLoaiVe.Items.Clear();
            var loaive = (from lv in db.LoaiVe
                          select lv.TenLoai).ToList();
            foreach (var loaix in loaive)
            {
                cbbLoaiVe.Items.Add(loaix);
            }
        }
        private void LoadComboBox_LoaiXe()
        {
            cbbLoaiXe.Items.Clear();
            var loaixe = (from lx in db.LoaiXe
                          select lx.TenXe).ToList();
            foreach(var loaix in loaixe)
            {
                cbbLoaiXe.Items.Add(loaix);
            }
        }

        private static string getTenNV(string manv)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var ten = (from nv in db.NhanVien
                           where nv.MaNv == manv
                           select nv.HoTen).FirstOrDefault();
                if(ten == null)
                {
                    return "#";
                }
                return ten;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy tên nhân viên\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private static string getTenVe(string mave)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var ve = (from v in db.LoaiVe
                          where v.MaLoaiVe == mave
                          select v.TenLoai).FirstOrDefault();
                return ve;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy tên loại vé!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private void ucBaiXeLoad()
        {
            
            // load data grid view
            dgvBaiXe.AutoGenerateColumns = true;
            var queryBaiXe = from hd in db.HoaDon
                             join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                             join maLV in db.LoaiVe on hd.MaLoaiVe equals maLV.MaLoaiVe
                             orderby hd.TgRa ascending
                             //orderby hd.TgVao descending
                             select new
                             {
                                 hd.MaVe,
                                 maLV.TenLoai,
                                 maLX.TenXe,
                                 hd.BienSo,
                                 hd.TgVao,
                                 hd.TgRa,
                                 Gia = hd.Gia.ToString("N0"),
                                 nv = getTenNV(hd.MaNv),
                             };
            dgvBaiXe.DataSource = queryBaiXe.ToList();
            dgvBaiXe.Columns["MaVe"].HeaderText = "Mã vé";
            dgvBaiXe.Columns["TenLoai"].HeaderText = "Loại vé";
            dgvBaiXe.Columns["TenXe"].HeaderText = "Loại xe";
            dgvBaiXe.Columns["BienSo"].HeaderText = "Biển số";
            dgvBaiXe.Columns["TgVao"].HeaderText = "Thời gian nhập";
            dgvBaiXe.Columns["TgRa"].HeaderText = "Thời gian xuất";
            dgvBaiXe.Columns["Gia"].HeaderText = "Mức phí";
            dgvBaiXe.Columns["nv"].HeaderText = "Nhân viên";

            dgvBaiXe.Columns["MaVe"].Width = (int)Math.Round(dgvBaiXe.Width * 0.1);
            dgvBaiXe.Columns["TenLoai"].Width = (int)Math.Round(dgvBaiXe.Width * 0.1);
            dgvBaiXe.Columns["TenXe"].Width = (int)Math.Round(dgvBaiXe.Width * 0.1);
            dgvBaiXe.Columns["BienSo"].Width = (int)Math.Round(dgvBaiXe.Width * 0.11);
            dgvBaiXe.Columns["TgVao"].Width = (int)Math.Round(dgvBaiXe.Width * 0.17);
            dgvBaiXe.Columns["TgRa"].Width = (int)Math.Round(dgvBaiXe.Width * 0.17);
            dgvBaiXe.Columns["Gia"].Width = (int)Math.Round(dgvBaiXe.Width * 0.1);
            dgvBaiXe.Columns["nv"].Width = (int)Math.Round(dgvBaiXe.Width * 0.097);

            dgvBaiXe.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBaiXe.Font, FontStyle.Bold);

            //dgvBaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadComboBox_LoaiVe();
            LoadComboBox_LoaiXe();
        }

        private void btnBTTTve_Click(object sender, EventArgs e)
        {
            
            if(hoadon != null)
            {
                Panel mainPanel = this.Parent as Panel;
                mainUI mainForm = mainPanel.Parent as mainUI;

                mainForm.showBlur();
                fBTTTve newForm = new fBTTTve(hoadon);
                newForm.ShowDialog();

                mainForm.closeBlur();
                ucBaiXeLoad();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 01 hoá đơn!","Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnBTbaiXe_Click(object sender, EventArgs e)
        {
            Panel mainPanel = this.Parent as Panel;
            mainUI mainForm = mainPanel.Parent as mainUI;

            mainForm.showBlur();
            fBTbaiXe newForm = new fBTbaiXe();
            newForm.ShowDialog();

            mainForm.closeBlur();
        }
        private string sinhMaVe()
        {
            return db.VeLuot
                     .Where(vl => vl.BienSo == "")
                     .Select(vl => vl.MaVe)
                     .FirstOrDefault();
        }

        public string getMaLoaiVe()
        {
            try
            {
                var a = (from mlv in db.LoaiVe
                         where mlv.TenLoai == cbbLoaiVe.Text.ToString()
                         select mlv.MaLoaiVe).SingleOrDefault();
                return a.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã loại vé!\n"+ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        public string getMaLoaiXe()
        {
            try
            {
                var a = (from mlx in db.LoaiXe
                         where mlx.TenXe == cbbLoaiXe.Text.ToString()
                         select mlx.MaLoaiXe).SingleOrDefault();
                return a.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã loại xe!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private static int getPhiQuaDem(string maloaixe)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                var mp = (from gqd in db.GiaQuaDem
                          where gqd.MaLoaiXe == maloaixe
                          select gqd.Gia).FirstOrDefault();
                return mp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu giá qua đêm!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return -1;
        }
        private static int getMucPhi(string maloaive, string maloaixe, DateTime ngayvao)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                if(maloaive == "VL" && DateTime.Compare(DateTime.Now.Date, ngayvao.Date)<0)
                {
                    return (ngayvao -  DateTime.Now).Days * getPhiQuaDem(maloaixe);
                }
                else
                {
                    var mp = (from bg in db.BangGia
                                where bg.MaLoaiVe == maloaive
                                && bg.MaLoaiXe == maloaixe
                                select bg.Gia).FirstOrDefault();

                    return mp;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu mức phí!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return -1;
        }
        private bool hieuLucVT()
        {
            try
            {
                var vethang = (from vt in db.VeThang
                               where vt.MaVe == txbMaVe.Text
                               select vt).FirstOrDefault();

                if(vethang.ThoiHan.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Vé tháng hết hiệu lực!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin thời hạn vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private bool NhapXe()
        {
            try
            {
                HoaDon newHD = new HoaDon();
                newHD.TgVao = DateTime.Now;
                newHD.TgRa = null;
                newHD.MaVe = txbMaVe.Text;
                newHD.MaLoaiVe = getMaLoaiVe();
                newHD.MaNv = currentNV.MaNv;
                newHD.MaLoaiXe = getMaLoaiXe();
                newHD.BienSo = txbBienSo.Text;
                newHD.Gia = getMucPhi(getMaLoaiVe(), getMaLoaiXe(), DateTime.Now.Date);

                db.HoaDon.Add(newHD);
                db.SaveChanges();
                if(newHD.MaLoaiVe == "VL")
                {
                    if (!update_NhapXe_VeLuot() || !update_NhapXe_BaiXe())
                    {
                        db.HoaDon.Remove(newHD);
                        db.SaveChanges();
                        MessageBox.Show("Nhập xe không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (!hieuLucVT() || !update_NhapXe_BaiXe())
                    {
                        db.HoaDon.Remove(newHD);
                        db.SaveChanges();
                        MessageBox.Show("Nhập xe không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hóa đơn!\n"+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
 
        }
        private bool isTrong(string loaixe)
        {
            try
            {
                var soluong = (from bx in db.BaiXe
                               join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                               where lx.TenXe == loaixe
                               select bx.SoLuong).FirstOrDefault();
                return soluong >= 1 ? true : false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi lấy số lượng xe trong bãi!", "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        public bool isCheck()
        {
            if(cbbLoaiVe.SelectedIndex == 1 && txbMaVe.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã vé tháng!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLoaiVe.Focus();
                return false;
            }
            if (cbbLoaiVe.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn loại vé!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLoaiVe.Focus();
                return false;
            }
            if (cbbLoaiXe.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn loại xe!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLoaiXe.Focus();
                return false;
            }
            if (txbBienSo.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập biển số!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
        private bool tonTaiXe(string bs)
        {
            try
            {
                var query = (from hd in db.HoaDon
                            where hd.TgRa == null
                            && hd.BienSo == bs
                            select hd).Count();
                if (query == 1)
                {
                    return true;
                }  
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kiểm tra tồn tại xe trong bãi!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        private bool tonTaiVe(string mave)
        {
            try
            {
                var query = (from hd in db.HoaDon
                             where hd.TgRa == null
                             && hd.MaVe == mave
                             select hd).Count();
                if (query == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kiểm tra tồn tại vé xe!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        private bool update_NhapXe_BaiXe()
        {
            try
            {
                var queryBaiXe = (from bx in db.BaiXe
                                  join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                                  where lx.MaLoaiXe == getMaLoaiXe()
                                  select bx).FirstOrDefault();
                queryBaiXe.SoLuong = queryBaiXe.SoLuong - 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật số lượng chỗ đậu xe!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }
        private bool update_NhapXe_VeLuot()
        {
            try
            {
                var queryUpdateVeLuot = (from ve in db.VeLuot
                                        join hd in db.HoaDon on ve.MaVe equals hd.MaVe
                                        where hd.TgRa == null && ve.MaVe == txbMaVe.Text
                                        select ve).FirstOrDefault();

                queryUpdateVeLuot.BienSo = txbBienSo.Text;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật biển số cho vé lượt!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false ;
        }
        private void reset()
        {
            txbBienSo.Text = string.Empty;
            txbMaVe.Text = string.Empty;
            cbbLoaiVe.Text = string.Empty;
            cbbLoaiXe.Text = string.Empty;
            lbThongTin.Text = string.Empty;
        }
        private void btnNhapXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (isCheck() == true)
            {
                if (!tonTaiXe(txbBienSo.Text))
                {
                    if (!tonTaiVe(txbMaVe.Text))
                    {
                        if (isTrong(cbbLoaiXe.Text))
                        {
                            if (NhapXe())
                            {
                                ucBaiXeLoad();
                                reset();
                                MessageBox.Show("Nhập xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Nhập xe không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Không còn chỗ trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vé xe đang được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                else
                {
                    MessageBox.Show("Xe đã tồn tại trong bãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
        }

        private bool tonTaiHoaDon()
        {
            try
            {
                var query = (from hd in db.HoaDon
                             where hd.TgRa == null
                             && hd.MaVe == hoadon.MaVe
                             && hd.BienSo == hoadon.BienSo
                             && hd.TgVao == hoadon.TgVao
                             select hd).Count();
                if (query == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kiểm tra tồn tại hoá đơn!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        private void btnXuatXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (isCheck() == true)
            {
                if (tonTaiHoaDon())
                {
                    XuatXe();

                    ucBaiXeLoad();
                    reset();
                    MessageBox.Show("Xuất xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Hoá đơn không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }

        }
        private void XuatXe()
        {
            try
            {
                if(hoadon.MaLoaiVe == "VT")
                {
                    if (update_XuatXe_BaiXe())
                    {
                        HoaDon newHD = hoadon;
                        newHD.TgRa = DateTime.Now;

                        db.SaveChanges();
                    }
                }
                else
                {
                    if (update_XuatXe_VeLuot() && update_XuatXe_BaiXe())
                    {
                        HoaDon newHD = hoadon;
                        newHD.TgRa = DateTime.Now;

                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xuất hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        private bool update_XuatXe_VeLuot()
        {
            try
            {
                var queryUpdateVeLuot = (from ve in db.VeLuot
                                         join hd in db.HoaDon on ve.MaVe equals hd.MaVe
                                         where hd.TgRa == null 
                                         && hd.TgVao == hoadon.TgVao
                                         && hd.MaVe == hoadon.MaVe
                                         select ve).FirstOrDefault();

                if(queryUpdateVeLuot != null) { 
                    queryUpdateVeLuot.BienSo = string.Empty;
                    
                    db.SaveChanges();
                    return true; 
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật biển số cho vé lượt!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }
        private bool update_XuatXe_BaiXe()
        {
            try
            {
                var queryBaiXe = (from bx in db.BaiXe
                                  join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                                  where lx.MaLoaiXe == getMaLoaiXe()
                                  select bx).FirstOrDefault();
                queryBaiXe.SoLuong = queryBaiXe.SoLuong + 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật số lượng chỗ đậu xe!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }

        private void dgvBaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvBaiXe.Rows[row];
                    var show = (from hd in db.HoaDon
                                join lx in db.LoaiXe on hd.MaLoaiXe equals lx.MaLoaiXe
                                join lv in db.LoaiVe on hd.MaLoaiVe equals lv.MaLoaiVe
                                where hd.MaVe == selectedRow.Cells["MaVe"].Value.ToString()
                                && hd.TgVao == (DateTime)selectedRow.Cells["TgVao"].Value
                                select new
                                {
                                    hd,
                                    lx.TenXe,
                                    lv.TenLoai,
                                    lv.MaLoaiVe,
                                    lx.MaLoaiXe,
                                }).FirstOrDefault();

                    txbBienSo.Text = show.hd.BienSo;
                    cbbLoaiVe.Text = show.TenLoai;
                    cbbLoaiXe.Text = show.TenXe;
                    txbMaVe.Text = show.hd.MaVe;

                    hoadon = show.hd;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy thông tin hoá đơn!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showMucPhiThoiHan()
        {
            if(cbbLoaiVe.Text != string.Empty && cbbLoaiXe.Text != string.Empty)
            {
                if (getMaLoaiVe() == "VT")
                {
                    try
                    {
                        var vethang = (from vt in db.VeThang
                                       where vt.MaVe == txbMaVe.Text
                                       select vt).FirstOrDefault();
                        if (vethang != null)
                            lbThongTin.Text = "Mức phí: " + getMucPhi("VT", getMaLoaiXe(), DateTime.Now).ToString("N0") + "đ/tháng\nThời hạn: " + vethang.ThoiHan.Date.ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi lấy thông tin vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (getMaLoaiVe() == "VL")
                {
                    lbThongTin.Text = "Mức phí: " + getMucPhi("VL", getMaLoaiXe(), DateTime.Now).ToString("N0") + "đ/lượt\nGửi đêm: "+getPhiQuaDem(getMaLoaiXe()).ToString("N0") + "/đêm";
                }
            }
        }
        private void cbbLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiVe.SelectedIndex == 0)
            {

                txbMaVe.Text = sinhMaVe();
                txbMaVe.ReadOnly = true;
                txbMaVe.BackColor = Color.Lavender;

            }
            else if (cbbLoaiVe.SelectedIndex == 1)
            {
                txbMaVe.ReadOnly = false;
                txbMaVe.Text = null;
                txbMaVe.BackColor = SystemColors.Window;
            }

            showMucPhiThoiHan();
        }
        private void findBienSo()
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryBaiXe = from hd in db.HoaDon
                                 join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                 join maLV in db.LoaiVe on hd.MaLoaiVe equals maLV.MaLoaiVe
                                 orderby hd.TgRa ascending
                                 orderby hd.TgVao descending
                                 where hd.BienSo.Contains(txbTimKiem.Text)
                                 select new
                                 {
                                     hd.MaVe,
                                     maLV.TenLoai,
                                     maLX.TenXe,
                                     hd.BienSo,
                                     hd.TgVao,
                                     hd.TgRa,
                                     hd.Gia,
                                     nv = getTenNV(hd.MaNv),
                                 };
                dgvBaiXe.DataSource = queryBaiXe.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin vé xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void findMaVe()
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryBaiXe = from hd in db.HoaDon
                                 join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                 join maLV in db.LoaiVe on hd.MaLoaiVe equals maLV.MaLoaiVe
                                 orderby hd.TgRa, hd.TgVao ascending    
                                 where hd.MaVe.Contains(txbTimKiem.Text)
                                 select new
                                 {
                                     hd.MaVe,
                                     maLV.TenLoai,
                                     maLX.TenXe,
                                     hd.BienSo,
                                     hd.TgVao,
                                     hd.TgRa,
                                     hd.Gia,
                                     nv = getTenNV(hd.MaNv),
                                 };
                dgvBaiXe.DataSource = queryBaiXe.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin vé xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTimBienSo_Click(object sender, EventArgs e)
        {
            findBienSo();
        }

        private void btnTimMaVe_Click(object sender, EventArgs e)
        {
            findMaVe();
        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txbTimKiem.Text.IsNullOrEmpty())
            {
                ucBaiXeLoad();
            }
        }

        private void txbMaVe_TextChanged(object sender, EventArgs e)
        {
            if(cbbLoaiVe.Text == getTenVe("VT"))
            {
                try
                {
                    var vethang = (from vt in db.VeThang
                                   join kh in db.KhachHang on vt.MaKh equals kh.MaKh
                                   join xe in db.Xe on kh.MaKh equals xe.MaKh
                                   join lx in db.LoaiXe on xe.MaLoaiXe equals lx.MaLoaiXe 
                                   where vt.MaVe == txbMaVe.Text
                                   select new
                                   {
                                       vt,
                                       lx.TenXe,
                                       xe.BienSo,
                                       mp = getMucPhi("VT", lx.MaLoaiXe, DateTime.Now),
                                       vt.ThoiHan,
                                   }).FirstOrDefault();
                    if (vethang != null)
                    {
                        cbbLoaiXe.Text = vethang.TenXe;
                        txbBienSo.Text = vethang.BienSo;
                        //lbThongTin.Text = "Mức phí: " + getMucPhi("VT", getMaLoaiXe()).ToString("N0") + "đ/tháng\nThời hạn: " + vethang.ThoiHan.Date.ToString("dd/MM/yyyy");
                        lbThongTin.Text = "Mức phí: " + vethang.mp.ToString("N0") + "đ/tháng\nThời hạn: " + vethang.ThoiHan.Date.ToString("dd/MM/yyyy");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy thông tin vé tháng!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            showMucPhiThoiHan();
        }
        private void updateHD_QuaNgay()
        {
            try
            {
                var HD = (from hd in db.HoaDon
                          where hd.TgRa == null
                          && hd.MaLoaiVe == "VL"
                          select hd).ToList();

                foreach(HoaDon i in HD)
                {
                    var updateHD = db.HoaDon.Find(i.MaHd);
                    updateHD.Gia = getMucPhi(updateHD.MaLoaiVe, updateHD.MaLoaiXe, updateHD.TgVao);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi update giá vé qua đêm!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lbNgay_TextChanged(object sender, EventArgs e)
        {
            updateHD_QuaNgay();
        }
    }
}
