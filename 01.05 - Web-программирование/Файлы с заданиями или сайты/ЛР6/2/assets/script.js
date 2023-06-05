"use strict"

function Formula(obj){
	let y;
	let x, x1, x2, x3, x4;

	x = Number(obj.x.value); // x

	let cos = Math.cos(x);

	x1 = x + (cos**2); // первое подкоренное выражение
	if (x1 < 0) {
		alert(`В корне содержится отрицательное число!`);
	}
	else {
		x2 = Math.sqrt(x1); // корень первого подкоренного выражения
		x3 = x**3+3 // второе подкоренное выражение

		if (x3 < 0) {
			alert(`В корне содержится отрицательное число!`);
		}
		else 
		{
			x4 = Math.sqrt(x3); // корень второго подкоренного выражения

			if (x4 == 0){
				alert(`В знаменателе 0`);
			}
			else{
				y = x2/x4; // деление первого выражения на второе
				document.getElementById('result').innerHTML = y;
			}
		}
	}
}