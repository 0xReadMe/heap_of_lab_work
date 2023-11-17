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
    <p>Заданы координаты трех вершин треугольника (1, 2), (3, 4) и (5, 6).</p>
    <?php
        $x1 = 1;
        $y1 = 2;
        $x2 = 3;
        $y2 = 4;
        $x3 = 5;
        $y3 = 6;
        $a = sqrt(pow($x2 - $x1, 2) + pow($y2 - $y1, 2));
        $b = sqrt(pow($x3 - $x2, 2) + pow($y3 - $y2, 2));
        $c = sqrt(pow($x1 - $x3, 2) + pow($y1 - $y3, 2));
        $p = $a + $b + $c;
        $h = $p / 2;
        $s = ($a * $h)/2;
        echo "<p> Периметр = ".$p;
        echo "<p> Площадь = ".$s;
    ?>
</body>
</html>