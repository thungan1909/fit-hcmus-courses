#include <iostream>
#include <cstring>
#include <ctime>
using namespace std;
int main()
{
	string English[] = { "Accountant", "Businessman", "Director", "Manager", "Secretary", "Dentist", "Doctor", "Nurse", "Actor","Artist" };
	string Vietnamese[] = { "Ke Toan", "Doanh nhan", "Giam doc", "Quan Li", "Thu Ki", "Nha Si", "Bac Si", "Y ta", "Dien Vien","Hoa si" };
	cout << "Please press ENTER to learn a new vocalbulary!\n";
	cout << "Press another key to exit\n";
	int i;
	char c = getchar();
	srand(time(NULL));
	while ((int)c == 10) {
		i = rand() % 9;
		cout << English[i] << ": " << Vietnamese[i] << endl;
		c = getchar();
	};
	return 0;
}