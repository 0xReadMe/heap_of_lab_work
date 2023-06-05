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
        $arr3 = [155, -22, 56, -5, 78];
        $sum= 0;
        foreach($arr3 as $elem)
        {
            if($elem > 0)
            {
                $sum += $elem;
            }
        }
        echo "Сумма положительных элементов: ".$sum."<br>";
    ?>
</body>
</html>