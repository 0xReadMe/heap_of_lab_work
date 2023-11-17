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
<title>Задание 2</title>
<body>
    <form action="" method="GET">
        Твоё имя: <input placeholder="Ваше имя" type="text" name="name"><br>
        Твой возраст: <input placeholder="Ваш возраст" type="text" name="age"><br>
        Твоё сообщение: <input placeholder="Ваше сообщение" type="textarea" name="textarea"><br>
        <input type="submit">
    </form>
    <?php
        if (isset($_GET['name'])) {
            $name = strip_tags($_GET['name']);              
            echo 'Привет, '.$name;
        }
        if (isset($_GET['age'])) {
            $age = strip_tags($_GET['age']);       
            echo ', '.$age." лет."."<br>";
        }
        if (isset($_GET['textarea'])) {
            $textarea = strip_tags($_GET['textarea']);       
            echo 'Твоё сообщение: '.$textarea;
        }
    ?>
</body>
</html>