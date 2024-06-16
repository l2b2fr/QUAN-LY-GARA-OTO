-- Tạo cơ sở dữ liệu cho quản lý gara ô tô
CREATE DATABASE QUAN_LY_GARA_OTO
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE QUAN_LY_GARA_OTO
GO

CREATE TABLE [tb_Users] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[user] NVARCHAR(255),
	[password] NVARCHAR(255),
	[permission] NVARCHAR(255),
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_KhachHang] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[name] NVARCHAR(255),
	[phone] NVARCHAR(255) UNIQUE,
	[email] NVARCHAR(255) UNIQUE,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_PhuongTien] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[idKhachHang] INT,
	[carBrand] NVARCHAR(255),
	[carNumberPlates] NVARCHAR(255),
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_TiepNhanXeSua] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[idPhuongTien] INT,
	[dayReception] DATE,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_PhieuSuaChua] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[idTiepNhanXeSua] INT,
	[idSoLuongVatTuPhuTung] INT,
	[idCongViec] INT,
	[totalCost] DECIMAL,
	[amountPaid] DECIMAL,
	[debt] DECIMAL,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_VatTuPhuTung] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[spareParts] NVARCHAR(255),
	[unitPrice] DECIMAL,
	[unitType] NVARCHAR(255),
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_CongViec] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[content] NVARCHAR(255),
	[laborCost] DECIMAL,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_QuanLyKho] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[idVatTuPhuTung] INT,
	[beginningInventory] INT,
	[netChange] INT,
	[endingInventory] INT,
	[month] DATE,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_SoLuongVatTuPhuTung] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[idVatTuPhuTung] INT,
	[quantity] INT,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_RestrictedList] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[vehicleBrandLimit] INT,
	[carLimit] INT,
	[materialLimit] INT,
	[workLimit] INT,
	PRIMARY KEY([id])
);
GO

ALTER TABLE [tb_PhuongTien]
ADD FOREIGN KEY([idKhachHang]) REFERENCES [tb_KhachHang]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_TiepNhanXeSua]
ADD FOREIGN KEY([idPhuongTien]) REFERENCES [tb_PhuongTien]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_PhieuSuaChua]
ADD FOREIGN KEY([idTiepNhanXeSua]) REFERENCES [tb_TiepNhanXeSua]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_PhieuSuaChua]
ADD FOREIGN KEY([idCongViec]) REFERENCES [tb_CongViec]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_QuanLyKho]
ADD FOREIGN KEY([idVatTuPhuTung]) REFERENCES [tb_VatTuPhuTung]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_SoLuongVatTuPhuTung]
ADD FOREIGN KEY([idVatTuPhuTung]) REFERENCES [tb_VatTuPhuTung]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_PhieuSuaChua]
ADD FOREIGN KEY([idSoLuongVatTuPhuTung]) REFERENCES [tb_SoLuongVatTuPhuTung]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO

-- Thêm các tài khoản quản trị vào bảng tb_Admin
INSERT INTO [tb_Users] ([user], [password], [permission])
VALUES ('admin', '123456', 'ADMIN'),
       ('leminhnam', '123456', 'NHÂN VIÊN'),
       ('dothithom', '123456', 'NHÂN VIÊN'),
       ('phamthuyquynh', '123456', 'NHÂN VIÊN');
GO

-- Thêm dữ liệu vào bảng tb_RestrictedList
INSERT INTO [tb_RestrictedList] ([vehicleBrandLimit], [carLimit], [materialLimit], [workLimit])
VALUES 
(10, 30, 200, 100)
GO

-- -- Thêm dữ liệu vào bảng tb_VatTuPhuTung với 200 mục, mỗi mục có giá và loại ngẫu nhiên
-- DECLARE @i INT = 1
-- WHILE @i <= 200
-- BEGIN
--     INSERT INTO [tb_VatTuPhuTung] ([spareParts], [unitPrice], [unitType])
--     VALUES (N'Vật tư ' + CAST(@i AS NVARCHAR(10)), RAND() * 1000000, N'Loại ' + CAST((@i % 10 + 1) AS NVARCHAR(10)))
--     SET @i = @i + 1
-- END
-- GO

-- -- Thêm dữ liệu vào bảng tb_CongViec với 100 công việc, mỗi công việc có chi phí lao động ngẫu nhiên
-- DECLARE @j INT = 1
-- WHILE @j <= 100
-- BEGIN
--     INSERT INTO [tb_CongViec] ([content], [laborCost])
--     VALUES (N'Công việc ' + CAST(@j AS NVARCHAR(10)), RAND() * 500000)
--     SET @j = @j + 1
-- END
-- GO

-- -- Thêm dữ liệu vào bảng tb_QuanLyKho với 200 mục, mỗi mục có số lượng tồn đầu, thay đổi và tồn cuối tính toán dựa trên số ngẫu nhiên
-- DECLARE @k INT = 1
-- WHILE @k <= 200
-- BEGIN
--     DECLARE @beginningInventory INT = ROUND(RAND() * 1000, 0)
--     DECLARE @netChange INT = ROUND((RAND() * 200 - 100), 0)
--     DECLARE @endingInventory INT = @beginningInventory + @netChange
--     DECLARE @month DATE = DATEADD(MONTH, @k % 12, '2024-01-01')

--     INSERT INTO [tb_QuanLyKho] ([idVatTuPhuTung], [beginningInventory], [netChange], [endingInventory], [month])
--     VALUES (@k, @beginningInventory, @netChange, @endingInventory, @month)
    
--     SET @k = @k + 1
-- END
-- GO
