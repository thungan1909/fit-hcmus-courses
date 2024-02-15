#pragma once
#include <iostream>

using namespace std;

class DynamicArray
{
private:
	int* arr;
	int n;
public:
	void input();
	void output();
	int getElement(int);
	void setElement(int, int);
	int length();
	DynamicArray();
	DynamicArray(int);
	~DynamicArray();
};