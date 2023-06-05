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
        $arr =[2, 5, 3, 9];
        $result = ($arr[0]*$arr[1])+($arr[2]*$arr[3]);
        print $result."<br>";
    ?>
</body>
</html>