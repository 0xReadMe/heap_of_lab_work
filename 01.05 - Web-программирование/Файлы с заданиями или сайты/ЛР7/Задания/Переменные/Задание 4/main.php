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
        $n = 2;
        $k = 7;

        for($i = 10; $i < 100; $i++)
        {
            $one = $i % 10;
            $ten = ($i / 10)%10;
            $check = $one + $ten;
            
            if($check == $k)
            {
                echo "Найдено число, сумма цифр которого равна k: ".$i."<br>";
            }
        }
    ?>
</body>
</html>