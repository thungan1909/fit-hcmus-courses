#include "HcmAddressMock.h"

HcmAddressMock::HcmAddressMock(vector<string> streets, vector<string> wards, vector<string> districts)
{
	_streets = streets;
	_wards = wards;
	_districts = districts;
	_cities = { "Ho Chi Minh City" };
}

Address HcmAddressMock::next()
{
	string number = Util::to_string(_rng.nextInt(100));

	int i = _rng.nextInt(_streets.size());
	string street = _streets[i];
	string ward = _wards[i];	//real ward
	string district = _districts[i];	//real district

	i = _rng.nextInt(_cities.size());
	string city = _cities[i];

	Address address(number, street, ward, district, city);
	return address;
}