using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class GiaQuaDem
    {
        public int Gia { get; set; }
        public string MaLoaiXe { get; set; }

        public virtual LoaiXe MaLoaiXeNavigation { get; set; }
    }
}
