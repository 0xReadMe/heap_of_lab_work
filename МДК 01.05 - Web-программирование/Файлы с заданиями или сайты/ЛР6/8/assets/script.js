"use strict"

function ucFirst(strname)
{
	let strchange = '';
	let strnameArr = strname.split('');
	strnameArr[0] = strnameArr[0].toUpperCase();

	for(let i in strnameArr)
	{
		strchange += strnameArr[i];
	}
	return strchange;
}

let stringname  = 'ем еду пью воду жую жвачку люблю ассемблер';
let strArr = stringname.split(' ');

for (let i in strArr) 
{
	let result = ucFirst(strArr[i]);
	document.write(result + ' ');
}
