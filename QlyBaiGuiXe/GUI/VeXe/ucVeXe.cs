using Microsoft.IdentityModel.Tokens;
using QlyBaiGuiXe.Entities;
using QlyBaiGuiXe.GUI.VeXe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QlyBaiGuiXe.GUI
{
    public partial class ucVeXe : UserControl
    {
        public ucVeXe(NhanVien nv)
        {
            InitializeComponent();
            if (nv.MaCv == "ql")
                groupBox3.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void showBangGia()
        {
            try
            {
                dgvBangGia.AutoGenerateColumns = true;
                BaiXeDBContext db = new BaiXeDBContext();

                DataTable dt = new DataTable();
                dt.Columns.Add("Loại vé", typeof(string));
                var queryXe = (from lx in db.LoaiXe
                               select lx).ToList();
                foreach (var lx in queryXe)
                {
                    dt.Columns.Add(lx.TenXe, typeof(string));
                }

                var queryVe = (from lv in db.LoaiVe
                               select lv).ToList();
                foreach (var lv in queryVe)
                {
                    //var queryGia = (from g in db.BangGia
                    //                where g.MaLoaiVe.Equals(lv.MaLoaiVe)
                    //                select g.Gia.ToString()).ToList();
                    //dt.Rows.Add(lv.TenLoai, queryGia);
                    DataRow row = dt.NewRow();
                    row["Loại vé"] = lv.TenLoai;

                    foreach (var lx in queryXe)
                    {
                        var gia = (from g in db.BangGia
                                   where g.MaLoaiVe == lv.MaLoaiVe && g.MaLoaiXe == lx.MaLoaiXe
                                   select g.Gia).FirstOrDefault();

                        row[lx.TenXe] = gia != 0 ? gia.ToString("N0") : "N/A";
                    }
                    dt.Rows.Add(row);
                }


                DataRow rowQD = dt.NewRow();
                rowQD["Loại vé"] = "Qua đêm";
                foreach (var lx in queryXe)
                {
                    var queryQuaDem = (from qd in db.GiaQuaDem
                                       where qd.MaLoaiXe == lx.MaLoaiXe
                                       select qd.Gia).FirstOrDefault();
                    rowQD[lx.TenXe] = queryQuaDem != 0 ? queryQuaDem.ToString("N0") : "N/A";
                }
                dt.Rows.Add(rowQD);


                dgvBangGia.DataSource = dt;
                dgvBangGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBangGia.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu bảng giá!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ucVeXe_Load(object sender, EventArgs e)
        {
            dtpk.Text = DateTime.Now.AddMonths(1).ToString();
            dtpk.Format = DateTimePickerFormat.Custom;
            dtpk.CustomFormat = "dd/MM/yyyy";

            showBangGia();

            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");

            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var loaixe = (from lx in db.LoaiXe
                              select lx.TenXe).ToList();

                foreach( var loaix in loaixe)
                {
                    cbbLoaiXe.Items.Add(loaix);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu loại xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txbMaVe.Text = string.Empty;
            txbBienSo.Text = string.Empty;
            txbChuXe.Text = string.Empty;
            txbDiaChi.Text = string.Empty;
            txbSDT.Text = string.Empty;
            txbMucPhi.Text = string.Empty;
            cbbLoaiXe.Text = string.Empty;
            cbbGioiTinh.Text = string.Empty;
        }

        private bool checkHopLe()
        {
            if (txbBienSo.Text.IsNullOrEmpty() ||
                txbChuXe.Text.IsNullOrEmpty() ||
                txbDiaChi.Text.IsNullOrEmpty() ||
                txbMaVe.Text.IsNullOrEmpty() ||
                txbMucPhi.Text.IsNullOrEmpty() ||
                txbSDT.Text.IsNullOrEmpty() ||
                cbbGioiTinh.Text.IsNullOrEmpty()||
                cbbLoaiXe.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (checkHopLe())
            {
                DialogResult kq = MessageBox.Show("Bạn muốn đăng ký vé tháng mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    // xu ly sql
                    try
                    {
                        BaiXeDBContext db = new BaiXeDBContext();
                        KhachHang newKH = new KhachHang();
                        newKH.DiaChi = txbDiaChi.Text;
                        newKH.HoTen = txbChuXe.Text;
                        newKH.Sdt = txbSDT.Text;
                        newKH.GioiTinh = cbbGioiTinh.Text == "Nam" ? true : false;

                        db.KhachHang.Add(newKH);
                        db.SaveChanges();
                        try
                        {
                            Xe newXe = new Xe();
                            newXe.BienSo = txbBienSo.Text;
                            newXe.MaKh = newKH.MaKh;
                            newXe.MaLoaiXe = getMaXe(cbbLoaiXe.Text);

                            db.Xe.Add(newXe);
                            db.SaveChanges();

                            try
                            {
                                VeThang vt = new VeThang();
                                vt.MaVe = txbMaVe.Text;
                                vt.MaKh = newKH.MaKh;
                                vt.BienSo = newXe.BienSo;
                                vt.ThoiHan = dtpk.Value.Date;
                                vt.MaLoaiVe = "VT";

                                db.VeThang.Add(vt);
                                db.SaveChanges();

                                MessageBox.Show("Tạo thành công vé tháng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnXoa.PerformClick();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi tạo vé tháng mới!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi tạo xe mới!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tạo khách hàng mới!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
        }

        private void btnBTveThang_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            mainUI mainForm = pnl.Parent as mainUI;

            mainForm.showBlur();
            fBTTTveThang newF = new fBTTTveThang();
            newF.ShowDialog();
            mainForm.closeBlur();
        }

        private void btnBTbangGia_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            mainUI mainForm = pnl.Parent as mainUI;

            mainForm.showBlur();
            fBTbangGia newF = new fBTbangGia();
            newF.ShowDialog();
            mainForm.closeBlur();
            showBangGia();
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

        private void cbbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaiXeDBContext db = new BaiXeDBContext();
            txbMucPhi.Text = (from bg in db.BangGia
                              where bg.MaLoaiVe == "VT" && bg.MaLoaiXe == getMaXe(cbbLoaiXe.Text)
                              select bg.Gia).FirstOrDefault().ToString();
        }
    }
}
