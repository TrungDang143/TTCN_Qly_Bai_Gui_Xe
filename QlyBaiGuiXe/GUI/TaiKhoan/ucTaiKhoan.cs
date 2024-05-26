using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using QlyBaiGuiXe.GUI.TaiKhoan;
using QlyBaiGuiXe.MoHinhDuLieu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI
{
    public partial class ucTaiKhoan : UserControl
    {
        private string choseNV = string.Empty;
        public ucTaiKhoan()
        {
            InitializeComponent();

            loadData();

        }
        private void loadData()
        {
            dgvNhanVien.AutoGenerateColumns = true;
            BaiXeDBContext db = new BaiXeDBContext();
            var queryNV = from nv in db.NhanVien
                          join cv in db.ChucVu on nv.MaCv equals cv.MaCv
                          select new
                          {
                              nv.MaNv,
                              nv.HoTen,
                              cv.TenCv,
                              nv.Sdt,
                              nv.NgaySinh,
                              GioiTinh = nv.GioiTinh == true ? "Nam" : "Nữ",
                          };

            dgvNhanVien.DataSource = queryNV.ToList();
            dgvNhanVien.Columns[0].Width = (int)Math.Round(dgvNhanVien.Width * 0.1);
            dgvNhanVien.Columns[1].Width = (int)Math.Round(dgvNhanVien.Width * 0.3);
            dgvNhanVien.Columns[2].Width = (int)Math.Round(dgvNhanVien.Width * 0.145);
            dgvNhanVien.Columns[3].Width = (int)Math.Round(dgvNhanVien.Width * 0.15);
            dgvNhanVien.Columns[4].Width = (int)Math.Round(dgvNhanVien.Width * 0.145);
            dgvNhanVien.Columns[5].Width = (int)Math.Round(dgvNhanVien.Width * 0.107);

            dgvNhanVien.Columns[0].HeaderText = "Mã nv";
            dgvNhanVien.Columns[1].HeaderText = "Họ tên";
            dgvNhanVien.Columns[2].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[3].HeaderText = "SĐT";
            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[5].HeaderText = "Giới tính";
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            mainUI newF = pnl.Parent as mainUI;

            newF.showBlur();
            fDoiMatKhau newform = new fDoiMatKhau();
            newform.ShowDialog();
            newF.closeBlur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            mainUI newF = pnl.Parent as mainUI;

            newF.showBlur();
            fQlyNhanVien newform = new fQlyNhanVien(choseNV);
            newform.ShowDialog();
            newF.closeBlur();
            loadData();
        }

        private void ucTaiKhoan_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if(row > -1)
            {
                DataGridViewRow dataRow = dgvNhanVien.Rows[row];
                choseNV = dataRow.Cells[0].Value.ToString();
            }
            
            //txbMaNhanVien.Text = dataRow.Cells[0].Value.ToString();
            //txbHoTen.Text = dataRow.Cells[1].Value.ToString();
            //txbChucVu.Text = dataRow.Cells[2].Value.ToString();
            //txbSDT.Text = dataRow.Cells[3].Value.ToString();
            //dtpkNgaySinh.Text = dataRow.Cells[4].Value.ToString();
            //cbbGioiTinh.Text = dataRow.Cells[5].Value.ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Panel panel = this.Parent as Panel;
            mainUI mainF = panel.Parent as mainUI;

            Task.Delay(500).Wait();
            mainF.isClose = false;
            mainF.Close();
        }
    }
}
