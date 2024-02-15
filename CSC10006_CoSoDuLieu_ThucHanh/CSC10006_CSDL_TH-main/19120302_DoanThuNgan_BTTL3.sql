--Q1. CHO BIẾT HỌ TÊN VÀ MỨC LƯƠNG GV NỮ

SELECT HOTEN,LUONG
FROM GIAOVIEN
WHERE PHAI=N'NỮ'

--Q2 CHO BIẾT HỌ TÊN, LUONG CỦA HỌ SAU KHI TĂNG 10%
SELECT HOTEN,LUONG*1.1 AS LUONG_SAU_TANG
FROM GIAOVIEN

--Q3 CHO BIẾT MÃ CỦA GIÁO VIÊN CÓ
--    + HỌ TÊN BẮT ĐẦU LÀ NGUYỄN VÀ LƯƠNG TRÊN 2000$
--    + HOẶC, GIÁO VIÊN LÀ TRƯỞNG BỘ MÔN NHẬN CHỨC SAU 1995

SELECT MAGV
FROM GIAOVIEN 
WHERE (HOTEN LIKE N'Nguyễn%' AND LUONG > 2000) 
UNION
SELECT MAGV
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MAGV=BM.TRUONGBM
WHERE YEAR(BM.NGAYNHANCHUC) > 1995

-- Ở đây, ta dùng cú pháp UNION
-- Toán tử UNION được dùng để kết hợp 2 bộ kết quả từ 2 hoặc nhiều lệnh SELECT. Nó sẽ xóa các hàng trùng trong các lệnh SELECT này.

--Q4: CHO BIẾT TÊN NHỮNG GIÁO VIÊN KHOA CÔNG NGHỆ THÔNG TIN

SELECT GV.HOTEN
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MABM=BM.MABM 
JOIN KHOA K ON BM.MAKHOA=K.MAKHOA
WHERE K.TENKHOA=N'CÔNG NGHỆ THÔNG TIN'

-- Ở đây, ta dùng JOIN ON 2 lần
-- Bởi vì, nếu ta chỉ JOIN với bảng BOMON mà tìm theo 'CNTT' là sai, vì tìm Công nghệ thông tin (ở bảng KHOA) mới đúng

--Q5: Cho  biết  thông  tin  của  bộ  môn  cùng  thông  tin  giảng  viên  làm  trưởng  bộ  môn  đó.

SELECT*
FROM BOMON BM LEFT JOIN GIAOVIEN GV ON BM.TRUONGBM=GV.MAGV

-- Ở đây, ta dùng LEFT JOIN
-- LEFT JOIN là: mọi bản ghi bảng bên trái được trả về, 
-- bản ghi nào phù hợp với bản ghi bên phải thì nó được bổ sung thêm dữ liệu từ bản ghi bảng bên phải (nếu không có thì nhận NULL)
-- Bởi vì, nếu ta chỉ JOIN thì đối với những bộ môn không có trưởng bộ môn sẽ không hiển thị

--Q6: Với  mỗi  giáo  viên,  hãy  cho  biết  thông  tin  của  bộ  môn  mà  họ  đang  làm  việc. 

SELECT*
FROM GIAOVIEN GV LEFT JOIN BOMON BM ON GV.MABM=BM.MABM

--Q7: Cho biết tên đề tài và GVCN đề tài
SELECT DT.TENDT, GV.HOTEN
FROM DETAI DT JOIN GIAOVIEN GV ON DT.GVCNDT=GV.MAGV

--Q8: Với mỗi khoa, cho biết thông tin trưởng khoa

SELECT *
FROM KHOA K LEFT JOIN GIAOVIEN GV ON K.TRUONGKHOA=GV.MAGV

--Q9: Cho biết các giáo viên của bộ môn Vi Sinh, có tham gia đề tài 006
SELECT *
FROM GIAOVIEN GV LEFT JOIN BOMON BM ON GV.MABM=BM.MABM JOIN THAMGIADT TGDT ON GV.MAGV=TGDT.MAGV
WHERE BM.TENBM=N'Vi Sinh' AND TGDT.MADT='006'

--Q10: Với những đề tài thuộc cấp quản lý “Thành phố”, cho biết mã đề tài, đề tài thuộc về chủ đề nào, 
--họ tên người chủ nhiệm đề tài cùng với ngày sinh và địa chỉ của người ấy.

SELECT DT.MADT, CD.TENCD, GV.HOTEN as N'Tên Chủ Nhiệm Đề Tài', GV.NGSINH, GV.DIACHI
FROM DETAI DT JOIN CHUDE CD ON DT.MACD=CD.MACD JOIN GIAOVIEN GV ON DT.GVCNDT=GV.MAGV
WHERE DT.CAPQL=N'Thành phố'

--Q11: Tìm họ tên của từng giáo viên và người phụ trách chuyên môn trực tiếp của giáo viên đó
SELECT GV.HOTEN, GV1.HOTEN AS N'HỌ TÊN NGƯỜI PHỤ TRÁCH CHUYÊN MÔN'
FROM GIAOVIEN GV LEFT JOIN GIAOVIEN GV1 ON GV.GVQLCM=GV1.MAGV

--Q12: Tìm họ tên của những giáo viên được“Nguyễn Thanh Tùng” phụ trách trực tiếp.
SELECT GV.HOTEN
FROM GIAOVIEN GV JOIN GIAOVIEN GV1 ON GV.GVQLCM=GV1.MAGV
WHERE GV1.HOTEN = N'Nguyễn Thanh Tùng'

--Q13: Cho biết tên giáo viên là trưởng bộ môn Hệ thống thông tin.

SELECT GV.HOTEN
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MAGV=BM.TRUONGBM
WHERE BM.TENBM=N'Hệ thống thông tin'

-- Q14. Cho biết tên người chủ nhiệm đề tài của những đề tài thuộc chủ đề Quản lý giáo dục. 
SELECT HOTEN
FROM GIAOVIEN GV JOIN DETAI DT ON GV.MAGV=DT.GVCNDT JOIN CHUDE CD ON DT.MACD=CD.MACD
WHERE CD.TENCD=N'Quản lý giáo dục'

--Q15. Cho biết tên các công việc của đề tài HTTT quản lý các trường ĐH có thời gian bắt đầu trong tháng  3/2008. 
SELECT CV.TENCV
FROM CONGVIEC CV JOIN DETAI DT ON CV.MADT=DT.MADT
WHERE DT.TENDT=N'HTTT quản lý các trường ĐH' AND (CV.NGAYBD > '2008-03-01' AND CV.NGAYBD <'2008-03-31')

-- Q16. Cho biết tên giáo viên và tên người quản lý chuyên môn của giáo viên đó. 
SELECT GV.HOTEN, GV1.HOTEN AS N'HỌ TÊN NGƯỜI QUÁN LÝ CHUYÊN MÔN'
FROM GIAOVIEN GV LEFT JOIN GIAOVIEN GV1 ON GV.GVQLCM=GV1.MAGV

-- Q17. Cho các công việc bắt đầu trong khoảng từ 01/01/2007 đến 01/08/2007. 
SELECT*
FROM CONGVIEC CV
WHERE (CV.NGAYBD > '2007-01-01' AND CV.NGAYBD <'2007-08-01')

-- Q18. Cho biết họ tên các giáo viên cùng bộ môn với giáo viên “Trần Trà Hương”. 
SELECT GV.HOTEN
FROM GIAOVIEN GV JOIN GIAOVIEN GV1 ON GV.MABM=GV1.MABM
WHERE GV1.HOTEN=N'Trần Trà Hương' AND GV.HOTEN<>N'Trần Trà Hương'

--Q19. Tìm những giáo viên vừa là trưởng bộ môn vừa chủ nhiệm đề tài. 
SELECT DISTINCT *
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MAGV=BM.TRUONGBM JOIN DETAI DT ON GV.MAGV= DT.GVCNDT

--Q20. Cho biết tên những giáo viên vừa là trưởng khoa và vừa là trưởng bộ môn. 
SELECT DISTINCT GV.HOTEN
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MAGV=BM.TRUONGBM JOIN KHOA K ON GV.MAGV= K.TRUONGKHOA

--Q21. Cho biết tên những trưởng bộ môn mà vừa chủ nhiệm đề tài  
SELECT DISTINCT GV.HOTEN
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MAGV=BM.TRUONGBM JOIN DETAI DT ON GV.MAGV= DT.GVCNDT

--Q22. Cho biết mã số các trưởng khoa có chủ nhiệm đề tài. 
SELECT DISTINCT GV.MAGV
FROM GIAOVIEN GV JOIN KHOA K ON GV.MAGV=K.TRUONGKHOA JOIN DETAI DT ON GV.MAGV= DT.GVCNDT

--Q23. Cho biết mã số các giáo viên thuộc bộ môn HTTT hoặc có tham gia đề tài mã 001. 
SELECT DISTINCT GV.MAGV
FROM GIAOVIEN GV,BOMON BM,THAMGIADT TGDT
WHERE  GV.MABM=BM.MABM AND BM.MABM='HTTT' 
OR
GV.MAGV=TGDT.MAGV AND TGDT.MADT='001'

--Q24. Cho biết giáo viên làm việc cùng bộ môn với giáo viên 002. 
SELECT GV.*
FROM GIAOVIEN GV JOIN GIAOVIEN GV1 ON GV.MABM=GV1.MABM
WHERE GV1.MAGV='002' AND GV.MAGV <> '002'

--Q25. Tìm những giáo viên là trưởng bộ môn. 
SELECT*
FROM GIAOVIEN GV JOIN BOMON BM ON GV.MAGV=BM.TRUONGBM
--Q26. Cho biết họ tên và mức lương của các giáo viên. 

SELECT HOTEN,LUONG
FROM GIAOVIEN
