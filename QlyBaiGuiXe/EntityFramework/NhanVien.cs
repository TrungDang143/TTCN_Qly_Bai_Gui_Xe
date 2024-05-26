using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.EntityFramework
{
    public partial class NhanVien
    {
        public string MaNv { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string Email { get; set; }
        public string MaTk { get; set; }
        public string MaCv { get; set; }

        public virtual ChucVu MaCvNavigation { get; set; }
        public virtual TaiKhoan MaTkNavigation { get; set; }
    }
}
