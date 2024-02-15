#pragma once
#include "Util.h"
#include <time.h>

class DateTime
{
private:
	int _day, _month, _year;
public:
	string toString();
	DateTime(int, int, int);
	static int currentYear();
	static bool isLeapYear(int);
};