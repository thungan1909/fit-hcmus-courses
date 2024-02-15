#pragma once
#include <iostream>
#include <vector>
#include <fstream>
#include <string>
#include <codecvt>
#include <sstream>

using namespace std;

class FullName
{
private:
	wstring _firstName;
	wstring _middleName;
	wstring _lastName;
public:
	wstring toString();
	FullName(wstring, wstring, wstring);
	wstring firstName();
	wstring middleName();
	wstring lastName();
};