<!DOCTYPE HTML>
<html>
    <head>
        <title>Авиакомпания FlightPool</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0">
        <link rel="shortcut icon" href="./assets/img/logo.png" type="image/x-icon">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" type="text/css" href="./css/index-page.css">
    </head>
    <body>
        <script src="https://kit.fontawesome.com/623ee197b9.js" crossorigin="anonymous"></script>
        <script src="https://kit.fontawesome.com/a6a2754c8e.js" crossorigin="anonymous"></script>
        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
        <header>
            <nav class="top-menu">
                <ul class="menu-main">
                  <li class="left-item"><a class="contacts" href="./pages/contact.html">Контакты</a></li>
                  <li class="left-item"><a class="promotions" href="./pages/promotions.html">Акции</a></li>
                  <li class="right-item"><a class="personalacc" href="./pages/personal account.php">Личный кабинет</a></li>
                </ul>
                <a class="navbar-logo" href="index.php">
                    <img src="./assets/img/ico/logo.png" width="75" height="75">
                </a>
            </nav>
        </header>
        <main>
            <h2 class="info-title" align="center">FlightPool</h2>
            <div class="information">
                <p>Приветствуем Вас на сайте компании FlightPool!</p>
                <p>Мы являемся новой и энергичной компанией, которая предоставляет пассажирские авиарейсы нашим клиентам!</p>
                <p>Наша главная цель - обеспечить безопасность перелётов для клиентов и организовать связность между городами.</p>
                <p>С нами Вы можете чувствовать себя в комфорте, не переплачивать стоимость билетов, а также всегда можете получить поддержку!</p>
            </div>
            <div class="wrapper">
                <input type="radio" name="point" id="slide1" checked>
                <input type="radio" name="point" id="slide2">
                <input type="radio" name="point" id="slide3">
                <input type="radio" name="point" id="slide4">
                <input type="radio" name="point" id="slide5">
                <div class="slider">
                    <div class="slides slide1"></div>
                    <div class="slides slide2"></div>
                    <div class="slides slide3"></div>
                    <div class="slides slide4"></div>
                    <div class="slides slide5"></div>
                </div>	
                <div class="controls">
                    <label for="slide1"></label>
                    <label for="slide2"></label>
                    <label for="slide3"></label>
                    <label for="slide4"></label>
                    <label for="slide5"></label>
                </div>
            </div>
        </main>
        <footer>
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