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
    <p>Среди всех 2-значных чисел указать те, сумма цифр которых равна данному числу k = 7.</p>
    <?php
        $arr4 =[
            'ru'=>[
                1=>'Понедельник',
                2=>'Вторник',
                3=>'Среда',
                4=>'Четверг',
                5=>'Пятница',
                6=>'Суббота',
                7=>'Воскресенье'],
            'en'=>[
                1=>'Monday', 
                2=>'Tuesday',  
                3=>'Wednesday', 
                4=>'Thursday', 
                5=>'Friday', 
                6=>'Saturday', 
                7=>'Sunday']];
        echo $arr4['ru'][1]."<br>";
        echo $arr4['en'][3]."<br>";
        $lang = 'ru';
        $day = 3; 
        echo $arr4[$lang][$day]."<br>";
    ?>
</body>
</html>