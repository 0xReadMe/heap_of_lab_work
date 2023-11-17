"use strict"

let a = Number(prompt('Введите значение а '));
let b = Number(prompt('Введите значение b '));
let n = 10;
let h, F;

h = (b-a)/n

document.write('<table> <tr> <th>X</th> <th> F(x)</th> </tr>');
for(let x = a; x <= b; x+=h)
{  
    F = 2 * Math.pow(x, 3) - 4 * x**2 + 12;
    document.write('<tr> <td>' + x.toFixed(1) + '</td> <td>' + F.toFixed(2) + '</td> </tr>');
}
