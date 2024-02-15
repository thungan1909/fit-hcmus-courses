#include "pch.h"
#include "DynamicArrray.h"

DynamicArrray::DynamicArrray(void)
{
	a = new int[100];
}

DynamicArrray::~DynamicArrray(void)
{
	delete[]a;
}

void DynamicArrray::Input()
{
	cout << "Input n\n";
	cin >> n;
	cout << "Input array\n";
	for (int i = 0; i < n; i++)
	{
		cin >> a[i];
	}
	
}

void DynamicArrray::Output()
{
	cout << "The array is\n";
	for (int i = 0; i < n; i++)
	{
		cout<< a[i];
	}
}
