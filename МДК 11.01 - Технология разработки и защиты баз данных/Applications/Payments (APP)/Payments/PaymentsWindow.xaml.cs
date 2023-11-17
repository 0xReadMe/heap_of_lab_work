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
using System.Windows.Shapes;
using Payments.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace Payments

{
    /// <summary>
    /// Логика взаимодействия для PaymentsWindow.xaml
    /// </summary>
    public partial class PaymentsWindow : Window
    {
        private static Users _currentUser;
        private static List<PaymentsUser> _paymentsUser;
        public PaymentsWindow(Users currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            UpLoad();
            //List<Categories> categoriesList = PaymentsEntities.GetContext().Categories.ToList();
            //categoriesList.Insert(0, new Categories { Name = "Все категории" });
            //CbCategory.ItemsSource = categoriesList;
            //CbCategory.SelectedIndex = 0;
            //_paymentsUser =PaymentsEntities.GetContext().Payments.Where(p => p.UserId == _currentUser.Id).ToList();
            //DgPayments.ItemsSource = _paymentsUser;
            //DpkStart.SelectedDate = _paymentsUser.Min(p => p.DatePayment);
            //DpkEnd.SelectedDate= _paymentsUser.Max(p => p.DatePayment);
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            _paymentsUser = PaymentsEntities.GetContext().Payments.Where(p => p.UserId == _currentUser.Id).ToList();
            if (CbCategory.SelectedIndex != 0)
            {
                Categories categories = CbCategory.SelectedItem as Categories;
                // string filter = categories.Name.ToString();
                _paymentsUser = _paymentsUser.Where(p => p.CategoryId == categories.Id &&
                p.DatePayment >= DpkStart.SelectedDate && p.DatePayment <= DpkEnd.SelectedDate).ToList();
             }
            else
            {
                _paymentsUser = _paymentsUser.Where(p =>p.DatePayment >= DpkStart.SelectedDate && p.DatePayment <= DpkEnd.SelectedDate).ToList();
            }
             DgPayments.ItemsSource = _paymentsUser;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            CbCategory.SelectedIndex = 0;
            _paymentsUser = PaymentsEntities.GetContext().Payments.Where(p => p.UserId == _currentUser.Id).ToList();
            DgPayments.ItemsSource = _paymentsUser;
            DpkStart.SelectedDate = _paymentsUser.Min(p => p.DatePayment);
            DpkEnd.SelectedDate = _paymentsUser.Max(p => p.DatePayment);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var paymentsAdd = new PaymentsAdd(_currentUser.Id, null);
            paymentsAdd.Owner = this;
            paymentsAdd.Title = "Добавление платежа";
            paymentsAdd.ShowDialog();
            UpLoad();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var paymentsForRemoving = DgPayments.SelectedItems.Cast<PaymentsUser>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {paymentsForRemoving.Count()} элементов?","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                try
                {
                    PaymentsEntities.GetContext().Payments.RemoveRange(paymentsForRemoving);
                    PaymentsEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    UpLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        public void UpLoad()
        {
            List<Categories> categoriesList = PaymentsEntities.GetContext().Categories.ToList();
            categoriesList.Insert(0, new Categories { Name = "Все категории" });
            CbCategory.ItemsSource = categoriesList;
            CbCategory.SelectedIndex = 0;
            _paymentsUser = PaymentsEntities.GetContext().Payments.Where(p => p.UserId == _currentUser.Id).ToList();
            DgPayments.ItemsSource = _paymentsUser;
            DpkStart.SelectedDate = _paymentsUser.Min(p => p.DatePayment);
            DpkEnd.SelectedDate = _paymentsUser.Max(p => p.DatePayment);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var paymentsAdd = new PaymentsAdd(_currentUser.Id, DgPayments.SelectedItem as PaymentsUser);
            paymentsAdd.Owner = this;
            paymentsAdd.Title = "Редактирование платежа";
            paymentsAdd.ShowDialog();
            UpLoad();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font2 = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLDITALIC);
            using (var writer = PdfWriter.GetInstance(doc, new FileStream("pdfReport.pdf", FileMode.Create)))
            { 
                doc.Open();
                doc.AddTitle("Отчет");
                doc.NewPage();
                doc.Add(new iTextSharp.text.Paragraph("СПИСОК ПЛАТЕЖЕЙ",font1));
                foreach (var g in PaymentsEntities.GetContext().Categories)
                {
                    string categoryName = $"{g.Name,5}";
                      
                    List<PaymentsUser> rez = _paymentsUser.Where(p => p.Categories.Name == g.Name).ToList();
                    if (rez.Count != 0)
                    { doc.Add(new iTextSharp.text.Paragraph(categoryName, font2));
                        foreach (var p in rez)
                        {
                            string payment = string.Format("{0,-30}{1} рублей", p.Discription,p.Cost);
                            doc.Add(new iTextSharp.text.Paragraph(payment, font));
                        }
                    }
                }
                decimal sum =(decimal)_paymentsUser.Sum(p => p.Cost);
                doc.Add(new iTextSharp.text.Paragraph($"Итого {sum} рублей", font1));
                doc.Close();
            }
            MessageBox.Show("Документ записан");
        }

        private void BtnDiagram_Click(object sender, RoutedEventArgs e)
        {
            var paymentDiagram = new PaymentsDiagram(_paymentsUser);
            paymentDiagram.Owner = this;
            paymentDiagram.Title = "Анализ расходов";
            paymentDiagram.ShowDialog();
        }

        private void CbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

