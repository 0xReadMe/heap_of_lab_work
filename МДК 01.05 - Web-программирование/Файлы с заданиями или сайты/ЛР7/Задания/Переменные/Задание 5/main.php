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
    <p>Таблица умножения</p>
    <?php
        echo '<table>';
        for ($j = 1; $j <= 10; ++$j) {
            echo "<tr>";
            for ($i = 1; $i <= 10; ++$i) {
                echo '<td>', $i * $j, '</td>';
            }
            echo "</tr>";
        }
        echo '</table>';
        
        
    ?>
</body>
</html>