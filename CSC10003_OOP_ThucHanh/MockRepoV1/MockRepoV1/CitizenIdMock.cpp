#include "CitizenIdMock.h"

CitizenIdMock::CitizenIdMock(vector<string> cityCodes, vector<string> cityNames)
{
	_cityCodes = cityCodes;
	_cityNames = cityNames;

	_maxAge = 120;

	time_t t = time(NULL);
	tm now;
	localtime_s(&now, &t);
	_currentYear = now.tm_year + 1900;
}

string CitizenIdMock::next() {
	stringstream writer;
	string cityCode = _cityCodes[_rng.nextInt(_cityCodes.size())];

	int century = _currentYear / 100 + 1;

	int male = _rng.nextInt(2);
	int gender = (century - 20) * 2 + male;

	int birthYear = (_currentYear - _rng.nextInt(_maxAge)) % 100;
	writer << cityCode << gender;
	writer << (birthYear < 10 ? "0" : "") << birthYear;

	for (int i = 1; i <= 6; i++)
		writer << _rng.nextInt(10);

	string id = writer.str();
	return id;
}

string CitizenIdMock::lookUp(string code)
{
	int i;
	for (i = 0; i < _cityCodes.size(); i++)
		if (_cityCodes[i] == code)
			break;

	return _cityNames[i];
}