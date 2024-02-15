#pragma once
#include <iostream>
#include <vector>
#include <random>
#include <time.h>

using namespace std;

class Random
{
private:
	static bool _seeded;
public:
	Random();
	int nextInt();
	int nextInt(int ceiling);
	int nextInt(int left, int right);
	static void set_seeded(bool value);
};