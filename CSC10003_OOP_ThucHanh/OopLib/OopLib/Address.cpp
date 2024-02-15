#include "Address.h"

string Address::toString()
{
	string str = _number + " " + _street + ", " + _ward + ", " + _district + ", " + _city;
	return str;
}

Address::Address(string n, string s, string w, string d, string c)
{
	_number = n;
	_street = s;
	_ward = w;
	_district = d;
	_city = c;
}

string Address::getStreet()
{
	return _street;
}

string Address::getWard()
{
	return _ward;
}

string Address::getDistrict()
{
	return _district;
}
