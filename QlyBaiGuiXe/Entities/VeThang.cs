using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class VeThang
    {
        public string MaVe { get; set; }
        public string BienSo { get; set; }
        public string MaLoaiVe { get; set; }
        public DateTime ThoiHan { get; set; }
        public int MaKh { get; set; }

        public virtual Xe BienSoNavigation { get; set; }
        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual LoaiVe MaLoaiVeNavigation { get; set; }
    }
}
