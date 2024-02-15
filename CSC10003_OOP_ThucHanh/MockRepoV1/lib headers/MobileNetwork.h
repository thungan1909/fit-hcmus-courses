#pragma once
#include <iostream>
#include <vector>
#include <sstream>

using namespace std;

class MobileNetwork
{
private:
	string _name;
	vector<string> _prefixes;
public:
	string name();
	vector<string> prefixes();
	MobileNetwork();
	MobileNetwork(string, vector<string>);
};