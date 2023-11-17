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

namespace Agents
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private RealizationProduct _product = new RealizationProduct();
        private int currentAgentID;

        public AddProduct(int _currentAgentID)
        {
            InitializeComponent();

            var allProduct = RustleEntities3.GetContext().Product.ToList();
            CBFilter.ItemsSource = allProduct;

            DataContext = _product;
            CBFilter.SelectedIndex = 1;

            currentAgentID = _currentAgentID;
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {

            _product.AgentId = currentAgentID;
            _product.ProductId = CBFilter.SelectedIndex + 1;

            StringBuilder errors = new StringBuilder();

            if (_product.ProductCount < 0)
            {
                errors.AppendLine("Введите количество продаж");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_product.IdRP == 0)
            {
                RustleEntities3.GetContext().RealizationProduct.Add(_product);
            }

            try
            {
                RustleEntities3.GetContext().SaveChanges();
                MessageBox.Show("Продажа добавлена");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
