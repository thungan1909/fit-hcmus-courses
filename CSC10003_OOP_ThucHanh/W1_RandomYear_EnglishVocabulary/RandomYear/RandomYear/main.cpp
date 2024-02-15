#include "Random.h"

bool IsLeapYear(int year) {
	if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
	{
		return true;
	}
	else return false;
}
void RandomYear(std::vector<int>& randYears, const int& n) 
{
	Random* rd = new Random();
	int year;
	for (int i = 0; i < n;i++) {
		year = rd->RandInt(1900, 2021);
		randYears.push_back(year);
	}
	delete rd;
}
int countLeapYears(std::vector<int> randYears) {
	int count = 0;

	for (int i = 0; i < randYears.size();i++) {
		if (IsLeapYear(randYears[i])) 
		{
			cout << "Leap Year:" << randYears[i] << endl;
			count++;
		}
	}
	return count;
}
int main()
{
	Random* rd = new Random();  //Khoi tao
	int n = rd->RandInt(5, 20); 
	cout << "a. Generating a integer number n in [5;20]: " << n << endl;
	delete rd;

	vector<int> randYears;
	RandomYear(randYears, n);  //Tu n da tim duoc o tren, ta se phat sinh ra n nam (nam >=1900)
	cout << "b. Generating n years from 1900:\n";
	for (int i = 0; i < randYears.size(); ++i)
	{
		cout << randYears[i] << endl;
	}
	cout << endl;
	cout << "\n c. Leap years from the generated years: " << countLeapYears(randYears) << "(years)\n";
	return 0;
}
