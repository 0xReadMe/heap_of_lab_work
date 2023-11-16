<?php
    $phone = $_POST['phone'];
    $pwd = strip_tags(trim($_POST['pwd']));

    require ("../connect.php");

    $auth_q = $connect->query("SELECT * FROM `users` WHERE `phone` = '$phone' AND `password` = '$pwd'");
    $auth = $auth_q->fetch_assoc();
    print_r($auth);
    if(empty($auth)){
        header('Location: /ЖдановУП/pages/neverno.html');
        exit();
    }
    
    setcookie('user', $auth['name'], time() + 3600, "/");
    setcookie('suruser', $auth['surname'], time() + 3600, "/");
    setcookie('role', $auth['role'], time() + 3600, "/");
    setcookie('id', $auth['id'], time() + 3600, "/");

    $connect->close();

    if($auth['role'] == '0'){
        header('Location: /ЖдановУП/pages/personal-auth.php');
        exit();
    } 
    else{
        header('Location: /ЖдановУП/pages/admin.php');
        exit();
    }
?>