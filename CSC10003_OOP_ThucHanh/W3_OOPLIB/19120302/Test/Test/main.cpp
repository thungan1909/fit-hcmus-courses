#include"OopLib.h"
#include<iostream>
using namespace std;
int main()
{
	Random Rd;
	Dice dice;
	int SumOfDiceResult(0);
	int result;
	int n;
	cout << "Day la ham test cac class\n";
	cout << "Xuat ra so ngau nhien n\n";

	n=Rd.nextInt(2, 6);
	cout << n;
	// Gieo xuc sac n lan
	cout << "\nKet qua gieo xuc sac:\n";

	for (int i = 0; i < n; ++i)
	{
		result = dice.roll();
		SumOfDiceResult += result;

		cout << "Lan gieo thu " << i + 1 << ": " << result << endl;
	}
	cout << "\nTong diem cua cac lan gieo: " << SumOfDiceResult << endl;

	cout << "\nTao ra 1 phan so ngau nhien\n";
	int TuSo = Rd.nextInt(0, 10);
	int MauSo = Rd.nextInt(1, 20);
	cout << "Phan So do la: " << TuSo << "/" << MauSo << endl;
		int GCDivisor = Integer::gcd(TuSo, MauSo);
		TuSo /= GCDivisor;
		MauSo /= GCDivisor;
		cout << "Phan so do sau khi rut gon: "<<TuSo << "/" << MauSo << endl;
	return 0;
}