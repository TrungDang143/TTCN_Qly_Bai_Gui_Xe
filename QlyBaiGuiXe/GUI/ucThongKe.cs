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
        private string locNgay = string.Empty;
        private string locLoai = string.Empty;
        public ucThongKe()
        {
            InitializeComponent();
        }

        private void resetFilterNgay()
        {
            this.btnNgay.BackColor = System.Drawing.Color.Lavender;
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

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            locNgay = "ngay";
            locLoai = "all";
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnNgay.BackColor = System.Drawing.Color.LightSteelBlue;
            locNgay = "ngay";

            //xuly
        }

        private void btnTuan_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnTuan.BackColor = System.Drawing.Color.LightSteelBlue;
            locNgay = "tuan";

            //xuly
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnThang.BackColor = System.Drawing.Color.LightSteelBlue;
            locNgay = "thang";

            //xuly
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            resetFilterNgay();
            this.btnNam.BackColor = System.Drawing.Color.LightSteelBlue;
            locNgay = "nam";

            //xuly
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            resetFilterLoai();
            this.btnAll.BackColor = System.Drawing.Color.LightSteelBlue;
            locLoai = "all";

            //xuly
        }

        private void btnVeLuot_Click(object sender, EventArgs e)
        {
            resetFilterLoai();
            this.btnVeLuot.BackColor = System.Drawing.Color.LightSteelBlue;
            locLoai = "veLuot";

            //xuly
        }

        private void btnVeThang_Click(object sender, EventArgs e)
        {
            resetFilterLoai();
            this.btnVeThang.BackColor = System.Drawing.Color.LightSteelBlue;
            locLoai = "veThang";

            //xuly
        }
    }
}
