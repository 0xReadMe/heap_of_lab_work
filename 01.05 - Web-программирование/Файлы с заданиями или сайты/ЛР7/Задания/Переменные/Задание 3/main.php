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
    <p>Подсчитать количество отрицательных чисел среди чисел а, b, c, где a = -5, b = 10, c = -15</p>
    <?php
        $array_num = array(-5, 10, -15);
        
        $count = 0;

        for($i = 0; $i < count($array_num); $i++)
        {
            if($array_num[$i] < 0)
            {
                $count++;
            }
        }
        echo "Количество отрицательных чисел: ".$count;
    ?>
</body>
</html>