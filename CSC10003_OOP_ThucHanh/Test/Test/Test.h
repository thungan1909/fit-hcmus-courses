#pragma once
#include "RandomYear.h"
#include "EnglishVocabulary.h"
#include "Fraction.h"
#include "FullNameMock.h"
#include "BirthDayMock.h"
#include "TelephoneMock.h"
#include "CitizenIdMock.h"
#include "EmailMock.h"
#include "Dice.h"
#include "Integer.h"
#include "HcmAddressMock.h"
#include "DynamicArray.h"
#include <io.h>
#include <fcntl.h>

#pragma warning (disable: 4996)
#pragma warning (disable: 6031)

vector<wstring> readOneLineToVector(wifstream& in);

void readNames(vector<wstring>&, vector<wstring>&, vector<wstring>&, vector<wstring>&, vector<wstring>&);

void readDomains(vector<string>&);

void readAddress(vector<string>&, vector<string>&, vector<string>&);

void readCityCodes(vector<string>&, vector<string>&);