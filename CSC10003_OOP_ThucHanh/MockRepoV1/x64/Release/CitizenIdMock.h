#pragma once
#include "Random.h"
#include <fstream>
#include <sstream>

class CitizenIdMock
{
private:
	Random _rng;
	vector<string> _cityCodes;
	vector<string> _cityNames;
	int _maxAge;
	int _currentYear;

public:
	CitizenIdMock(vector<string>, vector<string>);
	string next();
	string lookUp(string);
};

