using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.MoHinhDuLieu
{
    public partial class Xe
    {
        public Xe()
        {
            VeThang = new HashSet<VeThang>();
        }

        public string BienSo { get; set; }
        public string MaLoaiXe { get; set; }
        public string MaKh { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual LoaiXe MaLoaiXeNavigation { get; set; }
        public virtual ICollection<VeThang> VeThang { get; set; }
    }
}
