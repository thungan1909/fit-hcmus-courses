#pragma once
#include <iostream>

using namespace std;

class Address
{
private:
	string _number;
	string _street;
	string _ward;
	string _district;
	string _city;
public:
	string toString();
	Address(string, string, string, string, string);
	string getStreet();
	string getWard();
	string getDistrict();
};