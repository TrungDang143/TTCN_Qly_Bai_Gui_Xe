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

namespace QlyBaiGuiXe.GUI
{
    public partial class ucThongKe : UserControl
    {
        private DateTime bt;
        private DateTime kt;
        private string locLoai = string.Empty;
        public ucThongKe()
        {
            InitializeComponent();
            bt = dtpk.Value.Date;
            kt = dtpk.Value.Date;
            locLoai = "all";
        }

        private void resetFilterNgay()
        {
            this.btnHN.BackColor = System.Drawing.Color.Lavender;
            this.btnThang.BackColor = System.Drawing.Color.Lavender;
            this.btnNam.BackColor = System.Drawing.Color.Lavender;
            this.btnTuan.BackColor = System.Drawing.Color.Lavender;

        }
        private void resetFilterLoai()
        {
            this.btnAll.BackColor = System.Drawing.Color.Lavender;
            this.btnVeLuot.BackColor = System.Drawing.Color.Lavender;
            this.btnVeThang.BackColor = System.Drawing.Color.Lavender;

        }

        private void thongKeVe(DateTime bt, DateTime kt)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var sl = (from vt in db.VeThang
                          where vt.ThoiHan.Month == dtpk.Value.Month + 1
                          select vt).Count();
                lbVeThang.Text = "Số lượng vé tháng đăng ký trong tháng " + dtpk.Value.ToString("MM/yyyy") + ": " + sl;

                var doanhthuVT = (from vt in db.VeThang
                                  join bg in db.BangGia on vt.MaLoaiVe equals bg.MaLoaiVe
                                  join kh in db.KhachHang on vt.MaKh equals kh.MaKh
                                  join xe in db.Xe on kh.MaKh equals xe.MaKh
                                  where vt.ThoiHan.Month == dtpk.Value.Month + 1
                                  && xe.BienSo == vt.BienSo
                                  && xe.MaLoaiXe == bg.MaLoaiXe
                                  select bg.Gia).Sum();

                var doanhthu = (from hd in db.HoaDon
                                where hd.TgRa != null
                                && hd.TgRa >= bt.Date
                                && hd.TgRa <= kt.AddDays(1).Date
                                select hd.Gia).Sum();
                int tongDT = doanhthuVT + doanhthu;
                
                if (bt.Date == kt.Date)
                {
                    lbDoanhThu.Text = "Doanh thu ngày " + bt.ToString("dd/MM/yyyy") + ": " + doanhthu.ToString("N0");
                }
                else {
                    lbDoanhThu.Text = "Doanh thu từ " + bt.ToString("dd/MM/yyyy") + " đến " + kt.ToString("dd/MM/yyyy") + ": " + tongDT.ToString("N0");
                }

                var luotveluot = (from hd in db.HoaDon
                                  where hd.MaLoaiVe == "VL"
                                  && hd.TgVao >= bt.Date
                                  && hd.TgVao <= kt.AddDays(1).Date
                                  select hd).Count();
                lbVL.Text = "Vé lượt: " + luotveluot.ToString("N0") + " lượt";

                var luotvethang = (from hd in db.HoaDon
                                   where hd.MaLoaiVe == "VT"
                                   && hd.TgVao >= bt.Date
                                   && hd.TgVao <= kt.AddDays(1).Date
                                   select hd).Count();
                lbVT.Text = "Vé tháng: " + luotvethang.ToString("N0") + " lượt";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin thống kê!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (ten == null)
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
        private void loadData()
        {
            try
            {
                thongKeVe(bt, kt);
                dgvTK.AutoGenerateColumns = true;
                BaiXeDBContext db = new BaiXeDBContext();

                if (locLoai == "all")
                {
                    var queryBaiXe = from hd in db.HoaDon
                                     join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                     join maLV in db.LoaiVe on hd.MaLoaiVe equals maLV.MaLoaiVe
                                     where (hd.TgVao.Date >= bt.Date && hd.TgVao.Date <= kt.Date)
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
                    dgvTK.DataSource = queryBaiXe.ToList();
                }
                else
                {
                    var queryBaiXe = from hd in db.HoaDon
                                     join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                                     join maLV in db.LoaiVe on hd.MaLoaiVe equals maLV.MaLoaiVe
                                     where (hd.TgVao.Date >= bt.Date && hd.TgVao.Date <= kt.Date)
                                     && hd.MaLoaiVe == locLoai
                                     orderby hd.TgRa ascending
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
                    dgvTK.DataSource = queryBaiXe.ToList();
                }
                dgvTK.Columns["MaVe"].HeaderText = "Mã vé";
                dgvTK.Columns["TenLoai"].HeaderText = "Loại vé";
                dgvTK.Columns["TenXe"].HeaderText = "Loại xe";
                dgvTK.Columns["BienSo"].HeaderText = "Biển số";
                dgvTK.Columns["TgVao"].HeaderText = "Thời gian nhập";
                dgvTK.Columns["TgRa"].HeaderText = "Thời gian xuất";
                dgvTK.Columns["Gia"].HeaderText = "Mức phí";
                dgvTK.Columns["nv"].HeaderText = "Nhân viên";

                dgvTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTK.ColumnHeadersDefaultCellStyle.Font = new Font(dgvTK.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu thống kê!\n" + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ucThongKe_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnHN.BackColor = System.Drawing.Color.LightSteelBlue;
            dtpk.Value = DateTime.Now;
            bt = dtpk.Value;
            kt = dtpk.Value;
            loadData();
            //xuly
        }

        private void btnTuan_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnTuan.BackColor = System.Drawing.Color.LightSteelBlue;
            bt = GetStartOfWeek(dtpk.Value);
            kt = GetEndOfWeek(bt);

            loadData();

            //xuly
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnThang.BackColor = System.Drawing.Color.LightSteelBlue;
            bt = new DateTime(dtpk.Value.Year, dtpk.Value.Month, 1);
            kt = new DateTime(dtpk.Value.Year, dtpk.Value.Month, DateTime.DaysInMonth(dtpk.Value.Year, dtpk.Value.Month));
            loadData();
            //xuly
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnNam.BackColor = System.Drawing.Color.LightSteelBlue;
            bt = new DateTime(dtpk.Value.Year, 1, 1);
            kt = new DateTime(dtpk.Value.Year, 12, 31);
            loadData();
            //xuly
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            resetFilterLoai();
            this.btnAll.BackColor = System.Drawing.Color.LightSteelBlue;
            locLoai = "all";

            loadData();
            //xuly
        }

        private void btnVeLuot_Click(object sender, EventArgs e)
        {
            resetFilterLoai();
            this.btnVeLuot.BackColor = System.Drawing.Color.LightSteelBlue;
            locLoai = "VL";

            loadData();
            //xuly
        }

        private void btnVeThang_Click(object sender, EventArgs e)
        {
            resetFilterLoai();
            this.btnVeThang.BackColor = System.Drawing.Color.LightSteelBlue;
            locLoai = "VT";

            loadData();
            //xuly
        }

        private void dtpk_ValueChanged(object sender, EventArgs e)
        {
            bt = dtpk.Value;
            kt = dtpk.Value;
            resetFilterNgay();
            loadData();

            
        }
        private DateTime GetStartOfWeek(DateTime date)
        {
            // Ngày đầu tuần (Thứ Hai)
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private DateTime GetEndOfWeek(DateTime startOfWeek)
        {
            // Ngày cuối tuần (Chủ Nhật)
            return startOfWeek.AddDays(6);
        }
    }
}
