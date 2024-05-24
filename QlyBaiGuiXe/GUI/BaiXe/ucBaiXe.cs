using QlyBaiGuiXe.GUI.BaiXe;
using QlyBaiGuiXe.MoHinhDuLieu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI
{
    public partial class ucBaiXe : UserControl
    {
        testBaiXeContext db = new testBaiXeContext();
        public ucBaiXe()
        {
            InitializeComponent();
            ucBaiXeLoad();
        }
        private void ucBaiXeLoad()
        {
            dgvBaiXe.AutoGenerateColumns = false;
            dgvBaiXe.ColumnCount = 5;
            dgvBaiXe.Columns[0].Name = "Mã vé";
            dgvBaiXe.Columns[1].Name = "Loại xe";
            dgvBaiXe.Columns[2].Name = "Biển số";
            dgvBaiXe.Columns[3].Name = "Thời gian nhập";
            dgvBaiXe.Columns[4].Name = "Thời gian xuất";
            var queryBaiXe = from hd in db.HoaDon
                             join LV in db.LoaiVe on hd.MaLoaiVe equals LV.MaLoaiVe
                             join maLX in db.LoaiXe on hd.MaLoaiXe equals maLX.MaLoaiXe
                             join xe in db.Xe on maLX.MaLoaiXe equals xe.MaLoaiXe
                             select new
                             {
                                 hd.MaVe,
                                 maLX.TenXe,
                                 xe.BienSo,
                                 hd.TgVao,
                                 hd.TgRa,
                             };
            dgvBaiXe.DataSource = queryBaiXe.ToList(); 
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

        private void btnNhapXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            if (isCheck() == true)
            {
                Xe xeMoi = new Xe();
                MessageBox.Show("Nhập xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatXe_Click(object sender, EventArgs e)
        {
            //xu ly sql
            MessageBox.Show("Xuất xe thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvBaiXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public bool isCheck()
        {
            if(cbbLoaiVe.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn loại vé!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLoaiVe.Focus();
                return false;
            }
            if(cbbLoaiXe.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn loại xe!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLoaiXe.Focus();
                return false;
            }
            if(txbBienSo.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập biển số!", "Nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
