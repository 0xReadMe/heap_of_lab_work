"use strict"

function SquareMassive(numArr)
{
	let summ = 0;
	for (let i in numArr)
	{
		let square = numArr[i]**2;
		summ += square;
	}
	return summ;
}

let numArr = [10, 20, 30, 40, 50];

let result = SquareMassive(numArr);

document.write(result);
