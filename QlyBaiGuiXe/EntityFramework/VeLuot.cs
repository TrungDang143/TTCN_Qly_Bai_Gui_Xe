using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.EntityFramework
{
    public partial class VeLuot
    {
        public string MaVe { get; set; }
        public string MaLoaiVe { get; set; }
        public string BienSo { get; set; }

        public virtual LoaiVe MaLoaiVeNavigation { get; set; }
    }
}
