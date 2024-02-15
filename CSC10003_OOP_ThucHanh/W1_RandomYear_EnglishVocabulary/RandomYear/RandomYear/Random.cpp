#include "Random.h"
int Random::RandInt(int left, int right)
{
	return rand() % (right - left + 1) + left;
}