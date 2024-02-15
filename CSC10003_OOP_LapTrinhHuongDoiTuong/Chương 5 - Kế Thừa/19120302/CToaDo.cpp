#include "CToaDo.h"

CToaDo::CToaDo()
{
	x = y = 0;
}

CToaDo::~CToaDo()
{
}

float CToaDo::getX()
{
	return x;
}

float CToaDo::getY()
{
	return y;
}

void CToaDo::setX(float temp)
{
	x = temp;
}

void CToaDo::setY(float temp)
{
	y = temp;
}
