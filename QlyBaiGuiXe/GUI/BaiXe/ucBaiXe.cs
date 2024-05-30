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
            ucBaiXeLoad();
            currentNV = nv;
            LoadComboBox_LoaiVe();
            LoadComboBox_LoaiXe();
            cbbLoaiVe.SelectedIndex = 0;
            cbbLoaiXe.SelectedIndex = 0;
        }
        private void LoadComboBox_LoaiVe()
        {
            var loaive = (from lv in db.LoaiVe
                          select lv.TenLoai).ToList();
            foreach (var loaix in loaive)
            {
                cbbLoaiVe.Items.Add(loaix);
            }
        }
        private void LoadComboBox_LoaiXe()
        {
            var loaixe = (from lx in db.LoaiXe
                          select lx.TenXe).ToList();
            foreach(var loaix in loaixe)
            {
                cbbLoaiXe.Items.Add(loaix);
            }
        }
        //private void LoadMaVe()
        //{
        //    if (cbbLoaiVe.SelectedIndex == 0)
        //    {
        //        string ve = sinhMaVe();
        //        txbMaVe.Text = ve;
        //    }
        //    else
        //    {
        //        txbMaVe.Text = null;
        //    }
        //}
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
                    return "Không có dữ liệu";
                }
                return ten;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã loại vé!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private void ucBaiXeLoad()
        {
            txbMaVe.Text = sinhMaVe();
            // load data grid view
            dgvBaiXe.AutoGenerateColumns = true;
            var queryBaiXe = from hd in db.HoaDon
                             join LV in db.LoaiVe on hd.MaLoaiVe equals LV.MaLoaiVe
                             join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                             join VL in db.VeLuot on hd.MaVe equals VL.MaVe
                             select new
                             {
                                 hd.MaVe,
                                 maLX.TenXe,
                                 VL.BienSo,
                                 hd.TgVao,
                                 hd.TgRa,
                                 nv = getTenNV(hd.MaNv),
                             };
            dgvBaiXe.DataSource = queryBaiXe.ToList();
            dgvBaiXe.Columns["MaVe"].HeaderText = "Mã vé".ToUpper();
            dgvBaiXe.Columns["TenXe"].HeaderText = "Loại xe".ToUpper();
            dgvBaiXe.Columns["BienSo"].HeaderText = "Biển số".ToUpper();
            dgvBaiXe.Columns["TgVao"].HeaderText = "Thời gian nhập".ToUpper();
            dgvBaiXe.Columns["TgRa"].HeaderText = "Thời gian xuất".ToUpper();
            dgvBaiXe.Columns["nv"].HeaderText = "Nhân viên".ToUpper();

            dgvBaiXe.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBaiXe.Font, FontStyle.Bold);

            dgvBaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                         where mlv.TenLoai == cbbLoaiVe.SelectedItem.ToString()
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
                         where mlx.TenXe == cbbLoaiXe.SelectedItem.ToString()
                         select mlx.MaLoaiXe).SingleOrDefault();
                return a.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã loại xe!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private void query_ThemXe()
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
                db.HoaDon.Add(newHD);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi thêm hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
 
        }
        private bool Check_NhapXe()
        {
            try
            {

                var soluong = (from bx in db.BaiXe
                               join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                               where lx.TenXe == cbbLoaiXe.Text
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
        //ktra xem co hoa don chua hoan thanh ko
        private bool checkRear()
        {
            try
            {
                var queryUpdateVeLuot = (from bienSo in db.VeLuot
                                         join hd in db.HoaDon on bienSo.MaVe equals hd.MaVe
                                         where hd.TgRa == null
                                         select bienSo.BienSo).ToList();
                foreach (var a in queryUpdateVeLuot)
                {
                    if (a.ToString() == txbBienSo.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi không lấy được danh sách các biển số!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        private void update_ThemBaiXe()
        {
            if (Check_NhapXe())
            {
                var queryBaiXe = from bx in db.BaiXe
                                 join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                                 where lx.TenXe == cbbLoaiXe.SelectedItem.ToString()
                                 select bx;
                if (queryBaiXe.Count() > 0)
                {
                    Entities.BaiXe baiXe = queryBaiXe.SingleOrDefault();
                    baiXe.SoLuong = baiXe.SoLuong - 1;
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Sỗ lượng chỗ đã full! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void update_NhapVeLuot()
        {
            try
            {
                var queryUpdateVeLuot = from bienSo in db.VeLuot
                                        join hd in db.HoaDon on bienSo.MaVe equals hd.MaVe
                                        where bienSo.MaVe == txbMaVe.Text && hd.TgRa == null
                                        select bienSo;
                if (queryUpdateVeLuot.Count() > 0)
                {
                    VeLuot veLuot = queryUpdateVeLuot.SingleOrDefault();
                   // HoaDon hd = queryUpdateHoaDon.SingleOrDefault();
                    veLuot.BienSo = txbBienSo.Text;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi cập nhật biển số cho loại vé!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }
        private void reset()
        {
            txbBienSo.Text = null;
            cbbLoaiVe.SelectedIndex = 0;
            cbbLoaiXe.SelectedIndex = 0;
        }
        private void btnNhapXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (isCheck() == true)
            {
                if (checkRear())
                {
                    query_ThemXe();
                    update_NhapVeLuot();

                    update_ThemBaiXe();
                    ucBaiXeLoad();
                    reset();
                    MessageBox.Show("Nhập xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Biển số xe này đã tồn tại!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
        }

        private void update_XuatVeLuot()
        {
            var queryUpdateVeLuot = from bienSo in db.VeLuot
                                    join hd in db.HoaDon on bienSo.MaVe equals hd.MaVe
                                    where bienSo.MaVe == txbMaVe.Text && hd.TgRa != null
                                    select bienSo;
            if (queryUpdateVeLuot.Count() > 0)
            {
                VeLuot veLuot = queryUpdateVeLuot.SingleOrDefault();
                veLuot.BienSo = "";
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Không tìm thấy xe!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnXuatXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (daChon == true)
            {
                if(Check_XuatXe() == true)
                {
                    var queryHoaDon = (from hd in db.HoaDon
                                       where hd.MaVe == txbMaVe.Text
                                       select hd).FirstOrDefault();
                    HoaDon updateHoaDon = queryHoaDon;
                    updateHoaDon.TgRa = DateTime.Now;
                    db.SaveChanges();
                    update_XuatVeLuot();
                    update_XuatBaiXe();
                    ucBaiXeLoad();
                    MessageBox.Show("Xuất xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void update_XuatBaiXe()
        {
            try
            {
                var queryBaiXe = from bx in db.BaiXe
                                 join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                                 where lx.TenXe == cbbLoaiXe.SelectedItem.ToString()
                                 select bx;
                if (queryBaiXe.Count() > 0)
                {
                    Entities.BaiXe baiXe = queryBaiXe.SingleOrDefault();
                    baiXe.SoLuong = baiXe.SoLuong + 1;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật xe ra khỏi bãi không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }

        
        private bool Check_XuatXe()
        {
            var tgRa = (from hd in db.HoaDon
                       where hd.MaVe == txbMaVe.Text
                       select hd.TgRa).FirstOrDefault();
            if(tgRa == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool daChon = false;


        private void dgvBaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                DataGridViewRow selectedRow = dgvBaiXe.Rows[row];
                var b = (from mlv in db.VeLuot
                         join lv in db.LoaiVe on mlv.MaLoaiVe equals lv.MaLoaiVe
                         where mlv.BienSo == selectedRow.Cells[2].Value.ToString()
                         select lv.TenLoai).FirstOrDefault();
                txbBienSo.Text = selectedRow.Cells[2].Value.ToString();
                cbbLoaiVe.Text = b.ToString();
                cbbLoaiXe.SelectedItem = selectedRow.Cells[1].Value.ToString();
                txbMaVe.Text = selectedRow.Cells[0].Value.ToString();

                hoadon = (from hd in db.HoaDon
                              where hd.MaVe == txbMaVe.Text
                              && hd.TgVao== (DateTime)selectedRow.Cells[3].Value
                              select hd).FirstOrDefault();
                daChon = true;
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
        }
        private void findBienSo()
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryBaiXe = from hd in db.HoaDon
                                 join LV in db.LoaiVe on hd.MaLoaiVe equals LV.MaLoaiVe
                                 join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                 join VL in db.VeLuot on hd.MaVe equals VL.MaVe
                                 where VL.BienSo.Contains(txbTimKiem.Text)
                                 select new
                                 {
                                     hd.MaVe,
                                     maLX.TenXe,
                                     VL.BienSo,
                                     hd.TgVao,
                                     hd.TgRa,
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
                                 join LV in db.LoaiVe on hd.MaLoaiVe equals LV.MaLoaiVe
                                 join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                 join VL in db.VeLuot on hd.MaVe equals VL.MaVe
                                 where hd.MaVe.Contains(txbTimKiem.Text)
                                 select new
                                 {
                                     hd.MaVe,
                                     maLX.TenXe,
                                     VL.BienSo,
                                     hd.TgVao,
                                     hd.TgRa,
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
    }
}
