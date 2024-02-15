#pragma once
#include "Random.h"
#include "FullName.h"

struct NameCombination {
	wstring lastName;
	vector<wstring> availableMiddleName;
};

class FullNameMock
{
private:
	Random _rng;
	vector<wstring> _femaleMiddleNames;
	vector<wstring> _maleLastNames;
	vector<wstring> _maleMiddleNames;
	vector<wstring> _firstNames;
	vector<wstring> _femaleLastNames;
	vector<NameCombination> _nameCommbinations;

public:
	wstring randomFirstName();
	FullName next(bool);
	FullNameMock();
	FullNameMock(vector<wstring>, vector<wstring>, vector<wstring>, vector<wstring>, vector<wstring>);
};