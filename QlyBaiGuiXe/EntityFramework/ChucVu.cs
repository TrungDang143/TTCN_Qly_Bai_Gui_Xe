using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.EntityFramework
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public string MaCv { get; set; }
        public string TenCv { get; set; }

        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
