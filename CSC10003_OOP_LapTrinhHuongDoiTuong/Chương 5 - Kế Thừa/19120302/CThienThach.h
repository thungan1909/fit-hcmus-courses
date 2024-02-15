#pragma once
#include"CHinhTron.h"
class CThienThach :public CHinhTron
{
private:
	string MaThienThach;
	float TocDoBay;
	float ThoiGianCham;
public:
	CThienThach();
	~CThienThach();
	float ThoiGianVaCham();
	void Xuat();
};

