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
        $num = "12345";
        $char_array = str_split($num);
        $restult = 0;
        for($i = 0; $i < count($char_array); $i++)
        {
            $restult += (int)$char_array[$i];
        }
        echo $restult;
    ?>
</body>
</html>