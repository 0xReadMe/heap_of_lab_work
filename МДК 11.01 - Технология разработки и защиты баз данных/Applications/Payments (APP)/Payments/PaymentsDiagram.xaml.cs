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
using System.Windows.Forms.DataVisualization.Charting;

namespace Payments
{
    /// <summary>
    /// Логика взаимодействия для PaymentsDiagram.xaml
    /// </summary>
    public partial class PaymentsDiagram : Window
    {
        private static List<PaymentsUser> _paymentsDiagram;
        public PaymentsDiagram(List<PaymentsUser> paymentsUsers)
        {
            InitializeComponent();
            _paymentsDiagram = paymentsUsers;
            ChartPayments.ChartAreas.Add(new ChartArea("Main"));
            var currentSeries = new Series("PaymentsDiagram")
            {
                IsValueShownAsLabel = true
            };
            ChartPayments.Series.Add(currentSeries);
            CbChartTypes.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if(CbChartTypes.SelectedItem is SeriesChartType currentType)
            {
                Series currentSeries = ChartPayments.Series.FirstOrDefault();
                currentSeries.ChartType = currentType;
                currentSeries.Points.Clear();
                var categoriesList = PaymentsEntities.GetContext().Categories.ToList();
                foreach (var category in categoriesList)
                {
                    currentSeries.Points.AddXY(category.Name,
                        _paymentsDiagram.Where(p => p.Categories == category).Sum(p => p.Cost));
                }

            }
        }

        private void BtnCloseDiagram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
