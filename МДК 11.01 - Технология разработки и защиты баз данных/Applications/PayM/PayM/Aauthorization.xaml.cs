using System;
using System.Linq;
using System.Windows;

namespace PayM
{
    /// <summary>
    /// Логика взаимодействия для Aauthorization.xaml
    /// </summary>
    public partial class Aauthorization : Window
    {
        public Aauthorization()
        {
            InitializeComponent();
            using(PaymentsEntities dbContext = new PaymentsEntities()) 
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                dbContext.Configuration.LazyLoadingEnabled = false;

                UserField.ItemsSource = dbContext.Users
                    .Select(user => user.Login)
                    .ToList();

            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var login = UserField.Text.Trim();
            var pwd = PasswordField.Password;
            try
            {
                using (PaymentsEntities dbContext = new PaymentsEntities())
                {
                    var dbPassword = dbContext.Users
                        .Where(user => user.Login == login)
                        .Select(user => user.Password)
                        .ToArray()[0];
                    if (dbPassword == PasswordField.Password)
                    {
                        Users currentUser = dbContext.Users.Where(user => user.Login == login).ToArray()[0];
                        MainWindow mainWindow = new MainWindow(currentUser);
                        mainWindow.Show();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show($"Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
                                
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
