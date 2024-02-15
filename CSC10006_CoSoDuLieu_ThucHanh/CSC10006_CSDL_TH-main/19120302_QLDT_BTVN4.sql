--tao co so du lieu
USE master 
GO 
USE QL_CHUYENBAY
GO
--Q17: Với mỗi sân bay(SBDEN), cho biết số lượng chuyến bay hạ cánh xuống sân bay đó.
--Kết quả được sắp xếp theo thứ tự tăng dần của sân bay đến. 

SELECT SBDEN, COUNT(*) AS N'SỐ LƯỢNG CHUYẾN BAY'
FROM CHUYENBAY
GROUP BY SBDEN
ORDER BY SBDEN ASC


--Q18: Với mỗi sân bay(SBDI), cho biết số lượng chuyến bay xuất phát từ sân bay đó
--sắp xếp theo thứ tự tăng dần của sân bay xuất phát

SELECT SBDI, COUNT(*) AS N'SỐ LƯỢNG CHUYẾN BAY'
FROM CHUYENBAY
GROUP BY SBDI
ORDER BY SBDI ASC


--Q19: Với mỗi sân bay (SBDI), cho biết số lượng chuyến bay xuất phát theo từng ngày.
--Xuất ra mã sân bay đi, ngày và số lượng.
SELECT CB.SBDI,LB.NGAYDI,COUNT(LB.MACB) AS N'SỐ LƯỢNG CHUYẾN BAY XUẤT PHÁT THEO TỪNG NGÀY'
FROM CHUYENBAY CB JOIN LICHBAY LB ON CB.MACB=LB.MACB
GROUP BY CB.SBDI,LB.NGAYDI
--Q20: Với mỗi sân bay(SBDEN), cho biết số lượng chuyến bay hạ cánh theo từng ngày.
--Xuất ra mã sân bay đến, ngày, số lượng
SELECT CB.SBDEN,LB.NGAYDI,COUNT(LB.MACB) AS N'SỐ LƯỢNG CHUYẾN BAY HẠ CÁNH THEO TỪNG NGÀY'
FROM CHUYENBAY CB JOIN LICHBAY LB ON CB.MACB=LB.MACB
GROUP BY CB.SBDEN,LB.NGAYDI
--Ở ĐÂY ĐÚNG RA NÊN LÀ NGÀY ĐẾN NHƯNG TRONG CƠ SỞ DỮ LIỆU KHÔNG CÓ THÔNG TIN VỀ NGÀY ĐẾN NÊN EM TẠM THỜI LÀM NGÀY ĐI

--Q21: Với mỗi lịch bay, cho biết mã chuyến bay, ngày đi cùng với
--số lượng nhân viên không phải là phi công của chuyến bay đó. 

SELECT LB.MACB,LB.NGAYDI,COUNT(NV.MANV) AS N'SÓ LƯỢNG NHÂN VIÊN KHÔNG PHẢI PHI CÔNG CỦA CHUYẾN BAY ĐÓ'
FROM LICHBAY LB JOIN PHANCONG PC ON LB.MACB=PC.MACB JOIN NHANVIEN NV ON PC.MANV=NV.MANV 
WHERE NV.LOAINV=0
GROUP BY LB.MACB,LB.NGAYDI


--Ở ĐÂY, DO LOAINV CỦA BẢNG NHANVIEN CÓ QUY ƯỚC RẰNG LOAINV=1 //PHI CÔNG, LOAINV=0 //TIẾP VIÊN

--Q22: SỐ LƯỢNG CHUYẾN BAY XUẤT PHÁT TỪ SÂN BAY MIA VÀO NGÀY 11/01/2000

SELECT COUNT(CB.MACB) AS N'SỐ LƯỢNG CHUYẾN BAY XUẤT PHÁT TỪ SÂN BAY MIA VÀO NGÀY 11/01/2000'
FROM CHUYENBAY CB JOIN LICHBAY LB ON LB.MACB=CB.MACB
WHERE CB.SBDI='MIA' AND LB.NGAYDI='11-01-2000'

--Q23: Với mỗi chuyến bay, cho biết mã chuyến bay, ngày đi, số lượng nhân viên được phân công trên chuyến bay đó, sắp theo thứ tự giảm dần số lượng

SELECT PC.MACB,PC.NGAYDI, COUNT(PC.MANV) AS N' SỐ LƯỢNG NHÂN VIÊN ĐƯỢC PHÂN CÔNG TRÊN CHUYẾN BAY ĐÓ'
FROM PHANCONG PC
GROUP BY PC.MACB, PC.NGAYDI
ORDER BY COUNT(PC.MANV) DESC

--Q24: Với mỗi chuyến bay, cho biết mã chuyến bay, ngày đi, số lượng HÀNH KHÁCH ĐÃ ĐẶT CHỖ trên chuyến bay đó, sắp theo thứ tự giảm dần số lượng
SELECT DC.MACB,DC.NGAYDI, COUNT(DC.MAKH) AS N' SỐ LƯỢNG HÀNH KHÁCH ĐẤ ĐẶT CHỖ TRÊN CHUYẾN BAY ĐÓ'
FROM DATCHO DC
GROUP BY DC.MACB, DC.NGAYDI
ORDER BY COUNT(DC.MAKH) DESC

--Q25: Với mỗi chuyến bay, cho biết mã chuyến bay, ngày đi, tổng lương của phi hành đoàn (các NV được phân công trong chuyến bay), sắp xếp theo thứ tự tăng dần của tổng lương
SELECT PC.MACB,PC.NGAYDI,SUM(NV.LUONG) AS N'TỔNG LƯƠNG CỦA PHI HÀNH ĐOÀN'
FROM PHANCONG PC JOIN NHANVIEN NV ON PC.MANV=NV.MANV
GROUP BY PC.MACB, PC.NGAYDI
ORDER BY SUM(NV.LUONG) ASC

--Q26: Cho biết lương trung bình của các nhân viên không phải là phi công
SELECT AVG(NV.LUONG) AS N'LƯƠNG TRUNG BÌNH CỦA NHÂN VIÊN KHÔNG PHẢI PHI CÔNG'
FROM NHANVIEN NV
WHERE NV.LOAINV=0

--Q27:  Cho biết lương trung bình của các nhân viên là phi công
SELECT AVG(NV.LUONG) AS N'LƯƠNG TRUNG BÌNH CỦA NHÂN VIÊN LÀ PHI CÔNG'
FROM NHANVIEN NV
WHERE NV.LOAINV=1

--Q28: Với mỗi loại máy bay, cho biết số lượng chuyến bay đã bay trên loại máy bay đó hạ cánh xuống sân bay ORD.
--Xuất ra mã loại máy bay, số lượng chuyến bay

SELECT LB.MALOAI, COUNT(LB.MACB) AS N'SỐ LƯỢNG CHUYẾN BAY ĐÃ BAY TRÊN LOẠI MÁY BAY ĐÓ VÀ HẠ CÁNH XUỐNG SÂN BAY ORD'
FROM LICHBAY LB JOIN CHUYENBAY CB ON LB.MACB=LB.MACB
WHERE CB.SBDEN='ORD'
GROUP BY LB.MALOAI

--Q29: Cho biết sân bay(SBDI) và số lượng chuyến bay có nhiều hơn 2 chuyến bay xuất phát trong khoảng từ 10 giờ đến 22 giờ
SELECT CB.SBDI,COUNT (CB.MACB) AS N'SỐ LƯỢNG CHUYẾN BAY'
FROM CHUYENBAY CB
WHERE CB.GIODI >= '10:00' AND CB.GIODI <= '22:00'
GROUP BY CB.SBDI
HAVING COUNT(CB.MACB) > 2

--Q30: Cho biết tên phi công được phân công vào ít nhất 2 chuyến bay 1 ngày 
SELECT PC.NGAYDI,NV.TEN, COUNT (PC.MACB) AS N'SỐ LƯỢNG CHUYẾN BAY'
FROM PHANCONG PC JOIN NHANVIEN NV ON PC.MANV=NV.MANV
GROUP BY PC.NGAYDI, NV.TEN
HAVING COUNT(PC.MACB) >= 2
--Q31: Cho biết mã chuyến bay, ngày đi của những chuyến bay có ít nhất 3 hành khách đặt chỗ

SELECT DC.MACB, DC.NGAYDI, COUNT(DC.MAKH) AS N'SỐ HÀNH KHÁCH ĐẶT CHỖ'
FROM DATCHO DC
GROUP BY DC.MACB, DC.NGAYDI
HAVING COUNT(DC.MAKH) >=3
--Q32: Cho biết số hiệu máy bay, loại máy bay mà phi công có mã 1001 được phân công lái trên 2 lần

SELECT LB.SOHIEU,LB.MALOAI, COUNT(*) AS N'SỐ LẦN LÁI'
FROM PHANCONG PC, LICHBAY LB 
WHERE PC.MANV='1001'AND PC.MACB=LB.MACB 
GROUP BY  LB.SOHIEU,LB.MALOAI
HAVING COUNT(*)>2

--Q33: Với mỗi hãng sản xuất cho biết số lượng loại máy bay mà hãng đó đã sx ra. Xuất ra hãng sản xuất và số lượng

SELECT LMB.HANGSX, COUNT (LMB.MALOAI) AS N'SỐ LƯỢNG LOẠI MÁY BAY'
FROM LOAIMB LMB
GROUP BY LMB.HANGSX
