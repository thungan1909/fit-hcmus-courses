#pragma once
#include <ctime>
#include<iostream>
using namespace std;

class Random
{
	static bool _seeded;

public:
	Random();
	int nextInt();
	int nextInt(int ceiling);
	int nextInt(int left, int right);
};
