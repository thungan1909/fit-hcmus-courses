#include "BirthDayMock.h"

BirthDayMock::BirthDayMock()
{
	_maxAge = 120;
	_currentYear = DateTime::currentYear();
}

DateTime BirthDayMock::next()
{
	int year = _currentYear - _rng.nextInt(_maxAge);
	int month = _rng.nextInt(1, 12);

	int dayMax;
	if (month == 2)
		dayMax = DateTime::isLeapYear(year) ? 29 : 28;
	else if (month <= 7)
		dayMax = month % 2 == 0 ? 30 : 31;
	else
		dayMax = month % 2 == 0 ? 31 : 30;

	int day = _rng.nextInt(1, dayMax);
	DateTime dob(year, month, day);
	return dob;
}
