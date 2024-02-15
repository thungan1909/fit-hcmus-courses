.data
Nhap: .asciiz "Nhap N(N>0): "
Xuat: .asciiz "Mang vua nhap la\n"
strXuongHang: .asciiz "\n"
PhanTuThu: .asciiz "Phan tu thu"
DauHaiCham: .asciiz ": "
DauCach: .asciiz" "

array: .word 0:50  # tao ra int array[50]

.text
main:
# nhap so luong phan tu N

la $a0,Nhap  #Xuat ra chuoi
addi $v0, $0, 4
syscall

addi $v0, $0, 5
syscall
addi $s0, $v0, 0 # $s0 = N

jal NhapMang   #jump and link:
		# (B1: link luu dia chi cua cau len ke tiep vao thanh ghi $ra)
		# (B2: nhay den nhan label (Nhap mang))
j XuatMang	#jump to label = goto label trong :. Nhay khong dieu kien den label

#HÀM NHAP MANG
NhapMang:
# khoi tao
addi $t0, $0, 0 # Gan $t0 = 0
la $a1, array    #la: Khoi tao thanh ghi voi dia chi
		#tai dia chi cua array vao thanh ghi $a1
		# $a1 = &array
#HÀM NHAP PHAN TU
NhapTungPhanTu:

# Dem so lan d
slt $t1, $t0, $s0	#slt: set on less than: So sánh lon hon/bé hon cua $t1 và $s0
			#t1=1 khi t0<s0 va t1=0 khi t0>s0
#Kiem tra dieu kien de ket thuc lap			
beq $t1, $0, KetThucNhapLieu #Nhay den "KetThucNhapLieu" neu t1=0 (hay t0 > s0)

#DAY LA PHAN XUAT RA "PHAN TU THU I" 
#Xuat ra dong "Phan tu thu"
la $a0,PhanTuThu
addi $v0,$0,4
syscall
#Xuat ra cach (" ")
la $a0, DauCach
addi $v0,$0,4
syscall

# xuat chi so mang $t0
addi $a0, $t0, 0 
li $v0, 1 	#li: Khoi tao thanh ghi voi gia tri
syscall 

#Xuat ra dau hai cham (:)
la $a0, DauHaiCham
addi $v0,$0,4
syscall

#DAY LÀ PHAN NHAP

# nhap so nguyen va luu vao array[i]
addi $v0, $0, 5		#Nhap so nguyen
syscall
sw $v0, ($a1)		#sw: Luu 1 word trong thanh ghi vao 1 vi tri trong bo nho RAM
			#Luu vao mang $a1
# tang chi so
addi $t0, $t0, 1	#Tang chi so len 1 den den phan tu tiep theo
addi $a1, $a1, 4

j NhapTungPhanTu		#Lap lai viec nhap (nhay den NhapTungPhanTu)

KetThucNhapLieu:
jr $ra 	#jr: nhay den dia chi trong thanh ghi ra (dùng  tra ve tu loi goi hàm)

XuatMang:

#Xuong dòng
la $a0, strXuongHang
addi $v0,$0,4
syscall 
# Xuat ra dòng "Mang vua nhap là:"
la $a0,Xuat		#Goi ra chuoi Xuat
addi $v0,$0,4		#in ra chuoi 
syscall 

la $a1, array	#la: Khoi tao thanh ghi voi dia chi
		#tai dia chi cua array vao thanh ghi $a1
		# $a1 = &array
addi $t0, $0, 0

XuatPhanTu:
# kiem tra so lan lap
slt $t1, $t0, $s0
beq $t1, $0,Thoat

#DAY LA PHAN XUAT RA "PHAN TU THU I" 

#Xuat ra dong "Phan tu thu"
la $a0,PhanTuThu
addi $v0,$0,4
syscall
#Xuat ra cach (" ")
la $a0, DauCach
addi $v0,$0,4
syscall

# xuat chi so mang $t0
addi $a0, $t0, 0 
li $v0, 1 	#li: Khoi tao thanh ghi voi gia tri
syscall 

#Xuat ra dau hai cham (:)
la $a0, DauHaiCham
addi $v0,$0,4
syscall
#DÂY LÀ PHAN XUAT NOI DUNG MANG
# xuat phan tu array[i]
lw $a0, ($a1)
addi $v0, $0, 1
syscall

#Xuong dòng
la $a0, strXuongHang
addi $v0,$0,4
syscall 

# tang i
addi $t0, $t0, 1
addi $a1, $a1, 4

j XuatPhanTu  #Lap lai XuatPhanTu

Thoat:
addi $v0, $0, 10
syscall
