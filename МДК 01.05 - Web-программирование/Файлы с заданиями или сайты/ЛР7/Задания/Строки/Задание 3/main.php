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
        $text = "abcde";
        $char_array = str_split($text);
        echo $char_array[0]."<br>".$char_array[2]."<br>".$char_array[4]."<br>";
    ?>
</body>
</html>