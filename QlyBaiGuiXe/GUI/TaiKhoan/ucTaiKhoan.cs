using QlyBaiGuiXe.GUI.TaiKhoan;
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
    public partial class ucTaiKhoan : UserControl
    {
        public ucTaiKhoan()
        {
            InitializeComponent();
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
            fQlyNhanVien newform = new fQlyNhanVien();
            newform.ShowDialog();
            newF.closeBlur();
        }
    }
}
