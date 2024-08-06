using Microsoft.Identity.Client;
using QlyBaiGuiXe.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI.DieuHuongTrang
{
    public partial class UserControl1 : UserControl
    {
        private int tongSoTrang = 1;
        private int recordPerPage = 20;
        private int trangHienTai = 1;

        
        public UserControl1()
        {
            InitializeComponent();
        }
        public void CreateDieuHuongTrang(int tongso)
        {
            this.tongSoTrang = tongso;
            btnCenter.Text = $"{1}/{tongSoTrang} trang";
            checkBtn();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public class DataEventArgs : EventArgs
        {
            public int Data { get; }

            public DataEventArgs(int data)
            {
                Data = data;
            }
        }

        public event EventHandler<DataEventArgs> DataSent;
        private void btnr_Click(object sender, EventArgs e)
        {
            trangHienTai+=1;
            btnCenter.Text = $"{trangHienTai}/{tongSoTrang} trang";
            checkBtn();
            DataSent?.Invoke(this, new DataEventArgs(trangHienTai));
        }

        private void btnrr_Click(object sender, EventArgs e)
        {
            trangHienTai = tongSoTrang;
            btnCenter.Text = $"{trangHienTai}/{tongSoTrang} trang";
            checkBtn();
            DataSent?.Invoke(this, new DataEventArgs(trangHienTai));
        }

        private void btnl_Click(object sender, EventArgs e)
        {
            trangHienTai -= 1;
            btnCenter.Text = $"{trangHienTai}/{tongSoTrang} trang";
            checkBtn();
            DataSent?.Invoke(this, new DataEventArgs(trangHienTai));
        }

        private void btnll_Click(object sender, EventArgs e)
        {
            trangHienTai = 1;
            btnCenter.Text = $"{trangHienTai}/{tongSoTrang} trang";
            checkBtn();
            DataSent?.Invoke(this, new DataEventArgs(trangHienTai));
        }
        private void checkBtn()
        {
            if(trangHienTai == tongSoTrang)
            {
                btnr.Enabled = false;
                btnrr.Enabled = false;
                btnl.Enabled = true;
                btnll.Enabled = true;
            }
            if(trangHienTai == 1)
            {
                btnl.Enabled = false;
                btnll.Enabled = false;
                btnr.Enabled = true;
                btnrr.Enabled = true;
            }
            if(trangHienTai!= 1 && trangHienTai!=tongSoTrang)
            {
                btnl.Enabled = true;
                btnll.Enabled = true;
                btnr.Enabled = true;
                btnrr.Enabled = true;
            }
        }
    }
}
