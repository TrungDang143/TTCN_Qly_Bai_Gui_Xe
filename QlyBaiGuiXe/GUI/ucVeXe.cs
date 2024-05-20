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
    public partial class ucVeXe : UserControl
    {
        public ucVeXe()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ucVeXe_Load(object sender, EventArgs e)
        {
            dtpk.Text = DateTime.Now.AddMonths(1).ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txbBienSo.Text = string.Empty;
            txbChuXe.Text = string.Empty;
            txbDiaChi.Text = string.Empty;
            txbSDT.Text = string.Empty;
            txbMucPhi.Text = string.Empty;
            cbbLoaiXe.Text = string.Empty;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn đăng ký vé tháng mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(kq == DialogResult.Yes)
            {
                // xu ly sql

                MessageBox.Show("Thong bao");
            }
        }
    }
}
