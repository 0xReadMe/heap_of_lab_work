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
<title>Задание 3</title>
<body>
    <p></p>
    <?php
        $arr4 = [
            1=>'Понедельник', 
            2=>'Вторник',  
            3=>'Среда', 
            4=>'Четверг', 
            5=>'Пятница', 
            6=>'Суббота', 
            7=>'Воскресенье'];
        foreach($arr4 as $elem)
        {
            if($elem == 'Суббота' || $elem == 'Воскресенье')
            {
                echo "<b>".$elem."</b>"."<br>";
            }
            else{
                echo $elem."<br>";
            }
        }        
    ?>
</body>
</html>