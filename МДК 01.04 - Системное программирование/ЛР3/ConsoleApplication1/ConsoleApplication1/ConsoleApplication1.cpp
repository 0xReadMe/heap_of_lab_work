#include <iostream>
#include <math.h>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	double A, B, C;
	cout << "Введите A: \n"; cin >> A;
	cout << "Введите B: \n"; cin >> B;
	cout << "Введите C: \n"; cin >> C;

	if (abs(A - B) > abs(A - C)) 
	{
		cout << "Точка C расположена ближе к точке А, и ее расстояние: " << abs(A - C);
	}
	else if(abs(A - B) < abs(A - C))
	{
		cout << "Точка B расположена ближе к точке А,и ее расстояние: " << abs(A - B);
	}
	else 
	{
		cout << "Расстояние между точками одинаковое.";
	}
	return 0;
}
