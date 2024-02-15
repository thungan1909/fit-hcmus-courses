#pragma once
#include<string>
#include<iostream>
#include<fstream>
#pragma warning(disable:4996)
using namespace std;
class CToaDo
{
private:
	float x;
	float y;
public:
	CToaDo();
	~CToaDo();
	float getX();
	float getY();
	void setX(float);
	void setY(float);
};

