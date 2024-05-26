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
	[maNV] Char(10) NOT NULL,
	[hoTen] Nvarchar(30) NOT NULL,
	[SDT] Char(11) NOT NULL,
	[ngaySinh] Datetime NOT NULL,
	[gioiTinh] Bit NOT NULL,
	[email] Char(20) NOT NULL,
	[maTK] Char(10) NOT NULL,
	[maCV] Char(10) NOT NULL,
Primary Key ([maNV])
) 
go

Create table [TaiKhoan]
(
	[maTK] Char(10) NOT NULL,
	[tenDangNhap] Char(10) NOT NULL,
	[matKhau] Char(20) NOT NULL,
Primary Key ([maTK])
) 
go

Create table [Xe]
(
	[bienSo] Char(15) NOT NULL,
	[maLoaiXe] Char(10) NOT NULL,
	[maKH] Char(10) NOT NULL,
Primary Key ([bienSo])
) 
go

Create table [LoaiXe]
(
	[maLoaiXe] Char(10) NOT NULL,
	[tenXe] Nvarchar(15) NOT NULL,
	[maBaiXe] Char(10) NOT NULL,
Primary Key ([maLoaiXe])
) 
go

Create table [LoaiVe]
(
	[maLoaiVe] Char(10) NOT NULL,
	[tenLoai] Nvarchar(10) NOT NULL,
Primary Key ([maLoaiVe])
) 
go

Create table [VeLuot]
(
	[maVe] Char(10) NOT NULL,
	[maLoaiVe] Char(10) NOT NULL,
	[bienSo] Char(10) NULL,
Primary Key ([maVe])
) 
go

Create table [KhachHang]
(
	[maKH] Char(10) NOT NULL,
	[hoTen] Nvarchar(30) NOT NULL,
	[SDT] Char(11) NOT NULL,
	[gioiTinh] Bit NOT NULL,
	[diaChi] Nvarchar(20) NOT NULL,
Primary Key ([maKH])
) 
go

Create table [BangGia]
(
	[maLoaiXe] Char(10) NOT NULL,
	[maLoaiVe] Char(10) NOT NULL,
	[gia] Integer NOT NULL,
Primary Key ([maLoaiXe],[maLoaiVe])
) 
go

Create table [VeThang]
(
	[maVe] Char(10) NOT NULL,
	[bienSo] Char(15) NOT NULL,
	[maLoaiVe] Char(10) NOT NULL,
	[thoiHan] Datetime NOT NULL,
	[maKH] Char(10) NOT NULL,
Primary Key ([maVe])
) 
go

Create table [HoaDon]
(
	[maHD] int identity(1,1) NOT NULL,
	[tgVao] Datetime NOT NULL,
	[tgRa] Datetime NULL,
	[maVe] Char(10) NOT NULL,
	[maLoaiVe] Char(10) NOT NULL,
	[maNV] Char(10) NOT NULL,
	[maLoaiXe] Char(10) NOT NULL,
Primary Key ([maHD])
) 
go

Create table [BaiXe]
(
	[maBaiXe] Char(10) NOT NULL,
	[soLuong] Integer NOT NULL,
	[tenBai] Nvarchar(20) NOT NULL,
Primary Key ([maBaiXe])
) 
go

Create table [ChucVu]
(
	[maCV] Char(10) NOT NULL,
	[tenCV] Nvarchar(15) NOT NULL,
Primary Key ([maCV])
) 
go

Create table [GiaQuaDem]
(
	[gia] Integer NOT NULL,
	[maLoaiXe] Char(10) NOT NULL,
Primary Key ([maLoaiXe])
) 
go


Alter table [HoaDon] add  foreign key([maNV]) references [NhanVien] ([maNV])  on update no action on delete no action 
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



insert into BaiXe values("bx01", 100, "Bai xe may")
insert into BaiXe values("bx02", 100, "Bai xe o to")
insert into BaiXe values("bx03", 100, "Bai xe khach")

insert into LoaiXe values("xe01", "xe may", "bx01")
insert into LoaiXe values("xe02", "xe oto", "bx02")
insert into LoaiXe values("xe03", "xe khach", "bx03")

insert into HoaDon values("14:19:00", NULL, "VE1", "VL", "nv1", "xe01")
insert into HoaDon values("14:19:00", NULL, "VE10", "VL", "nv1", "xe02")
insert into HoaDon values("14:19:00", NULL, "VE100", "VL", "nv1", "xe03")

insert into LoaiVe values("VL", "Ve luot")
insert into LoaiVe values("VT", "Ve thang")

insert into GiaQuaDem values(10000, "xe01")
insert into GiaQuaDem values(20000, "xe02")
insert into GiaQuaDem values(30000, "xe03")

insert into BangGia values("xe01", "VL", 5000)
insert into BangGia values("xe01", "VT", 150000)
insert into BangGia values("xe02", "VL", 20000)
insert into BangGia values("xe02", "VT", 350000)
insert into BangGia values("xe03", "VL", 30000)
insert into BangGia values("xe03", "VT", 500000)

insert into KhachHang values("KH1", "dang duc trung", "0123456789", 1, "hoa binh")
insert into Xe values("28L1 23127", "xe01", "KH1")
insert into Xe values("28L1 3427", "xe01", "KH1")

insert into VeLuot values("VE1","VL", "28L1 11111")
insert into VeLuot values("VE2", "VL", "28L1 23127")
insert into VeThang values("VT1", "28L1 23127", "VT", "2024/12/12", "KH1")
insert into VeThang values("VT2", "28L1 3427", "VT", "2024/12/12", "KH1")

insert into ChucVu values("nv", "Nhan vien")
insert into ChucVu values("ql", "Quan ly")

insert into TaiKhoan values("tk1", "admin", "1111")
insert into NhanVien values("nv1", "dTrung", "0123456978", "2024/12/12", 1, "abc@gmail.com", "tk1", "ql")

select * from HoaDon
select * from VeLuot
select * from BaiXe
select * from Xe
select * from LoaiVe
select * from LoaiXe
select * from VeThang
select * from NhanVien

--Tao ham lay ve xe
CREATE FUNCTION getVeXe()
RETURNS @ResultTable TABLE (maVe CHAR(10))
AS
BEGIN
    INSERT INTO @ResultTable (maVe)
    SELECT TOP 1 maVe
    FROM VeLuot
    WHERE bienSo = '';

    RETURN;
END;

SELECT * FROM dbo.getVeXe();

go


--sinh vé lượt theo kích thước bãi xe
declare @n int
set @n = (select sum(soLuong) from BaiXe)
print @n
while @n > 0
begin

	insert into VeLuot values(concat('VE', @n), 'VL','')

	set @n = @n-1
	print concat('VE', @n)
end

/*
create proc TaoHoaDon @mave char(10), @loaive char(10), @loaixe char(10), @bienso char(11)
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