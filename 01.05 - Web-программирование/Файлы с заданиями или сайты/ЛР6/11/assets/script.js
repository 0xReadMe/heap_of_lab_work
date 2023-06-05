"use strict"

function Formula(){
	let a, b;
	let resultP, resultS;

	a = Number(document.getElementById('a').value);
	b = Number(document.getElementById('b').value);

	resultP = (a + b) * 2;
	resultS = a * b;

	if (a < 0 || b < 0)
	{
		confirm("Нужно ввести стороны больше 0!");
		location.reload()
	}

	document.getElementById('resultP').textContent = resultP;
	document.getElementById('resultS').textContent = resultS;
	
}

document.getElementById('bttn').onclick = Formula;