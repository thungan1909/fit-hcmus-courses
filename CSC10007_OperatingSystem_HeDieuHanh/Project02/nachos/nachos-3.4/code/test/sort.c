#include "syscall.h"
//bubble sort

int main()
{
    int intArray[100]; //Mang so nguyen
    int i;             //Bien dem
    int j;             //Bien dem 2
    int temp;          //Bien tam
    int n;             //So phan tu mang

    PrintString("Nhap kich co mang n (n>0 va n <=100): ");
    n = ReadInt();
    if (n <= 100 && n > 0)
    {
        PrintString("\nSo n ban vua nhap la: ");
        PrintInt(n);
        PrintString("\nNhap vao mang so nguyen co n phan tu: \n");
        for (i = 0; i < n; i++)
        {
            intArray[i] = ReadInt();
        }
        PrintString("\nMang vua nhap la: \n");
        for (i = 0; i < n; i++)
        {
            PrintString("Phan tu thu ");
            PrintInt(i);
            PrintString(" la: ");
            PrintInt(intArray[i]);
            PrintString("\n");
        }
        PrintString("\n Bubble Sort \n");
        for (i = 0; i < n - 1; i++)
        {
            for (j = 0; j < n - i - 1; j++)
            {
                if (intArray[j] > intArray[j + 1])
                {
                    temp = intArray[j];
                    intArray[j] = intArray[j + 1];
                    intArray[j + 1] = temp;
                }
            }
        }
        PrintString(" Mang sau khi sort la: \n");
        for (i = 0; i < n; i++)
        {
            PrintString("Phan tu thu ");
            PrintInt(i);
            PrintString(" la: ");
            PrintInt(intArray[i]);
            PrintString("\n");
        }
    }
	else
		PrintString("\nInput khong hop le!");
}

