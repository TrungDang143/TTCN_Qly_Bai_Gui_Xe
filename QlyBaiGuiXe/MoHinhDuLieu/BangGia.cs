using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.MoHinhDuLieu
{
    public partial class BangGia
    {
        public string MaLoaiXe { get; set; }
        public string MaLoaiVe { get; set; }
        public int Gia { get; set; }

        public virtual LoaiVe MaLoaiVeNavigation { get; set; }
        public virtual LoaiXe MaLoaiXeNavigation { get; set; }
    }
}
