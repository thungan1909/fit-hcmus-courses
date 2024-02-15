#include "CThienThach.h"

void CThienThach::Xuat()
{
	cout << MaThienThach << " " << ThoiGianCham;
}

CThienThach::CThienThach()
{

	TocDoBay = 0;
	MaThienThach = '0';
}

CThienThach::~CThienThach()
{
}
float CThienThach::ThoiGianVaCham()
{
	string temp;
	getline(cin, temp);
	int first = temp.find_first_of(' ');
	MaThienThach = temp.substr(0, first);
	int SpaceLast = temp.find_last_of(' ');
	TocDoBay = stof(temp.substr(SpaceLast + 1));
	CHinhTron::Nhap(temp);
	float tempX = Tam.getX();
	float tempY = Tam.getY();
	//Tinh Khoang Cach Tu Thien Thach Den Trai Dat
	float KhoangCach(0);
	KhoangCach = sqrt(pow(tempX, 2) + pow(tempY, 2)) - BanKinh;
	//Tinh Thoi Gian Va Cham

	ThoiGianCham = KhoangCach / TocDoBay;
	return ThoiGianCham;
}
