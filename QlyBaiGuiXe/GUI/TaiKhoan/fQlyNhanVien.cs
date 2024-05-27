using Microsoft.EntityFrameworkCore;
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

namespace QlyBaiGuiXe.GUI.TaiKhoan
{
    public partial class fQlyNhanVien : Form
    {
        private string choseNV = string.Empty;
        public fQlyNhanVien(string manv)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

            this.choseNV = manv;
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

        bool showPass = false;
        private void picMk_Click(object sender, EventArgs e)
        {
            if (showPass == false)
            {
                this.picMk.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbMk.PasswordChar = '\0';
                showPass = true;
            }
            else
            {
                this.picMk.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbMk.PasswordChar = '\u2022';
                showPass = false;
            }
        }
        bool showEmail = false;
        private void picEmail_Click(object sender, EventArgs e)
        {
            if (showEmail == false)
            {
                this.picEmail.Image = global::QlyBaiGuiXe.Properties.Resources.hide;
                txbEmail.PasswordChar = '\0';
                showEmail = true;
            }
            else
            {
                this.picEmail.Image = global::QlyBaiGuiXe.Properties.Resources.view;
                txbEmail.PasswordChar = '\u2022';
                showEmail = false;
            }
        }

        private void fQlyNhanVien_Load(object sender, EventArgs e)
        {
            dtpk.Format = DateTimePickerFormat.Custom;
            dtpk.CustomFormat = "dd/MM/yyyy";

            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");

            BaiXeDBContext db = new BaiXeDBContext();
            var chucvu = (from cv in db.ChucVu
                          select cv.TenCv).ToList();
            foreach(var cv in chucvu)
            {
                cbbChucVu.Items.Add(cv);
            }

            if (!choseNV.IsNullOrEmpty())
            {
                var query = (from nv in db.NhanVien
                             join tk in db.TaiKhoan on nv.MaTk equals tk.MaTk
                             join cv in db.ChucVu on nv.MaCv equals cv.MaCv
                             where nv.MaNv == choseNV
                             select new
                             {
                                 nv.MaNv,
                                 cv.TenCv,
                                 nv.HoTen,
                                 nv.Sdt,
                                 nv.GioiTinh,
                                 nv.NgaySinh,
                                 nv.Email,
                                 tk.MatKhau
                             }).First();

                txbEmail.Text = query.Email;
                txbHoTen.Text = query.HoTen;
                txbMaNV.Text = query.MaNv;
                txbMk.Text = query.MatKhau;
                txbSDT.Text = query.Sdt;
                cbbChucVu.Text = query.TenCv;
                cbbGioiTinh.Text = query.GioiTinh ? "Nam" : "Nữ";

                txbMaNV.ReadOnly = true;
                txbMaNV.BackColor = System.Drawing.Color.Lavender; 
            }
        }

        private bool checkHopLe()
        {
            if (txbEmail.Text.IsNullOrEmpty() ||
                txbHoTen.Text.IsNullOrEmpty() ||
                txbMaNV.Text.IsNullOrEmpty() ||
                txbMk.Text.IsNullOrEmpty() ||
                txbSDT.Text.IsNullOrEmpty() ||
                cbbChucVu.Text.IsNullOrEmpty() ||
                cbbGioiTinh.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnTaoNV_Click(object sender, EventArgs e)
        {
            if (checkHopLe())  
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();
                    var tontai = (from nv in db.NhanVien
                                  where nv.MaNv == txbMaNV.Text
                                  select nv).Count();
                    if (tontai > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbMaNV.Focus();
                        txbMaNV.SelectAll();
                    }
                    else
                    {
                        try
                        {
                            Entities.TaiKhoan newTK = new Entities.TaiKhoan();
                            newTK.MatKhau = txbMk.Text;
                            newTK.TenDangNhap = txbMaNV.Text;
                            db.TaiKhoan.Add(newTK);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi tạo tài khoản mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        try
                        {
                            Entities.NhanVien newNV = new Entities.NhanVien();

                            newNV.MaNv = txbMaNV.Text;
                            newNV.HoTen = txbHoTen.Text;
                            newNV.GioiTinh = true ? cbbGioiTinh.Text.CompareTo("Nam") == 0 : false;
                            newNV.NgaySinh = dtpk.Value.Date;
                            newNV.Sdt = txbSDT.Text;
                            newNV.Email = txbEmail.Text;
                            newNV.MaCv = (from cv in db.ChucVu where cv.TenCv == cbbChucVu.Text select cv.MaCv).FirstOrDefault();
                            newNV.MaTk = (from tk in db.TaiKhoan where tk.TenDangNhap == newNV.MaNv select tk.MaTk).FirstOrDefault();
                            db.NhanVien.Add(newNV);
                            db.SaveChanges();
                            MessageBox.Show("Tạo thành công nhân viên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi tạo nhân viên mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txbEmail.Text = string.Empty;
            txbHoTen.Text = string.Empty;
            txbMaNV.Text = string.Empty;
            txbMk.Text = string.Empty;
            txbSDT.Text = string.Empty;
            cbbChucVu.Text = string.Empty;
            cbbGioiTinh.Text = string.Empty;
            dtpk.Value = DateTime.Now;

            txbMaNV.ReadOnly = false;
            txbMaNV.BackColor = SystemColors.Window;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác nhận xoá nhân viên này?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();
                    Entities.NhanVien nvcanxoa = (from nv in db.NhanVien where nv.MaNv == txbMaNV.Text select nv).FirstOrDefault();
                    Entities.TaiKhoan tkcanxoa = (from tk in db.TaiKhoan where tk.MaTk == nvcanxoa.MaTk select tk).FirstOrDefault();
                    db.Remove(nvcanxoa);
                    db.Remove(tkcanxoa);
                    db.SaveChanges();

                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
