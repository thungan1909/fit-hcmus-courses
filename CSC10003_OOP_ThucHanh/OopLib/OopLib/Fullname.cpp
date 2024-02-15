#include "FullName.h"

wstring FullName::toString()
{
	return _firstName + L" " + _middleName + L" " + _lastName;
}

FullName::FullName(wstring first, wstring middle, wstring last)
{
	_firstName = first;
	_middleName = middle;
	_lastName = last;
}

wstring FullName::firstName()
{
	return _firstName;
}

wstring FullName::middleName()
{
	return _middleName;
}

wstring FullName::lastName()
{
	return _lastName;
}
