<!DOCTYPE html>
<html>
<head>
<meta charset = "UTF-8">
</head>
<style>
    p {font-size: 20px;
        font-family: Arial, Helvetica, sans-serif;
        color: rgb(13, 0, 47);}
</style>
<title>Переменные 1</title>
<body>
    <?php
        $arr3 =[1=>'Понедельник', 2=>'Вторник',  3=>'Среда', 4=>'Четверг', 5=>'Пятница', 6=>'Суббота', 7=>'Воскресенье'];
        print ("Текущий день недели: ");
        echo $arr3[6]."<br>";
    ?>
</body>
</html>