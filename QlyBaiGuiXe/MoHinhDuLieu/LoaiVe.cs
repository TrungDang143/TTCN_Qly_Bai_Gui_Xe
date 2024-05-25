using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.MoHinhDuLieu
{
    public partial class LoaiVe
    {
        public LoaiVe()
        {
            BangGia = new HashSet<BangGia>();
            HoaDon = new HashSet<HoaDon>();
            VeLuot = new HashSet<VeLuot>();
            VeThang = new HashSet<VeThang>();
        }

        public string MaLoaiVe { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<BangGia> BangGia { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<VeLuot> VeLuot { get; set; }
        public virtual ICollection<VeThang> VeThang { get; set; }
    }
}
