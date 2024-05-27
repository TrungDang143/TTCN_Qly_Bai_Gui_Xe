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
        NhanVien NV;
        public ucBaiXe(NhanVien nv)
        {
            InitializeComponent();
            ucBaiXeLoad();
            NV = nv;
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

        private void ucBaiXeLoad()
        {
            // load combo box
            LoadComboBox_LoaiVe();
            LoadComboBox_LoaiXe();
            cbbLoaiVe.SelectedIndex = 0;
            cbbLoaiXe.SelectedIndex = 0;
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
                             };
            dgvBaiXe.DataSource = queryBaiXe.ToList();
            dgvBaiXe.Columns["MaVe"].HeaderText = "Mã vé".ToUpper();
            dgvBaiXe.Columns["TenXe"].HeaderText = "Loại xe".ToUpper();
            dgvBaiXe.Columns["BienSo"].HeaderText = "Biển số".ToUpper();
            dgvBaiXe.Columns["TgVao"].HeaderText = "Thời gian nhập".ToUpper();
            dgvBaiXe.Columns["TgRa"].HeaderText = "Thời gian xuất".ToUpper();

            dgvBaiXe.ColumnHeadersDefaultCellStyle.Font = new Font(dgvBaiXe.Font, FontStyle.Bold);

            dgvBaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBTTTve_Click(object sender, EventArgs e)
        {
            //neu chon trong dgv

            //neu ko chon
            Panel mainPanel = this.Parent as Panel;
            mainUI mainForm = mainPanel.Parent as mainUI;

            mainForm.showBlur();
            fBTTTve newForm = new fBTTTve();
            newForm.ShowDialog();

            mainForm.closeBlur();
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
        private void query_ThemXe(string ve)
        {
            HoaDon newHD = new HoaDon();
            newHD.TgVao = DateTime.Now;
            newHD.TgRa = null;
            newHD.MaVe = ve;
            newHD.MaLoaiVe = cbbLoaiVe.SelectedItem.ToString();
            newHD.MaNv = NV.MaNv;
            var a = (from mlx in db.LoaiXe
                    where mlx.TenXe == cbbLoaiXe.SelectedItem.ToString()
                    select mlx.MaLoaiXe).SingleOrDefault();

            newHD.MaLoaiXe = a;
            db.HoaDon.Add(newHD);
            db.SaveChanges();
            MessageBox.Show("Nhập xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool Check_NhapXe()
        {

            var soluong = (from bx in db.BaiXe
                           join lx in db.LoaiXe on bx.MaBaiXe equals lx.MaBaiXe
                           where lx.TenXe == cbbLoaiXe.SelectedItem.ToString()
                           select bx.SoLuong).FirstOrDefault();
            return true ? soluong > 0 : false;
        }
        public bool isCheck()
        {
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
        private void update_NhapVeLuot(string ve)
        {
            var queryUpdateVeLuot = from sua in db.VeLuot
                                    where sua.MaVe == ve
                                    select sua;
            if(queryUpdateVeLuot.Count() > 0)
            {
                VeLuot veLuot = queryUpdateVeLuot.SingleOrDefault();
                veLuot.BienSo = txbBienSo.Text;
                db.SaveChanges();
            }
        }
        private void reset()
        {
        }
        private void btnNhapXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (isCheck() == true)
            {
                string ve = sinhMaVe();
                query_ThemXe(ve);
                update_NhapVeLuot(ve);
                update_ThemBaiXe();
                ucBaiXeLoad();
            }
        }

        private void update_XuatVeLuot()
        {
            var queryUpdateVeLuot = from sua in db.VeLuot
                                    where sua.MaVe == txbMaVe.Text
                                    select sua;
            if (queryUpdateVeLuot.Count() > 0)
            {
                VeLuot veLuot = queryUpdateVeLuot.SingleOrDefault();
                veLuot.BienSo = "";
                db.SaveChanges();
            }
        }
        private void btnXuatXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (daChon == true)
            {
                if(Check_XuatXe() == true)
                {
                    update_XuatVeLuot();
                    var queryHoaDon = (from hd in db.HoaDon
                                       where hd.MaVe == txbMaVe.Text
                                       select hd).FirstOrDefault();
                    HoaDon updateHoaDon = queryHoaDon;
                    updateHoaDon.TgRa = DateTime.Now;
                    db.SaveChanges();
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
        private void update_XoaBaiXe()
        {
            if (Check_XuatXe())
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
            else
            {
                MessageBox.Show("Sỗ lượng chỗ đã full! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                         where mlv.BienSo == selectedRow.Cells[2].Value.ToString()
                         select mlv.MaLoaiVe).FirstOrDefault();
                txbBienSo.Text = selectedRow.Cells[2].Value.ToString();
                cbbLoaiVe.Text = b.ToString();
                cbbLoaiXe.SelectedItem = selectedRow.Cells[1].Value.ToString();
                txbMaVe.Text = selectedRow.Cells[0].Value.ToString();
                daChon = true;
            }
        }

    }
}
