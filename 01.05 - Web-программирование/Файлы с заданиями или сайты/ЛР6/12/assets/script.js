"use strict"

function checkUsername() {                         
  var username = el.value;

  let strnameArr = username.split('');

  let firstletterUP = ucFirst(username)
  let zvezda = null;

  for(let i = 0; i < strnameArr.length; i++)
  {
  	if(strnameArr[i] == '*')
  	{
  		zvezda = true;
  	}
  	else 
  	{
  		zvezda = false;
  	}
  }

  if (username.length < 5 || zvezda !== true || strnameArr[0] !== firstletterUP) {                      
    elMsg.className = 'warning';                  
    elMsg.textContent = 'Пароль слишком короткий или начинается не с заглавной буквы или не содержит *.';
  } else {                                        
    elMsg.textContent = '';
  }
}

function ucFirst(strname)
{
	let strchange = '';
	let strnameArr = strname.split('');
	strnameArr[0] = strnameArr[0].toUpperCase();

	return strnameArr[0]
}

function tipUsername() {                          
  elMsg.className = 'tip';                        
  elMsg.innerHTML = 'Пароль должен содержать не менее 5 символов'; 
}
var el = document.getElementById('password');     
var elMsg = document.getElementById('feedback');  
el.addEventListener('focus', tipUsername, false); 
el.addEventListener('blur', checkUsername, false);
