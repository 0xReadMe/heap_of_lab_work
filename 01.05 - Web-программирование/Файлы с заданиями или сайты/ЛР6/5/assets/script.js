"use strict"

let a, b, n;

document.write('<table> ');
for(a = 1; a <= 10; a++)
{
    if (a == 1) 
    {
        document.write('<th colspan="5">');
        document.write('Таблица умножения');
        document.write('</th>');
    }

    document.write('<tr>');
    for(b = 1; b <= 5; b++)
    {  
    document.write('<td>');
    n = a * b;
    document.write(b + '*' + a + '=' + n);
    document.write('</td>');
    }   
    document.write('</tr>');   
}

document.write('</table>');
document.write('<table>');

for(a = 1; a <= 10; a++)
{        
    document.write('<tr>');    
    for(b = 6; b <= 10; b++)
    {  
    
    document.write('<td>');
    n = a * b;
    document.write(b + '*' + a + '=' + n);
    document.write('</td>');
    }   
    document.write('</tr>');
}
document.write('</table>');

