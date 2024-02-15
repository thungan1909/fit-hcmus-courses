#include "Integer.h"

int Integer::gcd(int a, int b)
{
	if (b == 0)
		return a;
	return gcd(b, a % b);
}