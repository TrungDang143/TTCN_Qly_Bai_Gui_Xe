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
using System.Xml.Linq;

namespace QlyBaiGuiXe.GUI.BaiXe
{
    public partial class fBTbaiXe : Form
    {
        public fBTbaiXe()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(Setting.BoForm.CreateRoundRectRgn(0, 0, Width, Height, 30, 30));

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Setting.TitleBar.ReleaseCapture();
                Setting.TitleBar.SendMessage(Handle, Setting.TitleBar.WM_NCLBUTTONDOWN, Setting.TitleBar.HTCAPTION, 0);
            }
        }

        private string getMaBaiXe(string name)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                var tenbai = (from bx in db.BaiXe
                              where bx.TenBai == name
                              select bx.MaBaiXe).FirstOrDefault();
                return tenbai;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu mã bãi xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        private string getMaLoaiXeByMaBaiXe(string mabx)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();

                var loaixe = (from lx in db.LoaiXe
                                join bx in db.BaiXe on lx.MaBaiXe equals bx.MaBaiXe
                                where bx.MaBaiXe == mabx
                                select lx.MaLoaiXe).FirstOrDefault();
                return loaixe;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu mã loại xe bằng mã bãi xe\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        private void cbbBaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var slc = (from bx in db.BaiXe
                          where bx.MaBaiXe == getMaBaiXe(cbbBaiXe.Text)
                          select bx.SoLuong).FirstOrDefault();
                var dd = (from hd in db.HoaDon
                          join lx in db.LoaiXe on hd.MaLoaiXe equals lx.MaLoaiXe
                          where hd.MaLoaiXe == getMaLoaiXeByMaBaiXe(cbbBaiXe.Text)
                          select hd).Count();

                txbDaDung.Text = dd.ToString();
                txbTongSL.Text = (slc+dd).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu số lượng chỗ để xe\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fBTbaiXe_Load(object sender, EventArgs e)
        {
            try
            {
                BaiXeDBContext db = new BaiXeDBContext();
                var baixe = (from bx in db.BaiXe
                             select bx.TenBai).ToList();
                foreach(var baix in baixe)
                {
                    cbbBaiXe.Items.Add(baix);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu bãi xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkHopLe()
        {
            if (txbDaDung.Text.IsNullOrEmpty() ||
                txbTongSL.Text.IsNullOrEmpty())
            {
                return false;
            }
            else 
            {
                if(int.TryParse(txbTongSL.Text, out int tong) &&
                    int.TryParse(txbDaDung.Text, out int dd) &&
                    tong >= dd)
                {
                    return true;
                }
                return false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkHopLe())
            {
                try
                {
                    BaiXeDBContext db = new BaiXeDBContext();
                    var tongCu = (from bx in db.BaiXe
                                  select bx.SoLuong).Sum();

                    var baixe = (from bx in db.BaiXe
                                 where bx.MaBaiXe == getMaBaiXe(cbbBaiXe.Text)
                                 select bx).FirstOrDefault();

                    baixe.SoLuong = int.Parse(txbTongSL.Text);
                    db.SaveChanges();

                    int tongMoi = (from bx in db.BaiXe
                                   select bx.SoLuong).Sum();

                    if (tongCu < tongMoi)
                    {
                        try
                        {
                            for (int i = tongCu+1; i <= tongMoi; i++)
                            {
                                VeLuot newVL = new VeLuot();
                                //insert into VeLuot values(concat('VE', @n), 'VL','')
                                newVL.MaVe = "VE" + i.ToString();
                                newVL.MaLoaiVe = "VL";
                                newVL.BienSo = "";

                                db.VeLuot.Add(newVL);
                                db.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi thêm chỗ để xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MessageBox.Show("Thay đổi số lượng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thay đổi số lượng chỗ gửi xe!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
