using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Input;

namespace PayM
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        private static Users _currentUser;
        private static List<Payments> _paymentsUser;
        public MainWindow(Users currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            Upload();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var paymentsAdd = new Addendum(_currentUser.Id, UsersData.SelectedItem as Payments);
            paymentsAdd.Owner = this;
            paymentsAdd.Title = "Редактирование платежа";
            paymentsAdd.ShowDialog();
            Upload();
        }

        public void Upload()
        {
            using (PaymentsEntities dbContext = new PaymentsEntities()) 
            {
                List<Categories> categoriesList = dbContext.Categories.ToList();
                categoriesList.Insert(0, new Categories { Name = "Все категории" });
                List<string> categoriesName = new List<string>();
                foreach (var category in categoriesList)
                {
                    categoriesName.Add(category.Name);
                }
                Category.ItemsSource = categoriesName;
                Category.SelectedIndex = 0;
                _paymentsUser = dbContext.Payments.Where(p => p.UserId == _currentUser.Id).ToList();
                UsersData.ItemsSource = _paymentsUser;
                DpStart.SelectedDate = _paymentsUser.Min(p => p.DatePayment);
                DpEnd.SelectedDate = _paymentsUser.Max(p => p.DatePayment);
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e) 
        {
            Category.SelectedIndex = 0;
            using (PaymentsEntities dbContext = new PaymentsEntities())
            {
                _paymentsUser = dbContext.Payments.Where(p => p.UserId == _currentUser.Id).ToList();
                UsersData.ItemsSource = _paymentsUser;
                DpStart.SelectedDate = _paymentsUser.Min(p => p.DatePayment);
                DpEnd.SelectedDate = _paymentsUser.Max(p => p.DatePayment);
            }
                
        }
        private void Filter_Click(object sender, RoutedEventArgs e) 
        {
            using (PaymentsEntities dbContext = new PaymentsEntities()) 
            {
                _paymentsUser = dbContext.Payments.Where(p => p.UserId == _currentUser.Id).ToList();
                if (Category.SelectedIndex != 0)
                {
                    Categories categories = Category.SelectedItem as Categories;
                    // string filter = categories.Name.ToString();
                    _paymentsUser = _paymentsUser.Where(p => p.CategoryId == categories.Id &&
                    p.DatePayment >= DpStart.SelectedDate && p.DatePayment <= DpEnd.SelectedDate).ToList();
                }
                else
                {
                    _paymentsUser = _paymentsUser.Where(p => p.DatePayment >= DpStart.SelectedDate && p.DatePayment <= DpEnd.SelectedDate).ToList();
                }
                UsersData.ItemsSource = _paymentsUser;
            }    
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var paymentsAdd = new Addendum(_currentUser.Id, null);
            paymentsAdd.Owner = this;
            paymentsAdd.Title = "Добавление платежа";
            paymentsAdd.ShowDialog();
            Upload();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var paymentsForRemoving = UsersData.SelectedItems.Cast<Payments>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {paymentsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    using (PaymentsEntities dbContext = new PaymentsEntities()) 
                    {
                        dbContext.Payments.RemoveRange(paymentsForRemoving);
                        dbContext.SaveChanges();
                        MessageBox.Show("Данные удалены");
                        Upload();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font2 = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLDITALIC);
            using (var writer = PdfWriter.GetInstance(doc, new FileStream("pdfReport.pdf", FileMode.Create)))
            {
                using (PaymentsEntities dbContext = new PaymentsEntities()) 
                {
                    doc.Open();
                    doc.AddTitle("Отчет");
                    doc.NewPage();
                    doc.Add(new iTextSharp.text.Paragraph("СПИСОК ПЛАТЕЖЕЙ", font1));
                    foreach (var g in dbContext.Categories)
                    {
                        string categoryName = $"{g.Name,5}";
                        List<Payments> rez = _paymentsUser.Where(p => p.Categories.Name == g.Name).ToList();
                        if (rez.Count != 0)
                        {
                            doc.Add(new iTextSharp.text.Paragraph(categoryName, font2));
                            foreach (var p in rez)
                            {
                                string payment = string.Format("{0,-30}{1} рублей", p.Discription, p.Cost);
                                doc.Add(new iTextSharp.text.Paragraph(payment, font));
                            }
                        }
                    }
                    decimal sum = (decimal)_paymentsUser.Sum(p => p.Cost);
                    doc.Add(new iTextSharp.text.Paragraph($"Итого {sum} рублей", font1));
                    doc.Close();
                }
            }
            MessageBox.Show("Документ записан");
        }
    }
}