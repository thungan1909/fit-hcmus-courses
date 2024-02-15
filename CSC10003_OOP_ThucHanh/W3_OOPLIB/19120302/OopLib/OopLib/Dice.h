#pragma once
#include "Random.h"

class Dice {
	Random rd;
public:
	int roll() // Tra ve ket qua khi giao xuc sac, co gia tri tu 1 den 6
	{
		return rd.nextInt(1, 6);
	}
};

