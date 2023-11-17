using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using Payments.Model;

namespace Payments
{
    /// <summary>
    /// Логика взаимодействия для PaymentsAdd.xaml
    /// </summary>
    public partial class PaymentsAdd : Window
    {
        private static PaymentsUser _currentPaymentsUser = new PaymentsUser();
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

        public PaymentsAdd(int userId, PaymentsUser paymentsUser)
        {
            InitializeComponent();
            CbAddCategory.ItemsSource = PaymentsEntities.GetContext().Categories.ToList();
            if (paymentsUser == null)
            {
                _currentPaymentsUser.UserId = userId;
                _currentPaymentsUser.DatePayment = DateTime.Now;
            }
            else
            {
                _currentPaymentsUser = paymentsUser;
                TbCostPaymentAdd.Text = Convert.ToString(_currentPaymentsUser.Cost);
            }
            DataContext = _currentPaymentsUser;
        }

        private void BtnSavePayment_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPaymentsUser.Categories == null)
                errors.AppendLine("Выберите категорию");
            if (string.IsNullOrWhiteSpace(_currentPaymentsUser.Discription))
                errors.AppendLine("Укажите назначение платежа");
            if (_currentPaymentsUser.Count ==null)
                errors.AppendLine("Укажите количество");
            if (_currentPaymentsUser.Count <= 0)
                errors.AppendLine("Количество должно быть больше 0");
            if (_currentPaymentsUser.Price == null)
                errors.AppendLine("Укажите цену");
            if (_currentPaymentsUser.Price <= 0)
                errors.AppendLine("Цена должна быть больше 0");
            if (errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentPaymentsUser.Id == 0)
            {// _currentPaymentsUser.Cost =Convert.ToDecimal(TbCostPaymentAdd.Text);
                PaymentsEntities.GetContext().Payments.Add(_currentPaymentsUser);
            }
            try
            {
                PaymentsEntities.GetContext().SaveChanges();
                var rez= MessageBox.Show("Платеж сохранен","Информация о платеже",MessageBoxButton.OK);
                if (rez==MessageBoxResult.OK)
                {
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnCenselPayment_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TbPricePaymentAdd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TbCountPaymentAdd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TbPricePaymentAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
          try
            {
                if (TbCountPaymentAdd.Text == "" || TbPricePaymentAdd.Text == "") return;

                else
                {
                    TbCostPaymentAdd.Text = Convert.ToString(int.Parse(TbCountPaymentAdd.Text) * decimal.Parse(TbPricePaymentAdd.Text,formatter));
                }
           }

            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }

        private void TbCountPaymentAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TbCountPaymentAdd.Text == "" || TbPricePaymentAdd.Text == "") return;
                else
                {
                    TbCostPaymentAdd.Text = Convert.ToString(int.Parse(TbCountPaymentAdd.Text) * decimal.Parse(TbPricePaymentAdd.Text,formatter));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
