<!DOCTYPE html>
<html>
    <head>
        <meta charset = "UTF-8">
        <style>
            p {font-size: 20px;
                font-family: Arial, Helvetica, sans-serif;
                color: rgb(13, 0, 47);}
        </style>
        <title>Задание 1</title>
    </head>
    <body>
        <form action="" method="GET">
            <input type="text" name="name">
            <input type="submit">
        </form>
        <?php
            if (isset($_GET['name'])) {
                $name = strip_tags($_GET['name']);
                echo 'Привет, '.$name;
            }
        ?>

    </body>
</html>