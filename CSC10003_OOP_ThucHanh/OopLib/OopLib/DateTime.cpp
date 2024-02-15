#include "DateTime.h"

string DateTime::toString()
{
	string str = "";
	str += (_day <= 9 ? "0" : "") + Util::to_string(_day);
	str += "/";
	str += (_month <= 9 ? "0" : "") + Util::to_string(_month);
	str += "/";
	str += Util::to_string(_year);
	return str;
}

DateTime::DateTime(int y, int m, int d)
{
	_day = d;
	_month = m;
	_year = y;
}

int DateTime::currentYear()
{
	time_t t = time(NULL);
	tm now;
	localtime_s(&now, &t);
	return now.tm_year + 1900;
}

bool DateTime::isLeapYear(int year)
{
	return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}
