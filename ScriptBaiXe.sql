/*
Created		4/20/2024
Modified		4/25/2024
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

use master
go

drop database if EXISTS BaiXeDB
go

create database BaiXeDB
go

use BaiXeDB
go

Create table [NhanVien]
(
	[maNV] varchar(10) NOT NULL,
	[hoTen] Nvarchar(30) NOT NULL,
	[SDT] varchar(11) NOT NULL,
	[ngaySinh] Datetime NOT NULL,
	[gioiTinh] Bit NOT NULL,
	[email] varchar(20) NOT NULL,
	[maTK] int NOT NULL,
	[maCV] varchar(10) NOT NULL,
Primary Key ([maNV])
) 
go

Create table [TaiKhoan]
(
	[maTK] int identity(1,1) NOT NULL,
	[tenDangNhap] varchar(15) NOT NULL,
	[matKhau] varchar(20) NOT NULL,
Primary Key ([maTK])
) 
go

Create table [Xe]
(
	[bienSo] varchar(15) NOT NULL,
	[maLoaiXe] varchar(10) NOT NULL,
	[maKH] int NOT NULL,
Primary Key ([bienSo])
) 
go

Create table [LoaiXe]
(
	[maLoaiXe] varchar(10) NOT NULL,
	[tenXe] Nvarchar(15) NOT NULL,
	[maBaiXe] varchar(10) NOT NULL,
Primary Key ([maLoaiXe])
) 
go

Create table [LoaiVe]
(
	[maLoaiVe] varchar(10) NOT NULL,
	[tenLoai] Nvarchar(10) NOT NULL,
Primary Key ([maLoaiVe])
) 
go

Create table [VeLuot]
(
	[maVe] varchar(10) NOT NULL,
	[maLoaiVe] varchar(10) NOT NULL,
	[bienSo] varchar(10) NULL,
Primary Key ([maVe])
) 
go

Create table [KhachHang]
(
	[maKH] int identity(1,1) NOT NULL,
	[hoTen] Nvarchar(30) NOT NULL,
	[SDT] varchar(11) NOT NULL,
	[gioiTinh] Bit NOT NULL,
	[diaChi] Nvarchar(20) NOT NULL,
Primary Key ([maKH])
) 
go

Create table [BangGia]
(
	[maLoaiXe] varchar(10) NOT NULL,
	[maLoaiVe] varchar(10) NOT NULL,
	[gia] Integer NOT NULL,
Primary Key ([maLoaiXe],[maLoaiVe])
) 
go

Create table [VeThang]
(
	[maVe] varchar(10) NOT NULL,
	[bienSo] varchar(15) NOT NULL,
	[maLoaiVe] varchar(10) NOT NULL,
	[thoiHan] Datetime NOT NULL,
	[maKH] int NOT NULL,
Primary Key ([maVe])
) 
go

Create table [HoaDon]
(
	[maHD] int identity(1,1) NOT NULL,
	[tgVao] Datetime NOT NULL,
	[tgRa] Datetime NULL,
	[maVe] varchar(10) NOT NULL,
	[maLoaiVe] varchar(10) NOT NULL,
	[maNV] varchar(10) NOT NULL,
	[maLoaiXe] varchar(10) NOT NULL,
Primary Key ([maHD])
) 
go

Create table [BaiXe]
(
	[maBaiXe] varchar(10) NOT NULL,
	[soLuong] Integer NOT NULL,
	[tenBai] Nvarchar(20) NOT NULL,
Primary Key ([maBaiXe])
) 
go

Create table [ChucVu]
(
	[maCV] varchar(10) NOT NULL,
	[tenCV] Nvarchar(15) NOT NULL,
Primary Key ([maCV])
) 
go

Create table [GiaQuaDem]
(
	[gia] Integer NOT NULL,
	[maLoaiXe] varchar(10) NOT NULL,
Primary Key ([maLoaiXe])
) 
go


Alter table [NhanVien] add  foreign key([maTK]) references [TaiKhoan] ([maTK])  on update no action on delete no action 
go
Alter table [VeThang] add  foreign key([bienSo]) references [Xe] ([bienSo])  on update no action on delete no action 
go
Alter table [Xe] add  foreign key([maLoaiXe]) references [LoaiXe] ([maLoaiXe])  on update no action on delete no action 
go
Alter table [BangGia] add  foreign key([maLoaiXe]) references [LoaiXe] ([maLoaiXe])  on update no action on delete no action 
go
Alter table [HoaDon] add  foreign key([maLoaiXe]) references [LoaiXe] ([maLoaiXe])  on update no action on delete no action 
go
Alter table [GiaQuaDem] add  foreign key([maLoaiXe]) references [LoaiXe] ([maLoaiXe])  on update no action on delete no action 
go
Alter table [VeLuot] add  foreign key([maLoaiVe]) references [LoaiVe] ([maLoaiVe])  on update no action on delete no action 
go
Alter table [BangGia] add  foreign key([maLoaiVe]) references [LoaiVe] ([maLoaiVe])  on update no action on delete no action 
go
Alter table [VeThang] add  foreign key([maLoaiVe]) references [LoaiVe] ([maLoaiVe])  on update no action on delete no action 
go
Alter table [HoaDon] add  foreign key([maLoaiVe]) references [LoaiVe] ([maLoaiVe])  on update no action on delete no action 
go
Alter table [Xe] add  foreign key([maKH]) references [KhachHang] ([maKH])  on update no action on delete no action 
go
Alter table [VeThang] add  foreign key([maKH]) references [KhachHang] ([maKH])  on update no action on delete no action 
go
Alter table [LoaiXe] add  foreign key([maBaiXe]) references [BaiXe] ([maBaiXe])  on update no action on delete no action 
go
Alter table [NhanVien] add  foreign key([maCV]) references [ChucVu] ([maCV])  on update no action on delete no action 
go



Set quoted_identifier on
go


Set quoted_identifier off
go



insert into BaiXe values("bx01", 100, N'Bãi xe máy')
insert into BaiXe values("bx02", 100, N'Bãi xe ô tô')
insert into BaiXe values("bx03", 100, N'Bãi xe khách')

insert into LoaiXe values("xe01", N'Xe máy', "bx01")
insert into LoaiXe values("xe02", N'Xe ô tô', "bx02")
insert into LoaiXe values("xe03", N'Xe khách', "bx03")

insert into LoaiVe values("VL", N'Vé lượt')
insert into LoaiVe values("VT", N'Vé tháng')

insert into GiaQuaDem values(10000, "xe01")
insert into GiaQuaDem values(20000, "xe02")
insert into GiaQuaDem values(30000, "xe03")

insert into BangGia values("xe01", "VL", 5000)
insert into BangGia values("xe01", "VT", 150000)
insert into BangGia values("xe02", "VL", 20000)
insert into BangGia values("xe02", "VT", 350000)
insert into BangGia values("xe03", "VL", 30000)
insert into BangGia values("xe03", "VT", 500000)

insert into KhachHang values("dang duc trung", "0123456789", 1, "hoa binh")
insert into Xe values("28L1 23127", "xe01", 1)
insert into Xe values("28L1 3427", "xe01", 1)

insert into VeLuot values("VE1","VL", "28L1 11111")
insert into VeLuot values("VE2", "VL", "28L1 23127")
insert into VeThang values("VT1", "28L1 23127", "VT", "2024/12/12", 1)
insert into VeThang values("VT2", "28L1 3427", "VT", "2024/12/12", 1)

insert into ChucVu values("nv", N'Nhân viên')
insert into ChucVu values("ql", N'Quản lý')


insert into TaiKhoan values("nv1", "1111")
insert into NhanVien values("nv1", "dTrung", "0123456978", "2024/12/12", 1, "abc@gmail.com", 1, "ql")


--sinh vé lượt theo kích thước bãi xe
create procedure inVe as
begin
	declare @n int
	set @n = (select sum(soLuong) from BaiXe)
	print @n
	while @n > 0
	begin
		insert into VeLuot values(concat('VE', @n), 'VL','')
		set @n = @n-1
		--print concat('VE', @n)
	end
end
--sinh vé lượt nếu số lượng slot tăng


create procedure showNV as
begin
	SELECT 
    NhanVien.maNV, 
    NhanVien.hoTen, 
    ChucVu.tenCV, 
    NhanVien.SDT, 
    NhanVien.ngaySinh, 
		CASE 
			WHEN NhanVien.gioiTinh = 1 THEN 'Nam' 
			WHEN NhanVien.gioiTinh = 0 THEN 'Nữ' 
		END AS GioiTinh
	FROM 
		NhanVien 
	INNER JOIN 
		ChucVu 
	ON 
		NhanVien.maCV = ChucVu.maCV;
end
go


/*
create proc TaoHoaDon @mave varchar(10), @loaive varchar(10), @loaixe varchar(10), @bienso varchar(11)
as
	declare @tong int
	if @loaive in ('VL')
	begin
		if exists (select 1 from VeLuot where @mave = maVe)
		begin
			set @tong = (select gia from BangGia where maLoaiVe = 'VL' and @loaixe = maLoaiXe)
			
			insert into HoaDon values ("hd5", @bienso, "2024/12/12", "2024/12/12", @mave, @loaive, "nv1")
			print '-->' + STR(@tong)
		end
		else print 'Ma ve ko hop le'
	end
	else
	if @loaive in ('VT')
	begin
		if exists (select 1 from VeThang where @mave = maVe)
		begin
			--so sanh thời hạn
			
			insert into HoaDon values ("hd6", @bienso, "2024/12/12", "2024/12/12", @mave, @loaive, "nv1")
			print '-->' + STR(@tong)
		end
	end
go

exec TaoHoaDon 'VE2', 'VL', 'xe02', '28L1 11111'

drop proc TaoHoaDon

insert into HoaDon values ("hd1", "28L1 23127", "2024/12/12", "2024/12/12", "VE5", "VL", "nv1")
insert into HoaDon values ("hd4", "28L1 23127", "2024/12/12", "2024/12/12", "VE4", "VL", "nv3")
*/