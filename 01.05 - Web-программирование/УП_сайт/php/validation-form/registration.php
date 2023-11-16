<?php
    $surname = strip_tags(trim($_POST['surname']));
    $name = strip_tags(trim($_POST['name']));
    $phone = strip_tags(trim($_POST['phone']));
    $email = strip_tags(trim($_POST['email']));
    $pwd = strip_tags(trim($_POST['pwd']));

    require ("../connect.php");
    $connect->query("INSERT INTO `users` (`surname`,`name`,`phone`,`email`,`password`) VALUES('$surname','$name','$phone','$email','$pwd')");
    $connect->close();

    header('Location: /ЖдановУП/pages/personal%20account.php');
    
?>