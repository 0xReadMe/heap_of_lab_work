using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Payments.Model;

namespace Payments
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CbUser.ItemsSource = PaymentsEntities.GetContext().Users.ToList();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BtbLogin_Click(object sender, RoutedEventArgs e)
        {
            if (CbUser.SelectedItem is Users currentUser)
            {
                MessageBox.Show($"{CbUser.SelectedIndex}");
                if (PwPassword.Password == currentUser.Password)
                {
                    var paymentWindow = new PaymentsWindow(currentUser);
                    paymentWindow.Owner = this;
                    paymentWindow.Title = "Платежи " + currentUser.Fio;
                    paymentWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
