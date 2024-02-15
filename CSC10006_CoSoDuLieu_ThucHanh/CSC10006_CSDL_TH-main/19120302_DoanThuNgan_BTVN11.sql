﻿USE QL_DETAI
GO

--CAU 2: SPXOAGV
 CREATE PROC SPXoaGV @MAGV NVARCHAR(5)
 AS
 --Kiểm	tra	mã giáo	viên phải tồn tại
	--Kiểm tra giáo	viên có	phải là	trưởng	khoa
-- CAU 4: SPTHEMCONGVIEC
 create proc spThemCongViec @MADT char(3), @TENCV NVARCHAR(40), @NGAYBD DATE, @NGAYKT DATE
 AS
 --kiem tra de tai ton tai
 --Neu khong in loi "De tai khong ton tai"
	IF (NOT EXISTS(SELECT*FROM DETAI DT WHERE DT.MADT=@MADT))
	BEGIN
	RAISERROR(N'Đề tài không tồn tại',16,1)
	RETURN
	END

--Kiem tra ngay bat dau phải nhỏ hơn ngày kết thúc
--Nếu không, in lỗi "Ngày bắt đầu phải nhỏ hơn ngày kết thúc"
	IF(@NGAYBD >= @NGAYKT)
	BEGIN
	RAISERROR(N'Ngày bắt đầu phải nhỏ hơn ngày kết thúc',16,1)
	RETURN 
	END

--Kiểm tra ngày bắt đầu phải lớn hơn ngày hiện hành
--Nếu không in lỗi "Ngày bắt đầu phải lớn hơn ngày hiện hành"
	IF(@NGAYBD <=GETDATE())
	BEGIN
	RAISERROR(N'Ngày bắt đầu phải lớn hơn ngày hiện hành',16,1)
	RETURN 
	END

--Kiểm tra đề tài có đủ 10 công việc chưa
--Nếu đã đủ in lỗi "Vượt quá số công việc tối đa cho đề tài"
	IF((SELECT COUNT(*) FROM CONGVIEC WHERE MADT=@MADT) >=10)
	BEGIN
	RAISERROR(N'Vượt quá số công việc tối đa cho đề tài',16,1)
	RETURN
	END

-- Nếu các kiểm tra hợp lệ, thêm thông tin vào CongViec và in thông báo "Thêm thành công"
	DECLARE @STT INT
	SET @STT=(SELECT MAX(CV.SOTT) FROM CONGVIEC CV WHERE CV.MADT=@MADT) + 1

	INSERT INTO CONGVIEC(MADT,SOTT,TENCV,NGAYBD,NGAYKT)
	VALUES (@MADT,@STT,@TENCV,@NGAYBD,@NGAYKT)
	PRINT N'THÊM THÀNH CÔNG'
GO
EXEC spThemCongViec '001',N'SOAN THAO','06/29/2021','09/09/2021'