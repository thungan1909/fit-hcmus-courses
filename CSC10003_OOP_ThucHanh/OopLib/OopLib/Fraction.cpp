#include "Fraction.h"

Fraction::Fraction()
{
	numerator = 0;
	denominator = 1;
}

Fraction Fraction::randomFraction()
{
	numerator = r.nextInt(20);
	denominator = r.nextInt(1, 20);
	return *this;
}

Fraction Fraction::operator+(Fraction fractionB)
{
	this->numerator = numerator * fractionB.denominator + fractionB.numerator * denominator;
	this->denominator *= fractionB.denominator;
	return *this;
}

void Fraction::reduceFraction()
{
	int GCD = Integer::gcd(numerator, denominator);
	numerator /= GCD;
	denominator /= GCD;
}

void Fraction::setterFraction(Fraction fraction)
{
	numerator = fraction.numerator;
	denominator = fraction.denominator;
}

ostream& operator<<(ostream& os, Fraction& fraction)
{
	if (fraction.denominator < 0)
	{
		fraction.numerator = -fraction.numerator;
		fraction.denominator = -fraction.denominator;
	}
	os << fraction.numerator << "/" << fraction.denominator;
	return os;
}
