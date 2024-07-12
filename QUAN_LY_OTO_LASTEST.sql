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
	[phone] NVARCHAR(255),
	[email] NVARCHAR(255),
	[address] NVARCHAR(255),
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
	[totalCost] DECIMAL,
	[amountPaid] DECIMAL,
	[debt] DECIMAL,
	PRIMARY KEY([id])
);
GO

CREATE TABLE [tb_SuaChua] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[idTiepNhanXeSua] INT,
	[idSoLuongVatTuPhuTung] INT,
	[idCongViec] INT,
	[intoMoney] DECIMAL,
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

CREATE TABLE [tb_CarBrand] (
	[id] INT NOT NULL IDENTITY UNIQUE,
	[name] NVARCHAR(255),
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
ALTER TABLE [tb_SuaChua]
ADD FOREIGN KEY([idTiepNhanXeSua]) REFERENCES [tb_TiepNhanXeSua]([id])
ON UPDATE CASCADE ON DELETE CASCADE;
GO
ALTER TABLE [tb_SuaChua]
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
ALTER TABLE [tb_SuaChua]
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

-- Thêm các hãng xe vào bảng tb_CarBrand
INSERT INTO tb_CarBrand (name) 
VALUES 
    ('Toyota'),
    ('Volkswagen'),
    ('Ford'),
    ('Chevrolet'),
    ('Honda'),
    ('Nissan'),
    ('BMW'),
    ('Mercedes-Benz'),
    ('Audi'),
    ('Hyundai');

INSERT INTO [tb_VatTuPhuTung] ([spareParts], [unitPrice], [unitType])
VALUES
(N'Dầu động cơ', 150000, N'Lit'),
(N'Lốp xe', 800000, N'Cái'),
(N'Phanh đĩa', 400000, N'Cái'),
(N'Bugi', 50000, N'Cái'),
(N'Dung dịch làm mát', 100000, N'Lit'),
(N'Lọc gió', 70000, N'Cái'),
(N'Lọc dầu', 60000, N'Cái'),
(N'Ắc quy', 1200000, N'Cái'),
(N'Dây curoa', 300000, N'Cái'),
(N'Đèn pha', 200000, N'Cái'),
(N'Gạt nước', 100000, N'Bộ'),
(N'Lọc nhiên liệu', 50000, N'Cái'),
(N'Má phanh', 300000, N'Bộ'),
(N'Dầu hộp số', 250000, N'Lit'),
(N'Cảm biến oxy', 400000, N'Cái'),
(N'Bơm nước', 600000, N'Cái'),
(N'Van hằng nhiệt', 200000, N'Cái'),
(N'Ống dẫn nhiên liệu', 100000, N'M'),
(N'Cảm biến nhiệt độ', 150000, N'Cái'),
(N'Mô tơ quạt', 450000, N'Cái'),
(N'Giảm chấn', 350000, N'Cái'),
(N'Bộ lọc khí thải', 500000, N'Cái'),
(N'Bộ điều hòa không khí', 700000, N'Cái'),
(N'Bơm nhiên liệu', 600000, N'Cái'),
(N'Bộ điều khiển phanh ABS', 900000, N'Cái'),
(N'Bơm phanh ABS', 800000, N'Cái'),
(N'Bộ làm mát dầu', 500000, N'Cái'),
(N'Bộ lọc dầu động cơ', 60000, N'Cái'),
(N'Bộ lọc dầu hộp số', 70000, N'Cái'),
(N'Cảm biến áp suất', 300000, N'Cái'),
(N'Cảm biến lưu lượng khí', 250000, N'Cái'),
(N'Bộ lọc gió điều hòa', 50000, N'Cái'),
(N'Bình nhiên liệu', 1200000, N'Cái'),
(N'Cảm biến vị trí bướm ga', 400000, N'Cái'),
(N'Cảm biến áp suất dầu', 300000, N'Cái'),
(N'Cảm biến nhiệt độ nước làm mát', 200000, N'Cái'),
(N'Cảm biến lưu lượng khí nạp', 250000, N'Cái'),
(N'Cảm biến oxy trước', 450000, N'Cái'),
(N'Cảm biến oxy sau', 450000, N'Cái'),
(N'Bộ điều khiển động cơ', 900000, N'Cái'),
(N'Bộ điều khiển hộp số', 800000, N'Cái'),
(N'Cảm biến vị trí trục cam', 300000, N'Cái'),
(N'Cảm biến tốc độ xe', 350000, N'Cái'),
(N'Cảm biến vị trí trục khuỷu', 300000, N'Cái'),
(N'Cảm biến nhiệt độ khí nạp', 200000, N'Cái'),
(N'Cảm biến vị trí chân ga', 350000, N'Cái'),
(N'Bộ điều khiển túi khí', 750000, N'Cái'),
(N'Bộ điều khiển hệ thống treo', 700000, N'Cái'),
(N'Cảm biến gia tốc', 250000, N'Cái'),
(N'Cảm biến áp suất khí nạp', 300000, N'Cái'),
(N'Cảm biến áp suất dầu hộp số', 400000, N'Cái'),
(N'Cảm biến nhiệt độ dầu hộp số', 300000, N'Cái'),
(N'Cảm biến áp suất nhiên liệu', 400000, N'Cái'),
(N'Cảm biến lưu lượng nhiên liệu', 350000, N'Cái'),
(N'Cảm biến áp suất phanh', 450000, N'Cái'),
(N'Cảm biến tốc độ trục truyền động', 350000, N'Cái'),
(N'Cảm biến vị trí tay số', 300000, N'Cái'),
(N'Cảm biến nhiệt độ dầu động cơ', 250000, N'Cái'),
(N'Cảm biến nhiệt độ nước làm mát động cơ', 250000, N'Cái'),
(N'Cảm biến áp suất dầu nhiên liệu', 450000, N'Cái'),
(N'Cảm biến vị trí van điều khiển', 500000, N'Cái'),
(N'Bộ điều khiển áp suất dầu', 550000, N'Cái'),
(N'Bộ điều khiển phanh tay điện tử', 600000, N'Cái'),
(N'Cảm biến vị trí bàn đạp phanh', 350000, N'Cái'),
(N'Cảm biến vị trí tay lái', 400000, N'Cái'),
(N'Bộ điều khiển hệ thống phanh ABS', 750000, N'Cái'),
(N'Cảm biến nhiệt độ khí thải', 450000, N'Cái'),
(N'Bộ điều khiển phanh', 800000, N'Cái'),
(N'Cảm biến lưu lượng khí động cơ', 300000, N'Cái'),
(N'Cảm biến lưu lượng khí thải', 400000, N'Cái'),
(N'Cảm biến nhiệt độ dầu', 500000, N'Cái'),
(N'Cảm biến nhiệt độ khí nạp', 350000, N'Cái'),
(N'Cảm biến áp suất lốp', 250000, N'Cái'),
(N'Cảm biến vị trí trục lái', 300000, N'Cái'),
(N'Cảm biến nhiệt độ nước làm mát', 200000, N'Cái'),
(N'Cảm biến nhiệt độ khí', 150000, N'Cái'),
(N'Cảm biến áp suất khí', 300000, N'Cái'),
(N'Cảm biến lưu lượng khí thải', 350000, N'Cái'),
(N'Cảm biến nhiệt độ dầu động cơ', 400000, N'Cái'),
(N'Bộ điều khiển cảm biến', 450000, N'Cái'),
(N'Cảm biến nhiệt độ lưu lượng khí', 500000, N'Cái'),
(N'Cảm biến áp suất khí động cơ', 350000, N'Cái'),
(N'Cảm biến nhiệt độ lưu lượng khí động cơ', 300000, N'Cái'),
(N'Cảm biến áp suất khí thải', 400000, N'Cái'),
(N'Cảm biến nhiệt độ lưu lượng khí thải', 350000, N'Cái'),
(N'Cảm biến áp suất dầu động cơ', 300000, N'Cái'),
(N'Cảm biến nhiệt độ lưu lượng dầu động cơ', 450000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí', 500000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất khí', 550000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí', 600000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu', 650000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu', 700000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí thải', 750000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất khí thải', 800000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ lưu lượng khí thải', 850000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng dầu', 900000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu nhiên liệu', 950000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ nước làm mát', 1000000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng dầu động cơ', 1050000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu hộp số', 1100000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu hộp số', 1150000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí nạp', 1200000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất khí nạp', 1250000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí nạp', 1300000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí động cơ', 1350000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu động cơ', 1400000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng dầu động cơ', 1450000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu nhiên liệu', 1500000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu nhiên liệu', 1550000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí nhiên liệu', 1600000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí nạp', 1650000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất khí thải động cơ', 1700000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí thải động cơ', 1750000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu hộp số', 1800000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu hộp số', 1850000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng dầu hộp số', 1900000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu nhiên liệu', 1950000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu nhiên liệu', 2000000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí nhiên liệu', 2050000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí nạp', 2100000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất khí nạp', 2150000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí động cơ', 2200000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí động cơ', 2250000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu động cơ', 2300000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng dầu động cơ', 2350000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu nhiên liệu', 2400000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu nhiên liệu', 2450000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí nhiên liệu', 2500000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí nạp', 2550000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất khí nạp', 2600000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí động cơ', 2650000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí động cơ', 2700000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu động cơ', 2750000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng dầu động cơ', 2800000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ dầu nhiên liệu', 2850000, N'Cái'),
(N'Bộ điều khiển cảm biến áp suất dầu nhiên liệu', 2900000, N'Cái'),
(N'Bộ điều khiển cảm biến lưu lượng khí nhiên liệu', 2950000, N'Cái'),
(N'Bộ điều khiển cảm biến nhiệt độ khí nạp', 3000000, N'Cái');



INSERT INTO [tb_CongViec] ([content], [laborCost])
VALUES
(N'Thay dầu động cơ', 500000),
(N'Kiểm tra và thay lốp xe', 700000),
(N'Kiểm tra phanh', 600000),
(N'Kiểm tra và thay bugi', 300000),
(N'Kiểm tra hệ thống làm mát', 400000),
(N'Thay lọc gió', 250000),
(N'Kiểm tra và nạp gas điều hòa', 450000),
(N'Kiểm tra hệ thống điện', 550000),
(N'Thay ắc quy', 650000),
(N'Thay dây curoa', 350000),
(N'Cân bằng lốp xe', 500000),
(N'Thay dầu hộp số', 750000),
(N'Thay dầu phanh', 550000),
(N'Kiểm tra và thay dây curoa cam', 700000),
(N'Thay lọc dầu', 200000),
(N'Kiểm tra và thay đèn pha', 150000),
(N'Kiểm tra hệ thống treo', 400000),
(N'Thay cần gạt nước', 100000),
(N'Thay lọc gió cabin', 200000),
(N'Kiểm tra và thay bugi đánh lửa', 250000),
(N'Thay bộ giảm xóc', 800000),
(N'Kiểm tra hệ thống lái', 450000),
(N'Kiểm tra và điều chỉnh cỡ lốp', 300000),
(N'Thay đĩa phanh', 700000),
(N'Thay má phanh', 500000),
(N'Thay thanh ổn định', 400000),
(N'Kiểm tra và thay xi lanh phanh', 600000),
(N'Kiểm tra và thay bơm nước', 550000),
(N'Thay van hằng nhiệt', 300000),
(N'Thay ống dẫn nhiên liệu', 450000),
(N'Kiểm tra và thay cảm biến ô-xy', 400000),
(N'Kiểm tra và thay dây đai', 250000),
(N'Thay đầu lọc nhiên liệu', 200000),
(N'Thay bộ lọc khí thải', 600000),
(N'Kiểm tra và thay bộ làm mát dầu', 700000),
(N'Kiểm tra và thay cảm biến nhiệt độ', 300000),
(N'Kiểm tra và thay mô tơ quạt', 400000),
(N'Thay bộ giảm chấn', 500000),
(N'Kiểm tra và thay bộ điều hòa không khí', 650000),
(N'Thay bộ lọc dầu hộp số', 200000),
(N'Thay bộ lọc dầu động cơ', 250000),
(N'Thay bộ lọc khí động cơ', 300000),
(N'Kiểm tra và thay cảm biến áp suất', 350000),
(N'Thay bộ lọc gió điều hòa', 150000),
(N'Kiểm tra và thay bình nhiên liệu', 700000),
(N'Thay bộ phận bơm nhiên liệu', 600000),
(N'Thay bộ phận điều khiển phanh ABS', 800000),
(N'Kiểm tra và thay bộ phận điều khiển túi khí', 750000),
(N'Thay bộ phận bơm phanh ABS', 500000),
(N'Thay bộ phận bơm phanh', 550000),
(N'Kiểm tra và thay bộ phận điều khiển động cơ', 700000),
(N'Thay bộ phận làm mát hộp số', 600000),
(N'Kiểm tra và thay bộ phận cảm biến vị trí bướm ga', 300000),
(N'Thay bộ phận cảm biến áp suất dầu', 400000),
(N'Thay bộ phận cảm biến nhiệt độ nước làm mát', 450000),
(N'Thay bộ phận cảm biến lưu lượng khí', 500000),
(N'Kiểm tra và thay bộ phận bơm nước làm mát', 650000),
(N'Thay bộ phận cảm biến nhiệt độ khí nạp', 350000),
(N'Thay bộ phận cảm biến lưu lượng không khí', 300000),
(N'Thay bộ phận cảm biến áp suất lốp', 250000),
(N'Kiểm tra và thay bộ phận cảm biến vị trí trục cam', 400000),
(N'Thay bộ phận cảm biến tốc độ xe', 450000),
(N'Kiểm tra và thay bộ phận cảm biến vị trí trục khuỷu', 500000),
(N'Thay bộ phận cảm biến khí thải', 650000),
(N'Thay bộ phận cảm biến oxy trước', 700000),
(N'Thay bộ phận cảm biến oxy sau', 750000),
(N'Kiểm tra và thay bộ phận cảm biến nhiệt độ dầu', 600000),
(N'Thay bộ phận cảm biến lưu lượng khí nạp', 650000),
(N'Thay bộ phận cảm biến nhiệt độ khí thải', 700000),
(N'Thay bộ phận cảm biến áp suất dầu nhiên liệu', 750000),
(N'Thay bộ phận cảm biến vị trí van điều khiển', 800000),
(N'Kiểm tra và thay bộ phận điều khiển áp suất dầu', 600000),
(N'Thay bộ phận điều khiển hộp số', 550000),
(N'Thay bộ phận điều khiển phanh tay điện tử', 500000),
(N'Thay bộ phận cảm biến vị trí bàn đạp phanh', 450000),
(N'Kiểm tra và thay bộ phận cảm biến vị trí tay lái', 400000),
(N'Thay bộ phận điều khiển hệ thống phanh ABS', 700000),
(N'Kiểm tra và thay bộ phận điều khiển hệ thống treo', 600000),
(N'Thay bộ phận cảm biến gia tốc', 300000),
(N'Thay bộ phận cảm biến tốc độ trục truyền động', 350000),
(N'Thay bộ phận cảm biến áp suất khí nạp', 400000),
(N'Kiểm tra và thay bộ phận cảm biến vị trí tay số', 450000),
(N'Thay bộ phận cảm biến áp suất dầu hộp số', 500000),
(N'Thay bộ phận cảm biến nhiệt độ dầu hộp số', 550000),
(N'Thay bộ phận cảm biến áp suất nhiên liệu', 600000),
(N'Thay bộ phận cảm biến nhiệt độ nước làm mát động cơ', 650000),
(N'Thay bộ phận cảm biến vị trí chân ga', 700000),
(N'Thay bộ phận cảm biến lưu lượng nhiên liệu', 750000),
(N'Thay bộ phận cảm biến áp suất phanh', 800000);

DECLARE @i INT = 1;

WHILE @i <= 138
BEGIN
    INSERT INTO [tb_QuanLyKho] ([idVatTuPhuTung], [beginningInventory], [netChange], [endingInventory], [month])
    VALUES (
        @i, 
        CAST(RAND() * 1000 AS INT), -- beginningInventory ngẫu nhiên từ 0 đến 1000
        CAST(RAND() * 200 - 100 AS INT), -- netChange ngẫu nhiên từ -100 đến 100
        CAST(RAND() * 1000 AS INT), -- endingInventory ngẫu nhiên từ 0 đến 1000
        DATEADD(MONTH, @i % 7, '2024-01-01') -- month ngẫu nhiên từ tháng 1 đến tháng 12 của năm 2023
    );
    SET @i = @i + 1;
END;
