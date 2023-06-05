"use strict"

let V = prompt('Введите количество конфет ');
if(V > 0 && V < 100)
{
	if (V > 9 && V < 21) 
	{
		document.write("Ваня съел "+ V +" конфет")
	}
	else
	{
		if ((V % 10 == 1 || V == 1) && V != 11) 
		{
			document.write("Ваня съел "+ V +" конфету")
		}
		else 
		{
			if ((V % 10 > 1 && V % 10 < 5) && V != 12 && V != 13 && V != 14)
			{
				document.write("Ваня съел "+ V +" конфеты")
			}
			else 
			{
				if ((V % 10 > 4 && V % 10 < 10) && V != 15 && V != 16 && V != 17 && V != 18 && V != 19 && V != 20)
				{
					document.write("Ваня съел "+ V +" конфет")
				}
			}
		}
	}
}
else
{
    document.write("Неверное число конфет");
}
