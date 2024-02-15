#include "Integer.h"
#include"Random.h"
#include "Fratction.h"

int main() {
	Random rd;
	Fratction Tong, ps;
	int n = rd.nextInt(5, 20);
	cout << "Phat sinh ngau nhien so nguyen n ( 5 <= n <= 20) " << n <<endl;
	cout << "Ta co n phan so sinh ra\n ";
	for (int i = 0; i < n;i++)
	{
		ps = Fratction::PhatSinhSo();
		Tong = Tong + ps;
		cout <<"Phan so thu  "<<i+1<<": "<< ps <<endl;
	}
	cout << "Tong cua cac phan so tren la " <<Tong<<endl;
	return 0;
}