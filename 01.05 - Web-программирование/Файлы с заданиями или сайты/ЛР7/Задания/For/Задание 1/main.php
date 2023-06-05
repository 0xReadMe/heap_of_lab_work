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
<title>Задание 1</title>
<body>
    <?php
        $arr = [1, 2, 3, 4, 5];
        $result = 0;
        foreach($arr as $elem)
        {
            $result += pow($elem, 2);
        }
        echo $result; 
    ?>
</body>
</html>