using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.EntityFramework
{
    public partial class BaiXe
    {
        public BaiXe()
        {
            LoaiXe = new HashSet<LoaiXe>();
        }

        public string MaBaiXe { get; set; }
        public int SoLuong { get; set; }
        public string TenBai { get; set; }

        public virtual ICollection<LoaiXe> LoaiXe { get; set; }
    }
}
