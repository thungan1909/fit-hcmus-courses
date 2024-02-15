#pragma once
#include "Telephone.h"
#include "Random.h"

class TelephoneMock
{
private:
	vector<MobileNetwork> _supportedNetworks;
	Random _rng;
public:
	Telephone next();
	TelephoneMock();
};

