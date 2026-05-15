CREATE DATABASE QuanLyTrungTamNgoaiNgu;
GO
USE QuanLyTrungTamNgoaiNgu;
GO

CREATE TABLE HocVien (
    MaHV INT IDENTITY(1,1) PRIMARY KEY,
    TenHV NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15),
    TrangThai NVARCHAR(50) DEFAULT N'Đang học'
);

-- Thêm 1 dòng dữ liệu mẫu để test
INSERT INTO HocVien (TenHV, SoDienThoai, TrangThai) 
VALUES (N'Nguyễn Văn A', '0901234567', N'Đang học');
