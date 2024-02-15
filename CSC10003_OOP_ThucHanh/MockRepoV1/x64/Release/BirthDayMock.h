#pragma once
#include "Random.h"
#include "DateTime.h"

class BirthDayMock
{
private:
	Random _rng;
	int _maxAge;
	int _currentYear;

public:
	BirthDayMock();
	DateTime next();
};

