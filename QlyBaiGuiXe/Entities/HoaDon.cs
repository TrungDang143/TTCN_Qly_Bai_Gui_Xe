using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class HoaDon
    {
        public int MaHd { get; set; }
        public DateTime TgVao { get; set; }
        public DateTime? TgRa { get; set; }
        public string MaVe { get; set; }
        public string MaLoaiVe { get; set; }
        public string MaNv { get; set; }
        public string MaLoaiXe { get; set; }
        public string BienSo { get; set; }
        public int Gia { get; set; }

        public virtual LoaiVe MaLoaiVeNavigation { get; set; }
        public virtual LoaiXe MaLoaiXeNavigation { get; set; }
    }
}
