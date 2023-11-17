<!DOCTYPE html>
<html>
    <head>
    <meta charset = "UTF-8">
        <style>
            p {font-size: 20px;
                font-family: Arial, Helvetica, sans-serif;
                color: rgb(13, 0, 47);}
        </style>
        <title>Задание 3</title>
    </head>
    <body>
        <?php
        if (isset($_GET['age'])) {
            $age = $_GET['age'];
            echo $age;
        }

        if (!isset($_GET['age'])):
            ?>
            <form action="" method="get">
                <input name="age" placeholder="Введите ваш возраст">
                <input type="submit">
            </form>
        <?php endif; ?>
    </body>
</html>