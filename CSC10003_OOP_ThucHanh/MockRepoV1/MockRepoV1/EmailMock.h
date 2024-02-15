#pragma once
#include "Util.h"
#include "Random.h"
#include "FullNameMock.h"

#pragma warning (disable: 4996)

class EmailMock
{
private:
	Random _rng;
	vector<string> _domains;
	FullNameMock _nameStore;
public:
	string next();
	EmailMock(vector<string>, FullNameMock);
	string next(FullName);
};