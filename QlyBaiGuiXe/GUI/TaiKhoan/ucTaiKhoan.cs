using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QlyBaiGuiXe.GUI.TaiKhoan;
using QlyBaiGuiXe.Entities;
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
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace QlyBaiGuiXe.GUI
{
    public partial class ucTaiKhoan : UserControl
    {
        private string choseNV = string.Empty;
        private NhanVien currentNV = null;
        public ucTaiKhoan(NhanVien currentNV)
        {
            InitializeComponent();

            this.currentNV = currentNV;
            if (currentNV.MaCv == "ql")
                groupBox2.Visible = true;
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
                              ngaysinh = nv.NgaySinh.Date.ToString("dd/MM/yyyy"),
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

            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");

            dtpkNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpkNgaySinh.CustomFormat = "dd/MM/yyyy";

            try
            {
                txbChucVu.Text = (from cv in db.ChucVu
                                  where currentNV.MaCv == cv.MaCv
                                  select cv.TenCv).FirstOrDefault();
                txbEmail.Text = currentNV.Email;
                txbHoTen.Text = currentNV.HoTen;
                txbMaNhanVien.Text = currentNV.MaNv;
                txbSDT.Text = currentNV.Sdt;
                cbbGioiTinh.SelectedIndex = currentNV.GioiTinh == true ? 0 : 1;
                dtpkNgaySinh.Value = currentNV.NgaySinh;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu cá nhân!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnLuu.Enabled = false;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            mainUI newF = pnl.Parent as mainUI;

            newF.showBlur();
            fDoiMatKhau newform = new fDoiMatKhau(currentNV);
            newform.ShowDialog();
            newF.closeBlur();
            btnDangXuat.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Parent as Panel;
            mainUI newF = pnl.Parent as mainUI;

            newF.showBlur();
            fQlyNhanVien newform = new fQlyNhanVien(choseNV);
            newform.ShowDialog();
            newF.closeBlur();

            if (choseNV.Equals(currentNV.MaNv))
            {
                DialogResult ok = MessageBox.Show("Vui lòng đăng nhập lại hệ thống!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDangXuat.PerformClick();
            }
            loadData();
            choseNV = string.Empty;
        }

        private void ucTaiKhoan_Load(object sender, EventArgs e)
        {
            loadData();
            if(currentNV.MaCv == "ql")
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false; 
            }
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(checkHopLe())
            {
                DialogResult kq = MessageBox.Show("Xác nhận cập nhật thông tin?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (kq == DialogResult.Yes)
                {
                    try
                    {
                        BaiXeDBContext db = new BaiXeDBContext();

                        NhanVien nv = db.NhanVien.Find(txbMaNhanVien.Text);
                        if (nv != null)
                        {
                            nv.Sdt = txbSDT.Text;
                            nv.Email = txbEmail.Text;
                            nv.HoTen = txbHoTen.Text;
                            nv.GioiTinh = cbbGioiTinh.SelectedIndex == 1 ? false : true;
                            nv.NgaySinh = dtpkNgaySinh.Value;

                            db.SaveChanges();
                        }
                        DialogResult ok =  MessageBox.Show("Vui lòng đăng nhập lại hệ thống!", "Lưu ý", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        btnDangXuat.PerformClick();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật thông tin nhân viên!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private bool checkHopLe()
        {
            if (txbEmail.Text.IsNullOrEmpty() ||
                txbHoTen.Text.IsNullOrEmpty() ||
                txbSDT.Text.IsNullOrEmpty() ||
                cbbGioiTinh.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(txbEmail.Text, pattern))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng email. \nVí dụ: abc@gmail.com", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbEmail.Focus();
                    txbEmail.SelectAll();
                    return false;
                }
            }
            return true;
        }
        private void txbHoTen_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void findMaNV()
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryNV = from nv in db.NhanVien
                              join cv in db.ChucVu on nv.MaCv equals cv.MaCv
                              where nv.MaNv.Contains(txbTimKiem.Text)
                              select new
                              {
                                  nv.MaNv,
                                  nv.HoTen,
                                  cv.TenCv,
                                  nv.Sdt,
                                  nv.NgaySinh,
                                  GioiTinh = nv.GioiTinh == true ? "Nam" : "Nữ",
                              };

                //dgvNhanVien.Rows.Clear();
                dgvNhanVien.DataSource = queryNV.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin nhân viên!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findHoTen()
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var queryNV = from nv in db.NhanVien
                                join cv in db.ChucVu on nv.MaCv equals cv.MaCv
                                where nv.HoTen.Contains(txbTimKiem.Text)
                                select new
                                {
                                    nv.MaNv,
                                    nv.HoTen,
                                    cv.TenCv,
                                    nv.Sdt,
                                    nv.NgaySinh,
                                    GioiTinh = nv.GioiTinh == true ? "Nam" : "Nữ",
                                };

                //dgvNhanVien.Rows.Clear();
                dgvNhanVien.DataSource = queryNV.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin nhân viên!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnTimMaNV_Click(object sender, EventArgs e)
        {
            findMaNV();
        }

        private void btnTimTen_Click(object sender, EventArgs e)
        {
            findHoTen();
        }
    }
}
