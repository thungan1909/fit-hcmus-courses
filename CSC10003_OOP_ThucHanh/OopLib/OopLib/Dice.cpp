#include "Dice.h"

int Dice::roll()
{
	return r.nextInt(1, 6);
}