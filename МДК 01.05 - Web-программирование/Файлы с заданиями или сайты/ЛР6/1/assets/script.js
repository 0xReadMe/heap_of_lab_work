"use strict"

function VichMass(obj){
	let result1, result2;
	let t, m, hcm, hm;

	t = Number(obj.t.value);
	m = Number(obj.m.value);
	hcm = Number(obj.hcm.value);
	hm = Number(obj.hm.value);

	result2 = m/hm**2;
	result2 = result2.toFixed(2);

	document.getElementById('result2').innerHTML = result2;

	result1 = hcm * t/240;
	document.getElementById('result1').innerHTML = result1;
}