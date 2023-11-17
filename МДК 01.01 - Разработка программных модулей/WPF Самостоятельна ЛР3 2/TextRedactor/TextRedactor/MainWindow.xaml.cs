using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
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

namespace TextRedactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Combo.SelectedIndex = 0;
        }
        

        #region Размер кисти
        double temp;

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            temp = (double)e.NewValue;
        }
        private void Prin_Click(object sender, RoutedEventArgs e)
        {
            ColorKist.Width = temp;
            ColorKist.Height = temp;
        }
        #endregion

        #region Режимы работы
        private void RadioButton_Boot1_Checked(object sender, RoutedEventArgs e)
        {
            ColorKist.Color = Color.FromRgb(0, 0, 0);
            Combo.SelectedIndex = 0;
            ColorKist.Width = temp;
            ColorKist.Height = temp;
        }

        private void RadioButton_Boot2_Checked(object sender, RoutedEventArgs e)
        {
            ColorKist.Color = Color.FromRgb(255, 255, 255);
            ColorKist.Width = temp;
            ColorKist.Height = temp;
        }

        private void RadioButton_Boot3_Checked(object sender, RoutedEventArgs e)
        {
            ColorKist.Color = Color.FromRgb(255, 255, 255);
            ColorKist.Width = 2000;
            ColorKist.Height = 2000;
        }
        #endregion

        #region Режимы работы
        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Combo.SelectedIndex == 0)
                ColorKist.Color = Color.FromRgb(255, 0, 0);
            if (Combo.SelectedIndex == 1)
                ColorKist.Color = Color.FromRgb(0, 255, 0);
            if (Combo.SelectedIndex == 2)
                ColorKist.Color = Color.FromRgb(0, 0, 255);
            if (Combo.SelectedIndex == 3)
                ColorKist.Color = Color.FromRgb(0, 0, 0);
            if (Combo.SelectedIndex == 4)
                ColorKist.Color = Color.FromRgb(255, 255, 0);                  
        }
        #endregion
    }
}
