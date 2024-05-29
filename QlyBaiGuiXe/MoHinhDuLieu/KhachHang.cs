using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            VeThang = new HashSet<VeThang>();
            Xe = new HashSet<Xe>();
        }

        public int MaKh { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<VeThang> VeThang { get; set; }
        public virtual ICollection<Xe> Xe { get; set; }
    }
}
