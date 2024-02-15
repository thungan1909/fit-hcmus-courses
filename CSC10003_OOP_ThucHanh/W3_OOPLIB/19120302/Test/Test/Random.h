#pragma once
#include<iostream>
#include <ctime>
using namespace std;

class Random
{
	static bool _seeded; //Thuoc tinh tinh bool _seeded: Cho biet da khoi tao hat giong hay chua
public:
	Random();
	int nextInt();
	int nextInt(int ceiling);
	int nextInt(int left, int right);
};


