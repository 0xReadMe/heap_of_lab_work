<!DOCTYPE html>
<html>
<head>
<meta charset = "UTF-8">
</head>
<style>
    p {
        font-size: 20px;
        font-family: Arial, Helvetica, sans-serif;
        color: rgb(13, 0, 47);
    }
</style>
<title>задание 2</title>
<body>
    <p>Задание 2</p>
    <?php
        $arr2 =['Коля'=>200, 'Вася'=>300,  'Петя'=>400];
        foreach($arr2 as $key => $elem)
        {
            echo $key." - зарплата ".$elem." долларов"."<br>";
        }
    ?>
</body>
</html>