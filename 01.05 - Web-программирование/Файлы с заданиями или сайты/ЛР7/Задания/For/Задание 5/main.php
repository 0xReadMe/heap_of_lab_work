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
<title>Задание 5</title>
<body>
    <p></p>
    <?php
        $arr5 = array();
        for ($i = 1; $i < 101; $i++) {
            $arr5[] = $i;
        }
        foreach($arr5 as $elem){
            echo $elem."<br>";
        }        
    ?>
</body>
</html>