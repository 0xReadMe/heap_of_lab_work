<!DOCTYPE HTML>
<html>
    <head>
        <title>Авиакомпания FlightPool</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" type="text/css" href="../css/personal-account.css">
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
            <div class="container">
                <div class="row g-0 mt-5 mb-5 height-100">
                    <div class="col-sm-3 col-md-6">
                        <div class="left-container"></div>
                    </div>
                    <div class="col-sm-3 col-md-6">
                        <form action="../php/validation-form/auth.php" method="POST">
                            <div class="right-container p-4 h-100">
                                <div class="p-3 d-flex justify-content-center flex-column align-items-center"> 
                                    <span class="main-title">Вход в личный кабинет</span>
                                    <ul class="social-list mt-3">
                                        <li>
                                            <i class="fa fa-facebook"></i>
                                        </li>
                                        <li>
                                            <i class="fa fa-google"></i>
                                        </li>
                                        <li>
                                            <i class="fa-brands fa-vk"></i>
                                        </li>
                                    </ul>
                                    <div class="form-data"> 
                                        <label>Телефон</label> 
                                        <input type="phone" name="phone" id="phone" class="form-control w-100"> 
                                    </div>
                                    <div class="form-data"> 
                                        <label>Пароль</label> 
                                        <input type="password" name="pwd" id="pwd" class="form-control w-100"> 
                                    </div>
                                    <div class="d-flex justify-content-between w-100 align-items-center">
                                        <div class="form-check"> 
                                            <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault"> 
                                            <label class="form-check-label" for="flexCheckDefault"> Запомнить меня </label> 
                                        </div>
                                        <a class="notaccont" href="./registration.html">Нет аккаунта?</a> 
                                    </div>
                                    <div class="signin-btn w-100 mt-2"> 
                                        <button class="btn btn-block btn-primary" type="submit">Войти</button> 
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>  
        </main>
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