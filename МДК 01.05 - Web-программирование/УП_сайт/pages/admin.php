<!DOCTYPE HTML>
<html>
    <head>
        <title>Авиакомпания FlightPool</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" type="text/css" href="../css/auth-person.css">
        <link rel="shortcut icon" href="../assets/img/logo.png" type="image/x-icon">
    </head>
    <body>
        <script src="https://kit.fontawesome.com/623ee197b9.js" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
        <header>
            <nav class="top-menu">
                <ul class="menu-main">
                  <li class="right-item"><a class="return-to-menu" href="../index.php">На главную</a></li>
                  <li class="left-item"><a class="promotions" href="promotions.html">Акции</a></li>
                  <li class="left-item"><a class="contacts" href="contact.html">Контакты</a></li>
                </ul>
                <a class="navbar-logo" href="../index.php">
                    <img src="../assets/img/ico/logo.png" width="75" height="75">
                </a>
            </nav>
        </header>
        <main>
            <div class="hello-block">
                <h1 class="regist">Здравствуйте, <?=$_COOKIE['user']; ?> <?=$_COOKIE['suruser'] ?></h1>
                <h1 class="regist">Все актуальные бронирования</h1>
            </div>
            <div class="block-php">
            <?php
            	$mysql = new mysqli('localhost', 'root', '', 'flightpool');
            	mysqli_set_charset($mysql, "utf8");
                $query ="SELECT * FROM users INNER JOIN booking ON  booking.id_user = users.id";
            	$result = $mysql->query($query);
            	while($row = $result->fetch_assoc())
			    {
                    echo '<div style="background-color: rgba(42, 38, 168, 0.637);"> Имя пользователя: '.$row['name'].'</div>';
                    echo '<div style="background-color: rgba(42, 38, 168, 0.637);"> <span> Фамилия пользователя: </span>'.$row['surname'].'</div>';
                    echo '<div style="background-color: rgba(42, 38, 168, 0.637);"> Tелефон пользователя: </span>'.$row['phone'].'</div>';		
                    echo '<div style="border-top: 2px solid rgba(42, 38, 168, 0.637); background-color: rgba(42, 38, 168, 0.637)"> Дата вылета: '.$row['departure_date'];
                    echo '<div><span> Время вылета: '.$row['departure_time'].'</span></div>';
                    echo '<p> <span> Дата прибытия: </span>'.$row['arrival_time'].'<p>';
                    echo '<span> Вылет из аэропорта: </span>'.$row['airport_of_departure'];	
                    echo '<div><span> Дистанция полёта: </span>'.$row['destination_airport'].'</div>';	
                    echo '</div>';
                    echo '<div style="border: 2px dotted rgba(42, 38, 168, 0.637); background-color: azure;"></div>';
			    }
            ?>
            </div>
            <div class="button-block">
                <form action="../php/validation-form/exit.php">
                   <button class="btn-exit">Выйти из личного кабинета</button>
                </form>
            </div>
        </main>
        <br>
        <br>
        <br>
        <br>
        <footer class="footer fixed-bottom">
            <div class="footer-container">
                <div class="d-sm-flex justify-content-between">
                    <div class="footer-left">
                        <a href="#">Политика конфиденциальности</a>
                        <a href="#">Условия использования</a>
                    </div>
                    <div class="footer-right">
                        <a href="#"><i class="fa-brands fa-instagram-square"></i></a>
                        <a href="#"><i class="fa-brands fa-vk"></i></a>
                        <a href="#"><i class="fa-brands fa-facebook-square"></i></a>
                    </div>
                </div>
            </div>
        </footer>
    </body>
</html>