using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public int MaTk { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
