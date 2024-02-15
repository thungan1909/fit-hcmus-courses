#pragma once
#include <iostream>
#include <ctime>
#include <vector>
using namespace std;
class Random 
{
public:
	Random()
	{
		srand(time(NULL));
	}
	int RandInt(int,int);  //Ham khoi tao so ngau nhien trong 1 khoang [left:right]
};