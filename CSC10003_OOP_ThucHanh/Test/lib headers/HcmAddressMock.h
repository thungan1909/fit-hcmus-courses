#pragma once
#include "Util.h"
#include "Random.h"
#include "Address.h"

#pragma warning (disable: 4996)

class HcmAddressMock
{
private:
	Random _rng;
	vector<string> _streets;
	vector<string> _wards;
	vector<string> _districts;
	vector<string> _cities;
public:
	HcmAddressMock(vector<string>, vector<string>, vector<string>);
	Address next();
};

