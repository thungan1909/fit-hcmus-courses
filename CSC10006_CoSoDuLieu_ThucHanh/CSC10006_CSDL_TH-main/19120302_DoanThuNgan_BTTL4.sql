--Q27:  Cho biết số lượng giáo viên viên và tổng lương của họ. 
SELECT COUNT(MAGV) AS N'SỐ LƯỢNG GIÁO VIÊN',SUM(LUONG) AS N'LƯƠNG'
FROM GIAOVIEN 
--Q28: Cho biết số lượng giáo viên và lương trung bình của từng bộ môn. 
SELECT GV.MABM, COUNT(GV.MAGV)AS N'SỐ LƯỢNG GIÁO VIÊN', AVG(GV.LUONG)AS N'LƯƠNG TRUNG BÌNH BỘ MÔN'
FROM GIAOVIEN GV
GROUP BY GV.MABM
--Q29: Cho biết tên chủ đề và số lượng đề tài thuộc về chủ đề đó.
SELECT CD.TENCD,COUNT(DT.MADT) AS N'SỐ LƯỢNG ĐỀ TÀI'
FROM CHUDE CD JOIN DETAI DT ON CD.MACD=DT.MACD
GROUP BY CD.TENCD, DT.MACD
--Q30: Cho biết tên giáo viên và số lượng đề tài mà giáo viên đó tham gia. 
SELECT GV.HOTEN AS N'HỌ TÊN GIÁO VIÊN',COUNT (DISTINCT TGDT.MADT) AS N'SỐ LƯỢNG ĐỀ TÀI GIÁO VIÊN ĐÓ THAM GIA'
FROM GIAOVIEN GV LEFT JOIN THAMGIADT TGDT ON GV.MAGV=TGDT.MAGV
GROUP BY GV.MAGV,GV.HOTEN
--Q31: Cho biết tên giáo viên và số lượng đề tài mà giáo viên đó làm chủ nhiệm. 
SELECT GV.HOTEN AS N'HỌ TÊN GIÁO VIÊN',COUNT (DISTINCT DT.MADT) AS N'SỐ LƯỢNG ĐỀ TÀI GIÁO VIÊN ĐÓ QUẢN LÝ'
FROM GIAOVIEN GV LEFT JOIN DETAI DT ON GV.MAGV=DT.GVCNDT
GROUP BY GV.MAGV,GV.HOTEN
--Q32 Với mỗi giáo viên cho tên giáo viên và số người thân của giáo viên đó. 
SELECT GV.HOTEN, COUNT (NT.MAGV) AS N'SỐ LƯỢNG NGƯỜI THÂN CỦA GIÁO VIÊN ĐÓ'
FROM GIAOVIEN GV LEFT JOIN NGUOITHAN NT ON GV.MAGV=NT.MAGV
GROUP BY GV.MAGV,GV.HOTEN

--Q33: Cho biết tên những giáo viên đã tham gia từ 3 đề tài trở lên. 
SELECT GV.HOTEN AS N'HỌ TÊN GIÁO VIÊN'
FROM GIAOVIEN GV LEFT JOIN THAMGIADT TGDT ON GV.MAGV=TGDT.MAGV
GROUP BY GV.MAGV,GV.HOTEN
HAVING COUNT ( TGDT.MADT) >= 3

--Q34: Cho biết số lượng giáo viên đã tham gia vào đề tài Ứng dụng hóa học xanh. 
SELECT COUNT( TGDT.MAGV) AS N'SỐ LƯỢNG NGƯỜI THAM GIA ĐỀ TẠI ỨNG DỤNG HOÁ HỌC XANH'
FROM THAMGIADT TGDT JOIN CONGVIEC CV ON TGDT.MADT = CV.MADT AND TGDT.STT = CV.SOTT JOIN DETAI DT ON CV.MADT = DT.MADT 
WHERE DT.TENDT = N'Ứng dụng hóa học xanh'
