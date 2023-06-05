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
        $new_text = "";
        $char_array = str_split($text);
        array_pop($char_array);
        array_push($char_array, "!");
        for($i = 0; $i < count($char_array); $i++)
        {
            $new_text .= $char_array[$i];
        }
        echo $new_text;
    ?>
</body>
</html>