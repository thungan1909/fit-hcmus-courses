.data

	strNhapN: .asciiz "Nhap N: "
	strNhapCacPT: .asciiz "Nhap cac phan tu:\n"
	strMangVuaNhap: .asciiz "Mang vua nhap la:\n"
	strXuongDong: .asciiz "\n"
	strTongCacPT: .asciiz "\nTong cac PT = "

.text
main:
	#Nhap N
	jal NhapN
	move $s0, $v0 # n: $s0
	
	#Khoi tao stack	
	addi $sp,$sp, -4 #Khai Bao Kich Thuoc Stack
 	sw $ra, 0($sp) 
 	# addi $sp,$sp, -framesize # khai báo kích th??c cho stack
        # sw $ra, framesize-4($sp) 
        
        
	#Nhap Mang
	li $v0, 4
	la $a0, strNhapCacPT
	syscall
	
	add $a0, $0, $sp
	add $a1, $0, $s0
	jal stack_push
	#Xuat Mang
	jal stack_pop
	#Tinh tong cac phan tu trong mang
	jal TongCacPT
	add $s1, $0, $v0
	#In ket qua
	li $v0, 4
	la $a0, strTongCacPT
	syscall
	li $v0, 1
	la $a0, ($s1)
	syscall
	#Thoat
	li $v0, 10
	syscall
#?AY LA PHAN KHAI BAO
NhapN:
la $a0, strNhapN
li $v0, 4
syscall
li $v0, 5
syscall
ble $v0, 0, NhapN #(so sanh neu N <=0, nhap lai)
jr $ra	
NhapTungPT:
	li $v0, 5
	syscall
	sw $v0, ($a0)
	addi $a0, $a0, 4
	addi $t1, $t1, 1
	blt $t1, $a1, NhapTungPT
	jr $ra
stack_push:
	subu $sp, $sp, 8  #push gia tri vao stack
	sw $a0, 4($sp)
	sw $ra, ($sp)
	addi $t1, $0, 0
	jal NhapTungPT
	lw $ra, ($sp)
	lw $a0, 4($sp)
	addi $sp, $sp, 8
	jr $ra
#stack_push:
#push: gi?m $sp ?i 4, l?u giá tr? vào ô nh? mà $sp ch? ??n.
#addi $sp, $sp, -4 # $sp -=4
#sw $a0, 0($sp) 
#jr $ra


stack_pop:
	subu $sp, $sp, 8
	sw $a0, 4($sp)
	sw $ra, ($sp)
	add $a2, $0, $a0
	li $v0, 4
	la $a0, strMangVuaNhap
	syscall
	addi $t1, $0, 0
	jal XuatTungPT
	lw $ra, ($sp)
	lw $a0, 4($sp)
	addi $sp, $sp, 8
	jr $ra
# pop: copy giá tr? trong vùng nh? ???c ch? ??n b?i $sp,c?ng 4 vào $sp
#stack_pop:
#lw $v0, 0($sp) 
#addi $sp, $sp, 4 
#jr $ra

XuatTungPT:
	li $v0, 1
	lw $a0, ($a2)
	syscall
	addi $a2, $a2, 4
	addi $t1, $t1, 1
	li $v0, 4
	la $a0, strXuongDong
	syscall
	blt $t1, $a1, XuatTungPT
	jr $ra

TongCacPT:
	sub $sp, $sp, 8
	sw $a0, 4($sp)
	sw $ra, ($sp)
	addi $t1, $0, 0
	addi $a2, $0, 0
	jal Tong
	move $v0, $a2
	lw $ra, ($sp)
	lw $a0, 4($sp)
	addi $sp, $sp, 8
	jr $ra
Tong:
	sub $sp, $sp, 4
	sw $t1, ($sp)
	lw $t1, ($a0)
	add $a2, $a2, $t1
	addi $a0, $a0, 4
	lw $t1, ($sp)
	addi $sp, $sp, 4
	addi $t1, $t1, 1
	blt $t1, $a1,Tong
	jr $ra
