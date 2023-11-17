"use strict"

function VichFunc(firstnumber, secondnumber){
	if(firstnumber == secondnumber)
	{
		return true;
	}
	else 
	{
		return false;
	}

}

let firstnumber, secondnumber;

firstnumber = prompt('Введите первое число:');
secondnumber = prompt('Введите второе число: ');

let result = VichFunc(firstnumber, secondnumber);
alert(result);