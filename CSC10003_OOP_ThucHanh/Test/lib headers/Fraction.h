#pragma once
#include "Integer.h"
#include "Random.h"

class Fraction
{
private:
	Random r;
	int numerator, denominator;
public:
	Fraction();
	Fraction randomFraction();
	Fraction operator+(Fraction fractionB);
	void reduceFraction();
	void setterFraction(Fraction fraction);
	friend ostream& operator<<(ostream& os, Fraction& fraction);
};