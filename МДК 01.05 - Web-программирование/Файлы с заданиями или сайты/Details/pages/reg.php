<!DOCTYPE html>
<html>
    <head>
    	<title>Студия Детали</title>
    	<link rel="shortcut icon" href="images/fa.png" type="image/x-icon">
    	<link rel="stylesheet" type="text/css" href="../css/main.css">
    </head>
    <body>
        <?php
        	require ("header.php");
        ?>
        	<main>
        		<div class="conteiner">            
        			<div class="h"><h1>Регистрация</h3></div>
        			<table>
                            <div class="con">
                                <form action="" method="POST" >
                                Введите Имя: <input placeholder="Ваше имя" type="text" name="name"><br>
                                Введите Логин: <input placeholder="Ваш логин" type="text" name="log"><br>
                                Введите Пароль: <input name="textarea" type="password" placeholder="Ваш пароль"><br>
                                <input type="submit"><br>
                                </form>
                            </div>
                            <?php
                            require ("connect.php");
        			        mysqli_set_charset($connect, 'utf8');      

                            if (isset($_POST['name'])) {
                                $name = strip_tags($_POST['name']); 
                                $log = strip_tags($_POST['log']); 
                                $textarea = strip_tags($_POST['textarea']); 
                            
                                if (mysqli_query($connect, "INSERT INTO users (Login, Password, FIO) VALUES ('$log', '$textarea', '$name')") ) 
                                {
                                    echo '<p>Данные успешно обработаны добавлены в таблицу.</p>';
                                }
                                else
                                {
                                    echo mysqli_error($connect);
                                }         
                            }              
                            ?>

        			</table>
        		</div>
        		<div class="solution"></div>
        	</main>
        <?php
        	require("footer.php");
        ?>
