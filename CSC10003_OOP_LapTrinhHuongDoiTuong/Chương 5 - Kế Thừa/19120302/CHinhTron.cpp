#include"CHinhTron.h"

CHinhTron::CHinhTron()
{
	BanKinh = 0;
}

CHinhTron::~CHinhTron()
{
}

void CHinhTron::Nhap(string temp)
{
	string temp1;
	int count(0);
	int first = temp.find_first_of('(');
	int mid = temp.find_first_of(',');
	int last = temp.find_first_of(')');
	int SpaceLast = temp.find_last_of(' ');
	count = mid - first - 1;
	temp1 = temp.substr(first + 1, count);

	Tam.setX(stof(temp1));
	count = last - mid - 1;
	temp1 = temp.substr(mid + 1, count);

	Tam.setY(stof(temp1));
	count = SpaceLast - last + 1;
	BanKinh = stof(temp.substr(last + 2, count));
}
