﻿USE MASTER 
GO
USE QL_DETAI
GO
SELECT *
FROM GIAOVIEN
 --35. Cho biet muc luong cao nhat cua các giang viên. 
 SELECT DISTINCT LUONG
 FROM GIAOVIEN
 WHERE LUONG >= ALL(SELECT LUONG FROM GIAOVIEN)
 --36. Cho biet nhung giáo viên có luong lon nhat. 
 SELECT *
 FROM GIAOVIEN
 WHERE LUONG >= ALL(SELECT LUONG FROM GIAOVIEN)
 --37. Cho biet luong cao nhat trong bo môn “HTTT”. 
 SELECT *
 FROM GIAOVIEN
 WHERE LUONG >= ALL(SELECT LUONG FROM GIAOVIEN WHERE MABM='HTTT') AND MABM='HTTT'

 --38. Cho biet tên giáo viên lon tuoi nhat cua bo môn He thong thông tin.

 SELECT GV.HOTEN
 FROM GIAOVIEN GV, BOMON BM
 WHERE GV.MABM=BM.MABM AND BM.TENBM=N'Hệ thống thông tin'
 AND (DATEDIFF(DAYOFYEAR,GV.NGSINH,GETDATE()) >=
 ALL (SELECT DATEDIFF(DAYOFYEAR,GV1.NGSINH,GETDATE()) FROM GIAOVIEN GV1,BOMON BM1
 WHERE BM1.TENBM=N'Hệ thống thông tin' AND GV1.MABM=BM1.MABM))

 --39. Cho biet tên giáo viên nho tuoi nhat khoa Công nghe thông tin. 
 
 SELECT GV.HOTEN
 FROM GIAOVIEN GV, BOMON BM, KHOA K
 WHERE GV.MABM=BM.MABM AND BM.MAKHOA=K.MAKHOA AND K.TENKHOA=N'Công nghệ thông tin'
 AND (DATEDIFF(DAYOFYEAR,GV.NGSINH,GETDATE()) <=
 ALL (SELECT DATEDIFF(DAYOFYEAR,GV1.NGSINH,GETDATE()) 
 FROM GIAOVIEN GV1, BOMON BM1, KHOA K1
 WHERE GV1.MABM=BM1.MABM AND BM1.MAKHOA=K1.MAKHOA AND K1.TENKHOA=N'Công nghệ thông tin'))

 --40. Cho biet tên giáo viên và tên khoa cua giáo viên có luong cao nhat. 
  SELECT GV.HOTEN,K.TENKHOA
 FROM GIAOVIEN GV, KHOA K, BOMON BM
 WHERE GV.MABM=BM.MABM AND BM.MAKHOA=K.MAKHOA AND GV.LUONG >= ALL(SELECT LUONG FROM GIAOVIEN)

 --41. Ceho biet nhung giáo viên có luong lon nhat trong bo môn cua ho. 
  SELECT *
 FROM GIAOVIEN GV
 WHERE GV.LUONG >= ALL
 (SELECT GV1.LUONG 
 FROM GIAOVIEN GV1,BOMON BM1, BOMON BM 
 WHERE  BM1.MABM=GV1.MABM AND BM1.MABM=BM.MABM AND GV.MABM=BM.MABM)
 
 --42. Cho biet tên nhung de tài mà giáo viên Nguyen Hoài An chua tham gia. 
SELECT *
FROM DETAI DT
WHERE DT.MADT NOT IN(
SELECT TG.MADT
FROM THAMGIADT TG, GIAOVIEN GV
WHERE GV.MAGV=TG.MAGV  AND GV.HOTEN=N'NGUYỄN HOÀI AN')

 --43. Cho biet nhung de tài mà giáo viên Nguyen Hoài An chua tham gia. Xuat ra tên de tài, tên nguoi chu nhiem de tài. 
 SELECT DT.TENDT,GV.HOTEN AS 'GV CNDT'
FROM DETAI DT, GIAOVIEN GV
WHERE GV.MAGV=DT.GVCNDT AND DT.MADT NOT IN(
SELECT TG.MADT
FROM THAMGIADT TG, GIAOVIEN GV
WHERE GV.MAGV=TG.MAGV  AND GV.HOTEN=N'NGUYỄN HOÀI AN')
 --44. Cho biet tên nhung giáo viên khoa Công nghe thông tin mà chua tham gia de tài nào. 
 SELECT DISTINCT GV.HOTEN
 FROM GIAOVIEN GV, KHOA K,BOMON BM
 WHERE K.MAKHOA=BM.MAKHOA AND BM.MABM=GV.MABM AND K.TENKHOA=N'Công nghệ thông tin'
 AND GV.MAGV
 NOT IN
 (SELECT TG.MAGV  FROM THAMGIADT TG WHERE TG.MAGV=GV.MAGV)
 --45. Tìm nhung giáo viên không tham gia bat ki de tài nào
  SELECT DISTINCT *
 FROM GIAOVIEN GV
 WHERE GV.MAGV  NOT IN (SELECT TG.MAGV  FROM THAMGIADT TG WHERE TG.MAGV=GV.MAGV)
  --46. Cho biet giáo viên có luong lon hon luong cua giáo viên “Nguyen Hoài An” 
 SELECT *
 FROM GIAOVIEN
 WHERE LUONG > ALL(SELECT LUONG FROM GIAOVIEN WHERE HOTEN=N'NGUYỄN HOÀI AN')
 --47. Tìm nhung truong bo môn tham gia toi thieu 1 de tài
 
 SELECT *
FROM GIAOVIEN GV, BOMON BM
WHERE BM.TRUONGBM = GV.MAGV AND GV.MAGV IN
(SELECT GV.MAGV
FROM GIAOVIEN GV, THAMGIADT TG
WHERE GV.MAGV=TG.MAGV)
 --48. Tìm giáo viên trùng tên và cùng gioi tính voi giáo viên khác trong cùng bo môn 
SELECT *
FROM GIAOVIEN GV
WHERE GV.MAGV IN
(SELECT GV1.MAGV
 FROM GIAOVIEN GV1
 WHERE GV1.HOTEN = GV.HOTEN AND GV1.PHAI = GV.PHAI AND GV1.MABM = GV.MABM AND  GV1.MAGV != GV.MAGV )
 --49. Tìm nhung giáo viên có luong lon hon luong cua ít nhat mot giáo viên bo môn “Công nghe phan mem”
 SELECT *
 FROM GIAOVIEN
 WHERE LUONG > ANY(SELECT GV.LUONG FROM GIAOVIEN GV, BOMON BM WHERE BM.MABM=GV.MABM AND BM.TENBM=N'Công nghệ tri thức')
 --50. Tìm nhung giáo viên có luong lon hon luong cua tat ca giáo viên thuoc bo môn “He thong thông tin” 
 SELECT *
 FROM GIAOVIEN
 WHERE LUONG > ALL(SELECT GV.LUONG FROM GIAOVIEN GV, BOMON BM WHERE BM.MABM=GV.MABM AND BM.TENBM=N'Hệ thống thông tin')
 --51. Cho biet tên khoa có dông giáo viên nhat 
SELECT K.TENKHOA 
FROM KHOA K , BOMON BM
WHERE K.MAKHOA = BM.MAKHOA AND BM.MABM = 
(SELECT MABM
 FROM GIAOVIEN
 GROUP BY MABM
 HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM GIAOVIEN
 GROUP BY MABM))
 --52. Cho biet ho tên giáo viên chu nhiem nhieu de tai nhat 
SELECT GV.HOTEN
FROM GIAOVIEN GV, DETAI DT
WHERE  DT.GVCNDT=GV.MAGV 
GROUP BY GV.HOTEN  
HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM DETAI DT,GIAOVIEN GV
 WHERE DT.GVCNDT = GV.MAGV  
 GROUP BY GV.HOTEN)
 --53. Cho biet mã bo môn có nhieu giáo viên nhat 
SELECT MABM
 FROM GIAOVIEN
 GROUP BY MABM
 HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM GIAOVIEN
 GROUP BY MABM)
 --54. Cho biet tên giáo viên và tên bo môn cua giáo viên tham gia nhieu de tài nhat.
 SELECT GV.HOTEN, BM.TENBM
FROM GIAOVIEN GV, BOMON BM, THAMGIADT TG
WHERE  GV.MABM=BM.MABM AND TG.MAGV=GV.MAGV
GROUP BY GV.HOTEN, BM.TENBM
HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM GIAOVIEN GV,THAMGIADT TG
 WHERE TG.MAGV = GV.MAGV  
 GROUP BY GV.HOTEN)
 --55. Cho biet tên giáo viên tham gia nhieu de tài nhat cua bo môn HTTT. 
  SELECT GV.HOTEN
FROM GIAOVIEN GV, BOMON BM, THAMGIADT TG
WHERE  GV.MABM=BM.MABM AND TG.MAGV=GV.MAGV AND GV.MABM='HTTT'
GROUP BY GV.HOTEN, BM.TENBM
HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM GIAOVIEN GV,THAMGIADT TG
 WHERE TG.MAGV = GV.MAGV AND GV.MABM='HTTT'
 GROUP BY GV.HOTEN)
 --56. Cho biet tên giáo viên và tên bo môn cua giáo viên có nhieu nguoi thân nhat.
 SELECT GV.HOTEN, BM.TENBM
FROM GIAOVIEN GV, BOMON BM, NGUOITHAN NT
WHERE  GV.MABM=BM.MABM AND GV.MAGV=NT.MAGV
GROUP BY GV.HOTEN, BM.TENBM
HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM GIAOVIEN GV,NGUOITHAN NT
 WHERE NT.MAGV = GV.MAGV  
 GROUP BY GV.HOTEN)
 --57. Cho biet tên truong bo môn mà chu nhiem nhieu de tài nhat. 
 SELECT GV.HOTEN
FROM GIAOVIEN GV, DETAI DT, BOMON BM
WHERE  DT.GVCNDT=GV.MAGV AND BM.TRUONGBM=GV.MAGV
GROUP BY GV.HOTEN  
HAVING COUNT(*) >= ALL(SELECT COUNT(*)
 FROM DETAI DT,GIAOVIEN GV, BOMON BM
 WHERE DT.GVCNDT = GV.MAGV AND BM.TRUONGBM=GV.MAGV 
 GROUP BY GV.HOTEN)