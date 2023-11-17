using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Agents
{
    /// <summary>
    /// Логика взаимодействия для EditingAgent.xaml
    /// </summary>
    public partial class EditingAgent : Window
    {
        private Agent _agent = new Agent();

        public EditingAgent(Agent selectedAgent)
        {
            InitializeComponent();

            if (selectedAgent != null)
            {
                _agent = selectedAgent;
            }

            var allTypes = RustleEntities3.GetContext().AgentTypes.ToList();
            CBFilter.ItemsSource = allTypes;
            CBFilter.SelectedIndex = selectedAgent.TypeID - 1;

            DataContext = selectedAgent;

            var _real = selectedAgent.RealizationProduct.ToList();
            DGSale.ItemsSource = _real;
        }

        private void ButDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить агента", "Внимание",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RustleEntities3.GetContext().Agent.Remove(_agent);
                    RustleEntities3.GetContext().SaveChanges();
                    MessageBox.Show("Агент удален");
                    GoMain();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ButDelSale_Click(object sender, RoutedEventArgs e)
        {
            var PRForDel = DGSale.SelectedItems.Cast<RealizationProduct>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {PRForDel.Count()} продажи", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    RustleEntities3.GetContext().RealizationProduct.RemoveRange(PRForDel);
                    RustleEntities3.GetContext().SaveChanges();
                    MessageBox.Show($"Количество удаленных продаж - {PRForDel.Count()}");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


        }

        private void ButAddSale_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct(_agent.AgentID);
            addProduct.Show();
        }

        private void ButChange_Click(object sender, RoutedEventArgs e)
        {
            _agent.TypeID = CBFilter.SelectedIndex + 1;

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_agent.AgentName))
            {
                errors.AppendLine("Имя слишком короткое");
            }
            if (string.IsNullOrEmpty(_agent.AgentEmail) || _agent.AgentEmail.Length < 6)
            {
                errors.AppendLine("Email слишком короткий");
            }
            if (string.IsNullOrEmpty(_agent.AgentEmail) || _agent.AgentPhone.Length < 6)
            {
                errors.AppendLine("Номер телефона слишком короткий");
            }
            if (string.IsNullOrEmpty(_agent.AgentAddress) || _agent.AgentAddress.Length < 10)
            {
                errors.AppendLine("Адресс слишком короткий");
            }
            if (_agent.AgentPriority < 0)
            {
                errors.AppendLine("Укажите приоритет");
            }
            if (string.IsNullOrEmpty(_agent.Director) || _agent.Director.Length < 3)
            {
                errors.AppendLine("Укажите имя директора");
            }
            if (_agent.AgentINN < 99999)
            {
                errors.AppendLine("Укажите ИНН");
            }
            if (_agent.AgentKPP < 99999)
            {
                errors.AppendLine("Укажите КПП");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_agent.AgentID == 0)
            {
                RustleEntities3.GetContext().Agent.Add(_agent);
            }

            try
            {
                RustleEntities3.GetContext().SaveChanges();
                MessageBox.Show("Данные обновлены");
                GoMain();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void ButRet_Click(object sender, RoutedEventArgs e)
        {
            GoMain();
        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var _agentForCount = RustleEntities3.GetContext().Agent.ToList();

                OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
                openFileDialog.ShowDialog(); // показываем
                string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var resourcePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(_BaseDirectory, @"..\..\")) + $"Resources\\agents\\agent_{_agent.AgentID}.png";
                if (File.Exists(resourcePath))
                {
                    File.Delete(resourcePath);
                }
                File.Copy(openFileDialog.FileName, resourcePath);
                _agent.AgentLogo = "Resources\\agents\\" + $"agent_{_agent.AgentID}.png";
            }
            catch
            {
                MessageBox.Show($"Вы не выбрали изображение");
            }
        }


        private void GoMain()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
