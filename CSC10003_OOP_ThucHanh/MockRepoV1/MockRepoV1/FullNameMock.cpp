#include "FullNameMock.h"

wstring FullNameMock::randomFirstName()
{
	wstring firstname = L"";
	int value = _rng.nextInt(1000);
	if (value <= 5)
		firstname = _firstNames[15];
	else if (value <= 15)
		firstname = _firstNames[14];
	else if (value <= 28)
	{
		int temp = _rng.nextInt(2);
		temp == 1 ? firstname = _firstNames[13] : firstname = _firstNames[12];
	}
	else if (value <= 42)
		firstname = _firstNames[11];
	else if (value <= 62)
		firstname = _firstNames[10];
	else if (value <= 83)
		firstname = _firstNames[9];
	else if (value <= 122)
	{
		int temp = _rng.nextInt(2);
		temp == 1 ? firstname = _firstNames[8] : firstname = _firstNames[7];
	}
	else if (value <= 167)
		firstname = _firstNames[6];
	else if (value <= 218)
	{
		int temp = _rng.nextInt(2);
		temp == 1 ? firstname = _firstNames[5] : firstname = _firstNames[4];
	}
	else if (value <= 288)
		firstname = _firstNames[3];
	else if (value <= 383)
		firstname = _firstNames[2];
	else if (value <= 504)
		firstname = _firstNames[1];
	else
		firstname = _firstNames[0];
	return firstname;
}

FullName FullNameMock::next(bool male)
{
	wstring chosenFirstName = randomFirstName();
	wstring chosenMiddleName, chosenLastName;

	if (male)
		chosenLastName = _maleLastNames[_rng.nextInt(_maleLastNames.size())];
	else
		chosenLastName = _femaleLastNames[_rng.nextInt(_femaleLastNames.size())];

	for (int i = 0; i < _nameCommbinations.size(); i++) {
		if (_nameCommbinations[i].lastName == chosenLastName) {
			chosenMiddleName = _nameCommbinations[i].availableMiddleName[
				_rng.nextInt(_nameCommbinations[i].availableMiddleName.size())];

			return FullName(chosenFirstName, chosenMiddleName, chosenLastName);
		}
	}

	if (male)
		chosenMiddleName = _maleMiddleNames[_rng.nextInt(_maleMiddleNames.size())];
	else
		chosenMiddleName = _femaleMiddleNames[_rng.nextInt(_femaleMiddleNames.size())];

	return FullName(chosenFirstName, chosenMiddleName, chosenLastName);
}

FullNameMock::FullNameMock() {}

FullNameMock::FullNameMock(vector<wstring> firstNames, vector<wstring> maleMiddleNames, vector<wstring> maleLastNames, vector<wstring> femaleMiddleNames, vector<wstring> femaleLastNames)
{
	_firstNames = firstNames;
	_maleMiddleNames = maleMiddleNames;
	_maleLastNames = maleLastNames;
	_femaleMiddleNames = femaleMiddleNames;
	_femaleLastNames = femaleLastNames;

	_nameCommbinations.push_back({ L"An", {L"Tuấn", L"Minh", L"Thanh", L"Thế"} });
	_nameCommbinations.push_back({ L"Bảo", {L"Đức", L"Duy", L"Thế", L"Hữu", L"Hoàng"} });
	_nameCommbinations.push_back({ L"Anh", {L"Tuấn", L"Minh", L"Thế", L"Quốc", L"Hoàng"} });
	_nameCommbinations.push_back({ L"Hải", {L"Đức", L"Minh", L"Anh"} });
	_nameCommbinations.push_back({ L"Duy", {L"Minh", L"Công", L"Quốc", L"Anh"} });
}
