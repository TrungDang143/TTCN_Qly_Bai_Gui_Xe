using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class LoaiXe
    {
        public LoaiXe()
        {
            BangGia = new HashSet<BangGia>();
            HoaDon = new HashSet<HoaDon>();
            Xe = new HashSet<Xe>();
        }

        public string MaLoaiXe { get; set; }
        public string TenXe { get; set; }
        public string MaBaiXe { get; set; }

        public virtual BaiXe MaBaiXeNavigation { get; set; }
        public virtual GiaQuaDem GiaQuaDem { get; set; }
        public virtual ICollection<BangGia> BangGia { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<Xe> Xe { get; set; }
    }
}
