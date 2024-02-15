#include<iostream>
#include<string>
#include<fstream>
#include <vector>
#pragma warning(disable:4996)
using namespace std;
//CÁC LỚP
class CThueBao {
protected: 
	string MaKhachHang;
	string HoTen;
	string SDT;
	string GoiCuoc;
public:
	virtual string LayLoaiGoiCuoc();
	virtual string LayMaKhachHang();
	virtual string LaySDT();
	virtual long int TinhTien() = 0;
	virtual void Nhap(string);
	virtual void Xuat();
	CThueBao();
	~CThueBao();
};
class CThueBaoTronGoi: public CThueBao
{
private:
public:
	void Nhap(string);
	void Xuat();
	long int TinhTien();
	CThueBaoTronGoi();
	~CThueBaoTronGoi();
};
class CThueBaoDungLuong: public CThueBao
{
private:
	long int DungLuong;
public:
	void Nhap(string,long int);
	void Xuat();
	long int TinhTien();
	CThueBaoDungLuong();
	~CThueBaoDungLuong();
};
class CKhachHangTraTruoc : public CThueBao
{
private:
	int SoThang;
public:
	void Nhap(int, string);
	void Xuat();
	long int TinhTien();
	CKhachHangTraTruoc();
	~CKhachHangTraTruoc();
};
class CCongTy
{
private:
	vector<CThueBao*> DSThueBao;
	vector<CThueBao*> DSKhachHangTraTruoc;
public:
	void Nhap();
	void Xuat();
	long int TinhTienTBTronGoi();
	long int TinhTienTBDungLuong();
	void TinhTienKhachHangTraTruoc();
	void XuatDanhSachKhachHangTraTruoc();
	void TimThongTinKhachHang();
	CCongTy();
	~CCongTy();
};
class CBaiThi
{
public:
	void Cau01();
	void Cau02();
	void Cau03();
	void Cau04();
};

//CÁC HÀM

//HÀM CHUNG TOÀN BÀI
/*Tìm vị trí xuất hiện lần thứ x của chuỗi con trong chuỗi gốc
Với x là số thứ tự chỉ lần xuất hiện của chuỗi con, do mình nhập vào.
*/
int TimViTriXuatHienThuXCuaChuoiCon(const string& chuoiGoc, const string& chuoiCon, int thuTu)
{
	int  vitri(0), dem(0);
	while (dem != thuTu)
	{
		vitri++;
		vitri= chuoiGoc.find(chuoiCon, vitri);
		if (vitri == string::npos)
			return -1;
		dem++;
	}
	return vitri;
}
void main()
{
	CBaiThi BT;
	BT.Cau01();
	BT.Cau02();
	BT.Cau03();
	BT.Cau04();
}
//============================================
//HÀM TRONG LỚP BÀI THI - CHỨA CÁC CÂU TRONG ĐỀ

//Câu 01: Xuất nội dung từ file INPUT.txt ra màn hình
void CBaiThi::Cau01()
{
	cout << "\n===========================\n";
	cout << "CAU 1:\n";
	freopen("INPUT.txt", "rt", stdin);
	while (!cin.eof())
	{
		string BienTam;
		getline(cin, BienTam);
		cout << BienTam << endl;
	}
}
//Câu 02: Tính tổng tiền của tất cả khách hàng thuê bao theo dung lượng và thuê bao trọn gói. In ra màn hình.
void CBaiThi::Cau02()
{
	cout << "\n===========================\n";
	cout << "CAU 2:\n";
	cin.clear();
	freopen("CON", "rt", stdin);
	freopen("INPUT.txt", "rt", stdin);
	CCongTy CT;
	while (!cin.eof())
	{
		CT.Nhap();
	}
	//CT.Xuat();
	//fixed: to set non-scientific (dang so E+)
	cout << "Tong tien cua tat ca khach hang su dung thue bao tinh theo dung luong: " << CT.TinhTienTBDungLuong() << " dong." << endl;
	cout << "Tong tien cua tat ca khach hang su dung thue bao tron goi: " << CT.TinhTienTBTronGoi() << " dong" << endl;
}
//Câu 03: Đọc từ INPUT2.TXT, thống kê tiền phải trả với khách hàng trả trước. In ra màn hình.
void CBaiThi::Cau03()
{
	cout << "\n===========================\n";
	cout << "CAU 3:\n";
	cin.clear();
	freopen("CON", "rt", stdin);
	freopen("INPUT2.txt", "rt", stdin);
	CCongTy CT;
	while (!cin.eof())
	{
		CT.Nhap();
	}
	CT.TinhTienKhachHangTraTruoc();
}
//Câu 04: Nhập mã khách hàng hoặc SĐT. Hiển thị số tiền cần đóng 1 tháng. Xuất ra file OUTPUT.TXT 
void CBaiThi::Cau04()
{
	cout << "\n===========================\n";
	cout << "CAU 4:\n";
	cin.clear();
	freopen("CON", "rt", stdin);
	freopen("INPUT2.txt", "rt", stdin);
	CCongTy CT;
	while (!cin.eof())
	{
		CT.Nhap();
	}
	cin.clear();
	freopen("CON", "rt", stdin);
	CT.TimThongTinKhachHang();
}
//============================================

//HÀM TRONG CÁC LỚP
//===============

//HÀM TRONG LỚP THUÊ BAO

//Hàm này trả về loại gói cước
string CThueBao::LayLoaiGoiCuoc()
{
	return GoiCuoc;
}
//Hàm này trả về mã khách hàng
string CThueBao::LayMaKhachHang()
{
	return MaKhachHang;
}
//Hàm này trả về Số điện thoại
string CThueBao::LaySDT()
{
	return SDT;
}
//Hàm này là hàm tính tiền mặc định
long int CThueBao::TinhTien()
{
	return 0;
}
/*Hàm này nhập(lưu) các thông tin chung của 1 khách hàng:
Hàm này truyền vào 1 dòng dữ liệu (BienTam), sau đó tìm các thông tin lưu vào các biến thông qua việc tìm vị trí xuất hiện của dấu phẩy
Bởi vì các dữ liệu trong 1 dòng được viết cách nhau bằng dấu phẩy. 
Ta tìm vị trí của dấu phẩy thứ x trong chuỗi, sau đó suy ra vị trí, số lượng chữ cái của các biến thông tin
Rồi từ đó ghép vào biến thông qua hàm subtr
*/
void CThueBao::Nhap(string BienTam)
{
	string DauPhay = ",";
	// Doc Ma Khach Hang
	int first = TimViTriXuatHienThuXCuaChuoiCon(BienTam, DauPhay,1);
	MaKhachHang = BienTam.substr(0, first);
	//Doc Ho Ten Khach Hang
	int second = TimViTriXuatHienThuXCuaChuoiCon(BienTam, DauPhay,2);
	int second1 = second - first - 2;
	HoTen = BienTam.substr(first+2, second1);
	// Doc SDT Khach Hang
	int third = TimViTriXuatHienThuXCuaChuoiCon(BienTam, DauPhay, 3);
	int third1 = third - second - 2;
	SDT = BienTam.substr(second+2, third1);
	//Doc Goi cuoc su dung
	int fourth = TimViTriXuatHienThuXCuaChuoiCon(BienTam, DauPhay, 4);
	int fourth1 = fourth - third - 2;
	GoiCuoc= BienTam.substr(third + 2, fourth1);
}
//Hàm này là hàm xuất mặc định
void CThueBao::Xuat()
{
}
//Phương thức khởi tạo, ta gán các giá trị bằng rỗng 
CThueBao::CThueBao()
{
	MaKhachHang = "";
	HoTen = "";
	SDT = "";
	GoiCuoc = "";
}
//Phương thức phá huỷ
CThueBao::~CThueBao()
{
}
//===============
//HÀM TRONG LỚP THUÊ BAO TRỌN GÓI

//Hàm nhập vào thông tin của thuê bao trọn gói (Thông qua kế thừa từ hàm nhập của lớp Thuê bao)
void CThueBaoTronGoi::Nhap(string BienTam)
{
	CThueBao::Nhap(BienTam);
}
//Hàm xuất ra thông tin của 1 thuê bao trọn gói
void CThueBaoTronGoi::Xuat()
{
	cout << MaKhachHang << ", " << HoTen << ", " << SDT << ", " << GoiCuoc << endl;
	cout << endl;
}
//Hàm tính tiền của 1 thuê bao trọn gói theo loại
long int CThueBaoTronGoi::TinhTien()
{
	if (LayLoaiGoiCuoc() == "MegaBasic")
	{
		return 250000;
	}
	else if (LayLoaiGoiCuoc() == "MegaEasy")
	{
		return 350000;
	}
	else if (LayLoaiGoiCuoc() == "MegaFamily")
	{
		return 450000;
	}
	else if (LayLoaiGoiCuoc() == "MegaMaxi")
	{
		return 900000;
	}
	else if (LayLoaiGoiCuoc() == "MegaPro")
	{
		return 1400000;
	}
}
//Phương thức khởi tạo lớp Thuê bao trọn gói
CThueBaoTronGoi::CThueBaoTronGoi()
{
}
//Phương thức phá huỷ lớp Thuê bao trọn gói
CThueBaoTronGoi::~CThueBaoTronGoi()
{
}
//===============
//HÀM TRONG LỚP THUÊ BAO DUNG LƯỢNG

//Hàm nhập vào 1 thuê bao tính theo dung lượng, kế thừa hàm nhập của lớp Thuê bao và thêm vào thông tin Dung lượng
void CThueBaoDungLuong::Nhap(string BienTam,long int DL)
{
	CThueBao::Nhap(BienTam);
	DungLuong = DL;
}
//Hàm xuất ra thông tin về 1 thuê bao tính theo dung lượng
void CThueBaoDungLuong::Xuat()
{
	cout << MaKhachHang << ", " << HoTen << ", " << SDT << ", " << GoiCuoc << ", " << DungLuong <<" MB" << endl;
	cout << endl;
}
//Hàm tính tiền của từng thuê bao theo dung lượng: Ta kiểm tra tên gói thuê bao sau đó tính theo công thức của gói thuê bao đó
long int CThueBaoDungLuong::TinhTien()
{
		if (LayLoaiGoiCuoc() == "MegaBasic")
		{
			return (24000 + 45 * DungLuong);
		}
		else if (LayLoaiGoiCuoc() == "MegaEasy")
		{
			return (30000 + 55 * DungLuong);
		}
		else if (LayLoaiGoiCuoc() == "MegaFamily")
		{
			return (34000 + 60 * DungLuong);
		}
		else if (LayLoaiGoiCuoc() == "MegaMaxi")
		{
			return (50000 + 80 * DungLuong);
		}
		else if (LayLoaiGoiCuoc() == "MegaPro")
		{
			return (70000 + 100 * DungLuong);
		}
}
//Phương thức khởi tạo của lớp Thuê bao dung lượng
CThueBaoDungLuong::CThueBaoDungLuong()
{
	DungLuong = 0;
}
//Phương thức phá huỷ của lớp Thuê Bao dung lượng
CThueBaoDungLuong::~CThueBaoDungLuong()
{
}
//===============
//HÀM TRONG LỚP CÔNG TY

/*Hàm nhập thông tin thuê bao của cả công ty(tất cả thuê bao từ file đầu vào)
Hàm này đọc 1 dòng dữ liệu và lưu vào biến BienTam.
Sau đó tách các thông tin trong dòng dữ liệu để lưu vào các biến tương ứng (biến Dung lương (DocDungLuong, biến số Tháng (DocSoThang)).  
Thông qua việc tìm vị trí xuất hiện thứ x của dấu phẩy.
Bởi vì các dữ liệu trong 1 dòng được viết cách nhau bằng dấu phẩy.
Ta tìm vị trí của dấu phẩy thứ x trong chuỗi, sau đó suy ra vị trí, số lượng chữ cái của các biến thông tin
Rồi từ đó ghép vào biến thông qua hàm subtr
Ngoài ra, ra còn tìm chữ cái đầu tiên của dòng dữ liệu để phân loại thuê bao
*/
void CCongTy::Nhap()
{
	//Khai báo biến
	string BienTam;
	getline(cin, BienTam);
	string DauPhay = ",";
	long int DocDungLuong(0);
	int DocSoThang(0);
	CKhachHangTraTruoc* TT = new CKhachHangTraTruoc;
	CThueBaoDungLuong* DL = new CThueBaoDungLuong;
	CThueBaoTronGoi* TG = new CThueBaoTronGoi;
	char firstWord = BienTam.at(0);
	//Xử lý
	if (firstWord == 'D') //Thuê bao tính theo dung lượng
	{
		int fourth = TimViTriXuatHienThuXCuaChuoiCon(BienTam, DauPhay, 4);
		DocDungLuong = stof(BienTam.substr(fourth + 2, BienTam.length() - 2));
		DL->Nhap(BienTam,DocDungLuong);
		DSThueBao.push_back(DL);
	}
	else if(firstWord=='T') 
	{
		int fourth = TimViTriXuatHienThuXCuaChuoiCon(BienTam, DauPhay, 4);
		if (fourth != -1) //Thuê bao khách hàng trả trước
		{
			DocSoThang = stoi(BienTam.substr(fourth + 2, BienTam.length() - 2));
			TT->Nhap(DocSoThang, BienTam);
			DSKhachHangTraTruoc.push_back(TT);
			DSThueBao.push_back(TT);
		}
		else //Thuê bao trọn gói
		{
			TG->Nhap(BienTam);
			DSThueBao.push_back(TG);
		}
	}
}
//Hàm xuất ra danh sách các thuê bao thông qua việc duyệt từ đầu đến cuối vector
void CCongTy::Xuat()
{
	for (int i = 0; i < DSThueBao.size(); i++)
	{
		DSThueBao[i]->Xuat();
	}
}
//Hàm xuất danh sách các khách hàng thuê bao trả trước
void CCongTy::XuatDanhSachKhachHangTraTruoc()
{
	for (int i = 0; i < DSKhachHangTraTruoc.size(); i++)
	{
		DSKhachHangTraTruoc[i]->Xuat();
	}
}
//Hàm tìm thông tin khách hàng bằng cách nhập Mã KH hoặc SĐT.
//Sau khi nhập sẽ đem so sánh để tìm trong danh sách thuê bao
//Xuất ra file OUTPUT.txt kết quả thu được
void CCongTy::TimThongTinKhachHang()
{
	string MaKhachHangCanTim;
	string SDTCanTim;
	int luaChon = 0;
	int kiemTra(-1);
	cout << "Nhap vao Ma Khach Hang hoac So Dien Thoai de tra cuu thong tin\n";
	cout << "Nhan phim 1 - neu ban muon nhap Ma Khach Hang\n";
	cout << "Nhan phim 2 - neu ban muon nhap So Dien Thoai\n";
	cin >> luaChon;
	while (luaChon != 1 && luaChon != 2)
	{
		cout << "Nhap sai cu phap! Vui long nhap lai";
		cin >> luaChon;
	}
	if (luaChon == 1)
	{
		cout << "Hay nhap vao Ma Khach Hang:\n";
		cin >> MaKhachHangCanTim;
	}
	else
	{
		cout << "Hay nhap vao So Dien Thoai:\n";
		cin >> SDTCanTim;
	}
	cout << "Hay kiem tra file OUTPUT.txt trong may cua ban!\n";
	freopen("OUTPUT.txt", "wt", stdout);
	for (int i = 0; i < DSThueBao.size(); i++)
	{
		if (DSThueBao[i]->LayMaKhachHang() == MaKhachHangCanTim || DSThueBao[i]->LaySDT() == SDTCanTim)
		{
			cout<<"=============THONG TIN KHACH HANG===========\n";
			DSThueBao[i]->Xuat();
			cout << "So tien khach hang phai dong trong 1 thang: " << DSThueBao[i]->TinhTien() << " dong." << endl;
			kiemTra = 1;
			break;
		}
	}
	if (kiemTra!=1)
	{
		cout << "Khong tim thay khach hang!";
	}
}
//Hàm tính tổng số tiền của thuê bao trọn gói bằng cách tìm cách thuê bao bắt đầu bằng chữ T. 
//Sau đó tính  số tiền của từng thuê bao rồi tổng lại
long int CCongTy::TinhTienTBTronGoi()
{
	long int TongTien(0);
	string firstword;
	for (int i = 0; i < DSThueBao.size(); i++)
	{
		firstword = DSThueBao[i]->LayMaKhachHang();
		if (firstword.at(0) == 'T')
		{
			TongTien = TongTien + DSThueBao[i]->TinhTien();
		}
	}
	return TongTien;
}
//Hàm tính tổng số tiền của thuê bao theo dung lượng bằng cách tìm cách thuê bao bắt đầu bằng chữ D. 
//Sau đó tính  số tiền của từng thuê bao rồi tổng lại
long int CCongTy::TinhTienTBDungLuong()
{
	long int TongTien(0);
	string firstword;
	for (int i = 0; i < DSThueBao.size(); i++)
	{
		firstword = DSThueBao[i]->LayMaKhachHang();
		if (firstword.at(0) == 'D')
		{
			TongTien = TongTien + DSThueBao[i]->TinhTien();
		}
	}
	return TongTien;
}
//Hàm xuất ra danh sách khách hàng trả trước kèm số tiền đã trả
void CCongTy::TinhTienKhachHangTraTruoc()
{
	for (int i = 0; i < DSKhachHangTraTruoc.size(); i++)
	{
		DSKhachHangTraTruoc[i]->Xuat();
		cout << "So tien can tra la: " << DSKhachHangTraTruoc[i]->TinhTien() << " dong" << endl;
		cout << "-----\n";
	}
}
//Phương thức khởi tạo của lớp công ty
CCongTy::CCongTy()
{
}
//Phương thức phá huỷ của lớp công ty
CCongTy::~CCongTy()
{
}
//===============

//HÀM TRONG LỚP KHÁCH HÀNG TRẢ TRƯỚC
//Hàm nhập vào thông tin khách hàng trả trước thông qua kế thừa hàm nhập của lớp thuê bao thêm vào số tháng
void CKhachHangTraTruoc::Nhap(int ST,string BienTam)
{
	CThueBao::Nhap(BienTam);
	SoThang = ST;
}
//Hàm xuất ra thông tin 1 khách hàng trả trước
void CKhachHangTraTruoc::Xuat()
{
	cout << MaKhachHang << ", " << HoTen << ", " << SDT << ", " << GoiCuoc << ", " << SoThang << endl;
}
//Hàm tính tiền của từng khách hàng trả trước bằng việc tìm tên gói cước phù hợp, rồi trả về giá tiền tương ứng
long int CKhachHangTraTruoc::TinhTien()
{
	if (LayLoaiGoiCuoc() == "MegaBasic")
	{
		return 250000 * SoThang;
	}
	else if (LayLoaiGoiCuoc() == "MegaEasy")
	{
		return 350000 * SoThang;
	}
	else if (LayLoaiGoiCuoc() == "MegaFamily")
	{
		return 450000 * SoThang;
	}
	else if (LayLoaiGoiCuoc() == "MegaMaxi")
	{
		return 900000 * SoThang;
	}
	else if (LayLoaiGoiCuoc() == "MegaPro")
	{
		return 1400000 * SoThang;
	}
}
//Phương thức khởi tạo của lớp Khách hàng trả trước
CKhachHangTraTruoc::CKhachHangTraTruoc()
{
	SoThang = 0;
}
//Phương thức phá huỷ của lớp Khách hàng trả trước
CKhachHangTraTruoc::~CKhachHangTraTruoc()
{
}