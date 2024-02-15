#include "pch.h"
#include "Random.h"
bool Random::_seeded = false;
Random::Random()
{
	srand(time(NULL));
	_seeded = true;
}
int Random::nextInt()
{
	if (_seeded == false)  //Neu _seeded = false thi khong can khoi tao hat giong
	{
		srand(time(NULL));
		_seeded = true;
	}
	return rand(); //Tra ve 1 so nguyen
}

int Random::nextInt(int ceiling)
{
	if (!_seeded) //Neu _seeded = false thi khong can khoi tao hat giong
	{
		srand(time(NULL));
		_seeded = true;
	}
	return rand() % ceiling; //tra ra 1 so  nguyen tu  0 - ceiling - 1
}

int Random::nextInt(int left, int right) {
	if (_seeded == false)//Neu _seeded = false thi khong can khoi tao hat giong 
	{
		srand(time(NULL));
		_seeded = true;
	}

	return rand() % (right - left + 1) + left; //Tra ra 1 so nguyen trong doan [left,right]
}