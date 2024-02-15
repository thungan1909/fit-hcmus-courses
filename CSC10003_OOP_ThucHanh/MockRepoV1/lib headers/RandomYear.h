#pragma once
#include "Random.h"

class RandomYear
{
private:
	Random r;
public:
	void showYears();
	bool isLeapYear(int);
};