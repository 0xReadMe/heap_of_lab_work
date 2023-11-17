"use strict"

function randomInteger(min, max) {
	let rand = min + Math.random() * (max - min);
	return Math.floor(rand);
}



if (confirm('Начинаем игру Угадай число?'))
{
	while (true)
	{
		let number = randomInteger(0, 100);
		alert('Мы загадали число... У тебя есть 10 попыток, чтобы его угадать!');
		let userNum = 0;

		for(let a = 1; a <= 11; a++)
		{
			if (a == 11)
			{
				alert(`Вы истратили все попытки! Это было число: ${number}`)
				break;
			}

			userNum = prompt("Введите ваше число:");

			if (userNum == number)
			{
				alert('Вы победили!');
				break;
			}
			else
			{
				if (userNum > number)
				{
					alert('Вы ввели число, которое больше чем загаданное!');
				}

				if (userNum < number)
				{
					alert('Вы ввели число, которое меньше чем загаданное!');
				}
			}
		}
		if (confirm("Continue?")) 
		{
			continue;
		}
		else 
		{
			break;
		}
	}
}
else
{
	alert('До связи.');
}
