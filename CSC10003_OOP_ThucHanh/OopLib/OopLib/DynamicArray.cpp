#include "DynamicArray.h"

void DynamicArray::input()
{
	do {
		cout << "Nhap do dai mang: ";
		cin >> n;
		if (n <= 0) cout << "\nDo dai mang phai > 0" << endl;
	} while (n <= 0);
	arr = new int[n];
	for (int i = 0; i < n; i++) {
		cout << "Nhap arr[" << i << "]: ";
		cin >> arr[i];
	}
}

void DynamicArray::output()
{
	for (int i = 0; i < n; i++)
		cout << arr[i] << ' ';
}

int DynamicArray::getElement(int i)
{
	return arr[i];
}

void DynamicArray::setElement(int i, int val)
{
	arr[i] = val;
}

int DynamicArray::length()
{
	return n;
}

DynamicArray::DynamicArray()
{
	n = 0;
	arr = nullptr;
}

DynamicArray::DynamicArray(int _n)
{
	n = _n;
	arr = new int[n];
}

DynamicArray::~DynamicArray()
{
	if (arr != nullptr)
		delete[] arr;
}
