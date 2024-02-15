USE QL_DETAI
GO

--CAU 2: SPXOAGV
 CREATE PROC SPXoaGV @MAGV NVARCHAR(5)
 AS
 --Kiểm	tra	mã giáo	viên phải tồn tại --nếu không in	lỗi	“Giáo viên không tồn tại”	IF (NOT EXISTS(SELECT*FROM GIAOVIEN GV WHERE GV.MAGV=@MAGV))	BEGIN		RAISERROR(N'GIÁO VIÊN KHÔNG TỒN TẠI',16,1)		RETURN	END	--Kiểm	tra	giáo viên có phải trưởng khoa	BEGIN 		UPDATE KHOA 		SET TRUONGKHOA=NULL, NGAYNHANCHUC=NULL		WHERE TRUONGKHOA=@MAGV;	END	--Kiểm	tra	giáo viên có phải trưởng bộ môn	BEGIN 		UPDATE BOMON 		SET TRUONGBM=NULL, NGAYNHANCHUC=NULL		WHERE TRUONGBM=@MAGV;	END	--Kiểm	tra	giáo viên có quản lý giáo viên khác hay không	BEGIN 		UPDATE GIAOVIEN		SET GVQLCM=NULL		WHERE GVQLCM=@MAGV;	END	--Kiểm	tra	giáo viên có chủ nhiệm đề tài hay không	BEGIN 		UPDATE DETAI		SET GVCNDT=NULL		WHERE GVCNDT=@MAGV;	END	--Kiểm tra giáo viên có tham gia thực hiện đề tài nào không, nếu có xoá các tham gia này	BEGIN 		DELETE		FROM THAMGIADT		WHERE MAGV=@MAGV;	END	-- Xoá điện thoại	BEGIN		DELETE		FROM GV_DT		WHERE MAGV=@MAGV;	END	--Xoá thân nhân	BEGIN		DELETE		FROM NGUOITHAN		WHERE MAGV=@MAGV;	END	--Xoá giáo viên			DELETE		FROM GIAOVIEN		WHERE MAGV=@MAGV		PRINT N'XOÁ THÀNH CÔNG'GOEXEC SPXOAGV '001'-- CAU 3: spCapNhatTruongBoMonCREATE PROC spCapNhatTruongBoMon @MAGV NVARCHAR(5),@MABM NVARCHAR(5),@NGAYNHANCHUC DATEAS	 --Kiểm	tra	mã giáo	viên phải tồn tại	IF (NOT EXISTS(SELECT*FROM GIAOVIEN GV WHERE GV.MAGV=@MAGV))		RETURN -1	 --Kiểm	tra	mã bộ môn phải tồn tại	IF (NOT EXISTS(SELECT*FROM BOMON BM WHERE BM.MABM=@MABM))		RETURN -2	--Kiểm tra giáo	viên có thuộc bộ môn mình sẽ làm trưởng	IF (EXISTS(SELECT*FROM GIAOVIEN GV WHERE GV.MABM!=@MABM and GV.MAGV=@MAGV))		RETURN -3
	--Kiểm tra giáo	viên có	phải là	trưởng	khoa	IF (EXISTS(SELECT*FROM KHOA K WHERE K.TRUONGKHOA=@MAGV))		RETURN -4	--Kiểm tra tuổi	giáo Viên có Phù hợp	IF((SELECT (YEAR(@NGAYNHANCHUC) - YEAR(GV.NGSINH)) FROM GIAOVIEN GV WHERE GV.MAGV=@MAGV) <=22)		RETURN -5	--Nếu hợp lệ thì cập nhật thông tin trưởng bộ môn, ngày nhận chức	UPDATE BOMON	SET TRUONGBM=@MAGV, NGAYNHANCHUC=@NGAYNHANCHUC	WHERE MABM=@MABM	RETURN 1GO--DECLARE @KQ INTEXEC @KQ=spCapNhatTruongBoMon '002','HTTT','09/09/2021'print @KQ	
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
