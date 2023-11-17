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

namespace PayM
{
    //private static PaymentsUser _currentPaymentsUser = new PaymentsUser();
    //IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

    /// <summary>
    /// Логика взаимодействия для Addendum.xaml
    /// </summary>
    public partial class Addendum : Window
    {
        private static Payments _currentPaymentsUser = new Payments();
        IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        public Addendum(int userId, Payments paymentsUser)
        {
            InitializeComponent();
            using (PaymentsEntities dbContext = new PaymentsEntities()) 
            {
                CategoryCB.ItemsSource = dbContext.Categories.ToList();
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
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentPaymentsUser.Categories == null) errors.AppendLine("Выберите категорию");
            if (string.IsNullOrWhiteSpace(_currentPaymentsUser.Discription)) errors.AppendLine("Укажите назначение платежа");
            if (_currentPaymentsUser.Count == null) errors.AppendLine("Укажите количество");
            if (_currentPaymentsUser.Count <= 0) errors.AppendLine("Количество должно быть больше 0");
            if (_currentPaymentsUser.Price == null) errors.AppendLine("Укажите цену");
            if (_currentPaymentsUser.Price <= 0) errors.AppendLine("Цена должна быть больше 0");

            try
            {
                if (errors.Length > 0)
                {       
                    throw new Exception(errors.ToString());
                }
                if (_currentPaymentsUser.Id == 0)
                {
                    // _currentPaymentsUser.Cost =Convert.ToDecimal(TbCostPaymentAdd.Text);
                    using (PaymentsEntities dbContext = new PaymentsEntities())
                    {
                        dbContext.Payments.Add(_currentPaymentsUser);
                    }
                }
                try
                {
                    using (PaymentsEntities dbContext = new PaymentsEntities())
                    {
                        dbContext.SaveChanges();
                        var rez = MessageBox.Show("Платеж сохранен", "Информация о платеже", MessageBoxButton.OK);
                        if (rez == MessageBoxResult.OK)
                        {
                            Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        private void TbPricePaymentAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TbCountPaymentAdd.Text == "" || TbPricePaymentAdd.Text == "") return;

                else
                {
                    TbCostPaymentAdd.Text = Convert.ToString(int.Parse(TbCountPaymentAdd.Text) * decimal.Parse(TbPricePaymentAdd.Text, formatter));
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
                    TbCostPaymentAdd.Text = Convert.ToString(int.Parse(TbCountPaymentAdd.Text) * decimal.Parse(TbPricePaymentAdd.Text, formatter));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
