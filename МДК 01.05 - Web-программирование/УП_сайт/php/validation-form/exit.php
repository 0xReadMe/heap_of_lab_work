<?php
    setcookie('user', $user['name'], time() - 3600, "/");
    setcookie('suruser', $user['surname'], time() - 3600, "/");
    header('Location: /ЖдановУП/pages/personal account.php');
?>