#include"CThienThach.h"

int main()
{
	CThienThach TT, temp;
	float ThoiGianNhoNhat, ThoiGianTam;
	ThoiGianNhoNhat = INT_MAX;
	freopen("INPUT.txt", "rt", stdin);
	freopen("OUTPUT.txt", "wt", stdout);
	while (!cin.eof())
	{
		ThoiGianTam = TT.ThoiGianVaCham();
		if (ThoiGianTam < ThoiGianNhoNhat)
		{
			ThoiGianNhoNhat = ThoiGianTam;
			temp = TT;
		}
	}

	temp.Xuat();
}