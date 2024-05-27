using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QlyBaiGuiXe.Entities
{
    public partial class BaiXeDBContext : DbContext
    {
        public BaiXeDBContext()
        {
        }

        public BaiXeDBContext(DbContextOptions<BaiXeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiXe> BaiXe { get; set; }
        public virtual DbSet<BangGia> BangGia { get; set; }
        public virtual DbSet<ChucVu> ChucVu { get; set; }
        public virtual DbSet<GiaQuaDem> GiaQuaDem { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiVe> LoaiVe { get; set; }
        public virtual DbSet<LoaiXe> LoaiXe { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<VeLuot> VeLuot { get; set; }
        public virtual DbSet<VeThang> VeThang { get; set; }
        public virtual DbSet<Xe> Xe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=dTrung\\SQLEXPRESS;Initial Catalog=BaiXeDB;Integrated Security=True ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiXe>(entity =>
            {
                entity.HasKey(e => e.MaBaiXe)
                    .HasName("PK__BaiXe__FA021C433F494106");

                entity.Property(e => e.MaBaiXe)
                    .HasColumnName("maBaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenBai)
                    .IsRequired()
                    .HasColumnName("tenBai")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<BangGia>(entity =>
            {
                entity.HasKey(e => new { e.MaLoaiXe, e.MaLoaiVe })
                    .HasName("PK__BangGia__1D0DCD9FA55D0BE1");

                entity.Property(e => e.MaLoaiXe)
                    .HasColumnName("maLoaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiVe)
                    .HasColumnName("maLoaiVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.HasOne(d => d.MaLoaiVeNavigation)
                    .WithMany(p => p.BangGia)
                    .HasForeignKey(d => d.MaLoaiVe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BangGia__maLoaiV__5535A963");

                entity.HasOne(d => d.MaLoaiXeNavigation)
                    .WithMany(p => p.BangGia)
                    .HasForeignKey(d => d.MaLoaiXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BangGia__maLoaiX__5165187F");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__ChucVu__7A3E0CF0801AE12F");

                entity.Property(e => e.MaCv)
                    .HasColumnName("maCV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenCv)
                    .IsRequired()
                    .HasColumnName("tenCV")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<GiaQuaDem>(entity =>
            {
                entity.HasKey(e => e.MaLoaiXe)
                    .HasName("PK__GiaQuaDe__7AA7B7E53B3DB6A5");

                entity.Property(e => e.MaLoaiXe)
                    .HasColumnName("maLoaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gia).HasColumnName("gia");

                entity.HasOne(d => d.MaLoaiXeNavigation)
                    .WithOne(p => p.GiaQuaDem)
                    .HasForeignKey<GiaQuaDem>(d => d.MaLoaiXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GiaQuaDem__maLoa__534D60F1");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__7A3E1486D6EAC38C");

                entity.Property(e => e.MaHd).HasColumnName("maHD");

                entity.Property(e => e.MaLoaiVe)
                    .IsRequired()
                    .HasColumnName("maLoaiVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiXe)
                    .IsRequired()
                    .HasColumnName("maLoaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasColumnName("maNV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaVe)
                    .IsRequired()
                    .HasColumnName("maVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TgRa)
                    .HasColumnName("tgRa")
                    .HasColumnType("datetime");

                entity.Property(e => e.TgVao)
                    .HasColumnName("tgVao")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MaLoaiVeNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaLoaiVe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__maLoaiVe__571DF1D5");

                entity.HasOne(d => d.MaLoaiXeNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaLoaiXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__maLoaiXe__52593CB8");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__7A3ECFE48FFA1524");

                entity.Property(e => e.MaKh).HasColumnName("maKH");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasColumnName("diaChi")
                    .HasMaxLength(20);

                entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasColumnName("hoTen")
                    .HasMaxLength(30);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoaiVe>(entity =>
            {
                entity.HasKey(e => e.MaLoaiVe)
                    .HasName("PK__LoaiVe__7AA7A7A7D8FB1380");

                entity.Property(e => e.MaLoaiVe)
                    .HasColumnName("maLoaiVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasColumnName("tenLoai")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<LoaiXe>(entity =>
            {
                entity.HasKey(e => e.MaLoaiXe)
                    .HasName("PK__LoaiXe__7AA7B7E53592021A");

                entity.Property(e => e.MaLoaiXe)
                    .HasColumnName("maLoaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaBaiXe)
                    .IsRequired()
                    .HasColumnName("maBaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenXe)
                    .IsRequired()
                    .HasColumnName("tenXe")
                    .HasMaxLength(15);

                entity.HasOne(d => d.MaBaiXeNavigation)
                    .WithMany(p => p.LoaiXe)
                    .HasForeignKey(d => d.MaBaiXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoaiXe__maBaiXe__59FA5E80");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__7A3EC7D5CFBEC5BE");

                entity.Property(e => e.MaNv)
                    .HasColumnName("maNV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasColumnName("gioiTinh");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasColumnName("hoTen")
                    .HasMaxLength(30);

                entity.Property(e => e.MaCv)
                    .IsRequired()
                    .HasColumnName("maCV")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaTk).HasColumnName("maTK");

                entity.Property(e => e.NgaySinh)
                    .HasColumnName("ngaySinh")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__maCV__5AEE82B9");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__maTK__4E88ABD4");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk)
                    .HasName("PK__TaiKhoan__7A22625E9ABE76AC");

                entity.Property(e => e.MaTk).HasColumnName("maTK");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasColumnName("matKhau")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .IsRequired()
                    .HasColumnName("tenDangNhap")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VeLuot>(entity =>
            {
                entity.HasKey(e => e.MaVe)
                    .HasName("PK__VeLuot__7A22727651E5836C");

                entity.Property(e => e.MaVe)
                    .HasColumnName("maVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BienSo)
                    .HasColumnName("bienSo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaLoaiVe)
                    .IsRequired()
                    .HasColumnName("maLoaiVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaLoaiVeNavigation)
                    .WithMany(p => p.VeLuot)
                    .HasForeignKey(d => d.MaLoaiVe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VeLuot__maLoaiVe__5441852A");
            });

            modelBuilder.Entity<VeThang>(entity =>
            {
                entity.HasKey(e => e.MaVe)
                    .HasName("PK__VeThang__7A22727696E4C170");

                entity.Property(e => e.MaVe)
                    .HasColumnName("maVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BienSo)
                    .IsRequired()
                    .HasColumnName("bienSo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MaKh).HasColumnName("maKH");

                entity.Property(e => e.MaLoaiVe)
                    .IsRequired()
                    .HasColumnName("maLoaiVe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThoiHan)
                    .HasColumnName("thoiHan")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.BienSoNavigation)
                    .WithMany(p => p.VeThang)
                    .HasForeignKey(d => d.BienSo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VeThang__bienSo__4F7CD00D");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.VeThang)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VeThang__maKH__59063A47");

                entity.HasOne(d => d.MaLoaiVeNavigation)
                    .WithMany(p => p.VeThang)
                    .HasForeignKey(d => d.MaLoaiVe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VeThang__maLoaiV__5629CD9C");
            });

            modelBuilder.Entity<Xe>(entity =>
            {
                entity.HasKey(e => e.BienSo)
                    .HasName("PK__Xe__8563D8C7115F7B39");

                entity.Property(e => e.BienSo)
                    .HasColumnName("bienSo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MaKh).HasColumnName("maKH");

                entity.Property(e => e.MaLoaiXe)
                    .IsRequired()
                    .HasColumnName("maLoaiXe")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Xe)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Xe__maKH__5812160E");

                entity.HasOne(d => d.MaLoaiXeNavigation)
                    .WithMany(p => p.Xe)
                    .HasForeignKey(d => d.MaLoaiXe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Xe__maLoaiXe__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
