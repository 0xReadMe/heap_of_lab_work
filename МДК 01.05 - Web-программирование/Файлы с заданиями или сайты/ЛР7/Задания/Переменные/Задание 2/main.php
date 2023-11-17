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
    <p>Заданы две пары чисел: (5, 19), (6, 5)</p>
    <?php
        $num1 = 5;
        $num2 = 19;
        $num3 = 6;
        $num4 = 5;

        $min_num1 = min($num1, $num2);
        $min_num2 = min($num3, $num4);
        $max_num = max($min_num1, $min_num2);
        echo "Максимальное число из двух пар минимальных чисел: ".$max_num;
    ?>
</body>
</html>