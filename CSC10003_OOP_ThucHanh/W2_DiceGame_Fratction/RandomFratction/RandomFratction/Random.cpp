#include "Random.h"

bool Random::_seeded = false;
Random::Random() 
{
	srand(time(NULL));
	_seeded = true;
};
int Random::nextInt() {
	if (_seeded==false)
	{
		srand(time(NULL));
		_seeded = true;
	}
	return rand();
}

int Random::nextInt(int ceiling) {
	if (_seeded==false) 
	{
		srand(time(NULL));
		_seeded = true;
	}
	return rand() % ceiling;
}

int Random::nextInt(int left, int right) 
{
	if (_seeded==false)
	{
		srand(time(NULL));
		_seeded = true;
	}
	return rand() % (right - left + 1) + left;
}